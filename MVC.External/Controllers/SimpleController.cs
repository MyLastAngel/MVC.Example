using Microsoft.AspNetCore.Mvc;
using System;

namespace MVC.External
{
    [Route("SimpleView")]
    public class SimpleController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
