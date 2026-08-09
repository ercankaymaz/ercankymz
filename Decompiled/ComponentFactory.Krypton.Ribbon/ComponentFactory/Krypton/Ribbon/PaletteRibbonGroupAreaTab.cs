using System.ComponentModel;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteRibbonGroupAreaTab : PaletteRibbonJustTab
{
	private PaletteRibbonBack _ribbonGroupArea;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && RibbonGroupArea.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group area appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonGroupArea => _ribbonGroupArea;

	public PaletteRibbonGroupAreaTab(PaletteRibbonRedirect inherit, NeedPaintHandler needPaint)
		: base(inherit, needPaint)
	{
		_ribbonGroupArea = new PaletteRibbonBack(inherit.RibbonGroupArea, needPaint);
	}

	public override void PopulateFromBase(PaletteState state)
	{
		base.PopulateFromBase(state);
		_ribbonGroupArea.PopulateFromBase(state);
	}

	public override void SetInherit(PaletteRibbonRedirect inherit)
	{
		base.SetInherit(inherit);
		_ribbonGroupArea.SetInherit(inherit.RibbonGroupArea);
	}

	private bool ShouldSerializeRibbonGroupArea()
	{
		return !_ribbonGroupArea.IsDefault;
	}
}
