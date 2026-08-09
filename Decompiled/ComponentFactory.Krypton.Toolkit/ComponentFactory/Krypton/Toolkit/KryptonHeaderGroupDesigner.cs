#define DEBUG
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonHeaderGroupDesigner : ParentControlDesigner
{
	private bool _lastHitTest;

	private KryptonHeaderGroup _headerGroup;

	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private ISelectionService _selectionService;

	public override ICollection AssociatedComponents
	{
		get
		{
			ICollection associatedComponents = base.AssociatedComponents;
			if (_headerGroup == null || _headerGroup.ButtonSpecs.Count == 0)
			{
				return associatedComponents;
			}
			ArrayList arrayList = new ArrayList(associatedComponents);
			arrayList.AddRange(_headerGroup.ButtonSpecs);
			return arrayList;
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonHeaderGroupActionList(this));
			return designerActionListCollection;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (_headerGroup != null)
		{
			_headerGroup.GetViewManager().MouseUpProcessed -= OnHeaderGroupMouseUp;
			_headerGroup.GetViewManager().DoubleClickProcessed -= OnHeaderGroupDoubleClick;
		}
		_changeService.ComponentRemoving -= OnComponentRemoving;
		base.Dispose(disposing);
	}

	public override void Initialize(IComponent component)
	{
		Debug.Assert(component != null);
		if (component == null)
		{
			throw new ArgumentNullException("component");
		}
		base.Initialize(component);
		_headerGroup = component as KryptonHeaderGroup;
		if (_headerGroup != null)
		{
			_headerGroup.GetViewManager().MouseUpProcessed += OnHeaderGroupMouseUp;
			_headerGroup.GetViewManager().DoubleClickProcessed += OnHeaderGroupDoubleClick;
		}
		base.AutoResizeHandles = true;
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_changeService.ComponentRemoving += OnComponentRemoving;
		if (_headerGroup != null)
		{
			EnableDesignMode(_headerGroup.Panel, "Panel");
		}
	}

	public override bool CanParent(Control control)
	{
		return false;
	}

	public override ControlDesigner InternalControlDesigner(int internalControlIndex)
	{
		if (_headerGroup != null && internalControlIndex == 0)
		{
			return (ControlDesigner)_designerHost.GetDesigner(_headerGroup.Panel);
		}
		return null;
	}

	public override int NumberOfInternalControlDesigners()
	{
		if (_headerGroup != null)
		{
			return 1;
		}
		return 0;
	}

	protected override bool GetHitTest(Point point)
	{
		if (_headerGroup != null)
		{
			bool flag = _headerGroup.DesignerGetHitTest(_headerGroup.PointToClient(point));
			if (!flag && _lastHitTest)
			{
				_headerGroup.DesignerMouseLeave();
			}
			_lastHitTest = flag;
			return flag;
		}
		return false;
	}

	protected override void OnMouseLeave()
	{
		if (_headerGroup != null)
		{
			_headerGroup.DesignerMouseLeave();
		}
		base.OnMouseLeave();
	}

	private void OnHeaderGroupMouseUp(object sender, MouseEventArgs e)
	{
		if (_headerGroup != null && e.Button == MouseButtons.Left)
		{
			Component component = _headerGroup.DesignerComponentFromPoint(new Point(e.X, e.Y));
			if (component != null)
			{
				_headerGroup.PerformLayout();
				ArrayList arrayList = new ArrayList();
				arrayList.Add(component);
				_selectionService.SetSelectedComponents(arrayList, SelectionTypes.Auto);
			}
		}
	}

	private void OnHeaderGroupDoubleClick(object sender, Point pt)
	{
		Component component = _headerGroup.DesignerComponentFromPoint(pt);
		if (component != null)
		{
			IDesigner designer = _designerHost.GetDesigner(component);
			designer.DoDefaultAction();
		}
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (e.Component == _headerGroup)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _headerGroup.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _headerGroup.ButtonSpecs[num];
				_changeService.OnComponentChanging(_headerGroup, null);
				_headerGroup.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_headerGroup, null, null, null);
			}
		}
	}
}
