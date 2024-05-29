using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;

namespace Repository_Layer.Interfaces
{
    public interface IPatientRepo
    {
        bool AddPatient(PatientModel Patient);
        List<PatientModel> GetAllPatient();
        PatientModel Login(LoginPatient Patient);
        PatientModel GetPatientById(int id);
        bool UpdatePatient(PatientModel patient);
        bool DeletePatientById(int id);
    }
}
