using System;

using testRxCancellationOfThrottle.Experiments;
using testRxCancellationOfThrottle.Services;

namespace testRxCancellationOfThrottle
{
    static class Program
    {
        static void Main()
        {
            ThrottleExperiment.Run();
//            ConcatExperiment.Run();
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