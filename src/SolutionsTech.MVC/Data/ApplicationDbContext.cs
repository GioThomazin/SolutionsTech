﻿using Microsoft.EntityFrameworkCore;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.Data.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SolutionsTech10;Trusted_Connection=True;TrustServerCertificate=True");
		}

		public DbSet<Brand> Brand { get; set; }
		public DbSet<FormPayment> FormPayment { get; set; }
		public DbSet<Product> Product { get; set; }
		public DbSet<Scheduling> Scheduling { get; set; }
		public DbSet<SchedulingProcedure> SchedulingProcedure { get; set; }
		public DbSet<SchedulingProduct> SchedulingProduct { get; set; }
		public DbSet<TypeProcedure> TypeProcedure { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserType> UserType { get; set; }
	}
}
