using App.DataAccess.Models;
using App.Models.ViewModels;
using AutoMapper;

namespace App.Services.MapperProfiles
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            CreateMap<TestTable, SampleViewModel>().ReverseMap();
        }
    }
}
