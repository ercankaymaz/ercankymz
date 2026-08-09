using System.IO;

namespace UglyToad.PdfPig.Images.Png;

internal interface IChunkVisitor
{
	void Visit(Stream stream, ImageHeader header, ChunkHeader chunkHeader, byte[] data, byte[] crc);
}
