namespace Zen.Barcode;

public class CompositeGlyph : Glyph
{
	private BarGlyph _first;

	private BarGlyph _second;

	public BarGlyph First => _first;

	public BarGlyph Second => _second;

	public CompositeGlyph(char character, BarGlyph first, BarGlyph second)
		: base(character)
	{
		_first = first;
		_second = second;
	}
}
