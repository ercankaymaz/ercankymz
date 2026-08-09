#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteMetricRedirect : Storage, IPaletteMetric
{
	private PaletteRedirect _redirect;

	[Browsable(false)]
	public override bool IsDefault => true;

	public PaletteMetricRedirect(PaletteRedirect redirect)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
	}

	public virtual void SetRedirector(PaletteRedirect redirect)
	{
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
