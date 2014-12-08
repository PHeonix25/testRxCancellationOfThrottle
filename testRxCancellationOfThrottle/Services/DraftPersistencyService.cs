using NLog;

namespace testRxCancellationOfThrottle.Services
{
    internal class DraftPersistencyService : IDraftPersistencyService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void Store()
        {
            _logger.Info("storing draft");
        }
    }
}