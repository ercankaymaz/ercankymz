namespace System.Windows.Forms;

internal class RibbonPanelDesigner : RibbonElementWithItemCollectionDesigner
{
	public override Ribbon Ribbon
	{
		get
		{
			if (base.Component is RibbonPanel ribbonPanel)
			{
				return ribbonPanel.Owner;
			}
			return null;
		}
	}

	public override RibbonItemCollection Collection
	{
		get
		{
			if (base.Component is RibbonPanel ribbonPanel)
			{
				return ribbonPanel.Items;
			}
			return null;
		}
	}
}
