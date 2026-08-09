namespace UglyToad.PdfPig.Fonts.TrueType.Glyphs;

public readonly struct HorizontalMetric
{
	public ushort AdvanceWidth { get; }

	public short LeftSideBearing { get; }

	public HorizontalMetric(ushort advanceWidth, short leftSideBearing)
	{
		AdvanceWidth = advanceWidth;
		LeftSideBearing = leftSideBearing;
	}

	public override string ToString()
	{
		return $"Width: {AdvanceWidth}. LSB: {LeftSideBearing}.";
	}
}
