using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="* Name is Required")]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required(ErrorMessage = "* Age Should be Length of 2")]
        [StringLength(2)]
        public string Age { get; set; }
        [Required(ErrorMessage = "* Age Should be Length of 7")]
        [StringLength(7)]
        public string Salary { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedBy { get; set; }
        [Required]
        private bool isactive = true;
        public bool IsActive{ get {  return isactive; } set { isactive = value ; } }
    }
}