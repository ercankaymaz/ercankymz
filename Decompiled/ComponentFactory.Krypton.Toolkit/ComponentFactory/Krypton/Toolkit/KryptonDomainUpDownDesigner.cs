using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonDomainUpDownDesigner : ControlDesigner
{
	private bool _lastHitTest;

	private KryptonDomainUpDown _domainUpDown;

	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private ISelectionService _selectionService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_domainUpDown != null)
			{
				return _domainUpDown.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override SelectionRules SelectionRules
	{
		get
		{
			SelectionRules selectionRules = base.SelectionRules;
			KryptonDomainUpDown kryptonDomainUpDown = (KryptonDomainUpDown)base.Component;
			return selectionRules & ~(SelectionRules.TopSizeable | SelectionRules.BottomSizeable);
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonDomainUpDownActionList(this));
			return designerActionListCollection;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		base.AutoResizeHandles = true;
		_domainUpDown = component as KryptonDomainUpDown;
		if (_domainUpDown != null)
		{
			_domainUpDown.GetViewManager().MouseUpProcessed += OnDomainUpDownMouseUp;
			_domainUpDown.GetViewManager().DoubleClickProcessed += OnDomainUpDownDoubleClick;
		}
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_changeService.ComponentRemoving += OnComponentRemoving;
	}

	protected override bool GetHitTest(Point point)
	{
		if (_domainUpDown != null)
		{
			bool flag = _domainUpDown.DesignerGetHitTest(_domainUpDown.PointToClient(point));
			if (!flag && _lastHitTest)
			{
				_domainUpDown.DesignerMouseLeave();
			}
			_lastHitTest = flag;
			return flag;
		}
		return false;
	}

	protected override void OnMouseLeave()
	{
		if (_domainUpDown != null)
		{
			_domainUpDown.DesignerMouseLeave();
		}
		base.OnMouseLeave();
	}

	private void OnDomainUpDownMouseUp(object sender, MouseEventArgs e)
	{
		if (_domainUpDown != null && e.Button == MouseButtons.Left)
		{
			Component component = _domainUpDown.DesignerComponentFromPoint(new Point(e.X, e.Y));
			if (component != null)
			{
				_domainUpDown.PerformLayout();
				ArrayList arrayList = new ArrayList();
				arrayList.Add(component);
				_selectionService.SetSelectedComponents(arrayList, SelectionTypes.Auto);
			}
		}
	}

	private void OnDomainUpDownDoubleClick(object sender, Point pt)
	{
		if (_domainUpDown != null)
		{
			Component component = _domainUpDown.DesignerComponentFromPoint(pt);
			if (component != null)
			{
				IDesigner designer = _designerHost.GetDesigner(component);
				designer.DoDefaultAction();
			}
		}
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (_domainUpDown != null && e.Component == _domainUpDown)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _domainUpDown.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _domainUpDown.ButtonSpecs[num];
				_changeService.OnComponentChanging(_domainUpDown, null);
				_domainUpDown.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_domainUpDown, null, null, null);
			}
		}
	}
}
