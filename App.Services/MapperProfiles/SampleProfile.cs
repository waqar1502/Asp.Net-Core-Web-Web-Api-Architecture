using App.DataAccess.DbModels;
using App.Models.CommonModels;
using App.Models.ViewModels;
using AutoMapper;

namespace App.Services.MapperProfiles
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            CreateMap<TestTable, SampleViewModel>().ReverseMap();

            CreateMap<AspNetUsers, RegisterUserBindingModel>().ReverseMap();
        }
    }
}
