using AutoMapper;
using HMOBackOffice.Api.Entities;
using HMOBackOffice.Core.DTOs;
using HMOBackOffice.Core.Entities;
using HMOBackOffice.Core.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMOBackOffice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationForMemberController : ControllerBase
    {
        private readonly IVaccinationForMemberService _vaccinationForMemberService;
        private readonly IMapper _mapper;

        public VaccinationForMemberController(IVaccinationForMemberService vaccinationForMemberService, IMapper mapper)
        {
            _vaccinationForMemberService = vaccinationForMemberService;
            _mapper = mapper;
        }
        // GET: api/<VaccinationForMemberController>
        [HttpGet("member/{memberId}")]
        public async Task<ActionResult> Get(int memberId)
        {
            var vfms = await _vaccinationForMemberService.GetAsync(memberId);
            var vfmsDto = _mapper.Map<IEnumerable<VaccinationForMemberDto>>(vfms);
            return Ok(vfmsDto);
        }


        [HttpDelete("member/{memberId}")]
        public async Task<ActionResult> DeleteByMemberId(int memberId)
        {
            await _vaccinationForMemberService.DeleteByMemberIdAsync(memberId);
            return Ok();
        }
    }
}
