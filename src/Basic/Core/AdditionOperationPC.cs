namespace Wayout.NetCore.Benchmarks.Basic.Core
{
    using System.Numerics;
    using IJKD.dotNetFramework.Example;

    public class AdditionOperationPC : PerformaceComparsionItemBase
    {
        public override void Initialize()
        {
            PerformanceTests.Add("uint", RunUInt);
            PerformanceTests.Add("int", RunInt);
            PerformanceTests.Add("long", RunLong);
            PerformanceTests.Add("float", RunFloat);
            PerformanceTests.Add("double", RunDouble);
            PerformanceTests.Add("decimal", RunDecimal);
            PerformanceTests.Add("big int", RunBigInteger);
        }

        uint uint1 = 2;
        uint uint2 = 1;
        private void RunUInt(int loops)
        {
            for (var j = 0; j < loops; j++)
                uint2 = uint2 + uint1;
        }

        int int1 = 2;
        int int2 = 1;
        private void RunInt(int loops)
        {
            for (var j = 0; j < loops; j++)
                int2 = int2 + int1;
        }

        long long1 = 2;
        long long2 = 1;
        private void RunLong(int loops)
        {
            for (var j = 0; j < loops; j++)
                long2 = long2 + long1;
        }

        float float1 = 2;
        float float2 = 1;
        private void RunFloat(int loops)
        {
            for (var j = 0; j < loops; j++)
                float2 = float2 + float1;
        }

        double double1 = 2;
        double double2 = 1;
        private void RunDouble(int loops)
        {
            for (var j = 0; j < loops; j++)
                double2 = double2 + double1;
        }

        decimal decimal1 = 2;
        decimal decimal2 = 1;
        private void RunDecimal(int loops)
        {
            for (var j = 0; j < loops; j++)
                decimal2 = decimal2 + decimal1;
        }

        BigInteger bint1 = new BigInteger(2);
        BigInteger bint2 = new BigInteger(1);
        private void RunBigInteger(int loops)
        {
            for (var j = 0; j < loops; j++)
                bint2 = bint2 + bint1;
        }
    }
}
