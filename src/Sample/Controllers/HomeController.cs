using DataAccessLayer;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    public class HomeController: Controller
    {
        public ActionResult Index() {
            var flightManager = new FlugManager();
            var flights = flightManager.FindAll();
            return View(flights);
        }
    }
}
