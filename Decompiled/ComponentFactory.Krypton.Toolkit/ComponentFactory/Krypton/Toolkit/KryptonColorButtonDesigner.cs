using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonColorButtonDesigner : ControlDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonColorButtonActionList(this));
			return designerActionListCollection;
		}
	}

	public KryptonColorButtonDesigner()
	{
		base.AutoResizeHandles = true;
	}
}
