using hogwartsAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hogwartsAPI.DTO
{
    public class FirstAdmissionDTO
    {

        [StringLength(20, ErrorMessage = "Only 20 characters allowed ")]
        [Required(ErrorMessage = "This parameter is mandatory")]
        [RegularExpression("[A-ZA-z]*", ErrorMessage = "This parameter only allows letters")]
        public string Name { get; set; }


        [StringLength(20, ErrorMessage = "Only 20 characters allowed ")]
        [RegularExpression("[A-ZA-z]*", ErrorMessage = "This parameter only allows letters")]
        [Required(ErrorMessage = "This parameter is mandatory")]
        public string Lastname { get; set; }

       
        [StringLength(10,ErrorMessage = "Only 10 characters allowed ")]
        [Required(ErrorMessage = "This parameter is mandatory")]
        [RegularExpression("[0-9]*", ErrorMessage = "This parameter only allows numbers")]
        public string DNI { get; set; }



        [Range(1,80, ErrorMessage = "Only 2 characters allowed ")]
        [RegularExpression("[0-9]*", ErrorMessage = "This parameter only allows numbers")]
        [Required(ErrorMessage = "This parameter is mandatory")]
        public int Age { get; set; }


        
        [Required(ErrorMessage = "This parameter is mandatory")]
        [RegularExpression("[A-ZA-z]*", ErrorMessage = "This parameter only allows letters")]
        //[def("Gryffindor", ErrorMessage = "This parameter only allows Gryffindor,Hufflepuff,Ravenclaw,")]
        public string House { get; set; }

    }

 
}
