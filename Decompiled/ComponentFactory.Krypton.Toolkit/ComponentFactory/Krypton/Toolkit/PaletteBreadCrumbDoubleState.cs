using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBreadCrumbDoubleState : PaletteDouble
{
	private PaletteTriple _paletteCrumb;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _paletteCrumb.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining bread crumb appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple BreadCrumb => _paletteCrumb;

	public PaletteBreadCrumbDoubleState(PaletteBreadCrumbRedirect redirect, NeedPaintHandler needPaint)
		: base(redirect, needPaint)
	{
		_paletteCrumb = new PaletteTriple(redirect.BreadCrumb, needPaint);
	}

	private bool ShouldSerializeBreadCrumb()
	{
		return !_paletteCrumb.IsDefault;
	}
}
