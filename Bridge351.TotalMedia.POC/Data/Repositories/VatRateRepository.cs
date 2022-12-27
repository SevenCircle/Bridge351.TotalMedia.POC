using Bridge351.TotalMedia.POC.Data.Interface;
using Bridge351.TotalMedia.POC.Models;
using System.Diagnostics.Metrics;

namespace Bridge351.TotalMedia.POC.Data.Repositories
{
    public class VatRateRepository : IVatRateRepository
    {
        public readonly Bridge351POCContext context;

        public VatRateRepository(Bridge351POCContext context)
        {
            this.context = context;
        }

        public List<VatRate> GetAllVatRates()
        {
            return context.VatRates.ToList();
        }

        public List<VatRate> GetAllVatRatesByCountry(Country country)
        {
            var vatRates = new List<VatRate>();
            vatRates = context.VatRates.Where(s => s.CountryId == country.CountryId).ToList();

            return vatRates;
        }

        public List<VatRate> GetVatRatesByCountryName(string countryName)
        {
            var vatRates = new List<VatRate>();
            vatRates = context.VatRates.Where(s => s.Country.CountryName == countryName).ToList();

            return vatRates;
        }
    }
}
