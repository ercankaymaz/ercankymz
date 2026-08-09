#define DEBUG
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectDoubleMetric : PaletteRedirectDouble
{
	private IPaletteMetric _disabled;

	private IPaletteMetric _normal;

	private IPaletteMetric _pressed;

	private IPaletteMetric _tracking;

	public PaletteRedirectDoubleMetric(IPalette target)
		: this(target, null, null, null, null)
	{
	}

	public PaletteRedirectDoubleMetric(IPalette target, IPaletteDouble disabled, IPaletteMetric disableMetric, IPaletteDouble normal, IPaletteMetric normalMetric)
		: base(target, disabled, normal)
	{
		_disabled = disableMetric;
		_normal = normalMetric;
	}

	public void SetRedirectStates(IPaletteDouble disabled, IPaletteMetric disableMetric, IPaletteDouble normal, IPaletteMetric normalMetric)
	{
		base.SetRedirectStates(disabled, normal);
		_disabled = disableMetric;
		_normal = normalMetric;
		_pressed = null;
		_tracking = null;
	}

	public void SetRedirectStates(IPaletteDouble disabled, IPaletteMetric disableMetric, IPaletteDouble normal, IPaletteMetric normalMetric, IPaletteDouble pressed, IPaletteMetric pressedMetric, IPaletteDouble tracking, IPaletteMetric trackingMetric)
	{
		base.SetRedirectStates(disabled, normal, pressed, tracking);
		_disabled = disableMetric;
		_normal = normalMetric;
		_pressed = pressedMetric;
		_tracking = trackingMetric;
	}

	public override void ResetRedirectStates()
	{
		base.ResetRedirectStates();
		_disabled = null;
		_normal = null;
		_pressed = null;
		_tracking = null;
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
		case PaletteState.Pressed:
			return _pressed;
		case PaletteState.Tracking:
			return _tracking;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}
}
