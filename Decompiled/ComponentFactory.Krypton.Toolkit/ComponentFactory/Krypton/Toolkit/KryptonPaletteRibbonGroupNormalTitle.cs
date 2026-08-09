using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteRibbonGroupNormalTitle : Storage
{
	private PaletteRibbonDoubleInheritRedirect _stateInherit;

	private PaletteRibbonDouble _stateCommon;

	private PaletteRibbonDouble _stateNormal;

	private PaletteRibbonDouble _stateTracking;

	private PaletteRibbonDouble _stateContextNormal;

	private PaletteRibbonDouble _stateContextTracking;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateNormal.IsDefault && _stateTracking.IsDefault && _stateContextNormal.IsDefault && _stateContextTracking.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common ribbon group normal title appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal ribbon group normal title appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tracking ribbon group normal title appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining context normal ribbon group normal title appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateContextNormal => _stateContextNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining context tracking ribbon group normal title appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDouble StateContextTracking => _stateContextTracking;

	public KryptonPaletteRibbonGroupNormalTitle(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_stateInherit = new PaletteRibbonDoubleInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGroupNormalTitle, PaletteRibbonTextStyle.RibbonGroupNormalTitle);
		_stateCommon = new PaletteRibbonDouble(_stateInherit, _stateInherit, needPaint);
		_stateNormal = new PaletteRibbonDouble(_stateCommon, _stateCommon, needPaint);
		_stateTracking = new PaletteRibbonDouble(_stateCommon, _stateCommon, needPaint);
		_stateContextNormal = new PaletteRibbonDouble(_stateCommon, _stateCommon, needPaint);
		_stateContextTracking = new PaletteRibbonDouble(_stateCommon, _stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateInherit.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateNormal.PopulateFromBase(PaletteState.Normal);
		_stateTracking.PopulateFromBase(PaletteState.Tracking);
		_stateContextNormal.PopulateFromBase(PaletteState.ContextNormal);
		_stateContextTracking.PopulateFromBase(PaletteState.ContextTracking);
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

	private bool ShouldSerializeStateContextNormal()
	{
		return !_stateContextNormal.IsDefault;
	}

	private bool ShouldSerializeStateContextTracking()
	{
		return !_stateContextTracking.IsDefault;
	}
}
