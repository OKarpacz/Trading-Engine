namespace LoggingCS
{
    public record LogInformation(
        LogLevel LogLevel,
        string Module,
        string Message,
        DateTime Now,
        int ThreadId,
        string ThreadName
        );
}