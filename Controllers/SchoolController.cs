using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FindASchool.Models;
using System.Linq;
using System.Data.Entity;

namespace FindASchool.Controllers
{
    // set route attribute to make request as 'api/school'  
    [Route("api/[controller]")]  
    public class SchoolController : Controller {  
      
        private readonly SchoolContext _context; 

         // initiate database context  
        public SchoolController(SchoolContext context) {  
                _context = context;  
        }

        [HttpGet]  
        [Route("getAllSchool")]  
        public List<School> GetAll() {  
                // fetch all school records  
                return _context.School.ToList();  
        }  

        [HttpGet("{id}")]  
        [Route("getSchool")]  
        public IActionResult GetById(long id) {  
                // filter school records by school id  
                var item = _context.School.FirstOrDefault(t => t.SchoolID == id);  
                if (item == null) {  
                    return NotFound();  
                }  
                return new ObjectResult(item);  
        }  

        [HttpPost]  
        [Route("addSchool")]  
        public IActionResult Create([FromBody] School item) {  
                // set bad request if school data is not provided in body  
                if (item == null) {  
                   return BadRequest();  
                } 
                _context.School.Add(new School { 
                    Name = item.Name, 
                    Email = item.Email,  
                    PublicInd = item.PublicInd,  
                    GenderType = item.GenderType
                });  
                _context.SaveChanges();  
                return Ok(new {  
                    message = "School added successfully."  
                });
        }  

        [HttpPut("{id}")]  
        [Route("updateSchool")]  
        public IActionResult Update(long id, [FromBody] School item) {  
            // set bad request if school data is not provided in body  
            if (item == null || id == 0) {  
                return BadRequest();  
            }  
            var school = _context.School.FirstOrDefault(t => t.SchoolID == id);  
            if (school == null) {  
                return NotFound();  
            }  
            school.Name = item.Name;  
            school.Email = item.Email;  
            school.PublicInd = item.PublicInd;  
            school.GenderType = item.GenderType;   

            _context.School.Update(school);  
            _context.SaveChanges();  
            return Ok(new {  
                message = "School updated successfully."  
            });  
        }  

        [HttpDelete("{id}")]  
        [Route("deleteSchool")]  
        public IActionResult Delete(long id) {  
            var school = _context.School.FirstOrDefault(t => t.SchoolID == id);  
            if (school == null) {  
                return NotFound();  
            }  
            _context.School.Remove(school);  
            _context.SaveChanges();  
            return Ok(new {  
                message = "School deleted successfully."  
            });  
        }  
   }  
}    
    
