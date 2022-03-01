using ShopBridge.DTOs;

namespace ShopBridge.Interfaces
{
    public interface ICountryGwpRepository
    {
        CountryGwpToReturnDto FetchGwpDetails(CountryGwpDto countryGwpDto);
    }
}
