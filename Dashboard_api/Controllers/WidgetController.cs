using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Mvc;

namespace dashboard_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        private static Models.WidgetRepository widgetRepo = new Models.WidgetRepository("");

        public WidgetController()
        {

            // var widgets

            if (widgetRepo.CountAll() == 0)
            {
                // widgetRepo.Add(new Models.Widget { Name = "toto", Password = "tata" });
            }
        }

        [HttpGet]
        public ActionResult<List<Models.Widgets.IWidget>> GetAll()
        {
            var request = Request;
            var header = request.Headers;
            return widgetRepo.GetAll().ToList();
        }

        [HttpGet("{id}", Name = "GetWidget")]
        public ActionResult<Models.Widgets.IWidget> GetById(string id)
        {
            var item = widgetRepo.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Models.Widgets.IWidget item)
        {
            widgetRepo.Add(item);
            return CreatedAtRoute("GetWidget", new { id = item.Id }, item);
        }

        // [HttpGet("{id}/invoke", Name = "InvokeWidget")]
        // public HttpResponseMessage InvokeById(string id) {
        //     var item = widgetRepo.Get(id);
        //     if (item == null) {
        //         var resp = new HttpResponseMessage() {
        //         StatusCode = System.Net.HttpStatusCode.NotFound
        //         };
        //         return resp;
        //     } else {
        //         var user = new Models.User();
        //         var toto = item.Invoke(user);
        //         var resp = new HttpResponseMessage() {
        //             Content = new StringContent(toto.Payload()),
        //             StatusCode = (toto.WidgetType() == Models.Widgets.EWidgetType.Error) ? System.Net.HttpStatusCode.InternalServerError : System.Net.HttpStatusCode.OK
        //             // Content = new StringContent("[{\"Name\":\"ABC\"},[{\"A\":\"1\"},{\"B\":\"2\"},{\"C\":\"3\"}]]")
        //         };
        //         resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //         return resp;
        //     }
        // }

        [HttpGet("{id}/invoke", Name = "InvokeWidget0")]
        public ActionResult<string> InvokeById(string id)
        {
            var item = widgetRepo.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            var result = item.Invoke(new Models.User());

            return this.Content(result.Payload(), "application/json");
        }

        [HttpGet("{id}/invoke/{param1}", Name = "InvokeWidget1")]
        public ActionResult<string> InvokeById(string id, string param1)
        {
            Console.WriteLine("PARAM = " + param1);
            var item = widgetRepo.Get(id);
            item.Intake(param1);
            if (item == null)
            {
                return NotFound();
            }
            var result = item.Invoke(new Models.User());

            return this.Content(result.Payload(), "application/json");
        }

        [HttpGet("{id}/invoke/{param1}/{param2}", Name = "InvokeWidget")]
        public ActionResult<string> InvokeById(string id, string param1, string param2)
        {
            var item = widgetRepo.Get(id);
            item.Intake(param1);
            item.Intake(param2);
            if (item == null)
            {
                return NotFound();
            }
            var result = item.Invoke(new Models.User());

            return this.Content(result.Payload(), "application/json");
        }
    }
}
