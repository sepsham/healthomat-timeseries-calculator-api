namespace TimeSeriesCalculator.DataAccess.Models.Abstraction
{
    public interface IIdentity
    {
    }

    public abstract class Identity : BaseEntity, IIdentity
    {
        public Guid ObjectId { get; set; }
    }
}
