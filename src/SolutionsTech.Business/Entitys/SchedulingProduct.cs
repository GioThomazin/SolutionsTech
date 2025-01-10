using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.Business.Entity
{
    public class SchedulingProduct
    {
        [Key]
        public long IdSchedulingProduct { get; set; }
        public Scheduling Scheduling { get; set; }
        public Product Product { get; set; }
    }
}
