using BenchmarkDotNet.Running;

namespace collect
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var addToCollectionsSummary = BenchmarkRunner.Run<AddingToCollections>();

            Console.ReadKey();
        }
    }
}
