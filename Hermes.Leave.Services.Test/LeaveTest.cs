using System.Linq;
using Hermes.Leave.Services.Model;
using NUnit.Framework;

namespace Hermes.Leave.Services.Test
{
    public class LeaveTest
    {
        private LeaveTestHelper _helper;

        [SetUp]
        public void SetUp()
        {
            _helper = new LeaveTestHelper();
        }

        [Test]
        public void GetLeave()
        {
            var sut = _helper.LeaveServiceBuilder.Build();

            var leave = sut.GetLeave();

            Assert.AreEqual(_helper.Count(), leave.Count());
        }

        [Test]
        public void LeaveFromUserId()
        {
            var sut = _helper.LeaveServiceBuilder.Build();
            
            const int userId = 1;
            var leave = sut.GetLeaveForUser(userId);
            var expected = _helper.CountWhereUserId(userId);

            Assert.AreEqual(expected, leave.Count());
        }

        [Test]
        public void LeaveFromDateRange()
        {
            var sut = _helper.LeaveServiceBuilder.Build();
            var leave = sut.GetLeaveFromDateRange(LeaveTestHelper.Monday, LeaveTestHelper.Wednesday);

            var expected = _helper.CountByDate(LeaveTestHelper.Monday, LeaveTestHelper.Wednesday);

            Assert.AreEqual(expected, leave.Count);
        }

        [Test]
        public void AddLeave()
        {
            var sut = _helper.LeaveServiceBuilder.Build();
            var expected = _helper.Count() + 1;

            sut.Add(new LeaveItem());

            Assert.AreEqual(expected, _helper.Count());
        }
    }
}
