namespace System.Windows.Forms;

internal class RibbonItemGroupDesigner : RibbonElementWithItemCollectionDesigner
{
	public override Ribbon Ribbon
	{
		get
		{
			if (base.Component is RibbonItemGroup ribbonItemGroup)
			{
				return ribbonItemGroup.Owner;
			}
			return null;
		}
	}

	public override RibbonItemCollection Collection
	{
		get
		{
			if (base.Component is RibbonItemGroup ribbonItemGroup)
			{
				return ribbonItemGroup.Items;
			}
			return null;
		}
	}
}
