using Asp.Versioning;
using AutoMapper;
using CoffeeMachine.Application.DTOs;
using CoffeeMachine.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachineApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BeveragesController : ControllerBase
    {
        private readonly ILogger<BeveragesController> _logger;
        private readonly IBeverageRepository _beverageService;
        private readonly IMapper _mapper;

        public BeveragesController(ILogger<BeveragesController> logger, IBeverageRepository beverageService, IMapper mapper)
        {
            _logger = logger;
            _beverageService = beverageService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BeverageDto>> Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<BeverageDto>>(_beverageService.GetBeverages()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving beverages.");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<BeverageResponse> GetBeverage(int id)
        {
            try
            {
                var beverage = _beverageService.GetBeverage(id);

                if (beverage is null)
                {
                    _logger.LogWarning($"Beverage not found with the Id : {id}.");
                    return NotFound();
                }

                return Ok(beverage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving beverage with Id : {id}.");
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}