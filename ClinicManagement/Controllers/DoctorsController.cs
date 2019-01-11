using System.Web.Mvc;
using ClinicManagement.Core;
using ClinicManagement.Core.ViewModel;
using Microsoft.AspNet.Identity;

namespace ClinicManagement.Controllers
{
    [Authorize]
    public class DoctorsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var doctors = _unitOfWork.Doctors.GetDectors();
            return View(doctors);
        }

        //Details for admin
        public ActionResult Details(int id)
        {
            var viewModel = new DoctorDetailViewModel
            {
                Doctor = _unitOfWork.Doctors.GetDoctor(id),
                UpcomingAppointments = _unitOfWork.Appointments.GetTodaysAppointments(id),
                Appointments = _unitOfWork.Appointments.GetAppointmentByDoctor(id),
            };
            return View(viewModel);
        }

        public ActionResult DoctorProfile()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new DoctorDetailViewModel
            {
                Doctor = _unitOfWork.Doctors.GetProfile(userId),
                Appointments = _unitOfWork.Appointments.GetUpcommingAppointments(userId),
            };
            return View(viewModel);
        }
        public ActionResult Edit(int id)
        {
            var doctor = _unitOfWork.Doctors.GetDoctor(id);
            if (doctor == null) return HttpNotFound();
            var viewModel = new DoctorFormViewModel()
            {

                Id = doctor.Id,
                Name = doctor.Name,
                Phone = doctor.Phone,
                Address = doctor.Address,
                IsAvailable = doctor.IsAvailable,
                Specialization = doctor.SpecializationId,
                Specializations = _unitOfWork.Specializations.GetSpecializations()

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(DoctorFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Specializations = _unitOfWork.Specializations.GetSpecializations();
                return View(viewModel);
            }

            var doctorInDb = _unitOfWork.Doctors.GetDoctor(viewModel.Id);
            doctorInDb.Id = viewModel.Id;
            doctorInDb.Name = viewModel.Name;
            doctorInDb.Phone = viewModel.Phone;
            doctorInDb.Address = viewModel.Address;
            doctorInDb.IsAvailable = viewModel.IsAvailable;
            doctorInDb.SpecializationId = viewModel.Specialization;

            _unitOfWork.Complete();

            return RedirectToAction("Details", new { id = viewModel.Id });
        }


    }

}

