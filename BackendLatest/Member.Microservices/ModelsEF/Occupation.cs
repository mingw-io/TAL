using System;
using System.Collections.Generic;

#nullable disable

namespace Member.Microservices.ModelsEF
{
    public partial class Occupation
    {
        public Occupation()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
