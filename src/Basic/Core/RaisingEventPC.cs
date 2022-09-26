namespace IJKD.dotNetFramework.Example.Core
{
    using System;
    using @base;

    //todo
    public class RaisingEventPC : PerformaceComparsionBase
    {
        public delegate void SampleEventHandler(object sender, EventArgs e);

        public event SampleEventHandler SampleEvent1;
        //public event SampleEventHandler SampleEvent2;

        public override void Initialize()
        {
            PerformanceTests.Add("raise1", RunRaise1);
        }

        private void RunRaise1(int loops)
        {
            for (int j = 0; j < loops; j++)
                OnSampleEvent1();
        }

        protected virtual void OnSampleEvent1()
        {
            SampleEventHandler handler = SampleEvent1;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}