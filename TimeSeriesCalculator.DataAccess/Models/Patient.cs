using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSeriesCalculator.DataAccess.Models.Abstraction;

namespace TimeSeriesCalculator.DataAccess.Models
{
    public class Patient : Identity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<PatientChild> PatientChildren { get; set; }

        public class CustomerConfigurations : IEntityTypeConfiguration<Patient>
        {
            public void Configure(EntityTypeBuilder<Patient> builder)
            {
                builder.HasKey(x => x.ObjectId);
            }
        }
    }
}
