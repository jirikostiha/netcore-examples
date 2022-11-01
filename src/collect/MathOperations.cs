using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using static System.Math;

namespace collect
{
    [MemoryDiagnoser]
    public class MathOperations
    {
        [Params(100, 10_000)]
        public int N;

        [Benchmark]
        public double Add()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = 3.3 + i;

            return aux;
        }

        [Benchmark]
        public double Add_Default()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = MathHelper.Add(3.3, i);

            return aux;
        }

        [Benchmark]
        public double Add_Inlined()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = MathHelper.Add_Inlined(3.3, i);

            return aux;
        }

        [Benchmark]
        public double Add_NoInlining()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = MathHelper.Add_NoInlining(3.3, i);

            return aux;
        }

        [Benchmark]
        public double Pythagoras()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = Sqrt(3.3 * 3.3 + i * i);

            return aux;
        }

        [Benchmark]
        public double Pythagoras_Default()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = MathHelper.Pythagoras(3.3, i);

            return aux;
        }

        [Benchmark]
        public double Pythagoras_Inlined()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = MathHelper.Pythagoras_Inlined(3.3, i);

            return aux;
        }


        [Benchmark]
        public double Pythagoras_NoInlining()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = MathHelper.Pythagoras_NoInlining(3.3, i);

            return aux;
        }

        [Benchmark]
        public double Pythagoras2()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = Sqrt(Pow(3.3, 2) + Pow(i, 2));

            return aux;
        }

        [Benchmark]
        public double Pythagoras2_Default()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = MathHelper.Pythagoras2(3.3, i);

            return aux;
        }

        [Benchmark]
        public double Pythagoras2_Inlined()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = MathHelper.Pythagoras2_Inlined(3.3, i);

            return aux;
        }

        [Benchmark]
        public double Pythagoras2_NoInlining()
        {
            var aux = 0d;
            for (long i = 0; i < N; i++)
                aux = MathHelper.Pythagoras2_NoInlining(3.3, i);

            return aux;
        }
    }

    public static class MathHelper
    {
        public static double Add(double a, double b) => a + b;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Add_Inlined(double a, double b) => a + b;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Add_NoInlining(double a, double b) => a + b;


        public static double Pythagoras(double a, double b) => Sqrt(a * a + b * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Pythagoras_Inlined(double a, double b) => Sqrt(a * a + b * b);
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Pythagoras_NoInlining(double a, double b) => Sqrt(a * a + b * b);


        public static double Pythagoras2(double a, double b) => Sqrt(Pow(a, 2) + Pow(b, 2));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Pythagoras2_Inlined(double a, double b) => Sqrt(Pow(a, 2) + Pow(b, 2));

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Pythagoras2_NoInlining(double a, double b) => Sqrt(Pow(a, 2) + Pow(b, 2));
    }
}
