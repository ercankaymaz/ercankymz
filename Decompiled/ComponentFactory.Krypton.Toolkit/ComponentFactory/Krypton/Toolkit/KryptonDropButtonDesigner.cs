using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonDropButtonDesigner : ControlDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonDropButtonActionList(this));
			return designerActionListCollection;
		}
	}

	public KryptonDropButtonDesigner()
	{
		base.AutoResizeHandles = true;
	}
}
