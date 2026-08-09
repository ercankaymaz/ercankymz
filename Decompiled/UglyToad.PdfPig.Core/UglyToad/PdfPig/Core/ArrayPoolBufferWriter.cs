using System;
using System.Buffers;

namespace UglyToad.PdfPig.Core;

public sealed class ArrayPoolBufferWriter<T> : IBufferWriter<T>, IDisposable
{
	private const int DefaultBufferSize = 256;

	private T[] buffer;

	private int position;

	public int WrittenCount => position;

	public ReadOnlyMemory<T> WrittenMemory => buffer.AsMemory(0, position);

	public ReadOnlySpan<T> WrittenSpan => buffer.AsSpan(0, position);

	private int RemainingBytes => buffer.Length - position;

	public ArrayPoolBufferWriter()
	{
		buffer = ArrayPool<T>.Shared.Rent(256);
		position = 0;
	}

	public ArrayPoolBufferWriter(int size)
	{
		buffer = ArrayPool<T>.Shared.Rent(size);
		position = 0;
	}

	public void Advance(int count)
	{
		position += count;
	}

	public void Write(T value)
	{
		GetSpan(1)[0] = value;
		position++;
	}

	public void Write(ReadOnlySpan<T> values)
	{
		values.CopyTo(GetSpan(values.Length));
		position += values.Length;
	}

	public Memory<T> GetMemory(int sizeHint = 0)
	{
		EnsureCapacity(sizeHint);
		return buffer.AsMemory(position);
	}

	public Span<T> GetSpan(int sizeHint = 0)
	{
		EnsureCapacity(sizeHint);
		return buffer.AsSpan(position);
	}

	private void EnsureCapacity(int sizeHint)
	{
		if (sizeHint == 0)
		{
			sizeHint = 1;
		}
		if (sizeHint > RemainingBytes)
		{
			T[] destinationArray = ArrayPool<T>.Shared.Rent(Math.Max(position + sizeHint, 512));
			if (buffer.Length != 0)
			{
				Array.Copy(buffer, 0, destinationArray, 0, position);
				ArrayPool<T>.Shared.Return(buffer);
			}
			buffer = destinationArray;
		}
	}

	public void Reset(bool clearArray = false)
	{
		position = 0;
		if (clearArray)
		{
			buffer.AsSpan().Clear();
		}
	}

	public void Dispose()
	{
		if (buffer.Length != 0)
		{
			ArrayPool<T>.Shared.Return(buffer);
			buffer = Array.Empty<T>();
		}
	}
}
