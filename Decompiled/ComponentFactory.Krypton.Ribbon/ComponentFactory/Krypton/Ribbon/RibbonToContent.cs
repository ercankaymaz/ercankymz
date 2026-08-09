#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class RibbonToContent : IPaletteContent
{
	private PaletteRibbonGeneral _ribbonGeneral;

	public PaletteRibbonGeneral RibbonGeneral => _ribbonGeneral;

	public RibbonToContent(PaletteRibbonGeneral ribbonGeneral)
	{
		Debug.Assert(ribbonGeneral != null);
		_ribbonGeneral = ribbonGeneral;
	}

	public virtual InheritBool GetContentDraw(PaletteState state)
	{
		return InheritBool.True;
	}

	public virtual InheritBool GetContentDrawFocus(PaletteState state)
	{
		return InheritBool.False;
	}

	public virtual PaletteRelativeAlign GetContentImageH(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public virtual PaletteRelativeAlign GetContentImageV(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public virtual PaletteImageEffect GetContentImageEffect(PaletteState state)
	{
		return PaletteImageEffect.Normal;
	}

	public virtual Color GetContentImageColorMap(PaletteState state)
	{
		return Color.Empty;
	}

	public virtual Color GetContentImageColorTo(PaletteState state)
	{
		return Color.Empty;
	}

	public virtual Font GetContentShortTextFont(PaletteState state)
	{
		return _ribbonGeneral.GetRibbonTextFont(state);
	}

	public Font GetContentShortTextNewFont(PaletteState state)
	{
		return _ribbonGeneral.GetRibbonTextFont(state);
	}

	public virtual PaletteTextHint GetContentShortTextHint(PaletteState state)
	{
		return _ribbonGeneral.GetRibbonTextHint(state);
	}

	public virtual PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state)
	{
		return PaletteTextHotkeyPrefix.None;
	}

	public virtual InheritBool GetContentShortTextMultiLine(PaletteState state)
	{
		return InheritBool.False;
	}

	public virtual PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
		return PaletteTextTrim.EllipsisCharacter;
	}

	public virtual PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public virtual PaletteRelativeAlign GetContentShortTextV(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public virtual PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteState state)
	{
		return PaletteRelativeAlign.Near;
	}

	public virtual Color GetContentShortTextColor1(PaletteState state)
	{
		return Color.Empty;
	}

	public virtual Color GetContentShortTextColor2(PaletteState state)
	{
		return Color.Empty;
	}

	public virtual PaletteColorStyle GetContentShortTextColorStyle(PaletteState state)
	{
		return PaletteColorStyle.Solid;
	}

	public virtual PaletteRectangleAlign GetContentShortTextColorAlign(PaletteState state)
	{
		return PaletteRectangleAlign.Local;
	}

	public virtual float GetContentShortTextColorAngle(PaletteState state)
	{
		return 0f;
	}

	public virtual Image GetContentShortTextImage(PaletteState state)
	{
		return null;
	}

	public virtual PaletteImageStyle GetContentShortTextImageStyle(PaletteState state)
	{
		return PaletteImageStyle.Stretch;
	}

	public virtual PaletteRectangleAlign GetContentShortTextImageAlign(PaletteState state)
	{
		return PaletteRectangleAlign.Local;
	}

	public virtual Font GetContentLongTextFont(PaletteState state)
	{
		return _ribbonGeneral.GetRibbonTextFont(state);
	}

	public virtual Font GetContentLongTextNewFont(PaletteState state)
	{
		return _ribbonGeneral.GetRibbonTextFont(state);
	}

	public virtual PaletteTextHint GetContentLongTextHint(PaletteState state)
	{
		return _ribbonGeneral.GetRibbonTextHint(state);
	}

	public virtual InheritBool GetContentLongTextMultiLine(PaletteState state)
	{
		return InheritBool.False;
	}

	public virtual PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		return PaletteTextTrim.EllipsisCharacter;
	}

	public virtual PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteState state)
	{
		return PaletteTextHotkeyPrefix.None;
	}

	public virtual PaletteRelativeAlign GetContentLongTextH(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public virtual PaletteRelativeAlign GetContentLongTextV(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public virtual PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteState state)
	{
		return PaletteRelativeAlign.Near;
	}

	public virtual Color GetContentLongTextColor1(PaletteState state)
	{
		return Color.Empty;
	}

	public virtual Color GetContentLongTextColor2(PaletteState state)
	{
		return Color.Empty;
	}

	public virtual PaletteColorStyle GetContentLongTextColorStyle(PaletteState state)
	{
		return PaletteColorStyle.Solid;
	}

	public virtual PaletteRectangleAlign GetContentLongTextColorAlign(PaletteState state)
	{
		return PaletteRectangleAlign.Local;
	}

	public virtual float GetContentLongTextColorAngle(PaletteState state)
	{
		return 0f;
	}

	public virtual Image GetContentLongTextImage(PaletteState state)
	{
		return null;
	}

	public virtual PaletteImageStyle GetContentLongTextImageStyle(PaletteState state)
	{
		return PaletteImageStyle.Stretch;
	}

	public virtual PaletteRectangleAlign GetContentLongTextImageAlign(PaletteState state)
	{
		return PaletteRectangleAlign.Local;
	}

	public virtual Padding GetContentPadding(PaletteState state)
	{
		return Padding.Empty;
	}

	public virtual int GetContentAdjacentGap(PaletteState state)
	{
		return 3;
	}

	public virtual PaletteContentStyle GetContentStyle()
	{
		return PaletteContentStyle.LabelNormalPanel;
	}
}
