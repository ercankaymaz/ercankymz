using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteRibbonGroupCollapsedFrameBorder : Storage
{
	private PaletteRibbonBackInheritRedirect _stateInherit;

	private PaletteRibbonBack _stateCommon;

	private PaletteRibbonBack _stateNormal;

	private PaletteRibbonBack _stateTracking;

	private PaletteRibbonBack _stateContextNormal;

	private PaletteRibbonBack _stateContextTracking;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateNormal.IsDefault && _stateTracking.IsDefault && _stateContextNormal.IsDefault && _stateContextTracking.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common ribbon group collapsed border appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal ribbon group collapsed border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tracking ribbon group collapsed border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining context normal ribbon group collapsed border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateContextNormal => _stateContextNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining context tracking ribbon group collapsed border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateContextTracking => _stateContextTracking;

	public KryptonPaletteRibbonGroupCollapsedFrameBorder(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_stateInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder);
		_stateCommon = new PaletteRibbonBack(_stateInherit, needPaint);
		_stateNormal = new PaletteRibbonBack(_stateCommon, needPaint);
		_stateTracking = new PaletteRibbonBack(_stateCommon, needPaint);
		_stateContextNormal = new PaletteRibbonBack(_stateCommon, needPaint);
		_stateContextTracking = new PaletteRibbonBack(_stateCommon, needPaint);
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
