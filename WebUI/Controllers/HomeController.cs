using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Security;

namespace WebUI.Controllers
{
    [SecurityFilter]
    public class HomeController : Controller
    {

        public ActionResult vLogIn()
        {
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult vUser()
        {

            return View();
        }

        public ActionResult eUser()
        {
            return View();
        }

        public ActionResult vAirport()
        {

            return View();
        }

        public ActionResult vBusinessPremises()
        {
            return View();
        }

        public ActionResult vCoin()
        {

            return View();
        }

        public ActionResult vCreateAdminAirport()
        {
            return View();
        }

        public ActionResult vCreateAirline()
        {
            return View();
        }

        public ActionResult vApproveAirline()
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
        public ActionResult vAirportAdminDashboard()
        {
            return View();
        }
        public ActionResult vAirlineList()
        {
            return View();
        }
    }
}