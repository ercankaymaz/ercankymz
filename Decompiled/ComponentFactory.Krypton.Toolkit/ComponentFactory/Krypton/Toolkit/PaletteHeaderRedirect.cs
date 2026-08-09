#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteHeaderRedirect : PaletteTripleMetricRedirect
{
	private PaletteRedirect _redirect;

	private Padding _buttonPadding;

	private int _buttonEdgeInset;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && ButtonPadding.Equals(CommonHelper.InheritPadding) && ButtonEdgeInset == -1;

	[Category("Visuals")]
	[Description("How far to inset buttons from the header edge.")]
	[DefaultValue(-1)]
	[RefreshProperties(RefreshProperties.All)]
	public int ButtonEdgeInset
	{
		get
		{
			return _buttonEdgeInset;
		}
		set
		{
			if (_buttonEdgeInset != value)
			{
				_buttonEdgeInset = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Padding used around each button on the header.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding ButtonPadding
	{
		get
		{
			return _buttonPadding;
		}
		set
		{
			if (_buttonPadding != value)
			{
				_buttonPadding = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public PaletteHeaderRedirect(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
		: base(redirect, backStyle, borderStyle, contentStyle, needPaint)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
		_buttonPadding = CommonHelper.InheritPadding;
		_buttonEdgeInset = -1;
	}

	public override void SetRedirector(PaletteRedirect redirect)
	{
		base.SetRedirector(redirect);
		_redirect = redirect;
	}

	public void ResetButtonEdgeInset()
	{
		ButtonEdgeInset = -1;
	}

	public void ResetButtonPadding()
	{
		ButtonPadding = CommonHelper.InheritPadding;
	}

	public override int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		if ((metric == PaletteMetricInt.HeaderButtonEdgeInsetPrimary || metric == PaletteMetricInt.HeaderButtonEdgeInsetSecondary || metric == PaletteMetricInt.HeaderButtonEdgeInsetDockInactive || metric == PaletteMetricInt.HeaderButtonEdgeInsetDockActive || metric == PaletteMetricInt.HeaderButtonEdgeInsetForm || metric == PaletteMetricInt.HeaderButtonEdgeInsetInputControl || metric == PaletteMetricInt.HeaderButtonEdgeInsetCustom1 || metric == PaletteMetricInt.HeaderButtonEdgeInsetCustom2) && ButtonEdgeInset != -1)
		{
			return ButtonEdgeInset;
		}
		return _redirect.GetMetricInt(state, metric);
	}

	public override InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		return _redirect.GetMetricBool(state, metric);
	}

	public override Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		if ((metric == PaletteMetricPadding.HeaderButtonPaddingPrimary || metric == PaletteMetricPadding.HeaderButtonPaddingSecondary || metric == PaletteMetricPadding.HeaderButtonPaddingDockInactive || metric == PaletteMetricPadding.HeaderButtonPaddingDockActive || metric == PaletteMetricPadding.HeaderButtonPaddingForm || metric == PaletteMetricPadding.HeaderButtonPaddingInputControl || metric == PaletteMetricPadding.HeaderButtonPaddingCustom1 || metric == PaletteMetricPadding.HeaderButtonPaddingCustom2) && !ButtonPadding.Equals(CommonHelper.InheritPadding))
		{
			return ButtonPadding;
		}
		return _redirect.GetMetricPadding(state, metric);
	}
}
