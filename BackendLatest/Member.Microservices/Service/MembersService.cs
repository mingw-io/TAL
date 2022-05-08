
namespace Member.Microservices.Service
{
    using Member.Microservices.ModelsEF;
    using System.Collections.Generic;

    public sealed class MembersService : IMembersService
    {
        private TALContext _context;

        public MembersService(TALContext context)
        {
            this._context = context;
        }

        public IEnumerable<Member> GetAll()
        {
            return this._context.Members;
        }
    }
}