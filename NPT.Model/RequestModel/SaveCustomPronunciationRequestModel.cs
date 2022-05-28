using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NPT.Model.RequestModel
{
    public class SaveCustomPronunciationRequestModel
    {
        public string LoggedinId { get; set; }
        public string EmployeeId { get; set; }
        public  string CustomPronunciationVoiceAsBase64 { get; set; }
        public bool OverrideStandardPronunciation { get; set; }
        public bool Isupdate { get; set; }
        public string Comments { get; set; }
    }
}
