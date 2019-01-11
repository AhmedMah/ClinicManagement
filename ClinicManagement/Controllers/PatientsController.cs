using System;
using System.Linq;
using System.Web.Mvc;
using ClinicManagement.Core;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.ViewModel;

namespace ClinicManagement.Controllers
{
    [Authorize(Roles = RoleName.DoctorRoleName + "," + RoleName.AdministratorRoleName)]
    public class PatientsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            var viewModel = new PatientDetailViewModel()
            {
                Patient = _unitOfWork.Patients.GetPatient(id),
                Appointments = _unitOfWork.Appointments.GetAppointmentWithPatient(id),
                Attendances = _unitOfWork.Attandences.GetAttendance(id),
                CountAppointments = _unitOfWork.Appointments.CountAppointments(id),
                CountAttendance = _unitOfWork.Attandences.CountAttendances(id)
            };
            return View("Details", viewModel);
        }




        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new PatientFormViewModel
            {
                Cities = _unitOfWork.Cities.GetCities(),
                Heading = "New Patient"
            };
            return View("PatientForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Cities = _unitOfWork.Cities.GetCities();
                return View("PatientForm", viewModel);

            }

            var patient = new Patient
            {
                Name = viewModel.Name,
                Phone = viewModel.Phone,
                Address = viewModel.Address,
                DateTime = DateTime.Now,
                BirthDate = viewModel.GetBirthDate(),
                Height = viewModel.Height,
                Weight = viewModel.Weight,
                CityId = viewModel.City,
                Sex = viewModel.Sex,
                Token = (2018 + _unitOfWork.Patients.GetPatients().Count()).ToString().PadLeft(7, '0')
            };

            _unitOfWork.Patients.Add(patient);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Patients");

            // TODO: BUG redirect to detail 
            //return RedirectToAction("Details", new { id = viewModel.Id });
        }


        public ActionResult Edit(int id)
        {
            var patient = _unitOfWork.Patients.GetPatient(id);

            var viewModel = new PatientFormViewModel
            {
                Heading = "Edit Patient",
                Id = patient.Id,
                Name = patient.Name,
                Phone = patient.Phone,
                Date = patient.DateTime,
                //Date = patient.DateTime.ToString("d MMM yyyy"),
                BirthDate = patient.BirthDate.ToString("dd/MM/yyyy"),
                Address = patient.Address,
                Height = patient.Height,
                Weight = patient.Weight,
                Sex = patient.Sex,
                City = patient.CityId,
                Cities = _unitOfWork.Cities.GetCities()
            };
            return View("PatientForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PatientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Cities = _unitOfWork.Cities.GetCities();
                return View("PatientForm", viewModel);
            }


            var patientInDb = _unitOfWork.Patients.GetPatient(viewModel.Id);
            patientInDb.Id = viewModel.Id;
            patientInDb.Name = viewModel.Name;
            patientInDb.Phone = viewModel.Phone;
            patientInDb.BirthDate = viewModel.GetBirthDate();
            patientInDb.Address = viewModel.Address;
            patientInDb.Height = viewModel.Height;
            patientInDb.Weight = viewModel.Weight;
            patientInDb.Sex = viewModel.Sex;
            patientInDb.CityId = viewModel.City;

            _unitOfWork.Complete();
            return RedirectToAction("Index", "Patients")
;
        }



    }
}