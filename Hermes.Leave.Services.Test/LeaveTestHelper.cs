using System;
using System.Collections.Generic;
using System.Linq;
using Hermes.Data.InMemory;
using Hermes.Data.Repositories.Interfaces;
using Hermes.Leave.Services.Model;
using Moq;

namespace Hermes.Leave.Services.Test
{
    public class LeaveTestHelper
    {
        private readonly List<LeaveItem> _list;

        private InMemoryDataContext<LeaveItem> _dataContext;
        private readonly LeaveServiceBuilder _leaveServiceBuilder;

        public int CountWhereUserId(int userId)
        {
            return _dataContext.List.Count(x => x.UserId == 1);
        }

        public int Count()
        {
            return _dataContext.List.Count();
        }

        public int CountByDate(DateTime startDateTime, DateTime endDateTime)
        {
            return _dataContext.List.Count(x =>
                x.StartDateTime >= startDateTime &&
                x.EndDateTime <= endDateTime);
        }

        public static DateTime Monday
        {
            get { return new DateTime(2014, 9, 15); }
        }

        public static DateTime Tuesday
        {
            get { return new DateTime(2014, 9, 16); }
        }

        public static DateTime Wednesday
        {
            get { return new DateTime(2014, 9, 17); }
        }

        public static DateTime Thursday
        {
            get { return new DateTime(2014, 9, 18); }
        }

        public LeaveServiceBuilder LeaveServiceBuilder
        {
            get { return _leaveServiceBuilder; }
        }

        public LeaveTestHelper(List<LeaveItem> list = null)
        {
            if (list != null)
            {
                _list = list;
            }
            else
            {
                _list = new List<LeaveItem>
                {
                    new LeaveItem {UserId = 1, StartDateTime = Monday, EndDateTime = Wednesday},
                    new LeaveItem {UserId = 1, StartDateTime = Monday, EndDateTime = Thursday},
                    new LeaveItem {UserId = 1, StartDateTime = Wednesday, EndDateTime = Thursday},
                    new LeaveItem {UserId = 1, StartDateTime = Tuesday, EndDateTime = Wednesday},
                    new LeaveItem {UserId = 2, StartDateTime = Monday, EndDateTime = Tuesday}
                };
            }
            _leaveServiceBuilder = new LeaveServiceBuilder();
            _leaveServiceBuilder.WithRepository(CreateRepository());
            _leaveServiceBuilder.WithLeaveItems(_list);
        }

        public IRepository<LeaveItem> CreateRepository()
        {
            _dataContext = new InMemoryDataContext<LeaveItem>();
            return new InMemoryRepository<LeaveItem>(_dataContext);
        }
    }
}