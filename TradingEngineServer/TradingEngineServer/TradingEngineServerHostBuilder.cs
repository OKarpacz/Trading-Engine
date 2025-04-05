using LoggingCS;
using LoggingCS.LoggingConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TradingEngineServer.TradingEngineServerConfig;

namespace TradingEngineServer
{

    public sealed class TradingEngineServerHostBuilder
    {
        
        public static IHost BuildTradingEngineServer()
            => Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddOptions();
                services.Configure<TradingEngineServerConfiguration>(hostContext.Configuration.GetSection(nameof(TradingEngineServerConfiguration)));
                services.Configure<LoggerConfiguration>(hostContext.Configuration.GetSection("LoggerConfiguration"));

                
                services.AddSingleton<ITradingEngineServer, TradingEngineServer>();
                services.AddSingleton<ITextLogger, TextLogger>();
                
                services.AddHostedService<TradingEngineServer>();
            }).Build();
        
        
    }
}