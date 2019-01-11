using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ClinicManagement.Persistence.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        public readonly ApplicationDbContext Context;

        public SpecializationRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<Specialization> GetSpecializations()
        {
            return Context.Specializations.ToList();
        }
    }
}