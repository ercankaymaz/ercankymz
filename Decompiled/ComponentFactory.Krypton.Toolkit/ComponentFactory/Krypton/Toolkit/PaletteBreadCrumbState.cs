using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBreadCrumbState : Storage
{
	private PaletteTriple _paletteCrumb;

	[Browsable(false)]
	public override bool IsDefault => _paletteCrumb.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining bread crumb appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple BreadCrumb => _paletteCrumb;

	public PaletteBreadCrumbState(PaletteBreadCrumbRedirect redirect, NeedPaintHandler needPaint)
	{
		_paletteCrumb = new PaletteTriple(redirect.BreadCrumb, needPaint);
	}

	private bool ShouldSerializeBreadCrumb()
	{
		return !_paletteCrumb.IsDefault;
	}
}
