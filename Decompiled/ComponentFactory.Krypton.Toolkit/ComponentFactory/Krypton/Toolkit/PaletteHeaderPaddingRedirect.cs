#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteHeaderPaddingRedirect : PaletteHeaderButtonRedirect
{
	private PaletteRedirect _redirect;

	private Padding _headerPadding;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && HeaderPadding.Equals(CommonHelper.InheritPadding);

	[Category("Visuals")]
	[Description("Padding used to inset the header within the HeaderGroup.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding HeaderPadding
	{
		get
		{
			return _headerPadding;
		}
		set
		{
			if (_headerPadding != value)
			{
				_headerPadding = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public PaletteHeaderPaddingRedirect(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
		: base(redirect, backStyle, borderStyle, contentStyle, needPaint)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
		_headerPadding = CommonHelper.InheritPadding;
	}

	public void ResetHeaderPadding()
	{
		HeaderPadding = CommonHelper.InheritPadding;
	}

	public override Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		if ((metric == PaletteMetricPadding.HeaderGroupPaddingPrimary || metric == PaletteMetricPadding.HeaderGroupPaddingSecondary || metric == PaletteMetricPadding.HeaderGroupPaddingDockInactive || metric == PaletteMetricPadding.HeaderGroupPaddingDockActive) && !HeaderPadding.Equals(CommonHelper.InheritPadding))
		{
			return HeaderPadding;
		}
		return base.GetMetricPadding(state, metric);
	}
}
