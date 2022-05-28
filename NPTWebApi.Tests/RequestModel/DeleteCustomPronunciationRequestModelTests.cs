using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using NPT.Model.RequestModel;

namespace NPTWebApi.Tests.RequestModel
{
    public class DeleteCustomPronunciationRequestModelTests
    {
        private MockRepository mockRepository;

        public DeleteCustomPronunciationRequestModelTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private DeleteCustomPronunciationRequestModel CreateDeleteCustomPronunciationRequestModel()
        {
            return new DeleteCustomPronunciationRequestModel();
        }

        [Fact]
        public void CheckTypeforModel_DeletingRecordEmployeeId()
        {
            //Arrange
            var deleteCustomPronunciationRequest = this.CreateDeleteCustomPronunciationRequestModel();

            //Act
            deleteCustomPronunciationRequest.DeletingRecordEmployeeId = "123456";

            //Assert
            Assert.IsType<string>(deleteCustomPronunciationRequest.DeletingRecordEmployeeId);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforModel_LoggedinUserId()
        {
            //Arrange
            var deleteCustomPronunciationRequest = this.CreateDeleteCustomPronunciationRequestModel();

            //Act
            deleteCustomPronunciationRequest.LoggedinUserId = "123@gmail.com";

            //Assert
            Assert.IsType<string>(deleteCustomPronunciationRequest.LoggedinUserId);
            this.mockRepository.Verify();

        }
    }
}
