using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp12
{
    public class Function
    {
       

        public Function( )
        {
        }

        [Function("Function")]
        public void asyncsbcall([ServiceBusTrigger(topicName:"sampletopic", subscriptionName: "samplesub", Connection =  "sbCon")] string mySbMsg,FunctionContext cnt)
        {

            var _logger = cnt.GetLogger("Function");
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
