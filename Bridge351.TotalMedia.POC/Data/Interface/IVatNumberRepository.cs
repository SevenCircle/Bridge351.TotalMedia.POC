using Bridge351.TotalMedia.POC.Models;

namespace Bridge351.TotalMedia.POC.Data.Interface
{
    public interface IVatRateRepository
    {
        List<VatRate> GetAllVatRates();
        List<VatRate> GetAllVatRatesByCountry(Country country);
        List<VatRate> GetVatRatesByCountryName(string countryName);

    }
}
