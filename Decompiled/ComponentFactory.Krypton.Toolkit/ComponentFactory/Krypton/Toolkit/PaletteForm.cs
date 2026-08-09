#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteForm : PaletteDouble, IPaletteMetric
{
	private IPaletteMetric _inherit;

	private PaletteTripleMetric _paletteHeader;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _paletteHeader.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleMetric Header => _paletteHeader;

	public PaletteForm(PaletteFormRedirect inheritForm, PaletteTripleMetricRedirect inheritHeader, NeedPaintHandler needPaint)
		: base(inheritForm, needPaint)
	{
		Debug.Assert(inheritForm != null);
		Debug.Assert(inheritHeader != null);
		_inherit = inheritForm;
		_paletteHeader = new PaletteTripleMetric(inheritHeader, needPaint);
	}

	public void SetInherit(PaletteForm inheritHeader)
	{
		SetInherit((IPaletteDouble)inheritHeader);
		_inherit = inheritHeader;
		_paletteHeader.SetInherit(inheritHeader.Header);
	}

	private bool ShouldSerializeHeader()
	{
		return !_paletteHeader.IsDefault;
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
