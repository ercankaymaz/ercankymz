using System.ComponentModel.Design;

namespace System.Windows.Forms;

internal class RibbonOrbMenuItemDesigner : RibbonElementWithItemCollectionDesigner
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

	protected override DesignerVerbCollection OnGetVerbs()
	{
		return new DesignerVerbCollection(new DesignerVerb[2]
		{
			new DesignerVerb("Add DescriptionMenuItem", AddDescriptionMenuItem),
			new DesignerVerb("Add Separator", AddSeparator)
		});
	}
}
