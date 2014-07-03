using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [DisplayName("Name")]
        [Required, MinLength(3, ErrorMessage = "Too Short!"), MaxLength(5, ErrorMessage = "Too Long!")]
        public string Username { get; set; }

        [DisplayName("Secrete Code")]
        [Required]
        public string Password { get; set; }
        
        [DisplayName("Group")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        [NotMapped]
        public SelectList DepartmentList { get; set; }
    }
}