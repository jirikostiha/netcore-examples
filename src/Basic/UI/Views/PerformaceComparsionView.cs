namespace IJKD.dotNetFramework.Example.UI.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Example;

    public class PerformaceComparsionView : ViewBase
    {
        private const ConsoleColor _titleColor = ConsoleColor.White;
        private const ConsoleColor _tableHeaderColor = ConsoleColor.Gray;
        private const ConsoleColor _rowColor = ConsoleColor.DarkGray;
        private const ConsoleColor _bestItemColor = ConsoleColor.Green;
        private const ConsoleColor _worstItemColor = ConsoleColor.Red;
        private readonly ConsoleColor _defaultForegroundColor = Console.ForegroundColor;

        private PerformaceComparsionItemBase _pc;

        public PerformaceComparsionView(PerformaceComparsionItemBase pc)
        {
            _pc = pc;
            _pc.TestFinished += TestFinished;
        }

        void TestFinished(object sender, Tuple<string, IEnumerable<PerformaceComparsionItemBase.MeasurementResult>> e)
        {
            WriteResultRow(e.Item1, e.Item2);
        }

        public override void Show()
        {
            Console.Clear();
            WriteHeader();

            _pc.Run();

            Console.WriteLine();
            Console.WriteLine("Finished.");
            
            Console.ReadKey();
        }

        private void WriteHeader()
        {
            Console.ForegroundColor = _titleColor;
            Console.WriteLine(Title);
            Console.ForegroundColor = _tableHeaderColor;
            Console.WriteLine("loops per measurement: {0}, measurements per test: {1}", _pc.Loops, _pc.MCount);
            Console.WriteLine();
            Console.ForegroundColor = _tableHeaderColor;
            Console.WriteLine("{0,-25} {1,15} {2,15} {3,15}", "test name", "avg [ms]", "min [ms]", "max [ms]");
            Console.WriteLine("-------------------------------------------------------------------------");
        }

        private void WriteResults(IEnumerable<KeyValuePair<string, IEnumerable<PerformaceComparsionItemBase.MeasurementResult>>> results)
        {
            foreach (var pair in results)
                WriteResultRow(pair.Key, pair.Value);
        }

        private void WriteResultRow(string name, IEnumerable<PerformaceComparsionItemBase.MeasurementResult> testResults)
        {
            const int sigma = 3;
            var data = testResults.OrderBy(x => x.Length.Ticks).Skip(sigma).Take(testResults.Count() - 2 * sigma);
            var average = TimeSpan.FromTicks((long)data.Average(x => x.Length.Ticks));
            var min = data.Min(x => x.Length);
            var max = data.Max(x => x.Length);

            Console.ForegroundColor = _rowColor;
            Console.WriteLine("{0,-25} {1,15:N4} {2,15:N4} {3,15:N4}", name, average.TotalMilliseconds, min.TotalMilliseconds, max.TotalMilliseconds);
        }
    }
}
