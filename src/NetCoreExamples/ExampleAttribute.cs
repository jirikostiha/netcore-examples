using System;

namespace DotNetCoreExamples
{
    public class Example : Attribute
    {
        public Example(string name = null, string category = null, params string[] stamps)
        {
            Name = name;
            Category = category;
            Stamps = stamps;
        }

        public string Name { get; }

        public string Category { get; }

        public string[] Stamps { get; }
    }
}
