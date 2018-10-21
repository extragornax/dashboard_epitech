/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** SessionController
*/

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private static Models.IUserRepository userRepo = new Models.UserRepository("");
        private static Models.ISessionRepository sessionRepo = new Models.SessionRepository("");

        public SessionController() { }

        [HttpPost]
        public ActionResult<Models.User> Start(Models.User user)
        {
            Models.User userGetter = userRepo.GetByName(user.Name);
            if (userGetter == null) return NotFound();
            if (userGetter.Password != user.Password) return Forbid();
            Models.Session activeSession = sessionRepo.GetByUserId(userGetter.Id.ToString());
            if (activeSession == null) activeSession = sessionRepo.Add(new Models.Session { UserId = userGetter.Id });
            userGetter.SessionId = activeSession.Id;
            userGetter.Password = "";
            return userGetter;
        }
    }
}
