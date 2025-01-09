using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class Brand
	{
		[Key]
		public long IdBrand { get; set; }
		public string Name { get; set; }
		public DateTime DtCreate { get; set; }
		public bool Active { get; set; }
	}
}
