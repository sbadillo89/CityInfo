using AutoMapper;
using CityInfo.Dtos;
using CityInfo.Services;
using NewsAPI.Constants;
using Microsoft.AspNetCore.Mvc;
using CityInfo.Models;

namespace CityInfo.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> Get()
        {
            try
            {
                var countries = await _countryService.GetAllCountries();
                var countriesNews = Enum.GetValues(typeof(Countries)).Cast<Countries>().ToList();

                var validCountries = (from c in countries.Data
                                      join code in countriesNews
                                         on c.Iso2 equals code.ToString()
                                      select c).ToList();


                return Ok(_mapper.Map<IEnumerable<CountryDTO>>(validCountries));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorMessage { Message = ex.Message });
            }
        }
    }
}

