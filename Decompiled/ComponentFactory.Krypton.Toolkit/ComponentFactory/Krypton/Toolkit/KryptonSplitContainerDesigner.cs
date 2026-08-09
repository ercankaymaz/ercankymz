#define DEBUG
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonSplitContainerDesigner : ParentControlDesigner
{
	private KryptonSplitContainer _splitContainer;

	private IDesignerHost _designerHost;

	private ISelectionService _selectionService;

	private BehaviorService _behaviorService;

	private Adorner _adorner;

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonSplitContainerActionList(this));
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
		base.AutoResizeHandles = true;
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_behaviorService = (BehaviorService)GetService(typeof(BehaviorService));
		_splitContainer = component as KryptonSplitContainer;
		_adorner = new Adorner();
		_adorner.Glyphs.Add(new KryptonSplitContainerGlyph(_selectionService, _behaviorService, _adorner, this));
		_behaviorService.Adorners.Add(_adorner);
		if (_splitContainer != null)
		{
			EnableDesignMode(_splitContainer.Panel1, "Panel1");
			EnableDesignMode(_splitContainer.Panel2, "Panel2");
		}
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _behaviorService != null)
			{
				_behaviorService.Adorners.Remove(_adorner);
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	public override bool CanParent(Control control)
	{
		return false;
	}

	public override ControlDesigner InternalControlDesigner(int internalControlIndex)
	{
		if (_splitContainer != null)
		{
			switch (internalControlIndex)
			{
			case 0:
				return (ControlDesigner)_designerHost.GetDesigner(_splitContainer.Panel1);
			case 1:
				return (ControlDesigner)_designerHost.GetDesigner(_splitContainer.Panel2);
			}
		}
		return null;
	}

	public override int NumberOfInternalControlDesigners()
	{
		if (_splitContainer != null)
		{
			return 2;
		}
		return 0;
	}

	protected override void OnDragEnter(DragEventArgs de)
	{
		de.Effect = DragDropEffects.None;
	}
}
