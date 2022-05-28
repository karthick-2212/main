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
    public class SearchRepository : ISearchRepository
    {
        public async Task<SearchResponseModel> SearchPronunciationDetails(SearchRequestModel request, string strConnString)
        {
            {
                SearchResponseModel response = new SearchResponseModel();

                NpgsqlConnection conn = new NpgsqlConnection(strConnString);

                DataSet actualData = new DataSet();

                try
                {
                    conn.Open();
                    NpgsqlCommand comm = new NpgsqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = RepoConstants.GetEmployeeDetailsByEmpID + "('" + request.Searchtxt + "');";

                    NpgsqlDataAdapter nda = new NpgsqlDataAdapter(comm);
                    nda.Fill(actualData);

                    response.LoggedinId = actualData.Tables[0].Rows[0]["email_id"].ToString();
                    response.EmployeeId = actualData.Tables[0].Rows[0]["emplid"].ToString();
                    response.Firstname = actualData.Tables[0].Rows[0]["first_name"].ToString();
                    response.Lastname = actualData.Tables[0].Rows[0]["last_name"].ToString();
                    response.Fullname = actualData.Tables[0].Rows[0]["full_name"].ToString();
                    response.Phone = actualData.Tables[0].Rows[0]["work_phone"].ToString();
                    response.EmailAddress = actualData.Tables[0].Rows[0]["email_id"].ToString();
                    response.Managername = actualData.Tables[0].Rows[0]["rep_to_mgr_name"].ToString();
                    response.IsAdmin = (Boolean)actualData.Tables[0].Rows[0]["isadmin"];
                    response.lanid = actualData.Tables[0].Rows[0]["elid"].ToString(); 
                    response.IsCustomPronunciationAvailable = (string.IsNullOrEmpty(Convert.ToString(actualData.Tables[0].Rows[0]["pronunciation"]))) ? false : true;
                    if (response.IsCustomPronunciationAvailable)
                    {
                        var buffers = (byte[])actualData.Tables[0].Rows[0]["pronunciation"];
                        response.CustomPronunciation = Encoding.UTF8.GetString(buffers);
                        response.OverrideStandardPronunciation = (Boolean)actualData.Tables[0].Rows[0]["overridestandardpronunciation"];
                        if (!(actualData.Tables[0].Rows[0]["updated_date"] is DBNull))
                            response.LastUpdatedDate = Convert.ToDateTime(actualData.Tables[0].Rows[0]["updated_date"]);
                        response.Createdby = actualData.Tables[0].Rows[0]["createdby"].ToString();
                        response.Comments = actualData.Tables[0].Rows[0]["comments"].ToString();
                    }
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
}
