using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteHeader : Storage
{
	private PaletteHeaderRedirect _stateCommon;

	private PaletteTripleMetric _stateDisabled;

	private PaletteTripleMetric _stateNormal;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateDisabled.IsDefault && _stateNormal.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common header appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteHeaderRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleMetric StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleMetric StateNormal => _stateNormal;

	public KryptonPaletteHeader(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
	{
		_stateCommon = new PaletteHeaderRedirect(redirect, backStyle, borderStyle, contentStyle, needPaint);
		_stateDisabled = new PaletteTripleMetric(_stateCommon, needPaint);
		_stateNormal = new PaletteTripleMetric(_stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateCommon.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateDisabled.PopulateFromBase(PaletteState.Disabled);
		_stateNormal.PopulateFromBase(PaletteState.Normal);
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}
}
