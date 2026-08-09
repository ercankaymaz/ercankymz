#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteNavigatorState : Storage
{
	private KryptonPaletteNavigatorStateBar _bar;

	[Browsable(false)]
	public override bool IsDefault => _bar.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining navigator bar appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteNavigatorStateBar Bar => _bar;

	public KryptonPaletteNavigatorState(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		_bar = new KryptonPaletteNavigatorStateBar(redirect, needPaint);
	}

	public void PopulateFromBase()
	{
		_bar.PopulateFromBase();
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_bar.IsDefault;
	}
}
