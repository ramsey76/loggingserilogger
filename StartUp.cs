using logging;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.ApplicationInsights.Sinks.ApplicationInsights.TelemetryConverters;

[assembly: FunctionsStartup(typeof(StartUp))]
namespace logging
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services.AddLogging();
            
            TelemetryConfiguration telemetryConfiguration = TelemetryConfiguration.CreateDefault();
            telemetryConfiguration.InstrumentationKey = "d8f91236-0aaa-422f-a4c5-519136382f24";

                //configuration["AppInsights_InstrumentationKey"];
            
            var logger = new LoggerConfiguration().WriteTo.ApplicationInsights(telemetryConfiguration, new TraceTelemetryConverter())
                .CreateLogger();
            builder.Services.AddLogging(lb => lb.AddSerilog(logger));

            builder.Services.AddScoped<ITimerHandler, TimerHandler>();
        }
    }
}