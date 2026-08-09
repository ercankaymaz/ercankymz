using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Newtonsoft.Json.Utilities;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal static class AsyncUtils
{
	public static readonly Task<bool> False = Task.FromResult(result: false);

	public static readonly Task<bool> True = Task.FromResult(result: true);

	internal static readonly Task CompletedTask = Task.Delay(0);

	internal static Task<bool> ToAsync(this bool value)
	{
		if (!value)
		{
			return False;
		}
		return True;
	}

	[Newtonsoft_002EJson_002ENullableContext(2)]
	public static Task CancelIfRequestedAsync(this CancellationToken cancellationToken)
	{
		if (!cancellationToken.IsCancellationRequested)
		{
			return null;
		}
		return cancellationToken.FromCanceled();
	}

	[Newtonsoft_002EJson_002ENullableContext(2)]
	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
	public static Task<T> CancelIfRequestedAsync<T>(this CancellationToken cancellationToken)
	{
		if (!cancellationToken.IsCancellationRequested)
		{
			return null;
		}
		return cancellationToken.FromCanceled<T>();
	}

	public static Task FromCanceled(this CancellationToken cancellationToken)
	{
		return new Task(delegate
		{
		}, cancellationToken);
	}

	public static Task<T> FromCanceled<[Newtonsoft_002EJson_002ENullable(2)] T>(this CancellationToken cancellationToken)
	{
		return new Task<T>([Newtonsoft_002EJson_002ENullableContext(0)] () => default(T), cancellationToken);
	}

	public static Task WriteAsync(this TextWriter writer, char value, CancellationToken cancellationToken)
	{
		if (!cancellationToken.IsCancellationRequested)
		{
			return writer.WriteAsync(value);
		}
		return cancellationToken.FromCanceled();
	}

	public static Task WriteAsync(this TextWriter writer, [Newtonsoft_002EJson_002ENullable(2)] string value, CancellationToken cancellationToken)
	{
		if (!cancellationToken.IsCancellationRequested)
		{
			return writer.WriteAsync(value);
		}
		return cancellationToken.FromCanceled();
	}

	public static Task WriteAsync(this TextWriter writer, char[] value, int start, int count, CancellationToken cancellationToken)
	{
		if (!cancellationToken.IsCancellationRequested)
		{
			return writer.WriteAsync(value, start, count);
		}
		return cancellationToken.FromCanceled();
	}

	public static Task<int> ReadAsync(this TextReader reader, char[] buffer, int index, int count, CancellationToken cancellationToken)
	{
		if (!cancellationToken.IsCancellationRequested)
		{
			return reader.ReadAsync(buffer, index, count);
		}
		return cancellationToken.FromCanceled<int>();
	}

	public static bool IsCompletedSuccessfully(this Task task)
	{
		return task.Status == TaskStatus.RanToCompletion;
	}
}
