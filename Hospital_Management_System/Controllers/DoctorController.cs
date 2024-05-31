using Business_Layer.Interfaces;
using Business_Layer.Services;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;

namespace Hospital_Management_System.Controllers
{
    public class DoctorController : Controller
    {
        readonly IDoctorBusiness doctorBusiness;
        public DoctorController(IDoctorBusiness doctor)
        {
            this.doctorBusiness = doctor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDoctor(DoctorModel Doctor)
        {
            bool result = doctorBusiness.AddDoctor(Doctor);
            if(result) return RedirectToAction("");
            return View("Index");
        }
        [HttpGet]
        public IActionResult GetAllDoctorDetails()
        {
            List<DoctorModel> allDoctor = new List<DoctorModel>();
            allDoctor = doctorBusiness.GetAllDoctor().ToList();
            if(allDoctor!=null) return View(allDoctor);
            return View("Index");
        }
        [HttpGet]
        public IActionResult GetByIdDoctor(int id) 
        {
            HttpContext.Session.SetInt32("DoctorId",id);
            DoctorModel doctor = doctorBusiness.GetDoctorById(id);
            if(doctor!=null) return View(doctor);
            return View("Index");
        }
        [HttpGet]
        public IActionResult UpdateDoctor(int id)
        {
            DoctorModel doctor = doctorBusiness.GetDoctorById(id);

            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateDoctor(int id, [Bind] DoctorModel doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                bool res = doctorBusiness.UpdateDoctor(doctor);
                if (res) return RedirectToAction("GetAllDoctorDetails");
                return View("Index");
            }
            return View(doctor);
        }
        [HttpGet]
        public IActionResult DeleteDoctorById(int id)
        {
            DoctorModel doctor = doctorBusiness.GetDoctorById(id);

            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpPost, ActionName("DeleteDoctorById")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bool result = doctorBusiness.DeleteDoctorById(id);
            if (result) return RedirectToAction("GetAllDoctorDetails");
            return View("Index");
        }
    }
}
