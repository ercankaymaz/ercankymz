#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteDataGridViewTripleRedirect : Storage, IPaletteTriple
{
	private PaletteBack _back;

	private PaletteBorder _border;

	private PaletteDataGridViewContentCommon _content;

	private PaletteBackInheritRedirect _backInherit;

	private PaletteBorderInheritRedirect _borderInherit;

	private PaletteContentInheritRedirect _contentInherit;

	[Browsable(false)]
	public override bool IsDefault => Back.IsDefault && Border.IsDefault && Content.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBack Back => _back;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteBack PaletteBack => Back;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PaletteBackStyle BackStyle
	{
		get
		{
			return _backInherit.Style;
		}
		set
		{
			_backInherit.Style = value;
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBorder Border => _border;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteBorder PaletteBorder => Border;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PaletteBorderStyle BorderStyle
	{
		get
		{
			return _borderInherit.Style;
		}
		set
		{
			_borderInherit.Style = value;
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining content appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewContentCommon Content => _content;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteContent PaletteContent => Content;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PaletteContentStyle ContentStyle
	{
		get
		{
			return _contentInherit.Style;
		}
		set
		{
			_contentInherit.Style = value;
		}
	}

	public PaletteDataGridViewTripleRedirect(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		NeedPaint = needPaint;
		_backInherit = new PaletteBackInheritRedirect(redirect, backStyle);
		_borderInherit = new PaletteBorderInheritRedirect(redirect, borderStyle);
		_contentInherit = new PaletteContentInheritRedirect(redirect, contentStyle);
		_back = new PaletteBack(_backInherit, needPaint);
		_border = new PaletteBorder(_borderInherit, needPaint);
		_content = new PaletteDataGridViewContentCommon(_contentInherit, needPaint);
	}

	public virtual void SetRedirector(PaletteRedirect redirect)
	{
		_backInherit.SetRedirector(redirect);
		_borderInherit.SetRedirector(redirect);
		_contentInherit.SetRedirector(redirect);
	}

	public void SetStyles(PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle)
	{
		BackStyle = backStyle;
		BorderStyle = borderStyle;
		ContentStyle = contentStyle;
	}

	public void SetStyles(ButtonStyle buttonStyle)
	{
		switch (buttonStyle)
		{
		case ButtonStyle.Standalone:
			SetStyles(PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone);
			break;
		case ButtonStyle.Alternate:
			SetStyles(PaletteBackStyle.ButtonAlternate, PaletteBorderStyle.ButtonAlternate, PaletteContentStyle.ButtonAlternate);
			break;
		case ButtonStyle.LowProfile:
			SetStyles(PaletteBackStyle.ButtonLowProfile, PaletteBorderStyle.ButtonLowProfile, PaletteContentStyle.ButtonLowProfile);
			break;
		case ButtonStyle.ButtonSpec:
			SetStyles(PaletteBackStyle.ButtonButtonSpec, PaletteBorderStyle.ButtonButtonSpec, PaletteContentStyle.ButtonButtonSpec);
			break;
		case ButtonStyle.BreadCrumb:
			SetStyles(PaletteBackStyle.ButtonBreadCrumb, PaletteBorderStyle.ButtonBreadCrumb, PaletteContentStyle.ButtonBreadCrumb);
			break;
		case ButtonStyle.CalendarDay:
			SetStyles(PaletteBackStyle.ButtonCalendarDay, PaletteBorderStyle.ButtonCalendarDay, PaletteContentStyle.ButtonCalendarDay);
			break;
		case ButtonStyle.Cluster:
			SetStyles(PaletteBackStyle.ButtonCluster, PaletteBorderStyle.ButtonCluster, PaletteContentStyle.ButtonCluster);
			break;
		case ButtonStyle.NavigatorStack:
			SetStyles(PaletteBackStyle.ButtonNavigatorStack, PaletteBorderStyle.ButtonNavigatorStack, PaletteContentStyle.ButtonNavigatorStack);
			break;
		case ButtonStyle.NavigatorOverflow:
			SetStyles(PaletteBackStyle.ButtonNavigatorOverflow, PaletteBorderStyle.ButtonNavigatorOverflow, PaletteContentStyle.ButtonNavigatorOverflow);
			break;
		case ButtonStyle.NavigatorMini:
			SetStyles(PaletteBackStyle.ButtonNavigatorMini, PaletteBorderStyle.ButtonNavigatorMini, PaletteContentStyle.ButtonNavigatorMini);
			break;
		case ButtonStyle.InputControl:
			SetStyles(PaletteBackStyle.ButtonInputControl, PaletteBorderStyle.ButtonInputControl, PaletteContentStyle.ButtonInputControl);
			break;
		case ButtonStyle.ListItem:
			SetStyles(PaletteBackStyle.ButtonListItem, PaletteBorderStyle.ButtonListItem, PaletteContentStyle.ButtonListItem);
			break;
		case ButtonStyle.Form:
			SetStyles(PaletteBackStyle.ButtonForm, PaletteBorderStyle.ButtonForm, PaletteContentStyle.ButtonForm);
			break;
		case ButtonStyle.FormClose:
			SetStyles(PaletteBackStyle.ButtonFormClose, PaletteBorderStyle.ButtonFormClose, PaletteContentStyle.ButtonFormClose);
			break;
		case ButtonStyle.Command:
			SetStyles(PaletteBackStyle.ButtonCommand, PaletteBorderStyle.ButtonCommand, PaletteContentStyle.ButtonCommand);
			break;
		case ButtonStyle.Custom1:
			SetStyles(PaletteBackStyle.ButtonCustom1, PaletteBorderStyle.ButtonCustom1, PaletteContentStyle.ButtonCustom1);
			break;
		case ButtonStyle.Custom2:
			SetStyles(PaletteBackStyle.ButtonCustom2, PaletteBorderStyle.ButtonCustom2, PaletteContentStyle.ButtonCustom2);
			break;
		case ButtonStyle.Custom3:
			SetStyles(PaletteBackStyle.ButtonCustom3, PaletteBorderStyle.ButtonCustom3, PaletteContentStyle.ButtonCustom3);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
	}

	public void SetStyles(HeaderStyle headerStyle)
	{
		switch (headerStyle)
		{
		case HeaderStyle.Primary:
			SetStyles(PaletteBackStyle.HeaderPrimary, PaletteBorderStyle.HeaderPrimary, PaletteContentStyle.HeaderPrimary);
			break;
		case HeaderStyle.Secondary:
			SetStyles(PaletteBackStyle.HeaderSecondary, PaletteBorderStyle.HeaderSecondary, PaletteContentStyle.HeaderSecondary);
			break;
		case HeaderStyle.DockActive:
			SetStyles(PaletteBackStyle.HeaderDockActive, PaletteBorderStyle.HeaderDockActive, PaletteContentStyle.HeaderDockActive);
			break;
		case HeaderStyle.DockInactive:
			SetStyles(PaletteBackStyle.HeaderDockInactive, PaletteBorderStyle.HeaderDockInactive, PaletteContentStyle.HeaderDockInactive);
			break;
		case HeaderStyle.Form:
			SetStyles(PaletteBackStyle.HeaderForm, PaletteBorderStyle.HeaderForm, PaletteContentStyle.HeaderForm);
			break;
		case HeaderStyle.Calendar:
			SetStyles(PaletteBackStyle.HeaderCalendar, PaletteBorderStyle.HeaderCalendar, PaletteContentStyle.HeaderCalendar);
			break;
		case HeaderStyle.Custom1:
			SetStyles(PaletteBackStyle.HeaderCustom1, PaletteBorderStyle.HeaderCustom1, PaletteContentStyle.HeaderCustom1);
			break;
		case HeaderStyle.Custom2:
			SetStyles(PaletteBackStyle.HeaderCustom2, PaletteBorderStyle.HeaderCustom2, PaletteContentStyle.HeaderCustom2);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
	}

	public void PopulateFromBase(PaletteState state)
	{
		_back.PopulateFromBase(state);
		_border.PopulateFromBase(state);
		_content.PopulateFromBase(state);
	}

	private bool ShouldSerializeBack()
	{
		return !_back.IsDefault;
	}

	private bool ShouldSerializeBorder()
	{
		return !_border.IsDefault;
	}

	private bool ShouldSerializeContent()
	{
		return !_content.IsDefault;
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}
}
