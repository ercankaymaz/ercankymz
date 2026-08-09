using System;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonRibbonGroupTripleCollectionEditor : CollectionEditor
{
	public KryptonRibbonGroupTripleCollectionEditor()
		: base(typeof(KryptonRibbonGroupTripleCollection))
	{
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[11]
		{
			typeof(KryptonRibbonGroupButton),
			typeof(KryptonRibbonGroupColorButton),
			typeof(KryptonRibbonGroupCheckBox),
			typeof(KryptonRibbonGroupComboBox),
			typeof(KryptonRibbonGroupCustomControl),
			typeof(KryptonRibbonGroupDateTimePicker),
			typeof(KryptonRibbonGroupLabel),
			typeof(KryptonRibbonGroupRadioButton),
			typeof(KryptonRibbonGroupRichTextBox),
			typeof(KryptonRibbonGroupTextBox),
			typeof(KryptonRibbonGroupMaskedTextBox)
		};
	}
}
