namespace System.Windows.Forms;

internal class RibbonComboBoxDesigner : RibbonElementWithItemCollectionDesigner
{
	public override Ribbon Ribbon
	{
		get
		{
			if (base.Component is RibbonComboBox ribbonComboBox)
			{
				return ribbonComboBox.Owner;
			}
			return null;
		}
	}

	public override RibbonItemCollection Collection
	{
		get
		{
			if (base.Component is RibbonComboBox ribbonComboBox)
			{
				return ribbonComboBox.DropDownItems;
			}
			return null;
		}
	}
}
