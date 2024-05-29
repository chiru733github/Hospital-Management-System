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
            if (result) return RedirectToAction("AddAppointment");
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
    }
}
