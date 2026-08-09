using System;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteRedirectRibbonAeroOverride : PaletteRedirect
{
	private KryptonRibbon _ribbon;

	public PaletteRedirectRibbonAeroOverride(KryptonRibbon ribbon, PaletteRedirect redirect)
		: base(redirect)
	{
		_ribbon = ribbon;
	}

	public override Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
	{
		if (style == PaletteContentStyle.ButtonButtonSpec && state == PaletteState.Normal && _ribbon.CaptionArea.DrawCaptionOnComposition && _ribbon.RibbonShape == PaletteRibbonShape.Office2010)
		{
			return LightBackground(base.GetContentShortTextColor1(style, state));
		}
		return base.GetContentShortTextColor1(style, state);
	}

	public override Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
	{
		if (style == PaletteContentStyle.ButtonButtonSpec && state == PaletteState.Normal && _ribbon.CaptionArea.DrawCaptionOnComposition && _ribbon.RibbonShape == PaletteRibbonShape.Office2010)
		{
			return LightBackground(base.GetContentShortTextColor2(style, state));
		}
		return base.GetContentShortTextColor2(style, state);
	}

	public override Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
	{
		if (style == PaletteContentStyle.ButtonButtonSpec && state == PaletteState.Normal && _ribbon.CaptionArea.DrawCaptionOnComposition && _ribbon.RibbonShape == PaletteRibbonShape.Office2010)
		{
			return LightBackground(base.GetContentLongTextColor1(style, state));
		}
		return base.GetContentLongTextColor1(style, state);
	}

	public override Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state)
	{
		if (style == PaletteContentStyle.ButtonButtonSpec && state == PaletteState.Normal && _ribbon.CaptionArea.DrawCaptionOnComposition && _ribbon.RibbonShape == PaletteRibbonShape.Office2010)
		{
			return LightBackground(base.GetContentLongTextColor2(style, state));
		}
		return base.GetContentLongTextColor2(style, state);
	}

	private Color LightBackground(Color retColor)
	{
		return Color.FromArgb(Math.Min(retColor.R, (byte)60), Math.Min(retColor.G, (byte)60), Math.Min(retColor.B, (byte)60));
	}
}
