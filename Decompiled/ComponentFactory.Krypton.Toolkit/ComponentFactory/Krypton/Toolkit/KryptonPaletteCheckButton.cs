using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteCheckButton : Storage
{
	private PaletteTripleRedirect _stateDefault;

	private PaletteTripleRedirect _stateFocus;

	private PaletteTripleRedirect _stateCommon;

	private PaletteTriple _stateDisabled;

	private PaletteTriple _stateNormal;

	private PaletteTriple _stateTracking;

	private PaletteTriple _statePressed;

	private PaletteTriple _stateCheckedNormal;

	private PaletteTriple _stateCheckedTracking;

	private PaletteTriple _stateCheckedPressed;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateDefault.IsDefault && _stateFocus.IsDefault && _stateDisabled.IsDefault && _stateNormal.IsDefault && _stateTracking.IsDefault && _statePressed.IsDefault && _stateCheckedNormal.IsDefault && _stateCheckedTracking.IsDefault && _stateCheckedPressed.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common button appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining hot tracking button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StatePressed => _statePressed;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal checked button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateCheckedNormal => _stateCheckedNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining hot tracking checked button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateCheckedTracking => _stateCheckedTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed checked button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateCheckedPressed => _stateCheckedPressed;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal button appearance when default.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect OverrideDefault => _stateDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining button appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect OverrideFocus => _stateFocus;

	public KryptonPaletteCheckButton(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
	{
		_stateDefault = new PaletteTripleRedirect(redirect, backStyle, borderStyle, contentStyle, needPaint);
		_stateFocus = new PaletteTripleRedirect(redirect, backStyle, borderStyle, contentStyle, needPaint);
		_stateCommon = new PaletteTripleRedirect(redirect, backStyle, borderStyle, contentStyle, needPaint);
		_stateDisabled = new PaletteTriple(_stateCommon, needPaint);
		_stateNormal = new PaletteTriple(_stateCommon, needPaint);
		_stateTracking = new PaletteTriple(_stateCommon, needPaint);
		_statePressed = new PaletteTriple(_stateCommon, needPaint);
		_stateCheckedNormal = new PaletteTriple(_stateCommon, needPaint);
		_stateCheckedTracking = new PaletteTriple(_stateCommon, needPaint);
		_stateCheckedPressed = new PaletteTriple(_stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateDefault.SetRedirector(redirect);
		_stateFocus.SetRedirector(redirect);
		_stateCommon.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateDefault.PopulateFromBase(PaletteState.NormalDefaultOverride);
		_stateFocus.PopulateFromBase(PaletteState.FocusOverride);
		_stateDisabled.PopulateFromBase(PaletteState.Disabled);
		_stateNormal.PopulateFromBase(PaletteState.Normal);
		_stateTracking.PopulateFromBase(PaletteState.Tracking);
		_statePressed.PopulateFromBase(PaletteState.Pressed);
		_stateCheckedNormal.PopulateFromBase(PaletteState.CheckedNormal);
		_stateCheckedTracking.PopulateFromBase(PaletteState.CheckedTracking);
		_stateCheckedPressed.PopulateFromBase(PaletteState.CheckedPressed);
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

	private bool ShouldSerializeStateCheckedNormal()
	{
		return !_stateCheckedNormal.IsDefault;
	}

	private bool ShouldSerializeStateCheckedTracking()
	{
		return !_stateCheckedTracking.IsDefault;
	}

	private bool ShouldSerializeStateCheckedPressed()
	{
		return !_stateCheckedPressed.IsDefault;
	}

	private bool ShouldSerializeOverrideDefault()
	{
		return !_stateDefault.IsDefault;
	}

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
	}
}
