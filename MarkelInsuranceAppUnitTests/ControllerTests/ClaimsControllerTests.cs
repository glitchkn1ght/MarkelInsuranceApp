namespace MarkelInsuranceAppUnitTests.ControllerTests.ClaimsControllerTests
{
    using MarkelInsuranceApp.Controllers;
    using MarkelInsuranceApp.Interfaces.Service;
    using MarkelInsuranceApp.Interfaces.Validation;
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Response.Claim;
    using MarkelInsuranceApp.Models.Response.Common;
    using MarkelInsuranceApp.Models.Response.Mapped;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ClaimsControllerTests
    {
        private Mock<ILogger<ClaimsController>> LoggerMock;

        private Mock<IClaimsService> ClaimsServiceMock;

        private Mock<IInputValidator<string>> StringInputValidatorMock;

        private Mock<IInputValidator<InsuranceClaim>> ClaimsInputValidatorMock;

        private ClaimsController ClaimsController;

        [SetUp]
        public void Setup()
        {
            this.LoggerMock = new Mock<ILogger<ClaimsController>>();
            this.ClaimsServiceMock = new Mock<IClaimsService>();
            this.StringInputValidatorMock = new Mock<IInputValidator<string>>();
            this.ClaimsInputValidatorMock = new Mock<IInputValidator<InsuranceClaim>>();

            this.ClaimsController = new ClaimsController(   this.LoggerMock.Object, 
                                                            this.StringInputValidatorMock.Object,
                                                            this.ClaimsInputValidatorMock.Object,
                                                            this.ClaimsServiceMock.Object
                                                        );
        }

        //Constructor Tests

        [Test]
        public void WhenConstructorCalledWithNullLogger_ThenArgNullExceptionThrown()
        {
            Assert.Throws(
                Is.TypeOf<ArgumentNullException>().And.Property("ParamName").EqualTo("logger"), delegate
                {
                    this.ClaimsController = new ClaimsController
                    (
                        null,
                        this.StringInputValidatorMock.Object,
                        this.ClaimsInputValidatorMock.Object,
                        this.ClaimsServiceMock.Object
                    );
                });
        }

        [Test]
        public void WhenConstructorCalledWithNullStringInputValidator_ThenArgNullExceptionThrown()
        {
            Assert.Throws(
                Is.TypeOf<ArgumentNullException>().And.Property("ParamName").EqualTo("stringInputValidator"), delegate
                {
                    this.ClaimsController = new ClaimsController
                    (
                        this.LoggerMock.Object,
                        null,
                        this.ClaimsInputValidatorMock.Object,
                        this.ClaimsServiceMock.Object
                    );
                });
        }

        [Test]
        public void WhenConstructorCalledWithNullClaimsValidator_ThenArgNullExceptionThrown()
        {
            Assert.Throws(
                Is.TypeOf<ArgumentNullException>().And.Property("ParamName").EqualTo("claimsInputValidator"), delegate
                {
                    this.ClaimsController = new ClaimsController
                    (
                        this.LoggerMock.Object,
                        this.StringInputValidatorMock.Object,
                        null,
                        this.ClaimsServiceMock.Object
                    );
                });
        }

        [Test]
        public void WhenConstructorCalledWithNullService_ThenArgNullExceptionThrown()
        {
            Assert.Throws(
                Is.TypeOf<ArgumentNullException>().And.Property("ParamName").EqualTo("claimsService"), delegate
                {
                    this.ClaimsController = new ClaimsController
                    (
                        this.LoggerMock.Object,
                        this.StringInputValidatorMock.Object,
                        this.ClaimsInputValidatorMock.Object,
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
                    this.ClaimsController = new ClaimsController
                    (
                        this.LoggerMock.Object,
                        this.StringInputValidatorMock.Object,
                        this.ClaimsInputValidatorMock.Object,
                        this.ClaimsServiceMock.Object
                    );
                });
        }

        //SingleClaimGetTests

        [Test]
        public void WhenValidParams_ThenSingleGetReturnsSingleClaimData()
        {
            SingleClaimResponse expected = new SingleClaimResponse
            {
                Claim = new MappedClaim { CompanyId = 101},
                ResponseStatus = new ResponseStatus()
            };

            this.StringInputValidatorMock.Setup(x => x.ValidateInput(It.IsAny<string>())).Returns(true);

            this.ClaimsServiceMock.Setup(x => x.GetSingleClaimByUCR(It.IsAny<string>())).ReturnsAsync(expected);

            ObjectResult actual = (ObjectResult)this.ClaimsController.GetSingleClaimByUCR(It.IsAny<string>()).Result;

            Assert.IsInstanceOf<SingleClaimResponse>(actual.Value);
            Assert.AreEqual(200, actual.StatusCode);
            Assert.AreEqual(101, ((SingleClaimResponse)actual.Value).Claim.CompanyId);
            Assert.AreEqual(0, ((SingleClaimResponse)actual.Value).ResponseStatus.Code);
            Assert.AreEqual("Success", ((SingleClaimResponse)actual.Value).ResponseStatus.Message);
        }

        [Test]
        public void WhenValidationFails_ThenSingleGetReturnsBadRequestWithErrorDetails()
        {
            SingleClaimResponse expected = new SingleClaimResponse
            {
                Claim = new MappedClaim { CompanyId = 101 },
                ResponseStatus = new ResponseStatus()
            };

            this.StringInputValidatorMock.Setup(x => x.ValidateInput(It.IsAny<string>())).Returns(false);

            this.ClaimsServiceMock.Setup(x => x.GetSingleClaimByUCR(It.IsAny<string>())).ReturnsAsync(expected);

            ObjectResult actual = (ObjectResult)this.ClaimsController.GetSingleClaimByUCR(It.IsAny<string>()).Result;

            Assert.IsInstanceOf<SingleClaimResponse>(actual.Value);
            Assert.AreEqual(400, actual.StatusCode);
            Assert.AreEqual(-102, ((SingleClaimResponse)actual.Value).ResponseStatus.Code);
            Assert.AreEqual("Validation of Unique Claims Reference failed, please check input.", ((SingleClaimResponse)actual.Value).ResponseStatus.Message);
        }

        [Test]
        public void WhenExceptionThrown_ThenSingleGetReturnsInternalServerError()
        {
            this.StringInputValidatorMock.Setup(x => x.ValidateInput(It.IsAny<string>())).Returns(true);

            this.ClaimsServiceMock.Setup(x => x.GetSingleClaimByUCR(It.IsAny<string>())).Throws(new Exception());

            ObjectResult actual = (ObjectResult)this.ClaimsController.GetSingleClaimByUCR(It.IsAny<string>()).Result;

            Assert.IsInstanceOf<SingleClaimResponse>(actual.Value);
            Assert.AreEqual(500, actual.StatusCode);
            Assert.AreEqual(500,((SingleClaimResponse)actual.Value).ResponseStatus.Code);
            Assert.AreEqual("Internal Server Error", ((SingleClaimResponse)actual.Value).ResponseStatus.Message);
        }


        //MultiClaimGetTests

        [Test]
        public void WhenEverythingOkay_ThenMultiGetReturnsData()
        {
            MultiClaimResponse expected = new MultiClaimResponse
            {
                Claims = new List<MappedClaim> { new MappedClaim { CompanyId = 101 }, new MappedClaim { CompanyId = 101 } },
                ResponseStatus = new ResponseStatus()
            };

            this.ClaimsServiceMock.Setup(x => x.GetAllClaimsForCompany(It.IsAny<int>())).ReturnsAsync(expected);

            ObjectResult actual = (ObjectResult)this.ClaimsController.GetAllClaimsByCompany(101).Result;

            Assert.IsInstanceOf<MultiClaimResponse>(actual.Value);
            Assert.AreEqual(200, actual.StatusCode);
            Assert.AreEqual(101, expected.Claims[0].CompanyId);
            Assert.AreEqual(0, ((MultiClaimResponse)actual.Value).ResponseStatus.Code);
            Assert.AreEqual("Success", ((MultiClaimResponse)actual.Value).ResponseStatus.Message);
        }

        [Test]
        public void WhenValidationFails_ThenMultGetReturnsBadRequest()
        {
            ObjectResult actual = (ObjectResult)this.ClaimsController.GetAllClaimsByCompany(0).Result;

            Assert.IsInstanceOf<MultiClaimResponse>(actual.Value);
            Assert.AreEqual(400, actual.StatusCode);
            Assert.AreEqual(-101, ((MultiClaimResponse)actual.Value).ResponseStatus.Code);
            Assert.AreEqual("Validation of CompanyId failed, please check input.", ((MultiClaimResponse)actual.Value).ResponseStatus.Message);
        }

        [Test]
        public void WhenExceptionThrown_ThenMultiGetReturnsInternalServerError()
        {
            this.ClaimsServiceMock.Setup(x => x.GetAllClaimsForCompany(It.IsAny<int>())).Throws(new Exception());

            ObjectResult actual = (ObjectResult)this.ClaimsController.GetAllClaimsByCompany(101).Result;

            Assert.IsInstanceOf<MultiClaimResponse>(actual.Value);
            Assert.AreEqual(500, actual.StatusCode);
            Assert.AreEqual(500, ((MultiClaimResponse)actual.Value).ResponseStatus.Code);
            Assert.AreEqual("Internal Server Error", ((MultiClaimResponse)actual.Value).ResponseStatus.Message);
        }

        //UpdateSingleClaimTests

        [Test]
        public void WhenEverythingOkay_ThenUpdateSingleClaimSuccessful()
        {
            ClaimUpdateResponse expected = new ClaimUpdateResponse();

            this.ClaimsInputValidatorMock.Setup(x => x.ValidateInput(It.IsAny<InsuranceClaim>())).Returns(true);

            this.ClaimsServiceMock.Setup(x => x.UpdateClaim(It.IsAny<InsuranceClaim>())).ReturnsAsync(expected);

            ObjectResult actual = (ObjectResult)this.ClaimsController.Update(It.IsAny<InsuranceClaim>()).Result;

            Assert.IsInstanceOf<ClaimUpdateResponse>(actual.Value);
            Assert.AreEqual(200, actual.StatusCode);
            Assert.AreEqual(0, ((ClaimUpdateResponse)actual.Value).ResponseStatus.Code);
            Assert.AreEqual("Success", ((ClaimUpdateResponse)actual.Value).ResponseStatus.Message);
        }

        [Test]
        public void WhenValidationFails_ThenUpdateSingleClaimReturnBadRequest()
        {
            ClaimUpdateResponse expected = new ClaimUpdateResponse();

            this.ClaimsInputValidatorMock.Setup(x => x.ValidateInput(It.IsAny<InsuranceClaim>())).Returns(false);

            this.ClaimsServiceMock.Setup(x => x.UpdateClaim(It.IsAny<InsuranceClaim>())).ReturnsAsync(expected);

            ObjectResult actual = (ObjectResult)this.ClaimsController.Update(It.IsAny<InsuranceClaim>()).Result;

            Assert.IsInstanceOf<ClaimUpdateResponse>(actual.Value);
            Assert.AreEqual(400, actual.StatusCode);
            Assert.AreEqual(-103, ((ClaimUpdateResponse)actual.Value).ResponseStatus.Code);
            Assert.AreEqual("Validation of Insurance Claim failed, please check input.", ((ClaimUpdateResponse)actual.Value).ResponseStatus.Message);
        }

        [Test]
        public void WhenExceptionThrown_ThenUpdateSingleClaimReturnBadRequest()
        {
            ClaimUpdateResponse expected = new ClaimUpdateResponse();

            this.ClaimsInputValidatorMock.Setup(x => x.ValidateInput(It.IsAny<InsuranceClaim>())).Returns(true);

            this.ClaimsServiceMock.Setup(x => x.UpdateClaim(It.IsAny<InsuranceClaim>())).Throws(new Exception());

            ObjectResult actual = (ObjectResult)this.ClaimsController.Update(It.IsAny<InsuranceClaim>()).Result;

            Assert.IsInstanceOf<ClaimUpdateResponse>(actual.Value);
            Assert.AreEqual(500, actual.StatusCode);
            Assert.AreEqual(500, ((ClaimUpdateResponse)actual.Value).ResponseStatus.Code);
            Assert.AreEqual("Internal Server Error", ((ClaimUpdateResponse)actual.Value).ResponseStatus.Message);
        }
    }
}