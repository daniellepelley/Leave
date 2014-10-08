using System.Web;
using System.Web.Mvc;
using Hermes.Data.EntityFramework;
using Hermes.Leave.Services;

namespace Hermes.Leave.Mvc.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ILeaveForUserService _leaveForUserService;
        private readonly ILeaveCardService _leaveCardService;

        public LeaveController(ILeaveForUserService leaveForUserService, ILeaveCardService leaveCardService)
        {
            _leaveCardService = leaveCardService;
            _leaveForUserService = leaveForUserService;
        }

        public ActionResult CurrentLeaveCard()
        {
            return View(_leaveCardService.GetLeaveCard(1));
        }

        public ActionResult LeaveItems()
        {
            return View(_leaveForUserService.GetLeaveForUser(1));
        }
    }
}