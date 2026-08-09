namespace Zen.Barcode;

public abstract class BinaryPitchVaryLengthBarcodeDraw<TGlyphFactory, TChecksum> : BinaryPitchBarcodeDraw<TGlyphFactory, TChecksum> where TGlyphFactory : GlyphFactory where TChecksum : Checksum
{
	protected BinaryPitchVaryLengthBarcodeDraw(TGlyphFactory factory, int encodingBitCount)
		: base(factory, encodingBitCount)
	{
	}

	protected BinaryPitchVaryLengthBarcodeDraw(TGlyphFactory factory, int encodingBitCount, int widthBitCount)
		: base(factory, encodingBitCount, widthBitCount)
	{
	}

	protected BinaryPitchVaryLengthBarcodeDraw(TGlyphFactory factory, TChecksum checksum, int encodingBitCount)
		: base(factory, checksum, encodingBitCount)
	{
	}

	protected BinaryPitchVaryLengthBarcodeDraw(TGlyphFactory factory, TChecksum checksum, int encodingBitCount, int widthBitCount)
		: base(factory, checksum, encodingBitCount, widthBitCount)
	{
	}

	protected override int GetGlyphEncodingBitCount(Glyph glyph)
	{
		return ((BinaryPitchVaryLengthGlyph)glyph).BitEncodingWidth;
	}
}
