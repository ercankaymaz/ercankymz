using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Test;

[ComVisible(true)]
public class RandomSource : IRandomSource
{
	private Random m_random;

	public RandomSource()
	{
		m_random = new Random();
	}

	public RandomSource(int seed)
	{
		m_random = new Random(seed);
	}

	public void NextBytes(byte[] bytes, int offset, int count)
	{
		if (bytes == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (offset < 0 || (offset != 0 && offset >= bytes.Length))
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (count < 0 || offset + count > bytes.Length)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (bytes.Length != 0)
		{
			if (offset == 0 && count == bytes.Length)
			{
				m_random.NextBytes(bytes);
				return;
			}
			byte[] array = new byte[count];
			m_random.NextBytes(array);
			Array.Copy(array, 0, bytes, offset, count);
		}
	}

	public int NextInt32(int max)
	{
		if (max < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		if (max < int.MaxValue)
		{
			max++;
		}
		return m_random.Next(max);
	}
}
