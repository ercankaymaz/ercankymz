using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal static class PolyfillExtensions
{
	private sealed class TaskCompletionSourceWithCancellation<T> : TaskCompletionSource<T>
	{
		private CancellationToken _cancellationToken;

		public TaskCompletionSourceWithCancellation()
			: base(TaskCreationOptions.RunContinuationsAsynchronously)
		{
		}

		private void OnCancellation()
		{
			TrySetCanceled(_cancellationToken);
		}

		public async Task<T> WaitWithCancellationAsync(CancellationToken cancellationToken)
		{
			_cancellationToken = cancellationToken;
			using (cancellationToken.Register(delegate(object s)
			{
				((TaskCompletionSourceWithCancellation<T>)s).OnCancellation();
			}, this))
			{
				return await base.Task.ConfigureAwait(continueOnCapturedContext: false);
			}
		}
	}

	public static TValue GetOrAdd<TKey, TValue, TArg>(this ConcurrentDictionary<TKey, TValue> target, TKey key, Func<TKey, TArg, TValue> valueFactory, TArg factoryArgument) where TKey : notnull
	{
		return target.GetOrAdd(key, (TKey arg) => valueFactory(arg, factoryArgument));
	}

	public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
	{
		if (!dictionary.TryGetValue(key, out TValue value))
		{
			return defaultValue;
		}
		return value;
	}

	public static TValue? GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
	{
		return dictionary.GetValueOrDefault(key, default(TValue));
	}

	public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> target, out TKey key, out TValue value)
	{
		key = target.Key;
		value = target.Value;
	}

	public static bool TryDequeue<T>(this Queue<T> target, [MaybeNullWhen(false)] out T result)
	{
		if (target.Count == 0)
		{
			result = default(T);
			return false;
		}
		result = target.Dequeue();
		return true;
	}

	public static async Task WaitForExitAsync(this Process target, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!target.HasExited)
		{
			cancellationToken.ThrowIfCancellationRequested();
		}
		try
		{
			target.EnableRaisingEvents = true;
		}
		catch (InvalidOperationException)
		{
			if (target.HasExited)
			{
				return;
			}
			throw;
		}
		TaskCompletionSourceWithCancellation<bool> tcs = new TaskCompletionSourceWithCancellation<bool>();
		target.Exited += Handler;
		try
		{
			if (target.HasExited)
			{
				return;
			}
			await tcs.WaitWithCancellationAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			target.Exited -= Handler;
		}
		target.WaitForExit();
		void Handler(object? s, EventArgs e)
		{
			tcs.TrySetResult(result: true);
		}
	}

	public static Task<string> ReadToEndAsync(this TextReader target, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		return target.ReadToEndAsync();
	}

	public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer = null) where TKey : notnull
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (keySelector == null)
		{
			throw new ArgumentNullException("keySelector");
		}
		if (seedSelector == null)
		{
			throw new ArgumentNullException("keySelector");
		}
		if (func == null)
		{
			throw new ArgumentNullException("func");
		}
		return _003CM_System_Linq_Enumerable_AggregateBy__3_System_Collections_Generic_IEnumerable___0__System_Func___0___1__System_Func___1___2__System_Func___2___0___2__System_Collections_Generic_IEqualityComparer___1___g_003EF19C5D540DD05DDE4AFA76C091CD5B8466BAEC0DA8DE4F9542E2200B89FD59FCB__Helpers.AggregateByIterator(source, keySelector, seedSelector, func, keyComparer);
	}

	public static IEnumerable<KeyValuePair<TKey, TAccumulate>> AggregateBy<TSource, TKey, TAccumulate>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer = null) where TKey : notnull
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (keySelector == null)
		{
			throw new ArgumentNullException("keySelector");
		}
		if (func == null)
		{
			throw new ArgumentNullException("func");
		}
		return _003CM_System_Linq_Enumerable_AggregateBy__3_System_Collections_Generic_IEnumerable___0__System_Func___0___1____2_System_Func___2___0___2__System_Collections_Generic_IEqualityComparer___1___g_003EF77FC9F9100F71522FFC008D4FF7C92E24FD25102F14A9A9D395B7B2E8AE69A5A__Helpers.AggregateByIterator(source, keySelector, seed, func, keyComparer);
	}

	public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? keyComparer = null) where TKey : notnull
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (keySelector == null)
		{
			throw new ArgumentNullException("keySelector");
		}
		return _003CM_System_Linq_Enumerable_CountBy__2_System_Collections_Generic_IEnumerable___0__System_Func___0___1__System_Collections_Generic_IEqualityComparer___1___g_003EFECF92F9078377704675FEFB662C59BD73FEF3D9DD56494C8CBF866F0D3FC09DA__Helpers.CountByIterator(source, keySelector, keyComparer);
	}

	public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
	{
		HashSet<TKey> hashSet = new HashSet<TKey>(comparer);
		foreach (TSource item2 in source)
		{
			TKey item = keySelector(item2);
			if (hashSet.Add(item))
			{
				yield return item2;
			}
		}
	}

	public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		HashSet<TKey> hashSet = new HashSet<TKey>();
		foreach (TSource item2 in source)
		{
			TKey item = keySelector(item2);
			if (hashSet.Add(item))
			{
				yield return item2;
			}
		}
	}

	public static IEnumerable<(int Index, TSource Item)> Index<TSource>(this IEnumerable<TSource> source)
	{
		int index = -1;
		foreach (TSource item in source)
		{
			index = checked(index + 1);
			yield return (Index: index, Item: item);
		}
	}

	public static TSource? MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		return source.MaxBy(keySelector, null);
	}

	public static TSource? MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (keySelector == null)
		{
			throw new ArgumentNullException("keySelector");
		}
		if (comparer == null)
		{
			comparer = Comparer<TKey>.Default;
		}
		using IEnumerator<TSource> enumerator = source.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			if (default(TSource) == null)
			{
				return default(TSource);
			}
			throw new InvalidOperationException("Sequence contains no elements");
		}
		TSource val = enumerator.Current;
		TKey val2 = keySelector(val);
		if (default(TKey) == null)
		{
			if (val2 == null)
			{
				TSource result = val;
				do
				{
					if (!enumerator.MoveNext())
					{
						return result;
					}
					val = enumerator.Current;
					val2 = keySelector(val);
				}
				while (val2 == null);
			}
			while (enumerator.MoveNext())
			{
				TSource current = enumerator.Current;
				TKey val3 = keySelector(current);
				if (val3 != null && comparer.Compare(val3, val2) > 0)
				{
					val2 = val3;
					val = current;
				}
			}
		}
		else if (comparer == Comparer<TKey>.Default)
		{
			while (enumerator.MoveNext())
			{
				TSource current2 = enumerator.Current;
				TKey val4 = keySelector(current2);
				if (Comparer<TKey>.Default.Compare(val4, val2) > 0)
				{
					val2 = val4;
					val = current2;
				}
			}
		}
		else
		{
			while (enumerator.MoveNext())
			{
				TSource current3 = enumerator.Current;
				TKey val5 = keySelector(current3);
				if (comparer.Compare(val5, val2) > 0)
				{
					val2 = val5;
					val = current3;
				}
			}
		}
		return val;
	}

	public static TSource? MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		return source.MinBy(keySelector, null);
	}

	public static TSource? MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (keySelector == null)
		{
			throw new ArgumentNullException("keySelector");
		}
		if (comparer == null)
		{
			comparer = Comparer<TKey>.Default;
		}
		using IEnumerator<TSource> enumerator = source.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			if (default(TSource) == null)
			{
				return default(TSource);
			}
			throw new InvalidOperationException("Sequence contains no elements");
		}
		TSource val = enumerator.Current;
		TKey val2 = keySelector(val);
		if (default(TKey) == null)
		{
			if (val2 == null)
			{
				TSource result = val;
				do
				{
					if (!enumerator.MoveNext())
					{
						return result;
					}
					val = enumerator.Current;
					val2 = keySelector(val);
				}
				while (val2 == null);
			}
			while (enumerator.MoveNext())
			{
				TSource current = enumerator.Current;
				TKey val3 = keySelector(current);
				if (val3 != null && comparer.Compare(val3, val2) < 0)
				{
					val2 = val3;
					val = current;
				}
			}
		}
		else if (comparer == Comparer<TKey>.Default)
		{
			while (enumerator.MoveNext())
			{
				TSource current2 = enumerator.Current;
				TKey val4 = keySelector(current2);
				if (Comparer<TKey>.Default.Compare(val4, val2) < 0)
				{
					val2 = val4;
					val = current2;
				}
			}
		}
		else
		{
			while (enumerator.MoveNext())
			{
				TSource current3 = enumerator.Current;
				TKey val5 = keySelector(current3);
				if (comparer.Compare(val5, val2) < 0)
				{
					val2 = val5;
					val = current3;
				}
			}
		}
		return val;
	}

	public static IOrderedEnumerable<T> OrderDescending<T>(this IEnumerable<T> source)
	{
		return source.OrderByDescending((T _) => _);
	}

	public static IOrderedEnumerable<T> OrderDescending<T>(this IEnumerable<T> source, IComparer<T>? comparer)
	{
		return source.OrderByDescending((T _) => _, comparer);
	}

	public static IOrderedEnumerable<T> Order<T>(this IEnumerable<T> source)
	{
		return source.OrderBy((T _) => _);
	}

	public static IOrderedEnumerable<T> Order<T>(this IEnumerable<T> source, IComparer<T>? comparer)
	{
		return source.OrderBy((T _) => _, comparer);
	}

	public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
	{
		return source.ToHashSet(null);
	}

	public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource>? comparer)
	{
		return new HashSet<TSource>(source, comparer);
	}

	public static IEnumerable<(TFirst left, TSecond right)> Zip<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
	{
		return first.Zip(second, (TFirst x, TSecond y) => (x: x, y: y));
	}

	public static void CopyTo(this HttpContent target, Stream stream, TransportContext? context, CancellationToken cancellationToken)
	{
		CopyToAsync(target, stream, context, cancellationToken).Wait(cancellationToken);
	}

	public static async Task CopyToAsync(this HttpContent target, Stream stream, TransportContext? context, CancellationToken cancellationToken)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		await (Task)typeof(HttpContent).GetMethod("SerializeToStreamAsync", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[2]
		{
			typeof(Stream),
			typeof(TransportContext)
		}, null).Invoke(target, new object[2] { stream, context });
	}

	public static Task CopyToAsync(this HttpContent target, Stream stream, CancellationToken cancellationToken)
	{
		return CopyToAsync(target, stream, cancellationToken);
	}

	public static Stream ReadAsStream(this HttpContent httpContent, CancellationToken cancellationToken)
	{
		MemoryStream memoryStream = new MemoryStream();
		CopyTo(httpContent, memoryStream, null, cancellationToken);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return memoryStream;
	}

	public static Stream ReadAsStream(this HttpContent httpContent)
	{
		return ReadAsStream(httpContent, CancellationToken.None);
	}

	public static bool Contains(this string target, char value)
	{
		return target.IndexOf(value) != -1;
	}

	public static bool Contains(this string target, char value, StringComparison comparisonType)
	{
		return IndexOf(target, value, comparisonType) != -1;
	}

	public static bool Contains(this string target, string value, StringComparison comparisonType)
	{
		return target.IndexOf(value, comparisonType) != -1;
	}

	public static bool EndsWith(this string target, char value)
	{
		if (target.Length > 0)
		{
			return target[target.Length - 1] == value;
		}
		return false;
	}

	public static int GetHashCode(this string target, StringComparison comparisonType)
	{
		return _003CM_System_String_GetHashCode_System_StringComparison__g_003EF8084431EE345D16D88A56088114A34F458701CE3D1A96F6CFED1E498AB2AF6E2__Helpers.FromComparison(comparisonType).GetHashCode(target);
	}

	public static int IndexOf(this string target, char value, StringComparison comparisonType)
	{
		return target.IndexOf(value.ToString(), comparisonType);
	}

	public static string Replace(this string target, string oldValue, string? newValue, StringComparison comparisonType)
	{
		if (oldValue == null)
		{
			throw new ArgumentNullException("oldValue");
		}
		if (oldValue == "")
		{
			throw new ArgumentException("The value cannot be an empty string.", "oldValue");
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		while (true)
		{
			int num2 = target.IndexOf(oldValue, num, comparisonType);
			if (num2 == -1)
			{
				break;
			}
			stringBuilder.Append(target, num, num2 - num);
			stringBuilder.Append(newValue);
			num = num2 + oldValue.Length;
		}
		stringBuilder.Append(target, num, target.Length - num);
		return stringBuilder.ToString();
	}

	public static string ReplaceLineEndings(this string target, string replacementText)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		while (true)
		{
			int num2 = target.IndexOfAny(_003CM_System_String_ReplaceLineEndings_System_String__g_003EF061FA32450E3B5AACBDC4743A4E7422FE2FC34089C90DA170865DBB87536B33F__Constants.NewLineChars, num);
			if (num2 == -1)
			{
				break;
			}
			stringBuilder.Append(target, num, num2 - num);
			stringBuilder.Append(replacementText);
			num = num2 + 1;
			if (target[num2] == '\r' && num2 + 1 < target.Length && target[num2 + 1] == '\n')
			{
				num++;
			}
		}
		stringBuilder.Append(target, num, target.Length - num);
		return stringBuilder.ToString();
	}

	public static string ReplaceLineEndings(this string target)
	{
		return ReplaceLineEndings(target, Environment.NewLine);
	}

	public static string[] Split(this string target, char separator, int count, StringSplitOptions options = StringSplitOptions.None)
	{
		return target.Split(new char[1] { separator }, count, options);
	}

	public static string[] Split(this string target, char separator, StringSplitOptions options = StringSplitOptions.None)
	{
		return target.Split(new char[1] { separator }, options);
	}

	public static bool StartsWith(this string target, char value)
	{
		if (target.Length > 0)
		{
			return target[0] == value;
		}
		return false;
	}

	public static StringBuilder AppendJoin(this StringBuilder target, char separator, params object?[] values)
	{
		bool flag = true;
		foreach (object value in values)
		{
			if (!flag)
			{
				target.Append(separator);
			}
			target.Append(value);
			flag = false;
		}
		return target;
	}

	public static StringBuilder AppendJoin(this StringBuilder target, char separator, params string?[] values)
	{
		bool flag = true;
		foreach (string value in values)
		{
			if (!flag)
			{
				target.Append(separator);
			}
			target.Append(value);
			flag = false;
		}
		return target;
	}

	public static StringBuilder AppendJoin(this StringBuilder target, string? separator, params object?[] values)
	{
		bool flag = true;
		foreach (object value in values)
		{
			if (!flag)
			{
				target.Append(separator);
			}
			target.Append(value);
			flag = false;
		}
		return target;
	}

	public static StringBuilder AppendJoin(this StringBuilder target, string? separator, params string?[] values)
	{
		bool flag = true;
		foreach (string value in values)
		{
			if (!flag)
			{
				target.Append(separator);
			}
			target.Append(value);
			flag = false;
		}
		return target;
	}

	public static StringBuilder AppendJoin<T>(this StringBuilder target, char separator, IEnumerable<T> values)
	{
		bool flag = true;
		foreach (T value in values)
		{
			if (!flag)
			{
				target.Append(separator);
			}
			target.Append(value);
			flag = false;
		}
		return target;
	}

	public static StringBuilder AppendJoin<T>(this StringBuilder target, string? separator, IEnumerable<T> values)
	{
		bool flag = true;
		foreach (T value in values)
		{
			if (!flag)
			{
				target.Append(separator);
			}
			target.Append(value);
			flag = false;
		}
		return target;
	}

	public static Task CancelAsync(this CancellationTokenSource target)
	{
		target.Cancel();
		return Task.CompletedTask;
	}

	public static Task<TResult> WaitAsync<TResult>(this Task<TResult> task, CancellationToken cancellationToken)
	{
		if (task.IsCompleted || !cancellationToken.CanBeCanceled)
		{
			return task;
		}
		if (cancellationToken.IsCancellationRequested)
		{
			return Task.FromCanceled<TResult>(cancellationToken);
		}
		return _003CM_System_Threading_Tasks_Task_WaitAsync_System_Threading_CancellationToken__g_003EFCEE89C2E51D9AFB2F8B8B19F43D708E8BE33FC07AAC1F411F18F05373E6D8650__WaitTask.WaitTaskAsync(task, cancellationToken);
	}

	public static bool IsAssignableTo(this Type target, [NotNullWhen(true)] Type? targetType)
	{
		return targetType?.IsAssignableFrom(target) ?? false;
	}
}
