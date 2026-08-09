using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteRibbonGroupArea : Storage
{
	private PaletteRibbonBackInheritRedirect _stateInherit;

	private PaletteRibbonBack _stateCommon;

	private PaletteRibbonBack _stateCheckedNormal;

	private PaletteRibbonBack _stateContextCheckedTracking;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateCheckedNormal.IsDefault && _stateContextCheckedTracking.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common ribbon application button appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining checked ribbon group area appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateCheckedNormal => _stateCheckedNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining context checked ribbon group area appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateContextCheckedNormal => _stateContextCheckedTracking;

	public KryptonPaletteRibbonGroupArea(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_stateInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGroupArea);
		_stateCommon = new PaletteRibbonBack(_stateInherit, needPaint);
		_stateCheckedNormal = new PaletteRibbonBack(_stateCommon, needPaint);
		_stateContextCheckedTracking = new PaletteRibbonBack(_stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateInherit.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateCheckedNormal.PopulateFromBase(PaletteState.CheckedNormal);
		_stateContextCheckedTracking.PopulateFromBase(PaletteState.ContextCheckedNormal);
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateCheckedNormal()
	{
		return !_stateCheckedNormal.IsDefault;
	}

	private bool ShouldSerializeStateContextCheckedNormal()
	{
		return !_stateContextCheckedTracking.IsDefault;
	}
}
