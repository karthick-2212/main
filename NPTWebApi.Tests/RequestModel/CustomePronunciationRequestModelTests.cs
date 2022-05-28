using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using NPT.Model.RequestModel;

namespace NPTWebApi.Tests
{
    public class CustomePronunciationRequestModelTests
    {
        private MockRepository mockRepository;

        public CustomePronunciationRequestModelTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private CustomPronunciationRequestModel CreateCustomPronunciationRequestModel()
        {
            return new CustomPronunciationRequestModel();
        }

        [Fact]
        public void CheckTypeforModel_EmployeeID()
        {
            //Arrange
            var customPronunciationRequest = this.CreateCustomPronunciationRequestModel();

            //Act
            customPronunciationRequest.EmployeeID = "123456";

            //Assert
            Assert.IsType<string>(customPronunciationRequest.EmployeeID);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforModel_FullName()
        {
            //Arrange
            var customPronunciationRequest = this.CreateCustomPronunciationRequestModel();

            //Act

            customPronunciationRequest.FullName = "Test Full Name";
            //Assert
            Assert.IsType<string>(customPronunciationRequest.FullName);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforModel_Country()
        {
            //Arrange
            var customPronunciationRequest = this.CreateCustomPronunciationRequestModel();

            //Act
            customPronunciationRequest.Country = "IND";

            //Assert
            Assert.IsType<string>(customPronunciationRequest.Country);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforModel_Voicespeed()
        {
            //Arrange
            var customPronunciationRequest = this.CreateCustomPronunciationRequestModel();

            //Act
            customPronunciationRequest.Voicespeed = "Slow";

            //Assert
            Assert.IsType<string>(customPronunciationRequest.Voicespeed);
            this.mockRepository.Verify();

        }
    }
}
