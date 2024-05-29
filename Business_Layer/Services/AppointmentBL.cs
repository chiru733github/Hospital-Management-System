using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Layer.Interfaces;
using ModelLayer.Models;
using Repository_Layer.Interfaces;

namespace Business_Layer.Services
{
    public class AppointmentBL : IAppointmentBL
    {
        readonly IAppointmentRepo _appointmentRepo;
        public AppointmentBL(IAppointmentRepo repo)
        {
            this._appointmentRepo = repo;
        }
        public bool AddAppointment(AppointmentModel AMmodel)
        {
            return _appointmentRepo.AddAppointment(AMmodel);
        }
        public List<AppointmentModel> GetAllAppointment()
        {
            return _appointmentRepo.GetAllAppointment();
        }
    }
}
