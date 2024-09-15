using Test0912.Models;

namespace Test0912.ViewModels
{
    // You use ViewModel when you do not need to access all properties
    // or when you would like to combine several properties
    public class CandyListViewModel
    {
        public IEnumerable<Candy> Candies { get; set; }
        public string CurrentCategory { get; set; }

    }
}
