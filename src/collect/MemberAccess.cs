using BenchmarkDotNet.Attributes;

namespace collect
{
    [MemoryDiagnoser]
    public class MemberAccess
    {
        [Params(100, 100_000)]
        public int N;

        private SomeClass _someClass;
        private SomeClassWithPrivateOptions _someClassWithPrivateOptions;
        private SomeClassWithPublicOptions _someClassWithPublicOptions;

        [IterationSetup]
        public void IterationSetup()
        {
            _someClass = new SomeClass() { IntNum = 1 };
            _someClassWithPrivateOptions = new SomeClassWithPrivateOptions(
                new SomeOptions { IntNum = 1 });
            _someClassWithPublicOptions = new SomeClassWithPublicOptions()
            { Options = new SomeOptions() { IntNum = 1 } };
        }

        [Benchmark]
        public int AccessIntProperty()
        {
            var sum = 0;
            for (int i = 0; i < N - 1; i++)
            {
                sum += _someClass.IntNum;
            }

            return sum;
        }

        [Benchmark]
        public int AccessIntPropertyViaPrivateOptions()
        {
            var sum = 0;
            for (int i = 0; i < N - 1; i++)
            {
                sum += _someClassWithPrivateOptions.IntNum;
            }

            return sum;
        }

        [Benchmark]
        public int AccessIntPropertyViaPublicOptions()
        {
            var sum = 0;
            for (int i = 0; i < N - 1; i++)
            {
                sum += _someClassWithPublicOptions.IntNum;
            }

            return sum;
        }
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
