using System;
using System.Collections.Generic;
using System.Linq;
using Hermes.Data.Repositories.Interfaces;
using Hermes.Leave.Services.Model;

namespace Hermes.Leave.Mvc.Controllers
{
    public class LeaveItemRepository : IRepository<LeaveItem>
    {
        public LeaveItemRepository()
        {
            var list = new List<LeaveItem>();
            list.Add(new LeaveItem
            {
                StartDateTime = new DateTime(2013, 3, 1),
                EndDateTime = new DateTime(2013, 3, 2),
                Status = LeaveItemStatus.Approved,
                UserId = 1
            });
            list.Add(new LeaveItem
            {
                StartDateTime = new DateTime(2013, 3, 4),
                EndDateTime = new DateTime(2013, 3, 5),
                Status = LeaveItemStatus.Approved,
                UserId = 1
            });
            Items = list.AsQueryable();
        }

        public IDataContext DataContext { get; private set; }
        public IQueryable<LeaveItem> Items { get; private set; }
        public void Delete(LeaveItem entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(LeaveItem entity)
        {
            throw new NotImplementedException();
        }
    }
}