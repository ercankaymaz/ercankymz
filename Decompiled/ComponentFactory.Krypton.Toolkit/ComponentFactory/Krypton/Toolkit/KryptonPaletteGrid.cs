using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteGrid : Storage
{
	private PaletteDataGridViewRedirect _stateCommon;

	private PaletteDataGridViewAll _stateDisabled;

	private PaletteDataGridViewAll _stateNormal;

	private PaletteDataGridViewHeaders _stateTracking;

	private PaletteDataGridViewHeaders _statePressed;

	private PaletteDataGridViewCells _stateSelected;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateDisabled.IsDefault && _stateNormal.IsDefault && _stateTracking.IsDefault && _statePressed.IsDefault && _stateSelected.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common grid appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled grid appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewAll StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal grid appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewAll StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining hot tracking grid appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewHeaders StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed grid appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewHeaders StatePressed => _statePressed;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining selected grid appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewCells StateSelected => _stateSelected;

	public KryptonPaletteGrid(PaletteRedirect redirect, GridStyle gridStyle, NeedPaintHandler needPaint)
	{
		_stateCommon = new PaletteDataGridViewRedirect(redirect, needPaint);
		_stateDisabled = new PaletteDataGridViewAll(_stateCommon, needPaint);
		_stateNormal = new PaletteDataGridViewAll(_stateCommon, needPaint);
		_stateTracking = new PaletteDataGridViewHeaders(_stateCommon, needPaint);
		_statePressed = new PaletteDataGridViewHeaders(_stateCommon, needPaint);
		_stateSelected = new PaletteDataGridViewCells(_stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateCommon.SetRedirector(redirect);
	}

	public void PopulateFromBase(KryptonPaletteCommon common, GridStyle gridStyle)
	{
		_stateDisabled.PopulateFromBase(common, PaletteState.Disabled, gridStyle);
		_stateNormal.PopulateFromBase(common, PaletteState.Normal, gridStyle);
		_stateTracking.PopulateFromBase(common, PaletteState.Tracking, gridStyle);
		_statePressed.PopulateFromBase(common, PaletteState.Pressed, gridStyle);
		_stateSelected.PopulateFromBase(common, PaletteState.CheckedNormal, gridStyle);
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
}
