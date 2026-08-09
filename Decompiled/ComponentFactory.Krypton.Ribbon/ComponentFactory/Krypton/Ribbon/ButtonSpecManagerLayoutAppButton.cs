using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class ButtonSpecManagerLayoutAppButton : ButtonSpecManagerLayout
{
	private ViewContextMenuManager _viewManager;

	public ViewContextMenuManager ViewManager => _viewManager;

	public ButtonSpecManagerLayoutAppButton(ViewContextMenuManager viewManager, Control control, PaletteRedirect redirector, ButtonSpecCollectionBase variableSpecs, ButtonSpecCollectionBase fixedSpecs, ViewLayoutDocker[] viewDockers, IPaletteMetric[] viewMetrics, PaletteMetricInt[] viewMetricInt, PaletteMetricPadding[] viewMetricPaddings, GetToolStripRenderer getRenderer, NeedPaintHandler needPaint)
		: base(control, redirector, variableSpecs, fixedSpecs, viewDockers, viewMetrics, viewMetricInt, viewMetricPaddings, getRenderer, needPaint)
	{
		_viewManager = viewManager;
	}

	protected override ButtonSpecView CreateButtonSpecView(PaletteRedirect redirector, IPaletteMetric viewPaletteMetric, PaletteMetricPadding viewMetricPadding, ButtonSpec buttonSpec)
	{
		return new ButtonSpecViewAppButton(redirector, viewPaletteMetric, viewMetricPadding, this, buttonSpec);
	}
}
