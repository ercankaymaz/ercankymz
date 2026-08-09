#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteComboBoxJustComboStates : Storage
{
	private PaletteInputControlTripleStates _comboBoxState;

	[Browsable(false)]
	public override bool IsDefault => ComboBox.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining combo box appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlTripleStates ComboBox => _comboBoxState;

	public PaletteComboBoxJustComboStates(IPaletteTriple inheritComboBox, NeedPaintHandler needPaint)
	{
		Debug.Assert(inheritComboBox != null);
		NeedPaint = needPaint;
		_comboBoxState = new PaletteInputControlTripleStates(inheritComboBox, needPaint);
	}

	public void SetInherit(IPaletteTriple inheritComboBox)
	{
		_comboBoxState.SetInherit(inheritComboBox);
	}

	public void PopulateFromBase(PaletteState state)
	{
		_comboBoxState.PopulateFromBase(state);
	}

	private bool ShouldSerializeComboBox()
	{
		return !_comboBoxState.IsDefault;
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}
}
