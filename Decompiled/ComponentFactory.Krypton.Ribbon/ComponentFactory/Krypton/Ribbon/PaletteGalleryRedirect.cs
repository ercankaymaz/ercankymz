#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteGalleryRedirect : PaletteMetricRedirect
{
	private PaletteRibbonBack _ribbonBack;

	private PaletteRibbonBack _ribbonBorder;

	private PaletteRibbonBackInheritRedirect _ribbonBackInherit;

	private PaletteRibbonBackInheritRedirect _ribbonBorderInherit;

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

	public PaletteGalleryRedirect(PaletteRedirect redirect, NeedPaintHandler needPaint)
		: base(redirect)
	{
		Debug.Assert(redirect != null);
		NeedPaint = needPaint;
		_ribbonBorderInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGalleryBorder);
		_ribbonBackInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGalleryBack);
		_ribbonBack = new PaletteRibbonBack(_ribbonBackInherit, needPaint);
		_ribbonBorder = new PaletteRibbonBack(_ribbonBorderInherit, needPaint);
	}

	public override void SetRedirector(PaletteRedirect redirect)
	{
		base.SetRedirector(redirect);
		_ribbonBackInherit.SetRedirector(redirect);
		_ribbonBorderInherit.SetRedirector(redirect);
	}

	private bool ShouldSerializeRibbonGalleryBack()
	{
		return !_ribbonBack.IsDefault;
	}

	private bool ShouldSerializeRibbonGalleryBorder()
	{
		return !_ribbonBorder.IsDefault;
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}
}
