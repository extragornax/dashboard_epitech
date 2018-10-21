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
        private static Models.IUserRepository users = new Models.UserRepository("");

        public UserController()
        {
            if (users.CountAll() == 0) users.Add(new Models.User { Name = "Extra", Password = "Cheap" });
        }

        [HttpGet]
        public ActionResult<List<Models.User>> GetAll()
        {
            Microsoft.AspNetCore.Http.HttpRequest request = Request;
            Microsoft.AspNetCore.Http.IHeaderDictionary header = request.Headers;
            return users.GetAll().ToList();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<Models.User> GetById(string id)
        {
            Models.User item = users.Get(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public IActionResult Create(Models.User item)
        {
            if (users.GetByName(item.Name) != null) Forbid();
            else users.Add(item);
            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
        }
    }
}
