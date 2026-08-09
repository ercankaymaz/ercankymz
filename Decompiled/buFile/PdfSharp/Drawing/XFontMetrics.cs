namespace PdfSharp.Drawing;

public sealed class XFontMetrics
{
	private readonly string _name;

	private readonly int _unitsPerEm;

	private readonly int _ascent;

	private readonly int _descent;

	private readonly int _averageWidth;

	private readonly int _capHeight;

	private readonly int _leading;

	private readonly int _lineSpacing;

	private readonly int _maxWidth;

	private readonly int _stemH;

	private readonly int _stemV;

	private readonly int _xHeight;

	private readonly int _underlinePosition;

	private readonly int _underlineThickness;

	private readonly int _strikethroughPosition;

	private readonly int _strikethroughThickness;

	public string Name => _name;

	public int UnitsPerEm => _unitsPerEm;

	public int Ascent => _ascent;

	public int Descent => _descent;

	public int AverageWidth => _averageWidth;

	public int CapHeight => _capHeight;

	public int Leading => _leading;

	public int LineSpacing => _lineSpacing;

	public int MaxWidth => _maxWidth;

	public int StemH => _stemH;

	public int StemV => _stemV;

	public int XHeight => _xHeight;

	public int UnderlinePosition => _underlinePosition;

	public int UnderlineThickness => _underlineThickness;

	public int StrikethroughPosition => _strikethroughPosition;

	public int StrikethroughThickness => _strikethroughThickness;

	internal XFontMetrics(string name, int unitsPerEm, int ascent, int descent, int leading, int lineSpacing, int capHeight, int xHeight, int stemV, int stemH, int averageWidth, int maxWidth, int underlinePosition, int underlineThickness, int strikethroughPosition, int strikethroughThickness)
	{
		_name = name;
		_unitsPerEm = unitsPerEm;
		_ascent = ascent;
		_descent = descent;
		_leading = leading;
		_lineSpacing = lineSpacing;
		_capHeight = capHeight;
		_xHeight = xHeight;
		_stemV = stemV;
		_stemH = stemH;
		_averageWidth = averageWidth;
		_maxWidth = maxWidth;
		_underlinePosition = underlinePosition;
		_underlineThickness = underlineThickness;
		_strikethroughPosition = strikethroughPosition;
		_strikethroughThickness = strikethroughThickness;
	}
}
