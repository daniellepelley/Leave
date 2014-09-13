namespace Hermes.Leave.Services
{
    public interface ILeavePolicy
    {
        int HoursPerDay { get; set; }
        int Allowance { get; set; }
    }
}