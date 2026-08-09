using System;

namespace PdfSharp.Fonts.OpenType;

internal class IRefFontTable : OpenTypeFontTable
{
	private readonly TableDirectoryEntry _irefDirectoryEntry;

	public IRefFontTable(OpenTypeFontface fontData, OpenTypeFontTable fontTable)
		: base(null, fontTable.DirectoryEntry.Tag)
	{
		_fontData = fontData;
		_irefDirectoryEntry = fontTable.DirectoryEntry;
	}

	public override void PrepareForCompilation()
	{
		base.PrepareForCompilation();
		DirectoryEntry.Length = _irefDirectoryEntry.Length;
		DirectoryEntry.CheckSum = _irefDirectoryEntry.CheckSum;
		if (DirectoryEntry.Tag != "head")
		{
			byte[] array = new byte[DirectoryEntry.PaddedLength];
			Buffer.BlockCopy(_irefDirectoryEntry.FontTable._fontData.FontSource.Bytes, _irefDirectoryEntry.Offset, array, 0, DirectoryEntry.PaddedLength);
			uint checkSum = DirectoryEntry.CheckSum;
			uint num = OpenTypeFontTable.CalcChecksum(array);
		}
	}

	public override void Write(OpenTypeFontWriter writer)
	{
		writer.Write(_irefDirectoryEntry.FontTable._fontData.FontSource.Bytes, _irefDirectoryEntry.Offset, _irefDirectoryEntry.PaddedLength);
	}
}
