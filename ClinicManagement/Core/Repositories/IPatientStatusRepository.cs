using System.Collections.Generic;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Core.Repositories
{
    public interface IPatientStatusRepository
    {
        IEnumerable<PatientStatus> GetStatuses();

    }
}