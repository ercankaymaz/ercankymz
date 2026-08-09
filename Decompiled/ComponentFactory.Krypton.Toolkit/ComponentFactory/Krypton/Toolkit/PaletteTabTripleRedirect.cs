#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTabTripleRedirect : Storage, IPaletteTriple
{
	private PaletteBack _back;

	private PaletteTabBorder _border;

	private PaletteContent _content;

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
	public PaletteTabBorder Border => _border;

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
	public PaletteContent Content => _content;

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

	public PaletteTabTripleRedirect(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		NeedPaint = needPaint;
		_backInherit = new PaletteBackInheritRedirect(redirect, backStyle);
		_borderInherit = new PaletteBorderInheritRedirect(redirect, borderStyle);
		_contentInherit = new PaletteContentInheritRedirect(redirect, contentStyle);
		_back = new PaletteBack(_backInherit, needPaint);
		_border = new PaletteTabBorder(_borderInherit, needPaint);
		_content = new PaletteContent(_contentInherit, needPaint);
	}

	public virtual void SetRedirector(PaletteRedirect redirect)
	{
		_backInherit.SetRedirector(redirect);
		_borderInherit.SetRedirector(redirect);
		_contentInherit.SetRedirector(redirect);
	}

	public void SetStyles(TabStyle tabStyle)
	{
		switch (tabStyle)
		{
		case TabStyle.HighProfile:
			SetStyles(PaletteBackStyle.TabHighProfile, PaletteBorderStyle.TabHighProfile, PaletteContentStyle.TabHighProfile);
			break;
		case TabStyle.StandardProfile:
			SetStyles(PaletteBackStyle.TabStandardProfile, PaletteBorderStyle.TabStandardProfile, PaletteContentStyle.TabStandardProfile);
			break;
		case TabStyle.LowProfile:
			SetStyles(PaletteBackStyle.TabLowProfile, PaletteBorderStyle.TabLowProfile, PaletteContentStyle.TabLowProfile);
			break;
		case TabStyle.OneNote:
			SetStyles(PaletteBackStyle.TabOneNote, PaletteBorderStyle.TabOneNote, PaletteContentStyle.TabOneNote);
			break;
		case TabStyle.Dock:
			SetStyles(PaletteBackStyle.TabDock, PaletteBorderStyle.TabDock, PaletteContentStyle.TabDock);
			break;
		case TabStyle.DockAutoHidden:
			SetStyles(PaletteBackStyle.TabDockAutoHidden, PaletteBorderStyle.TabDockAutoHidden, PaletteContentStyle.TabDockAutoHidden);
			break;
		case TabStyle.Custom1:
			SetStyles(PaletteBackStyle.TabCustom1, PaletteBorderStyle.TabCustom1, PaletteContentStyle.TabCustom1);
			break;
		case TabStyle.Custom2:
			SetStyles(PaletteBackStyle.TabCustom2, PaletteBorderStyle.TabCustom2, PaletteContentStyle.TabCustom2);
			break;
		case TabStyle.Custom3:
			SetStyles(PaletteBackStyle.TabCustom3, PaletteBorderStyle.TabCustom3, PaletteContentStyle.TabCustom3);
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

	private void SetStyles(PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle)
	{
		BackStyle = backStyle;
		BorderStyle = borderStyle;
		ContentStyle = contentStyle;
	}
}
