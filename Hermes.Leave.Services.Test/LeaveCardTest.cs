using System.Linq;
using Hermes.Leave.Services.Model;
using NUnit.Framework;

namespace Hermes.Leave.Services.Test
{
    public class LeaveCardTest
    {
        private LeaveTestHelper _helper;

        [SetUp]
        public void SetUp()
        {
            _helper = new LeaveTestHelper();
        }

        [Test]
        public void TakenIsCalculatedFromBookedLeave()
        {
            const int hoursPerDay = 6;

            _helper.LeaveServiceBuilder
                .WithHourPerDay(hoursPerDay);

            var sut = _helper.LeaveServiceBuilder.Build();

            var expected = _helper.CountWhereUserId(1) * hoursPerDay;

            var leaveCard = sut.GetLeaveCard(1);

            Assert.AreEqual(expected, leaveCard.Taken);
        }

        [Test]
        public void RemainingEqualsAllowanceMinusTaken()
        {
            const int allowance = 80;

            _helper.LeaveServiceBuilder
                .WithAllowance(allowance);

            var sut = _helper.LeaveServiceBuilder.Build();

            var expected = allowance - _helper.CountWhereUserId(1) * 8;

            var leaveCard = sut.GetLeaveCard(1);

            Assert.AreEqual(expected, leaveCard.Remaining);            
        }
    }
}