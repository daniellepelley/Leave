using System.Collections;
using System.Collections.Generic;
using Hermes.Data.InMemory;
using Hermes.Data.Repositories.Interfaces;
using Hermes.Leave.Services.Model;
using Moq;

namespace Hermes.Leave.Services.Test
{
    public class LeaveServiceBuilder
    {
        private IRepository<LeaveItem> _repository;
        private int _hoursPerDay;
        private int _allowance;
        private IEnumerable<LeaveItem> _leaveItems;

        public LeaveServiceBuilder()
        {
            _repository = CreateRepository();
            _hoursPerDay = 8;
            _allowance = 100;
        }

        private IRepository<LeaveItem> CreateRepository()
        {
            var dataContext = new InMemoryDataContext<LeaveItem>();
            return new InMemoryRepository<LeaveItem>(dataContext);
        }

        public void WithRepository(IRepository<LeaveItem> repository)
        {
            _repository = repository;
        }

        public void WithHourPerDay(int hoursPerDay)
        {
            _hoursPerDay = hoursPerDay;
        }

        public void WithAllowance(int allowance)
        {
            _allowance = allowance;
        }

        public void WithLeaveItems(IEnumerable<LeaveItem> leaveItems)
        {
            _leaveItems = leaveItems;
        }

        public LeaveService Build()
        {
            var mockLeavePolicy = new Mock<ILeavePolicy>();
            mockLeavePolicy.SetupGet(x => x.HoursPerDay)
                .Returns(_hoursPerDay);

            mockLeavePolicy.SetupGet(x => x.Allowance)
                .Returns(_allowance);

            foreach (var l in _leaveItems)
            {
                _repository.Insert(l);                
            }

            return new LeaveService(_repository, mockLeavePolicy.Object);
        }
    }
}