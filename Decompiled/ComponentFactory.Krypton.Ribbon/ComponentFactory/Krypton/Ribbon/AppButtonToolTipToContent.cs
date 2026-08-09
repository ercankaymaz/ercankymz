#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class AppButtonToolTipToContent : IContentValues
{
	private KryptonRibbon _ribbon;

	public bool HasContent => GetImage(PaletteState.Normal) != null || !string.IsNullOrEmpty(GetShortText()) || !string.IsNullOrEmpty(GetLongText());

	public AppButtonToolTipToContent(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
	}

	public Image GetImage(PaletteState state)
	{
		return _ribbon.RibbonAppButton.AppButtonToolTipImage;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return _ribbon.RibbonAppButton.AppButtonToolTipImageTransparentColor;
	}

	public string GetShortText()
	{
		return _ribbon.RibbonAppButton.AppButtonToolTipTitle;
	}

	public string GetLongText()
	{
		return _ribbon.RibbonAppButton.AppButtonToolTipBody;
	}
}
