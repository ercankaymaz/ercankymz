#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutMetricSpacer : ViewLeaf
{
	private IPaletteMetric _paletteMetric;

	private PaletteMetricInt _metricInt;

	public ViewLayoutMetricSpacer(IPaletteMetric paletteMetric, PaletteMetricInt metricInt)
	{
		Debug.Assert(paletteMetric != null);
		_paletteMetric = paletteMetric;
		_metricInt = metricInt;
	}

	public override string ToString()
	{
		return "ViewLayoutMetricSpacer:" + base.Id;
	}

	public void SetMetrics(IPaletteMetric paletteMetric)
	{
		_paletteMetric = paletteMetric;
	}

	public void SetMetrics(IPaletteMetric paletteMetric, PaletteMetricInt metricInt)
	{
		_paletteMetric = paletteMetric;
		_metricInt = metricInt;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		int metricInt = _paletteMetric.GetMetricInt(ElementState, _metricInt);
		return new Size(metricInt, metricInt);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		int metricInt = _paletteMetric.GetMetricInt(ElementState, _metricInt);
		ClientRectangle = new Rectangle(context.DisplayRectangle.Location, new Size(metricInt, metricInt));
	}
}
