using System;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class KryptonRibbonGroupTripleCollection : TypedRestrictCollection<KryptonRibbonGroupItem>
{
	private static readonly Type[] _types = new Type[14]
	{
		typeof(KryptonRibbonGroupButton),
		typeof(KryptonRibbonGroupColorButton),
		typeof(KryptonRibbonGroupCheckBox),
		typeof(KryptonRibbonGroupComboBox),
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

	public override int Add(object value)
	{
		if (base.Count == 3)
		{
			throw new ArgumentException("Collection can only contain 3 entries.");
		}
		return base.Add(value);
	}

	public override void Insert(int index, object value)
	{
		if (base.Count == 3)
		{
			throw new ArgumentException("Collection can only contain 3 entries.");
		}
		base.Insert(index, value);
	}

	public override void Insert(int index, KryptonRibbonGroupItem item)
	{
		if (base.Count == 3)
		{
			throw new ArgumentException("Collection can only contain 3 entries.");
		}
		base.Insert(index, item);
	}

	public override void Add(KryptonRibbonGroupItem item)
	{
		if (base.Count == 3)
		{
			throw new ArgumentException("Collection can only contain 3 entries.");
		}
		base.Add(item);
	}
}
