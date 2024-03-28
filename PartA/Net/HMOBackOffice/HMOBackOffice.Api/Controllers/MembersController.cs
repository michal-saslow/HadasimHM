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
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;
        public MembersController(IMemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var members = await _memberService.GetAsync();
            var membersDto = _mapper.Map<IEnumerable<MemberDto>>(members);
            return Ok(membersDto);
        }
        [HttpGet("NotVaccinated")]
        public async Task<int> GetNotVaccinated()
        {
            return await _memberService.GetNotVaccinatedAsync();
        }

        [HttpGet("PatientsPerDay")]
        public async Task<IEnumerable<int>> GetPatientsPerDayAsync()
        {
            return await _memberService.GetPatientsPerDayAsync();
        }


        // POST api/<MembersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MemberPostModel member)
        {
            var memberToAdd = _mapper.Map<Member>(member);
            var vacsToAdd = _mapper.Map<IEnumerable<VaccinationForMember>>(member.Vfms);
            var newMember = await _memberService.AddAsync(memberToAdd, vacsToAdd.ToArray());
            if (newMember is not null)
            {
                return Ok(_mapper.Map<MemberDto>(newMember));
            }
            return BadRequest();
        }

        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] MemberPostModel member)
        {
            var memberToUpdate = _mapper.Map<Member>(member);
            var vacsToUpdate = _mapper.Map<IEnumerable<VaccinationForMember>>(member.Vfms);
            var updateMember = await _memberService.UpdateAsync(id, memberToUpdate, vacsToUpdate.ToArray());
            if (updateMember is not null)
            {
                return Ok(_mapper.Map<MemberDto>(updateMember));
            }
            return BadRequest();
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _memberService.DeleteAsync(id);
            return Ok();
        }
    }
}
