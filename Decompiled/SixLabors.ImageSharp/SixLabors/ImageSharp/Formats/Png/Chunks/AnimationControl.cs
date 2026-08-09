using System;
using System.Buffers.Binary;

namespace SixLabors.ImageSharp.Formats.Png.Chunks;

internal readonly struct AnimationControl(uint numberFrames, uint numberPlays)
{
	public const int Size = 8;

	public uint NumberFrames { get; } = numberFrames;

	public uint NumberPlays { get; } = numberPlays;

	public void WriteTo(Span<byte> buffer)
	{
		BinaryPrimitives.WriteInt32BigEndian(buffer.Slice(0, 4), (int)NumberFrames);
		BinaryPrimitives.WriteInt32BigEndian(buffer.Slice(4, 4), (int)NumberPlays);
	}

	public static AnimationControl Parse(ReadOnlySpan<byte> data)
	{
		return new AnimationControl(BinaryPrimitives.ReadUInt32BigEndian(data.Slice(0, 4)), BinaryPrimitives.ReadUInt32BigEndian(data.Slice(4, 4)));
	}
}
