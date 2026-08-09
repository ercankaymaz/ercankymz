using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonRichTextBoxDesigner : ControlDesigner
{
	private bool _lastHitTest;

	private KryptonRichTextBox _richTextBox;

	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private ISelectionService _selectionService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_richTextBox != null)
			{
				return _richTextBox.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override SelectionRules SelectionRules
	{
		get
		{
			SelectionRules selectionRules = base.SelectionRules;
			KryptonRichTextBox kryptonRichTextBox = (KryptonRichTextBox)base.Component;
			if (!kryptonRichTextBox.Multiline && kryptonRichTextBox.AutoSize)
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
			designerActionListCollection.Add(new KryptonRichTextBoxActionList(this));
			return designerActionListCollection;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		base.AutoResizeHandles = true;
		_richTextBox = component as KryptonRichTextBox;
		if (_richTextBox != null)
		{
			_richTextBox.GetViewManager().MouseUpProcessed += OnTextBoxMouseUp;
			_richTextBox.GetViewManager().DoubleClickProcessed += OnTextBoxDoubleClick;
		}
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_changeService.ComponentRemoving += OnComponentRemoving;
	}

	protected override bool GetHitTest(Point point)
	{
		if (_richTextBox != null)
		{
			bool flag = _richTextBox.DesignerGetHitTest(_richTextBox.PointToClient(point));
			if (!flag && _lastHitTest)
			{
				_richTextBox.DesignerMouseLeave();
			}
			_lastHitTest = flag;
			return flag;
		}
		return false;
	}

	protected override void OnMouseLeave()
	{
		if (_richTextBox != null)
		{
			_richTextBox.DesignerMouseLeave();
		}
		base.OnMouseLeave();
	}

	private void OnTextBoxMouseUp(object sender, MouseEventArgs e)
	{
		if (_richTextBox != null && e.Button == MouseButtons.Left)
		{
			Component component = _richTextBox.DesignerComponentFromPoint(new Point(e.X, e.Y));
			if (component != null)
			{
				_richTextBox.PerformLayout();
				ArrayList arrayList = new ArrayList();
				arrayList.Add(component);
				_selectionService.SetSelectedComponents(arrayList, SelectionTypes.Auto);
			}
		}
	}

	private void OnTextBoxDoubleClick(object sender, Point pt)
	{
		Component component = _richTextBox.DesignerComponentFromPoint(pt);
		if (component != null)
		{
			IDesigner designer = _designerHost.GetDesigner(component);
			designer.DoDefaultAction();
		}
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (e.Component == _richTextBox)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _richTextBox.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _richTextBox.ButtonSpecs[num];
				_changeService.OnComponentChanging(_richTextBox, null);
				_richTextBox.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_richTextBox, null, null, null);
			}
		}
	}
}
