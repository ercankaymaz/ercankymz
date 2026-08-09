using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteCalendarDay : Storage
{
	private PaletteTripleRedirect _stateFocus;

	private PaletteTripleRedirect _stateBolded;

	private PaletteTripleRedirect _stateToday;

	private PaletteTripleRedirect _stateCommon;

	private PaletteTriple _stateDisabled;

	private PaletteTriple _stateNormal;

	private PaletteTriple _stateTracking;

	private PaletteTriple _statePressed;

	private PaletteTriple _stateCheckedNormal;

	private PaletteTriple _stateCheckedTracking;

	private PaletteTriple _stateCheckedPressed;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateFocus.IsDefault && _stateBolded.IsDefault && _stateToday.IsDefault && _stateDisabled.IsDefault && _stateNormal.IsDefault && _stateTracking.IsDefault && _statePressed.IsDefault && _stateCheckedNormal.IsDefault && _stateCheckedTracking.IsDefault && _stateCheckedPressed.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common calendar day appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled calendar day appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal calendar day appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining hot tracking calendar day appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed calendar day appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StatePressed => _statePressed;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal checked calendar day appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateCheckedNormal => _stateCheckedNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining hot tracking checked calendar day appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateCheckedTracking => _stateCheckedTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed checked calendar day appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateCheckedPressed => _stateCheckedPressed;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining calendar day appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect OverrideFocus => _stateFocus;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining calendar day appearance when it has bolded days.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect OverrideBolded => _stateBolded;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining calendar day appearance when it is today.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect OverrideToday => _stateToday;

	public KryptonPaletteCalendarDay(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_stateFocus = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonCalendarDay, PaletteBorderStyle.ButtonCalendarDay, PaletteContentStyle.ButtonCalendarDay, needPaint);
		_stateBolded = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonCalendarDay, PaletteBorderStyle.ButtonCalendarDay, PaletteContentStyle.ButtonCalendarDay, needPaint);
		_stateToday = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonCalendarDay, PaletteBorderStyle.ButtonCalendarDay, PaletteContentStyle.ButtonCalendarDay, needPaint);
		_stateCommon = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonCalendarDay, PaletteBorderStyle.ButtonCalendarDay, PaletteContentStyle.ButtonCalendarDay, needPaint);
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
		_stateFocus.SetRedirector(redirect);
		_stateBolded.SetRedirector(redirect);
		_stateToday.SetRedirector(redirect);
		_stateCommon.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateFocus.PopulateFromBase(PaletteState.FocusOverride);
		_stateBolded.PopulateFromBase(PaletteState.BoldedOverride);
		_stateToday.PopulateFromBase(PaletteState.BoldedOverride);
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

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
	}

	private bool ShouldSerializeOverrideBolded()
	{
		return !_stateBolded.IsDefault;
	}

	private bool ShouldSerializeOverrideToday()
	{
		return !_stateToday.IsDefault;
	}
}
