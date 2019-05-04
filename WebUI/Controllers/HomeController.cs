using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        [HttpPost]
        public ActionResult QR(string qrcode)

        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            return View();
        }
    }
}