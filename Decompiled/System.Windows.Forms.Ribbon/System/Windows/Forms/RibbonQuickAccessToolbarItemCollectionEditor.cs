using System.ComponentModel.Design;

namespace System.Windows.Forms;

public class RibbonQuickAccessToolbarItemCollectionEditor : CollectionEditor
{
	public RibbonQuickAccessToolbarItemCollectionEditor()
		: base(typeof(RibbonQuickAccessToolbarItemCollection))
	{
	}

	protected override Type CreateCollectionItemType()
	{
		return typeof(RibbonItem);
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[9]
		{
			typeof(RibbonButton),
			typeof(RibbonComboBox),
			typeof(RibbonSeparator),
			typeof(RibbonTextBox),
			typeof(RibbonColorChooser),
			typeof(RibbonCheckBox),
			typeof(RibbonUpDown),
			typeof(RibbonLabel),
			typeof(RibbonHost)
		};
	}
}
