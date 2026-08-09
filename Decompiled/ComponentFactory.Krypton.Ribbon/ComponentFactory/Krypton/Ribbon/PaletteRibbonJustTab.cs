#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteRibbonJustTab : Storage
{
	private PaletteRibbonDouble _ribbonTab;

	[Browsable(false)]
	public override bool IsDefault => RibbonTab.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonDouble RibbonTab => _ribbonTab;

	public PaletteRibbonJustTab(PaletteRibbonRedirect inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		NeedPaint = needPaint;
		_ribbonTab = new PaletteRibbonDouble(inherit.RibbonTab, inherit.RibbonTab, needPaint);
	}

	public virtual void PopulateFromBase(PaletteState state)
	{
		_ribbonTab.PopulateFromBase(state);
	}

	public virtual void SetInherit(PaletteRibbonRedirect inherit)
	{
		_ribbonTab.SetInherit(inherit.RibbonTab, inherit.RibbonTab);
	}

	private bool ShouldSerializeRibbonTab()
	{
		return !_ribbonTab.IsDefault;
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}
}
