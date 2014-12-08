using System;

using NLog;

using testRxCancellationOfThrottle.Experiments;
using testRxCancellationOfThrottle.Services;

namespace testRxCancellationOfThrottle
{
    static class Program
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main()
        {
            _logger.Info("startup");

            ThrottleExperiment.Run();
//            ConcatExperiment.Run();

            _logger.Info("end");
            Console.ReadKey();
        }

        private static IExperiment ThrottleExperiment
        {
            get
            {
                var throttleExperiment = new ThrottleExperiment(
                    new DraftPersistencyService(),
                    new UploadService(
                        new DraftPersistencyService()));
                return throttleExperiment;
            }
        }

        private static IExperiment ConcatExperiment
        {
            get
            {
                return new ConcatExperiment();
            }
        }
    }
}