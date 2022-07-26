using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TimeSeriesCalculator.DataAccess.Models.Abstraction;

public interface IBaseEntity
{
}
public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
}

public abstract class BaseEntityConfigurations<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
