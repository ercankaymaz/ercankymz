#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteSeparatorPadding : PaletteDouble, IPaletteMetric
{
	private IPaletteMetric _inherit;

	private Padding _separatorPadding;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && Padding.Equals(CommonHelper.InheritPadding);

	[KryptonPersist]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new PaletteBorder Border => base.Border;

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

	public PaletteSeparatorPadding(IPaletteDouble inheritDouble, IPaletteMetric inheritMetric, NeedPaintHandler needPaint)
		: base(inheritDouble, needPaint)
	{
		Debug.Assert(inheritDouble != null);
		Debug.Assert(inheritMetric != null);
		_inherit = inheritMetric;
		_separatorPadding = CommonHelper.InheritPadding;
	}

	public void PopulateFromBase(PaletteState state, PaletteMetricPadding metric)
	{
		base.PopulateFromBase(state);
		Padding = _inherit.GetMetricPadding(state, metric);
	}

	public void ResetPadding()
	{
		Padding = CommonHelper.InheritPadding;
	}

	public int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		return _inherit.GetMetricInt(state, metric);
	}

	public InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		return _inherit.GetMetricBool(state, metric);
	}

	public Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		if ((metric == PaletteMetricPadding.SeparatorPaddingLowProfile || metric == PaletteMetricPadding.SeparatorPaddingHighProfile || metric == PaletteMetricPadding.SeparatorPaddingHighInternalProfile || metric == PaletteMetricPadding.SeparatorPaddingCustom1) && !Padding.Equals(CommonHelper.InheritPadding))
		{
			return Padding;
		}
		return _inherit.GetMetricPadding(state, metric);
	}
}
