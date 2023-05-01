using Microsoft.AspNetCore.Mvc;
using Projekt.API.Data;
using Projekt.API.Data.DTOs.University;
using Projekt.API.Data.Models;

namespace Projekt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public UniversitiesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        //Krijo nje API endpoint per te marre te dhenat nga DB
        [HttpGet("GetAllUniversitites")]
        public IActionResult GetAllUniversities()
        {
            var allUniversities = _appDbContext.Universities.ToList();
            return Ok(allUniversities);
        }

        //Krijo nje API endpoint per te marre te dhenat nga DB
        [HttpGet("GetUniversityById/{id}")]
        public IActionResult GetUniversityById(int id)
        {
            var University = _appDbContext.Universities.FirstOrDefault(x => x.Id == id);
            return Ok($"Universiteti me id = {id} u kthye me sukses!");
        }

        [HttpPost("AddUniversity")]
        public IActionResult AddUniversity([FromBody] PostUniversityDTO payload)
        {
            //1. Krijo nje objekt Student me te dhenat e marra nga payload
            University newUniversity = new University()
            {
                UniversityName = payload.UniversityName,
                Code = payload.Code,
                UniversityDateCreated = payload.UniversityDateCreated,
                DateCreated = DateTime.UtcNow,

                FacultyId = payload.FacultyId
            };

            _appDbContext.Universities.Add(newUniversity);
            _appDbContext.SaveChanges();

            return Ok("Universiteti u krijua me sukses!");
        }

        [HttpPut("UpdateUniversity")]
        public IActionResult UpdateUniversity([FromBody] PutUniversityDTO payload, int id)
        {
            //1. Duke perdour ID marrim te dhenat nga databaza
            var university = _appDbContext.Universities.FirstOrDefault(x => x.Id == id);
            if (university == null)
                return NotFound();

            //2. Perditesojme Studentin e DB me te dhenat e payload-it
            university.UniversityName = payload.UniversityName;
            university.Code = payload.Code;
            university.UniversityDateCreated = payload.UniversityDateCreated;

            //Add Refrence to Subject Id
            university.FacultyId = payload.FacultyId;

            //3. Ruhen te dhenat ne database
            _appDbContext.Universities.Update(university);
            _appDbContext.SaveChanges();

            return Ok("Universiteti u modifikua me sukses!");
        }

        [HttpDelete("DeleteUniversity/{id}")]
        public IActionResult DeleteUniversity(int id)
        {
            //1. Duke perdour ID marrim te dhenat nga databaza
            var university = _appDbContext.Universities.FirstOrDefault(x => x.Id == id);
            if (university == null)
                return NotFound();

            //2. Fshijme universityin nga DB
            _appDbContext.Universities.Remove(university);
            _appDbContext.SaveChanges();

            return Ok($"Universiteti me id = {id} u fshi me sukses!");
        }
    }
}
