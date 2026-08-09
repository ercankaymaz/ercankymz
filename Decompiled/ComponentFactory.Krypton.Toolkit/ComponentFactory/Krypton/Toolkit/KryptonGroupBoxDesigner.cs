#define DEBUG
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonGroupBoxDesigner : ParentControlDesigner
{
	private KryptonGroupBox _groupBox;

	private IDesignerHost _designerHost;

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonGroupBoxActionList(this));
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
		_groupBox = component as KryptonGroupBox;
		base.AutoResizeHandles = true;
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		if (_groupBox != null)
		{
			EnableDesignMode(_groupBox.Panel, "Panel");
		}
	}

	public override bool CanParent(Control control)
	{
		return false;
	}

	public override ControlDesigner InternalControlDesigner(int internalControlIndex)
	{
		if (_groupBox != null && internalControlIndex == 0)
		{
			return (ControlDesigner)_designerHost.GetDesigner(_groupBox.Panel);
		}
		return null;
	}

	public override int NumberOfInternalControlDesigners()
	{
		if (_groupBox != null)
		{
			return 1;
		}
		return 0;
	}
}
