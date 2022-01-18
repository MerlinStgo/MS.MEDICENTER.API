using Microsoft.AspNetCore.Mvc;

namespace MS.MediCenter.Web.Controllers
{
    public class FarmaciaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Productos()
        {
            return View();
        }
    }
}
