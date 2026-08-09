using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonComboBoxDesigner : ControlDesigner
{
	private bool _lastHitTest;

	private KryptonComboBox _comboBox;

	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private ISelectionService _selectionService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_comboBox != null)
			{
				return _comboBox.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override SelectionRules SelectionRules
	{
		get
		{
			SelectionRules selectionRules = base.SelectionRules;
			return selectionRules & ~(SelectionRules.TopSizeable | SelectionRules.BottomSizeable);
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonComboBoxActionList(this));
			return designerActionListCollection;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		base.AutoResizeHandles = true;
		_comboBox = component as KryptonComboBox;
		if (_comboBox != null)
		{
			_comboBox.GetViewManager().MouseUpProcessed += OnComboBoxMouseUp;
			_comboBox.GetViewManager().DoubleClickProcessed += OnComboBoxDoubleClick;
		}
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_changeService.ComponentRemoving += OnComponentRemoving;
	}

	protected override bool GetHitTest(Point point)
	{
		if (_comboBox != null)
		{
			bool flag = _comboBox.DesignerGetHitTest(_comboBox.PointToClient(point));
			if (!flag && _lastHitTest)
			{
				_comboBox.DesignerMouseLeave();
			}
			_lastHitTest = flag;
			return flag;
		}
		return false;
	}

	protected override void OnMouseLeave()
	{
		if (_comboBox != null)
		{
			_comboBox.DesignerMouseLeave();
		}
		base.OnMouseLeave();
	}

	private void OnComboBoxMouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left && _comboBox != null)
		{
			Component component = _comboBox.DesignerComponentFromPoint(new Point(e.X, e.Y));
			if (component != null)
			{
				_comboBox.PerformLayout();
				ArrayList arrayList = new ArrayList();
				arrayList.Add(component);
				_selectionService.SetSelectedComponents(arrayList, SelectionTypes.Auto);
			}
		}
	}

	private void OnComboBoxDoubleClick(object sender, Point pt)
	{
		if (_comboBox != null)
		{
			Component component = _comboBox.DesignerComponentFromPoint(pt);
			if (component != null)
			{
				IDesigner designer = _designerHost.GetDesigner(component);
				designer.DoDefaultAction();
			}
		}
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (_comboBox != null && e.Component == _comboBox)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _comboBox.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _comboBox.ButtonSpecs[num];
				_changeService.OnComponentChanging(_comboBox, null);
				_comboBox.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_comboBox, null, null, null);
			}
		}
	}
}
