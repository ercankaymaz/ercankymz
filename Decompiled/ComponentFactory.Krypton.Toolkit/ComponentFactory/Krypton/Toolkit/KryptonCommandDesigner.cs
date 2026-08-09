using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonCommandDesigner : ComponentDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonCommandActionList(this));
			return designerActionListCollection;
		}
	}
}
