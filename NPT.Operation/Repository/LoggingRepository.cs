using System;
using System.Collections.Generic;
using System.Text;
using NPT.DataAccess.Interfaces;
using System.Threading.Tasks;
using NPT.Model.RequestModel;
using NPT.Model.Logging;
using Npgsql;
using System.Data;
using NPT.DataAccess.Constants;

namespace NPT.DataAccess.Repository
{
    public class LoggingRepository
    {

        public static async void Log(string methodName, string request, string response, string logType, string errorCode, string errorMessage, string conn)
        {
            LogInfo log = new LogInfo();

            log.MethodName = methodName;
            log.Request = request;
            log.Response = response;
            log.LogType = logType;
            log.ErrorCode = errorCode;
            log.ErrorMessage = errorMessage;
            await SaveLog(log, conn);
        }

        private static async Task SaveLog(LogInfo request, string strConnString)
        {

            NpgsqlConnection conn = new NpgsqlConnection(strConnString);
            try
            {
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = RepoConstants.SaveLog + "('" + request.MethodName + "','" + request.Request + "','" + request.Response + "','" + request.ErrorCode + "','" + request.ErrorMessage.Replace("'","") + "','" + request.LogType + "');";
                comm.ExecuteNonQuery();
                comm.Dispose();

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