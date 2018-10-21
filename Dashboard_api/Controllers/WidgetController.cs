/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** WidgetController
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        private static Models.WidgetRepository widgets = new Models.WidgetRepository("");

        public WidgetController() { }

        [HttpGet]
        public ActionResult<List<Models.Widgets.IWidget>> GetAll()
        {
            Microsoft.AspNetCore.Http.HttpRequest request = Request;
            Microsoft.AspNetCore.Http.IHeaderDictionary header = request.Headers;
            return widgets.GetAll().ToList();
        }

        [HttpGet("{id}", Name = "GetWidget")]
        public ActionResult<Models.Widgets.IWidget> GetById(string id)
        {
            Models.Widgets.IWidget item = widgets.Get(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public IActionResult Create(Models.Widgets.IWidget item)
        {
            widgets.Add(item);
            return CreatedAtRoute("GetWidget", new { id = item.Id }, item);
        }

        [HttpGet("{id}/invoke", Name = "InvokeWidget0")]
        public ActionResult<string> InvokeById(string id)
        {
            Models.Widgets.IWidget item = widgets.Get(id);
            if (item == null) return NotFound();
            Models.Widgets.IWidgetResult result = item.Invoke(new Models.User());
            return this.Content(result.DataPackage(), "application/json");
        }

        [HttpGet("{id}/invoke/{param1}", Name = "InvokeWidget1")]
        public ActionResult<string> InvokeById(string id, string param1)
        {
            Console.WriteLine("PARAM = " + param1);
            Models.Widgets.IWidget item = widgets.Get(id);
            item.Intake(param1);
            if (item == null) return NotFound();
            Models.Widgets.IWidgetResult result = item.Invoke(new Models.User());
            return this.Content(result.DataPackage(), "application/json");
        }

        [HttpGet("{id}/invoke/{param1}/{param2}", Name = "InvokeWidget")]
        public ActionResult<string> InvokeById(string id, string param1, string param2)
        {
            Models.Widgets.IWidget item = widgets.Get(id);
            item.Intake(param1);
            item.Intake(param2);
            if (item == null) return NotFound();
            Models.Widgets.IWidgetResult result = item.Invoke(new Models.User());
            return this.Content(result.DataPackage(), "application/json");
        }
    }
}
