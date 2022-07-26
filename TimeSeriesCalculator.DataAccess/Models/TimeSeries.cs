using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSeriesCalculator.DataAccess.Models.Abstraction;
using TimeSeriesCalculator.DataAccess.Models.Enums;

namespace TimeSeriesCalculator.DataAccess.Models
{
    public class TimeSeries : BaseEntity
    {
        public int Month { get; set; }
        public bool Gender { get; set; }
        public TimeSeriesType Type { get; set; }
        public double P1 { get; set; }
        public double P3 { get; set; }
        public double P5 { get; set; }
        public double P10 { get; set; }
        public double P15 { get; set; }
        public double P25 { get; set; }
        public double P50 { get; set; }
        public double P75 { get; set; }
        public double P85 { get; set; }
        public double P90 { get; set; }
        public double P95 { get; set; }
        public double P97 { get; set; }
        public double P99 { get; set; }

        public class TimeSeriesConfigurations : IEntityTypeConfiguration<TimeSeries>
        {
            public void Configure(EntityTypeBuilder<TimeSeries> builder)
            {
                builder.HasKey(x => x.Id);
            }
        }
    }
}
