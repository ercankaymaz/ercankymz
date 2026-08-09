using System;
using System.Text;

namespace UglyToad.PdfPig.Util;

internal sealed class CircularByteBuffer(int size)
{
	private readonly byte[] buffer = new byte[size];

	private int start;

	private int count;

	public void Add(byte b)
	{
		int num = (start + count) % buffer.Length;
		buffer[num] = b;
		if (count < buffer.Length)
		{
			count++;
		}
		else
		{
			start = (start + 1) % buffer.Length;
		}
	}

	public void AddReverse(byte b)
	{
		start = (start - 1 + buffer.Length) % buffer.Length;
		buffer[start] = b;
		if (count < buffer.Length)
		{
			count++;
		}
	}

	public bool EndsWith(string s)
	{
		if (s.Length > count)
		{
			return false;
		}
		for (int i = 0; i < s.Length; i++)
		{
			char c = s[i];
			int i2 = count - (s.Length - i);
			if (buffer[IndexToBufferIndex(i2)] != c)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsCurrentlyEqual(string s)
	{
		if (s.Length > buffer.Length)
		{
			return false;
		}
		for (int i = 0; i < s.Length; i++)
		{
			byte num = (byte)s[i];
			byte b = buffer[IndexToBufferIndex(i)];
			if (num != b)
			{
				return false;
			}
		}
		return true;
	}

	public ReadOnlySpan<byte> AsSpan()
	{
		Span<byte> span = new byte[count];
		for (int i = 0; i < count; i++)
		{
			span[i] = buffer[IndexToBufferIndex(i)];
		}
		return span;
	}

	public override string ToString()
	{
		return Encoding.ASCII.GetString(AsSpan());
	}

	private int IndexToBufferIndex(int i)
	{
		return (start + i) % buffer.Length;
	}
}
