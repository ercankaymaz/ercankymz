#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteSeparatorPaddingRedirect : PaletteDoubleMetricRedirect
{
	private PaletteRedirect _redirect;

	private Padding _separatorPadding;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && Padding.Equals(CommonHelper.InheritPadding);

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding used to position the separator.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding Padding
	{
		get
		{
			return _separatorPadding;
		}
		set
		{
			if (_separatorPadding != value)
			{
				_separatorPadding = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public PaletteSeparatorPaddingRedirect(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, NeedPaintHandler needPaint)
		: base(redirect, backStyle, borderStyle, needPaint)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
		_separatorPadding = CommonHelper.InheritPadding;
	}

	public void ResetPadding()
	{
		Padding = CommonHelper.InheritPadding;
	}

	public override int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		return _redirect.GetMetricInt(state, metric);
	}

	public override InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		return _redirect.GetMetricBool(state, metric);
	}

	public override Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		if ((metric == PaletteMetricPadding.SeparatorPaddingLowProfile || metric == PaletteMetricPadding.SeparatorPaddingHighProfile || metric == PaletteMetricPadding.SeparatorPaddingHighInternalProfile || metric == PaletteMetricPadding.SeparatorPaddingCustom1) && !Padding.Equals(CommonHelper.InheritPadding))
		{
			return Padding;
		}
		return _redirect.GetMetricPadding(state, metric);
	}
}
