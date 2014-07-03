using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}