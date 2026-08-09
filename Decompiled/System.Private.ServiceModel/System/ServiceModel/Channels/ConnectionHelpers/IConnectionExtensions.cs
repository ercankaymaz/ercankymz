using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels.ConnectionHelpers;

internal static class IConnectionExtensions
{
	internal static async Task WriteAsync(this IConnection connection, byte[] buffer, int offset, int size, bool immediate, TimeSpan timeout)
	{
		TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
		AsyncCompletionResult asyncCompletionResult = connection.BeginWrite(buffer, offset, size, immediate, timeout, OnIoComplete, taskCompletionSource);
		if (asyncCompletionResult == AsyncCompletionResult.Completed)
		{
			taskCompletionSource.SetResult(result: true);
		}
		await taskCompletionSource.Task;
		connection.EndWrite();
	}

	internal static async Task<int> ReadAsync(this IConnection connection, int offset, int size, TimeSpan timeout)
	{
		TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
		AsyncCompletionResult asyncCompletionResult = connection.BeginRead(offset, size, timeout, OnIoComplete, taskCompletionSource);
		if (asyncCompletionResult == AsyncCompletionResult.Completed)
		{
			taskCompletionSource.SetResult(result: true);
		}
		await taskCompletionSource.Task;
		return connection.EndRead();
	}

	internal static async Task<int> ReadAsync(this IConnection connection, byte[] buffer, int offset, int size, TimeSpan timeout)
	{
		int num = await connection.ReadAsync(0, size, timeout);
		Buffer.BlockCopy(connection.AsyncReadBuffer, 0, buffer, offset, num);
		return num;
	}

	private static void OnIoComplete(object state)
	{
		if (state == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("state");
		}
		if (!(state is TaskCompletionSource<bool> taskCompletionSource))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("state", System.SR.SPS_InvalidAsyncResult);
		}
		taskCompletionSource.TrySetResult(result: true);
	}
}
