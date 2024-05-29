using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ModelLayer.Models
{
    public class DoctorModel
    {
		public int Id { get; set; }
        public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public int Age { get; set; }
		public string gender { get; set; }
		public string Address { get; set; }
		public string Qualification { get; set; }
		public string Specialization { get; set; }
		public Double Experience { get; set; }
		public string DoctorImage { get; set;}
		public bool IsTrash { get; set; }
    }
}
