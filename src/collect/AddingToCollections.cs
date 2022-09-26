using BenchmarkDotNet.Attributes;

namespace collect
{
    [MemoryDiagnoser]
    public class AddingToCollections
    {
        [Params(100, 100_000)]
        public int N;

        private List<object> _list;
        private List<object> _listInit;
        private object[] _array;

        private object Obj = new object();


        [IterationSetup]
        public void IterationSetup()
        {
            _list = new List<object>();
            _listInit = new List<object>(N + 1);
            _array = new object[N + 1];
        }

        [Benchmark]
        public void AddToList()
        {
            for (int i = 0; i < N - 1; i++)
            {
                _list.Add(Obj);
            }
        }

        [Benchmark]
        public void AddToInitializedList()
        {
            for (int i = 0; i < N - 1; i++)
            {
                _listInit.Add(Obj);
            }
        }

        [Benchmark]
        public void AddToArray()
        {
            for (int i = 0; i < N - 1; i++)
            {
                _array[i] = Obj;
            }
        }
    }
}
