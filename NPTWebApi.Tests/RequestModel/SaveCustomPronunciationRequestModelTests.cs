using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using NPT.Model.RequestModel;
namespace NPTWebApi.Tests.RequestModel
{
    public class SaveCustomPronunciationRequestModelTests
    {
        private MockRepository mockRepository;

        public SaveCustomPronunciationRequestModelTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private SaveCustomPronunciationRequestModel CreateSaveCustomPronunciationRequestModel()
        {
            return new SaveCustomPronunciationRequestModel();
        }

        [Fact]
        public void CheckTypeforModel_LoggedinUserId()
        {
            //Arrange
            var savecustomPronunciationRequest = this.CreateSaveCustomPronunciationRequestModel();

            //Act
            savecustomPronunciationRequest.LoggedinId = "test@user.com";

            //Assert
            Assert.IsType<string>(savecustomPronunciationRequest.LoggedinId);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforModel_EmployeeId()
        {
            //Arrange
            var savecustomPronunciationRequest = this.CreateSaveCustomPronunciationRequestModel();

            //Act
            savecustomPronunciationRequest.EmployeeId = "123456";

            //Assert
            Assert.IsType<string>(savecustomPronunciationRequest.EmployeeId);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforModel_CustomPronunciationVoiceAsBase64()
        {
            //Arrange
            var savecustomPronunciationRequest = this.CreateSaveCustomPronunciationRequestModel();

            //Act
            savecustomPronunciationRequest.CustomPronunciationVoiceAsBase64 = "ABDEEEFEERERER";
            //Assert
            Assert.IsType<string>(savecustomPronunciationRequest.CustomPronunciationVoiceAsBase64);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforModel_OverrideStandardPronunciation()
        {
            //Arrange
            var savecustomPronunciationRequest = this.CreateSaveCustomPronunciationRequestModel();

            //Act
            savecustomPronunciationRequest.OverrideStandardPronunciation = true;

            //Assert
            Assert.IsType<bool>(savecustomPronunciationRequest.OverrideStandardPronunciation);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforModel_Isupdate()
        {
            //Arrange
            var savecustomPronunciationRequest = this.CreateSaveCustomPronunciationRequestModel();

            //Act
            savecustomPronunciationRequest.Isupdate = true;

            //Assert
            Assert.IsType<bool>(savecustomPronunciationRequest.Isupdate);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforModel_Comments()
        {
            //Arrange
            var savecustomPronunciationRequest = this.CreateSaveCustomPronunciationRequestModel();

            //Act
            savecustomPronunciationRequest.Comments = "comments";
            //Assert
            Assert.IsType<string>(savecustomPronunciationRequest.Comments);
            this.mockRepository.Verify();

        }

    }
}
