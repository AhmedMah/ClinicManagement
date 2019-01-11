using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;

namespace ClinicManagement.Persistence.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Attendance> GetAttandences()
        {
            return _context.Attendances.ToList();
        }
        /// <summary>
        /// Get attandences for single patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Attendance> GetAttendance(int id)
        {
            return _context.Attendances.Where(p => p.PatientId == id).ToList();
        }
        /// <summary>
        /// search  attandences for patient by token 
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public IEnumerable<Attendance> GetPatientAttandences(string searchTerm = null)
        {
            var attandences = _context.Attendances.Include(p => p.Patient);
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                attandences = attandences.Where(p => p.Patient.Token.Contains(searchTerm));
            }
            return attandences.ToList();
        }
        /// <summary>
        /// Get number of attendances for defined patient 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CountAttendances(int id)
        {
            return _context.Attendances.Count(a => a.PatientId == id);
        }
        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }
    }
}