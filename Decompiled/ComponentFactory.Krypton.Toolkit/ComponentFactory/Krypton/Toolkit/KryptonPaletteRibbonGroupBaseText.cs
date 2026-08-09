using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteRibbonGroupBaseText : Storage
{
	private PaletteRibbonTextInheritRedirect _stateInherit;

	private PaletteRibbonText _stateCommon;

	private PaletteRibbonText _stateNormal;

	private PaletteRibbonText _stateDisabled;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateNormal.IsDefault && _stateDisabled.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common ribbon group text appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonText StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal ribbon group text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonText StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tracking ribbon group text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonText StateDisabled => _stateDisabled;

	public KryptonPaletteRibbonGroupBaseText(PaletteRedirect redirect, PaletteRibbonTextStyle textStyle, NeedPaintHandler needPaint)
	{
		_stateInherit = new PaletteRibbonTextInheritRedirect(redirect, textStyle);
		_stateCommon = new PaletteRibbonText(_stateInherit, needPaint);
		_stateNormal = new PaletteRibbonText(_stateCommon, needPaint);
		_stateDisabled = new PaletteRibbonText(_stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateInherit.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateNormal.PopulateFromBase(PaletteState.Normal);
		_stateDisabled.PopulateFromBase(PaletteState.Disabled);
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}
}
