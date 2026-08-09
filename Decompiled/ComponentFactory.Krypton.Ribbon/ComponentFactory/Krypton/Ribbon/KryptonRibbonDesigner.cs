#define DEBUG
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonRibbonDesigner : ParentControlDesigner
{
	private KryptonRibbon _ribbon;

	private IDesignerHost _designerHost;

	private ISelectionService _selectionService;

	private IComponentChangeService _changeService;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _addTabVerb;

	private DesignerVerb _clearTabsVerb;

	private bool _lastHitTest;

	public override ICollection AssociatedComponents
	{
		get
		{
			ArrayList arrayList = new ArrayList(base.AssociatedComponents);
			arrayList.AddRange(_ribbon.ButtonSpecs);
			arrayList.AddRange(_ribbon.QATButtons);
			arrayList.AddRange(_ribbon.RibbonContexts);
			arrayList.AddRange(_ribbon.RibbonAppButton.AppButtonMenuItems);
			arrayList.AddRange(_ribbon.RibbonAppButton.AppButtonRecentDocs);
			arrayList.AddRange(_ribbon.RibbonAppButton.AppButtonSpecs);
			foreach (KryptonRibbonTab ribbonTab in _ribbon.RibbonTabs)
			{
				arrayList.Add(ribbonTab);
			}
			return arrayList;
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonRibbonActionList(this));
			return designerActionListCollection;
		}
	}

	public override DesignerVerbCollection Verbs
	{
		get
		{
			if (_verbs == null)
			{
				_verbs = new DesignerVerbCollection();
				_toggleHelpersVerb = new DesignerVerb("Toggle Helpers", OnToggleHelpers);
				_addTabVerb = new DesignerVerb("Add Tab", OnAddTab);
				_clearTabsVerb = new DesignerVerb("Clear Tabs", OnClearTabs);
				_verbs.AddRange(new DesignerVerb[3] { _toggleHelpersVerb, _addTabVerb, _clearTabsVerb });
			}
			UpdateVerbStatus();
			return _verbs;
		}
	}

	public KryptonRibbonDesigner()
	{
		base.AutoResizeHandles = true;
	}

	public override void Initialize(IComponent component)
	{
		Debug.Assert(component != null);
		if (component == null)
		{
			throw new ArgumentNullException("component");
		}
		base.Initialize(component);
		_ribbon = (KryptonRibbon)component;
		_ribbon.GetViewManager().MouseUpProcessed += OnRibbonMouseUp;
		_ribbon.GetViewManager().DoubleClickProcessed += OnRibbonDoubleClick;
		_ribbon.SelectedTabChanged += OnSelectedTabChanged;
		_ribbon.DesignTimeAddTab += OnAddTab;
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		_changeService.ComponentRemoving += OnComponentRemoving;
		_changeService.ComponentChanged += OnComponentChanged;
	}

	public override bool CanParent(Control control)
	{
		return false;
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing)
			{
				_ribbon.GetViewManager().MouseUpProcessed -= OnRibbonMouseUp;
				_ribbon.GetViewManager().DoubleClickProcessed -= OnRibbonDoubleClick;
				_ribbon.SelectedTabChanged -= OnSelectedTabChanged;
				_ribbon.DesignTimeAddTab -= OnAddTab;
				_changeService.ComponentRemoving -= OnComponentRemoving;
				_changeService.ComponentChanged -= OnComponentChanged;
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	protected override bool GetHitTest(Point point)
	{
		bool flag = _ribbon.DesignerGetHitTest(_ribbon.PointToClient(point));
		if (!flag && _lastHitTest)
		{
			_ribbon.DesignerMouseLeave();
		}
		_lastHitTest = flag;
		return flag;
	}

	protected override void OnMouseLeave()
	{
		_ribbon.DesignerMouseLeave();
		base.OnMouseLeave();
	}

	protected override void OnDragEnter(DragEventArgs de)
	{
		de.Effect = DragDropEffects.None;
	}

	protected override void OnDragOver(DragEventArgs de)
	{
		de.Effect = DragDropEffects.None;
	}

	protected override void OnDragDrop(DragEventArgs de)
	{
		de.Effect = DragDropEffects.None;
	}

	private void OnSelectedTabChanged(object sender, EventArgs e)
	{
		MemberDescriptor member = TypeDescriptor.GetProperties(_ribbon)["SelectedTab"];
		RaiseComponentChanging(member);
		RaiseComponentChanged(member, null, null);
	}

	private void UpdateVerbStatus()
	{
		if (_verbs != null)
		{
			_clearTabsVerb.Enabled = _ribbon.RibbonTabs.Count > 0;
		}
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		_ribbon.InDesignHelperMode = !_ribbon.InDesignHelperMode;
	}

	private void OnAddTab(object sender, EventArgs e)
	{
		DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbon AddTab");
		try
		{
			MemberDescriptor member = TypeDescriptor.GetProperties(_ribbon)["RibbonTabs"];
			RaiseComponentChanging(member);
			KryptonRibbonTab item = (KryptonRibbonTab)_designerHost.CreateComponent(typeof(KryptonRibbonTab));
			_ribbon.RibbonTabs.Add(item);
			RaiseComponentChanged(member, null, null);
		}
		finally
		{
			designerTransaction?.Commit();
			UpdateVerbStatus();
		}
	}

	private void OnClearTabs(object sender, EventArgs e)
	{
		DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbon ClearTabs");
		try
		{
			MemberDescriptor member = TypeDescriptor.GetProperties(_ribbon)["RibbonTabs"];
			RaiseComponentChanging(member);
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _ribbon.RibbonTabs.Count - 1; num >= 0; num--)
			{
				KryptonRibbonTab item = _ribbon.RibbonTabs[num];
				_ribbon.RibbonTabs.Remove(item);
				designerHost.DestroyComponent(item);
			}
			RaiseComponentChanged(member, null, null);
		}
		finally
		{
			designerTransaction?.Commit();
			UpdateVerbStatus();
		}
	}

	private void OnRibbonMouseUp(object sender, MouseEventArgs e)
	{
		Component component = _ribbon.DesignerComponentFromPoint(new Point(e.X, e.Y));
		if (component != null)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(component);
			_selectionService.SetSelectedComponents(arrayList, SelectionTypes.Auto);
			_ribbon.PerformLayout();
		}
	}

	private void OnRibbonDoubleClick(object sender, Point pt)
	{
		Component component = _ribbon.DesignerComponentFromPoint(pt);
		if (component != null && !(component is Control))
		{
			IDesigner designer = _designerHost.GetDesigner(component);
			designer.DoDefaultAction();
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (e.Component == _ribbon)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _ribbon.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _ribbon.ButtonSpecs[num];
				_ribbon.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
			}
			for (int num2 = _ribbon.QATButtons.Count - 1; num2 >= 0; num2--)
			{
				Component item = _ribbon.QATButtons[num2];
				_ribbon.QATButtons.Remove(item);
				designerHost.DestroyComponent(item);
			}
			for (int num3 = _ribbon.RibbonContexts.Count - 1; num3 >= 0; num3--)
			{
				KryptonRibbonContext item2 = _ribbon.RibbonContexts[num3];
				_ribbon.RibbonContexts.Remove(item2);
				designerHost.DestroyComponent(item2);
			}
			for (int num4 = _ribbon.RibbonTabs.Count - 1; num4 >= 0; num4--)
			{
				KryptonRibbonTab item3 = _ribbon.RibbonTabs[num4];
				_ribbon.RibbonTabs.Remove(item3);
				designerHost.DestroyComponent(item3);
			}
		}
	}
}
