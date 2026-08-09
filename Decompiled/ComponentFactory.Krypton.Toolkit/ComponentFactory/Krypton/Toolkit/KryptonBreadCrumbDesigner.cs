using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonBreadCrumbDesigner : ControlDesigner
{
	private bool _lastHitTest;

	private KryptonBreadCrumb _breadCrumb;

	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private ISelectionService _selectionService;

	public override ICollection AssociatedComponents
	{
		get
		{
			ArrayList arrayList = new ArrayList(base.AssociatedComponents);
			if (_breadCrumb != null)
			{
				arrayList.AddRange(_breadCrumb.ButtonSpecs);
				arrayList.AddRange(_breadCrumb.RootItem.Items);
			}
			return arrayList;
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonBreadCrumbActionList(this));
			return designerActionListCollection;
		}
	}

	public override void Initialize(IComponent component)
	{
		if (component == null)
		{
			throw new ArgumentNullException("component");
		}
		base.Initialize(component);
		base.AutoResizeHandles = true;
		_breadCrumb = component as KryptonBreadCrumb;
		if (_breadCrumb != null)
		{
			_breadCrumb.GetViewManager().MouseUpProcessed += OnBreadCrumbMouseUp;
			_breadCrumb.GetViewManager().DoubleClickProcessed += OnBreadCrumbDoubleClick;
		}
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_changeService.ComponentRemoving += OnComponentRemoving;
	}

	protected override void Dispose(bool disposing)
	{
		if (_breadCrumb != null)
		{
			_breadCrumb.GetViewManager().MouseUpProcessed -= OnBreadCrumbMouseUp;
			_breadCrumb.GetViewManager().DoubleClickProcessed -= OnBreadCrumbDoubleClick;
		}
		_changeService.ComponentRemoving -= OnComponentRemoving;
		base.Dispose(disposing);
	}

	protected override bool GetHitTest(Point point)
	{
		if (_breadCrumb != null)
		{
			bool flag = _breadCrumb.DesignerGetHitTest(_breadCrumb.PointToClient(point));
			if (!flag && _lastHitTest)
			{
				_breadCrumb.DesignerMouseLeave();
			}
			_lastHitTest = flag;
			return flag;
		}
		return false;
	}

	protected override void OnMouseLeave()
	{
		if (_breadCrumb != null)
		{
			_breadCrumb.DesignerMouseLeave();
		}
		base.OnMouseLeave();
	}

	private void OnBreadCrumbMouseUp(object sender, MouseEventArgs e)
	{
		if (_breadCrumb != null && e.Button == MouseButtons.Left)
		{
			Component component = _breadCrumb.DesignerComponentFromPoint(new Point(e.X, e.Y));
			if (component != null)
			{
				_breadCrumb.PerformLayout();
				ArrayList arrayList = new ArrayList();
				arrayList.Add(component);
				_selectionService.SetSelectedComponents(arrayList, SelectionTypes.Auto);
			}
		}
	}

	private void OnBreadCrumbDoubleClick(object sender, Point pt)
	{
		if (_breadCrumb != null)
		{
			Component component = _breadCrumb.DesignerComponentFromPoint(pt);
			if (component != null)
			{
				IDesigner designer = _designerHost.GetDesigner(component);
				designer.DoDefaultAction();
			}
		}
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (_breadCrumb != null && e.Component == _breadCrumb)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _breadCrumb.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _breadCrumb.ButtonSpecs[num];
				_changeService.OnComponentChanging(_breadCrumb, null);
				_breadCrumb.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_breadCrumb, null, null, null);
			}
		}
	}
}
