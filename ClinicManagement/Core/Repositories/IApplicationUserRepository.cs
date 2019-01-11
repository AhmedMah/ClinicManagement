using System.Collections.Generic;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.ViewModel;

namespace ClinicManagement.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        List<UserViewModel> GetUsers();
        ApplicationUser GetUser(string id);
    }
}