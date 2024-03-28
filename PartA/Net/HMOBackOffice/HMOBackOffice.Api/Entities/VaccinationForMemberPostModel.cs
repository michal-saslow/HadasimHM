namespace HMOBackOffice.Api.Entities
{
    public class VaccinationForMemberPostModel
    {
        public int VaccinationId { get; set; }
        public int? MemberId { get; set; }
        public DateTime Date { get; set; }
    }
}
