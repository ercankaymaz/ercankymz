using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class KryptonPaletteDouble3 : Storage
{
	internal PaletteDoubleRedirect _stateCommon;

	internal PaletteDouble _stateDisabled;

	internal PaletteDouble _stateNormal;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault && _stateDisabled.IsDefault && _stateNormal.IsDefault;

	public KryptonPaletteDouble3(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, NeedPaintHandler needPaint)
	{
		_stateCommon = new PaletteDoubleRedirect(redirect, backStyle, borderStyle, needPaint);
		_stateDisabled = new PaletteDouble(_stateCommon, needPaint);
		_stateNormal = new PaletteDouble(_stateCommon, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateCommon.SetRedirector(redirect);
	}

	public void PopulateFromBase()
	{
		_stateDisabled.PopulateFromBase(PaletteState.Disabled);
		_stateNormal.PopulateFromBase(PaletteState.Normal);
	}
}
