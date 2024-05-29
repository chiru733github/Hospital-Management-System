using Business_Layer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;
using NuGet.Protocol.Plugins;

namespace Hospital_Management_System.Controllers
{
    public class PatientController : Controller
    {
        readonly IPatientBusiness patientBusiness;
        public PatientController(IPatientBusiness patient)
        {
            this.patientBusiness = patient;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(PatientModel patient)
        {
            bool result = patientBusiness.AddPatient(patient);
            if(result) return RedirectToAction("GetAllPatientDetails");
            else return View("Index");
        }
        [HttpGet]
        public IActionResult GetAllPatientDetails()
        {
            List<PatientModel> allPatient = new List<PatientModel>();
            allPatient = patientBusiness.GetAllPatient().ToList();
            if (allPatient != null) return View(allPatient);
            else return View("Index");
        }
        [HttpGet]
        // [Route("GetById/{PatientId}")]
        public IActionResult GetPatientById(int PatientId)
        {
            PatientModel patient = patientBusiness.GetPatientById(PatientId);
            if (patient != null) return View(patient);
            else return View("GetAllPatientDetails");
        }

        [HttpGet]
        public IActionResult UpdatePatient(int id)
        {
            PatientModel patient = patientBusiness.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePatient(int id, [Bind] PatientModel patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                bool res = patientBusiness.UpdatePatient(patient);
                if(res) return RedirectToAction("GetAllPatientDetails");
                return View("Index");
            }
            return View(patient);
        }
        [HttpGet]
        public IActionResult DeletePatientById(int id)
        {
            PatientModel patient = patientBusiness.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost, ActionName("DeletePatientById")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bool result = patientBusiness.DeletePatientById(id);
            if(result) return RedirectToAction("GetAllPatientDetails");
            return View("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginPatient patient)
        {
            PatientModel result = patientBusiness.Login(patient);
            if (result == null)
            {
                return Content("Invalid Credentials");
            }
            else
            {
                return RedirectToAction("GetPatientById", new { PatientId = result.Id });
            }
        }
    }
}
