using System.ComponentModel.DataAnnotations.Schema;
using Bilet_1_Practice_.Models.Base;

namespace Bilet_1_Practice_.Models
{
    public class Member : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
