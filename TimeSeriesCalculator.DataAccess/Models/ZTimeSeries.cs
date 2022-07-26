using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSeriesCalculator.DataAccess.Models.Abstraction;
using TimeSeriesCalculator.DataAccess.Models.Enums;

namespace TimeSeriesCalculator.DataAccess.Models
{
    public class ZTimeSeries : BaseEntity
    {
        public int Month { get; set; }
        public bool Gender { get; set; }
        public TimeSeriesType Type { get; set; }
        public double SD3neg { get; set; }
        public double SD2neg { get; set; }
        public double SD1neg { get; set; }
        public double SD0 { get; set; }
        public double SD1 { get; set; }
        public double SD2 { get; set; }
        public double SD3 { get; set; }

        public class ZTimeSeriesConfigurations : IEntityTypeConfiguration<ZTimeSeries>
        {
            public void Configure(EntityTypeBuilder<ZTimeSeries> builder)
            {
                builder.HasKey(x => x.Id);
            }
        }
    }
}
