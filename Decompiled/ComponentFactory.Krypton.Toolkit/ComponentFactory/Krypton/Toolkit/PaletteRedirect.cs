using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirect : GlobalId, IPalette
{
	private IPalette _target;

	public virtual IPalette Target
	{
		get
		{
			return _target;
		}
		set
		{
			_target = value;
		}
	}

	public virtual KryptonColorTable ColorTable => _target.ColorTable;

	public event EventHandler<PaletteLayoutEventArgs> PalettePaint;

	public event EventHandler AllowFormChromeChanged;

	public event EventHandler BasePaletteChanged;

	public event EventHandler BaseRendererChanged;

	public event EventHandler ButtonSpecChanged;

	public PaletteRedirect()
		: this(null)
	{
	}

	public PaletteRedirect(IPalette target)
	{
		_target = target;
	}

	public virtual InheritBool GetAllowFormChrome()
	{
		return _target.GetAllowFormChrome();
	}

	public virtual IRenderer GetRenderer()
	{
		return _target.GetRenderer();
	}

	public virtual InheritBool GetBackDraw(PaletteBackStyle style, PaletteState state)
	{
		return _target.GetBackDraw(style, state);
	}

	public virtual PaletteGraphicsHint GetBackGraphicsHint(PaletteBackStyle style, PaletteState state)
	{
		return _target.GetBackGraphicsHint(style, state);
	}

	public virtual Color GetBackColor1(PaletteBackStyle style, PaletteState state)
	{
		return _target.GetBackColor1(style, state);
	}

	public virtual Color GetBackColor2(PaletteBackStyle style, PaletteState state)
	{
		return _target.GetBackColor2(style, state);
	}

	public virtual PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
	{
		return _target.GetBackColorStyle(style, state);
	}

	public virtual PaletteRectangleAlign GetBackColorAlign(PaletteBackStyle style, PaletteState state)
	{
		return _target.GetBackColorAlign(style, state);
	}

	public virtual float GetBackColorAngle(PaletteBackStyle style, PaletteState state)
	{
		return _target.GetBackColorAngle(style, state);
	}

	public virtual Image GetBackImage(PaletteBackStyle style, PaletteState state)
	{
		return _target.GetBackImage(style, state);
	}

	public virtual PaletteImageStyle GetBackImageStyle(PaletteBackStyle style, PaletteState state)
	{
		return _target.GetBackImageStyle(style, state);
	}

	public virtual PaletteRectangleAlign GetBackImageAlign(PaletteBackStyle style, PaletteState state)
	{
		return _target.GetBackImageAlign(style, state);
	}

	public virtual InheritBool GetBorderDraw(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderDraw(style, state);
	}

	public virtual PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderDrawBorders(style, state);
	}

	public virtual PaletteGraphicsHint GetBorderGraphicsHint(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderGraphicsHint(style, state);
	}

	public virtual Color GetBorderColor1(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderColor1(style, state);
	}

	public virtual Color GetBorderColor2(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderColor2(style, state);
	}

	public virtual PaletteColorStyle GetBorderColorStyle(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderColorStyle(style, state);
	}

	public virtual PaletteRectangleAlign GetBorderColorAlign(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderColorAlign(style, state);
	}

	public virtual float GetBorderColorAngle(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderColorAngle(style, state);
	}

	public virtual int GetBorderWidth(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderWidth(style, state);
	}

	public virtual int GetBorderRounding(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderRounding(style, state);
	}

	public virtual Image GetBorderImage(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderImage(style, state);
	}

	public virtual PaletteImageStyle GetBorderImageStyle(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderImageStyle(style, state);
	}

	public virtual PaletteRectangleAlign GetBorderImageAlign(PaletteBorderStyle style, PaletteState state)
	{
		return _target.GetBorderImageAlign(style, state);
	}

	public virtual InheritBool GetContentDraw(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentDraw(style, state);
	}

	public virtual InheritBool GetContentDrawFocus(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentDrawFocus(style, state);
	}

	public virtual PaletteRelativeAlign GetContentImageH(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentImageH(style, state);
	}

	public virtual PaletteRelativeAlign GetContentImageV(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentImageV(style, state);
	}

	public virtual PaletteImageEffect GetContentImageEffect(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentImageEffect(style, state);
	}

	public virtual Color GetContentImageColorMap(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentImageColorMap(style, state);
	}

	public virtual Color GetContentImageColorTo(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentImageColorTo(style, state);
	}

	public virtual Font GetContentShortTextFont(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextFont(style, state);
	}

	public virtual Font GetContentShortTextNewFont(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextNewFont(style, state);
	}

	public virtual PaletteTextHint GetContentShortTextHint(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextHint(style, state);
	}

	public virtual PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextPrefix(style, state);
	}

	public virtual InheritBool GetContentShortTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextMultiLine(style, state);
	}

	public virtual PaletteTextTrim GetContentShortTextTrim(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextTrim(style, state);
	}

	public virtual PaletteRelativeAlign GetContentShortTextH(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextH(style, state);
	}

	public virtual PaletteRelativeAlign GetContentShortTextV(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextV(style, state);
	}

	public virtual PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextMultiLineH(style, state);
	}

	public virtual Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextColor1(style, state);
	}

	public virtual Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextColor2(style, state);
	}

	public virtual PaletteColorStyle GetContentShortTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextColorStyle(style, state);
	}

	public virtual PaletteRectangleAlign GetContentShortTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextColorAlign(style, state);
	}

	public virtual float GetContentShortTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextColorAngle(style, state);
	}

	public virtual Image GetContentShortTextImage(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextImage(style, state);
	}

	public virtual PaletteImageStyle GetContentShortTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextImageStyle(style, state);
	}

	public virtual PaletteRectangleAlign GetContentShortTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentShortTextImageAlign(style, state);
	}

	public virtual Font GetContentLongTextFont(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextFont(style, state);
	}

	public virtual Font GetContentLongTextNewFont(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextNewFont(style, state);
	}

	public virtual PaletteTextHint GetContentLongTextHint(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextHint(style, state);
	}

	public virtual InheritBool GetContentLongTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextMultiLine(style, state);
	}

	public virtual PaletteTextTrim GetContentLongTextTrim(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextTrim(style, state);
	}

	public virtual PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextPrefix(style, state);
	}

	public virtual PaletteRelativeAlign GetContentLongTextH(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextH(style, state);
	}

	public virtual PaletteRelativeAlign GetContentLongTextV(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextV(style, state);
	}

	public virtual PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextMultiLineH(style, state);
	}

	public virtual Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextColor1(style, state);
	}

	public virtual Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextColor2(style, state);
	}

	public virtual PaletteColorStyle GetContentLongTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextColorStyle(style, state);
	}

	public virtual PaletteRectangleAlign GetContentLongTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextColorAlign(style, state);
	}

	public virtual float GetContentLongTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextColorAngle(style, state);
	}

	public virtual Image GetContentLongTextImage(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextImage(style, state);
	}

	public virtual PaletteImageStyle GetContentLongTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextImageStyle(style, state);
	}

	public virtual PaletteRectangleAlign GetContentLongTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentLongTextImageAlign(style, state);
	}

	public virtual Padding GetContentPadding(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentPadding(style, state);
	}

	public virtual int GetContentAdjacentGap(PaletteContentStyle style, PaletteState state)
	{
		return _target.GetContentAdjacentGap(style, state);
	}

	public virtual int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		return _target.GetMetricInt(state, metric);
	}

	public virtual InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		return _target.GetMetricBool(state, metric);
	}

	public virtual Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		return _target.GetMetricPadding(state, metric);
	}

	public virtual Image GetTreeViewImage(bool expanded)
	{
		return _target.GetTreeViewImage(expanded);
	}

	public virtual Image GetCheckBoxImage(bool enabled, CheckState checkState, bool tracking, bool pressed)
	{
		return _target.GetCheckBoxImage(enabled, checkState, tracking, pressed);
	}

	public virtual Image GetRadioButtonImage(bool enabled, bool checkState, bool tracking, bool pressed)
	{
		return _target.GetRadioButtonImage(enabled, checkState, tracking, pressed);
	}

	public virtual Image GetDropDownButtonImage(PaletteState state)
	{
		return _target.GetDropDownButtonImage(state);
	}

	public virtual Image GetContextMenuCheckedImage()
	{
		return _target.GetContextMenuCheckedImage();
	}

	public virtual Image GetContextMenuIndeterminateImage()
	{
		return _target.GetContextMenuIndeterminateImage();
	}

	public virtual Image GetContextMenuSubMenuImage()
	{
		return _target.GetContextMenuSubMenuImage();
	}

	public virtual Image GetGalleryButtonImage(PaletteRibbonGalleryButton button, PaletteState state)
	{
		return _target.GetGalleryButtonImage(button, state);
	}

	public virtual Icon GetButtonSpecIcon(PaletteButtonSpecStyle style)
	{
		return _target.GetButtonSpecIcon(style);
	}

	public virtual Image GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state)
	{
		return _target.GetButtonSpecImage(style, state);
	}

	public virtual Color GetButtonSpecImageTransparentColor(PaletteButtonSpecStyle style)
	{
		return _target.GetButtonSpecImageTransparentColor(style);
	}

	public virtual string GetButtonSpecShortText(PaletteButtonSpecStyle style)
	{
		return _target.GetButtonSpecShortText(style);
	}

	public virtual string GetButtonSpecLongText(PaletteButtonSpecStyle style)
	{
		return _target.GetButtonSpecLongText(style);
	}

	public virtual string GetButtonSpecToolTipTitle(PaletteButtonSpecStyle style)
	{
		return _target.GetButtonSpecToolTipTitle(style);
	}

	public virtual Color GetButtonSpecColorMap(PaletteButtonSpecStyle style)
	{
		return _target.GetButtonSpecColorMap(style);
	}

	public virtual PaletteButtonStyle GetButtonSpecStyle(PaletteButtonSpecStyle style)
	{
		return _target.GetButtonSpecStyle(style);
	}

	public virtual HeaderLocation GetButtonSpecLocation(PaletteButtonSpecStyle style)
	{
		return _target.GetButtonSpecLocation(style);
	}

	public virtual PaletteRelativeEdgeAlign GetButtonSpecEdge(PaletteButtonSpecStyle style)
	{
		return _target.GetButtonSpecEdge(style);
	}

	public virtual PaletteButtonOrientation GetButtonSpecOrientation(PaletteButtonSpecStyle style)
	{
		return _target.GetButtonSpecOrientation(style);
	}

	public virtual PaletteRibbonShape GetRibbonShape()
	{
		return _target.GetRibbonShape();
	}

	public virtual PaletteRelativeAlign GetRibbonContextTextAlign(PaletteState state)
	{
		return _target.GetRibbonContextTextAlign(state);
	}

	public virtual Font GetRibbonContextTextFont(PaletteState state)
	{
		return _target.GetRibbonContextTextFont(state);
	}

	public virtual Color GetRibbonContextTextColor(PaletteState state)
	{
		return _target.GetRibbonContextTextColor(state);
	}

	public virtual Color GetRibbonDisabledDark(PaletteState state)
	{
		return _target.GetRibbonDisabledDark(state);
	}

	public virtual Color GetRibbonDisabledLight(PaletteState state)
	{
		return _target.GetRibbonDisabledLight(state);
	}

	public virtual Color GetRibbonDropArrowLight(PaletteState state)
	{
		return _target.GetRibbonDropArrowLight(state);
	}

	public virtual Color GetRibbonDropArrowDark(PaletteState state)
	{
		return _target.GetRibbonDropArrowDark(state);
	}

	public virtual Color GetRibbonGroupDialogDark(PaletteState state)
	{
		return _target.GetRibbonGroupDialogDark(state);
	}

	public virtual Color GetRibbonGroupDialogLight(PaletteState state)
	{
		return _target.GetRibbonGroupDialogLight(state);
	}

	public virtual Color GetRibbonGroupSeparatorDark(PaletteState state)
	{
		return _target.GetRibbonGroupSeparatorDark(state);
	}

	public virtual Color GetRibbonGroupSeparatorLight(PaletteState state)
	{
		return _target.GetRibbonGroupSeparatorLight(state);
	}

	public virtual Color GetRibbonMinimizeBarDark(PaletteState state)
	{
		return _target.GetRibbonMinimizeBarDark(state);
	}

	public virtual Color GetRibbonMinimizeBarLight(PaletteState state)
	{
		return _target.GetRibbonMinimizeBarLight(state);
	}

	public virtual Color GetRibbonTabSeparatorColor(PaletteState state)
	{
		return _target.GetRibbonTabSeparatorColor(state);
	}

	public virtual Color GetRibbonTabSeparatorContextColor(PaletteState state)
	{
		return _target.GetRibbonTabSeparatorContextColor(state);
	}

	public virtual Font GetRibbonTextFont(PaletteState state)
	{
		return _target.GetRibbonTextFont(state);
	}

	public virtual PaletteTextHint GetRibbonTextHint(PaletteState state)
	{
		return _target.GetRibbonTextHint(state);
	}

	public virtual Color GetRibbonQATButtonDark(PaletteState state)
	{
		return _target.GetRibbonQATButtonDark(state);
	}

	public virtual Color GetRibbonQATButtonLight(PaletteState state)
	{
		return _target.GetRibbonQATButtonLight(state);
	}

	public virtual PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteRibbonBackStyle style, PaletteState state)
	{
		return _target.GetRibbonBackColorStyle(style, state);
	}

	public virtual Color GetRibbonBackColor1(PaletteRibbonBackStyle style, PaletteState state)
	{
		return _target.GetRibbonBackColor1(style, state);
	}

	public virtual Color GetRibbonBackColor2(PaletteRibbonBackStyle style, PaletteState state)
	{
		return _target.GetRibbonBackColor2(style, state);
	}

	public virtual Color GetRibbonBackColor3(PaletteRibbonBackStyle style, PaletteState state)
	{
		return _target.GetRibbonBackColor3(style, state);
	}

	public virtual Color GetRibbonBackColor4(PaletteRibbonBackStyle style, PaletteState state)
	{
		return _target.GetRibbonBackColor4(style, state);
	}

	public virtual Color GetRibbonBackColor5(PaletteRibbonBackStyle style, PaletteState state)
	{
		return _target.GetRibbonBackColor5(style, state);
	}

	public virtual Color GetRibbonTextColor(PaletteRibbonTextStyle style, PaletteState state)
	{
		return _target.GetRibbonTextColor(style, state);
	}

	public virtual Color GetElementColor1(PaletteElement element, PaletteState state)
	{
		return _target.GetElementColor1(element, state);
	}

	public virtual Color GetElementColor2(PaletteElement element, PaletteState state)
	{
		return _target.GetElementColor2(element, state);
	}

	public virtual Color GetElementColor3(PaletteElement element, PaletteState state)
	{
		return _target.GetElementColor3(element, state);
	}

	public virtual Color GetElementColor4(PaletteElement element, PaletteState state)
	{
		return _target.GetElementColor4(element, state);
	}

	public virtual Color GetElementColor5(PaletteElement element, PaletteState state)
	{
		return _target.GetElementColor5(element, state);
	}

	public virtual PaletteDragFeedback GetDragDropFeedback()
	{
		return _target.GetDragDropFeedback();
	}

	public virtual Color GetDragDropSolidBack()
	{
		return _target.GetDragDropSolidBack();
	}

	public virtual Color GetDragDropSolidBorder()
	{
		return _target.GetDragDropSolidBack();
	}

	public virtual float GetDragDropSolidOpacity()
	{
		return _target.GetDragDropSolidOpacity();
	}

	public virtual Color GetDragDropDockBack()
	{
		return _target.GetDragDropDockBack();
	}

	public virtual Color GetDragDropDockBorder()
	{
		return _target.GetDragDropDockBorder();
	}

	public virtual Color GetDragDropDockActive()
	{
		return _target.GetDragDropDockActive();
	}

	public virtual Color GetDragDropDockInactive()
	{
		return _target.GetDragDropDockInactive();
	}

	protected virtual void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
	{
		if (this.PalettePaint != null)
		{
			this.PalettePaint(this, e);
		}
	}

	protected virtual void OnAllowFormChromeChanged(object sender, EventArgs e)
	{
		if (this.AllowFormChromeChanged != null)
		{
			this.AllowFormChromeChanged(this, e);
		}
	}

	protected virtual void OnBasePaletteChanged(object sender, EventArgs e)
	{
		if (this.BasePaletteChanged != null)
		{
			this.BasePaletteChanged(this, e);
		}
	}

	protected virtual void OnBaseRendererChanged(object sender, EventArgs e)
	{
		if (this.BaseRendererChanged != null)
		{
			this.BaseRendererChanged(this, e);
		}
	}

	protected virtual void OnButtonSpecChanged(object sender, EventArgs e)
	{
		if (this.ButtonSpecChanged != null)
		{
			this.ButtonSpecChanged(this, e);
		}
	}
}
