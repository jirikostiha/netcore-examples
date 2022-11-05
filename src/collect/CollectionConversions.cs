using BenchmarkDotNet.Attributes;

namespace collect
{
    [MemoryDiagnoser]
    public class CollectionConversions
    {
        [Params(1000, 100_000)]
        public int N;

        private List<long> _list;
        private long[] _array;


        [IterationSetup]
        public void IterationSetup()
        {
            _list = new List<long>(Enumerable.Range(0, N-1).Select(x => (long)x));
            _array = _list.ToArray();
        }

        [Benchmark]
        public long[] ListToArray()
        {
            return _list.ToArray();
        }

        [Benchmark]
        public List<long> ListToList()
        {
            return _list.ToList();
        }

        [Benchmark]
        public List<long> ArrayToList()
        {
            return _array.ToList();
        }

        [Benchmark]
        public long[] ArrayToArray()
        {
            return _array.ToArray();
        }
    }
}
