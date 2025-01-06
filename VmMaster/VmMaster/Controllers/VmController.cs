using Microsoft.AspNetCore.Mvc;

namespace VmMaster.Controllers
{
    public class VmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
