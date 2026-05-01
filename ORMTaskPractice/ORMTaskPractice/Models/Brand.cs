using ORMTaskPractice.Models.Base;

namespace ORMTaskPractice.Models
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
