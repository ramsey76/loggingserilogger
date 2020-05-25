using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace logging
{
    public class TimerHandler : ITimerHandler
    {
        private ILogger<TimerHandler> logger;
        
        public TimerHandler(ILogger<TimerHandler> logger)
        {
            this.logger = logger;
        }

        public void Handle()
        {
            // var settings = new Dictionary<string, object> {{"PersonId", 5}, {"Date", DateTime.Now}};
            // using (logger.BeginScope(settings))
            
            var loggingContext = new LoggingContext();
            
            using(this.logger.BeginScope(loggingContext))
            {
                loggingContext.PushProperty("PersonId", 5);
                loggingContext.PushProperty("Date", DateTime.Now);

                this.logger.Log(LogLevel.Information, $"Handler called at {DateTime.Now}");
                this.logger.Log(LogLevel.Information, $"Second log line in Handler called at {DateTime.Now}");
            }
        }
    }
}