using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Test0912.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please enter your first Name")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your Last Name")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your Address")]
        [Display(Name = "Street Address")]
        [StringLength(100)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter your City")]
        [Display(Name = "City")]
        [StringLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your State")]
        [Display(Name = "State ")]
        [StringLength(100, MinimumLength = 2)]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter Zip Code")]
        [Display(Name = "Zip Code ")]
        [StringLength(5, MinimumLength = 5)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Please enter your Telefone Number")]
        [Display(Name = "Phone Number ")]
        [DataType(DataType.PhoneNumber)]
        public string PhonNumber { get; set; }

        [BindNever]
        public decimal OrderTotal { get; set; }
        [BindNever]
        public DateTime OrderPlaced { get; set; }
    }
}
