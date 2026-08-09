using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonRadioButtonDesigner : ControlDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonRadioButtonActionList(this));
			return designerActionListCollection;
		}
	}

	public KryptonRadioButtonDesigner()
	{
		base.AutoResizeHandles = true;
	}
}
