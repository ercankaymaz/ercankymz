using System;
using System.IO;
using System.Runtime.InteropServices;

namespace UglyToad.PdfPig.Core;

public static class MemoryHelper
{
	public static MemoryStream AsReadOnlyMemoryStream(this ReadOnlyMemory<byte> memory)
	{
		if (MemoryMarshal.TryGetArray(memory, out var segment))
		{
			return new MemoryStream(segment.Array, segment.Offset, segment.Count, writable: false);
		}
		return new MemoryStream(memory.ToArray(), writable: false);
	}

	public static Memory<byte> AsMemory(this MemoryStream stream)
	{
		if (stream.TryGetBuffer(out var buffer))
		{
			return buffer.AsMemory();
		}
		return stream.ToArray();
	}
}
