using System.Collections.Generic;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Core.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetDectors();
        IEnumerable<Doctor> GetAvailableDoctors();
        Doctor GetDoctor(int id);
        Doctor GetProfile(string userId);
        void Add(Doctor doctor);
    }
}