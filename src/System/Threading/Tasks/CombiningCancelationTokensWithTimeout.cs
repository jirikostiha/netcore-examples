using DotNetCoreExamples;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreExamples.System.Threading.Tasks
{
    [Example("combining cancelation tokens - timeout", nameof(System.Threading.Tasks), Stamp.Operation, Stamp.Cancelation)]
    public class CombiningCancelationTokensWithTimeout : ExampleBase
    {
        public override async Task Run()
        {
            var externalCts = new CancellationTokenSource();
            try
            {
                await CallCancelableOperation(externalCts.Token);
            }
            catch (Exception ex)
            {
                Output.Write(ex.Message);
            }
        }

        public async Task CallCancelableOperation(CancellationToken externalToken)
        {
            using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
            using var ctsWithTimeout = CancellationTokenSource.CreateLinkedTokenSource(timeoutCts.Token, externalToken);

            Output.Write("Operation started.");

            await Task.Delay(TimeSpan.FromSeconds(5), ctsWithTimeout.Token);

            Output.Write("Operation finished.");
        }
    }
}
