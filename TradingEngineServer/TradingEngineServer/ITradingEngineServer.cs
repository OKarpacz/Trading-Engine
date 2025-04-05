namespace TradingEngineServer;

public interface ITradingEngineServer
{
    Task Run(CancellationToken token);
}