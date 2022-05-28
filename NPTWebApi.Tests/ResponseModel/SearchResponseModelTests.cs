using Xunit;
using Moq;
using NPT.Model.ResponseModel;
using System;

namespace NPTWebApi.Tests.ResponseModel
{
    public class SearchResponseModelTests
    {
        private MockRepository mockRepository;

        public SearchResponseModelTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private SearchResponseModel CreateSearchResponseModelTests()
        {
            return new SearchResponseModel();
        }

        [Fact]
        public void CheckTypeforResponseModel_LoggedinId()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.LoggedinId = "test@123.com";

            //Assert
            Assert.IsType<string>(searchresponsemodel.LoggedinId);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforResponseModel_EmployeeId()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.EmployeeId = "123456";

            //Assert
            Assert.IsType<string>(searchresponsemodel.EmployeeId);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforResponseModel_Firstname()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.Firstname = "Firstname";

            //Assert
            Assert.IsType<string>(searchresponsemodel.Firstname);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_Lastname()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.Lastname = "Lastname";

            //Assert
            Assert.IsType<string>(searchresponsemodel.Lastname);
            this.mockRepository.Verify();
        }

        [Fact]
        public void CheckTypeforResponseModel_Fullname()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.Fullname = "Fullname";

            //Assert
            Assert.IsType<string>(searchresponsemodel.Fullname);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_EmailAddress()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.EmailAddress = "test@test.com";

            //Assert
            Assert.IsType<string>(searchresponsemodel.EmailAddress);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_Phone()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.Phone = "9999999";

            //Assert
            Assert.IsType<string>(searchresponsemodel.Phone);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_Managername()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.Managername = "Managername";

            //Assert
            Assert.IsType<string>(searchresponsemodel.Managername);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_IsCustomPronunciationAvailable()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.IsCustomPronunciationAvailable = true;

            //Assert
            Assert.IsType<bool>(searchresponsemodel.IsCustomPronunciationAvailable);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_CustomPronunciation()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.OverrideStandardPronunciation = true;

            //Assert
            Assert.IsType<bool>(searchresponsemodel.OverrideStandardPronunciation);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_LastUpdatedDate()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.LastUpdatedDate = DateTime.Now;

            //Assert
            Assert.IsType<DateTime>(searchresponsemodel.LastUpdatedDate);
            this.mockRepository.Verify();

        }

        [Fact]
        public void CheckTypeforResponseModel_IsAdmin()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.IsAdmin = true;

            //Assert
            Assert.IsType<bool>(searchresponsemodel.IsAdmin);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_OverrideStandardPronunciation()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.OverrideStandardPronunciation = true;

            //Assert
            Assert.IsType<bool>(searchresponsemodel.OverrideStandardPronunciation);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_Createdby()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.Createdby = "Createdby";

            //Assert
            Assert.IsType<string>(searchresponsemodel.Createdby);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_lanid()
        {
            //Arrange
            var searchresponsemodel = this.CreateSearchResponseModelTests();

            //Act
            searchresponsemodel.lanid = "lanid";

            //Assert
            Assert.IsType<string>(searchresponsemodel.lanid);
            this.mockRepository.Verify();

        }
    }
}
