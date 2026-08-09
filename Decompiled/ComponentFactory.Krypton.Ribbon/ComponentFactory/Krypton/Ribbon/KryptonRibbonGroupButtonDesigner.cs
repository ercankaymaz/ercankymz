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

internal class KryptonRibbonGroupButtonDesigner : ComponentDesigner
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonGroupButton _ribbonButton;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _moveFirstVerb;

	private DesignerVerb _movePrevVerb;

	private DesignerVerb _moveNextVerb;

	private DesignerVerb _moveLastVerb;

	private DesignerVerb _deleteButtonVerb;

	private ContextMenuStrip _cms;

	private ToolStripMenuItem _toggleHelpersMenu;

	private ToolStripMenuItem _visibleMenu;

	private ToolStripMenuItem _enabledMenu;

	private ToolStripMenuItem _checkedMenu;

	private ToolStripMenuItem _typeMenu;

	private ToolStripMenuItem _typePushMenu;

	private ToolStripMenuItem _typeCheckMenu;

	private ToolStripMenuItem _typeDropDownMenu;

	private ToolStripMenuItem _typeSplitMenu;

	private ToolStripMenuItem _moveFirstMenu;

	private ToolStripMenuItem _movePreviousMenu;

	private ToolStripMenuItem _moveNextMenu;

	private ToolStripMenuItem _moveLastMenu;

	private ToolStripMenuItem _deleteButtonMenu;

	public override DesignerVerbCollection Verbs
	{
		get
		{
			UpdateVerbStatus();
			return _verbs;
		}
	}

	private TypedRestrictCollection<KryptonRibbonGroupItem> ParentItems
	{
		get
		{
			if (_ribbonButton.RibbonContainer is KryptonRibbonGroupTriple)
			{
				KryptonRibbonGroupTriple kryptonRibbonGroupTriple = (KryptonRibbonGroupTriple)_ribbonButton.RibbonContainer;
				return kryptonRibbonGroupTriple.Items;
			}
			if (_ribbonButton.RibbonContainer is KryptonRibbonGroupLines)
			{
				KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_ribbonButton.RibbonContainer;
				return kryptonRibbonGroupLines.Items;
			}
			Debug.Assert(condition: false);
			return null;
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
		_ribbonButton = (KryptonRibbonGroupButton)component;
		_ribbonButton.DesignTimeContextMenu += OnContextMenu;
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
				_ribbonButton.DesignTimeContextMenu -= OnContextMenu;
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
			_moveFirstVerb = new DesignerVerb("Move Button First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move Button Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move Button Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move Button Last", OnMoveLast);
			_deleteButtonVerb = new DesignerVerb("Delete Button", OnDeleteButton);
			_verbs.AddRange(new DesignerVerb[6] { _toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _deleteButtonVerb });
		}
		bool enabled = false;
		bool enabled2 = false;
		bool enabled3 = false;
		bool enabled4 = false;
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			enabled = parentItems.IndexOf(_ribbonButton) > 0;
			enabled2 = parentItems.IndexOf(_ribbonButton) > 0;
			enabled3 = parentItems.IndexOf(_ribbonButton) < parentItems.Count - 1;
			enabled4 = parentItems.IndexOf(_ribbonButton) < parentItems.Count - 1;
		}
		_moveFirstVerb.Enabled = enabled;
		_movePrevVerb.Enabled = enabled2;
		_moveNextVerb.Enabled = enabled3;
		_moveLastVerb.Enabled = enabled4;
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			_ribbonButton.Ribbon.InDesignHelperMode = !_ribbonButton.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupButton MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonButton.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonButton);
				parentItems.Insert(0, _ribbonButton);
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
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupButton MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonButton.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				int val = parentItems.IndexOf(_ribbonButton) - 1;
				val = Math.Max(val, 0);
				parentItems.Remove(_ribbonButton);
				parentItems.Insert(val, _ribbonButton);
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
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupButton MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonButton.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				int val = parentItems.IndexOf(_ribbonButton) + 1;
				val = Math.Min(val, parentItems.Count - 1);
				parentItems.Remove(_ribbonButton);
				parentItems.Insert(val, _ribbonButton);
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
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupButton MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonButton.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonButton);
				parentItems.Insert(parentItems.Count, _ribbonButton);
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnDeleteButton(object sender, EventArgs e)
	{
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupButton DeleteButton");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonButton.RibbonContainer)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonButton);
				_designerHost.DestroyComponent(_ribbonButton);
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
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonButton, null, _ribbonButton.Visible, !_ribbonButton.Visible);
			_ribbonButton.Visible = !_ribbonButton.Visible;
		}
	}

	private void OnEnabled(object sender, EventArgs e)
	{
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonButton, null, _ribbonButton.Enabled, !_ribbonButton.Enabled);
			_ribbonButton.Enabled = !_ribbonButton.Enabled;
		}
	}

	private void OnChecked(object sender, EventArgs e)
	{
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonButton, null, _ribbonButton.Checked, !_ribbonButton.Checked);
			_ribbonButton.Checked = !_ribbonButton.Checked;
		}
	}

	private void OnTypePush(object sender, EventArgs e)
	{
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonButton, null, _ribbonButton.ButtonType, GroupButtonType.Push);
			_ribbonButton.ButtonType = GroupButtonType.Push;
		}
	}

	private void OnTypeCheck(object sender, EventArgs e)
	{
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonButton, null, _ribbonButton.ButtonType, GroupButtonType.Check);
			_ribbonButton.ButtonType = GroupButtonType.Check;
		}
	}

	private void OnTypeDropDown(object sender, EventArgs e)
	{
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonButton, null, _ribbonButton.ButtonType, GroupButtonType.DropDown);
			_ribbonButton.ButtonType = GroupButtonType.DropDown;
		}
	}

	private void OnTypeSplit(object sender, EventArgs e)
	{
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonButton, null, _ribbonButton.ButtonType, GroupButtonType.Split);
			_ribbonButton.ButtonType = GroupButtonType.Split;
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonButton != null && _ribbonButton.Ribbon != null)
		{
			if (_cms == null)
			{
				_cms = new ContextMenuStrip();
				_toggleHelpersMenu = new ToolStripMenuItem("Design Helpers", null, OnToggleHelpers);
				_visibleMenu = new ToolStripMenuItem("Visible", null, OnVisible);
				_enabledMenu = new ToolStripMenuItem("Enabled", null, OnEnabled);
				_checkedMenu = new ToolStripMenuItem("Checked", null, OnChecked);
				_typePushMenu = new ToolStripMenuItem("Push", null, OnTypePush);
				_typeCheckMenu = new ToolStripMenuItem("Check", null, OnTypeCheck);
				_typeDropDownMenu = new ToolStripMenuItem("DropDown", null, OnTypeDropDown);
				_typeSplitMenu = new ToolStripMenuItem("Split", null, OnTypeSplit);
				_typeMenu = new ToolStripMenuItem("Type");
				_typeMenu.DropDownItems.AddRange(new ToolStripItem[4] { _typePushMenu, _typeCheckMenu, _typeDropDownMenu, _typeSplitMenu });
				_moveFirstMenu = new ToolStripMenuItem("Move Button First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move Button Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move Button Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move Button Last", Resources.MoveLast, OnMoveLast);
				_deleteButtonMenu = new ToolStripMenuItem("Delete Button", Resources.delete2, OnDeleteButton);
				_cms.Items.AddRange(new ToolStripItem[13]
				{
					_toggleHelpersMenu,
					new ToolStripSeparator(),
					_visibleMenu,
					_enabledMenu,
					_checkedMenu,
					_typeMenu,
					new ToolStripSeparator(),
					_moveFirstMenu,
					_movePreviousMenu,
					_moveNextMenu,
					_moveLastMenu,
					new ToolStripSeparator(),
					_deleteButtonMenu
				});
			}
			UpdateVerbStatus();
			_toggleHelpersMenu.Checked = _ribbonButton.Ribbon.InDesignHelperMode;
			_visibleMenu.Checked = _ribbonButton.Visible;
			_enabledMenu.Checked = _ribbonButton.Enabled;
			_checkedMenu.Checked = _ribbonButton.Checked;
			_typePushMenu.Checked = _ribbonButton.ButtonType == GroupButtonType.Push;
			_typeCheckMenu.Checked = _ribbonButton.ButtonType == GroupButtonType.Check;
			_typeDropDownMenu.Checked = _ribbonButton.ButtonType == GroupButtonType.DropDown;
			_typeSplitMenu.Checked = _ribbonButton.ButtonType == GroupButtonType.Split;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonButton.Ribbon.ViewRectangleToPoint(_ribbonButton.ButtonView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}
}
