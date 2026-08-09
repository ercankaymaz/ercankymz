#define DEBUG
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonRibbonGroupSeparatorDesigner : ComponentDesigner
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonGroupSeparator _ribbonSeparator;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _moveFirstVerb;

	private DesignerVerb _movePrevVerb;

	private DesignerVerb _moveNextVerb;

	private DesignerVerb _moveLastVerb;

	private DesignerVerb _deleteSeparatorVerb;

	private ContextMenuStrip _cms;

	private ToolStripMenuItem _toggleHelpersMenu;

	private ToolStripMenuItem _moveFirstMenu;

	private ToolStripMenuItem _movePreviousMenu;

	private ToolStripMenuItem _moveNextMenu;

	private ToolStripMenuItem _moveLastMenu;

	private ToolStripMenuItem _moveToGroupMenu;

	private ToolStripMenuItem _deleteSeparatorMenu;

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
		_ribbonSeparator = (KryptonRibbonGroupSeparator)component;
		_ribbonSeparator.DesignTimeContextMenu += OnContextMenu;
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_changeService.ComponentChanged += OnComponentChanged;
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing)
			{
				_ribbonSeparator.DesignTimeContextMenu -= OnContextMenu;
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
			_moveFirstVerb = new DesignerVerb("Move Separator First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move Separator Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move Separator Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move Separator Last", OnMoveLast);
			_deleteSeparatorVerb = new DesignerVerb("Delete Separator", OnDeleteSeparator);
			_verbs.AddRange(new DesignerVerb[6] { _toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _deleteSeparatorVerb });
		}
		if (_verbs != null)
		{
			bool enabled = false;
			bool enabled2 = false;
			bool enabled3 = false;
			bool enabled4 = false;
			if (_ribbonSeparator != null && _ribbonSeparator.Ribbon != null && _ribbonSeparator.RibbonGroup.Items.Contains(_ribbonSeparator))
			{
				enabled = _ribbonSeparator.RibbonGroup.Items.IndexOf(_ribbonSeparator) > 0;
				enabled2 = _ribbonSeparator.RibbonGroup.Items.IndexOf(_ribbonSeparator) > 0;
				enabled3 = _ribbonSeparator.RibbonGroup.Items.IndexOf(_ribbonSeparator) < _ribbonSeparator.RibbonGroup.Items.Count - 1;
				enabled4 = _ribbonSeparator.RibbonGroup.Items.IndexOf(_ribbonSeparator) < _ribbonSeparator.RibbonGroup.Items.Count - 1;
			}
			_moveFirstVerb.Enabled = enabled;
			_movePrevVerb.Enabled = enabled2;
			_moveNextVerb.Enabled = enabled3;
			_moveLastVerb.Enabled = enabled4;
		}
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonSeparator != null && _ribbonSeparator.Ribbon != null)
		{
			_ribbonSeparator.Ribbon.InDesignHelperMode = !_ribbonSeparator.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonSeparator != null && _ribbonSeparator.Ribbon != null && _ribbonSeparator.RibbonGroup.Items.Contains(_ribbonSeparator))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupSeparator MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonSeparator.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonSeparator.RibbonGroup;
				ribbonGroup.Items.Remove(_ribbonSeparator);
				ribbonGroup.Items.Insert(0, _ribbonSeparator);
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
		if (_ribbonSeparator != null && _ribbonSeparator.Ribbon != null && _ribbonSeparator.RibbonGroup.Items.Contains(_ribbonSeparator))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupSeparator MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonSeparator.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonSeparator.RibbonGroup;
				int val = ribbonGroup.Items.IndexOf(_ribbonSeparator) - 1;
				val = Math.Max(val, 0);
				ribbonGroup.Items.Remove(_ribbonSeparator);
				ribbonGroup.Items.Insert(val, _ribbonSeparator);
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
		if (_ribbonSeparator != null && _ribbonSeparator.Ribbon != null && _ribbonSeparator.RibbonGroup.Items.Contains(_ribbonSeparator))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupSeparator MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonSeparator.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonSeparator.RibbonGroup;
				int val = ribbonGroup.Items.IndexOf(_ribbonSeparator) + 1;
				val = Math.Min(val, ribbonGroup.Items.Count - 1);
				ribbonGroup.Items.Remove(_ribbonSeparator);
				ribbonGroup.Items.Insert(val, _ribbonSeparator);
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
		if (_ribbonSeparator != null && _ribbonSeparator.Ribbon != null && _ribbonSeparator.RibbonGroup.Items.Contains(_ribbonSeparator))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupSeparator MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonSeparator.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonSeparator.RibbonGroup;
				ribbonGroup.Items.Remove(_ribbonSeparator);
				ribbonGroup.Items.Insert(ribbonGroup.Items.Count, _ribbonSeparator);
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnDeleteSeparator(object sender, EventArgs e)
	{
		if (_ribbonSeparator != null && _ribbonSeparator.Ribbon != null && _ribbonSeparator.RibbonGroup.Items.Contains(_ribbonSeparator))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupSeparator DeleteSeparator");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonSeparator.RibbonGroup)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				_ribbonSeparator.RibbonGroup.Items.Remove(_ribbonSeparator);
				_designerHost.DestroyComponent(_ribbonSeparator);
				RaiseComponentChanged(member, null, null);
				RaiseComponentChanged(null, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonSeparator != null && _ribbonSeparator.Ribbon != null && _ribbonSeparator.RibbonGroup.Items.Contains(_ribbonSeparator))
		{
			if (_cms == null)
			{
				_cms = new ContextMenuStrip();
				_toggleHelpersMenu = new ToolStripMenuItem("Design Helpers", null, OnToggleHelpers);
				_moveFirstMenu = new ToolStripMenuItem("Move Separator First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move Separator Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move Separator Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move Separator Last", Resources.MoveLast, OnMoveLast);
				_moveToGroupMenu = new ToolStripMenuItem("Move Separator To Group");
				_deleteSeparatorMenu = new ToolStripMenuItem("Delete Separator", Resources.delete2, OnDeleteSeparator);
				_cms.Items.AddRange(new ToolStripItem[10]
				{
					_toggleHelpersMenu,
					new ToolStripSeparator(),
					_moveFirstMenu,
					_movePreviousMenu,
					_moveNextMenu,
					_moveLastMenu,
					new ToolStripSeparator(),
					_moveToGroupMenu,
					new ToolStripSeparator(),
					_deleteSeparatorMenu
				});
			}
			UpdateVerbStatus();
			UpdateMoveToGroup();
			_toggleHelpersMenu.Checked = _ribbonSeparator.Ribbon.InDesignHelperMode;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			_moveToGroupMenu.Enabled = _moveToGroupMenu.DropDownItems.Count > 0;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonSeparator.Ribbon.ViewRectangleToPoint(_ribbonSeparator.SeparatorView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}

	private void UpdateMoveToGroup()
	{
		_moveToGroupMenu.DropDownItems.Clear();
		if (_ribbonSeparator.Ribbon == null)
		{
			return;
		}
		foreach (KryptonRibbonGroup group in _ribbonSeparator.RibbonTab.Groups)
		{
			if (group != _ribbonSeparator.RibbonGroup)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
				toolStripMenuItem.Text = group.TextLine1 + " " + group.TextLine2;
				toolStripMenuItem.Tag = group;
				toolStripMenuItem.Click += OnMoveToGroup;
				_moveToGroupMenu.DropDownItems.Add(toolStripMenuItem);
			}
		}
	}

	private void OnMoveToGroup(object sender, EventArgs e)
	{
		if (_ribbonSeparator != null && _ribbonSeparator.Ribbon != null && _ribbonSeparator.RibbonGroup.Items.Contains(_ribbonSeparator))
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			KryptonRibbonGroup kryptonRibbonGroup = (KryptonRibbonGroup)toolStripMenuItem.Tag;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupSeparator MoveSeparatorToGroup");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonSeparator.RibbonGroup)["Items"];
				MemberDescriptor member2 = TypeDescriptor.GetProperties(kryptonRibbonGroup)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				RaiseComponentChanging(member2);
				_ribbonSeparator.RibbonGroup.Items.Remove(_ribbonSeparator);
				kryptonRibbonGroup.Items.Add(_ribbonSeparator);
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
