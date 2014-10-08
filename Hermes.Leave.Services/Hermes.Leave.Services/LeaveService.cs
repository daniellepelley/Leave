using System;
using System.Collections.Generic;
using System.Linq;
using Hermes.Data.Repositories.Interfaces;
using Hermes.Leave.Services.Model;

namespace Hermes.Leave.Services
{
    public class LeaveService : ILeaveCardService, ILeaveForUserService
    {
        private readonly IRepository<LeaveItem> _repository;
        private readonly ILeavePolicy _leavePolicy;

        public LeaveService(IRepository<LeaveItem> repository, ILeavePolicy leavePolicy)
        {
            _leavePolicy = leavePolicy;
            _repository = repository;
        }

        public List<LeaveItem> GetLeave()
        {
            return _repository.Items.ToList();
        }

        public List<LeaveItem> GetLeaveForUser(int userId)
        {
            return _repository.Items
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public List<LeaveItem> GetLeaveFromDateRange(DateTime startDateTime, DateTime endDateTime)
        {
            return _repository.Items
                .Where(x => 
                    x.StartDateTime >= startDateTime &&
                    x.EndDateTime <= endDateTime)
                .ToList();
        }

        public void Add(LeaveItem leaveItem)
        {
            _repository.Insert(leaveItem);
        }

        public LeaveCard GetLeaveCard(int userId)
        {
            var taken = GetLeaveForUser(userId).Count() * _leavePolicy.HoursPerDay; 

            return new LeaveCard
            {
                Allowance = _leavePolicy.Allowance,
                Taken = taken
            };
        }
    }
}
