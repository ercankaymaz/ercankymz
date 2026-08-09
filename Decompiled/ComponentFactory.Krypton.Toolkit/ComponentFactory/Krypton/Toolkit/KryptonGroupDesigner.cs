#define DEBUG
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonGroupDesigner : ParentControlDesigner
{
	private KryptonGroup _group;

	private IDesignerHost _designerHost;

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonGroupActionList(this));
			return designerActionListCollection;
		}
	}

	public override void Initialize(IComponent component)
	{
		Debug.Assert(component != null);
		if (component == null)
		{
			throw new ArgumentNullException("component");
		}
		base.Initialize(component);
		_group = component as KryptonGroup;
		base.AutoResizeHandles = true;
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		if (_group != null)
		{
			EnableDesignMode(_group.Panel, "Panel");
		}
	}

	public override bool CanParent(Control control)
	{
		return false;
	}

	public override ControlDesigner InternalControlDesigner(int internalControlIndex)
	{
		if (internalControlIndex == 0 && _group != null)
		{
			return (ControlDesigner)_designerHost.GetDesigner(_group.Panel);
		}
		return null;
	}

	public override int NumberOfInternalControlDesigners()
	{
		if (_group != null)
		{
			return 1;
		}
		return 0;
	}
}
