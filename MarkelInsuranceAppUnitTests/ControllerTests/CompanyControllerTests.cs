namespace MarkelInsuranceAppUnitTests.ControllerTests.CompanyControllerTests
{
    using MarkelInsuranceApp.CommonData;
    using MarkelInsuranceApp.Controllers;
    using MarkelInsuranceApp.Interfaces.Service;
    using MarkelInsuranceApp.Models.Response.Common;
    using MarkelInsuranceApp.Models.Response.Company;
    using MarkelInsuranceApp.Models.Response.Mapped;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using System;

    public class CompanyControllerTests
    {
        private Mock<ILogger<CompanyController>> LoggerMock;

        private Mock<ICompanyService> CompanyServiceMock;

        private CommonTestData testData;

        private CompanyController CompanyController;

        [SetUp]
        public void Setup()
        {
            this.LoggerMock = new Mock<ILogger<CompanyController>>();
            this.testData = new CommonTestData();
            this.CompanyServiceMock = new Mock<ICompanyService>();

            this.CompanyController = new CompanyController(this.LoggerMock.Object, this.CompanyServiceMock.Object);
        }

        [Test]
        public void WhenConstructorCalledWithNullLogger_ThenArgNullExceptionThrown()
        {
            Assert.Throws(
                Is.TypeOf<ArgumentNullException>().And.Property("ParamName").EqualTo("logger"), delegate
                {
                    this.CompanyController = new CompanyController
                    (
                        null,
                        this.CompanyServiceMock.Object
                    );
                });
        }

        [Test]
        public void WhenConstructorCalledWithNullService_ThenArgNullExceptionThrown()
        {
            Assert.Throws(
                Is.TypeOf<ArgumentNullException>().And.Property("ParamName").EqualTo("companyService"), delegate
                {
                    this.CompanyController = new CompanyController
                    (
                        this.LoggerMock.Object,
                        null
                    );
                });
        }

        [Test]
        public void WhenConstructorCalledWithValidArguements_ThenNoExceptionThrown()
        {
            Assert.DoesNotThrow(
                delegate
                {
                    this.CompanyController = new CompanyController
                    (
                        this.LoggerMock.Object,
                        this.CompanyServiceMock.Object
                    );
                });
        }

        [Test]
        public void WhenNoExceptionThrown_ThenControllerReturnsCompanyData()
        {
            CompanyResponse expected = new CompanyResponse
            {
                Company = new MappedCompany { CompanyId = 101},
                ResponseStatus = new ResponseStatus()
            };

            this.CompanyServiceMock.Setup(x => x.GetCompanyById(It.IsAny<int>())).ReturnsAsync(expected);

            ObjectResult actual = (ObjectResult)this.CompanyController.Get(It.IsAny<int>()).Result;

            Assert.IsInstanceOf<CompanyResponse>(actual.Value);
            Assert.AreEqual(200, actual.StatusCode);
            Assert.AreEqual(0, ((CompanyResponse)actual.Value).ResponseStatus.Code);
            Assert.AreEqual("Success", ((CompanyResponse)actual.Value).ResponseStatus.Message);
        }

        [Test]
        public void WhenExceptionThrown_ThenControllerReturnsInternalServerError()
        {
            this.CompanyServiceMock.Setup(x => x.GetCompanyById(It.IsAny<int>())).Throws(new Exception());

            ObjectResult actual = (ObjectResult)this.CompanyController.Get(It.IsAny<int>()).Result;

            Assert.IsInstanceOf<CompanyResponse>(actual.Value);
            Assert.AreEqual(500, actual.StatusCode);
            Assert.AreEqual(500,((CompanyResponse)actual.Value).ResponseStatus.Code);
            Assert.AreEqual("Internal Server Error", ((CompanyResponse)actual.Value).ResponseStatus.Message);
        }
    }
}