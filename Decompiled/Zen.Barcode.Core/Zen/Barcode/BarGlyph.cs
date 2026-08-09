namespace Zen.Barcode;

public class BarGlyph : Glyph, IBarGlyph, IGlyph
{
	private short _bitEncoding;

	public short BitEncoding => _bitEncoding;

	public BarGlyph(char character, short bitEncoding)
		: base(character)
	{
		_bitEncoding = bitEncoding;
	}
}
