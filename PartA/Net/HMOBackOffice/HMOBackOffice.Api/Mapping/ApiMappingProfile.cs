using AutoMapper;
using HMOBackOffice.Api.Entities;
using HMOBackOffice.Core.Entities;

namespace HMOBackOffice.Api.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<MemberPostModel, Member>();
            CreateMap<VaccinationForMemberPostModel, VaccinationForMember>();
            CreateMap<VaccinationPostModel, Vaccination>();
            CreateMap<CityPostModel, City>();
        }
    }
}
