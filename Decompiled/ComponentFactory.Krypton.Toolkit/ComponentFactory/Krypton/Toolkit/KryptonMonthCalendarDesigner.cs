using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonMonthCalendarDesigner : ControlDesigner
{
	private bool _lastHitTest;

	private KryptonMonthCalendar _monthCalendar;

	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private ISelectionService _selectionService;

	public override ICollection AssociatedComponents
	{
		get
		{
			ICollection associatedComponents = base.AssociatedComponents;
			if (_monthCalendar == null || _monthCalendar.ButtonSpecs.Count == 0)
			{
				return associatedComponents;
			}
			ArrayList arrayList = new ArrayList(associatedComponents);
			arrayList.AddRange(_monthCalendar.ButtonSpecs);
			return arrayList;
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonMonthCalendarActionList(this));
			return designerActionListCollection;
		}
	}

	public override SelectionRules SelectionRules
	{
		get
		{
			SelectionRules selectionRules = base.SelectionRules;
			return selectionRules & ~(SelectionRules.TopSizeable | SelectionRules.LeftSizeable);
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
		_monthCalendar = component as KryptonMonthCalendar;
		if (_monthCalendar != null)
		{
			_monthCalendar.GetViewManager().MouseUpProcessed += OnCalendarMouseUp;
			_monthCalendar.GetViewManager().DoubleClickProcessed += OnCalendarDoubleClick;
		}
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_changeService.ComponentRemoving += OnComponentRemoving;
	}

	protected override void Dispose(bool disposing)
	{
		if (_monthCalendar != null)
		{
			_monthCalendar.GetViewManager().MouseUpProcessed -= OnCalendarMouseUp;
			_monthCalendar.GetViewManager().DoubleClickProcessed -= OnCalendarDoubleClick;
		}
		_changeService.ComponentRemoving -= OnComponentRemoving;
		base.Dispose(disposing);
	}

	protected override bool GetHitTest(Point point)
	{
		if (_monthCalendar != null)
		{
			bool flag = _monthCalendar.DesignerGetHitTest(_monthCalendar.PointToClient(point));
			if (!flag && _lastHitTest)
			{
				_monthCalendar.DesignerMouseLeave();
			}
			_lastHitTest = flag;
			return flag;
		}
		return false;
	}

	protected override void OnMouseLeave()
	{
		if (_monthCalendar != null)
		{
			_monthCalendar.DesignerMouseLeave();
		}
		base.OnMouseLeave();
	}

	private void OnCalendarMouseUp(object sender, MouseEventArgs e)
	{
		if (_monthCalendar != null && e.Button == MouseButtons.Left)
		{
			Component component = _monthCalendar.DesignerComponentFromPoint(new Point(e.X, e.Y));
			if (component != null)
			{
				_monthCalendar.PerformLayout();
				ArrayList arrayList = new ArrayList();
				arrayList.Add(component);
				_selectionService.SetSelectedComponents(arrayList, SelectionTypes.Auto);
			}
		}
	}

	private void OnCalendarDoubleClick(object sender, Point pt)
	{
		Component component = _monthCalendar.DesignerComponentFromPoint(pt);
		if (component != null)
		{
			IDesigner designer = _designerHost.GetDesigner(component);
			designer.DoDefaultAction();
		}
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (e.Component == _monthCalendar)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _monthCalendar.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _monthCalendar.ButtonSpecs[num];
				_changeService.OnComponentChanging(_monthCalendar, null);
				_monthCalendar.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_monthCalendar, null, null, null);
			}
		}
	}
}
