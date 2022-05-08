
namespace Member.Microservices.Service
{
    using System.Collections.Generic;

    public interface IMembersService
    {
        IEnumerable<Member.Microservices.ModelsEF.Member> GetAll();
    }
}
