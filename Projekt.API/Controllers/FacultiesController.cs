using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt.API.Data;
using Projekt.API.Data.DTOs.Faculty;
using Projekt.API.Data.Models;

namespace Projekt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public FacultiesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        //Krijo nje API endpoint per te marre te dhenat nga DB
        [HttpGet("GetAllFaculties")]
        public IActionResult GetAllFaculties()
        {
            var allFaculties = _appDbContext.Faculties.ToList();

            return Ok(allFaculties);
        }

        //Krijo nje API endpoint per te marre te dhenat nga DB
        [HttpGet("GetFacultyById/{id}")]
        public IActionResult GetFacultyById(int id)
        {
            var faculty = _appDbContext.Faculties.FirstOrDefault(x => x.Id == id);

            if (faculty == null)
            {
                return NotFound();
            }

            return Ok(faculty);
        }

        [HttpPost("AddFaculty")]
        public IActionResult AddFaculty([FromBody] PostFacultyDTO payload)
        {
            Faculty newFaculty = new Faculty()
            {
                Name = payload.Name,
                Code = payload.Code,
                Dean = payload.Dean,
                DateCreated = DateTime.UtcNow
            };

            _appDbContext.Faculties.Add(newFaculty);
            _appDbContext.SaveChanges();

            return Ok("Fakulteti u krijua me sukses!");
        }

        [HttpPut("UpdateFaculty")]
        public IActionResult UpdateFaculty([FromBody] PutFacultyDTO payload, int id)
        {
            //1. Duke perdour ID marrim te dhenat nga databaza
            var faculty = _appDbContext.Faculties.FirstOrDefault(x => x.Id == id);

            //2. Perditesojme Facultyin e DB me te dhenat e payload-it
            if (faculty == null)
                return NotFound();

            faculty.Name = payload.Name;
            faculty.Code = payload.Code;
            faculty.Dean = payload.Dean;

            //3. Ruhen te dhenat ne database
            _appDbContext.Faculties.Update(faculty);
            _appDbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteFaculty/{id}")]
        public IActionResult DeleteFaculty(int id)
        {
            var faculty = _appDbContext.Faculties.FirstOrDefault(x => x.Id == id);

            if (faculty == null)
                return NotFound();

            _appDbContext.Faculties.Remove(faculty);
            _appDbContext.SaveChanges();

            return Ok($"Fakulteti me id = {id} u fshi me sukses!");
        }
    }
}
