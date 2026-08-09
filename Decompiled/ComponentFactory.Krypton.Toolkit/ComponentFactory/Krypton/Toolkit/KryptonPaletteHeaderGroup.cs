#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteHeaderGroup : Storage
{
	private KryptonPaletteHeaderGroupState _stateCommon;

	[Browsable(false)]
	public override bool IsDefault => _stateCommon.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common header group appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteHeaderGroupState StateCommon => _stateCommon;

	public KryptonPaletteHeaderGroup(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		_stateCommon = new KryptonPaletteHeaderGroupState(redirect, needPaint);
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
