namespace Member.Microservices.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public interface IApplicationDbContext
    {
        DbSet<Model.Member> Members { get; set; }
        Task<int> SaveChanges();
    }
}