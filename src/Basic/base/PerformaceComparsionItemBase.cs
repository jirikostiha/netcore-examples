namespace IJKD.dotNetFramework.Example
{ 
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using common;

    public abstract class PerformaceComparsionItemBase
    {
        private readonly IDictionary<string, IList<MeasurementResult>> _resultColl;
        private readonly IDictionary<string, IReadOnlyList<MeasurementResult>> _resultCollRO;

        protected PerformaceComparsionItemBase()
        {
            _resultColl = new Dictionary<string, IList<MeasurementResult>>();
            _resultCollRO = new Dictionary<string, IReadOnlyList<MeasurementResult>>();
            Results = new ReadOnlyDictionary<string, IReadOnlyList<MeasurementResult>>(_resultCollRO);

            Profiler = new PerformanceProfiler();
            PerformanceTests = new Dictionary<string, Action<int>>();
            MCount = 100;
            Loops = 1;
        }

        public readonly IDictionary<string, Action<int>> PerformanceTests;

        /// <summary> Loops in single measurement. </summary>
        public int Loops { get; set; }

        /// <summary> Number of measurements. </summary>
        public int MCount { get; set; }

        public IReadOnlyDictionary<string, IReadOnlyList<MeasurementResult>> Results { get; private set; }

        public abstract void Initialize();

        /// <summary> Run the performace measurement. </summary>
        public void Run()
        {
            PerformanceTests.Clear();
            Initialize();
            
            foreach (var performanceTestPair in PerformanceTests)
            {
                var performanceTest = performanceTestPair.Value; 

                for (int i = 0; i < MCount; i++)
                {
                    Profiler.CollectGabage();

                    Profiler.Start();

                    // call test action
                    performanceTest(Loops);

                    var mu1 = GC.GetTotalMemory(false);
                    var elapsed = Profiler.Stop();

                    var elapsedGarbage = Profiler.CollectGabage();
                    //TimeSpan elapsedGarbage2 = Profiler.CollectGabage();
                    //TimeSpan elapsedGarbage3 = Profiler.CollectGabage();

                    var mu = GC.GetTotalMemory(true);
                    var result = new MeasurementResult(elapsed, elapsedGarbage, mu1-mu);
                    AddElapsed(performanceTestPair.Key, result);
                    //elapsedGarbage2.Add(new TimeSpan());
                    //elapsedGarbage3.Add(new TimeSpan());

                    OnSingleMeasurementFinished(result);
                }

                OnTestFinished(new Tuple<string, IEnumerable<MeasurementResult>>(performanceTestPair.Key, _resultCollRO[performanceTestPair.Key]));
            }
        }

        protected PerformanceProfiler Profiler { get; private set; }

        protected void AddElapsed(string name, MeasurementResult measurementResult)
        {
            if (_resultColl.ContainsKey(name))
            {
                _resultColl[name].Add(measurementResult);
            }
            else
            {
                var list = new List<MeasurementResult> { measurementResult };
                _resultColl.Add(name, list);
                _resultCollRO.Add(name, new ReadOnlyCollection<MeasurementResult>(list));
            }
        }

        public event EventHandler<MeasurementResult> SingleMeasurementFinished;

        /// <summary> Single measurement of one performance test finished. </summary>
        protected virtual void OnSingleMeasurementFinished(MeasurementResult result)
        {
            var handlers = SingleMeasurementFinished;
            if (handlers != null)
                handlers(this, result);
        }

        public event EventHandler<Tuple<string, IEnumerable<MeasurementResult>>> TestFinished;

        /// <summary> One performance test finished. </summary>
        protected virtual void OnTestFinished(Tuple<string, IEnumerable<MeasurementResult>> testResult)
        {
            var handlers = TestFinished;
            if (handlers != null)
                handlers(this, testResult);
        }

        public class MeasurementResult
        {
            public MeasurementResult(TimeSpan length, TimeSpan cleaningLength, long memoryUsed)
            {
                Length = length;
                CleaningLength = cleaningLength;
                MemoryUsed = memoryUsed;
            }

            /// <summary> Namerena hodnota </summary>
            public TimeSpan Length { get; private set; }

            //jeste promyslet
            /// <summary> Doba uklidu - Garbage Collection </summary>
            public TimeSpan CleaningLength { get; private set; }

            public long MemoryUsed { get; private set; }
        }
    }
}
