namespace System.Windows.Forms;

internal class RibbonButtonListDesigner : RibbonElementWithItemCollectionDesigner
{
	public override Ribbon Ribbon
	{
		get
		{
			if (base.Component is RibbonButtonList ribbonButtonList)
			{
				return ribbonButtonList.Owner;
			}
			return null;
		}
	}

	public override RibbonItemCollection Collection
	{
		get
		{
			if (base.Component is RibbonButtonList ribbonButtonList)
			{
				return ribbonButtonList.Buttons;
			}
			return null;
		}
	}
}
