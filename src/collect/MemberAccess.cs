using BenchmarkDotNet.Attributes;

namespace collect
{
    //https://till.red/b/1/

    [MemoryDiagnoser]
    public class MemberAccess
    {
        [Params(100, 100_000)]
        public int N;

        private SomeClass _someClass = new () { IntNum = 1 };
        private SomeClassWithPrivateOptions _someClassWithPrivateOptions = new (
            new SomeOptions() { IntNum = 1 } );
        private SomeClassWithPublicOptions _someClassWithPublicOptions = new ()
            { Options = new SomeOptions() };


        [Benchmark]
        public int AccessIntProperty()
            => _someClass.IntNum;

        //[Benchmark]
        //public int AccessIntPropertyLoop()
        //{
        //    var sum = 0;
        //    for (int i = 0; i < N - 1; i++)
        //    {
        //        sum += _someClass.IntNum;
        //    }

        //    return sum;
        //}

        [Benchmark]
        public int AccessIntPropertyViaPrivateOptions()
            => _someClassWithPrivateOptions.IntNum;

        //[Benchmark]
        //public int AccessIntPropertyViaPrivateOptionsLoop()
        //{
        //    var sum = 0;
        //    for (int i = 0; i < N - 1; i++)
        //    {
        //        sum += _someClassWithPrivateOptions.IntNum;
        //    }

        //    return sum;
        //}

        [Benchmark]
        public int AccessIntPropertyViaPublicOptions()
            => _someClassWithPublicOptions.IntNum;

        //[Benchmark]
        //public int AccessIntPropertyViaPublicOptionsLoop()
        //{
        //    var sum = 0;
        //    for (int i = 0; i < N - 1; i++)
        //    {
        //        sum += _someClassWithPublicOptions.IntNum;
        //    }

        //    return sum;
        //}
    }

    class SomeClass
    {
        public int IntNum { get; set; }
    }

    class SomeClassWithPrivateOptions
    {
        private readonly SomeOptions _options;

        public SomeClassWithPrivateOptions(SomeOptions options)
        {
            _options = options;
        }

        public int IntNum => _options.IntNum;
    }

    class SomeClassWithPublicOptions
    {
        public SomeOptions Options { get; init; }

        public int IntNum => Options.IntNum;
    }

    record SomeOptions
    {
        public int IntNum { get; set; }

        public int IntNumField;
    }
}
