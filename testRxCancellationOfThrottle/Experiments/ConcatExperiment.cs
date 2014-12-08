using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;

using testRxCancellationOfThrottle.Utils;

namespace testRxCancellationOfThrottle.Experiments
{
    internal class ConcatExperiment : IExperiment
    {
        private IEnumerable<IObservable<long>> GetSequences()
        {
            Console.WriteLine("GetSequences() called");

            Console.WriteLine("Yield 1st sequence");
            yield return Observable.Create<long>(o =>
            {
                Console.WriteLine("1st subscribed to");
                return Observable.Timer(TimeSpan.FromMilliseconds(1500)).Select(i => 1L).Subscribe(o);
            });

            Console.WriteLine("Yield 2nd sequence");
            yield return Observable.Create<long>(o =>
            {
                Console.WriteLine("2nd subscribed to");
                return Observable.Timer(TimeSpan.FromMilliseconds(3000))
                                 .Select(i => 2L)
                                 .Subscribe(o);
            });

            Thread.Sleep(2000);
            Console.WriteLine("Yield 3rd sequence");
            yield return Observable.Create<long>(o =>
            {
                Console.WriteLine("3rd subscribed to");
                return Observable.Timer(TimeSpan.FromMilliseconds(1000))
                                 .Select(i => 3L)
                                 .Subscribe(o);
            });

            Console.WriteLine("GetSequences() complete");
        }

        public void Run()
        {
            GetSequences().Concat().Dump("Concat");
        }
    }
}