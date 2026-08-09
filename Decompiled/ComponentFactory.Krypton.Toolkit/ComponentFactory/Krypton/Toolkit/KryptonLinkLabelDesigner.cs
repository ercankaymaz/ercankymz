using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonLinkLabelDesigner : ControlDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonLinkLabelActionList(this));
			return designerActionListCollection;
		}
	}

	public KryptonLinkLabelDesigner()
	{
		base.AutoResizeHandles = true;
	}
}
