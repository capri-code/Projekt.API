using Projekt.API.Data.Base;

namespace Projekt.API.Data.Models
{
    public class University:BaseClass
    {
        public string UniversityName { get; set; }
        public string Code { get; set; }
        public DateTime UniversityDateCreated { get; set; }

        //Add a reference to Subject table
        public int FacultyId { get; set; }
    }
}
