namespace UglyToad.PdfPig.Fonts.TrueType.Tables.Kerning;

public readonly struct KernPair
{
	public int LeftGlyphIndex { get; }

	public int RightGlyphIndex { get; }

	public short Value { get; }

	public KernPair(int leftGlyphIndex, int rightGlyphIndex, short value)
	{
		LeftGlyphIndex = leftGlyphIndex;
		RightGlyphIndex = rightGlyphIndex;
		Value = value;
	}

	public override string ToString()
	{
		return $"Left: {LeftGlyphIndex}, Right: {RightGlyphIndex}, Value {Value}.";
	}
}
