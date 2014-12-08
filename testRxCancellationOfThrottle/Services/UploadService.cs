using System;

namespace testRxCancellationOfThrottle.Services
{
    internal class UploadService : IUploadService
    {
        private readonly IDraftPersistencyService _persistencyService;

        public UploadService(IDraftPersistencyService persistencyService)
        {
            _persistencyService = persistencyService;
        }

        public void UploadFile()
        {
            Console.WriteLine("UPLOAD SERVICE     : uploading file, first saving the draft");
            _persistencyService.Store();
        }
    }
}