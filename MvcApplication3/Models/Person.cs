using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Models
{
    public class Person
    {
        [DisplayName("Name")]
        [Required, MinLength(3, ErrorMessage = "Too Short!"), MaxLength(5, ErrorMessage = "Too Long!")]
        public string Username { get; set; }

        [DisplayName("Secrete Code")]
        [Required]
        public string Password { get; set; }
        
        [DisplayName("Group")]
        public string Department { get; set; }

        public SelectList DepartmentList { get; set; }
    }
}