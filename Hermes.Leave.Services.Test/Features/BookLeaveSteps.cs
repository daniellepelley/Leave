using System.Collections.Generic;
using Hermes.Leave.Services.Model;
using Hermes.Validation.Rules.Preset.String;
using Moq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Hermes.Leave.Services.Test.Features
{
    [Binding]
    public class BookLeaveSteps
    {
        //private LeavePolicy _policy = new LeavePolicy();

        LeaveServiceBuilder _builder = new LeaveServiceBuilder();

        private LeaveCard _leaveCard;

        public BookLeaveSteps()
        {
            _builder = new LeaveServiceBuilder();          
        }

        [Given(@"the leave policy is for (.*) hours per year")]
        public void GivenTheLeavePolicyIsForHoursPerYear(int allowance)
        {
            _builder.WithAllowance(allowance);
        }

        [Given(@"the leave policy is for (.*) hours per day")]
        public void GivenTheLeavePolicyIsForHoursPerDay(int hoursPerDay)
        {
            _builder.WithHourPerDay(hoursPerDay);
        }

        [Given(@"I have (.*) days booked leave")]
        public void GivenIHaveDaysBookedLeave(int days)
        {
            var list = new List<LeaveItem>();

            for (int i = 0; i < days; i++)
            {
                list.Add(new LeaveItem {UserId = 1});
            }
            _builder.WithLeaveItems(list);  
        }

        [When(@"I request a leave card")]
        public void WhenIRequestALeaveCard()
        {
            var sut = _builder.Build();
            _leaveCard = sut.GetLeaveCard(1);
        }

        [Then(@"the leave card should show (.*) hours allowance")]
        public void ThenTheLeaveCardShouldShowHoursAllowance(int allowance)
        {
            Assert.AreEqual(allowance, _leaveCard.Allowance);
        }

        [Then(@"the leave card should show (.*) hours taken")]
        public void ThenTheLeaveCardShouldShowHoursTaken(int taken)
        {
            Assert.AreEqual(taken, _leaveCard.Taken);
        }

        [Then(@"the leave card should show (.*) hours remaining")]
        public void ThenTheLeaveCardShouldShowHoursRemaining(int remaining)
        {
            Assert.AreEqual(remaining, _leaveCard.Remaining);
        }
    }
}
