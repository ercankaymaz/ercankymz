using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteTabButton : Storage
{
	private PaletteTabTripleRedirect _stateFocus;

	private PaletteTabTripleRedirect _stateCommon;

	private PaletteTabTriple _stateDisabled;

	private PaletteTabTriple _stateNormal;

	private PaletteTabTriple _stateTracking;

	private PaletteTabTriple _statePressed;

	private PaletteTabTriple _stateSelected;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateFocus.IsDefault && _stateDisabled.IsDefault && _stateNormal.IsDefault && _stateTracking.IsDefault && _statePressed.IsDefault && _stateSelected.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common tab appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTabTripleRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTabTriple StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTabTriple StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining hot tracking tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTabTriple StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTabTriple StatePressed => _statePressed;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTabTriple StateSelected => _stateSelected;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tab appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTabTripleRedirect OverrideFocus => _stateFocus;

	public KryptonPaletteTabButton(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
	{
		_stateFocus = new PaletteTabTripleRedirect(redirect, backStyle, borderStyle, contentStyle, needPaint);
		_stateCommon = new PaletteTabTripleRedirect(redirect, backStyle, borderStyle, contentStyle, needPaint);
		_stateDisabled = new PaletteTabTriple(_stateCommon, needPaint);
		_stateNormal = new PaletteTabTriple(_stateCommon, needPaint);
		_stateTracking = new PaletteTabTriple(_stateCommon, needPaint);
		_statePressed = new PaletteTabTriple(_stateCommon, needPaint);
		_stateSelected = new PaletteTabTriple(_stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateFocus.SetRedirector(redirect);
		_stateCommon.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateFocus.PopulateFromBase(PaletteState.FocusOverride);
		_stateDisabled.PopulateFromBase(PaletteState.Disabled);
		_stateNormal.PopulateFromBase(PaletteState.Normal);
		_stateTracking.PopulateFromBase(PaletteState.Tracking);
		_statePressed.PopulateFromBase(PaletteState.Pressed);
		_stateSelected.PopulateFromBase(PaletteState.CheckedNormal);
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

	private bool ShouldSerializeStateTracking()
	{
		return !_stateTracking.IsDefault;
	}

	private bool ShouldSerializeStatePressed()
	{
		return !_statePressed.IsDefault;
	}

	private bool ShouldSerializeStateSelected()
	{
		return !_stateSelected.IsDefault;
	}

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
	}
}
