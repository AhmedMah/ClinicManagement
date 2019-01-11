using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;

namespace ClinicManagement.Persistence.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Doctor> GetDectors()
        {
            return _context.Doctors
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .ToList();
        }

        /// <summary>
        /// Get the available doctors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Doctor> GetAvailableDoctors()
        {
            return _context.Doctors
                .Where(a => a.IsAvailable == true)
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .ToList();
        }
        /// <summary>
        /// Get single Doctor - Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Doctor GetDoctor(int id)
        {
            return _context.Doctors
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .SingleOrDefault(d => d.Id == id);
        }

        public Doctor GetProfile(string userId)
        {
            return _context.Doctors
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .SingleOrDefault(d => d.PhysicianId == userId);
        }
        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
        }
    }
}