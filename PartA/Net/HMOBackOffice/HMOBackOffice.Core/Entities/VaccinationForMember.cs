namespace HMOBackOffice.Core.Entities
{
    public class VaccinationForMember
    {
        public int Id { get; set; }
        public int VaccinationId { get; set; }
        public Vaccination? Vaccination { get; set; }
        public int? MemberId { get; set; }
        public Member? Member { get; set; }
        public DateTime? Date { get; set; }
    }
}
