using System.Collections.Generic;

namespace SharpGLTF.Schema2;

internal sealed class _StaticBufferBuilder
{
	private readonly int _BufferIndex;

	private readonly List<byte> _Data;

	public int BufferIndex => _BufferIndex;

	public int BufferSize => _Data.Count;

	public _StaticBufferBuilder(int bufferIndex, int initialCapacity = 0)
	{
		_BufferIndex = bufferIndex;
		_Data = new List<byte>(initialCapacity);
	}

	public int Append(byte[] data)
	{
		Guard.NotNullOrEmpty(data, "data");
		while ((_Data.Count & 3) != 0)
		{
			_Data.Add(0);
		}
		int count = _Data.Count;
		_Data.AddRange(data);
		return count;
	}

	public byte[] ToArray()
	{
		int i;
		for (i = _Data.Count; (i & 3) != 0; i++)
		{
		}
		byte[] array = new byte[i];
		_Data.CopyTo(array);
		return array;
	}
}
