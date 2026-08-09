using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonDateTimePickerDesigner : ControlDesigner
{
	private bool _lastHitTest;

	private KryptonDateTimePicker _dateTimePicker;

	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private ISelectionService _selectionService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_dateTimePicker != null)
			{
				return _dateTimePicker.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonDateTimePickerActionList(this));
			return designerActionListCollection;
		}
	}

	public override SelectionRules SelectionRules
	{
		get
		{
			SelectionRules selectionRules = base.SelectionRules;
			return selectionRules &= ~(SelectionRules.TopSizeable | SelectionRules.BottomSizeable);
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		base.AutoResizeHandles = true;
		_dateTimePicker = component as KryptonDateTimePicker;
		if (_dateTimePicker != null)
		{
			_dateTimePicker.GetViewManager().MouseUpProcessed += OnDateTimePickerMouseUp;
			_dateTimePicker.GetViewManager().DoubleClickProcessed += OnDateTimePickerDoubleClick;
		}
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_changeService.ComponentRemoving += OnComponentRemoving;
	}

	protected override void Dispose(bool disposing)
	{
		if (_dateTimePicker != null)
		{
			_dateTimePicker.GetViewManager().MouseUpProcessed -= OnDateTimePickerMouseUp;
			_dateTimePicker.GetViewManager().DoubleClickProcessed -= OnDateTimePickerDoubleClick;
		}
		_changeService.ComponentRemoving -= OnComponentRemoving;
		base.Dispose(disposing);
	}

	protected override bool GetHitTest(Point point)
	{
		if (_dateTimePicker != null)
		{
			bool flag = _dateTimePicker.DesignerGetHitTest(_dateTimePicker.PointToClient(point));
			if (!flag && _lastHitTest)
			{
				_dateTimePicker.DesignerMouseLeave();
			}
			_lastHitTest = flag;
			return flag;
		}
		return false;
	}

	protected override void OnMouseLeave()
	{
		if (_dateTimePicker != null)
		{
			_dateTimePicker.DesignerMouseLeave();
		}
		base.OnMouseLeave();
	}

	private void OnDateTimePickerMouseUp(object sender, MouseEventArgs e)
	{
		if (_dateTimePicker != null && e.Button == MouseButtons.Left)
		{
			Component component = _dateTimePicker.DesignerComponentFromPoint(new Point(e.X, e.Y));
			if (component != null)
			{
				_dateTimePicker.PerformLayout();
				ArrayList arrayList = new ArrayList();
				arrayList.Add(component);
				_selectionService.SetSelectedComponents(arrayList, SelectionTypes.Auto);
			}
		}
	}

	private void OnDateTimePickerDoubleClick(object sender, Point pt)
	{
		Component component = _dateTimePicker.DesignerComponentFromPoint(pt);
		if (component != null)
		{
			IDesigner designer = _designerHost.GetDesigner(component);
			designer.DoDefaultAction();
		}
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (e.Component == _dateTimePicker)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _dateTimePicker.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _dateTimePicker.ButtonSpecs[num];
				_changeService.OnComponentChanging(_dateTimePicker, null);
				_dateTimePicker.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_dateTimePicker, null, null, null);
			}
		}
	}
}
