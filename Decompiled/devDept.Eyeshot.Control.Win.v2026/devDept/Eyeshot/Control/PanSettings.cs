using System;
using System.ComponentModel;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(PanConverter))]
public class PanSettings : MovementSettingsBase
{
	public PanSettings()
		: this(_0023_003Dz_bvIk_00244hiDEH(), _0023_003DzNpMGfoYaUexs(), MovementSettingsBase._0023_003DzlAUaJg4N2d6h())
	{
	}

	public PanSettings(MouseButton mouseButton, int keysStep, bool enabled)
		: base(mouseButton, keysStep, enabled)
	{
	}

	private static MouseButton _0023_003Dz_bvIk_00244hiDEH()
	{
		return new MouseButton(mouseButtonsZPR.Middle, modifierKeys.Ctrl);
	}

	private static int _0023_003DzNpMGfoYaUexs()
	{
		return 25;
	}

	internal override bool _0023_003DzTuElmQdRnJAJ()
	{
		return base.MouseButton != _0023_003Dz_bvIk_00244hiDEH();
	}

	internal override void _0023_003Dzyz4tqOWweGck()
	{
		base.MouseButton = _0023_003Dz_bvIk_00244hiDEH();
	}

	internal override bool _0023_003DzsW3nXFIc0Ymq974B_0024A_003D_003D()
	{
		return base.KeysStep != _0023_003DzNpMGfoYaUexs();
	}

	internal override void _0023_003DzMctCFm0sc4YA()
	{
		base.KeysStep = _0023_003DzNpMGfoYaUexs();
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(PanSettings _0023_003DzAbAO3f4_003D)
	{
		if (!(base.MouseButton != _0023_003DzAbAO3f4_003D.MouseButton) && base.KeysStep == _0023_003DzAbAO3f4_003D.KeysStep)
		{
			return base.Enabled != _0023_003DzAbAO3f4_003D.Enabled;
		}
		return true;
	}

	public override object Clone()
	{
		return new PanSettings(base.MouseButton, base.KeysStep, base.Enabled);
	}
}
