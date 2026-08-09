#define DEBUG
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonRibbonTabDesigner : ComponentDesigner
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonTab _ribbonTab;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _moveFirstVerb;

	private DesignerVerb _movePrevVerb;

	private DesignerVerb _moveNextVerb;

	private DesignerVerb _moveLastVerb;

	private DesignerVerb _addGroupVerb;

	private DesignerVerb _clearGroupsVerb;

	private DesignerVerb _deleteTabVerb;

	private ContextMenuStrip _cms;

	private ToolStripMenuItem _toggleHelpersMenu;

	private ToolStripMenuItem _visibleMenu;

	private ToolStripMenuItem _moveFirstMenu;

	private ToolStripMenuItem _movePreviousMenu;

	private ToolStripMenuItem _moveNextMenu;

	private ToolStripMenuItem _moveLastMenu;

	private ToolStripMenuItem _addGroupMenu;

	private ToolStripMenuItem _clearGroupsMenu;

	private ToolStripMenuItem _deleteTabMenu;

	public override ICollection AssociatedComponents
	{
		get
		{
			ArrayList arrayList = new ArrayList(base.AssociatedComponents);
			arrayList.AddRange(_ribbonTab.Groups);
			return arrayList;
		}
	}

	public override DesignerVerbCollection Verbs
	{
		get
		{
			UpdateVerbStatus();
			return _verbs;
		}
	}

	public override void Initialize(IComponent component)
	{
		Debug.Assert(component != null);
		if (component == null)
		{
			throw new ArgumentNullException("component");
		}
		base.Initialize(component);
		_ribbonTab = (KryptonRibbonTab)component;
		_ribbonTab.DesignTimeAddGroup += OnAddGroup;
		_ribbonTab.DesignTimeContextMenu += OnContextMenu;
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_changeService.ComponentRemoving += OnComponentRemoving;
		_changeService.ComponentChanged += OnComponentChanged;
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing)
			{
				if (_cms != null)
				{
					_cms.Dispose();
					_cms = null;
				}
				_ribbonTab.DesignTimeAddGroup -= OnAddGroup;
				_ribbonTab.DesignTimeContextMenu -= OnContextMenu;
				_changeService.ComponentRemoving -= OnComponentRemoving;
				_changeService.ComponentChanged -= OnComponentChanged;
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void UpdateVerbStatus()
	{
		if (_verbs == null)
		{
			_verbs = new DesignerVerbCollection();
			_toggleHelpersVerb = new DesignerVerb("Toggle Helpers", OnToggleHelpers);
			_moveFirstVerb = new DesignerVerb("Move First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move Last", OnMoveLast);
			_addGroupVerb = new DesignerVerb("Add Group", OnAddGroup);
			_clearGroupsVerb = new DesignerVerb("Clear Groups", OnClearGroups);
			_deleteTabVerb = new DesignerVerb("Delete Tab", OnDeleteTab);
			_verbs.AddRange(new DesignerVerb[8] { _toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _addGroupVerb, _clearGroupsVerb, _deleteTabVerb });
		}
		bool enabled = false;
		bool enabled2 = false;
		bool enabled3 = false;
		bool enabled4 = false;
		bool enabled5 = false;
		if (_ribbonTab != null && _ribbonTab.Ribbon != null && _ribbonTab.Ribbon.RibbonTabs.Contains(_ribbonTab))
		{
			enabled = _ribbonTab.Ribbon.RibbonTabs.IndexOf(_ribbonTab) > 0;
			enabled2 = _ribbonTab.Ribbon.RibbonTabs.IndexOf(_ribbonTab) > 0;
			enabled3 = _ribbonTab.Ribbon.RibbonTabs.IndexOf(_ribbonTab) < _ribbonTab.Ribbon.RibbonTabs.Count - 1;
			enabled4 = _ribbonTab.Ribbon.RibbonTabs.IndexOf(_ribbonTab) < _ribbonTab.Ribbon.RibbonTabs.Count - 1;
			enabled5 = _ribbonTab.Groups.Count > 0;
		}
		_moveFirstVerb.Enabled = enabled;
		_movePrevVerb.Enabled = enabled2;
		_moveNextVerb.Enabled = enabled3;
		_moveLastVerb.Enabled = enabled4;
		_clearGroupsVerb.Enabled = enabled5;
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonTab != null && _ribbonTab.Ribbon != null)
		{
			_ribbonTab.Ribbon.InDesignHelperMode = !_ribbonTab.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonTab != null && _ribbonTab.Ribbon != null && _ribbonTab.Ribbon.RibbonTabs.Contains(_ribbonTab))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonTab MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTab.Ribbon)["RibbonTabs"];
				RaiseComponentChanging(member);
				KryptonRibbon ribbon = _ribbonTab.Ribbon;
				ribbon.RibbonTabs.Remove(_ribbonTab);
				ribbon.RibbonTabs.Insert(0, _ribbonTab);
				ribbon.SelectedTab = _ribbonTab;
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnMovePrevious(object sender, EventArgs e)
	{
		if (_ribbonTab != null && _ribbonTab.Ribbon != null && _ribbonTab.Ribbon.RibbonTabs.Contains(_ribbonTab))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonTab MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTab.Ribbon)["RibbonTabs"];
				RaiseComponentChanging(member);
				KryptonRibbon ribbon = _ribbonTab.Ribbon;
				int val = ribbon.RibbonTabs.IndexOf(_ribbonTab) - 1;
				val = Math.Max(val, 0);
				ribbon.RibbonTabs.Remove(_ribbonTab);
				ribbon.RibbonTabs.Insert(val, _ribbonTab);
				ribbon.SelectedTab = _ribbonTab;
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnMoveNext(object sender, EventArgs e)
	{
		if (_ribbonTab != null && _ribbonTab.Ribbon != null && _ribbonTab.Ribbon.RibbonTabs.Contains(_ribbonTab))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonTab MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTab.Ribbon)["RibbonTabs"];
				RaiseComponentChanging(member);
				KryptonRibbon ribbon = _ribbonTab.Ribbon;
				int val = ribbon.RibbonTabs.IndexOf(_ribbonTab) + 1;
				val = Math.Min(val, ribbon.RibbonTabs.Count - 1);
				ribbon.RibbonTabs.Remove(_ribbonTab);
				ribbon.RibbonTabs.Insert(val, _ribbonTab);
				ribbon.SelectedTab = _ribbonTab;
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnMoveLast(object sender, EventArgs e)
	{
		if (_ribbonTab != null && _ribbonTab.Ribbon != null && _ribbonTab.Ribbon.RibbonTabs.Contains(_ribbonTab))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonTab MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTab.Ribbon)["RibbonTabs"];
				RaiseComponentChanging(member);
				KryptonRibbon ribbon = _ribbonTab.Ribbon;
				ribbon.RibbonTabs.Remove(_ribbonTab);
				ribbon.RibbonTabs.Insert(ribbon.RibbonTabs.Count, _ribbonTab);
				ribbon.SelectedTab = _ribbonTab;
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddGroup(object sender, EventArgs e)
	{
		if (_ribbonTab != null && _ribbonTab.Ribbon != null && _ribbonTab.Ribbon.RibbonTabs.Contains(_ribbonTab))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonTab AddGroup");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTab)["Groups"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup item = (KryptonRibbonGroup)_designerHost.CreateComponent(typeof(KryptonRibbonGroup));
				_ribbonTab.Groups.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnClearGroups(object sender, EventArgs e)
	{
		if (_ribbonTab == null || _ribbonTab.Ribbon == null || !_ribbonTab.Ribbon.RibbonTabs.Contains(_ribbonTab))
		{
			return;
		}
		DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonTab ClearGroups");
		try
		{
			MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTab)["Groups"];
			RaiseComponentChanging(member);
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _ribbonTab.Groups.Count - 1; num >= 0; num--)
			{
				KryptonRibbonGroup item = _ribbonTab.Groups[num];
				_ribbonTab.Groups.Remove(item);
				designerHost.DestroyComponent(item);
			}
			RaiseComponentChanged(member, null, null);
		}
		finally
		{
			designerTransaction?.Commit();
		}
	}

	private void OnDeleteTab(object sender, EventArgs e)
	{
		if (_ribbonTab != null && _ribbonTab.Ribbon != null && _ribbonTab.Ribbon.RibbonTabs.Contains(_ribbonTab))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonTab DeleteTab");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTab.Ribbon)["RibbonTabs"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				_ribbonTab.Ribbon.RibbonTabs.Remove(_ribbonTab);
				_designerHost.DestroyComponent(_ribbonTab);
				RaiseComponentChanged(member, null, null);
				RaiseComponentChanged(null, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnVisible(object sender, EventArgs e)
	{
		if (_ribbonTab != null && _ribbonTab.Ribbon != null && _ribbonTab.Ribbon.RibbonTabs.Contains(_ribbonTab))
		{
			_changeService.OnComponentChanged(_ribbonTab, null, _ribbonTab.Visible, !_ribbonTab.Visible);
			_ribbonTab.Visible = !_ribbonTab.Visible;
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (e.Component == _ribbonTab)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _ribbonTab.Groups.Count - 1; num >= 0; num--)
			{
				KryptonRibbonGroup item = _ribbonTab.Groups[num];
				_ribbonTab.Groups.Remove(item);
				designerHost.DestroyComponent(item);
			}
		}
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonTab != null && _ribbonTab.Ribbon != null && _ribbonTab.Ribbon.RibbonTabs.Contains(_ribbonTab))
		{
			if (_cms == null)
			{
				_cms = new ContextMenuStrip();
				_toggleHelpersMenu = new ToolStripMenuItem("Design Helpers", null, OnToggleHelpers);
				_visibleMenu = new ToolStripMenuItem("Visible", null, OnVisible);
				_moveFirstMenu = new ToolStripMenuItem("Move First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move Last", Resources.MoveLast, OnMoveLast);
				_addGroupMenu = new ToolStripMenuItem("Add Group", Resources.KryptonRibbonGroup, OnAddGroup);
				_clearGroupsMenu = new ToolStripMenuItem("Clear Groups", null, OnClearGroups);
				_deleteTabMenu = new ToolStripMenuItem("Delete Tab", Resources.delete2, OnDeleteTab);
				_cms.Items.AddRange(new ToolStripItem[14]
				{
					_toggleHelpersMenu,
					new ToolStripSeparator(),
					_visibleMenu,
					new ToolStripSeparator(),
					_moveFirstMenu,
					_movePreviousMenu,
					_moveNextMenu,
					_moveLastMenu,
					new ToolStripSeparator(),
					_addGroupMenu,
					new ToolStripSeparator(),
					_clearGroupsMenu,
					new ToolStripSeparator(),
					_deleteTabMenu
				});
				_addGroupMenu.ImageTransparentColor = Color.Magenta;
			}
			UpdateVerbStatus();
			_toggleHelpersMenu.Checked = _ribbonTab.Ribbon.InDesignHelperMode;
			_visibleMenu.Checked = _ribbonTab.Visible;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			_clearGroupsMenu.Enabled = _clearGroupsVerb.Enabled;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonTab.Ribbon.ViewRectangleToPoint(_ribbonTab.TabView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}
}
