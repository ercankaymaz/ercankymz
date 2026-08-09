using PdfSharp.Drawing;

namespace PdfSharp.Fonts;

internal class FontResolvingOptions
{
	public XFontStyle FontStyle;

	public bool OverrideStyleSimulations;

	public XStyleSimulations StyleSimulations;

	public bool IsBold => (FontStyle & XFontStyle.Bold) == XFontStyle.Bold;

	public bool IsItalic => (FontStyle & XFontStyle.Italic) == XFontStyle.Italic;

	public bool IsBoldItalic => (FontStyle & XFontStyle.BoldItalic) == XFontStyle.BoldItalic;

	public bool MustSimulateBold => (StyleSimulations & XStyleSimulations.BoldSimulation) == XStyleSimulations.BoldSimulation;

	public bool MustSimulateItalic => (StyleSimulations & XStyleSimulations.ItalicSimulation) == XStyleSimulations.ItalicSimulation;

	public FontResolvingOptions(XFontStyle fontStyle)
	{
		FontStyle = fontStyle;
	}

	public FontResolvingOptions(XFontStyle fontStyle, XStyleSimulations styleSimulations)
	{
		FontStyle = fontStyle;
		OverrideStyleSimulations = true;
		StyleSimulations = styleSimulations;
	}
}
