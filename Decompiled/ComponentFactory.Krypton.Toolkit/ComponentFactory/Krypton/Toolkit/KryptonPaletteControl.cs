using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteControl : KryptonPaletteDouble3
{
	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common control appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDouble StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDouble StateNormal => _stateNormal;

	public KryptonPaletteControl(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, NeedPaintHandler needPaint)
		: base(redirect, backStyle, borderStyle, needPaint)
	{
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
