using hogwartsAPI.Application;
using hogwartsAPI.DataAccess;
using hogwartsAPI.DTO;
using hogwartsAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hogwartsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        InterfaceApplication<FirstAdmission> _admission;

        public AdmissionController(InterfaceApplication<FirstAdmission> admission)
        {
            _admission = admission;

        }


        // Endpoint to get all admission requests
        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_admission.GetAll());

        }


        //endpoint for a new admission request
        [HttpPost]

        public IActionResult Save(FirstAdmissionDTO dto)
        {
            if ((dto.House == "Gryffindor") || (dto.House == "Hufflepuff") || (dto.House == "Ravenclaw") || (dto.House == "Slytherin")) 
            {


                var f = new FirstAdmission()
                {
                    Name = dto.Name,
                    Lastname = dto.Lastname,
                    DNI = dto.DNI,
                    Age = dto.Age,

                    House = dto.House
                };
                    _admission.Save(f);
                    return Ok("application for admission received");
                
            }
            else {
                return BadRequest("house not valid. use the houses indicated in the documentation");
            }
        }

        //endpoint for update one admission request
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, FirstAdmissionDTO dto)
        {
         
            if (id == 0 || dto == null)
                {
                  return NotFound();
               }

             if ((dto.House == "Gryffindor") || (dto.House == "Hufflepuff") || (dto.House == "Ravenclaw") || (dto.House == "Slytherin"))
                {
                
                    var tmp = _admission.GetById(id);
                    if (tmp != null) {
                        tmp.Id = id;
                        tmp.Name = dto.Name;
                        tmp.Lastname = dto.Lastname;
                        tmp.DNI = dto.DNI;
                        tmp.Age = dto.Age;
                        tmp.House = dto.House;
                    }

                        _admission.Save(tmp);
                         return Ok(tmp);                      
                 }
                  else{
                      return BadRequest("house not valid. use the houses indicated in the documentation");
                    }
        }
        

        // endpoint for delete admission request
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {

            if (id == 0)
                return NotFound();
                
           
            _admission.Delete(id);
            return Ok("application for admission deleted");
        }

    }
}
