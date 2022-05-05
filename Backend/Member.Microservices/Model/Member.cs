/// <summary>
/// 
/// </summary>
namespace Member.Microservices.Model
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public sealed class Member : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; private set; }
        public DateTime DOB { get; set; }

        public OccupationEnum Occupation { get; set; }

        public decimal SumInsured {get; set; }

        public Member()
        {

        }
    }
}