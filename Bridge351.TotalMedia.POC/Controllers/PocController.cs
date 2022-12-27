using Bridge351.TotalMedia.POC.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bridge351.TotalMedia.POC.Controllers
{
    [Route("api/[controller]")]
    public class PocController : Controller
    {
        private readonly ICountryRepository countryRepository;
        private readonly IVatRateRepository vatNumbersRepository;

        public PocController(ICountryRepository countryRepository, IVatRateRepository vatNumbersRepository)
        {
            this.countryRepository = countryRepository;
            this.vatNumbersRepository = vatNumbersRepository;
        }



        // GET: PocController/Details/5
        [HttpGet("/GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = countryRepository.GetCountries();
            return Ok(countries);
        }

        // GET: PocController/Details/5
        [HttpGet("/GetVatRates/{countryName}")]
        public async Task<IActionResult> GetVatRates(string countryName)
        {
            var countries = vatNumbersRepository.GetVatRatesByCountryName(countryName);
            return Ok(countries);
        }
    }
}
