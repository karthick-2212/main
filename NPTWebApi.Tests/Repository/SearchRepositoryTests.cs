using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using NPT.DataAccess.Repository;
using NPT.Model.RequestModel;
using NPT.Model.ResponseModel;
using System.Threading.Tasks;

namespace NPTWebApi.Tests.Repository
{
    public class SearchRepositoryTests
    {
        private MockRepository mockRepository;

        public SearchRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private SearchRepository CreateSearchRepository()
        {
            return new SearchRepository();
        }

        [Fact]
        public void CheckTypeforModel_EmployeeID()
        {
            //Arrange
            var searchrepo = this.CreateSearchRepository();
            string strConnectionString = "test";
            
            SearchRequestModel request = new SearchRequestModel();
            SearchResponseModel response = new SearchResponseModel();
            request.Searchtxt = "2022001";
            request.LanId = "2022001";
            
            ////Act
            //response = searchrepo.SearchPronunciationDetails(request, Conn);
            ////Assert
            //Assert.NotNull(response.lanid);
            //Assert.NotNull(response.Firstname);
            //Assert.NotNull(response.Lastname);
            //Assert.NotNull(response.Fullname);
            //Assert.NotNull(response.Comments);
            //Assert.NotNull(response.Createdby);
            //Assert.NotNull(response.Managername);
            //Assert.NotNull(response.Comments);

            //Assert
            // Assert.IsType<string>(customPronunciationRequest.EmployeeID);
            this.mockRepository.Verify();

        }
    }
}
