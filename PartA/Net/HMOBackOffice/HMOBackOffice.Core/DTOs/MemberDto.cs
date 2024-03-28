namespace HMOBackOffice.Core.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Identity { get; set; }
        public int CityId { get; set; }
        public CityDto? City { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? CellPhone { get; set; }
        public DateTime? DateOfIllness { get; set; }
        public DateTime? DateOfRecovery { get; set; }
        public string? ProfileImage { get; set; }
    }
}
