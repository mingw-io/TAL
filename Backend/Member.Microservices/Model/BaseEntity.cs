/// <summary>
/// 
/// </summary>
namespace Member.Microservices.Model
{
    /// <summary>
    /// 
    /// </summary>
    public enum OccupationEnum
    {
        Florist,
        Mechanic,
        Farmer,
        Author,
        Doctor,
        Cleaner
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
    }
}