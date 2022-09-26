namespace IJKD.dotNetFramework.Example.common
{
    using System;
    using System.Diagnostics;

    //https://msdn.microsoft.com/en-us/library/ee787088(v=vs.110).aspx

    public class PerformanceProfiler
    {
        private readonly Stopwatch _stopwatch;

        public PerformanceProfiler()
        {
            _stopwatch = new Stopwatch();
        }

        public void Start()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
        }

        public TimeSpan Stop()
        {
            _stopwatch.Stop();
            return _stopwatch.Elapsed;
        }

        // chce promyslet vic
        public TimeSpan CollectGabage()
        {
            var sw = new Stopwatch();
            sw.Reset();
            sw.Start();

            //sledovat pamet
            //GC.CollectionCount()
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            //should be better  GC.WaitForFullGCComplete();

            sw.Stop();

            return sw.Elapsed;
        }
    }
}