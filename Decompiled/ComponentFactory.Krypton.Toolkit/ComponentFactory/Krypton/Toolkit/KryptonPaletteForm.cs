using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteForm : KryptonPaletteDouble3
{
	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common control appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining inactive form appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDouble StateInactive => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining active form appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDouble StateActive => _stateNormal;

	public KryptonPaletteForm(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, NeedPaintHandler needPaint)
		: base(redirect, backStyle, borderStyle, needPaint)
	{
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateInactive()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateActive()
	{
		return !_stateNormal.IsDefault;
	}
}
