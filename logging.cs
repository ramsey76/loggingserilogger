using System;
using logging;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace logging
{
    public class Logging
    {
        private ITimerHandler timerHandler;
        
        public Logging(ITimerHandler timerHandler)
        {
            this.timerHandler = timerHandler;
        }
        
        [FunctionName("logging")]
        public void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            this.timerHandler.Handle();
        }
    }
}
