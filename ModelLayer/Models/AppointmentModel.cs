using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class AppointmentModel
    {
        public int AMId { get; set; }
        public int Doctorid { get; set; }
        public int Patientid { get; set; }
        public DateTime date {  get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public string concern { get; set; }

    }
}
