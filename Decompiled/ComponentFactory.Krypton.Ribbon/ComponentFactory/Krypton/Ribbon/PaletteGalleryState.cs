using System.ComponentModel;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteGalleryState : Storage
{
	private PaletteRibbonBack _ribbonBack;

	private PaletteRibbonBack _ribbonBorder;

	[Browsable(false)]
	public override bool IsDefault => RibbonGalleryBack.IsDefault & RibbonGalleryBorder.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining gallery background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonGalleryBack => _ribbonBack;

	[Category("Visuals")]
	[Description("Overrides for defining gallery border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonGalleryBorder => _ribbonBorder;

	public PaletteGalleryState(PaletteGalleryRedirect inherit, NeedPaintHandler needPaint)
	{
		_ribbonBack = new PaletteRibbonBack(inherit.RibbonGalleryBack, needPaint);
		_ribbonBorder = new PaletteRibbonBack(inherit.RibbonGalleryBorder, needPaint);
	}

	public virtual void PopulateFromBase(PaletteState state)
	{
		_ribbonBack.PopulateFromBase(state);
		_ribbonBorder.PopulateFromBase(state);
	}

	public virtual void SetInherit(PaletteGalleryRedirect inherit)
	{
		_ribbonBack.SetInherit(inherit.RibbonGalleryBack);
		_ribbonBorder.SetInherit(inherit.RibbonGalleryBorder);
	}

	private bool ShouldSerializeRibbonGalleryBack()
	{
		return !_ribbonBack.IsDefault;
	}

	private bool ShouldSerializeRibbonGalleryBorder()
	{
		return !_ribbonBorder.IsDefault;
	}
}
