using AutoMapper;
using HMOBackOffice.Core.DTOs;
using HMOBackOffice.Core.Entities;

namespace HMOBackOffice.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<VaccinationForMember, VaccinationForMemberDto>().ReverseMap();
            CreateMap<Vaccination, VaccinationDto>().ReverseMap();
        }
    }
}
