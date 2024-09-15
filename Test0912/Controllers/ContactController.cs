using Microsoft.AspNetCore.Mvc;

namespace Test0912.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
