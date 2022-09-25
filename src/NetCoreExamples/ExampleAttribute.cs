using System;

namespace DotNetCoreExamples
{
    public class Example : Attribute
    {
        public Example(string name = null, string category = null, string[] labels = null)
        {
            Name = name;
            Category = category;
            Labels = labels;
        }

        public string Name { get; }

        public string Category { get; }

        public string[] Labels { get; }
    }
}
