using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonWrapLabelDesigner : ControlDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonWrapLabelActionList(this));
			return designerActionListCollection;
		}
	}

	public KryptonWrapLabelDesigner()
	{
		base.AutoResizeHandles = true;
	}
}
