namespace Wayout.NetCore.Benchmarks
{
    using System;
    using System.Linq;
    using System.Reflection;
    using IJKD.dotNetFramework.Example.UI.Views;
    using Wayout.NetCore.Benchmarks.Basic.Core;

    class Program
    {
        static void Main(string[] args)
        {
            var pc = new CallingFunctionPC()
            {
                Loops = 100000,
                MCount = 100,
            };

            var view = new PerformaceComparsionView(pc);
            view.Show();
        }
    }
}
