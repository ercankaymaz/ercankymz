namespace Zen.Barcode;

public class Glyph : IGlyph
{
	private char _character;

	public char Character => _character;

	public Glyph(char character)
	{
		_character = character;
	}
}
