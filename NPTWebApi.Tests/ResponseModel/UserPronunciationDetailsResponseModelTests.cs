using Xunit;
using Moq;
using NPT.Model.ResponseModel;
using System;


namespace NPTWebApi.Tests.ResponseModel
{
    public class UserPronunciationDetailsResponseModelTests
    {
        private MockRepository mockRepository;

        public UserPronunciationDetailsResponseModelTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private UserPronunciationDetailsResponseModel CreateUserPronunciationDetailsResponseModelTests()
        {
            return new UserPronunciationDetailsResponseModel();
        }

        [Fact]
        public void CheckTypeforResponseModel_LoggedinId()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.LoggedinId = "test@123.com";

            //Assert
            Assert.IsType<string>(userPronunciationDetailsResponseModel.LoggedinId);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_EmployeeId()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.EmployeeId = "EmployeeId";

            //Assert
            Assert.IsType<string>(userPronunciationDetailsResponseModel.EmployeeId);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_Firstname()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.Firstname = "Firstname";

            //Assert
            Assert.IsType<string>(userPronunciationDetailsResponseModel.Firstname);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_Lastname()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.Lastname = "Lastname";

            //Assert
            Assert.IsType<string>(userPronunciationDetailsResponseModel.Lastname);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_Fullname()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.Fullname = "Fullname";

            //Assert
            Assert.IsType<string>(userPronunciationDetailsResponseModel.Fullname);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_EmailAddress()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.EmailAddress = "test@123.com";

            //Assert
            Assert.IsType<string>(userPronunciationDetailsResponseModel.EmailAddress);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_Phone()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.Phone = "9996767";

            //Assert
            Assert.IsType<string>(userPronunciationDetailsResponseModel.Phone);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_Managername()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.Managername = "Managername";

            //Assert
            Assert.IsType<string>(userPronunciationDetailsResponseModel.Managername);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_IsAdmin()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.IsAdmin = true;

            //Assert
            Assert.IsType<bool>(userPronunciationDetailsResponseModel.IsAdmin);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_IsCustomPronunciationAvailable()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.IsCustomPronunciationAvailable = false;

            //Assert
            Assert.IsType<bool>(userPronunciationDetailsResponseModel.IsCustomPronunciationAvailable);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_LastUpdatedDate()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.LastUpdatedDate = DateTime.Now;

            //Assert
            Assert.IsType<DateTime>(userPronunciationDetailsResponseModel.LastUpdatedDate);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_CustomPronunciation()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.CustomPronunciation = "AFAFERE";

            //Assert
            Assert.IsType<string>(userPronunciationDetailsResponseModel.CustomPronunciation);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_OverrideStandardPronunciation()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.OverrideStandardPronunciation = true;

            //Assert
            Assert.IsType<bool>(userPronunciationDetailsResponseModel.OverrideStandardPronunciation);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModelComments()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.Comments = "Comments";

            //Assert
            Assert.IsType<string>(userPronunciationDetailsResponseModel.Comments);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_Createdby()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.Createdby = "Createdby";

            //Assert
            Assert.IsType<string>(userPronunciationDetailsResponseModel.Createdby);
            this.mockRepository.Verify();

        }
        [Fact]
        public void CheckTypeforResponseModel_lanid()
        {
            //Arrange
            var userPronunciationDetailsResponseModel = this.CreateUserPronunciationDetailsResponseModelTests();

            //Act
            userPronunciationDetailsResponseModel.lanid = "lanid";

            //Assert
            Assert.IsType<string>(userPronunciationDetailsResponseModel.lanid);
            this.mockRepository.Verify();

        }
    }
}
