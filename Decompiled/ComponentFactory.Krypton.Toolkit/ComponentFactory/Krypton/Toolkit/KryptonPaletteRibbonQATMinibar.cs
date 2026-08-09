using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteRibbonQATMinibar : Storage
{
	private PaletteRibbonBackInheritRedirect _stateInherit;

	private PaletteRibbonBack _stateCommon;

	private PaletteRibbonBack _stateActive;

	private PaletteRibbonBack _stateInactive;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateActive.IsDefault && _stateInactive.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common ribbon quick access minibar values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining active ribbon quick access minibar values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateActive => _stateActive;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining inactive ribbon quick access minibar values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack StateInactive => _stateInactive;

	public KryptonPaletteRibbonQATMinibar(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_stateInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonQATMinibar);
		_stateCommon = new PaletteRibbonBack(_stateInherit, needPaint);
		_stateActive = new PaletteRibbonBack(_stateCommon, needPaint);
		_stateInactive = new PaletteRibbonBack(_stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateInherit.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateActive.PopulateFromBase(PaletteState.Normal);
		_stateInactive.PopulateFromBase(PaletteState.Disabled);
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateActive()
	{
		return !_stateActive.IsDefault;
	}

	private bool ShouldSerializeStateInactive()
	{
		return !_stateInactive.IsDefault;
	}
}
