using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Models
{
    public class Product
    {
        [Key]
        public long IdProduct { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public DateTime DtCreate { get; set; }
        public bool Active { get; set; }
        public Brand Brand { get; set; }
    }
}
