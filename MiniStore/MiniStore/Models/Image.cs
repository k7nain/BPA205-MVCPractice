using MiniStore.Models.Base;

namespace MiniStore.Models
{
    public class Image : BaseEntity
    {
        public string Url { get; set; }
        public Product Product { get; set; }
    }
}
