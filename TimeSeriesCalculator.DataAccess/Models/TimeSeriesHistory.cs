using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSeriesCalculator.DataAccess.Models.Abstraction;
using TimeSeriesCalculator.DataAccess.Models.Enums;

namespace TimeSeriesCalculator.DataAccess.Models
{
    public class TimeSeriesHistory : BaseEntity
    {
        public DateTime TryingDate { get; set; }
        public TimeSeriesType Type { get; set; }
        public double Value { get; set; }
        public int PatientChildId { get; set; }
        public PatientChild PatientChild { get; set; }

        public class TimeSeriesHistoryConfigurations : IEntityTypeConfiguration<TimeSeriesHistory>
        {
            public void Configure(EntityTypeBuilder<TimeSeriesHistory> builder)
            {
                builder.HasKey(x => x.Id);
            }
        }
    }
}
