namespace Projekt.API.Data.DTOs.University
{
    public class PutUniversityDTO
    {
        public string UniversityName { get; set; }
        public string Code { get; set; }
        public DateTime UniversityDateCreated { get; set; }
        public string Rector { get ; set; }

        //Add a reference to Faculty table
        public int FacultyId { get; set; }
    }
}
