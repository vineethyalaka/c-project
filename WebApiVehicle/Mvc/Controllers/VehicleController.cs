using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            IEnumerable<MvcVehicleModel> vehlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Vehicle").Result;
            vehlist = response.Content.ReadAsAsync<IEnumerable<MvcVehicleModel>>().Result;
            return View(vehlist);
        }

        public ActionResult AddOrEdit(int Id = 0)
        {
            if(Id == 0)
                return View(new MvcVehicleModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Vehicle/" + Id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MvcVehicleModel>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcVehicleModel veh)
        {
            if (veh.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Vehicle", veh).Result;
                TempData["Success"] = "Data has been inserted";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Vehicle/" + veh.Id, veh).Result;
                TempData["Success"] = "Data has been updated";

            }
            return RedirectToAction("Index");
        }

        public ActionResult delete(int id = 0)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Vehicle/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}