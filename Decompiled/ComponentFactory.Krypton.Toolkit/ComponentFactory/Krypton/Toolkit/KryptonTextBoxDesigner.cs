using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonTextBoxDesigner : ControlDesigner
{
	private bool _lastHitTest;

	private KryptonTextBox _textBox;

	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private ISelectionService _selectionService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_textBox != null)
			{
				return _textBox.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override SelectionRules SelectionRules
	{
		get
		{
			SelectionRules selectionRules = base.SelectionRules;
			KryptonTextBox kryptonTextBox = (KryptonTextBox)base.Component;
			if (!kryptonTextBox.Multiline && kryptonTextBox.AutoSize)
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
			designerActionListCollection.Add(new KryptonTextBoxActionList(this));
			return designerActionListCollection;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		base.AutoResizeHandles = true;
		_textBox = component as KryptonTextBox;
		if (_textBox != null)
		{
			_textBox.GetViewManager().MouseUpProcessed += OnTextBoxMouseUp;
			_textBox.GetViewManager().DoubleClickProcessed += OnTextBoxDoubleClick;
		}
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_changeService.ComponentRemoving += OnComponentRemoving;
	}

	protected override bool GetHitTest(Point point)
	{
		if (_textBox != null)
		{
			bool flag = _textBox.DesignerGetHitTest(_textBox.PointToClient(point));
			if (!flag && _lastHitTest)
			{
				_textBox.DesignerMouseLeave();
			}
			_lastHitTest = flag;
			return flag;
		}
		return false;
	}

	protected override void OnMouseLeave()
	{
		if (_textBox != null)
		{
			_textBox.DesignerMouseLeave();
		}
		base.OnMouseLeave();
	}

	private void OnTextBoxMouseUp(object sender, MouseEventArgs e)
	{
		if (_textBox != null && e.Button == MouseButtons.Left)
		{
			Component component = _textBox.DesignerComponentFromPoint(new Point(e.X, e.Y));
			if (component != null)
			{
				_textBox.PerformLayout();
				ArrayList arrayList = new ArrayList();
				arrayList.Add(component);
				_selectionService.SetSelectedComponents(arrayList, SelectionTypes.Auto);
			}
		}
	}

	private void OnTextBoxDoubleClick(object sender, Point pt)
	{
		if (_textBox != null)
		{
			Component component = _textBox.DesignerComponentFromPoint(pt);
			if (component != null)
			{
				IDesigner designer = _designerHost.GetDesigner(component);
				designer.DoDefaultAction();
			}
		}
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (_textBox != null && e.Component == _textBox)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _textBox.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _textBox.ButtonSpecs[num];
				_changeService.OnComponentChanging(_textBox, null);
				_textBox.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_textBox, null, null, null);
			}
		}
	}
}
