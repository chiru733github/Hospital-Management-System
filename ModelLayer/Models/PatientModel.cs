using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public string Email { get; set; }
		public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PatientImage { get; set; }
        public string BloodGroup { get; set; }
        public string SufferFrom { get; set; }
        public bool IsTrash {  get; set; }
    }
}
