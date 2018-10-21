/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** ServiceController
*/

using System.Collections.Generic;
using System.Linq;
using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private static Models.ServiceRepository services = new Models.ServiceRepository("");

        public ServiceController() { }

        [HttpGet]
        public ActionResult<List<Models.Service>> GetAll() { return services.GetAll().ToList(); }

        [HttpGet("{id}", Name = "GetService")]
        public ActionResult<Models.Service> GetById(string id)
        {
            Service item = services.Get(id);
            if (item == null) return NotFound();
            return item;
        }

    }
}
