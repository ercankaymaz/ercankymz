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

internal class KryptonRibbonGroupCheckBoxDesigner : ComponentDesigner
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonGroupCheckBox _ribbonCheckBox;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _moveFirstVerb;

	private DesignerVerb _movePrevVerb;

	private DesignerVerb _moveNextVerb;

	private DesignerVerb _moveLastVerb;

	private DesignerVerb _deleteCheckBoxVerb;

	private ContextMenuStrip _cms;

	private ToolStripMenuItem _toggleHelpersMenu;

	private ToolStripMenuItem _visibleMenu;

	private ToolStripMenuItem _enabledMenu;

	private ToolStripMenuItem _autoCheckMenu;

	private ToolStripMenuItem _checkedMenu;

	private ToolStripMenuItem _threeStateMenu;

	private ToolStripMenuItem _moveFirstMenu;

	private ToolStripMenuItem _movePreviousMenu;

	private ToolStripMenuItem _moveNextMenu;

	private ToolStripMenuItem _moveLastMenu;

	private ToolStripMenuItem _deleteCheckBoxMenu;

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
			if (_ribbonCheckBox.RibbonContainer is KryptonRibbonGroupTriple)
			{
				KryptonRibbonGroupTriple kryptonRibbonGroupTriple = (KryptonRibbonGroupTriple)_ribbonCheckBox.RibbonContainer;
				return kryptonRibbonGroupTriple.Items;
			}
			if (_ribbonCheckBox.RibbonContainer is KryptonRibbonGroupLines)
			{
				KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_ribbonCheckBox.RibbonContainer;
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
		_ribbonCheckBox = (KryptonRibbonGroupCheckBox)component;
		_ribbonCheckBox.DesignTimeContextMenu += OnContextMenu;
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
				_ribbonCheckBox.DesignTimeContextMenu -= OnContextMenu;
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
			_moveFirstVerb = new DesignerVerb("Move CheckBox First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move CheckBox Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move CheckBox Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move CheckBox Last", OnMoveLast);
			_deleteCheckBoxVerb = new DesignerVerb("Delete CheckBox", OnDeleteCheckBox);
			_verbs.AddRange(new DesignerVerb[6] { _toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _deleteCheckBoxVerb });
		}
		bool enabled = false;
		bool enabled2 = false;
		bool enabled3 = false;
		bool enabled4 = false;
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			enabled = parentItems.IndexOf(_ribbonCheckBox) > 0;
			enabled2 = parentItems.IndexOf(_ribbonCheckBox) > 0;
			enabled3 = parentItems.IndexOf(_ribbonCheckBox) < parentItems.Count - 1;
			enabled4 = parentItems.IndexOf(_ribbonCheckBox) < parentItems.Count - 1;
		}
		_moveFirstVerb.Enabled = enabled;
		_movePrevVerb.Enabled = enabled2;
		_moveNextVerb.Enabled = enabled3;
		_moveLastVerb.Enabled = enabled4;
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			_ribbonCheckBox.Ribbon.InDesignHelperMode = !_ribbonCheckBox.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupCheckBox MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonCheckBox.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonCheckBox);
				parentItems.Insert(0, _ribbonCheckBox);
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
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupCheckBox MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonCheckBox.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				int val = parentItems.IndexOf(_ribbonCheckBox) - 1;
				val = Math.Max(val, 0);
				parentItems.Remove(_ribbonCheckBox);
				parentItems.Insert(val, _ribbonCheckBox);
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
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupCheckBox MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonCheckBox.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				int val = parentItems.IndexOf(_ribbonCheckBox) + 1;
				val = Math.Min(val, parentItems.Count - 1);
				parentItems.Remove(_ribbonCheckBox);
				parentItems.Insert(val, _ribbonCheckBox);
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
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupCheckBox MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonCheckBox.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonCheckBox);
				parentItems.Insert(parentItems.Count, _ribbonCheckBox);
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnDeleteCheckBox(object sender, EventArgs e)
	{
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupCheckBox DeleteCheckBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonCheckBox.RibbonContainer)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonCheckBox);
				_designerHost.DestroyComponent(_ribbonCheckBox);
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
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonCheckBox, null, _ribbonCheckBox.Visible, !_ribbonCheckBox.Visible);
			_ribbonCheckBox.Visible = !_ribbonCheckBox.Visible;
		}
	}

	private void OnEnabled(object sender, EventArgs e)
	{
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonCheckBox, null, _ribbonCheckBox.Enabled, !_ribbonCheckBox.Enabled);
			_ribbonCheckBox.Enabled = !_ribbonCheckBox.Enabled;
		}
	}

	private void OnAutoCheck(object sender, EventArgs e)
	{
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonCheckBox, null, _ribbonCheckBox.AutoCheck, !_ribbonCheckBox.AutoCheck);
			_ribbonCheckBox.AutoCheck = !_ribbonCheckBox.AutoCheck;
		}
	}

	private void OnThreeState(object sender, EventArgs e)
	{
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonCheckBox, null, _ribbonCheckBox.ThreeState, !_ribbonCheckBox.ThreeState);
			_ribbonCheckBox.ThreeState = !_ribbonCheckBox.ThreeState;
		}
	}

	private void OnChecked(object sender, EventArgs e)
	{
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonCheckBox, null, _ribbonCheckBox.Checked, !_ribbonCheckBox.Checked);
			_ribbonCheckBox.Checked = !_ribbonCheckBox.Checked;
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonCheckBox != null && _ribbonCheckBox.Ribbon != null)
		{
			if (_cms == null)
			{
				_cms = new ContextMenuStrip();
				_toggleHelpersMenu = new ToolStripMenuItem("Design Helpers", null, OnToggleHelpers);
				_visibleMenu = new ToolStripMenuItem("Visible", null, OnVisible);
				_enabledMenu = new ToolStripMenuItem("Enabled", null, OnEnabled);
				_autoCheckMenu = new ToolStripMenuItem("AutoCheck", null, OnAutoCheck);
				_checkedMenu = new ToolStripMenuItem("Checked", null, OnChecked);
				_threeStateMenu = new ToolStripMenuItem("ThreeState", null, OnThreeState);
				_moveFirstMenu = new ToolStripMenuItem("Move CheckBox First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move CheckBox Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move CheckBox Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move CheckBox Last", Resources.MoveLast, OnMoveLast);
				_deleteCheckBoxMenu = new ToolStripMenuItem("Delete CheckBox", Resources.delete2, OnDeleteCheckBox);
				_cms.Items.AddRange(new ToolStripItem[14]
				{
					_toggleHelpersMenu,
					new ToolStripSeparator(),
					_visibleMenu,
					_enabledMenu,
					_autoCheckMenu,
					_checkedMenu,
					_threeStateMenu,
					new ToolStripSeparator(),
					_moveFirstMenu,
					_movePreviousMenu,
					_moveNextMenu,
					_moveLastMenu,
					new ToolStripSeparator(),
					_deleteCheckBoxMenu
				});
			}
			UpdateVerbStatus();
			_toggleHelpersMenu.Checked = _ribbonCheckBox.Ribbon.InDesignHelperMode;
			_visibleMenu.Checked = _ribbonCheckBox.Visible;
			_enabledMenu.Checked = _ribbonCheckBox.Enabled;
			_autoCheckMenu.Checked = _ribbonCheckBox.AutoCheck;
			_checkedMenu.Checked = _ribbonCheckBox.Checked;
			_threeStateMenu.Checked = _ribbonCheckBox.ThreeState;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonCheckBox.Ribbon.ViewRectangleToPoint(_ribbonCheckBox.CheckBoxView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}
}
