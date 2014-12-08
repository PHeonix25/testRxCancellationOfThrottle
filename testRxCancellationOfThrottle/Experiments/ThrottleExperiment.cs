using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

using NLog;

using testRxCancellationOfThrottle.Services;

namespace testRxCancellationOfThrottle.Experiments
{
    internal class ThrottleExperiment : IExperiment
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly IDraftPersistencyService _persistencyService;
        private readonly IUploadService _uploadService;

        public ThrottleExperiment(IDraftPersistencyService persistencyService, IUploadService uploadService)
        {
            _persistencyService = persistencyService;
            _uploadService = uploadService;
        }

        public void Run()
        {
            var draftChangesStream = new Subject<string>();
            var uploadChangesStream = new Subject<string>();

            SetupStreamHandlers(draftChangesStream, uploadChangesStream);
            DoExperiment(draftChangesStream, uploadChangesStream);
        }

        private void SetupStreamHandlers(IObservable<string> draftChangesStream, IObservable<string> uploadChangesStream)
        {
            draftChangesStream.Subscribe(_logger.Info);
            uploadChangesStream.Subscribe(_logger.Info);

            draftChangesStream.Throttle(TimeSpan.FromSeconds(5)).Subscribe(_ => _persistencyService.Store());
            uploadChangesStream.Subscribe(_ => _uploadService.UploadFile());
        }

        private void DoExperiment(IObserver<string> draftChangesStream, IObserver<string> uploadChangesStream)
        {
            draftChangesStream.OnNext("entering description");

            Thread.Sleep(TimeSpan.FromSeconds(1));
            uploadChangesStream.OnNext("uploading file");
        }
    }
}