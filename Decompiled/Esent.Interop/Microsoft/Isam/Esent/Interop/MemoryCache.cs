using System;
using System.Threading;

namespace Microsoft.Isam.Esent.Interop;

internal sealed class MemoryCache
{
	private static readonly byte[] ZeroLengthArray = new byte[0];

	private readonly int bufferSize;

	private readonly byte[][] cachedBuffers;

	public int BufferSize => bufferSize;

	public MemoryCache(int bufferSize, int maxCachedBuffers)
	{
		this.bufferSize = bufferSize;
		cachedBuffers = new byte[maxCachedBuffers][];
	}

	public static byte[] Duplicate(byte[] data, int length)
	{
		if (length == 0)
		{
			return ZeroLengthArray;
		}
		byte[] array = new byte[length];
		Buffer.BlockCopy(data, 0, array, 0, length);
		return array;
	}

	public byte[] Allocate()
	{
		int startingOffset = GetStartingOffset();
		for (int i = 0; i < cachedBuffers.Length; i = checked(i + 1))
		{
			int num = checked(i + startingOffset) % cachedBuffers.Length;
			byte[] array = Interlocked.Exchange(ref cachedBuffers[num], null);
			if (array != null)
			{
				return array;
			}
		}
		return new byte[bufferSize];
	}

	public void Free(ref byte[] data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		if (data.Length != bufferSize)
		{
			throw new ArgumentOutOfRangeException("data", data.Length, "buffer is not correct size for this MemoryCache");
		}
		int startingOffset = GetStartingOffset();
		for (int i = 0; i < cachedBuffers.Length; i = checked(i + 1))
		{
			int num = checked(i + startingOffset) % cachedBuffers.Length;
			if (cachedBuffers[num] == null)
			{
				cachedBuffers[num] = data;
				break;
			}
		}
		data = null;
	}

	private int GetStartingOffset()
	{
		return LibraryHelpers.GetCurrentManagedThreadId() % cachedBuffers.Length;
	}
}
