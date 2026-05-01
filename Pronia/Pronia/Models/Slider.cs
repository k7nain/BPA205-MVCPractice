using Pronia.Models.Base;

namespace Pronia.Models
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

    }
}
