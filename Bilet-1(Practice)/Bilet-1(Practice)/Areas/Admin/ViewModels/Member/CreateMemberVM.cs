using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bilet_1_Practice_.Areas.Admin.ViewModels.Member
{
    public class CreateMemberVM
    {
        [Required(ErrorMessage = "Name is required")]
        [
            StringLength(30, ErrorMessage = "Name must be max 30 ch"),
            MinLength(2, ErrorMessage = "Name must be min 30 ch")
        ]
        public string Name { get; set; }


        [Required(ErrorMessage = "Surname is required")]
        [
            StringLength(30, ErrorMessage = "Surname must be max 30 ch"),
            MinLength(2, ErrorMessage = "Surname must be min 30 ch")
        ]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [
            StringLength(30, ErrorMessage = "Position must be max 30 ch"),
            MinLength(2, ErrorMessage = "Position must be min 30 ch")
        ]
        public string Position { get; set; }


        [Required(ErrorMessage = "ImageFile is required")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
