using System;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonRibbonGroupLinesCollectionEditor : CollectionEditor
{
	public KryptonRibbonGroupLinesCollectionEditor()
		: base(typeof(KryptonRibbonGroupLinesCollection))
	{
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[12]
		{
			typeof(KryptonRibbonGroupButton),
			typeof(KryptonRibbonGroupColorButton),
			typeof(KryptonRibbonGroupCheckBox),
			typeof(KryptonRibbonGroupComboBox),
			typeof(KryptonRibbonGroupCluster),
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
