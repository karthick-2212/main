using System;
using System.Collections.Generic;
using System.Text;

namespace NPT.Model.RequestModel
{
    public class DeleteCustomPronunciationRequestModel
    {
        public string DeletingRecordEmployeeId { get; set; }

        public string LoggedinUserId { get; set; }
    }
}
