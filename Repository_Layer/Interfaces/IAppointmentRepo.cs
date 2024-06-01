using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;

namespace Repository_Layer.Interfaces
{
    public interface IAppointmentRepo
    {
        bool AddAppointment(AppointmentModel AMmodel);
        List<AppointmentModel> GetAllAppointment();
        List<DoctorWithPatient> GetDoctorWithPatients();
    }
}
