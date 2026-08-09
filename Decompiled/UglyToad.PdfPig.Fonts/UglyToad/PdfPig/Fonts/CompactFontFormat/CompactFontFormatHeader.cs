namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

public readonly struct CompactFontFormatHeader
{
	public byte MajorVersion { get; }

	public byte MinorVersion { get; }

	public byte SizeInBytes { get; }

	public byte OffsetSize { get; }

	public CompactFontFormatHeader(byte majorVersion, byte minorVersion, byte sizeInBytes, byte offsetSize)
	{
		MajorVersion = majorVersion;
		MinorVersion = minorVersion;
		SizeInBytes = sizeInBytes;
		OffsetSize = offsetSize;
	}

	public override string ToString()
	{
		return $"Major: {MajorVersion}, Minor: {MinorVersion}, Header Size: {SizeInBytes}, Offset: {OffsetSize}";
	}
}
