using Pronia.Models.Base;

namespace Pronia.Models
{
    public class Review  : BaseEntity
    {
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public Product Product { get; set; }
    }
}
