using Hermes.Leave.Services.Model;

namespace Hermes.Leave.Services
{
    public interface ILeaveCardService
    {
        LeaveCard GetLeaveCard(int userId);
    }
}