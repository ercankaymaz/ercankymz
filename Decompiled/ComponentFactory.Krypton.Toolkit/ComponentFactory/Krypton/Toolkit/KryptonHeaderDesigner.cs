using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonHeaderDesigner : ControlDesigner
{
	private bool _lastHitTest;

	private KryptonHeader _header;

	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private ISelectionService _selectionService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_header != null)
			{
				return _header.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonHeaderActionList(this));
			return designerActionListCollection;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (_header != null)
		{
			ViewManager viewManager = _header.GetViewManager();
			if (viewManager != null)
			{
				viewManager.MouseUpProcessed -= OnHeaderMouseUp;
				viewManager.DoubleClickProcessed -= OnHeaderDoubleClick;
			}
		}
		if (_changeService != null)
		{
			_changeService.ComponentRemoving -= OnComponentRemoving;
		}
		base.Dispose(disposing);
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		base.AutoResizeHandles = true;
		_header = component as KryptonHeader;
		if (_header != null)
		{
			_header.GetViewManager().MouseUpProcessed += OnHeaderMouseUp;
			_header.GetViewManager().DoubleClickProcessed += OnHeaderDoubleClick;
		}
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_changeService.ComponentRemoving += OnComponentRemoving;
	}

	protected override bool GetHitTest(Point point)
	{
		if (_header != null)
		{
			bool flag = _header.DesignerGetHitTest(_header.PointToClient(point));
			if (!flag && _lastHitTest)
			{
				_header.DesignerMouseLeave();
			}
			_lastHitTest = flag;
			return flag;
		}
		return false;
	}

	protected override void OnMouseLeave()
	{
		if (_header != null)
		{
			_header.DesignerMouseLeave();
		}
		base.OnMouseLeave();
	}

	private void OnHeaderMouseUp(object sender, MouseEventArgs e)
	{
		if (_header != null && e.Button == MouseButtons.Left)
		{
			Component component = _header.DesignerComponentFromPoint(new Point(e.X, e.Y));
			if (component != null)
			{
				_header.PerformLayout();
				ArrayList arrayList = new ArrayList();
				arrayList.Add(component);
				_selectionService.SetSelectedComponents(arrayList, SelectionTypes.Auto);
			}
		}
	}

	private void OnHeaderDoubleClick(object sender, Point pt)
	{
		if (_header != null)
		{
			Component component = _header.DesignerComponentFromPoint(pt);
			if (component != null)
			{
				IDesigner designer = _designerHost.GetDesigner(component);
				designer.DoDefaultAction();
			}
		}
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (_header != null && e.Component == _header)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _header.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _header.ButtonSpecs[num];
				_changeService.OnComponentChanging(_header, null);
				_header.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_header, null, null, null);
			}
		}
	}
}
