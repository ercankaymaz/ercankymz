using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteRibbonTab : Storage
{
	private PaletteRibbonDoubleInheritRedirect _stateInherit;

	private PaletteRibbonDouble _stateCommon;

	private PaletteRibbonDouble _stateNormal;

	private PaletteRibbonDouble _stateTracking;

	private PaletteRibbonDouble _stateCheckedNormal;

	private PaletteRibbonDouble _stateCheckedTracking;

	private PaletteRibbonDouble _stateContextTracking;

	private PaletteRibbonDouble _stateContextCheckedNormal;

	private PaletteRibbonDouble _stateContextCheckedTracking;

	private PaletteRibbonDouble _overrideFocus;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateNormal.IsDefault && _stateTracking.IsDefault && _stateCheckedNormal.IsDefault && _stateCheckedTracking.IsDefault && _stateContextTracking.IsDefault && _stateContextCheckedNormal.IsDefault && _stateContextCheckedTracking.IsDefault && _overrideFocus.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common ribbon tab appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal ribbon tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tracking ribbon tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining checked normal ribbon tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateCheckedNormal => _stateCheckedNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining checked tracking ribbon tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateCheckedTracking => _stateCheckedTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining context tracking ribbon tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateContextTracking => _stateContextTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining checked normal ribbon tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateContextCheckedNormal => _stateContextCheckedNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining context checked tracking ribbon tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateContextCheckedTracking => _stateContextCheckedTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining focus ribbon tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble OverrideFocus => _overrideFocus;

	public KryptonPaletteRibbonTab(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_stateInherit = new PaletteRibbonDoubleInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonTab, PaletteRibbonTextStyle.RibbonTab);
		_stateCommon = new PaletteRibbonDouble(_stateInherit, _stateInherit, needPaint);
		_stateNormal = new PaletteRibbonDouble(_stateCommon, _stateCommon, needPaint);
		_stateTracking = new PaletteRibbonDouble(_stateCommon, _stateCommon, needPaint);
		_stateCheckedNormal = new PaletteRibbonDouble(_stateCommon, _stateCommon, needPaint);
		_stateCheckedTracking = new PaletteRibbonDouble(_stateCommon, _stateCommon, needPaint);
		_stateContextTracking = new PaletteRibbonDouble(_stateCommon, _stateCommon, needPaint);
		_stateContextCheckedNormal = new PaletteRibbonDouble(_stateCommon, _stateCommon, needPaint);
		_stateContextCheckedTracking = new PaletteRibbonDouble(_stateCommon, _stateCommon, needPaint);
		_overrideFocus = new PaletteRibbonDouble(_stateInherit, _stateInherit, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateInherit.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateNormal.PopulateFromBase(PaletteState.Normal);
		_stateTracking.PopulateFromBase(PaletteState.Tracking);
		_stateCheckedNormal.PopulateFromBase(PaletteState.CheckedNormal);
		_stateCheckedTracking.PopulateFromBase(PaletteState.CheckedTracking);
		_stateContextTracking.PopulateFromBase(PaletteState.ContextTracking);
		_stateContextCheckedNormal.PopulateFromBase(PaletteState.ContextCheckedNormal);
		_stateContextCheckedTracking.PopulateFromBase(PaletteState.ContextCheckedTracking);
		_overrideFocus.PopulateFromBase(PaletteState.FocusOverride);
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeStateTracking()
	{
		return !_stateTracking.IsDefault;
	}

	private bool ShouldSerializeStateCheckedNormal()
	{
		return !_stateCheckedNormal.IsDefault;
	}

	private bool ShouldSerializeStateCheckedTracking()
	{
		return !_stateCheckedTracking.IsDefault;
	}

	private bool ShouldSerializeStateContextTracking()
	{
		return !_stateContextTracking.IsDefault;
	}

	private bool ShouldSerializeStateContextCheckedNormal()
	{
		return !_stateContextCheckedNormal.IsDefault;
	}

	private bool ShouldSerializeStateContextCheckedTracking()
	{
		return !_stateContextCheckedTracking.IsDefault;
	}

	private bool ShouldSerializeOverrideFocus()
	{
		return !_overrideFocus.IsDefault;
	}
}
