using System;
using System.Buffers.Binary;
using System.IO;
using SixLabors.ImageSharp.Common.Helpers;

namespace SixLabors.ImageSharp.Formats.Webp.Chunks;

internal readonly struct WebpAnimationParameter(uint background, ushort loopCount)
{
	public uint Background { get; } = background;

	public ushort LoopCount { get; } = loopCount;

	public void WriteTo(Stream stream)
	{
		Span<byte> span = stackalloc byte[6];
		BinaryPrimitives.WriteUInt32LittleEndian(span.Slice(0, 4), Background);
		BinaryPrimitives.WriteUInt16LittleEndian(span.Slice(4, span.Length - 4), LoopCount);
		RiffHelper.WriteChunk(stream, 1095649613u, span);
	}
}
