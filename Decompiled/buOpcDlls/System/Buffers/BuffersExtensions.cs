using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Buffers;

[ComVisible(true)]
public static class BuffersExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static SequencePosition? PositionOf<T>([In][System_002EMemory_002EIsReadOnly] this ref ReadOnlySequence<T> source, T value) where T : IEquatable<T>
	{
		if (source.IsSingleSegment)
		{
			int num = source.First.Span.IndexOf(value);
			if (num != -1)
			{
				return source.GetPosition(num);
			}
			return null;
		}
		return PositionOfMultiSegment(ref source, value);
	}

	private static SequencePosition? PositionOfMultiSegment<T>([In][System_002EMemory_002EIsReadOnly] ref ReadOnlySequence<T> source, T value) where T : IEquatable<T>
	{
		SequencePosition position = source.Start;
		SequencePosition origin = position;
		ReadOnlyMemory<T> memory;
		while (source.TryGet(ref position, out memory))
		{
			int num = memory.Span.IndexOf(value);
			if (num != -1)
			{
				return source.GetPosition(num, origin);
			}
			if (position.GetObject() == null)
			{
				break;
			}
			origin = position;
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void CopyTo<T>([In][System_002EMemory_002EIsReadOnly] this ref ReadOnlySequence<T> source, Span<T> destination)
	{
		if (source.Length > destination.Length)
		{
			System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument.destination);
		}
		if (source.IsSingleSegment)
		{
			source.First.Span.CopyTo(destination);
		}
		else
		{
			CopyToMultiSegment(ref source, destination);
		}
	}

	private static void CopyToMultiSegment<T>([In][System_002EMemory_002EIsReadOnly] ref ReadOnlySequence<T> sequence, Span<T> destination)
	{
		SequencePosition position = sequence.Start;
		ReadOnlyMemory<T> memory;
		while (sequence.TryGet(ref position, out memory))
		{
			ReadOnlySpan<T> span = memory.Span;
			span.CopyTo(destination);
			if (position.GetObject() != null)
			{
				destination = destination.Slice(span.Length);
				continue;
			}
			break;
		}
	}

	public static T[] ToArray<T>([In][System_002EMemory_002EIsReadOnly] this ref ReadOnlySequence<T> sequence)
	{
		T[] array = new T[sequence.Length];
		sequence.CopyTo(array);
		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Write<T>(this IBufferWriter<T> writer, ReadOnlySpan<T> value)
	{
		Span<T> span = writer.GetSpan();
		if (value.Length <= span.Length)
		{
			value.CopyTo(span);
			writer.Advance(value.Length);
		}
		else
		{
			WriteMultiSegment(writer, ref value, span);
		}
	}

	private static void WriteMultiSegment<T>(IBufferWriter<T> writer, [In][System_002EMemory_002EIsReadOnly] ref ReadOnlySpan<T> source, Span<T> destination)
	{
		ReadOnlySpan<T> readOnlySpan = source;
		while (true)
		{
			int num = Math.Min(destination.Length, readOnlySpan.Length);
			readOnlySpan.Slice(0, num).CopyTo(destination);
			writer.Advance(num);
			readOnlySpan = readOnlySpan.Slice(num);
			if (readOnlySpan.Length > 0)
			{
				destination = writer.GetSpan(readOnlySpan.Length);
				continue;
			}
			break;
		}
	}
}
