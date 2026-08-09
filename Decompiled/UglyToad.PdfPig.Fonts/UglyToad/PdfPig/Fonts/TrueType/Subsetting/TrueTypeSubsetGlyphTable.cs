using System;
using UglyToad.PdfPig.Fonts.TrueType.Glyphs;

namespace UglyToad.PdfPig.Fonts.TrueType.Subsetting;

internal class TrueTypeSubsetGlyphTable
{
	public byte[] Bytes { get; }

	public uint[] GlyphOffsets { get; }

	public HorizontalMetric[] HorizontalMetrics { get; }

	public ushort GlyphCount => (ushort)(GlyphOffsets.Length - 1);

	public TrueTypeSubsetGlyphTable(byte[] bytes, uint[] glyphOffsets, HorizontalMetric[] horizontalMetrics)
	{
		Bytes = bytes ?? throw new ArgumentNullException("bytes");
		GlyphOffsets = glyphOffsets ?? throw new ArgumentNullException("glyphOffsets");
		HorizontalMetrics = horizontalMetrics ?? throw new ArgumentNullException("horizontalMetrics");
	}

	public long[] OffsetsAsLongs()
	{
		long[] array = new long[GlyphOffsets.Length];
		for (int i = 0; i < GlyphOffsets.Length; i++)
		{
			array[i] = GlyphOffsets[i];
		}
		return array;
	}

	public override string ToString()
	{
		return $"{GlyphCount} glyphs. Data is {Bytes.Length} bytes.";
	}
}
