using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NPT.Model.RequestModel;
using NPT.Model.ResponseModel;

namespace NPT.DataAccess.Interfaces
{
    public interface IRoleRepositry
    {
        Task<RoleResponseModel> GetUserRoles(RoleRequestModel request, string conn);
    }
}
