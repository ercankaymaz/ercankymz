using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteTrackBar : Storage
{
	private PaletteTrackBarRedirect _stateCommon;

	private PaletteTrackBarRedirect _stateFocus;

	private PaletteTrackBarStates _stateDisabled;

	private PaletteTrackBarStates _stateNormal;

	private PaletteTrackBarPositionStates _stateTracking;

	private PaletteTrackBarPositionStates _statePressed;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateFocus.IsDefault && _stateDisabled.IsDefault && _stateNormal.IsDefault && _stateTracking.IsDefault && _statePressed.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common track bar appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTrackBarRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled track bar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTrackBarStates StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal track bar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTrackBarStates StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tracking track bar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTrackBarPositionStates StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed track bar appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTrackBarPositionStates StatePressed => _statePressed;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining track bar appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTrackBarRedirect OverrideFocus => _stateFocus;

	public KryptonPaletteTrackBar(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_stateCommon = new PaletteTrackBarRedirect(redirect, needPaint);
		_stateFocus = new PaletteTrackBarRedirect(redirect, needPaint);
		_stateDisabled = new PaletteTrackBarStates(_stateCommon, needPaint);
		_stateNormal = new PaletteTrackBarStates(_stateCommon, needPaint);
		_stateTracking = new PaletteTrackBarPositionStates(_stateCommon, needPaint);
		_statePressed = new PaletteTrackBarPositionStates(_stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateCommon.SetRedirector(redirect);
		_stateFocus.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateFocus.PopulateFromBase(PaletteState.FocusOverride);
		_stateDisabled.PopulateFromBase(PaletteState.Disabled);
		_stateNormal.PopulateFromBase(PaletteState.Normal);
		_stateTracking.PopulateFromBase(PaletteState.Tracking);
		_statePressed.PopulateFromBase(PaletteState.Pressed);
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

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
	}
}
