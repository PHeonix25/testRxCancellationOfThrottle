using System;

using NLog;

namespace testRxCancellationOfThrottle.Services
{
    internal class UploadService : IUploadService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly IDraftPersistencyService _persistencyService;

        public UploadService(IDraftPersistencyService persistencyService)
        {
            _persistencyService = persistencyService;
        }

        public void UploadFile()
        {
            _logger.Info("uploading file, first saving the draft");
            _persistencyService.Store();
        }
    }
}