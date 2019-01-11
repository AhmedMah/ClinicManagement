using System.Data.Entity.ModelConfiguration;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Persistence.EntityConfigurations
{
    public class PatientStatusConfiguration : EntityTypeConfiguration<PatientStatus>
    {
        public PatientStatusConfiguration()
        {
            Property(s => s.Name).IsRequired().HasMaxLength(255);
        }
    }
}