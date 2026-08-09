using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonNumericUpDownDesigner : ControlDesigner
{
	private bool _lastHitTest;

	private KryptonNumericUpDown _numericUpDown;

	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private ISelectionService _selectionService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_numericUpDown != null)
			{
				return _numericUpDown.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override SelectionRules SelectionRules
	{
		get
		{
			SelectionRules selectionRules = base.SelectionRules;
			KryptonNumericUpDown kryptonNumericUpDown = (KryptonNumericUpDown)base.Component;
			return selectionRules & ~(SelectionRules.TopSizeable | SelectionRules.BottomSizeable);
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonNumericUpDownActionList(this));
			return designerActionListCollection;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		base.AutoResizeHandles = true;
		_numericUpDown = component as KryptonNumericUpDown;
		if (_numericUpDown != null)
		{
			_numericUpDown.GetViewManager().MouseUpProcessed += OnNumericUpDownMouseUp;
			_numericUpDown.GetViewManager().DoubleClickProcessed += OnNumericUpDownDoubleClick;
		}
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_changeService.ComponentRemoving += OnComponentRemoving;
	}

	protected override bool GetHitTest(Point point)
	{
		if (_numericUpDown != null)
		{
			bool flag = _numericUpDown.DesignerGetHitTest(_numericUpDown.PointToClient(point));
			if (!flag && _lastHitTest)
			{
				_numericUpDown.DesignerMouseLeave();
			}
			_lastHitTest = flag;
			return flag;
		}
		return false;
	}

	protected override void OnMouseLeave()
	{
		if (_numericUpDown != null)
		{
			_numericUpDown.DesignerMouseLeave();
		}
		base.OnMouseLeave();
	}

	private void OnNumericUpDownMouseUp(object sender, MouseEventArgs e)
	{
		if (_numericUpDown != null && e.Button == MouseButtons.Left)
		{
			Component component = _numericUpDown.DesignerComponentFromPoint(new Point(e.X, e.Y));
			if (component != null)
			{
				_numericUpDown.PerformLayout();
				ArrayList arrayList = new ArrayList();
				arrayList.Add(component);
				_selectionService.SetSelectedComponents(arrayList, SelectionTypes.Auto);
			}
		}
	}

	private void OnNumericUpDownDoubleClick(object sender, Point pt)
	{
		if (_numericUpDown != null)
		{
			Component component = _numericUpDown.DesignerComponentFromPoint(pt);
			if (component != null)
			{
				IDesigner designer = _designerHost.GetDesigner(component);
				designer.DoDefaultAction();
			}
		}
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (_numericUpDown != null && e.Component == _numericUpDown)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _numericUpDown.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _numericUpDown.ButtonSpecs[num];
				_changeService.OnComponentChanging(_numericUpDown, null);
				_numericUpDown.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_numericUpDown, null, null, null);
			}
		}
	}
}
