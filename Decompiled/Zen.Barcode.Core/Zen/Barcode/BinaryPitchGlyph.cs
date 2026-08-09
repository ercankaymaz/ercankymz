namespace Zen.Barcode;

public class BinaryPitchGlyph : BarGlyph, IBinaryPitchGlyph, IBarGlyph, IGlyph
{
	private short _widthEncoding;

	public short WidthEncoding => _widthEncoding;

	public BinaryPitchGlyph(char character, short bitEncoding, short widthEncoding)
		: base(character, bitEncoding)
	{
		_widthEncoding = widthEncoding;
	}
}
