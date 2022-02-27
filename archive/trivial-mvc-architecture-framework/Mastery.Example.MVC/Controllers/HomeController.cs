using System.Web.Mvc;

namespace Mastery.Example.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() 
            => View();
    }
}