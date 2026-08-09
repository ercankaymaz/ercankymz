using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonLabelDesigner : ControlDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonLabelActionList(this));
			return designerActionListCollection;
		}
	}

	public KryptonLabelDesigner()
	{
		base.AutoResizeHandles = true;
	}
}
