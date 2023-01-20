using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.Models;
using CityInfo.Services.NewsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CityInfo.Controllers
{
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly IOptions<ExternalApiSettings> _settings;
        private readonly INewsService _newsService;

        public CityController(IOptions<ExternalApiSettings> settings, INewsService serviceNews)
        {
            _settings = settings;
            _newsService = serviceNews;
        }

        [HttpGet]
        public ActionResult<IEnumerable<News>> GetByCountry()
        {
            var apiKey = _settings.Value.NewsApi.ApiKey;
            var response = _newsService.GetByCountry("co", apiKey);
            return Ok(response);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

