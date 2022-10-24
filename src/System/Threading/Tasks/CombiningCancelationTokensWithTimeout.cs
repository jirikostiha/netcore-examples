using DotNetCoreExamples;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreExamples.System.Threading.Tasks
{
    //more info:
    //https://learn.microsoft.com/en-us/dotnet/standard/threading/how-to-listen-for-multiple-cancellation-requests
    //https://learn.microsoft.com/en-us/dotnet/standard/threading/cancellation-in-managed-threads?redirectedfrom=MSDN

    [Example("combining cancelation tokens - timeout", nameof(System.Threading.Tasks), Stamp.Operation, Stamp.Cancelation)]
    public sealed class CombiningCancelationTokensWithTimeout : ExampleBase
    {
        public readonly TimeSpan OperationDuration = TimeSpan.FromSeconds(8);
        public readonly TimeSpan Timeout = TimeSpan.FromSeconds(4);
        public readonly TimeSpan ExternalDelayToCancel = TimeSpan.FromSeconds(2);

        public override async Task Run()
        {
            using var externalCts = new CancellationTokenSource();
            try
            {
                await CallCancelableOperation(externalCts.Token);
                //await Task.Delay(TimeSpan.FromSeconds(1));
                //Output.Write($"{DateTime.Now} Canceling external token.");
                //externalCts.Cancel(true);
            }
            catch (Exception ex)
            {
                Output.Write($"{DateTime.Now} {ex.GetType()} {ex.Message}");
            }
        }

        public async Task CallCancelableOperation(CancellationToken externalToken)
        {
            using var timeoutCts = new CancellationTokenSource(Timeout);
            using var ctsWithTimeout = CancellationTokenSource.CreateLinkedTokenSource(timeoutCts.Token, externalToken);

            Output.Write($"{DateTime.Now} Operation started.");
            
            try
            {
                await Task.Delay(OperationDuration, ctsWithTimeout.Token);
            }
            catch (OperationCanceledException e)
            {
                if (timeoutCts.IsCancellationRequested)
                {
                    throw new TimeoutException($"The time limit {Timeout} has expired.", e);
                }

                throw;
            }

            Output.Write($"{DateTime.Now} Operation finished.");
        }
    }
}
