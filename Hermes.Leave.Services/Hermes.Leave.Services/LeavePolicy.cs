namespace Hermes.Leave.Services
{
    public class LeavePolicy : ILeavePolicy
    {
        public int HoursPerDay { get; set; }
        public int Allowance { get; set; }
    }
}