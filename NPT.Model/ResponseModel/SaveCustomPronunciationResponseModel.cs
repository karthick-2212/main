using System;
using System.Collections.Generic;
using System.Text;

namespace NPT.Model.ResponseModel
{
    public class SaveCustomPronunciationResponseModel
    {
        public bool Success { get; set; }
        public byte[] CustomPronunciation { get; set; }
        public bool OverrideStandardPronunciation { get; set; }
        public string comments { get; set; }
    }
}
