using MiniStore.Models.Base;

namespace MiniStore.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public Image ImageUrl { get; set; }
        public int Price { get; set; }
    }
}
