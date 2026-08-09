using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPalettePanel : Storage
{
	private PaletteBackInheritRedirect _stateInherit;

	private PaletteBack _stateCommon;

	private PaletteBack _stateNormal;

	private PaletteBack _stateDisabled;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateDisabled.IsDefault && _stateNormal.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common panel appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBack StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled panel appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBack StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal panel appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBack StateNormal => _stateNormal;

	public KryptonPalettePanel(PaletteRedirect redirect, PaletteBackStyle backStyle, NeedPaintHandler needPaint)
	{
		_stateInherit = new PaletteBackInheritRedirect(redirect, backStyle);
		_stateCommon = new PaletteBack(_stateInherit, needPaint);
		_stateDisabled = new PaletteBack(_stateCommon, needPaint);
		_stateNormal = new PaletteBack(_stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateInherit.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateDisabled.PopulateFromBase(PaletteState.Disabled);
		_stateNormal.PopulateFromBase(PaletteState.Normal);
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
}
