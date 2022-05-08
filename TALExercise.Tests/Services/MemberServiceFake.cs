
namespace TALExercise.Tests.Services
{
    //using Member.Microservices.Models;
    using Member.Microservices.Service;
    using System;
    using System.Collections.Generic;

    public sealed class MemberServiceFake : IMembersService
    {
        private readonly List<Member.Microservices.ModelsEF.Member> _memberList;

        public MemberServiceFake()
        {
            this._memberList = new List<Member.Microservices.ModelsEF.Member>()
            {
                new Member.Microservices.ModelsEF.Member() { Id = 123,
                    Name = "John CITIZEN", Dob = new DateTime(1980, 01, 26) }
            };
        }
        public IEnumerable<Member.Microservices.ModelsEF.Member> GetAll()
        {
            return this._memberList;
        }
    }
}