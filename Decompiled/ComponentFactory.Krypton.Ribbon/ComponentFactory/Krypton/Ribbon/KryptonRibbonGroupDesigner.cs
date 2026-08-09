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

internal class KryptonRibbonGroupDesigner : ComponentDesigner
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonGroup _ribbonGroup;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _moveFirstVerb;

	private DesignerVerb _movePrevVerb;

	private DesignerVerb _moveNextVerb;

	private DesignerVerb _moveLastVerb;

	private DesignerVerb _addTripleVerb;

	private DesignerVerb _addLinesVerb;

	private DesignerVerb _addSepVerb;

	private DesignerVerb _addGalleryVerb;

	private DesignerVerb _clearItemsVerb;

	private DesignerVerb _deleteGroupVerb;

	private ContextMenuStrip _cms;

	private ToolStripMenuItem _toggleHelpersMenu;

	private ToolStripMenuItem _visibleMenu;

	private ToolStripMenuItem _collapsableMenu;

	private ToolStripMenuItem _dialogLauncherMenu;

	private ToolStripMenuItem _moveFirstMenu;

	private ToolStripMenuItem _movePreviousMenu;

	private ToolStripMenuItem _moveNextMenu;

	private ToolStripMenuItem _moveLastMenu;

	private ToolStripMenuItem _moveToTabMenu;

	private ToolStripMenuItem _addTripleMenu;

	private ToolStripMenuItem _addLinesMenu;

	private ToolStripMenuItem _addSeparatorMenu;

	private ToolStripMenuItem _addGalleryMenu;

	private ToolStripMenuItem _clearItemsMenu;

	private ToolStripMenuItem _deleteGroupMenu;

	public override ICollection AssociatedComponents
	{
		get
		{
			ArrayList arrayList = new ArrayList(base.AssociatedComponents);
			arrayList.AddRange(_ribbonGroup.Items);
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
		_ribbonGroup = (KryptonRibbonGroup)component;
		_ribbonGroup.DesignTimeAddTriple += OnAddTriple;
		_ribbonGroup.DesignTimeAddLines += OnAddLines;
		_ribbonGroup.DesignTimeAddSeparator += OnAddSep;
		_ribbonGroup.DesignTimeAddGallery += OnAddGallery;
		_ribbonGroup.DesignTimeContextMenu += OnContextMenu;
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
				_ribbonGroup.DesignTimeAddTriple -= OnAddTriple;
				_ribbonGroup.DesignTimeAddLines -= OnAddLines;
				_ribbonGroup.DesignTimeAddSeparator -= OnAddSep;
				_ribbonGroup.DesignTimeAddGallery -= OnAddGallery;
				_ribbonGroup.DesignTimeContextMenu -= OnContextMenu;
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
			_moveFirstVerb = new DesignerVerb("Move Group First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move Group Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move Group Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move Group Last", OnMoveLast);
			_addTripleVerb = new DesignerVerb("Add Triple", OnAddTriple);
			_addLinesVerb = new DesignerVerb("Add Lines", OnAddLines);
			_addSepVerb = new DesignerVerb("Add Separator", OnAddSep);
			_addGalleryVerb = new DesignerVerb("Add Gallery", OnAddGallery);
			_clearItemsVerb = new DesignerVerb("Clear Items", OnClearItems);
			_deleteGroupVerb = new DesignerVerb("Delete Group", OnDeleteGroup);
			_verbs.AddRange(new DesignerVerb[11]
			{
				_toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _addTripleVerb, _addLinesVerb, _addSepVerb, _addGalleryVerb, _clearItemsVerb,
				_deleteGroupVerb
			});
		}
		bool enabled = false;
		bool enabled2 = false;
		bool enabled3 = false;
		bool enabled4 = false;
		bool enabled5 = false;
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			enabled = _ribbonGroup.RibbonTab.Groups.IndexOf(_ribbonGroup) > 0;
			enabled2 = _ribbonGroup.RibbonTab.Groups.IndexOf(_ribbonGroup) > 0;
			enabled3 = _ribbonGroup.RibbonTab.Groups.IndexOf(_ribbonGroup) < _ribbonGroup.RibbonTab.Groups.Count - 1;
			enabled4 = _ribbonGroup.RibbonTab.Groups.IndexOf(_ribbonGroup) < _ribbonGroup.RibbonTab.Groups.Count - 1;
			enabled5 = _ribbonGroup.Items.Count > 0;
		}
		_moveFirstVerb.Enabled = enabled;
		_movePrevVerb.Enabled = enabled2;
		_moveNextVerb.Enabled = enabled3;
		_moveLastVerb.Enabled = enabled4;
		_clearItemsVerb.Enabled = enabled5;
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null)
		{
			_ribbonGroup.Ribbon.InDesignHelperMode = !_ribbonGroup.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroup MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGroup.RibbonTab)["Groups"];
				RaiseComponentChanging(member);
				KryptonRibbonTab ribbonTab = _ribbonGroup.RibbonTab;
				ribbonTab.Groups.Remove(_ribbonGroup);
				ribbonTab.Groups.Insert(0, _ribbonGroup);
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
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroup MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGroup.RibbonTab)["Groups"];
				RaiseComponentChanging(member);
				KryptonRibbonTab ribbonTab = _ribbonGroup.RibbonTab;
				int val = ribbonTab.Groups.IndexOf(_ribbonGroup) - 1;
				val = Math.Max(val, 0);
				ribbonTab.Groups.Remove(_ribbonGroup);
				ribbonTab.Groups.Insert(val, _ribbonGroup);
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
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroup MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGroup.RibbonTab)["Groups"];
				RaiseComponentChanging(member);
				KryptonRibbonTab ribbonTab = _ribbonGroup.RibbonTab;
				int val = ribbonTab.Groups.IndexOf(_ribbonGroup) + 1;
				val = Math.Min(val, ribbonTab.Groups.Count - 1);
				ribbonTab.Groups.Remove(_ribbonGroup);
				ribbonTab.Groups.Insert(val, _ribbonGroup);
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
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroup MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGroup.RibbonTab)["Groups"];
				RaiseComponentChanging(member);
				KryptonRibbonTab ribbonTab = _ribbonGroup.RibbonTab;
				ribbonTab.Groups.Remove(_ribbonGroup);
				ribbonTab.Groups.Insert(ribbonTab.Groups.Count, _ribbonGroup);
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddTriple(object sender, EventArgs e)
	{
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroup AddTriple");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupTriple kryptonRibbonGroupTriple = (KryptonRibbonGroupTriple)_designerHost.CreateComponent(typeof(KryptonRibbonGroupTriple));
				_ribbonGroup.Items.Add(kryptonRibbonGroupTriple);
				MemberDescriptor member2 = TypeDescriptor.GetProperties(kryptonRibbonGroupTriple)["Items"];
				RaiseComponentChanging(member2);
				KryptonRibbonGroupButton item = (KryptonRibbonGroupButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupButton));
				KryptonRibbonGroupButton item2 = (KryptonRibbonGroupButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupButton));
				KryptonRibbonGroupButton item3 = (KryptonRibbonGroupButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupButton));
				kryptonRibbonGroupTriple.Items.Add(item);
				kryptonRibbonGroupTriple.Items.Add(item2);
				kryptonRibbonGroupTriple.Items.Add(item3);
				RaiseComponentChanged(member2, null, null);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddLines(object sender, EventArgs e)
	{
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroup AddLines");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_designerHost.CreateComponent(typeof(KryptonRibbonGroupLines));
				_ribbonGroup.Items.Add(kryptonRibbonGroupLines);
				MemberDescriptor member2 = TypeDescriptor.GetProperties(kryptonRibbonGroupLines)["Items"];
				RaiseComponentChanging(member2);
				KryptonRibbonGroupButton item = (KryptonRibbonGroupButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupButton));
				KryptonRibbonGroupButton item2 = (KryptonRibbonGroupButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupButton));
				kryptonRibbonGroupLines.Items.Add(item);
				kryptonRibbonGroupLines.Items.Add(item2);
				RaiseComponentChanged(member2, null, null);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddSep(object sender, EventArgs e)
	{
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroup AddSep");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupSeparator item = (KryptonRibbonGroupSeparator)_designerHost.CreateComponent(typeof(KryptonRibbonGroupSeparator));
				_ribbonGroup.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddGallery(object sender, EventArgs e)
	{
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroup AddGallery");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupGallery item = (KryptonRibbonGroupGallery)_designerHost.CreateComponent(typeof(KryptonRibbonGroupGallery));
				_ribbonGroup.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnClearItems(object sender, EventArgs e)
	{
		if (_ribbonGroup == null || _ribbonGroup.Ribbon == null || !_ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			return;
		}
		DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroup ClearItems");
		try
		{
			MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGroup)["Items"];
			RaiseComponentChanging(member);
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _ribbonGroup.Items.Count - 1; num >= 0; num--)
			{
				KryptonRibbonGroupContainer item = _ribbonGroup.Items[num];
				_ribbonGroup.Items.Remove(item);
				designerHost.DestroyComponent(item);
			}
			RaiseComponentChanged(member, null, null);
		}
		finally
		{
			designerTransaction?.Commit();
		}
	}

	private void OnDeleteGroup(object sender, EventArgs e)
	{
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroup DeleteGroup");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGroup.RibbonTab)["Groups"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				_ribbonGroup.RibbonTab.Groups.Remove(_ribbonGroup);
				_designerHost.DestroyComponent(_ribbonGroup);
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
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			_changeService.OnComponentChanged(_ribbonGroup, null, _ribbonGroup.Visible, !_ribbonGroup.Visible);
			_ribbonGroup.Visible = !_ribbonGroup.Visible;
		}
	}

	private void OnCollapsable(object sender, EventArgs e)
	{
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			_changeService.OnComponentChanged(_ribbonGroup, null, _ribbonGroup.AllowCollapsed, !_ribbonGroup.AllowCollapsed);
			_ribbonGroup.AllowCollapsed = !_ribbonGroup.AllowCollapsed;
		}
	}

	private void OnDialogLauncher(object sender, EventArgs e)
	{
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			_changeService.OnComponentChanged(_ribbonGroup, null, _ribbonGroup.DialogBoxLauncher, !_ribbonGroup.DialogBoxLauncher);
			_ribbonGroup.DialogBoxLauncher = !_ribbonGroup.DialogBoxLauncher;
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (e.Component == _ribbonGroup)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _ribbonGroup.Items.Count - 1; num >= 0; num--)
			{
				KryptonRibbonGroupContainer item = _ribbonGroup.Items[num];
				_ribbonGroup.Items.Remove(item);
				designerHost.DestroyComponent(item);
			}
		}
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			if (_cms == null)
			{
				_cms = new ContextMenuStrip();
				_toggleHelpersMenu = new ToolStripMenuItem("Design Helpers", null, OnToggleHelpers);
				_visibleMenu = new ToolStripMenuItem("Visible", null, OnVisible);
				_collapsableMenu = new ToolStripMenuItem("Allow Collapsed", null, OnCollapsable);
				_dialogLauncherMenu = new ToolStripMenuItem("Dialog Launcher", null, OnDialogLauncher);
				_moveFirstMenu = new ToolStripMenuItem("Move Group First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move Group Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move Group Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move Group Last", Resources.MoveLast, OnMoveLast);
				_moveToTabMenu = new ToolStripMenuItem("Move Group To Tab");
				_addTripleMenu = new ToolStripMenuItem("Add Triple", Resources.KryptonRibbonGroupTriple, OnAddTriple);
				_addLinesMenu = new ToolStripMenuItem("Add Lines", Resources.KryptonRibbonGroupLines, OnAddLines);
				_addSeparatorMenu = new ToolStripMenuItem("Add Separator", Resources.KryptonRibbonGroupSeparator, OnAddSep);
				_addGalleryMenu = new ToolStripMenuItem("Add Gallery", Resources.KryptonGallery, OnAddGallery);
				_clearItemsMenu = new ToolStripMenuItem("Clear Items", null, OnClearItems);
				_deleteGroupMenu = new ToolStripMenuItem("Delete Group", Resources.delete2, OnDeleteGroup);
				_cms.Items.AddRange(new ToolStripItem[21]
				{
					_toggleHelpersMenu,
					new ToolStripSeparator(),
					_visibleMenu,
					_collapsableMenu,
					_dialogLauncherMenu,
					new ToolStripSeparator(),
					_moveFirstMenu,
					_movePreviousMenu,
					_moveNextMenu,
					_moveLastMenu,
					new ToolStripSeparator(),
					_moveToTabMenu,
					new ToolStripSeparator(),
					_addTripleMenu,
					_addLinesMenu,
					_addSeparatorMenu,
					_addGalleryMenu,
					new ToolStripSeparator(),
					_clearItemsMenu,
					new ToolStripSeparator(),
					_deleteGroupMenu
				});
				_addTripleMenu.ImageTransparentColor = Color.Magenta;
				_addLinesMenu.ImageTransparentColor = Color.Magenta;
				_addSeparatorMenu.ImageTransparentColor = Color.Magenta;
				_addGalleryMenu.ImageTransparentColor = Color.Magenta;
			}
			UpdateVerbStatus();
			UpdateMoveToTab();
			_toggleHelpersMenu.Checked = _ribbonGroup.Ribbon.InDesignHelperMode;
			_visibleMenu.Checked = _ribbonGroup.Visible;
			_collapsableMenu.Checked = _ribbonGroup.AllowCollapsed;
			_dialogLauncherMenu.Checked = _ribbonGroup.DialogBoxLauncher;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			_moveToTabMenu.Enabled = _moveToTabMenu.DropDownItems.Count > 0;
			_clearItemsMenu.Enabled = _clearItemsVerb.Enabled;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonGroup.Ribbon.ViewRectangleToPoint(_ribbonGroup.GroupView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}

	private void UpdateMoveToTab()
	{
		_moveToTabMenu.DropDownItems.Clear();
		if (_ribbonGroup.Ribbon == null)
		{
			return;
		}
		foreach (KryptonRibbonTab ribbonTab in _ribbonGroup.Ribbon.RibbonTabs)
		{
			if (ribbonTab != _ribbonGroup.RibbonTab)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
				toolStripMenuItem.Text = ribbonTab.Text;
				toolStripMenuItem.Tag = ribbonTab;
				toolStripMenuItem.Click += OnMoveToTab;
				_moveToTabMenu.DropDownItems.Add(toolStripMenuItem);
			}
		}
	}

	private void OnMoveToTab(object sender, EventArgs e)
	{
		if (_ribbonGroup != null && _ribbonGroup.Ribbon != null && _ribbonGroup.RibbonTab.Groups.Contains(_ribbonGroup))
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			KryptonRibbonTab kryptonRibbonTab = (KryptonRibbonTab)toolStripMenuItem.Tag;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroup MoveTabTo");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGroup.RibbonTab)["Groups"];
				MemberDescriptor member2 = TypeDescriptor.GetProperties(kryptonRibbonTab)["Groups"];
				MemberDescriptor member3 = TypeDescriptor.GetProperties(_ribbonGroup.Ribbon)["RibbonTabs"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				RaiseComponentChanging(member2);
				RaiseComponentChanging(member3);
				_ribbonGroup.RibbonTab.Groups.Remove(_ribbonGroup);
				kryptonRibbonTab.Groups.Add(_ribbonGroup);
				RaiseComponentChanged(member3, null, null);
				RaiseComponentChanged(member2, null, null);
				RaiseComponentChanged(member, null, null);
				RaiseComponentChanged(null, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}
}
