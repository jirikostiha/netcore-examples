using BenchmarkDotNet.Attributes;

namespace collect
{
    [MemoryDiagnoser]
    public class AppendingToList
    {
        [Params(100, 100_000)]
        public int N;

        private List<int> _list;

        [IterationSetup]
        public void IterationSetup()
        {
            _list = new List<int>(N);
        }

        [Benchmark]
        public void Append()
        {
            for (int i = 0; i < N - 1; i++)
            {
                ListExt.Append(_list, i);
            }
        }


        [Benchmark]
        public void AppendAndReturnAndDiscard()
        {
            for (int i = 0; i < N - 1; i++)
            {
                _ = _list.AppendAndReturn(i);
            }
        }

        [Benchmark]
        public List<int>? AppendAndReturn()
        {
            List<int>? list = null;
            for (int i = 0; i < N - 1; i++)
            {
                list = _list.AppendAndReturn(i);
            }

            return list;
        }
    }

    public static class ListExt
    {
        public static void Append<T>(List<T> list, T item)
        {
            list.Add(item);
        }

        public static List<T> AppendAndReturn<T>(this List<T> list, T item)
        {
            list.Add(item);
            return list;
        }
    }
}
