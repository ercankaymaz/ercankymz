#define DEBUG
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectMetric : PaletteRedirect
{
	private IPaletteMetric _disabled;

	private IPaletteMetric _normal;

	public PaletteRedirectMetric(IPalette target)
		: this(target, null, null)
	{
	}

	public PaletteRedirectMetric(IPalette target, IPaletteMetric disableMetric, IPaletteMetric normalMetric)
		: base(target)
	{
		_disabled = disableMetric;
		_normal = normalMetric;
	}

	public void SetRedirectStates(IPaletteMetric disableMetric, IPaletteMetric normalMetric)
	{
		_disabled = disableMetric;
		_normal = normalMetric;
	}

	public void ResetRedirectStates()
	{
		_disabled = null;
		_normal = null;
	}

	public override int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		return GetInherit(state)?.GetMetricInt(state, metric) ?? Target.GetMetricInt(state, metric);
	}

	public override InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		return GetInherit(state)?.GetMetricBool(state, metric) ?? Target.GetMetricBool(state, metric);
	}

	public override Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		return GetInherit(state)?.GetMetricPadding(state, metric) ?? Target.GetMetricPadding(state, metric);
	}

	private IPaletteMetric GetInherit(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return _disabled;
		case PaletteState.Normal:
			return _normal;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}
}
