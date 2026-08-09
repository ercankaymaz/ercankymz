#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteDoubleRedirect : Storage, IPaletteDouble
{
	private PaletteBack _back;

	private PaletteBorder _border;

	private PaletteBackInheritRedirect _backInherit;

	private PaletteBorderInheritRedirect _borderInherit;

	[Browsable(false)]
	public override bool IsDefault => Back.IsDefault && Border.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteBack Back => _back;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual IPaletteBack PaletteBack => Back;

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
	public virtual PaletteBorder Border => _border;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual IPaletteBorder PaletteBorder => Border;

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

	internal PaletteBorderInheritRedirect BorderRedirect => _borderInherit;

	public PaletteDoubleRedirect(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle)
		: this(redirect, backStyle, borderStyle, null)
	{
	}

	public PaletteDoubleRedirect(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, NeedPaintHandler needPaint)
	{
		PaletteBackInheritRedirect paletteBackInheritRedirect = new PaletteBackInheritRedirect(redirect, backStyle);
		PaletteBorderInheritRedirect paletteBorderInheritRedirect = new PaletteBorderInheritRedirect(redirect, borderStyle);
		PaletteBack back = new PaletteBack(paletteBackInheritRedirect, needPaint);
		PaletteBorder border = new PaletteBorder(paletteBorderInheritRedirect, needPaint);
		Construct(redirect, back, paletteBackInheritRedirect, border, paletteBorderInheritRedirect, needPaint);
	}

	public PaletteDoubleRedirect(PaletteRedirect redirect, PaletteBack back, PaletteBackInheritRedirect backInherit, PaletteBorder border, PaletteBorderInheritRedirect borderInherit, NeedPaintHandler needPaint)
	{
		Construct(redirect, back, backInherit, border, borderInherit, needPaint);
	}

	public PaletteRedirect GetRedirector()
	{
		return _backInherit.GetRedirector();
	}

	public virtual void SetRedirector(PaletteRedirect redirect)
	{
		_backInherit.SetRedirector(redirect);
		_borderInherit.SetRedirector(redirect);
	}

	public void PopulateFromBase(PaletteState state)
	{
		_back.PopulateFromBase(state);
		_border.PopulateFromBase(state);
	}

	public void SetStyles(PaletteBackStyle backStyle, PaletteBorderStyle borderStyle)
	{
		BackStyle = backStyle;
		BorderStyle = borderStyle;
	}

	public void SetStyles(SeparatorStyle separatorStyle)
	{
		switch (separatorStyle)
		{
		case SeparatorStyle.LowProfile:
			SetStyles(PaletteBackStyle.SeparatorLowProfile, PaletteBorderStyle.SeparatorLowProfile);
			break;
		case SeparatorStyle.HighProfile:
			SetStyles(PaletteBackStyle.SeparatorHighProfile, PaletteBorderStyle.SeparatorHighProfile);
			break;
		case SeparatorStyle.HighInternalProfile:
			SetStyles(PaletteBackStyle.SeparatorHighInternalProfile, PaletteBorderStyle.SeparatorHighInternalProfile);
			break;
		case SeparatorStyle.Custom1:
			SetStyles(PaletteBackStyle.SeparatorCustom1, PaletteBorderStyle.SeparatorCustom1);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
	}

	public void SetStyles(InputControlStyle inputControlStyle)
	{
		switch (inputControlStyle)
		{
		case InputControlStyle.Standalone:
			SetStyles(PaletteBackStyle.InputControlStandalone, PaletteBorderStyle.InputControlStandalone);
			break;
		case InputControlStyle.Ribbon:
			SetStyles(PaletteBackStyle.InputControlRibbon, PaletteBorderStyle.InputControlRibbon);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
	}

	private bool ShouldSerializeBack()
	{
		return !_back.IsDefault;
	}

	private bool ShouldSerializeBorder()
	{
		return !_border.IsDefault;
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}

	private void Construct(PaletteRedirect redirect, PaletteBack back, PaletteBackInheritRedirect backInherit, PaletteBorder border, PaletteBorderInheritRedirect borderInherit, NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
		_backInherit = backInherit;
		_borderInherit = borderInherit;
		_back = back;
		_border = border;
	}
}
