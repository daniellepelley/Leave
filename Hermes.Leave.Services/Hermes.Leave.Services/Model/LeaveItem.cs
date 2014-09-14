using System;

namespace Hermes.Leave.Services.Model
{
    public class LeaveItem
    {
        public int UserId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public LeaveItemStatus Status { get; set; }
    }
}
