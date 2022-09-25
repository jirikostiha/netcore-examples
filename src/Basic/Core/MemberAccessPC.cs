namespace IJKD.dotNetFramework.Example.Core
{
    using System;
    using @base;

    public class MemberAccessPC : PerformaceComparsionBase
    {
        public override void Initialize()
        {
            PerformanceTests.Add("field access", RunFieldAccess);
            PerformanceTests.Add("field access - lmb", RunFieldAccessByLambda);
            PerformanceTests.Add("prop access - auto", RunAutoPropertyAccess);
            PerformanceTests.Add("prop access - bf", RunBFPropertyAccess);
            PerformanceTests.Add("prop access - lmb", RunPropertyAccessByLambda);
            PerformanceTests.Add("method access", RunMethodAccess);
            PerformanceTests.Add("method access - lmb", RunMethodAccessByLambda);
            PerformanceTests.Add("method access - dyn", RunMethodAccessWithDynamic);
        }

        A obj1 = new A();
        private void RunFieldAccess(int loops)
        {
            for (int j = 0; j < loops; j++)
            {
                obj1._num = 1;
                obj1._num = 2;
            }
        }

        A obj2 = new A();
        private void RunAutoPropertyAccess(int loops)
        {
            for (int j = 0; j < loops; j++)
            {
                obj2.NumAuto = 1;
                obj2.NumAuto = 2;
            }
        }

        A obj3 = new A();
        private void RunBFPropertyAccess(int loops)
        {
            for (int j = 0; j < loops; j++)
            {
                obj3.NumBF = 1;
                obj3.NumBF = 2;
            }
        }

        A obj4 = new A();
        private void RunMethodAccess(int loops)
        {
            for (int j = 0; j < loops; j++)
            {
                obj4.SetNum(1);
                obj4.SetNum(2);
            }
        }

        dynamic obj5 = new A();
        private void RunMethodAccessWithDynamic(int loops)
        {
            for (int j = 0; j < loops; j++)
            {
                obj5.SetNum(1);
                obj5.SetNum(2);
            }
        }

        A obj6 = new A();
        Action<A, int> setterF = (a, v) => a._num = v;
        private void RunFieldAccessByLambda(int loops)
        {
            for (int j = 0; j < loops; j++)
            {
                setterF(obj6, 1);
                setterF(obj6, 2);
            }
        }

        A obj7 = new A();
        Action<A, int> setterP = (a, v) => a.NumAuto = v;
        private void RunPropertyAccessByLambda(int loops)
        {
            for (int j = 0; j < loops; j++)
            {
                setterP(obj7, 1);
                setterP(obj7, 2);
            }
        }

        A obj8 = new A();
        Action<A, int> setterL = (a, v) => a.SetNum(v);
        private void RunMethodAccessByLambda(int loops)
        {
            for (int j = 0; j < loops; j++)
            {
                setterL(obj8, 1);
                setterL(obj8, 2);
            }
        }

        class A
        {
            public int _num;
            private int _numBf;

            public int NumAuto { get; set; }
            public int NumBF { get { return _numBf; } set { _numBf = value; } }

            public void SetNum(int num)
            {
                _num = num;
            }
        }
    }
}