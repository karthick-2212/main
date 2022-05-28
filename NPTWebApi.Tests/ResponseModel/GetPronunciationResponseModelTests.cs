using Xunit;
using Moq;
using NPT.Model.ResponseModel;

namespace NPTWebApi.Tests.ResponseModel
{
    public class GetPronunciationResponseModelTests
    {
        private MockRepository mockRepository;

        public GetPronunciationResponseModelTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private GetPronunciationResponseModel CreateGetPronunciationResponseModelTests()
        {
            return new GetPronunciationResponseModel();
        }

        [Fact]
        public void CheckTypeforResponseModel_Success()
        {
            //Arrange
            var getpronunciationresponsemodel = this.CreateGetPronunciationResponseModelTests();

            //Act
            getpronunciationresponsemodel.Success = true;

            //Assert
            Assert.IsType<bool>(getpronunciationresponsemodel.Success);
            this.mockRepository.Verify();

        }
    }
}
