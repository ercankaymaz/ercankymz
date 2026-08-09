namespace Zen.Barcode;

public class VaryLengthGlyph : BarGlyph, IVaryLengthGlyph, IBarGlyph, IGlyph
{
	private short _bitEncodingWidth;

	public short BitEncodingWidth => _bitEncodingWidth;

	public VaryLengthGlyph(char character, short bitEncoding, short bitEncodingWidth)
		: base(character, bitEncoding)
	{
		_bitEncodingWidth = bitEncodingWidth;
	}
}
