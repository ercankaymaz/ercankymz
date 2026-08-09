using System;
using System.Collections.Generic;
using System.Linq;
using SharpGLTF.Memory;

namespace SharpGLTF.Geometry;

internal class PackedBuffer
{
	private readonly List<MemoryAccessor> _Accessors = new List<MemoryAccessor>();

	protected int? ByteStride
	{
		get
		{
			if (_Accessors.Count == 0)
			{
				return null;
			}
			return _Accessors[0].Attribute.StepByteLength;
		}
	}

	public void AddAccessors(params MemoryAccessor[] accessors)
	{
		foreach (MemoryAccessor memoryAccessor in accessors)
		{
			if (memoryAccessor != null)
			{
				if (ByteStride.HasValue)
				{
					int stepByteLength = memoryAccessor.Attribute.StepByteLength;
					SharpGLTF.Guard.IsTrue(ByteStride.Value == stepByteLength, "accessors");
				}
				_Accessors.Add(memoryAccessor);
			}
		}
	}

	public void MergeBuffers()
	{
		if (_Accessors.Count == 0)
		{
			return;
		}
		List<ArraySegment<byte>> list = (from item in _Accessors.Select((MemoryAccessor item) => item.Data).Distinct()
			orderby item.Count descending
			select item).ToList();
		byte[] array = new byte[list.Sum((ArraySegment<byte> item) => item.Count)];
		int num = 0;
		Dictionary<ArraySegment<byte>, int> dictionary = new Dictionary<ArraySegment<byte>, int>();
		foreach (ArraySegment<byte> item in list)
		{
			dictionary[item] = num;
			item.CopyTo(0, array, num, item.Count);
			num += item.Count;
		}
		ArraySegment<byte> data = new ArraySegment<byte>(array);
		foreach (MemoryAccessor accessor in _Accessors)
		{
			num = dictionary[accessor.Data];
			MemoryAccessInfo attribute = accessor.Attribute;
			attribute.ByteOffset += num;
			accessor.Update(data, attribute);
		}
	}
}
