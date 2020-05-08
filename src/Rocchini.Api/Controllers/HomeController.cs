using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rocchini.Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Get() => Content("Hello from Rocchini Api");
    }
}