using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteSeparator : Storage
{
	private PaletteSeparatorPaddingRedirect _stateCommon;

	private PaletteSeparatorPadding _stateDisabled;

	private PaletteSeparatorPadding _stateNormal;

	private PaletteSeparatorPadding _stateTracking;

	private PaletteSeparatorPadding _statePressed;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateDisabled.IsDefault && _stateNormal.IsDefault && _stateTracking.IsDefault && _statePressed.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common separator appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSeparatorPaddingRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSeparatorPadding StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSeparatorPadding StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining hot tracking separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSeparatorPadding StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSeparatorPadding StatePressed => _statePressed;

	public KryptonPaletteSeparator(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, NeedPaintHandler needPaint)
	{
		_stateCommon = new PaletteSeparatorPaddingRedirect(redirect, backStyle, borderStyle, needPaint);
		_stateDisabled = new PaletteSeparatorPadding(_stateCommon, _stateCommon, needPaint);
		_stateNormal = new PaletteSeparatorPadding(_stateCommon, _stateCommon, needPaint);
		_stateTracking = new PaletteSeparatorPadding(_stateCommon, _stateCommon, needPaint);
		_statePressed = new PaletteSeparatorPadding(_stateCommon, _stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateCommon.SetRedirector(redirect);
	}

	public void PopulateFromBase(PaletteMetricPadding metric)
	{
		_stateDisabled.PopulateFromBase(PaletteState.Disabled, metric);
		_stateNormal.PopulateFromBase(PaletteState.Normal, metric);
		_stateTracking.PopulateFromBase(PaletteState.Tracking, metric);
		_statePressed.PopulateFromBase(PaletteState.Pressed, metric);
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
}
