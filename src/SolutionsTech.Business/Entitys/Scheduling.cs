using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.Business.Entity
{
    public class Scheduling
    {
        [Key]
        public long IdScheduling { get; set; }
        public string Name { get; set; }
        public DateTime DtCreate { get; set; } = DateTime.Now;
        public decimal TotalValue { get; set; }
        public string Observation { get; set; }


        [ForeignKey(name: "IdUser")]
        public long IdUser { get; set; }

        [ForeignKey(name: "IdUser")]
        public virtual User User { get; set; }

        [ForeignKey(name: "IdFormPayment")]
        public long IdFormPayment { get; set; }

        [ForeignKey(name: "IdFormPayment")]
        public virtual FormPayment FormPayment { get; set; }
    }
}
