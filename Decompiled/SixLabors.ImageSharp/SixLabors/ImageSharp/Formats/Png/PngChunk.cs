using System.Buffers;

namespace SixLabors.ImageSharp.Formats.Png;

internal readonly struct PngChunk(int length, PngChunkType type, IMemoryOwner<byte> data = null)
{
	public int Length { get; } = length;

	public PngChunkType Type { get; } = type;

	public IMemoryOwner<byte> Data { get; } = data;

	public bool IsCritical(PngCrcChunkHandling handling)
	{
		switch (handling)
		{
		case PngCrcChunkHandling.IgnoreNone:
			return true;
		case PngCrcChunkHandling.IgnoreNonCritical:
		{
			bool result;
			switch (Type)
			{
			case PngChunkType.Data:
			case PngChunkType.Header:
			case PngChunkType.Palette:
			case PngChunkType.FrameData:
				result = true;
				break;
			default:
				result = false;
				break;
			}
			return result;
		}
		case PngCrcChunkHandling.IgnoreData:
		{
			PngChunkType type = Type;
			return (type == PngChunkType.Header || type == PngChunkType.Palette) ? true : false;
		}
		default:
			return false;
		}
	}
}
