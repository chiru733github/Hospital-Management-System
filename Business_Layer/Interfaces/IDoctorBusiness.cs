using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;

namespace Business_Layer.Interfaces
{
    public interface IDoctorBusiness
    {
        bool AddDoctor(DoctorModel doctor);
        List<DoctorModel> GetAllDoctor();
        DoctorModel GetDoctorById(int id);
        bool UpdateDoctor(DoctorModel doctor);
        bool DeleteDoctorById(int id);
    }
}
