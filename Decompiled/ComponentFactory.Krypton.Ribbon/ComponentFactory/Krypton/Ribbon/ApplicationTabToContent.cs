using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ApplicationTabToContent : RibbonToContent
{
	private KryptonRibbon _ribbon;

	public ApplicationTabToContent(KryptonRibbon ribbon, PaletteRibbonGeneral ribbonGeneral)
		: base(ribbonGeneral)
	{
		_ribbon = ribbon;
	}

	public override Color GetContentShortTextColor1(PaletteState state)
	{
		return _ribbon.RibbonAppButton.AppButtonTextColor;
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		return _ribbon.RibbonAppButton.AppButtonTextColor;
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		return _ribbon.RibbonAppButton.AppButtonTextColor;
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		return _ribbon.RibbonAppButton.AppButtonTextColor;
	}
}
