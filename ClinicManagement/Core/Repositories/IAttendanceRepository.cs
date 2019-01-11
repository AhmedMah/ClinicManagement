using System.Collections.Generic;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetAttandences();
        IEnumerable<Attendance> GetAttendance(int id);
        IEnumerable<Attendance> GetPatientAttandences(string searchTerm = null);
        int CountAttendances(int id);
        void Add(Attendance attendance);
    }
}
