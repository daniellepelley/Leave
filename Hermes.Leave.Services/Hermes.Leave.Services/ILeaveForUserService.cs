using System.Collections.Generic;
using Hermes.Leave.Services.Model;

namespace Hermes.Leave.Services
{
    public interface ILeaveForUserService
    {
        List<LeaveItem> GetLeaveForUser(int userId);
    }
}