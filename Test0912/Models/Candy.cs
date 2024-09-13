using System.ComponentModel.DataAnnotations;

namespace Test0912.Models
{
    public class Candy
    {
        [Key]
        public int CandyId { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumpnailUrl { get; set; }
        public bool IsOnSale { get; set; }
        public bool IsInStock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
