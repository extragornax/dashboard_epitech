/*
** EPITECH PROJECT, 2018
** Dashboard_api
** File description:
** ServiceController
*/

using System.Collections.Generic;
using System.Linq;

using Dashboard.Models;

using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private static Models.ServiceRepository serviceRepo = new Models.ServiceRepository("");

        public ServiceController() { }

        [HttpGet]
        public ActionResult<List<Models.Service>> GetAll()
        {
            return serviceRepo.GetAll().ToList();
        }

        [HttpGet("{id}", Name = "GetService")]
        public ActionResult<Models.Service> GetById(string id)
        {
            var item = serviceRepo.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

    }
}
