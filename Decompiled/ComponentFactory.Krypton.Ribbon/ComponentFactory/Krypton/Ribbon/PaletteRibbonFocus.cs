#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteRibbonFocus : PaletteMetricRedirect
{
	private PaletteRibbonDouble _ribbonTab;

	private PaletteRibbonDoubleInheritRedirect _ribbonTabInherit;

	[Browsable(false)]
	public override bool IsDefault => RibbonTab.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonDouble RibbonTab => _ribbonTab;

	public PaletteRibbonFocus(PaletteRedirect redirect, NeedPaintHandler needPaint)
		: base(redirect)
	{
		Debug.Assert(redirect != null);
		NeedPaint = needPaint;
		_ribbonTabInherit = new PaletteRibbonDoubleInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonTab, PaletteRibbonTextStyle.RibbonTab);
		_ribbonTab = new PaletteRibbonDouble(_ribbonTabInherit, _ribbonTabInherit, needPaint);
	}

	public override void SetRedirector(PaletteRedirect redirect)
	{
		base.SetRedirector(redirect);
		_ribbonTabInherit.SetRedirector(redirect);
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
