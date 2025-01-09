using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class TypeProcedure
	{
		[Key]
		public long IdTypeProcedure { get; set; }
		public string Name { get; set; }
		public decimal Value { get; set; }
	}
}
