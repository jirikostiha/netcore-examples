using BenchmarkDotNet.Attributes;

namespace collect
{
    [MemoryDiagnoser]
    public class CollectionConversions
    {
        [Params(100, 10_000)]
        public int N;

        private List<int> _list;


        [IterationSetup]
        public void IterationSetup()
        {
            _list = new List<int>(Enumerable.Range(0, N-1));
        }

        [Benchmark]
        public int[] ListToArray()
        {
            return _list.ToArray();
        }

        [Benchmark]
        public List<int> ListToList()
        {
            return _list.ToList();
        }
    }
}
