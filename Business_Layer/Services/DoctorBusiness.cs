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
    public class DoctorBusiness : IDoctorBusiness
    {
        readonly IDoctorRepo _Doctorrepo;
        public DoctorBusiness(IDoctorRepo repo)
        {
            _Doctorrepo = repo;
        }
        public bool AddDoctor(DoctorModel doctor)
        {
            return _Doctorrepo.AddDoctor(doctor);
        }

        public List<DoctorModel> GetAllDoctor()
        {
            return _Doctorrepo.GetAllDoctor();
        }

        public DoctorModel GetDoctorById(int id)
        {
            return _Doctorrepo.GetDoctorById(id);
        }
        public bool UpdateDoctor(DoctorModel doctor)
        {
            return _Doctorrepo.UpdateDoctor(doctor);
        }
        public bool DeleteDoctorById(int id)
        {
            return _Doctorrepo.DeleteDoctorById(id);
        }
    }
}
