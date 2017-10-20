using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Review2C.Models;

namespace Review2C.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
    }
}
