#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteNavigator : Storage
{
	private KryptonPaletteNavigatorState _stateCommon;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common navigator appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteNavigatorState StateCommon => _stateCommon;

	public KryptonPaletteNavigator(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		_stateCommon = new KryptonPaletteNavigatorState(redirect, needPaint);
	}

	public void PopulateFromBase()
	{
		_stateCommon.PopulateFromBase();
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}
}
