using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityInfo.Dtos;
using CityInfo.Models;
using CityInfo.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityInfo.Controllers
{
    [Route("api/[controller]")]
    public class HistoryController : Controller
    {

        private readonly IHistoryService _historyService;
        private readonly IMapper _mapper;

        public HistoryController(IHistoryService historyService, IMapper mapper)
        {
            _historyService = historyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryDTO>>> Get()
        {
            try
            {
                var historical = await _historyService.GetHistoryConsultation();

                return Ok(_mapper.Map<IEnumerable<HistoryDTO>>(historical));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorMessage { Message = ex.Message });
            }

        }
    }
}

