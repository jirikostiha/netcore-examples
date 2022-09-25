namespace Wayout.NetCore.Benchmarks.Basic.Core
{
    using System.Runtime.CompilerServices;
    using IJKD.dotNetFramework.Example;

    public class CallingFunctionPC : PerformaceComparsionItemBase
    {
        public override void Initialize()
        {
            PerformanceTests.Add("pure empty method", RunPureMethod);
            PerformanceTests.Add("2 param empty method", RunTwoParamMethod);
            PerformanceTests.Add("pure fnc", RunPureFunction);
            PerformanceTests.Add("single param fnc", RunSingleParamFunction);
            PerformanceTests.Add("caller name fnc", RunCallerNameFunction);

            PerformanceTests.Add(nameof(BaseClass_VirtualFunction1), BaseClass_VirtualFunction1);
            PerformanceTests.Add(nameof(DerivedClass_VirtualFunction1), DerivedClass_VirtualFunction1);
            PerformanceTests.Add(nameof(DerivedAbstractClass_AbstractFunction1), DerivedAbstractClass_AbstractFunction1);
            PerformanceTests.Add(nameof(DerivedInterfaceClassAsInterface_PublicFunction1), DerivedInterfaceClassAsInterface_PublicFunction1);
            PerformanceTests.Add(nameof(OverridenDerivedInterfaceClassAsInterface_PublicFunction1), OverridenDerivedInterfaceClassAsInterface_PublicFunction1);
            PerformanceTests.Add(nameof(OverridenDerivedInterfaceClass_PublicFunction1), OverridenDerivedInterfaceClass_PublicFunction1);
        }

        private void RunPureMethod(int loops)
        {
            for (var j = 0; j < loops; j++)
                PureMethod();
        }

        int num = 2;
        string str = "sd";
        private void RunTwoParamMethod(int loops)
        {
            for (var j = 0; j < loops; j++) TwoParamMethod(num, str);
        }

        private void RunPureFunction(int loops)
        {
            for (var j = 0; j < loops; j++) { var smt = PureFunction(); }
        }

        string ss = "asd";
        private void RunSingleParamFunction(int loops)
        {
            for (var j = 0; j < loops; j++) { var smt = SingleParamFunction(ss); }
        }

        private void RunCallerNameFunction(int loops)
        {
            for (var j = 0; j < loops; j++) { var smt = CallerNameFunction(ss); }
        }


        private void BaseClass_VirtualFunction1(int loops)
        {
            var x = 0;
            var c = new BaseClass();
            for (var j = 0; j < loops; j++) x = c.VirtualFunction1(x);
        }

        private void DerivedClass_VirtualFunction1(int loops)
        {
            var x = 0;
            var c = new DerivedClass();
            for (var j = 0; j < loops; j++) x = c.VirtualFunction1(x);
        }

        private void DerivedAbstractClass_AbstractFunction1(int loops)
        {
            var x = 0;
            var c = new DerivedAbstractClass();
            for (var j = 0; j < loops; j++) x = c.AbstractFunction1(x);
        }

        private void DerivedInterfaceClassAsInterface_PublicFunction1(int loops)
        {
            var x = 0;
            IBaseInterface c = new DerivedInterfaceClass();
            for (var j = 0; j < loops; j++) x = c.PublicFunction1(x);
        }

        private void OverridenDerivedInterfaceClassAsInterface_PublicFunction1(int loops)
        {
            var x = 0;
            IBaseInterface c = new OverridenDerivedInterfaceClass();
            for (var j = 0; j < loops; j++) x = c.PublicFunction1(x);
        }

        private void OverridenDerivedInterfaceClass_PublicFunction1(int loops)
        {
            var x = 0;
            var c = new OverridenDerivedInterfaceClass();
            for (var j = 0; j < loops; j++) x = c.PublicFunction1(x);
        }

     

        //------------------
        private void PureMethod()
        { }

        private void TwoParamMethod(int num, string s)
        { }

        private int PureFunction()
        {
            return 1;
        }

        private string SingleParamFunction(string str)
        {
            return str;
        }

        private string CallerNameFunction(string str, [CallerMemberName] string name = "")
        {
            return name;
        }
    }

    //todo to test ready types
    public class BaseClass
    {
        public virtual void EmptyVirtualMethod0() { }
        public virtual int VirtualFunction0() { return 1; }
        public virtual int VirtualFunction1(int p1) { return p1 + 1; }
    }

    public abstract class BaseAbstractClass
    {
        public abstract void EmptyAbstractMethod0();
        public abstract int AbstractFunction0();
        public abstract int AbstractFunction1(int p1);
    }

    public interface IBaseInterface
    {
        void EmptyMethod0();
        public void PublicEmptyMethod0();

        //default impl
        public int PublicFunction1(int p1) { return p1 + 1; }
    }

    public class DerivedClass : BaseClass
    {
        public override void EmptyVirtualMethod0() { }
        public override int VirtualFunction0() { return 2; }
        public override int VirtualFunction1(int p1) { return p1 + 2; }
    }

    public class DerivedAbstractClass : BaseAbstractClass
    {
        public override void EmptyAbstractMethod0() { }
        public override int AbstractFunction0() { return 2; }
        public override int AbstractFunction1(int p1) { return p1 + 2; }
    }

    public class DerivedInterfaceClass : IBaseInterface
    {
        public void EmptyMethod0() { }
        public void PublicEmptyMethod0() { }
    }

    public class OverridenDerivedInterfaceClass : IBaseInterface
    {
        public void EmptyMethod0() { }
        public void PublicEmptyMethod0() { }
        public int PublicFunction1(int p1) { return p1 + 2; }
    }
}
