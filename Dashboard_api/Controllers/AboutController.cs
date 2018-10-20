/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** AboutController
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("about.json")]
    [ApiController]
    public class GetAboutController : ControllerBase
    {
        private static Models.ServiceRepository serviceRepo = new Models.ServiceRepository("");

        public GetAboutController() { }

        [HttpGet]
        public ActionResult<Models.About> Get()
        {
            var context = Request.HttpContext;
            var ip = context.Connection.RemoteIpAddress;

            Console.WriteLine(ip);

            var about = new Models.About();

            about.Client.Host = ip.ToString();

            about.Server.current_time = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            about.Server.Services = serviceRepo.GetAll();

            return about;
        }
    }
}
