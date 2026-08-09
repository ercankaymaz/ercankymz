#define DEBUG
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectTripleMetric : PaletteRedirectTriple
{
	private IPaletteMetric _disabled;

	private IPaletteMetric _normal;

	public PaletteRedirectTripleMetric(IPalette target)
		: this(target, null, null, null, null)
	{
	}

	public PaletteRedirectTripleMetric(IPalette target, IPaletteTriple disabled, IPaletteMetric disableMetric, IPaletteTriple normal, IPaletteMetric normalMetric)
		: base(target, disabled, normal)
	{
		_disabled = disableMetric;
		_normal = normalMetric;
	}

	public void SetRedirectStates(IPaletteTriple disabled, IPaletteMetric disableMetric, IPaletteTriple normal, IPaletteMetric normalMetric)
	{
		base.SetRedirectStates(disabled, normal);
		_disabled = disableMetric;
		_normal = normalMetric;
	}

	public override void ResetRedirectStates()
	{
		base.ResetRedirectStates();
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
