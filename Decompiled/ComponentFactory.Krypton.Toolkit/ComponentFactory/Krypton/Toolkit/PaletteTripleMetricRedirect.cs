#define DEBUG
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTripleMetricRedirect : PaletteTripleRedirect, IPaletteMetric
{
	private PaletteRedirect _redirect;

	public PaletteTripleMetricRedirect(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
		: base(redirect, backStyle, borderStyle, contentStyle, needPaint)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
	}

	public override void SetRedirector(PaletteRedirect redirect)
	{
		base.SetRedirector(redirect);
		_redirect = redirect;
	}

	public virtual int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		return _redirect.GetMetricInt(state, metric);
	}

	public virtual InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		return _redirect.GetMetricBool(state, metric);
	}

	public virtual Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		return _redirect.GetMetricPadding(state, metric);
	}
}
