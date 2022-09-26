namespace IJKD.dotNetFramework.Example.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using @base;

    public class EnumeratingPC : PerformaceComparsionBase
    {
        List<int> list = Enumerable.Range(1, 100000).ToList();

        public override void Initialize()
        {
            PerformanceTests.Add("for loop", RunForLoop);
            PerformanceTests.Add("foreach loop", RunForeachLoop);
            PerformanceTests.Add("enumerator loop", RunEnumerator);
        }

        public void RunForLoop(int loops)
        {
            int n = 0;
            for (int i = 0; i < loops; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                    n = list[j];
            }
        }

        public void RunForeachLoop(int loops)
        {
            int n = 0;
            for (int i = 0; i < loops; i++)
            {
                foreach (var item in list)
                {
                    n = item;
                }
            }
        }

        public void RunEnumerator(int loops)
        {
            int n = 0;
            for (int i = 0; i < loops; i++)
            {
                var enumerator = list.GetEnumerator();
                while (enumerator.MoveNext())
                    n = enumerator.Current;
            }
        }
    }
}