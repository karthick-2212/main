using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using NPT.Model.RequestModel;
using NPT.Model.ResponseModel;
using NPT.DataAccess.Interfaces;
using Npgsql;
using System.Data;
using NPT.DataAccess.Constants;

namespace NPT.DataAccess.Repository
{
    public class PronunciationRepository : IPronunciationRepository
    {
        public async Task<UserPronunciationDetailsResponseModel> GetUserPronunciationDetails(UserPronunciationDetailsRequestModel request, string strConnString)
        {

            UserPronunciationDetailsResponseModel response = new UserPronunciationDetailsResponseModel();
            NpgsqlConnection conn = new NpgsqlConnection(strConnString);
            DataSet actualData = new DataSet();

            try
            {
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = RepoConstants.GetEmployeeDetailsByEmailID + "('" + request.loggedinId + "');";

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
                bool? nullvalue = null;
                response.OptOutPronunciationService = (!(actualData.Tables[0].Rows[0]["optoutfrompronunciation"] is DBNull)) ? (Boolean)actualData.Tables[0].Rows[0]["optoutfrompronunciation"] : nullvalue;
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

        public async Task<SaveCustomPronunciationResponseModel> SaveCustomPronunciation(SaveCustomPronunciationRequestModel request, string strConnString)
        {
            SaveCustomPronunciationResponseModel response = new SaveCustomPronunciationResponseModel();

            //Convert 64 Base data to Byte array
            var content = request.CustomPronunciationVoiceAsBase64.Split(',').ToList<string>();

            //insert into DB
            NpgsqlConnection conn = new NpgsqlConnection(strConnString);
            try
            {
                string transType = string.Empty;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                if (request.Isupdate == false)
                {
                    transType = "INSERT";
                }
                else
                {
                    transType = "UPDATE";
                }
                if (request.OptOutPronunciationService == null)
                    request.OptOutPronunciationService = false;
                comm.CommandText = RepoConstants.SaveCustomPronunciation + "('" + request.EmployeeId + "','" + content[1] + "', 'false', '" + request.OverrideStandardPronunciation + "','" + request.OptOutPronunciationService + "','" + transType + "', '" + request.EmployeeId + "','" + request.Comments + "' )";
                comm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            response.Success = true;
            return response;
        }

        public async Task<CustomPronunciationResponseModel> GetPronunciation(GetPronunciationRequestmodel request, string strConnString)
        {
            CustomPronunciationResponseModel response = new CustomPronunciationResponseModel();
            NpgsqlConnection conn = new NpgsqlConnection(strConnString);
            DataSet actualData = new DataSet();
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = RepoConstants.GetCustomPronunciationByEmplid + "('" + request.EmployeeId + "');";


                NpgsqlDataAdapter nda = new NpgsqlDataAdapter(comm);
                nda.Fill(actualData);

                var buffers = (byte[])actualData.Tables[0].Rows[0]["pronunciation"];
                response.Custompronunciation = Encoding.UTF8.GetString(buffers);
                response.Success = true;

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

        public async Task<DeleteCustomPronunciationResponseModel> DeleteCustomPronunciation(DeleteCustomPronunciationRequestModel request, string strConnString)
        {
            DeleteCustomPronunciationResponseModel response = new DeleteCustomPronunciationResponseModel();
            NpgsqlConnection conn = new NpgsqlConnection(strConnString);
            try
            {
                string transType = string.Empty;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;

                comm.CommandText = RepoConstants.SaveCustomPronunciation + "('" + request.DeletingRecordEmployeeId + "','','false','false','false','DELETE','','')";
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            response.Success = true;
            return response;
        }


        public async Task<OptOutResponseModel> OptOutfromPronunciationservice(OptOutRequestModel request, string strConnString)
        {
            OptOutResponseModel response = new OptOutResponseModel();
            //DB CALL

            NpgsqlConnection conn = new NpgsqlConnection(strConnString);
            try
            {
                string transType = string.Empty;
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                //comm.CommandText = RepoConstants.SaveCustomPronunciation + "('" + request.EmployeeId + "','','false','false','" + request.IsoptedOut + "','INSERT','','')";
                comm.CommandText = RepoConstants.SaveOutPutCustomPronunciation + "('" + request.EmployeeId + "','" + request.IsoptedOut + "')";
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            response.Success = true;
            return response;
        }
    }
}
