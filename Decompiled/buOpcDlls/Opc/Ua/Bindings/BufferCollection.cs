using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class BufferCollection : List<ArraySegment<byte>>
{
	public int TotalSize
	{
		get
		{
			int num = 0;
			for (int i = 0; i < base.Count; i++)
			{
				num += base[i].Count;
			}
			return num;
		}
	}

	public BufferCollection()
	{
	}

	public BufferCollection(int capacity)
		: base(capacity)
	{
	}

	public BufferCollection(ArraySegment<byte> segment)
	{
		Add(segment);
	}

	public BufferCollection(byte[] array, int offset, int count)
	{
		Add(new ArraySegment<byte>(array, offset, count));
	}

	public int Release(BufferManager bufferManager, string owner)
	{
		int num = 0;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ArraySegment<byte> current = enumerator.Current;
				num += current.Count;
				bufferManager.ReturnBuffer(current.Array, owner);
			}
		}
		Clear();
		return num;
	}
}
