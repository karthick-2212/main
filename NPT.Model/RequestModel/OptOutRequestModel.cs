using System;
using System.Collections.Generic;
using System.Text;

namespace NPT.Model.RequestModel
{
    public class OptOutRequestModel
    {
        public bool IsoptedOut { get; set; }

        public string EmployeeId { get; set; }

        public string LoggedInUserId { get; set; }
    }
}
