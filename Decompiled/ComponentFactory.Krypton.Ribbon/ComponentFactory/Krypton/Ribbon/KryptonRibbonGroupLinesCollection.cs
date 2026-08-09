using System;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class KryptonRibbonGroupLinesCollection : TypedRestrictCollection<KryptonRibbonGroupItem>
{
	private static readonly Type[] _types = new Type[15]
	{
		typeof(KryptonRibbonGroupButton),
		typeof(KryptonRibbonGroupColorButton),
		typeof(KryptonRibbonGroupCheckBox),
		typeof(KryptonRibbonGroupComboBox),
		typeof(KryptonRibbonGroupCluster),
		typeof(KryptonRibbonGroupCustomControl),
		typeof(KryptonRibbonGroupDateTimePicker),
		typeof(KryptonRibbonGroupDomainUpDown),
		typeof(KryptonRibbonGroupLabel),
		typeof(KryptonRibbonGroupNumericUpDown),
		typeof(KryptonRibbonGroupRadioButton),
		typeof(KryptonRibbonGroupRichTextBox),
		typeof(KryptonRibbonGroupTextBox),
		typeof(KryptonRibbonGroupTrackBar),
		typeof(KryptonRibbonGroupMaskedTextBox)
	};

	public override Type[] RestrictTypes => _types;
}
