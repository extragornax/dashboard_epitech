/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** UserController
*/

using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static Models.IUserRepository userRepo = new Models.UserRepository("");

        public UserController()
        {
            if (userRepo.CountAll() == 0)
                userRepo.Add(new Models.User { Name = "Extra", Password = "Cheap" });
        }

        [HttpGet]
        public ActionResult<List<Models.User>> GetAll()
        {
            var request = Request;
            var header = request.Headers;
            return userRepo.GetAll().ToList();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<Models.User> GetById(string id)
        {
            var item = userRepo.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Models.User item)
        {
            if (userRepo.GetByName(item.Name) != null)
            {
                Forbid();
            }
            else
            {
                userRepo.Add(item);
            }
            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
        }
    }
}
