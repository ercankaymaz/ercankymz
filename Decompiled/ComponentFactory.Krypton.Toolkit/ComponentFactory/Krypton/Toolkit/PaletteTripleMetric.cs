#define DEBUG
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTripleMetric : PaletteTriple, IPaletteMetric
{
	private PaletteTripleMetricRedirect _inherit;

	public PaletteTripleMetric(PaletteTripleMetricRedirect inherit, NeedPaintHandler needPaint)
		: base(inherit, needPaint)
	{
		Debug.Assert(inherit != null);
		_inherit = inherit;
	}

	public void SetInherit(PaletteTripleMetricRedirect inherit)
	{
		SetInherit((IPaletteTriple)inherit);
		_inherit = inherit;
	}

	public virtual int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		return _inherit.GetMetricInt(state, metric);
	}

	public virtual InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		return _inherit.GetMetricBool(state, metric);
	}

	public virtual Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		return _inherit.GetMetricPadding(state, metric);
	}
}
