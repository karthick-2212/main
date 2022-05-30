using System;
using System.Collections.Generic;
using System.Text;
using NPT.DataAccess.Interfaces;
using System.Threading.Tasks;
using NPT.Model.RequestModel;
using NPT.Model.ResponseModel;
using Npgsql;
using System.Data;
using NPT.DataAccess.Constants;

namespace NPT.DataAccess.Repository
{
    public class RoleRepository: IRoleRepositry
    {

        public async Task<RoleResponseModel> GetUserRoles(RoleRequestModel request, string strConnString)
        {

            RoleResponseModel response = new RoleResponseModel();
            NpgsqlConnection conn = new NpgsqlConnection(strConnString);
            DataSet actualData = new DataSet();

            try
            {
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = RepoConstants.GetRolesByEmpID + "('" + request.loggedinId + "');";

                NpgsqlDataAdapter nda = new NpgsqlDataAdapter(comm);
                nda.Fill(actualData);
             
                response.IsAdmin = (Boolean)actualData.Tables[0].Rows[0]["isadmin"];
               
                comm.Dispose();

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
