using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonCheckBoxDesigner : ControlDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonCheckBoxActionList(this));
			return designerActionListCollection;
		}
	}

	public KryptonCheckBoxDesigner()
	{
		base.AutoResizeHandles = true;
	}
}
