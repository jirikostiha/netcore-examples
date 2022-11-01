using BenchmarkDotNet.Running;

namespace collect
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var addToCollectionsSummary = BenchmarkRunner.Run<AddingToCollections>();

            //var summary = BenchmarkRunner.Run<MemberAccess>();

            var summary = BenchmarkRunner.Run<MathOperations>();

            //var summary = BenchmarkRunner.Run<AppendingToList>();

            Console.ReadKey();
        }
    }
}
