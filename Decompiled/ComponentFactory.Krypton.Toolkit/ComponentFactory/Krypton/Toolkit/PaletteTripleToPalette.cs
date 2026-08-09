#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTripleToPalette : IPaletteTriple
{
	private PaletteBackToPalette _back;

	private PaletteBorderToPalette _border;

	private PaletteContentToPalette _content;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteBack PaletteBack => _back;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PaletteBackStyle BackStyle
	{
		get
		{
			return _back.BackStyle;
		}
		set
		{
			_back.BackStyle = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteBorder PaletteBorder => _border;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PaletteBorderStyle BorderStyle
	{
		get
		{
			return _border.BorderStyle;
		}
		set
		{
			_border.BorderStyle = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteContent PaletteContent => _content;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PaletteContentStyle ContentStyle
	{
		get
		{
			return _content.ContentStyle;
		}
		set
		{
			_content.ContentStyle = value;
		}
	}

	public PaletteTripleToPalette(IPalette palette, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle)
	{
		_back = new PaletteBackToPalette(palette, backStyle);
		_border = new PaletteBorderToPalette(palette, borderStyle);
		_content = new PaletteContentToPalette(palette, contentStyle);
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
		case ButtonStyle.Gallery:
			SetStyles(PaletteBackStyle.ButtonGallery, PaletteBorderStyle.ButtonGallery, PaletteContentStyle.ButtonGallery);
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
}
