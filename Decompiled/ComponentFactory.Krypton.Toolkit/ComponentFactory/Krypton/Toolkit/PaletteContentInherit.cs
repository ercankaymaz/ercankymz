using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class PaletteContentInherit : GlobalId, IPaletteContent
{
	public abstract InheritBool GetContentDraw(PaletteState state);

	public abstract InheritBool GetContentDrawFocus(PaletteState state);

	public abstract PaletteRelativeAlign GetContentImageH(PaletteState state);

	public abstract PaletteRelativeAlign GetContentImageV(PaletteState state);

	public abstract PaletteImageEffect GetContentImageEffect(PaletteState state);

	public abstract Color GetContentImageColorMap(PaletteState state);

	public abstract Color GetContentImageColorTo(PaletteState state);

	public abstract Font GetContentShortTextFont(PaletteState state);

	public abstract Font GetContentShortTextNewFont(PaletteState state);

	public abstract PaletteTextHint GetContentShortTextHint(PaletteState state);

	public abstract PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state);

	public abstract InheritBool GetContentShortTextMultiLine(PaletteState state);

	public abstract PaletteTextTrim GetContentShortTextTrim(PaletteState state);

	public abstract PaletteRelativeAlign GetContentShortTextH(PaletteState state);

	public abstract PaletteRelativeAlign GetContentShortTextV(PaletteState state);

	public abstract PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteState state);

	public abstract Color GetContentShortTextColor1(PaletteState state);

	public abstract Color GetContentShortTextColor2(PaletteState state);

	public abstract PaletteColorStyle GetContentShortTextColorStyle(PaletteState state);

	public abstract PaletteRectangleAlign GetContentShortTextColorAlign(PaletteState state);

	public abstract float GetContentShortTextColorAngle(PaletteState state);

	public abstract Image GetContentShortTextImage(PaletteState state);

	public abstract PaletteImageStyle GetContentShortTextImageStyle(PaletteState state);

	public abstract PaletteRectangleAlign GetContentShortTextImageAlign(PaletteState state);

	public abstract Font GetContentLongTextFont(PaletteState state);

	public abstract Font GetContentLongTextNewFont(PaletteState state);

	public abstract PaletteTextHint GetContentLongTextHint(PaletteState state);

	public abstract PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteState state);

	public abstract InheritBool GetContentLongTextMultiLine(PaletteState state);

	public abstract PaletteTextTrim GetContentLongTextTrim(PaletteState state);

	public abstract PaletteRelativeAlign GetContentLongTextH(PaletteState state);

	public abstract PaletteRelativeAlign GetContentLongTextV(PaletteState state);

	public abstract PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteState state);

	public abstract Color GetContentLongTextColor1(PaletteState state);

	public abstract Color GetContentLongTextColor2(PaletteState state);

	public abstract PaletteColorStyle GetContentLongTextColorStyle(PaletteState state);

	public abstract PaletteRectangleAlign GetContentLongTextColorAlign(PaletteState state);

	public abstract float GetContentLongTextColorAngle(PaletteState state);

	public abstract Image GetContentLongTextImage(PaletteState state);

	public abstract PaletteImageStyle GetContentLongTextImageStyle(PaletteState state);

	public abstract PaletteRectangleAlign GetContentLongTextImageAlign(PaletteState state);

	public abstract Padding GetContentPadding(PaletteState state);

	public abstract int GetContentAdjacentGap(PaletteState state);

	public abstract PaletteContentStyle GetContentStyle();
}
