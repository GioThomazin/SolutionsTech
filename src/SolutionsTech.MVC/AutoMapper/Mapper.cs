using AutoMapper;
using SolutionsTech.Business.Entity;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.AutoMapper
{
	public class Mapper : Profile
	{
		public Mapper()
		{
			CreateMap<Brand, BrandDto>();
			CreateMap<BrandDto, Brand>();
		}
	}
}
