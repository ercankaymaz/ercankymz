using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteInputControl : Storage
{
	internal PaletteTripleRedirect _stateCommon;

	internal PaletteTriple _stateDisabled;

	internal PaletteTriple _stateNormal;

	internal PaletteTriple _stateActive;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateDisabled.IsDefault && _stateNormal.IsDefault && _stateActive.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common input control appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled input control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal input control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining active input control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateActive => _stateActive;

	public KryptonPaletteInputControl(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
	{
		_stateCommon = new PaletteTripleRedirect(redirect, backStyle, borderStyle, contentStyle, needPaint);
		_stateDisabled = new PaletteTriple(_stateCommon, needPaint);
		_stateNormal = new PaletteTriple(_stateCommon, needPaint);
		_stateActive = new PaletteTriple(_stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateCommon.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateDisabled.PopulateFromBase(PaletteState.Disabled);
		_stateNormal.PopulateFromBase(PaletteState.Normal);
		_stateActive.PopulateFromBase(PaletteState.Tracking);
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

	private bool ShouldSerializeStateActive()
	{
		return !_stateActive.IsDefault;
	}
}
