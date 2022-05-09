namespace TALExercise.Tests
{
    using Member.Microservices.Controllers;
    using Member.Microservices.Service;
    using Microsoft.AspNetCore.Mvc;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using TALExercise.Tests.Services;
    using Xunit;

    public class MemberControllerTest : IDisposable
    {
        const string WEB_DRIVER_PATH = "D:\\chromedriver_win32";

        const string UI_LOGIN_URL = "http://localhost:4200/login";

        private readonly IWebDriver _driver;

        MemberController _controller;
        IMembersService _service;

        // NOTE: equivalent to [SetUp] attribute
        public MemberControllerTest()
        {
            //Find folder with Chrome Driver (chromedriver.exe)
            var browserDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //Set Chrome to start with maximized window
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            // Local Selenium WebDriver
            _driver = new ChromeDriver(WEB_DRIVER_PATH, options);
            _driver.Manage().Window.Maximize();

            _service = new MemberServiceFake();

            _controller = new MemberController(_service);
        }

        [Fact(DisplayName = "Selenium::UI::Angular Test:: Login Page")]
        public void CanReachLoginPage()
        {
            _driver.Navigate().GoToUrl(UI_LOGIN_URL);

            // 1 minute timer here (1 min too much?)
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 1, 0));

            // Wait until I can find 'username' input box on the screen
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("username")));

            Assert.Equal("TasksApp", _driver.Title);
            Assert.Contains("Member Premiums App - (c) TAL 2022", _driver.PageSource);

            var userNameInputBox = _driver.FindElement(By.Name("username"));

            Assert.NotNull(userNameInputBox);

            //clear search box just in case anything is already typed in
            userNameInputBox.Clear();
            //Type "Selenium HQ" into the search box
            userNameInputBox.SendKeys("sergio");

            var userPasswordBox = _driver.FindElement(By.Name("password"));

            Assert.NotNull(userPasswordBox);

            //clear search box just in case anything is already typed in
            userPasswordBox.Clear();
            //Type "Selenium HQ" into the search box
            userPasswordBox.SendKeys("pass@123");


            var loginBtn = _driver.FindElement(By.ClassName("btn-primary"));
            Assert.NotNull(loginBtn);

            loginBtn.Click();

            // Wait for next page after the login page
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("dca")));
        }

        // NOTE: Equivalent to [TearDown] attribute
        public void Dispose()
        {
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();
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