using Bilet_Practice_.Models;
using System.ComponentModel.DataAnnotations;

namespace Bilet_Practice_.Areas.Admin.ViewModels.Game
{
    public class CreateGameVM
    {
        [Required(ErrorMessage = "Name is required")]
        [
            StringLength(30, ErrorMessage = "Name must be max 30 ch"),
            MinLength(2, ErrorMessage = "Name must be min 3 ch")
        ]
        public string Name { get; set; }

        [Required(ErrorMessage = "Discount is required")]
        public int Discount { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [
            StringLength(30, ErrorMessage = "Description must be max 30 ch"),
            MinLength(2, ErrorMessage = "Description must be min 3 ch")
        ]
        public string Description { get; set; }

        [Required(ErrorMessage = "ImageFile is required")]
        public IFormFile ImageFile { get; set; }

        public int CategoryId { get; set; }
    }
}
