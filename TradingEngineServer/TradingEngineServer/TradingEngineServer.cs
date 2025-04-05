using LoggingCS;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using TradingEngineServer.TradingEngineServerConfig;

namespace TradingEngineServer
{

   sealed class TradingEngineServer : BackgroundService, ITradingEngineServer
    {
        private readonly ITextLogger _logger;
        private readonly TradingEngineServerConfiguration _tradingEngineServerConfig;
        
        public TradingEngineServer(ITextLogger textLogger,
            IOptions<TradingEngineServerConfiguration> engineConfiguration)
        
        {
            _logger = textLogger ?? throw  new ArgumentNullException(nameof(textLogger));
            _tradingEngineServerConfig = engineConfiguration.Value ?? throw  new ArgumentNullException(nameof(engineConfiguration));
        }

        public Task Run(CancellationToken token) => ExecuteAsync(token);
        
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.Information(nameof(TradingEngineServer), "Starting Trading Engine");
            while (!stoppingToken.IsCancellationRequested)
            {}
            _logger.Information(nameof(TradingEngineServer), "Stopping Trading Engine");
            return Task.CompletedTask;
        }
    }
}