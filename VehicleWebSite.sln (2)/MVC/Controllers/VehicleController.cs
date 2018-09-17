using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using MVC.Models;

namespace MVC.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            IEnumerable<Models.mvcVehicleModel> vehList;
            HttpResponseMessage response = Mvc.GlobalVariables.VehiclesApiClient.GetAsync("Vehicle").Result;
            vehList = response.Content.ReadAsAsync<IEnumerable<Models.mvcVehicleModel>>().Result;
            return View(vehList);
        }
    }

    public ActionResult AddorEdit(int id = 0)
    {
        return View(new mvcVehicleModel());
    }
    [HttpPost]
    public ActionResult AddorEdit()
    {
        return View();
    }
}