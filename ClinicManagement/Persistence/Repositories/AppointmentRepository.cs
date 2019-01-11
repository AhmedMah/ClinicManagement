using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;
using ClinicManagement.Core.ViewModel;

namespace ClinicManagement.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all appointments
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Appointment> GetAppointments()
        {
            return _context.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .ToList();
        }
        /// <summary>
        /// Get appointments for single patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Appointment> GetAppointmentWithPatient(int id)
        {
            return _context.Appointments
                .Where(p => p.PatientId == id)
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .ToList();
        }
        /// <summary>
        /// Get appointments for single doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Appointment> GetAppointmentByDoctor(int id)
        {
            //return (from a in _context.Appointments where a.DoctorId == id select a).AsEnumerable();

            return _context.Appointments
                .Where(d => d.DoctorId == id)
                .Include(p => p.Patient)
                .ToList();
        }

        /// <summary>
        /// Get upcomming appointments for doctor - Admin section
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Appointment> GetTodaysAppointments(int id)
        {
            DateTime today = DateTime.Now.Date;
            return _context.Appointments
                .Where(d => d.DoctorId == id && d.StartDateTime >= today)
                .Include(p => p.Patient)
                .OrderBy(d => d.StartDateTime)
                .ToList();
        }
        /// <summary>
        /// Get upcomming appointments for specific doctor
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Appointment> GetUpcommingAppointments(string userId)
        {
            DateTime today = DateTime.Now.Date;
            return _context.Appointments
                .Where(d => d.Doctor.PhysicianId == userId && d.StartDateTime >= today && d.Status==true)
                .Include(p => p.Patient)
                .OrderBy(d => d.StartDateTime)
                .ToList();
        }

        public IQueryable<Appointment> FilterAppointments(AppointmentSearchVM searchModel)
        {
            var result = _context.Appointments.Include(p => p.Patient).Include(d => d.Doctor).AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrWhiteSpace(searchModel.Name))
                    result = result.Where(a => a.Doctor.Name == searchModel.Name);
                if (!string.IsNullOrWhiteSpace(searchModel.Option))
                {
                    if (searchModel.Option == "ThisMonth")
                    {
                        result = result.Where(x => x.StartDateTime.Year == DateTime.Now.Year && x.StartDateTime.Month == DateTime.Now.Month);
                    }
                    else if (searchModel.Option == "Pending")
                    {
                        result = result.Where(x => x.Status == false);
                    }
                    else if (searchModel.Option == "Approved")
                    {
                        result = result.Where(x => x.Status);
                    }
                }
            }

            return result;

        }
        /// <summary>
        /// Get Daily appointments
        /// </summary>
        /// <param name="getDate"></param>
        /// <returns></returns>
        public IEnumerable<Appointment> GetDaillyAppointments(DateTime getDate)
        {
            return _context.Appointments.Where(a => DbFunctions.DiffDays(a.StartDateTime, getDate) == 0)
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .ToList();
        }

        /// <summary>
        /// Validate appointment date and time
        /// </summary>
        /// <param name="appntDate"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ValidateAppointment(DateTime appntDate, int id)
        {
            return _context.Appointments.Any(a => a.StartDateTime == appntDate && a.DoctorId == id);
        }
        /// <summary>
        /// Get number of appointments for defined patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CountAppointments(int id)
        {
            return _context.Appointments.Count(a => a.PatientId == id);
        }


        /// <summary>
        /// Get single appointment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Appointment GetAppointment(int id)
        {
            return _context.Appointments.Find(id);
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
        }

    }
}