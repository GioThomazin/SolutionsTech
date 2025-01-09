using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class UserType
	{
		[Key]
		public long IdUserType { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; } = true;
	}
}
