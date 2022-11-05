using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace collect
{
    [MemoryDiagnoser]
    public class MathPower
    {
        [Params(10_000, 1_000_000)]
        public int N;

        [Benchmark]
        public double Power2_ByMultiplication()
        {
            var aux = 0d;
            for (double i = 0; i < N; i++)
                aux = i * i;

            return aux;
        }

        [Benchmark]
        public double Power2_ByMathPow()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = Math.Pow(i, 2);

            return aux;
        }

        [Benchmark]
        public double Power3_ByMultiplication()
        {
            var aux = 0d;
            for (double i = 0; i < N; i++)
                aux = i * i * i;

            return aux;
        }

        [Benchmark]
        public double Power3_ByMathPow()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = Math.Pow(i, 3);

            return aux;
        }

        [Benchmark]
        public double Power4_ByMultiplication()
        {
            var aux = 0d;
            for (double i = 0; i < N; i++)
                aux = i * i * i * i;

            return aux;
        }

        [Benchmark]
        public double Power4_ByMathPow()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = Math.Pow(i, 4);

            return aux;
        }

    }
}
