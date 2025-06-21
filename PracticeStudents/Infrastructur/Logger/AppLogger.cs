using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System;

public static class AppLogger
{
    public static void InitLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console()  // Логи в консоль
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // Логи в файл с ротацией
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
            {
                AutoRegisterTemplate = true,
                IndexFormat = "myapp-logs-{0:yyyy.MM.dd}",  // Индекс с датой
                ModifyConnectionSettings = conn => conn.BasicAuthentication("username", "password")
            })
            .CreateLogger();
    }

    public static void Info(string message, params object[] args)
    {
        Log.Information(message, args);
    }

    public static void Debug(string message, params object[] args)
    {
        Log.Debug(message, args);
    }

    public static void Warning(string message, params object[] args)
    {
        Log.Warning(message, args);
    }

    public static void Error(string message, params object[] args)
    {
        Log.Error(message, args);
    }

    public static void Fatal(string message, params object[] args)
    {
        Log.Fatal(message, args);
    }

    public static void Error(Exception ex, string message, params object[] args)
    {
        Log.Error(ex, message, args);
    }

    public static void CloseAndFlush()
    {
        Log.CloseAndFlush();
    }
}
