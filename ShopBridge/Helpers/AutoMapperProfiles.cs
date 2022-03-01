using AutoMapper;
using ShopBridge.DTOs;
using ShopBridge.Models;

namespace ShopBridge.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CountryGwpToReturnDto, CountryGwp>().ReverseMap();
        }
    }
}
