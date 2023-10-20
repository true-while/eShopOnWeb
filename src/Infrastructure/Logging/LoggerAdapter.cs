using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Abstractions;

namespace Microsoft.eShopWeb.Infrastructure.Logging;

public class LoggerAdapter<T> : IAppLogger<T>
{
    static TelemetryClient telemetryClient = new TelemetryClient() { InstrumentationKey = "d9657adf-ffae-48cb-8f08-e676f16905ea" };

    private readonly ILogger<T> _logger;
    public LoggerAdapter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<T>();
    }

    public void LogWarning(string message, params object[] args)
    {
        _logger.LogWarning(message, args);
        telemetryClient.TrackEvent("Warning", new Dictionary<string,string>(){{ "msg", message} });
    }

    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
        telemetryClient.TrackTrace( message );
    }
}
