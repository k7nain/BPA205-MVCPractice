using Bilet_Practice_.Models.Base;

namespace Bilet_Practice_.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Game> Game { get; set; }


    }
}
