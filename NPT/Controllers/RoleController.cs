using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NPT.DataAccess.Repository;
using NPT.Model.RequestModel;
using Microsoft.Extensions.Configuration;

namespace NPT.Controllers
{
    
    [ApiController]
    public class RoleController : ControllerBase
    {
        RoleRepository repo = new RoleRepository();

        private IConfiguration Configuration;

        public RoleController(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }

        [Route("api/role/GetUserRoles/v1")]
        [HttpPost]
        public async Task<ActionResult> GetUserRoles([FromBody] RoleRequestModel request)
        {
            try
            {
                string Conn = Configuration.GetConnectionString("NPTContextConnection");
                return Ok(await repo.GetUserRoles(request, Conn));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
