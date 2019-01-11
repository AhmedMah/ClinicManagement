using System.Collections.Generic;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Core.ViewModel
{
    public class DoctorDetailViewModel
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<Appointment> UpcomingAppointments { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}