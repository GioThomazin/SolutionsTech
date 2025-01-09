using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Models
{
    public class SchedulingProduct
    {
        [Key]
        public long IdSchedulingProduct { get; set; }
        public Scheduling Scheduling { get; set; }
        public Product Product { get; set; }
    }
}
