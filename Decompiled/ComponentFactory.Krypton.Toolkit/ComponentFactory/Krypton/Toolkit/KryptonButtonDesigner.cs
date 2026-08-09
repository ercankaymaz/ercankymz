using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonButtonDesigner : ControlDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonButtonActionList(this));
			return designerActionListCollection;
		}
	}

	public KryptonButtonDesigner()
	{
		base.AutoResizeHandles = true;
	}
}
