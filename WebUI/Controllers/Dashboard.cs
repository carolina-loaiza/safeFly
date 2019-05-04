using System.Web.Mvc;
using WebUI.Security;

namespace WebUI.Controllers
{
    [SecurityFilter]
    public class DashboardController : Controller
    {

        public ActionResult user()
        {
            return View();
        }

        public ActionResult listAirline()
        {
            return View();
        }

        public ActionResult createAirline()
        {
            return View();
        }

        public ActionResult listSchedule()
        {
            return View();
        }

        public ActionResult createSchedule()
        {
            return View();
        }

        public ActionResult modifyAirline()
        {
            return View();
        }

        public ActionResult listAirport()
        {
            return View();
        }

        public ActionResult createAirport()
        {
            return View();
        }

        public ActionResult listFlight()
        {
            return View();
        }

        public ActionResult createFlight()
        {
            return View();
        }

        public ActionResult listSeat()
        {
            return View();
        }

        public ActionResult createSeat()
        {
            return View();
        }

        public ActionResult listBusinessPremises()
        {
            return View();
        }

        public ActionResult createBusinessPremises()
        {
            return View();
        }

        public ActionResult createCoin()
        {
            return View();
        }

        public ActionResult listCoin()
        {
            return View();
        }

        public ActionResult approveAirline()
        {
            return View();
        }
        public ActionResult VPermiseC()
        {
            return View();
        }
        public ActionResult VPermiseU()
        {
            return View();
        }
        public ActionResult VPermiseL()
        {
            return View();
        }
        public ActionResult VViewC()
        {
            return View();
        }
        public ActionResult VViewU()
        {
            return View();
        }
        public ActionResult VViewL()
        {
            return View();
        }
        public ActionResult VTaxC()
        {
            return View();
        }
        public ActionResult VTaxU()
        {
            return View();
        }
        public ActionResult VTaxL()
        {
            return View();
        }

        public ActionResult modUser()
        {
            return View();
        }

        public ActionResult modSettingUser()
        {
            return View();
        }


        public ActionResult contactUs()
        {
            return View();
        }

        public ActionResult dashboardGenAdmin()
        {
            return View();
        }

    }
}