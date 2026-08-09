using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IPalette
{
	KryptonColorTable ColorTable { get; }

	event EventHandler<PaletteLayoutEventArgs> PalettePaint;

	event EventHandler AllowFormChromeChanged;

	event EventHandler BasePaletteChanged;

	event EventHandler BaseRendererChanged;

	event EventHandler ButtonSpecChanged;

	InheritBool GetAllowFormChrome();

	IRenderer GetRenderer();

	InheritBool GetBackDraw(PaletteBackStyle style, PaletteState state);

	PaletteGraphicsHint GetBackGraphicsHint(PaletteBackStyle style, PaletteState state);

	Color GetBackColor1(PaletteBackStyle style, PaletteState state);

	Color GetBackColor2(PaletteBackStyle style, PaletteState state);

	PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state);

	PaletteRectangleAlign GetBackColorAlign(PaletteBackStyle style, PaletteState state);

	float GetBackColorAngle(PaletteBackStyle style, PaletteState state);

	Image GetBackImage(PaletteBackStyle style, PaletteState state);

	PaletteImageStyle GetBackImageStyle(PaletteBackStyle style, PaletteState state);

	PaletteRectangleAlign GetBackImageAlign(PaletteBackStyle style, PaletteState state);

	InheritBool GetBorderDraw(PaletteBorderStyle style, PaletteState state);

	PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state);

	PaletteGraphicsHint GetBorderGraphicsHint(PaletteBorderStyle style, PaletteState state);

	Color GetBorderColor1(PaletteBorderStyle style, PaletteState state);

	Color GetBorderColor2(PaletteBorderStyle style, PaletteState state);

	PaletteColorStyle GetBorderColorStyle(PaletteBorderStyle style, PaletteState state);

	PaletteRectangleAlign GetBorderColorAlign(PaletteBorderStyle style, PaletteState state);

	float GetBorderColorAngle(PaletteBorderStyle style, PaletteState state);

	int GetBorderWidth(PaletteBorderStyle style, PaletteState state);

	int GetBorderRounding(PaletteBorderStyle style, PaletteState state);

	Image GetBorderImage(PaletteBorderStyle style, PaletteState state);

	PaletteImageStyle GetBorderImageStyle(PaletteBorderStyle style, PaletteState state);

	PaletteRectangleAlign GetBorderImageAlign(PaletteBorderStyle style, PaletteState state);

	InheritBool GetContentDraw(PaletteContentStyle style, PaletteState state);

	InheritBool GetContentDrawFocus(PaletteContentStyle style, PaletteState state);

	PaletteRelativeAlign GetContentImageH(PaletteContentStyle style, PaletteState state);

	PaletteRelativeAlign GetContentImageV(PaletteContentStyle style, PaletteState state);

	PaletteImageEffect GetContentImageEffect(PaletteContentStyle style, PaletteState state);

	Color GetContentImageColorMap(PaletteContentStyle style, PaletteState state);

	Color GetContentImageColorTo(PaletteContentStyle style, PaletteState state);

	Font GetContentShortTextFont(PaletteContentStyle style, PaletteState state);

	Font GetContentShortTextNewFont(PaletteContentStyle style, PaletteState state);

	PaletteTextHint GetContentShortTextHint(PaletteContentStyle style, PaletteState state);

	InheritBool GetContentShortTextMultiLine(PaletteContentStyle style, PaletteState state);

	PaletteTextTrim GetContentShortTextTrim(PaletteContentStyle style, PaletteState state);

	PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteContentStyle style, PaletteState state);

	PaletteRelativeAlign GetContentShortTextH(PaletteContentStyle style, PaletteState state);

	PaletteRelativeAlign GetContentShortTextV(PaletteContentStyle style, PaletteState state);

	PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteContentStyle style, PaletteState state);

	Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state);

	Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state);

	PaletteColorStyle GetContentShortTextColorStyle(PaletteContentStyle style, PaletteState state);

	PaletteRectangleAlign GetContentShortTextColorAlign(PaletteContentStyle style, PaletteState state);

	float GetContentShortTextColorAngle(PaletteContentStyle style, PaletteState state);

	Image GetContentShortTextImage(PaletteContentStyle style, PaletteState state);

	PaletteImageStyle GetContentShortTextImageStyle(PaletteContentStyle style, PaletteState state);

	PaletteRectangleAlign GetContentShortTextImageAlign(PaletteContentStyle style, PaletteState state);

	Font GetContentLongTextFont(PaletteContentStyle style, PaletteState state);

	Font GetContentLongTextNewFont(PaletteContentStyle style, PaletteState state);

	PaletteTextHint GetContentLongTextHint(PaletteContentStyle style, PaletteState state);

	PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteContentStyle style, PaletteState state);

	InheritBool GetContentLongTextMultiLine(PaletteContentStyle style, PaletteState state);

	PaletteTextTrim GetContentLongTextTrim(PaletteContentStyle style, PaletteState state);

	PaletteRelativeAlign GetContentLongTextH(PaletteContentStyle style, PaletteState state);

	PaletteRelativeAlign GetContentLongTextV(PaletteContentStyle style, PaletteState state);

	PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteContentStyle style, PaletteState state);

	Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state);

	Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state);

	PaletteColorStyle GetContentLongTextColorStyle(PaletteContentStyle style, PaletteState state);

	PaletteRectangleAlign GetContentLongTextColorAlign(PaletteContentStyle style, PaletteState state);

	float GetContentLongTextColorAngle(PaletteContentStyle style, PaletteState state);

	Image GetContentLongTextImage(PaletteContentStyle style, PaletteState state);

	PaletteImageStyle GetContentLongTextImageStyle(PaletteContentStyle style, PaletteState state);

	PaletteRectangleAlign GetContentLongTextImageAlign(PaletteContentStyle style, PaletteState state);

	Padding GetContentPadding(PaletteContentStyle style, PaletteState state);

	int GetContentAdjacentGap(PaletteContentStyle style, PaletteState state);

	int GetMetricInt(PaletteState state, PaletteMetricInt metric);

	InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric);

	Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric);

	Image GetTreeViewImage(bool expanded);

	Image GetCheckBoxImage(bool enabled, CheckState checkState, bool tracking, bool pressed);

	Image GetRadioButtonImage(bool enabled, bool checkState, bool tracking, bool pressed);

	Image GetDropDownButtonImage(PaletteState state);

	Image GetContextMenuCheckedImage();

	Image GetContextMenuIndeterminateImage();

	Image GetContextMenuSubMenuImage();

	Image GetGalleryButtonImage(PaletteRibbonGalleryButton button, PaletteState state);

	Icon GetButtonSpecIcon(PaletteButtonSpecStyle style);

	Image GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state);

	Color GetButtonSpecImageTransparentColor(PaletteButtonSpecStyle style);

	string GetButtonSpecShortText(PaletteButtonSpecStyle style);

	string GetButtonSpecLongText(PaletteButtonSpecStyle style);

	string GetButtonSpecToolTipTitle(PaletteButtonSpecStyle style);

	Color GetButtonSpecColorMap(PaletteButtonSpecStyle style);

	PaletteButtonStyle GetButtonSpecStyle(PaletteButtonSpecStyle style);

	HeaderLocation GetButtonSpecLocation(PaletteButtonSpecStyle style);

	PaletteRelativeEdgeAlign GetButtonSpecEdge(PaletteButtonSpecStyle style);

	PaletteButtonOrientation GetButtonSpecOrientation(PaletteButtonSpecStyle style);

	PaletteRibbonShape GetRibbonShape();

	PaletteRelativeAlign GetRibbonContextTextAlign(PaletteState state);

	Font GetRibbonContextTextFont(PaletteState state);

	Color GetRibbonContextTextColor(PaletteState state);

	Color GetRibbonDisabledDark(PaletteState state);

	Color GetRibbonDisabledLight(PaletteState state);

	Color GetRibbonDropArrowLight(PaletteState state);

	Color GetRibbonDropArrowDark(PaletteState state);

	Color GetRibbonGroupDialogDark(PaletteState state);

	Color GetRibbonGroupDialogLight(PaletteState state);

	Color GetRibbonGroupSeparatorDark(PaletteState state);

	Color GetRibbonGroupSeparatorLight(PaletteState state);

	Color GetRibbonMinimizeBarDark(PaletteState state);

	Color GetRibbonMinimizeBarLight(PaletteState state);

	Color GetRibbonTabSeparatorColor(PaletteState state);

	Color GetRibbonTabSeparatorContextColor(PaletteState state);

	Font GetRibbonTextFont(PaletteState state);

	PaletteTextHint GetRibbonTextHint(PaletteState state);

	Color GetRibbonQATButtonDark(PaletteState state);

	Color GetRibbonQATButtonLight(PaletteState state);

	PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteRibbonBackStyle style, PaletteState state);

	Color GetRibbonBackColor1(PaletteRibbonBackStyle style, PaletteState state);

	Color GetRibbonBackColor2(PaletteRibbonBackStyle style, PaletteState state);

	Color GetRibbonBackColor3(PaletteRibbonBackStyle style, PaletteState state);

	Color GetRibbonBackColor4(PaletteRibbonBackStyle style, PaletteState state);

	Color GetRibbonBackColor5(PaletteRibbonBackStyle style, PaletteState state);

	Color GetRibbonTextColor(PaletteRibbonTextStyle style, PaletteState state);

	Color GetElementColor1(PaletteElement element, PaletteState state);

	Color GetElementColor2(PaletteElement element, PaletteState state);

	Color GetElementColor3(PaletteElement element, PaletteState state);

	Color GetElementColor4(PaletteElement element, PaletteState state);

	Color GetElementColor5(PaletteElement element, PaletteState state);

	PaletteDragFeedback GetDragDropFeedback();

	Color GetDragDropSolidBack();

	Color GetDragDropSolidBorder();

	float GetDragDropSolidOpacity();

	Color GetDragDropDockBack();

	Color GetDragDropDockBorder();

	Color GetDragDropDockActive();

	Color GetDragDropDockInactive();
}
