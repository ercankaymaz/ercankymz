#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
public abstract class PaletteBase : Component, IPalette
{
	private float? _baseFontSize;

	private Padding? _inputControlPadding;

	private PaletteDragFeedback _dragFeedback;

	public virtual float BaseFontSize
	{
		get
		{
			if (!_baseFontSize.HasValue)
			{
				return SystemFonts.MenuFont.SizeInPoints;
			}
			return _baseFontSize.Value;
		}
		set
		{
			if ((value <= 0f && _baseFontSize.HasValue) || (value > 0f && (!_baseFontSize.HasValue || _baseFontSize.Value != value)))
			{
				if (value <= 0f)
				{
					_baseFontSize = null;
				}
				else
				{
					_baseFontSize = value;
				}
				DefineFonts();
				OnPalettePaint(this, new PaletteLayoutEventArgs(needLayout: true, needColorTable: false));
			}
		}
	}

	public abstract KryptonColorTable ColorTable { get; }

	protected virtual Padding InputControlPadding
	{
		get
		{
			if (!_inputControlPadding.HasValue)
			{
				TextBox textBox = new TextBox();
				textBox.BorderStyle = BorderStyle.None;
				Size preferredSize = textBox.GetPreferredSize(new Size(int.MaxValue, int.MaxValue));
				textBox.BorderStyle = BorderStyle.FixedSingle;
				Size preferredSize2 = textBox.GetPreferredSize(new Size(int.MaxValue, int.MaxValue));
				Padding value = new Padding(0);
				int num = Math.Max(0, preferredSize2.Width - preferredSize.Width);
				int num2 = Math.Max(0, preferredSize2.Height - preferredSize.Height - 2);
				if (Environment.OSVersion.Version.Major == 6)
				{
					num2 = ((!PI.IsAppThemed() || !PI.IsThemeActive()) ? Math.Max(0, num2 - 2) : Math.Max(0, num2 - 3));
				}
				if (num > 0)
				{
					value.Left = num / 2;
					value.Right = num - value.Left;
				}
				if (num2 > 0)
				{
					value.Top = num2 / 2;
					value.Bottom = num2 - value.Top;
				}
				_inputControlPadding = value;
			}
			return _inputControlPadding.Value;
		}
	}

	public event EventHandler<PaletteLayoutEventArgs> PalettePaint;

	public event EventHandler AllowFormChromeChanged;

	public event EventHandler BasePaletteChanged;

	public event EventHandler BaseRendererChanged;

	public event EventHandler ButtonSpecChanged;

	public PaletteBase()
	{
		SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
		_dragFeedback = PaletteDragFeedback.Inherit;
	}

	public abstract InheritBool GetAllowFormChrome();

	public abstract IRenderer GetRenderer();

	public abstract InheritBool GetBackDraw(PaletteBackStyle style, PaletteState state);

	public abstract PaletteGraphicsHint GetBackGraphicsHint(PaletteBackStyle style, PaletteState state);

	public abstract Color GetBackColor1(PaletteBackStyle style, PaletteState state);

	public abstract Color GetBackColor2(PaletteBackStyle style, PaletteState state);

