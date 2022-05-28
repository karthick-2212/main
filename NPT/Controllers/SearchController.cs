using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NPT.DataAccess.Repository;
using NPT.Model.RequestModel;
using Microsoft.Extensions.Configuration;
namespace NPT.Controllers
{

    public class SearchController : ControllerBase
    {
        SearchRepository repo = new SearchRepository();

        private IConfiguration Configuration;

        public SearchController(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }

        [Route("api/search/SearchPronunciationDetails/v1")]
        [HttpPost]
        public async Task<ActionResult> SearchPronunciationDetails([FromBody] SearchRequestModel request)
        {
            try
            {
                string Conn = Configuration.GetConnectionString("NPTContextConnection");
                return Ok(await repo.SearchPronunciationDetails(request, Conn));
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
