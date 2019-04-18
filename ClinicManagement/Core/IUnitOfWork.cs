using ClinicManagement.Core.Repositories;

namespace ClinicManagement.Core
{
    public interface IUnitOfWork
    {
        IPatientRepository Patients { get; }
        IAppointmentRepository Appointments { get; }
        IAttendanceRepository Attandences { get; }
        ICityRepository Cities { get; }
        IDoctorRepository Doctors { get; }
        ISpecializationRepository Specializations { get; }
        IApplicationUserRepository Users { get; }

        void Complete();
    }
}