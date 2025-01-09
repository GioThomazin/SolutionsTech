using SolutionsTech.MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class SchedulingProcedure
	{
		[Key]
		public long IdSchedulingProcedure { get; set; }
		public Scheduling Scheduling { get; set; }
		public TypeProcedure TypeProcedure { get; set; }
	}
}
