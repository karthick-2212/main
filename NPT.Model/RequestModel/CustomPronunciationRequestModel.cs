using System;
using System.Collections.Generic;
using System.Text;

namespace NPT.Model.RequestModel
{
    public class CustomPronunciationRequestModel
    {
        public string EmployeeID { get; set; }

        public string FullName { get; set; }

        public string Country { get; set; }

        public string Voicespeed { get; set; }
    }
}
