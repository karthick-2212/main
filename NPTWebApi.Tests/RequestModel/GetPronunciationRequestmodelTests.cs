using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using NPT.Model.RequestModel;

namespace NPTWebApi.Tests.RequestModel
{
    public class GetPronunciationRequestmodelTests
    {

        private MockRepository mockRepository;

        public GetPronunciationRequestmodelTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private GetPronunciationRequestmodel CreateGetPronunciationRequestmodel()
        {
            return new GetPronunciationRequestmodel();
        }

        [Fact]
        public void CheckTypeforModel_LoggedinUserId()
        {
            //Arrange
            var customPronunciationRequest = this.CreateGetPronunciationRequestmodel();

            //Act
            customPronunciationRequest.LoggedinUserId = "test@user.com";

            //Assert
            Assert.IsType<string>(customPronunciationRequest.LoggedinUserId);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforModel_FullName()
        {
            //Arrange
            var customPronunciationRequest = this.CreateGetPronunciationRequestmodel();

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
            var customPronunciationRequest = this.CreateGetPronunciationRequestmodel();

            //Act

            customPronunciationRequest.Country = "IND";
            //Assert
            Assert.IsType<string>(customPronunciationRequest.Country);
            this.mockRepository.Verify();


        }

        [Fact]
        public void CheckTypeforModel_VoiceSpeedd()
        {
            //Arrange
            var customPronunciationRequest = this.CreateGetPronunciationRequestmodel();

            //Act
            customPronunciationRequest.VoiceSpeed = "Slow";

            //Assert
            Assert.IsType<string>(customPronunciationRequest.VoiceSpeed);
            this.mockRepository.Verify();


        }
        [Fact]
        public void CheckTypeforModel_IsOverrideStandardPronunciation()
        {
            //Arrange
            var customPronunciationRequest = this.CreateGetPronunciationRequestmodel();

            //Act
            customPronunciationRequest.IsOverrideStandardPronunciation = true;

            //Assert
            Assert.IsType<bool>(customPronunciationRequest.IsOverrideStandardPronunciation);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforModel_IsCustomPronunciationAvailable()
        {
            //Arrange
            var customPronunciationRequest = this.CreateGetPronunciationRequestmodel();

            //Act
            customPronunciationRequest.IsCustomPronunciationAvailable = true;

            //Assert
            Assert.IsType<bool>(customPronunciationRequest.IsCustomPronunciationAvailable);
            this.mockRepository.Verify();

        }
       

    }
}
