using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ClinicManagement.Persistence.Repositories
{
    public class PatientStatusRepository : IPatientStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PatientStatus> GetStatuses()
        {
            return _context.PatientStatus.ToList();
        }
    }
}