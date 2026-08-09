namespace UglyToad.PdfPig.Fonts.CompactFontFormat.Dictionaries;

internal sealed class CidFontOperators
{
	public RegistryOrderingSupplement Ros { get; set; }

	public int Version { get; set; }

	public int Revision { get; set; }

	public int Type { get; set; }

	public int Count { get; set; } = 8720;

	public double UidBase { get; set; }

	public int FontDictionaryArray { get; set; }

	public int FontDictionarySelect { get; set; }

	public string FontName { get; set; }
}
