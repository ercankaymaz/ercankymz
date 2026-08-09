using System.Threading;
using System.Threading.Tasks;

internal sealed class _003CM_System_Threading_Tasks_Task_WaitAsync_System_Threading_CancellationToken__g_003EFCEE89C2E51D9AFB2F8B8B19F43D708E8BE33FC07AAC1F411F18F05373E6D8650__WaitTask
{
	public static async Task<TResult> WaitTaskAsync<TResult>(Task<TResult> task, CancellationToken cancellationToken)
	{
		TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>(TaskCreationOptions.RunContinuationsAsynchronously);
		using (cancellationToken.Register(delegate(object state)
		{
			((TaskCompletionSource<TResult>)state).SetCanceled();
		}, taskCompletionSource, useSynchronizationContext: false))
		{
			return (await Task.WhenAny(new Task<TResult>[2] { task, taskCompletionSource.Task }).ConfigureAwait(continueOnCapturedContext: false)).GetAwaiter().GetResult();
		}
	}
}
