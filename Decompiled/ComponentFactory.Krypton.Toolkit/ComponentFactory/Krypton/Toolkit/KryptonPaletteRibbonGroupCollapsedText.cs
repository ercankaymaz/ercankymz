using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteRibbonGroupCollapsedText : Storage
{
	private PaletteRibbonTextInheritRedirect _stateInherit;

	private PaletteRibbonText _stateCommon;

	private PaletteRibbonText _stateNormal;

	private PaletteRibbonText _stateTracking;

	private PaletteRibbonText _stateContextNormal;

	private PaletteRibbonText _stateContextTracking;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateNormal.IsDefault && _stateTracking.IsDefault && _stateContextNormal.IsDefault && _stateContextTracking.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common ribbon group collapsed text appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonText StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal ribbon group collapsed text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonText StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tracking ribbon group collapsed text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonText StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining context normal ribbon group collapsed text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonText StateContextNormal => _stateContextNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining context tracking ribbon group collapsed text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonText StateContextTracking => _stateContextTracking;

	public KryptonPaletteRibbonGroupCollapsedText(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_stateInherit = new PaletteRibbonTextInheritRedirect(redirect, PaletteRibbonTextStyle.RibbonGroupCollapsedText);
		_stateCommon = new PaletteRibbonText(_stateInherit, needPaint);
		_stateNormal = new PaletteRibbonText(_stateCommon, needPaint);
		_stateTracking = new PaletteRibbonText(_stateCommon, needPaint);
		_stateContextNormal = new PaletteRibbonText(_stateCommon, needPaint);
		_stateContextTracking = new PaletteRibbonText(_stateCommon, needPaint);
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
