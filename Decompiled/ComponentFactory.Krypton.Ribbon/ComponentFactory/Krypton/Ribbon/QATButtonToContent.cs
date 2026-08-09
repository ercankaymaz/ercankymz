#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class QATButtonToContent : IPaletteContent
{
	private IQuickAccessToolbarButton _qatButton;

	public QATButtonToContent(IQuickAccessToolbarButton qatButton)
	{
		Debug.Assert(qatButton != null);
		_qatButton = qatButton;
	}

	public InheritBool GetContentDraw(PaletteState state)
	{
		return InheritBool.True;
	}

	public InheritBool GetContentDrawFocus(PaletteState state)
	{
		return InheritBool.False;
	}

	public PaletteRelativeAlign GetContentImageH(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public PaletteRelativeAlign GetContentImageV(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public PaletteImageEffect GetContentImageEffect(PaletteState state)
	{
		if (state != PaletteState.Disabled)
		{
			return PaletteImageEffect.Normal;
		}
		return PaletteImageEffect.Disabled;
	}

	public Color GetContentImageColorMap(PaletteState state)
	{
		return Color.Empty;
	}

	public Color GetContentImageColorTo(PaletteState state)
	{
		return Color.Empty;
	}

	public Font GetContentShortTextFont(PaletteState state)
	{
		return null;
	}

	public Font GetContentShortTextNewFont(PaletteState state)
	{
		return null;
	}

	public PaletteTextHint GetContentShortTextHint(PaletteState state)
	{
		return PaletteTextHint.SystemDefault;
	}

	public PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state)
	{
		return PaletteTextHotkeyPrefix.None;
	}

	public InheritBool GetContentShortTextMultiLine(PaletteState state)
	{
		return InheritBool.False;
	}

	public PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
		return PaletteTextTrim.Character;
	}

	public PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public PaletteRelativeAlign GetContentShortTextV(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteState state)
	{
		return PaletteRelativeAlign.Near;
	}

	public Color GetContentShortTextColor1(PaletteState state)
	{
		return Color.Empty;
	}

	public Color GetContentShortTextColor2(PaletteState state)
	{
		return Color.Empty;
	}

	public PaletteColorStyle GetContentShortTextColorStyle(PaletteState state)
	{
		return PaletteColorStyle.Solid;
	}

	public PaletteRectangleAlign GetContentShortTextColorAlign(PaletteState state)
	{
		return PaletteRectangleAlign.Local;
	}

	public float GetContentShortTextColorAngle(PaletteState state)
	{
		return 0f;
	}

	public Image GetContentShortTextImage(PaletteState state)
	{
		return null;
	}

	public PaletteImageStyle GetContentShortTextImageStyle(PaletteState state)
	{
		return PaletteImageStyle.Stretch;
	}

	public PaletteRectangleAlign GetContentShortTextImageAlign(PaletteState state)
	{
		return PaletteRectangleAlign.Local;
	}

	public Font GetContentLongTextFont(PaletteState state)
	{
		return null;
	}

	public Font GetContentLongTextNewFont(PaletteState state)
	{
		return null;
	}

	public PaletteTextHint GetContentLongTextHint(PaletteState state)
	{
		return PaletteTextHint.SystemDefault;
	}

	public InheritBool GetContentLongTextMultiLine(PaletteState state)
	{
		return InheritBool.False;
	}

	public PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		return PaletteTextTrim.Character;
	}

	public PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteState state)
	{
		return PaletteTextHotkeyPrefix.None;
	}

	public PaletteRelativeAlign GetContentLongTextH(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public PaletteRelativeAlign GetContentLongTextV(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteState state)
	{
		return PaletteRelativeAlign.Near;
	}

	public Color GetContentLongTextColor1(PaletteState state)
	{
		return Color.Empty;
	}

	public Color GetContentLongTextColor2(PaletteState state)
	{
		return Color.Empty;
	}

	public PaletteColorStyle GetContentLongTextColorStyle(PaletteState state)
	{
		return PaletteColorStyle.Solid;
	}

	public PaletteRectangleAlign GetContentLongTextColorAlign(PaletteState state)
	{
		return PaletteRectangleAlign.Local;
	}

	public float GetContentLongTextColorAngle(PaletteState state)
	{
		return 0f;
	}

	public Image GetContentLongTextImage(PaletteState state)
	{
		return null;
	}

	public PaletteImageStyle GetContentLongTextImageStyle(PaletteState state)
	{
		return PaletteImageStyle.Stretch;
	}

	public PaletteRectangleAlign GetContentLongTextImageAlign(PaletteState state)
	{
		return PaletteRectangleAlign.Local;
	}

	public Padding GetContentPadding(PaletteState state)
	{
		return Padding.Empty;
	}

	public int GetContentAdjacentGap(PaletteState state)
	{
		return 3;
	}

	public PaletteContentStyle GetContentStyle()
	{
		return PaletteContentStyle.LabelNormalPanel;
	}
}
