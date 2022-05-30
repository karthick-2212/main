using System;
using System.Collections.Generic;
using System.Text;

namespace NPT.DataAccess.Constants
{
    public static class RepoConstants
    {
        public const string GetEmployeeDetailsByEmpID = "SELECT * from \"Crypto\".GetEmployeeDetailsByEmpID";
        public const string GetEmployeeDetailsByEmailID = "SELECT * from \"Crypto\".getemployeedetailsbyemailid";
        public const string SaveCustomPronunciation = "CALL \"Crypto\".savecustompronunciation";
        public const string GetCustomPronunciationByEmplid = "SELECT * from \"Crypto\".getcustompronunciationbyemplid";
        public const string GetRolesByEmpID = "SELECT isadmin from \"Crypto\".getemployeedetailsbyemailid";
        public const string SaveOutPutCustomPronunciation = "CALL \"Crypto\".saveupdateoptoutpronunciation";
    }
}
