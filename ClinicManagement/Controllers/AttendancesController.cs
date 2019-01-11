using System;
using System.Web.Mvc;
using ClinicManagement.Core;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.ViewModel;

namespace ClinicManagement.Controllers
{
    [Authorize]
    public class AttendancesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Details(int id)
        {
            var attendance = _unitOfWork.Attandences.GetAttendance(id);
            return View("_attendancePartial", attendance);
        }

        public ActionResult Create(int id)
        {
            var viewModel = new AttendanceFormViewModel
            {
                Patient = id,
                Heading = "Add Attendance"
            };
            return View("AttendanceForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(AttendanceFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("AttendanceForm", viewModel);

            var attendance = new Attendance
            {
                Id = viewModel.Id,
                ClinicRemarks = viewModel.ClinicRemarks,
                Diagnosis = viewModel.Diagnosis,
                SecondDiagnosis = viewModel.SecondDiagnosis,
                ThirdDiagnosis = viewModel.ThirdDiagnosis,
                Therapy = viewModel.Therapy,
                Date = DateTime.Now,
                Patient = _unitOfWork.Patients.GetPatient(viewModel.Patient)
            };
            _unitOfWork.Attandences.Add(attendance);
            _unitOfWork.Complete();
            //ViewBag.Confirm = "Successfully Saved";
            //return PartialView("_Confirmation");
            return RedirectToAction("Details", "Patients", new { id = viewModel.Patient });
        }



    }
}