using System;
using System.Collections.Generic;
using System.Text;

namespace NPT.Model.ResponseModel
{
    public class SearchResponseModel
    {
        public string LoggedinId { get; set; }
        public string EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Managername { get; set; }
        public bool IsCustomPronunciationAvailable { get; set; }
        public string CustomPronunciation { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsAdmin { get; set; }
        public bool? OverrideStandardPronunciation { get; set; }
        public string Comments { get; set; }
        public string Createdby { get; set; }

        public string lanid { get; set; }
    }
}
