﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class SchedulingDto
	{
		public long IdScheduling { get; set; }
		public string Name { get; set; }
		public DateTime DtCreate { get; set; } = DateTime.Now;
		public decimal TotalValue { get; set; }
		public string Observation { get; set; }


		[ForeignKey(name: "IdUser")]
		public long IdUser { get; set; }

		[ForeignKey(name: "IdUser")]
		public virtual UserDto User { get; set; }

		[ForeignKey(name: "IdFormPayment")]
		public long IdFormPayment { get; set; }

		[ForeignKey(name: "IdFormPayment")]
		public virtual FormPaymentDto FormPayment { get; set; }
	}
}