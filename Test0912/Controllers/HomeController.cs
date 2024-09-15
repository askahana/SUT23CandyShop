using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test0912.Models;
using Test0912.Services.IService;
using Test0912.ViewModels;

namespace Test0912.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICandyRepository _candyRepository;
        public HomeController(ILogger<HomeController> logger, ICandyRepository candyRepo)
        {
            _logger = logger;
            _candyRepository = candyRepo;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                CandyOnSale = _candyRepository.GetCandyOnSale
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