	public abstract PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state);

	public abstract PaletteRectangleAlign GetBackColorAlign(PaletteBackStyle style, PaletteState state);

	public abstract float GetBackColorAngle(PaletteBackStyle style, PaletteState state);

	public abstract Image GetBackImage(PaletteBackStyle style, PaletteState state);

	public abstract PaletteImageStyle GetBackImageStyle(PaletteBackStyle style, PaletteState state);

	public abstract PaletteRectangleAlign GetBackImageAlign(PaletteBackStyle style, PaletteState state);

	public abstract InheritBool GetBorderDraw(PaletteBorderStyle style, PaletteState state);

	public abstract PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state);

	public abstract PaletteGraphicsHint GetBorderGraphicsHint(PaletteBorderStyle style, PaletteState state);

	public abstract Color GetBorderColor1(PaletteBorderStyle style, PaletteState state);

	public abstract Color GetBorderColor2(PaletteBorderStyle style, PaletteState state);

	public abstract PaletteColorStyle GetBorderColorStyle(PaletteBorderStyle style, PaletteState state);

	public abstract PaletteRectangleAlign GetBorderColorAlign(PaletteBorderStyle style, PaletteState state);

	public abstract float GetBorderColorAngle(PaletteBorderStyle style, PaletteState state);

	public abstract int GetBorderWidth(PaletteBorderStyle style, PaletteState state);

	public abstract int GetBorderRounding(PaletteBorderStyle style, PaletteState state);

	public abstract Image GetBorderImage(PaletteBorderStyle style, PaletteState state);

	public abstract PaletteImageStyle GetBorderImageStyle(PaletteBorderStyle style, PaletteState state);

	public abstract PaletteRectangleAlign GetBorderImageAlign(PaletteBorderStyle style, PaletteState state);

	public abstract InheritBool GetContentDraw(PaletteContentStyle style, PaletteState state);

	public abstract InheritBool GetContentDrawFocus(PaletteContentStyle style, PaletteState state);

	public abstract PaletteRelativeAlign GetContentImageH(PaletteContentStyle style, PaletteState state);

	public abstract PaletteRelativeAlign GetContentImageV(PaletteContentStyle style, PaletteState state);

	public abstract PaletteImageEffect GetContentImageEffect(PaletteContentStyle style, PaletteState state);

	public abstract Color GetContentImageColorMap(PaletteContentStyle style, PaletteState state);

	public abstract Color GetContentImageColorTo(PaletteContentStyle style, PaletteState state);

	public abstract Color GetContentImageColorTransparent(PaletteContentStyle style, PaletteState state);

	public abstract Font GetContentShortTextFont(PaletteContentStyle style, PaletteState state);

	public abstract Font GetContentShortTextNewFont(PaletteContentStyle style, PaletteState state);

	public abstract PaletteTextHint GetContentShortTextHint(PaletteContentStyle style, PaletteState state);

	public abstract PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteContentStyle style, PaletteState state);

	public abstract InheritBool GetContentShortTextMultiLine(PaletteContentStyle style, PaletteState state);

	public abstract PaletteTextTrim GetContentShortTextTrim(PaletteContentStyle style, PaletteState state);

	public abstract PaletteRelativeAlign GetContentShortTextH(PaletteContentStyle style, PaletteState state);

	public abstract PaletteRelativeAlign GetContentShortTextV(PaletteContentStyle style, PaletteState state);

	public abstract PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteContentStyle style, PaletteState state);

	public abstract Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state);

	public abstract Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state);

	public abstract PaletteColorStyle GetContentShortTextColorStyle(PaletteContentStyle style, PaletteState state);

	public abstract PaletteRectangleAlign GetContentShortTextColorAlign(PaletteContentStyle style, PaletteState state);

	public abstract float GetContentShortTextColorAngle(PaletteContentStyle style, PaletteState state);

	public abstract Image GetContentShortTextImage(PaletteContentStyle style, PaletteState state);

	public abstract PaletteImageStyle GetContentShortTextImageStyle(PaletteContentStyle style, PaletteState state);

	public abstract PaletteRectangleAlign GetContentShortTextImageAlign(PaletteContentStyle style, PaletteState state);

	public abstract Font GetContentLongTextFont(PaletteContentStyle style, PaletteState state);

	public abstract Font GetContentLongTextNewFont(PaletteContentStyle style, PaletteState state);

	public abstract PaletteTextHint GetContentLongTextHint(PaletteContentStyle style, PaletteState state);

	public abstract PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteContentStyle style, PaletteState state);

	public abstract InheritBool GetContentLongTextMultiLine(PaletteContentStyle style, PaletteState state);

	public abstract PaletteTextTrim GetContentLongTextTrim(PaletteContentStyle style, PaletteState state);

	public abstract PaletteRelativeAlign GetContentLongTextH(PaletteContentStyle style, PaletteState state);

	public abstract PaletteRelativeAlign GetContentLongTextV(PaletteContentStyle style, PaletteState state);

	public abstract PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteContentStyle style, PaletteState state);

	public abstract Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state);

	public abstract Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state);

	public abstract PaletteColorStyle GetContentLongTextColorStyle(PaletteContentStyle style, PaletteState state);

	public abstract PaletteRectangleAlign GetContentLongTextColorAlign(PaletteContentStyle style, PaletteState state);

	public abstract float GetContentLongTextColorAngle(PaletteContentStyle style, PaletteState state);

	public abstract Image GetContentLongTextImage(PaletteContentStyle style, PaletteState state);

	public abstract PaletteImageStyle GetContentLongTextImageStyle(PaletteContentStyle style, PaletteState state);

	public abstract PaletteRectangleAlign GetContentLongTextImageAlign(PaletteContentStyle style, PaletteState state);

	public abstract Padding GetContentPadding(PaletteContentStyle style, PaletteState state);

	public abstract int GetContentAdjacentGap(PaletteContentStyle style, PaletteState state);

	public abstract int GetMetricInt(PaletteState state, PaletteMetricInt metric);

	public abstract InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric);

	public abstract Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric);

	public abstract Image GetTreeViewImage(bool expanded);

	public abstract Image GetCheckBoxImage(bool enabled, CheckState checkState, bool tracking, bool pressed);

	public abstract Image GetRadioButtonImage(bool enabled, bool checkState, bool tracking, bool pressed);

	public abstract Image GetDropDownButtonImage(PaletteState state);

	public abstract Image GetContextMenuCheckedImage();

	public abstract Image GetContextMenuIndeterminateImage();

	public abstract Image GetContextMenuSubMenuImage();

	public abstract Image GetGalleryButtonImage(PaletteRibbonGalleryButton button, PaletteState state);

	public abstract Icon GetButtonSpecIcon(PaletteButtonSpecStyle style);

	public abstract Image GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state);

	public abstract Color GetButtonSpecImageTransparentColor(PaletteButtonSpecStyle style);

	public abstract string GetButtonSpecShortText(PaletteButtonSpecStyle style);

	public abstract string GetButtonSpecLongText(PaletteButtonSpecStyle style);

	public virtual string GetButtonSpecToolTipTitle(PaletteButtonSpecStyle style)
	{
		switch (style)
		{
		case PaletteButtonSpecStyle.Close:
		case PaletteButtonSpecStyle.FormClose:
		case PaletteButtonSpecStyle.PendantClose:
			return "Close";
		case PaletteButtonSpecStyle.Context:
			return "Select";
		case PaletteButtonSpecStyle.Next:
			return "Next";
		case PaletteButtonSpecStyle.Previous:
			return "Previous";
		case PaletteButtonSpecStyle.FormMin:
		case PaletteButtonSpecStyle.PendantMin:
			return "Minimize";
		case PaletteButtonSpecStyle.FormMax:
			return "Maximize";
		case PaletteButtonSpecStyle.FormRestore:
		case PaletteButtonSpecStyle.PendantRestore:
			return "Restore";
		case PaletteButtonSpecStyle.RibbonMinimize:
			return "Minimize";
		case PaletteButtonSpecStyle.RibbonExpand:
			return "Expand";
		case PaletteButtonSpecStyle.Generic:
		case PaletteButtonSpecStyle.ArrowLeft:
		case PaletteButtonSpecStyle.ArrowRight:
		case PaletteButtonSpecStyle.ArrowUp:
		case PaletteButtonSpecStyle.ArrowDown:
		case PaletteButtonSpecStyle.DropDown:
		case PaletteButtonSpecStyle.PinVertical:
		case PaletteButtonSpecStyle.PinHorizontal:
			return string.Empty;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	public abstract Color GetButtonSpecColorMap(PaletteButtonSpecStyle style);

	public abstract Color GetButtonSpecColorTransparent(PaletteButtonSpecStyle style);

	public abstract PaletteButtonStyle GetButtonSpecStyle(PaletteButtonSpecStyle style);

	public abstract HeaderLocation GetButtonSpecLocation(PaletteButtonSpecStyle style);

	public abstract PaletteRelativeEdgeAlign GetButtonSpecEdge(PaletteButtonSpecStyle style);

	public abstract PaletteButtonOrientation GetButtonSpecOrientation(PaletteButtonSpecStyle style);

	public abstract PaletteRibbonShape GetRibbonShape();

	public abstract PaletteRelativeAlign GetRibbonContextTextAlign(PaletteState state);

	public abstract Font GetRibbonContextTextFont(PaletteState state);

	public abstract Color GetRibbonContextTextColor(PaletteState state);

	public abstract Color GetRibbonDisabledDark(PaletteState state);

	public abstract Color GetRibbonDisabledLight(PaletteState state);

	public abstract Color GetRibbonDropArrowLight(PaletteState state);

	public abstract Color GetRibbonDropArrowDark(PaletteState state);

	public abstract Color GetRibbonGroupDialogDark(PaletteState state);

	public abstract Color GetRibbonGroupDialogLight(PaletteState state);

	public abstract Color GetRibbonGroupSeparatorDark(PaletteState state);

	public abstract Color GetRibbonGroupSeparatorLight(PaletteState state);

	public abstract Color GetRibbonMinimizeBarDark(PaletteState state);

	public abstract Color GetRibbonMinimizeBarLight(PaletteState state);

	public abstract Color GetRibbonTabSeparatorColor(PaletteState state);

	public abstract Color GetRibbonTabSeparatorContextColor(PaletteState state);

	public abstract Font GetRibbonTextFont(PaletteState state);

	public abstract PaletteTextHint GetRibbonTextHint(PaletteState state);

	public abstract Color GetRibbonQATButtonDark(PaletteState state);

	public abstract Color GetRibbonQATButtonLight(PaletteState state);

	public abstract PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteRibbonBackStyle style, PaletteState state);

	public abstract Color GetRibbonBackColor1(PaletteRibbonBackStyle style, PaletteState state);

	public abstract Color GetRibbonBackColor2(PaletteRibbonBackStyle style, PaletteState state);

	public abstract Color GetRibbonBackColor3(PaletteRibbonBackStyle style, PaletteState state);

	public abstract Color GetRibbonBackColor4(PaletteRibbonBackStyle style, PaletteState state);

	public abstract Color GetRibbonBackColor5(PaletteRibbonBackStyle style, PaletteState state);

	public abstract Color GetRibbonTextColor(PaletteRibbonTextStyle style, PaletteState state);

	public abstract Color GetElementColor1(PaletteElement element, PaletteState state);

	public abstract Color GetElementColor2(PaletteElement element, PaletteState state);

	public abstract Color GetElementColor3(PaletteElement element, PaletteState state);

	public abstract Color GetElementColor4(PaletteElement element, PaletteState state);

	public abstract Color GetElementColor5(PaletteElement element, PaletteState state);

	public virtual PaletteDragFeedback GetDragDropFeedback()
	{
		if (_dragFeedback == PaletteDragFeedback.Inherit)
		{
			_dragFeedback = ((Environment.OSVersion.Version.Major < 6) ? PaletteDragFeedback.Square : PaletteDragFeedback.Rounded);
			if (_dragFeedback == PaletteDragFeedback.Rounded && (OSFeature.Feature.GetVersionPresent(OSFeature.LayeredWindows) == null || CommonHelper.ColorDepth() <= 8))
			{
				_dragFeedback = PaletteDragFeedback.Square;
			}
		}
		return _dragFeedback;
	}

	public virtual Color GetDragDropSolidBack()
	{
		return SystemColors.ActiveCaption;
	}

	public virtual Color GetDragDropSolidBorder()
	{
		return SystemColors.Control;
	}

	public virtual float GetDragDropSolidOpacity()
	{
		return 0.37f;
	}

	public virtual Color GetDragDropDockBack()
	{
		return Color.FromArgb(228, 228, 228);
	}

	public virtual Color GetDragDropDockBorder()
	{
		return Color.FromArgb(181, 181, 181);
	}

	public virtual Color GetDragDropDockActive()
	{
		return SystemColors.ActiveCaption;
	}

	public virtual Color GetDragDropDockInactive()
	{
		return SystemColors.InactiveCaption;
	}

	protected abstract void DefineFonts();

	public static Color MergeColors(Color color1, float percent1, Color color2, float percent2)
	{
		return CommonHelper.MergeColors(color1, percent1, color2, percent2);
	}

	public static Color MergeColors(Color color1, float percent1, Color color2, float percent2, Color color3, float percent3)
	{
		return CommonHelper.MergeColors(color1, percent1, color2, percent2, color3, percent3);
	}

	public static Color FadedColor(Color baseColor)
	{
		ColorHSL colorHSL = new ColorHSL(baseColor);
		colorHSL.Saturation = 0.0;
		colorHSL.Luminance = 0.550000011920929;
		return colorHSL.Color;
	}

	internal void UserPreferenceChanged()
	{
		OnUserPreferenceChanged(this, new UserPreferenceChangedEventArgs(UserPreferenceCategory.General));
	}

	protected virtual void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
	{
		_inputControlPadding = null;
		_dragFeedback = PaletteDragFeedback.Inherit;
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
