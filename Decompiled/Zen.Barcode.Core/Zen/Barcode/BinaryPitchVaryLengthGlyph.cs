namespace Zen.Barcode;

public class BinaryPitchVaryLengthGlyph : BinaryPitchGlyph, IVaryLengthGlyph, IBarGlyph, IGlyph
{
	private short _bitEncodingWidth;

	public short BitEncodingWidth => _bitEncodingWidth;

	public BinaryPitchVaryLengthGlyph(char character, short bitEncoding, short widthEncoding, short bitEncodingWidth)
		: base(character, bitEncoding, widthEncoding)
	{
		_bitEncodingWidth = bitEncodingWidth;
	}
}
