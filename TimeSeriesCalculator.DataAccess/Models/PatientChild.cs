using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSeriesCalculator.DataAccess.Models.Abstraction;

namespace TimeSeriesCalculator.DataAccess.Models
{
    public class PatientChild : BaseEntity
    {
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public class CustomerConfigurations : IEntityTypeConfiguration<PatientChild>
        {
            public void Configure(EntityTypeBuilder<PatientChild> builder)
            {
                builder.HasKey(x => x.Id);

                builder.HasOne(x => x.Patient)
                       .WithMany(a => a.PatientChildren)
                       .HasForeignKey(x => x.PatientId);

            }
        }
    }
}
