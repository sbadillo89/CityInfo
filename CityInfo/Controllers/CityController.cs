using AutoMapper;
using CityInfo.Models;
using CityInfo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace CityInfo.Controllers
{
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly IOptions<ExternalApiSettings> _settings;
        private readonly INewsService _newsService;
        private readonly IWeatherService _weatherService;
        private readonly ICountryService _countryService;
        private readonly IHistoryService _historyService;
        private readonly IMapper _mapper;

        CountryInformation _countryInformation;
        List<Countries> _validCountriesNews;

        public CityController(IOptions<ExternalApiSettings> settings,
                                INewsService serviceNews,
                                IWeatherService weatherService,
                                ICountryService countryService,
                                IHistoryService historyService,
                                IMapper mapper)
        {
            _settings = settings;
            _newsService = serviceNews;
            _weatherService = weatherService;
            _countryService = countryService;
            _historyService = historyService;
            _mapper = mapper;

            InitializeController();
        }

        private void InitializeController()
        {
            _validCountriesNews = Enum.GetValues(typeof(Countries)).Cast<Countries>().ToList();
            _countryInformation = _countryService.GetAllCountries().Result;
        }

        [HttpGet("{countryCode}")]
        public async Task<ActionResult<CityInformation>> GetByCountry(string countryCode)
        {
            try
            {
                CityInformation cityInformation = new CityInformation();

                if (!ValidCountry(countryCode))
                    return BadRequest(new ErrorMessage { Message = $"'{countryCode.ToUpper()}' no es un código de país válido." });

                var country = _validCountriesNews.FirstOrDefault(c => c.ToString() == countryCode.ToUpper());
                var countryInfo = _countryInformation.Data.FirstOrDefault(x => x.Iso2.ToUpper() == countryCode.ToUpper());

                var newsApiKey = _settings.Value.NewsApi.ApiKey;
                var weatherApiKey = _settings.Value.OpenWeather.ApiKey;

                cityInformation.Name = countryInfo.Name;
                cityInformation.News = await _newsService.GetByCountry(country, newsApiKey);

                cityInformation.CurrentWeather = await _weatherService.GetByCountry(countryInfo.Name, weatherApiKey);

                var newHistory = new History { Country = countryInfo.Name, Info = "Info" };
                await _historyService.AddHistory(newHistory);

                return Ok(cityInformation);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorMessage { Message = ex.Message });
            }
        }

        private bool ValidCountry(string countryCode)
        {
            if (!_validCountriesNews.Exists(c => c.ToString() == countryCode.ToUpper()))
                return false;

            if (!_countryInformation.Data.Exists(x => x.Iso2.ToUpper() == countryCode.ToUpper()))
                return false;

            return true;
        }


    }
}