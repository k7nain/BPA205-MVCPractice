using ORMTaskPractice.Models.Base;

namespace ORMTaskPractice.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }

    }
}
