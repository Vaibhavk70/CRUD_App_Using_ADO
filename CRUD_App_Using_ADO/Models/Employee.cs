using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CRUD_App_Using_ADO.Models
{
    public class Employee
    {
        [Required] 
        public int ID { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string Dept { get; set; }
        [Required]
        public string City { get; set; }

    }
}