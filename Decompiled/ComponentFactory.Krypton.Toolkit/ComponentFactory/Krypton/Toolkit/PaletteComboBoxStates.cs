#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteComboBoxStates : Storage
{
	private PaletteTriple _itemState;

	private PaletteInputControlTripleStates _comboBoxState;

	[Browsable(false)]
	public override bool IsDefault => ComboBox.IsDefault && Item.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining combo box appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlTripleStates ComboBox => _comboBoxState;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple Item => _itemState;

	public PaletteComboBoxStates(IPaletteTriple inheritComboBox, IPaletteTriple inheritItem, NeedPaintHandler needPaint)
	{
		Debug.Assert(inheritComboBox != null);
		Debug.Assert(inheritItem != null);
		NeedPaint = needPaint;
		_itemState = new PaletteTriple(inheritItem, needPaint);
		_comboBoxState = new PaletteInputControlTripleStates(inheritComboBox, needPaint);
	}

	public void SetInherit(IPaletteTriple inheritComboBox, IPaletteTriple inheritItem)
	{
		_comboBoxState.SetInherit(inheritComboBox);
		_itemState.SetInherit(inheritItem);
	}

	public void PopulateFromBase(PaletteState state)
	{
		_comboBoxState.PopulateFromBase(state);
		_itemState.PopulateFromBase(state);
	}

	private bool ShouldSerializeComboBox()
	{
		return !_comboBoxState.IsDefault;
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
