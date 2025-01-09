using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Models
{
    public class TypeProcedure
    {
        [Key]
        public long IdTypeProcedure { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
