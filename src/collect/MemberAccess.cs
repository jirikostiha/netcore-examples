using BenchmarkDotNet.Attributes;

namespace collect
{
    [MemoryDiagnoser]
    public class MemberAccess
    {
        [Params(100, 100_000)]
        public int N;

        [IterationSetup]
        public void IterationSetup()
        {
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
