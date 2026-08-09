using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics;

public class CurrentFontState : IDeepCloneable<CurrentFontState>
{
	public bool FromExtendedGraphicsState { get; set; }

	public double CharacterSpacing { get; set; }

	public double WordSpacing { get; set; }

	public double HorizontalScaling { get; set; } = 100.0;

	public double Leading { get; set; }

	public NameToken FontName { get; set; }

	public double FontSize { get; set; }

	public TextRenderingMode TextRenderingMode { get; set; }

	public double Rise { get; set; }

	public bool Knockout { get; set; }

	public CurrentFontState DeepClone()
	{
		return new CurrentFontState
		{
			CharacterSpacing = CharacterSpacing,
			TextRenderingMode = TextRenderingMode,
			Rise = Rise,
			Leading = Leading,
			WordSpacing = WordSpacing,
			FontName = FontName,
			FontSize = FontSize,
			HorizontalScaling = HorizontalScaling,
			Knockout = Knockout
		};
	}
}
