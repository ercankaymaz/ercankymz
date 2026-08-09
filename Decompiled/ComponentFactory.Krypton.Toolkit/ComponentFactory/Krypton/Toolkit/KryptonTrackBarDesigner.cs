using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonTrackBarDesigner : ControlDesigner
{
	private KryptonTrackBar _trackBar;

	public override SelectionRules SelectionRules
	{
		get
		{
			if (!_trackBar.AutoSize)
			{
				return SelectionRules.AllSizeable | SelectionRules.Moveable;
			}
			if (_trackBar.Orientation == Orientation.Horizontal)
			{
				return SelectionRules.Moveable | SelectionRules.LeftSizeable | SelectionRules.RightSizeable;
			}
			return SelectionRules.Moveable | SelectionRules.TopSizeable | SelectionRules.BottomSizeable;
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonTrackBarActionList(this));
			return designerActionListCollection;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		base.AutoResizeHandles = true;
		_trackBar = component as KryptonTrackBar;
	}
}
