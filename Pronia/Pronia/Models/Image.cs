using Pronia.Models.Base;

namespace Pronia.Models
{
    public class Image : BaseEntity
    {
        public string ImageUrl { get; set; }
        public Product Product { get; set; }
        public bool IsPrimary { get; set; } = false;
    }
}
