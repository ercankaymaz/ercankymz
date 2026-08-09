using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteRibbonAppButton : Storage
{
	private PaletteRibbonBackInheritRedirect _stateInherit;

	private PaletteRibbonBack _stateCommon;

	private PaletteRibbonBack _stateNormal;

	private PaletteRibbonBack _stateTracking;

	private PaletteRibbonBack _statePressed;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateNormal.IsDefault && _stateTracking.IsDefault && _statePressed.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common ribbon application button appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal ribbon application button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tracking ribbon application button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed ribbon application button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StatePressed => _statePressed;

	public KryptonPaletteRibbonAppButton(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_stateInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonAppButton);
		_stateCommon = new PaletteRibbonBack(_stateInherit, needPaint);
		_stateNormal = new PaletteRibbonBack(_stateCommon, needPaint);
		_stateTracking = new PaletteRibbonBack(_stateCommon, needPaint);
		_statePressed = new PaletteRibbonBack(_stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateInherit.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateNormal.PopulateFromBase(PaletteState.Normal);
		_stateTracking.PopulateFromBase(PaletteState.Tracking);
		_statePressed.PopulateFromBase(PaletteState.Pressed);
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

	private bool ShouldSerializeStatePressed()
	{
		return !_statePressed.IsDefault;
	}
}
