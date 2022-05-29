using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using NPT.DataAccess.Repository;
using NPT.Model.RequestModel;
using NPT.Model.ResponseModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NPTWebApi.Tests.Repository
{
    public class SearchRepositoryTests
    {
        private MockRepository mockRepository;
        private string connectionstring;
        public SearchRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            IConfiguration config = builder.Build();
            connectionstring = config.GetValue<string>("ConnectionStrings:NPTContextConnection");
        }

        private SearchRepository CreateSearchRepository()
        {
            return new SearchRepository();
        }

        [Fact]
        public async void SearchPronunciationDetails()
        {

            //Arrange
            var searchrepo = this.CreateSearchRepository();

            SearchRequestModel request = new SearchRequestModel();
            SearchResponseModel response = new SearchResponseModel();
            request.Searchtxt = "2022003";

            ////Act
            response = await searchrepo.SearchPronunciationDetails(request, connectionstring);
            //Assert
            Assert.NotNull(response.lanid);
            Assert.NotNull(response.Firstname);
            Assert.NotNull(response.Lastname);
            Assert.NotNull(response.Fullname);
            Assert.NotNull(response.LoggedinId);
            Assert.NotNull(response.Managername);
            Assert.NotNull(response.Phone);

            //Assert
            this.mockRepository.Verify();

        }
    }
}
