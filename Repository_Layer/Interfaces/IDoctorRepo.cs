using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;

namespace Repository_Layer.Interfaces
{
    public interface IDoctorRepo
    {
        bool AddDoctor(DoctorModel doctor);
        List<DoctorModel> GetAllDoctor();
        DoctorModel GetDoctorById(int id);
        bool UpdateDoctor(DoctorModel doctor);
        bool DeleteDoctorById(int id);
    }
}
