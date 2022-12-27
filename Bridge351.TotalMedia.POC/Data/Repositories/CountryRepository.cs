using Bridge351.TotalMedia.POC.Data.Interface;
using Bridge351.TotalMedia.POC.Models;

namespace Bridge351.TotalMedia.POC.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public readonly Bridge351POCContext context;

        public CountryRepository(Bridge351POCContext context)
        {
            this.context = context;
        }

        public List<Country> GetCountries()
        {
            var countryList = new List<Country>();

            countryList.AddRange(context.Countries.ToList());

            return countryList;
        }
    }
}
