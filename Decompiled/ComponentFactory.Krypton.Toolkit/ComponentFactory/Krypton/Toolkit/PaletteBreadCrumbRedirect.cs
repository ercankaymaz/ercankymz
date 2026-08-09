using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBreadCrumbRedirect : PaletteDoubleMetricRedirect
{
	private PaletteTripleRedirect _paletteCrumb;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _paletteCrumb.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining bread crumb appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect BreadCrumb => _paletteCrumb;

	public PaletteBreadCrumbRedirect(PaletteRedirect redirect, NeedPaintHandler needPaint)
		: base(redirect, PaletteBackStyle.PanelAlternate, PaletteBorderStyle.ControlClient)
	{
		_paletteCrumb = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonBreadCrumb, PaletteBorderStyle.ButtonBreadCrumb, PaletteContentStyle.ButtonBreadCrumb, needPaint);
	}

	private bool ShouldSerializeBreadCrumb()
	{
		return !_paletteCrumb.IsDefault;
	}
}
