namespace DotNetCoreExamples
{
    using System;

    public class ConsoleOutput : IUiOutput
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }

        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
