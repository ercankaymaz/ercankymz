using System;
using System.Buffers;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class BufferManager
{
	private readonly string m_name;

	private readonly int m_maxBufferSize;

	private readonly ArrayPool<byte> m_arrayPool;

	private const byte kCookieLocked = 165;

	private const byte kCookieUnlocked = 90;

	private const byte kCookieLength = 1;

	public BufferManager(string name, int maxBufferSize)
	{
		m_name = name;
		m_arrayPool = ((maxBufferSize <= 1048576) ? ArrayPool<byte>.Shared : ArrayPool<byte>.Create(maxBufferSize + 1, 4));
		m_maxBufferSize = maxBufferSize;
	}

	public byte[] TakeBuffer(int size, string owner)
	{
		if (size > m_maxBufferSize)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		byte[] array = m_arrayPool.Rent(size + 1);
		array[array.Length - 1] = 90;
		return array;
	}

	public void TransferBuffer(byte[] buffer, string owner)
	{
	}

	public static void LockBuffer(byte[] buffer)
	{
		if (buffer[buffer.Length - 1] != 90)
		{
			throw new InvalidOperationException("Buffer is already locked.");
		}
		buffer[buffer.Length - 1] = 165;
	}

	public static void UnlockBuffer(byte[] buffer)
	{
		if (buffer[buffer.Length - 1] != 165)
		{
			throw new InvalidOperationException("Buffer is not locked.");
		}
		buffer[buffer.Length - 1] = 90;
	}

	public void ReturnBuffer(byte[] buffer, string owner)
	{
		if (buffer != null)
		{
			if (buffer[buffer.Length - 1] != 90)
			{
				throw new InvalidOperationException("Buffer has been locked.");
			}
			buffer[buffer.Length - 1] = byte.MaxValue;
			m_arrayPool.Return(buffer);
		}
	}
}
