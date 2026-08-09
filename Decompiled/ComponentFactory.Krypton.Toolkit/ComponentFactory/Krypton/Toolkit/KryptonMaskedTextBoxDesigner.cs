using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonMaskedTextBoxDesigner : ControlDesigner
{
	private bool _lastHitTest;

	private KryptonMaskedTextBox _maskedTextBox;

	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private ISelectionService _selectionService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_maskedTextBox != null)
			{
				return _maskedTextBox.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override SelectionRules SelectionRules
	{
		get
		{
			SelectionRules selectionRules = base.SelectionRules;
			KryptonMaskedTextBox kryptonMaskedTextBox = (KryptonMaskedTextBox)base.Component;
			if (kryptonMaskedTextBox.AutoSize)
			{
				selectionRules &= ~(SelectionRules.TopSizeable | SelectionRules.BottomSizeable);
			}
			return selectionRules;
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonMaskedTextBoxActionList(this));
			return designerActionListCollection;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		base.AutoResizeHandles = true;
		_maskedTextBox = component as KryptonMaskedTextBox;
		if (_maskedTextBox != null)
		{
			_maskedTextBox.GetViewManager().MouseUpProcessed += OnMaskedTextBoxMouseUp;
			_maskedTextBox.GetViewManager().DoubleClickProcessed += OnMaskedTextBoxDoubleClick;
		}
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_changeService.ComponentRemoving += OnComponentRemoving;
	}

	protected override bool GetHitTest(Point point)
	{
		if (_maskedTextBox != null)
		{
			bool flag = _maskedTextBox.DesignerGetHitTest(_maskedTextBox.PointToClient(point));
			if (!flag && _lastHitTest)
			{
				_maskedTextBox.DesignerMouseLeave();
			}
			_lastHitTest = flag;
			return flag;
		}
		return false;
	}

	protected override void OnMouseLeave()
	{
		if (_maskedTextBox != null)
		{
			_maskedTextBox.DesignerMouseLeave();
		}
		base.OnMouseLeave();
	}

	private void OnMaskedTextBoxMouseUp(object sender, MouseEventArgs e)
	{
		if (_maskedTextBox != null && e.Button == MouseButtons.Left)
		{
			Component component = _maskedTextBox.DesignerComponentFromPoint(new Point(e.X, e.Y));
			if (component != null)
			{
				_maskedTextBox.PerformLayout();
				ArrayList arrayList = new ArrayList();
				arrayList.Add(component);
				_selectionService.SetSelectedComponents(arrayList, SelectionTypes.Auto);
			}
		}
	}

	private void OnMaskedTextBoxDoubleClick(object sender, Point pt)
	{
		Component component = _maskedTextBox.DesignerComponentFromPoint(pt);
		if (component != null)
		{
			IDesigner designer = _designerHost.GetDesigner(component);
			designer.DoDefaultAction();
		}
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (e.Component == _maskedTextBox)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _maskedTextBox.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _maskedTextBox.ButtonSpecs[num];
				_changeService.OnComponentChanging(_maskedTextBox, null);
				_maskedTextBox.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_maskedTextBox, null, null, null);
			}
		}
	}
}
