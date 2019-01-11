using System.Data.Entity.ModelConfiguration;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Persistence.EntityConfigurations
{
    public class DoctorConfiguration : EntityTypeConfiguration<Doctor>
    {
        public DoctorConfiguration()
        {
            Property(d => d.PhysicianId).IsRequired();
            Property(d => d.SpecializationId).IsRequired();
            Property(d => d.Name).IsRequired().HasMaxLength(255);
            Property(d => d.Phone).IsRequired();
        }
    }
}