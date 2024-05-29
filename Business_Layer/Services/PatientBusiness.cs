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
    public class PatientBusiness : IPatientBusiness
    {
        readonly IPatientRepo _PatientRepo;
        public PatientBusiness(IPatientRepo repo)
        {
            this._PatientRepo = repo;
        }
        public bool AddPatient(PatientModel Patient)
        {
            return _PatientRepo.AddPatient(Patient);
        }
        public List<PatientModel> GetAllPatient()
        {
            return _PatientRepo.GetAllPatient();
        }
        public PatientModel Login(LoginPatient Patient)
        {
            return _PatientRepo.Login(Patient);
        }

        public PatientModel GetPatientById(int Id)
        {
            return _PatientRepo.GetPatientById(Id);
        }
        public bool UpdatePatient(PatientModel patient)
        {
            return _PatientRepo.UpdatePatient(patient);
        }
        public bool DeletePatientById(int id)
        {
            return _PatientRepo.DeletePatientById(id);
        }
    }
}
