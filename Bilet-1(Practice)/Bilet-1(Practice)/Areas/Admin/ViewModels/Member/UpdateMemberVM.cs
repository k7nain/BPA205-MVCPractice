using System.ComponentModel.DataAnnotations;

namespace Bilet_1_Practice_.Areas.Admin.ViewModels.Member
{
    public class UpdateMemberVM
    {
        public int Id { get; set; }

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
    }
}
