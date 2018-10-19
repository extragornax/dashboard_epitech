using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

namespace dashboard_api.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class SessionController : ControllerBase {
        private static Models.IUserRepository userRepo = new Models.UserRepository("");
        private static Models.ISessionRepository sessionRepo = new Models.SessionRepository("");

        public SessionController() {}

        [HttpPost]
        public ActionResult<Models.User> Start(Models.User user) {
            var match = userRepo.GetByName(user.Name);
            if (match == null) {
                return NotFound();
            }
            if (match.Password != user.Password) {
                return Forbid();
            }
            var activeSession = sessionRepo.GetByUserId(match.Id.ToString());
            if (activeSession == null) {
                activeSession = sessionRepo.Add(new Models.Session { UserId = match.Id });
            }
            match.SessionId = activeSession.Id;
            match.Password = "";
            return match;
        }
    }
}
