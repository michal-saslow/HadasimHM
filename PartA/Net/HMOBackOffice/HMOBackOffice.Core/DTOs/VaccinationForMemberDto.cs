namespace HMOBackOffice.Core.DTOs
{
    public class VaccinationForMemberDto
    {
        public int Id { get; set; }
        public int VaccinationId { get; set; }
        public VaccinationDto? Vaccination { get; set; }
        public int? MemberId { get; set; }
        public MemberDto? Member { get; set; }
        public DateTime Date { get; set; }
    }
}
