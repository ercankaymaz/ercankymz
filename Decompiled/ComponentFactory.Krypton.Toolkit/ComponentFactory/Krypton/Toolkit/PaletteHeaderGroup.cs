#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteHeaderGroup : PaletteDouble, IPaletteMetric
{
	private IPaletteMetric _inherit;

	private PaletteTripleMetric _paletteHeaderPrimary;

	private PaletteTripleMetric _paletteHeaderSecondary;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _paletteHeaderPrimary.IsDefault && _paletteHeaderSecondary.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining primary header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleMetric HeaderPrimary => _paletteHeaderPrimary;

	[Category("Visuals")]
	[Description("Overrides for defining secondary header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleMetric HeaderSecondary => _paletteHeaderSecondary;

	public PaletteHeaderGroup(PaletteHeaderGroupRedirect inheritHeaderGroup, PaletteHeaderPaddingRedirect inheritHeaderPrimary, PaletteHeaderPaddingRedirect inheritHeaderSecondary, NeedPaintHandler needPaint)
		: base(inheritHeaderGroup, needPaint)
	{
		Debug.Assert(inheritHeaderGroup != null);
		Debug.Assert(inheritHeaderPrimary != null);
		Debug.Assert(inheritHeaderSecondary != null);
		_inherit = inheritHeaderGroup;
		_paletteHeaderPrimary = new PaletteTripleMetric(inheritHeaderPrimary, needPaint);
		_paletteHeaderSecondary = new PaletteTripleMetric(inheritHeaderSecondary, needPaint);
	}

	public void SetInherit(PaletteHeaderGroup inheritHeaderGroup)
	{
		SetInherit((IPaletteDouble)inheritHeaderGroup);
		_inherit = inheritHeaderGroup;
		_paletteHeaderPrimary.SetInherit(inheritHeaderGroup.HeaderPrimary);
		_paletteHeaderSecondary.SetInherit(inheritHeaderGroup.HeaderSecondary);
	}

	private bool ShouldSerializeHeaderPrimary()
	{
		return !_paletteHeaderPrimary.IsDefault;
	}

	private bool ShouldSerializeHeaderSecondary()
	{
		return !_paletteHeaderSecondary.IsDefault;
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
		return _inherit.GetMetricPadding(state, metric);
	}
}
