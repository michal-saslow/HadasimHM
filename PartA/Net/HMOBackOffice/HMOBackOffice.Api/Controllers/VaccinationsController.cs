using AutoMapper;
using HMOBackOffice.Core.DTOs;
using HMOBackOffice.Core.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMOBackOffice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationsController : ControllerBase
    {
        private readonly IVaccinationService _vaccinationService;
        private readonly IMapper _mapper;
        public VaccinationsController(IVaccinationService vaccinationService, IMapper mapper)
        {
            _vaccinationService = vaccinationService;
            _mapper = mapper;
        }
        // GET: api/<VaccinationsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var vaccinations = await _vaccinationService.GetAsync();
            var vaccinationsDto = _mapper.Map<IEnumerable<VaccinationDto>>(vaccinations);
            return Ok(vaccinationsDto);
        }

    }
}
