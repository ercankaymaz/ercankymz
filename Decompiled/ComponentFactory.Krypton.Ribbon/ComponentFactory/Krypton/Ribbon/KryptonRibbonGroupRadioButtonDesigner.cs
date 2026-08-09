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

internal class KryptonRibbonGroupRadioButtonDesigner : ComponentDesigner
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonGroupRadioButton _ribbonRadioButton;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _moveFirstVerb;

	private DesignerVerb _movePrevVerb;

	private DesignerVerb _moveNextVerb;

	private DesignerVerb _moveLastVerb;

	private DesignerVerb _deleteRadioButtonVerb;

	private ContextMenuStrip _cms;

	private ToolStripMenuItem _toggleHelpersMenu;

	private ToolStripMenuItem _visibleMenu;

	private ToolStripMenuItem _enabledMenu;

	private ToolStripMenuItem _checkedMenu;

	private ToolStripMenuItem _moveFirstMenu;

	private ToolStripMenuItem _movePreviousMenu;

	private ToolStripMenuItem _moveNextMenu;

	private ToolStripMenuItem _moveLastMenu;

	private ToolStripMenuItem _deleteRadioButtonMenu;

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
			if (_ribbonRadioButton.RibbonContainer is KryptonRibbonGroupTriple)
			{
				KryptonRibbonGroupTriple kryptonRibbonGroupTriple = (KryptonRibbonGroupTriple)_ribbonRadioButton.RibbonContainer;
				return kryptonRibbonGroupTriple.Items;
			}
			if (_ribbonRadioButton.RibbonContainer is KryptonRibbonGroupLines)
			{
				KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_ribbonRadioButton.RibbonContainer;
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
		_ribbonRadioButton = (KryptonRibbonGroupRadioButton)component;
		_ribbonRadioButton.DesignTimeContextMenu += OnContextMenu;
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
				_ribbonRadioButton.DesignTimeContextMenu -= OnContextMenu;
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
			_moveFirstVerb = new DesignerVerb("Move RadioButton First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move RadioButton Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move RadioButton Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move RadioButton Last", OnMoveLast);
			_deleteRadioButtonVerb = new DesignerVerb("Delete RadioButton", OnDeleteRadioButton);
			_verbs.AddRange(new DesignerVerb[6] { _toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _deleteRadioButtonVerb });
		}
		bool enabled = false;
		bool enabled2 = false;
		bool enabled3 = false;
		bool enabled4 = false;
		if (_ribbonRadioButton != null && _ribbonRadioButton.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			enabled = parentItems.IndexOf(_ribbonRadioButton) > 0;
			enabled2 = parentItems.IndexOf(_ribbonRadioButton) > 0;
			enabled3 = parentItems.IndexOf(_ribbonRadioButton) < parentItems.Count - 1;
			enabled4 = parentItems.IndexOf(_ribbonRadioButton) < parentItems.Count - 1;
		}
		_moveFirstVerb.Enabled = enabled;
		_movePrevVerb.Enabled = enabled2;
		_moveNextVerb.Enabled = enabled3;
		_moveLastVerb.Enabled = enabled4;
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonRadioButton != null && _ribbonRadioButton.Ribbon != null)
		{
			_ribbonRadioButton.Ribbon.InDesignHelperMode = !_ribbonRadioButton.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonRadioButton != null && _ribbonRadioButton.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupRadioButton MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonRadioButton.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonRadioButton);
				parentItems.Insert(0, _ribbonRadioButton);
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
		if (_ribbonRadioButton != null && _ribbonRadioButton.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupRadioButton MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonRadioButton.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				int val = parentItems.IndexOf(_ribbonRadioButton) - 1;
				val = Math.Max(val, 0);
				parentItems.Remove(_ribbonRadioButton);
				parentItems.Insert(val, _ribbonRadioButton);
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
		if (_ribbonRadioButton != null && _ribbonRadioButton.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupRadioButton MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonRadioButton.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				int val = parentItems.IndexOf(_ribbonRadioButton) + 1;
				val = Math.Min(val, parentItems.Count - 1);
				parentItems.Remove(_ribbonRadioButton);
				parentItems.Insert(val, _ribbonRadioButton);
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
		if (_ribbonRadioButton != null && _ribbonRadioButton.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupRadioButton MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonRadioButton.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonRadioButton);
				parentItems.Insert(parentItems.Count, _ribbonRadioButton);
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnDeleteRadioButton(object sender, EventArgs e)
	{
		if (_ribbonRadioButton != null && _ribbonRadioButton.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupRadioButton DeleteRadioButton");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonRadioButton.RibbonContainer)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonRadioButton);
				_designerHost.DestroyComponent(_ribbonRadioButton);
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
		if (_ribbonRadioButton != null && _ribbonRadioButton.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonRadioButton, null, _ribbonRadioButton.Visible, !_ribbonRadioButton.Visible);
			_ribbonRadioButton.Visible = !_ribbonRadioButton.Visible;
		}
	}

	private void OnEnabled(object sender, EventArgs e)
	{
		if (_ribbonRadioButton != null && _ribbonRadioButton.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonRadioButton, null, _ribbonRadioButton.Enabled, !_ribbonRadioButton.Enabled);
			_ribbonRadioButton.Enabled = !_ribbonRadioButton.Enabled;
		}
	}

	private void OnChecked(object sender, EventArgs e)
	{
		if (_ribbonRadioButton != null && _ribbonRadioButton.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonRadioButton, null, _ribbonRadioButton.Checked, !_ribbonRadioButton.Checked);
			_ribbonRadioButton.Checked = !_ribbonRadioButton.Checked;
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonRadioButton != null && _ribbonRadioButton.Ribbon != null)
		{
			if (_cms == null)
			{
				_cms = new ContextMenuStrip();
				_toggleHelpersMenu = new ToolStripMenuItem("Design Helpers", null, OnToggleHelpers);
				_visibleMenu = new ToolStripMenuItem("Visible", null, OnVisible);
				_enabledMenu = new ToolStripMenuItem("Enabled", null, OnEnabled);
				_checkedMenu = new ToolStripMenuItem("Checked", null, OnChecked);
				_moveFirstMenu = new ToolStripMenuItem("Move RadioButton First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move RadioButton Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move RadioButton Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move RadioButton Last", Resources.MoveLast, OnMoveLast);
				_deleteRadioButtonMenu = new ToolStripMenuItem("Delete RadioButton", Resources.delete2, OnDeleteRadioButton);
				_cms.Items.AddRange(new ToolStripItem[12]
				{
					_toggleHelpersMenu,
					new ToolStripSeparator(),
					_visibleMenu,
					_enabledMenu,
					_checkedMenu,
					new ToolStripSeparator(),
					_moveFirstMenu,
					_movePreviousMenu,
					_moveNextMenu,
					_moveLastMenu,
					new ToolStripSeparator(),
					_deleteRadioButtonMenu
				});
			}
			UpdateVerbStatus();
			_toggleHelpersMenu.Checked = _ribbonRadioButton.Ribbon.InDesignHelperMode;
			_visibleMenu.Checked = _ribbonRadioButton.Visible;
			_enabledMenu.Checked = _ribbonRadioButton.Enabled;
			_checkedMenu.Checked = _ribbonRadioButton.Checked;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonRadioButton.Ribbon.ViewRectangleToPoint(_ribbonRadioButton.RadioButtonView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}
}
