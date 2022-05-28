using System;
using System.Collections.Generic;
using System.Text;

namespace NPT.Model.RequestModel
{
    public class GetPronunciationRequestmodel
    {
        public string LoggedinUserId { get; set; }

        public string EmployeeId { get; set; }

        public string FullName { get; set; }

        public string Country { get; set; }

        public string VoiceSpeed { get; set; }

        public bool IsCustomPronunciationAvailable { get; set; }

        public bool IsOverrideStandardPronunciation { get; set; }

    }
}
