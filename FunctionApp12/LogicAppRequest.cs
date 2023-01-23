using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp12
{
    public class LogicAppRequest
    {
        public string activityExecutionId { get; set; }
        public string activityName { get; set; }
        public string activityStatus { get; set; }
        public string callerId { get; set; }
        public string correlationId { get; set; }
        public string failedActivity { get; set; }
        public string processExecutionId { get; set; }
        public string processName { get; set; }
        public string status { get; set; }

    }
}
