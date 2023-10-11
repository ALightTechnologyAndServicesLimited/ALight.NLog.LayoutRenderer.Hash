using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

// This code is direct "copy and paste" from NLog's console example

var logger = LogManager.GetCurrentClassLogger();
try
{
    var config = new ConfigurationBuilder()
         .SetBasePath(System.IO.Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
         .Build();

    using var servicesProvider = new ServiceCollection()
        .AddTransient<Runner>() // Runner is the custom class
        .AddLogging(loggingBuilder =>
        {
            // configure Logging with NLog
            loggingBuilder.ClearProviders();
            loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            loggingBuilder.AddNLog(config);
        }).BuildServiceProvider();

    logger.Properties.Add("secret", "secret");
    logger.Debug("Logger with secret");
    var runner = servicesProvider.GetRequiredService<Runner>();
    runner.DoAction("Action1");

    Console.WriteLine("Press ANY key to exit");
    Console.ReadKey();
}
catch (Exception ex)
{
    // NLog: catch any exception and log it.
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}