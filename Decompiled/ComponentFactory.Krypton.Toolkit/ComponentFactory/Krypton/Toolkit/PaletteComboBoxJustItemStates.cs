#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteComboBoxJustItemStates : Storage
{
	private PaletteTriple _itemState;

	[Browsable(false)]
	public override bool IsDefault => Item.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple Item => _itemState;

	public PaletteComboBoxJustItemStates(IPaletteTriple inheritItem, NeedPaintHandler needPaint)
	{
		Debug.Assert(inheritItem != null);
		NeedPaint = needPaint;
		_itemState = new PaletteTriple(inheritItem, needPaint);
	}

	public void SetInherit(IPaletteTriple inheritItem)
	{
		_itemState.SetInherit(inheritItem);
	}

	public void PopulateFromBase(PaletteState state)
	{
		_itemState.PopulateFromBase(state);
	}

	private bool ShouldSerializeItem()
	{
		return !_itemState.IsDefault;
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}
}
