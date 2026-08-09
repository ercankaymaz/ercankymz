using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonBorderEdgeDesigner : ControlDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonBorderEdgeActionList(this));
			return designerActionListCollection;
		}
	}

	public KryptonBorderEdgeDesigner()
	{
		base.AutoResizeHandles = true;
	}
}
