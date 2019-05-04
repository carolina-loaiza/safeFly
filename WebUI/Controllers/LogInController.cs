using System.Web.Mvc;
using WebUI.Security;

namespace WebUI.Controllers
{
    [SecurityFilter]
    public class LogInController : Controller
    {

        public ActionResult user()
        {
            return View();
        }
    }
}