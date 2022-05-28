using Xunit;
using Moq;
using NPT.Model.ResponseModel;

namespace NPTWebApi.Tests.ResponseModel
{
    public class CustomPronunciationResponseModelTests
    {
        private MockRepository mockRepository;

        public CustomPronunciationResponseModelTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private CustomPronunciationResponseModel CreateCustomPronunciationResponseModel()
        {
            return new CustomPronunciationResponseModel();
        }

        [Fact]
        public void CheckTypeforModel_Success()
        {
            //Arrange
            var customPronunciationresponse = this.CreateCustomPronunciationResponseModel();

            //Act
            customPronunciationresponse.Success = true;

            //Assert
            Assert.IsType<bool>(customPronunciationresponse.Success);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforModel_Custompronunciation()
        {
            //Arrange
            var customPronunciationresponse = this.CreateCustomPronunciationResponseModel();

            //Act
            customPronunciationresponse.Custompronunciation = "ADBERERERER";

            //Assert
            Assert.IsType<string>(customPronunciationresponse.Custompronunciation);
            this.mockRepository.Verify();

        }
    }
}
