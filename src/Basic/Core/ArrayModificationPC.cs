namespace IJKD.dotNetFramework.Example.Core
{
    using System;

    public class ArrayModificationPC : PerformaceComparsionBase
    {
        public override void Initialize()
        {
            PerformanceTests.Add("for loop", RunForLoops);
            PerformanceTests.Add("generic for loop", RunGenericForLoops);
        }

        static readonly double[,,] Arr1 = CreateArray();
        private void RunForLoops(int loops)
        {
            for (int j = 0; j < loops; j++)
            {
                AddToAll(Arr1, 100);
            }
        }

        static readonly double[,,] Arr2 = CreateArray();
        private void RunGenericForLoops(int loops)
        {
            for (int j = 0; j < loops; j++)
            {
                ApplyToAll(Arr2, (x) => x + 100);
            }
        }

        private static double[,,] CreateArray()
        {
            return new double[,,]
            {
                {{01,02,03},{04,05,06},{07,08,09}}, 
                {{11,12,13},{14,15,16},{17,18,19}}, 
                {{21,22,23},{24,25,26},{27,28,29}},
                {{31,32,33},{34,35,36},{37,38,39}}
            };
        }

        private static void ApplyToAll<T>(T[,,] array, Func<T, T> func)
        {
            for (int i1 = 0; i1 <= array.GetUpperBound(0); i1++)
            for (int i2 = 0; i2 <= array.GetUpperBound(1); i2++)
            for (int i3 = 0; i3 <= array.GetUpperBound(2); i3++)
                array[i1, i2, i3] = func(array[i1, i2, i3]);
        }

        private static void AddToAll(double[,,] array, double value)
        {
            for (int i1 = 0; i1 <= array.GetUpperBound(0); i1++)
            for (int i2 = 0; i2 <= array.GetUpperBound(1); i2++)
            for (int i3 = 0; i3 <= array.GetUpperBound(2); i3++)
                array[i1, i2, i3] += value;
        }
    }
}
