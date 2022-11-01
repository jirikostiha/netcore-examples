using BenchmarkDotNet.Attributes;

namespace collect
{
    //https://till.red/b/1/

    [MemoryDiagnoser]
    public class MemberAccess
    {
        [Params(100, 100_000)]
        public int N;

        private long _intField;

        public long IntAutoProperty { get; private set; }
        
        private ClassWithIntAutoProperty _classFieldWithIntAutoProperty = new();

        private ClassWithFieldClass _classFieldWithFieldClass = new();

        private ClassWithAutoPropertyClass _classFieldWithAutoPropertyClass = new();


        [Benchmark]
        public long AccessField()
        {
            for (long i = 0; i < N; i++)
                _intField += i;

            return _intField;
        }

        [Benchmark]
        public long AccessAutoProperty()
        {
            for (long i = 0; i < N; i++)
                IntAutoProperty += i;

            return IntAutoProperty;
        }

        [Benchmark]
        public long AccessClassFieldWithIntAutoProperty()
        {
            for (long i = 0; i < N; i++)
                _classFieldWithIntAutoProperty.IntNum += i;

            return _classFieldWithIntAutoProperty.IntNum;
        }

        [Benchmark]
        public long AccessClassFieldWithFieldClass()
        {
            for (long i = 0; i < N; i++)
                _classFieldWithFieldClass.IntNum += i;

            return _classFieldWithFieldClass.IntNum;
        }

        [Benchmark]
        public long AccessClassFieldWithAutoPropertyClass()
        {
            for (long i = 0; i < N; i++)
                _classFieldWithAutoPropertyClass.Options.IntNum += i;

            return _classFieldWithAutoPropertyClass.Options.IntNum;
        }
    }

    class ClassWithIntAutoProperty
    {
        public long IntNum { get; set; }
    }

    class ClassWithFieldClass
    {
        private readonly RecordWithIntNumbers _options;

        public ClassWithFieldClass(RecordWithIntNumbers? options = null)
        {
            _options = options ?? new RecordWithIntNumbers();
        }

        public long IntNum { get => _options.IntNum; set => _options.IntNum = value; }
    }

    class ClassWithAutoPropertyClass
    {
        public RecordWithIntNumbers Options { get; init; } = new();

        public long IntNum => Options.IntNum;
    }

    record RecordWithIntNumbers
    {
        public long IntNum { get; set; }

        public long IntNumField;
    }
}
