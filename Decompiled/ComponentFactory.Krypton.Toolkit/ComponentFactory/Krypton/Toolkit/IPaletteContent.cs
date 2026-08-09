using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IPaletteContent
{
	InheritBool GetContentDraw(PaletteState state);

	InheritBool GetContentDrawFocus(PaletteState state);

	PaletteRelativeAlign GetContentImageH(PaletteState state);

	PaletteRelativeAlign GetContentImageV(PaletteState state);

	PaletteImageEffect GetContentImageEffect(PaletteState state);

	Color GetContentImageColorMap(PaletteState state);

	Color GetContentImageColorTo(PaletteState state);

	Font GetContentShortTextFont(PaletteState state);

	Font GetContentShortTextNewFont(PaletteState state);

	PaletteTextHint GetContentShortTextHint(PaletteState state);

	PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state);

	InheritBool GetContentShortTextMultiLine(PaletteState state);

	PaletteTextTrim GetContentShortTextTrim(PaletteState state);

	PaletteRelativeAlign GetContentShortTextH(PaletteState state);

	PaletteRelativeAlign GetContentShortTextV(PaletteState state);

	PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteState state);

	Color GetContentShortTextColor1(PaletteState state);

	Color GetContentShortTextColor2(PaletteState state);

	PaletteColorStyle GetContentShortTextColorStyle(PaletteState state);

	PaletteRectangleAlign GetContentShortTextColorAlign(PaletteState state);

	float GetContentShortTextColorAngle(PaletteState state);

	Image GetContentShortTextImage(PaletteState state);

	PaletteImageStyle GetContentShortTextImageStyle(PaletteState state);

	PaletteRectangleAlign GetContentShortTextImageAlign(PaletteState state);

	Font GetContentLongTextFont(PaletteState state);

	Font GetContentLongTextNewFont(PaletteState state);

	PaletteTextHint GetContentLongTextHint(PaletteState state);

	InheritBool GetContentLongTextMultiLine(PaletteState state);

	PaletteTextTrim GetContentLongTextTrim(PaletteState state);

	PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteState state);

	PaletteRelativeAlign GetContentLongTextH(PaletteState state);

	PaletteRelativeAlign GetContentLongTextV(PaletteState state);

	PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteState state);

	Color GetContentLongTextColor1(PaletteState state);

	Color GetContentLongTextColor2(PaletteState state);

	PaletteColorStyle GetContentLongTextColorStyle(PaletteState state);

	PaletteRectangleAlign GetContentLongTextColorAlign(PaletteState state);

	float GetContentLongTextColorAngle(PaletteState state);

	Image GetContentLongTextImage(PaletteState state);

	PaletteImageStyle GetContentLongTextImageStyle(PaletteState state);

	PaletteRectangleAlign GetContentLongTextImageAlign(PaletteState state);

	Padding GetContentPadding(PaletteState state);

	int GetContentAdjacentGap(PaletteState state);

	PaletteContentStyle GetContentStyle();
}
