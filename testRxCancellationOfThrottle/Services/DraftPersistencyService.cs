using System;

namespace testRxCancellationOfThrottle.Services
{
    internal class DraftPersistencyService : IDraftPersistencyService
    {
        public void Store()
        {
            Console.WriteLine("PERSISTENCY SERVICE: storing draft");
        }
    }
}