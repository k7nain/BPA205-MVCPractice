using Bilet_Practice_.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bilet_Practice_.Models
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }
        public int Discount { get; set; }
        public int Price { get; set; }
        public string Description{ get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string ImageUrl { get; set; }
    }
}
