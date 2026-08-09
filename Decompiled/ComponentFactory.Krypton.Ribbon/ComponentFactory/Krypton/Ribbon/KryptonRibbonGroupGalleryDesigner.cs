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

internal class KryptonRibbonGroupGalleryDesigner : ComponentDesigner, IKryptonDesignObject
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonGroupGallery _ribbonGallery;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _moveFirstVerb;

	private DesignerVerb _movePrevVerb;

	private DesignerVerb _moveNextVerb;

	private DesignerVerb _moveLastVerb;

	private DesignerVerb _deleteGalleryVerb;

	private ContextMenuStrip _cms;

	private ToolStripMenuItem _toggleHelpersMenu;

	private ToolStripMenuItem _visibleMenu;

	private ToolStripMenuItem _enabledMenu;

	private ToolStripMenuItem _maximumSizeMenu;

	private ToolStripMenuItem _maximumLMenu;

	private ToolStripMenuItem _maximumMMenu;

	private ToolStripMenuItem _maximumSMenu;

	private ToolStripMenuItem _minimumSizeMenu;

	private ToolStripMenuItem _minimumLMenu;

	private ToolStripMenuItem _minimumMMenu;

	private ToolStripMenuItem _minimumSMenu;

	private ToolStripMenuItem _moveFirstMenu;

	private ToolStripMenuItem _movePreviousMenu;

	private ToolStripMenuItem _moveNextMenu;

	private ToolStripMenuItem _moveLastMenu;

	private ToolStripMenuItem _deleteGalleryMenu;

	private bool _visible;

	private bool _enabled;

	public override DesignerVerbCollection Verbs
	{
		get
		{
			UpdateVerbStatus();
			return _verbs;
		}
	}

	public bool DesignEnabled
	{
		get
		{
			return Enabled;
		}
		set
		{
			Enabled = value;
		}
	}

	public bool DesignVisible
	{
		get
		{
			return Visible;
		}
		set
		{
			Visible = value;
		}
	}

	internal bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			_visible = value;
		}
	}

	internal bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			_enabled = value;
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
		_ribbonGallery = (KryptonRibbonGroupGallery)component;
		_ribbonGallery.GalleryDesigner = this;
		Visible = _ribbonGallery.Visible;
		Enabled = _ribbonGallery.Enabled;
		_ribbonGallery.Visible = true;
		_ribbonGallery.Enabled = true;
		_ribbonGallery.Gallery.InRibbonDesignMode = true;
		_ribbonGallery.DesignTimeContextMenu += OnContextMenu;
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
				_ribbonGallery.DesignTimeContextMenu -= OnContextMenu;
				_changeService.ComponentChanged -= OnComponentChanged;
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	protected override void PreFilterProperties(IDictionary properties)
	{
		base.PreFilterProperties(properties);
		Attribute[] attributes = new Attribute[0];
		string[] array = new string[2] { "Visible", "Enabled" };
		for (int i = 0; i < array.Length; i++)
		{
			PropertyDescriptor propertyDescriptor = (PropertyDescriptor)properties[array[i]];
			if (propertyDescriptor != null)
			{
				properties[array[i]] = TypeDescriptor.CreateProperty(typeof(KryptonRibbonGroupGalleryDesigner), propertyDescriptor, attributes);
			}
		}
	}

	private void ResetVisible()
	{
		Visible = true;
	}

	private bool ShouldSerializeVisible()
	{
		return !Visible;
	}

	private void ResetEnabled()
	{
		Enabled = true;
	}

	private bool ShouldSerializeEnabled()
	{
		return !Enabled;
	}

	private void UpdateVerbStatus()
	{
		if (_verbs == null)
		{
			_verbs = new DesignerVerbCollection();
			_toggleHelpersVerb = new DesignerVerb("Toggle Helpers", OnToggleHelpers);
			_moveFirstVerb = new DesignerVerb("Move Gallery First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move Gallery Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move Gallery Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move Gallery Last", OnMoveLast);
			_deleteGalleryVerb = new DesignerVerb("Delete Gallery", OnDeleteGallery);
			_verbs.AddRange(new DesignerVerb[6] { _toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _deleteGalleryVerb });
		}
		bool enabled = false;
		bool enabled2 = false;
		bool enabled3 = false;
		bool enabled4 = false;
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null && _ribbonGallery.RibbonGroup.Items.Contains(_ribbonGallery))
		{
			enabled = _ribbonGallery.RibbonGroup.Items.IndexOf(_ribbonGallery) > 0;
			enabled2 = _ribbonGallery.RibbonGroup.Items.IndexOf(_ribbonGallery) > 0;
			enabled3 = _ribbonGallery.RibbonGroup.Items.IndexOf(_ribbonGallery) < _ribbonGallery.RibbonGroup.Items.Count - 1;
			enabled4 = _ribbonGallery.RibbonGroup.Items.IndexOf(_ribbonGallery) < _ribbonGallery.RibbonGroup.Items.Count - 1;
		}
		_moveFirstVerb.Enabled = enabled;
		_movePrevVerb.Enabled = enabled2;
		_moveNextVerb.Enabled = enabled3;
		_moveLastVerb.Enabled = enabled4;
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null)
		{
			_ribbonGallery.Ribbon.InDesignHelperMode = !_ribbonGallery.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null && _ribbonGallery.RibbonGroup.Items.Contains(_ribbonGallery))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupGallery MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGallery.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonGallery.RibbonGroup;
				ribbonGroup.Items.Remove(_ribbonGallery);
				ribbonGroup.Items.Insert(0, _ribbonGallery);
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
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null && _ribbonGallery.RibbonGroup.Items.Contains(_ribbonGallery))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupGallery MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGallery.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonGallery.RibbonGroup;
				int val = ribbonGroup.Items.IndexOf(_ribbonGallery) - 1;
				val = Math.Max(val, 0);
				ribbonGroup.Items.Remove(_ribbonGallery);
				ribbonGroup.Items.Insert(val, _ribbonGallery);
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
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null && _ribbonGallery.RibbonGroup.Items.Contains(_ribbonGallery))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupGallery MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGallery.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonGallery.RibbonGroup;
				int val = ribbonGroup.Items.IndexOf(_ribbonGallery) + 1;
				val = Math.Min(val, ribbonGroup.Items.Count - 1);
				ribbonGroup.Items.Remove(_ribbonGallery);
				ribbonGroup.Items.Insert(val, _ribbonGallery);
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
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null && _ribbonGallery.RibbonGroup.Items.Contains(_ribbonGallery))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupGallery MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGallery.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonGallery.RibbonGroup;
				ribbonGroup.Items.Remove(_ribbonGallery);
				ribbonGroup.Items.Insert(ribbonGroup.Items.Count, _ribbonGallery);
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnDeleteGallery(object sender, EventArgs e)
	{
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null && _ribbonGallery.RibbonGroup.Items.Contains(_ribbonGallery))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupGallery DeleteGallery");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonGallery.RibbonGroup)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				_ribbonGallery.RibbonGroup.Items.Remove(_ribbonGallery);
				_designerHost.DestroyComponent(_ribbonGallery);
				RaiseComponentChanged(member, null, null);
				RaiseComponentChanged(null, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnEnabled(object sender, EventArgs e)
	{
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_ribbonGallery)["Enabled"];
			bool flag = (bool)propertyDescriptor.GetValue(_ribbonGallery);
			bool flag2 = !flag;
			_changeService.OnComponentChanged(_ribbonGallery, null, flag, flag2);
			propertyDescriptor.SetValue(_ribbonGallery, flag2);
		}
	}

	private void OnVisible(object sender, EventArgs e)
	{
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_ribbonGallery)["Visible"];
			bool flag = (bool)propertyDescriptor.GetValue(_ribbonGallery);
			bool flag2 = !flag;
			_changeService.OnComponentChanged(_ribbonGallery, null, flag, flag2);
			propertyDescriptor.SetValue(_ribbonGallery, flag2);
		}
	}

	private void OnMaxLarge(object sender, EventArgs e)
	{
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonGallery, null, _ribbonGallery.MaximumSize, GroupItemSize.Large);
			_ribbonGallery.MaximumSize = GroupItemSize.Large;
		}
	}

	private void OnMaxMedium(object sender, EventArgs e)
	{
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonGallery, null, _ribbonGallery.MaximumSize, GroupItemSize.Medium);
			_ribbonGallery.MaximumSize = GroupItemSize.Medium;
		}
	}

	private void OnMaxSmall(object sender, EventArgs e)
	{
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonGallery, null, _ribbonGallery.MaximumSize, GroupItemSize.Small);
			_ribbonGallery.MaximumSize = GroupItemSize.Small;
		}
	}

	private void OnMinLarge(object sender, EventArgs e)
	{
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonGallery, null, _ribbonGallery.MinimumSize, GroupItemSize.Large);
			_ribbonGallery.MinimumSize = GroupItemSize.Large;
		}
	}

	private void OnMinMedium(object sender, EventArgs e)
	{
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonGallery, null, _ribbonGallery.MinimumSize, GroupItemSize.Medium);
			_ribbonGallery.MinimumSize = GroupItemSize.Medium;
		}
	}

	private void OnMinSmall(object sender, EventArgs e)
	{
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonGallery, null, _ribbonGallery.MinimumSize, GroupItemSize.Small);
			_ribbonGallery.MinimumSize = GroupItemSize.Small;
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonGallery != null && _ribbonGallery.Ribbon != null)
		{
			if (_cms == null)
			{
				_cms = new ContextMenuStrip();
				_toggleHelpersMenu = new ToolStripMenuItem("Design Helpers", null, OnToggleHelpers);
				_visibleMenu = new ToolStripMenuItem("Visible", null, OnVisible);
				_enabledMenu = new ToolStripMenuItem("Enabled", null, OnEnabled);
				_maximumLMenu = new ToolStripMenuItem("Large", null, OnMaxLarge);
				_maximumMMenu = new ToolStripMenuItem("Medium", null, OnMaxMedium);
				_maximumSMenu = new ToolStripMenuItem("Small", null, OnMaxSmall);
				_maximumSizeMenu = new ToolStripMenuItem("Maximum Size");
				_maximumSizeMenu.DropDownItems.AddRange(new ToolStripItem[3] { _maximumLMenu, _maximumMMenu, _maximumSMenu });
				_minimumLMenu = new ToolStripMenuItem("Large", null, OnMinLarge);
				_minimumMMenu = new ToolStripMenuItem("Medium", null, OnMinMedium);
				_minimumSMenu = new ToolStripMenuItem("Small", null, OnMinSmall);
				_minimumSizeMenu = new ToolStripMenuItem("Minimum Size");
				_minimumSizeMenu.DropDownItems.AddRange(new ToolStripItem[3] { _minimumLMenu, _minimumMMenu, _minimumSMenu });
				_moveFirstMenu = new ToolStripMenuItem("Move Gallery First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move Gallery Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move Gallery Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move Gallery Last", Resources.MoveLast, OnMoveLast);
				_deleteGalleryMenu = new ToolStripMenuItem("Delete Gallery", Resources.delete2, OnDeleteGallery);
				_cms.Items.AddRange(new ToolStripItem[13]
				{
					_toggleHelpersMenu,
					new ToolStripSeparator(),
					_visibleMenu,
					_enabledMenu,
					_maximumSizeMenu,
					_minimumSizeMenu,
					new ToolStripSeparator(),
					_moveFirstMenu,
					_movePreviousMenu,
					_moveNextMenu,
					_moveLastMenu,
					new ToolStripSeparator(),
					_deleteGalleryMenu
				});
			}
			UpdateVerbStatus();
			_toggleHelpersMenu.Checked = _ribbonGallery.Ribbon.InDesignHelperMode;
			_visibleMenu.Checked = Visible;
			_enabledMenu.Checked = Enabled;
			_maximumLMenu.Checked = _ribbonGallery.MaximumSize == GroupItemSize.Large;
			_maximumMMenu.Checked = _ribbonGallery.MaximumSize == GroupItemSize.Medium;
			_maximumSMenu.Checked = _ribbonGallery.MaximumSize == GroupItemSize.Small;
			_minimumLMenu.Checked = _ribbonGallery.MinimumSize == GroupItemSize.Large;
			_minimumMMenu.Checked = _ribbonGallery.MinimumSize == GroupItemSize.Medium;
			_minimumSMenu.Checked = _ribbonGallery.MinimumSize == GroupItemSize.Small;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonGallery.Ribbon.ViewRectangleToPoint(_ribbonGallery.GalleryView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}
}
