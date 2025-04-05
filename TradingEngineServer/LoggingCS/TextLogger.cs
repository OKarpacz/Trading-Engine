using System.Threading.Tasks.Dataflow;
using LoggingCS.LoggingConfiguration;
using Microsoft.Extensions.Options;

namespace LoggingCS
{

    public class TextLogger : AbstractLogger, ITextLogger
    {
        
        //PRIVATE//
        private readonly LoggerConfiguration _loggingConfiguration;
        
        public TextLogger(IOptions<LoggerConfiguration> loggingConfiguration) : base()
        {
            _loggingConfiguration = loggingConfiguration?.Value 
                                    ?? throw new ArgumentNullException(nameof(loggingConfiguration), "LoggerConfiguration is null.");

            Console.WriteLine($"LoggerType: {_loggingConfiguration.LoggerType}");
            Console.WriteLine($"TextLoggerConfiguration is null? {_loggingConfiguration.TextLoggerConfiguration == null}");
            Console.WriteLine($"Directory: {_loggingConfiguration.TextLoggerConfiguration?.Directory}");
            Console.WriteLine($"FileName: {_loggingConfiguration.TextLoggerConfiguration?.FileName}");
            Console.WriteLine($"FileExtension: {_loggingConfiguration.TextLoggerConfiguration?.FileExtension}");

            if (_loggingConfiguration.TextLoggerConfiguration == null)
            {
                throw new ArgumentNullException(nameof(_loggingConfiguration.TextLoggerConfiguration),
                    "TextLoggerConfiguration is missing in configuration.");
            }

            if (string.IsNullOrWhiteSpace(_loggingConfiguration.TextLoggerConfiguration.Directory))
                throw new ArgumentException("Directory path is not set in the configuration.");

            var now = DateTime.Now;
            string logDirectory = Path.Combine(_loggingConfiguration.TextLoggerConfiguration.Directory, $"{now:yyyy-MM-dd}");
            string uniqueLogName = $"{_loggingConfiguration.TextLoggerConfiguration.FileName}--{now:HH-mm-ss}";
            string baseLogName = Path.ChangeExtension(uniqueLogName,_loggingConfiguration.TextLoggerConfiguration.FileExtension);
            string filepath = Path.Combine(logDirectory, baseLogName);

            Directory.CreateDirectory(logDirectory);
            _ = Task.Run(() => LogAsync(filepath, _logQueue, _tokenSource.Token));
        }
        
        private static async Task LogAsync(string filepath, BufferBlock<LogInformation> logQueue, CancellationToken token)
        {
            using var fs = new FileStream(filepath, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
            using var sw = new StreamWriter(fs);
            try
            {
                while (true)
                {
                    var logItem = await logQueue.ReceiveAsync(token).ConfigureAwait(false);
                    string formattedMessage = FormatLogItem(logItem);
                    await sw.WriteLineAsync(formattedMessage).ConfigureAwait(false);
                    await sw.FlushAsync().ConfigureAwait(false);
                }
            }
            catch(OperationCanceledException)
            {}
        }

        private static string FormatLogItem(LogInformation logItem)
        {
            return $"[{logItem.Now:yyyy-MM-dd HH:mm:ss.fff}] [{logItem.ThreadName,-30}]:{logItem.ThreadId:000}"
                   + $"[{logItem.LogLevel}] {logItem.Message}" ;
        }
        
        protected override void Log(LogLevel logLevel, string module, string message)
        {
            _logQueue.Post(new LogInformation(logLevel, module, message,
                DateTime.Now, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name));
        }

        ~TextLogger()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            lock (_lock)
            {
                if (_disposed)
                    return;
                _disposed = true;
            }

            if (disposing)
            {
                _tokenSource.Cancel();
                _tokenSource.Dispose();
            }
        }

        private readonly BufferBlock<LogInformation> _logQueue = new BufferBlock<LogInformation>();
        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private readonly object _lock = new object();
        private bool _disposed = false;
        
    }
}