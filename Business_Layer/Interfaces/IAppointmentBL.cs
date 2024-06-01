using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;

namespace Business_Layer.Interfaces
{
    public interface IAppointmentBL
    {
        bool AddAppointment(AppointmentModel AMmodel);
        List<AppointmentModel> GetAllAppointment();
        List<DoctorWithPatient> GetDoctorWithPatients();
    }
}
