using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonListBoxDesigner : ControlDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonListBoxActionList(this));
			return designerActionListCollection;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		base.AutoResizeHandles = true;
	}
}
