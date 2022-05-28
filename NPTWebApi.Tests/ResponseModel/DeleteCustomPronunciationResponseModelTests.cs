using Xunit;
using Moq;
using NPT.Model.ResponseModel;

namespace NPTWebApi.Tests.ResponseModel
{
    public class DeleteCustomPronunciationResponseModelTests
    {
        private MockRepository mockRepository;

        public DeleteCustomPronunciationResponseModelTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private DeleteCustomPronunciationResponseModel CreateDeleteCustomPronunciationResponseModelTests()
        {
            return new DeleteCustomPronunciationResponseModel();
        }

        [Fact]
        public void CheckTypeforResponseModel_Success()
        {
            //Arrange
            var deletecustompronunciationResponse = this.CreateDeleteCustomPronunciationResponseModelTests();

            //Act
            deletecustompronunciationResponse.Success = true;

            //Assert
            Assert.IsType<bool>(deletecustompronunciationResponse.Success);
            this.mockRepository.Verify();

        }

    }
}
