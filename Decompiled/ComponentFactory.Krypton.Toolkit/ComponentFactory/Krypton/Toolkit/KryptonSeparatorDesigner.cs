using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonSeparatorDesigner : ControlDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonSeparatorActionList(this));
			return designerActionListCollection;
		}
	}

	public KryptonSeparatorDesigner()
	{
		base.AutoResizeHandles = true;
	}
}
