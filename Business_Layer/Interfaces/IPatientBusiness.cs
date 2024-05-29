using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;

namespace Business_Layer.Interfaces
{
    public interface IPatientBusiness
    {
        bool AddPatient(PatientModel Patient);
        List<PatientModel> GetAllPatient();
        PatientModel Login(LoginPatient Patient);
        PatientModel GetPatientById(int Id);
        bool UpdatePatient(PatientModel patient);
        bool DeletePatientById(int id);
    }
}
