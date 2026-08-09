using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class ButtonSpecManagerLayoutRibbon : ButtonSpecManagerLayout
{
	public ButtonSpecManagerLayoutRibbon(KryptonRibbon ribbon, PaletteRedirect redirector, ButtonSpecCollectionBase variableSpecs, ButtonSpecCollectionBase fixedSpecs, ViewLayoutDocker[] viewDockers, IPaletteMetric[] viewMetrics, PaletteMetricInt[] viewMetricInt, PaletteMetricPadding[] viewMetricPaddings, GetToolStripRenderer getRenderer, NeedPaintHandler needPaint)
		: base(ribbon, redirector, variableSpecs, fixedSpecs, viewDockers, viewMetrics, viewMetricInt, viewMetricPaddings, getRenderer, needPaint)
	{
	}

	protected override ButtonSpecView CreateButtonSpecView(PaletteRedirect redirector, IPaletteMetric viewPaletteMetric, PaletteMetricPadding viewMetricPadding, ButtonSpec buttonSpec)
	{
		return new ButtonSpecViewRibbon(redirector, viewPaletteMetric, viewMetricPadding, this, buttonSpec);
	}
}
