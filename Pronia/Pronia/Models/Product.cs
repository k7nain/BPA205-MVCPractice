using Pronia.Models.Base;

namespace Pronia.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }

        public List<Review> Reviews { get; set; }
        public string SKU { get; set; }
        public List<Tag> Tags { get; set; }
        public int Price { get; set; }
        public List<Image> Images { get; set; }
    }
}
