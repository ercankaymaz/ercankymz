using System.IO;
using System.Text;

namespace ACadSharp.IO.DWG;

internal class DwgFileHeaderWriterAC21 : DwgFileHeaderWriterAC18
{
	protected override int _fileHeaderSize => 1152;

	protected override ICompressor compressor => new DwgLZ77AC21Compressor();

	public DwgFileHeaderWriterAC21(Stream stream, Encoding encoding, CadDocument model)
		: base(stream, encoding, model)
	{
	}

	protected override void craeteLocalSection(DwgSectionDescriptor descriptor, byte[] buffer, int decompressedSize, ulong offset, int totalSize, bool isCompressed)
	{
		applyCompression(buffer, decompressedSize, offset, totalSize, isCompressed);
		writeMagicNumber();
	}
}
