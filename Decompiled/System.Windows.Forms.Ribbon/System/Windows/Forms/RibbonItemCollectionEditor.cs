using System.ComponentModel.Design;

namespace System.Windows.Forms;

public class RibbonItemCollectionEditor : CollectionEditor
{
	public RibbonItemCollectionEditor()
		: base(typeof(RibbonItemCollection))
	{
	}

	protected override Type CreateCollectionItemType()
	{
		return typeof(RibbonButton);
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[12]
		{
			typeof(RibbonButton),
			typeof(RibbonButtonList),
			typeof(RibbonItemGroup),
			typeof(RibbonComboBox),
			typeof(RibbonSeparator),
			typeof(RibbonTextBox),
			typeof(RibbonColorChooser),
			typeof(RibbonDescriptionMenuItem),
			typeof(RibbonCheckBox),
			typeof(RibbonUpDown),
			typeof(RibbonLabel),
			typeof(RibbonHost)
		};
	}
}
