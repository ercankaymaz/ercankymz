namespace System.Windows.Forms;

internal class RibbonButtonDesigner : RibbonElementWithItemCollectionDesigner
{
	public override Ribbon Ribbon
	{
		get
		{
			if (base.Component is RibbonButton ribbonButton)
			{
				return ribbonButton.Owner;
			}
			return null;
		}
	}

	public override RibbonItemCollection Collection
	{
		get
		{
			if (base.Component is RibbonButton ribbonButton)
			{
				return ribbonButton.DropDownItems;
			}
			return null;
		}
	}

	protected override void AddButton(object sender, EventArgs e)
	{
		base.AddButton(sender, e);
	}
}
