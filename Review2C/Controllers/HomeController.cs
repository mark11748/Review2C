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

      [HttpPost("/Result")]
      public ActionResult Result()
      {
        RepeatCounter myCounter = new RepeatCounter(Request.Form["main-str"],Request.Form["search-str"]);
        myCounter.CountRepeats();
        return View(myCounter);
      }
    }
}
