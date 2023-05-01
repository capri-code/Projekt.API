namespace Projekt.API.Data.DTOs.University
{
    public class PostUniversityDTO
    {
        public string UniversityName { get; set; }
        public string Code { get; set; }
        public DateTime UniversityDateCreated { get; set; }

        //Add a reference to Faculty table
        public int FacultyId { get; set; }
    }
}