using Business_Layer.Interfaces;
using Business_Layer.Services;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;

namespace Hospital_Management_System.Controllers
{
    public class AppointmentController : Controller
    {
        readonly IAppointmentBL appointmentBL;
        public AppointmentController(IAppointmentBL appointment)
        {
            this.appointmentBL=appointment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddAppointment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAppointment(AppointmentModel AM)
        {
            bool result = appointmentBL.AddAppointment(AM);
            int patientId = (int)@HttpContext.Session.GetInt32("patientId");
            if (result && patientId > 0) return RedirectToAction("GetAllDoctorDetails","Doctor");
            else if (result) return RedirectToAction("AddAppointment");
            return View("Index");
        }
        [HttpGet]
        public IActionResult GetAllAppointmentDetails()
        {
            List<AppointmentModel> allAppointment = new List<AppointmentModel>();
            allAppointment = appointmentBL.GetAllAppointment().ToList();
            if (allAppointment != null) return View(allAppointment);
            return View("Index");
        }
        [HttpGet]
        public IActionResult GetDoctorWithPatients()
        {
            List<DoctorWithPatient> DocWithPatientAppointment = new List<DoctorWithPatient>();
            DocWithPatientAppointment = appointmentBL.GetDoctorWithPatients().ToList();
            if (DocWithPatientAppointment != null) return View(DocWithPatientAppointment);
            return View("Index");
        }
    }
}
