using System.Web.Mvc;

namespace Architecture.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("List", "Employees");
        }
    }
}