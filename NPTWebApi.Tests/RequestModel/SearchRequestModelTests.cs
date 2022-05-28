using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using NPT.Model.RequestModel;

namespace NPTWebApi.Tests.RequestModel
{
    public class SearchRequestModelTests
    {
        private MockRepository mockRepository;

        public SearchRequestModelTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private SearchRequestModel CreateSearchRequestModel()
        {
            return new SearchRequestModel();
        }

        [Fact]
        public void CheckTypeforModel_Searchtxt()
        {
            //Arrange
            var customPronunciationRequest = this.CreateSearchRequestModel();

            //Act
            customPronunciationRequest.Searchtxt = "123456";

            //Assert
            Assert.IsType<string>(customPronunciationRequest.Searchtxt);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforModel_LanId()
        {
            //Arrange
            var customPronunciationRequest = this.CreateSearchRequestModel();

            //Act
            customPronunciationRequest.LanId = "LanId";

            //Assert
            Assert.IsType<string>(customPronunciationRequest.LanId);
            this.mockRepository.Verify();

        }
    }
}
