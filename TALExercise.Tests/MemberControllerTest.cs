namespace TALExercise.Tests
{
    using Member.Microservices.Controllers;
    using Member.Microservices.Service;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using TALExercise.Tests.Services;
    using Xunit;

    public class MemberControllerTest
    {
        MemberController _controller;
        IMembersService _service;

        public MemberControllerTest()
        {
            _service = new MemberServiceFake();

            _controller = new MemberController(_service);
        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            //Act
            var result = _controller.GetAll();
            //Assert
            // Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<OkObjectResult>(result);

            // var list = result.Result as OkObjectResult;
            var list = result as OkObjectResult;

            Assert.IsType<List<Member.Microservices.ModelsEF.Member>>(list.Value);



            var listMembers = list.Value as List<Member.Microservices.ModelsEF.Member>;

            Assert.Equal(1, listMembers.Count);
        }
    }
}