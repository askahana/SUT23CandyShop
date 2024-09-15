using Microsoft.AspNetCore.Mvc;
using Test0912.Models;
using Test0912.Services.IService;
using Test0912.ViewModels;

namespace Test0912.Controllers
{
    public class CandyController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CandyController(ICandyRepository canRepo, ICategoryRepository cateRepo)
        {
            _candyRepository = canRepo;
            _categoryRepository = cateRepo;
        }

        public IActionResult List(string category)
        {
            var candyListViewModel = new CandyListViewModel();
            candyListViewModel.Candies = _candyRepository.GetAllCandy;
            candyListViewModel.CurrentCategory = "Message from controller/ See list";
            return View(candyListViewModel);

            //IEnumerable<Candy> candies;
            //string currentCategory;
            //// You use ViewBag to send data from controller to view.
            //// There is ViewData also.

            ////ViewBag.CurrentCategory = "Bestsellers";
            //if (string.IsNullOrEmpty(category))
            //{
            //    candies = _candyRepository.GetAllCandy.OrderBy(x => x.CandyId);
            //    currentCategory = "All Candy";
            //}
            //else
            //{
            //    candies = _candyRepository.GetAllCandy
            //        .Where(c => c.Category.CategoryName == category);

            //    currentCategory = _categoryRepository.GetCategories
            //        .FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            //    // FirstOrDefault returns null if the item is not found.
            //    // ?.CategoryName means, when it is not null it returns CategoryName
            //    // if it is null, it returns null.
            //    // This is to avoid exception
            
            //}
            //return View(candies);
        }

      
        public IActionResult Detail(int id) 
        {
            var candy = _candyRepository.GetCandyById(id);
            if(candy == null)
            {
                return NotFound();
            }
            return View(candy);
        }
    }
}
