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

internal class KryptonRibbonGroupNumericUpDownDesigner : ComponentDesigner, IKryptonDesignObject
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonGroupNumericUpDown _ribbonNumericUpDown;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _moveFirstVerb;

	private DesignerVerb _movePrevVerb;

	private DesignerVerb _moveNextVerb;

	private DesignerVerb _moveLastVerb;

	private DesignerVerb _deleteNumericUpDownVerb;

	private ContextMenuStrip _cms;

	private ToolStripMenuItem _toggleHelpersMenu;

	private ToolStripMenuItem _visibleMenu;

	private ToolStripMenuItem _moveFirstMenu;

	private ToolStripMenuItem _movePreviousMenu;

	private ToolStripMenuItem _moveNextMenu;

	private ToolStripMenuItem _moveLastMenu;

	private ToolStripMenuItem _deleteNumericUpDownMenu;

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

	private TypedRestrictCollection<KryptonRibbonGroupItem> ParentItems
	{
		get
		{
			if (_ribbonNumericUpDown.RibbonContainer is KryptonRibbonGroupTriple)
			{
				KryptonRibbonGroupTriple kryptonRibbonGroupTriple = (KryptonRibbonGroupTriple)_ribbonNumericUpDown.RibbonContainer;
				return kryptonRibbonGroupTriple.Items;
			}
			if (_ribbonNumericUpDown.RibbonContainer is KryptonRibbonGroupLines)
			{
				KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_ribbonNumericUpDown.RibbonContainer;
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
		_ribbonNumericUpDown = (KryptonRibbonGroupNumericUpDown)component;
		_ribbonNumericUpDown.NumericUpDownDesigner = this;
		Visible = _ribbonNumericUpDown.Visible;
		Enabled = _ribbonNumericUpDown.Enabled;
		_ribbonNumericUpDown.Visible = true;
		_ribbonNumericUpDown.Enabled = true;
		_ribbonNumericUpDown.NumericUpDown.InRibbonDesignMode = true;
		_ribbonNumericUpDown.DesignTimeContextMenu += OnContextMenu;
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
				_ribbonNumericUpDown.DesignTimeContextMenu -= OnContextMenu;
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
				properties[array[i]] = TypeDescriptor.CreateProperty(typeof(KryptonRibbonGroupNumericUpDownDesigner), propertyDescriptor, attributes);
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
			_moveFirstVerb = new DesignerVerb("Move NumericUpDown First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move NumericUpDown Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move NumericUpDown Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move NumericUpDown Last", OnMoveLast);
			_deleteNumericUpDownVerb = new DesignerVerb("Delete NumericUpDown", OnDeleteNumericUpDown);
			_verbs.AddRange(new DesignerVerb[6] { _toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _deleteNumericUpDownVerb });
		}
		bool enabled = false;
		bool enabled2 = false;
		bool enabled3 = false;
		bool enabled4 = false;
		if (_ribbonNumericUpDown != null && _ribbonNumericUpDown.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			enabled = parentItems.IndexOf(_ribbonNumericUpDown) > 0;
			enabled2 = parentItems.IndexOf(_ribbonNumericUpDown) > 0;
			enabled3 = parentItems.IndexOf(_ribbonNumericUpDown) < parentItems.Count - 1;
			enabled4 = parentItems.IndexOf(_ribbonNumericUpDown) < parentItems.Count - 1;
		}
		_moveFirstVerb.Enabled = enabled;
		_movePrevVerb.Enabled = enabled2;
		_moveNextVerb.Enabled = enabled3;
		_moveLastVerb.Enabled = enabled4;
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonNumericUpDown != null && _ribbonNumericUpDown.Ribbon != null)
		{
			_ribbonNumericUpDown.Ribbon.InDesignHelperMode = !_ribbonNumericUpDown.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonNumericUpDown != null && _ribbonNumericUpDown.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupNumericUpDown MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonNumericUpDown.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonNumericUpDown);
				parentItems.Insert(0, _ribbonNumericUpDown);
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
		if (_ribbonNumericUpDown != null && _ribbonNumericUpDown.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupNumericUpDown MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonNumericUpDown.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				int val = parentItems.IndexOf(_ribbonNumericUpDown) - 1;
				val = Math.Max(val, 0);
				parentItems.Remove(_ribbonNumericUpDown);
				parentItems.Insert(val, _ribbonNumericUpDown);
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
		if (_ribbonNumericUpDown != null && _ribbonNumericUpDown.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupNumericUpDown MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonNumericUpDown.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				int val = parentItems.IndexOf(_ribbonNumericUpDown) + 1;
				val = Math.Min(val, parentItems.Count - 1);
				parentItems.Remove(_ribbonNumericUpDown);
				parentItems.Insert(val, _ribbonNumericUpDown);
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
		if (_ribbonNumericUpDown != null && _ribbonNumericUpDown.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupNumericUpDown MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonNumericUpDown.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonNumericUpDown);
				parentItems.Insert(parentItems.Count, _ribbonNumericUpDown);
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnDeleteNumericUpDown(object sender, EventArgs e)
	{
		if (_ribbonNumericUpDown != null && _ribbonNumericUpDown.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupNumericUpDown DeleteNumericUpDown");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonNumericUpDown.RibbonContainer)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonNumericUpDown);
				_designerHost.DestroyComponent(_ribbonNumericUpDown);
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
		if (_ribbonNumericUpDown != null && _ribbonNumericUpDown.Ribbon != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_ribbonNumericUpDown)["Enabled"];
			bool flag = (bool)propertyDescriptor.GetValue(_ribbonNumericUpDown);
			bool flag2 = !flag;
			_changeService.OnComponentChanged(_ribbonNumericUpDown, null, flag, flag2);
			propertyDescriptor.SetValue(_ribbonNumericUpDown, flag2);
		}
	}

	private void OnVisible(object sender, EventArgs e)
	{
		if (_ribbonNumericUpDown != null && _ribbonNumericUpDown.Ribbon != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_ribbonNumericUpDown)["Visible"];
			bool flag = (bool)propertyDescriptor.GetValue(_ribbonNumericUpDown);
			bool flag2 = !flag;
			_changeService.OnComponentChanged(_ribbonNumericUpDown, null, flag, flag2);
			propertyDescriptor.SetValue(_ribbonNumericUpDown, flag2);
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonNumericUpDown != null && _ribbonNumericUpDown.Ribbon != null)
		{
			if (_cms == null)
			{
				_cms = new ContextMenuStrip();
				_toggleHelpersMenu = new ToolStripMenuItem("Design Helpers", null, OnToggleHelpers);
				_visibleMenu = new ToolStripMenuItem("Visible", null, OnVisible);
				_moveFirstMenu = new ToolStripMenuItem("Move NumericUpDown First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move NumericUpDown Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move NumericUpDown Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move NumericUpDown Last", Resources.MoveLast, OnMoveLast);
				_deleteNumericUpDownMenu = new ToolStripMenuItem("Delete NumericUpDown", Resources.delete2, OnDeleteNumericUpDown);
				_cms.Items.AddRange(new ToolStripItem[10]
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
					_deleteNumericUpDownMenu
				});
			}
			UpdateVerbStatus();
			_toggleHelpersMenu.Checked = _ribbonNumericUpDown.Ribbon.InDesignHelperMode;
			_visibleMenu.Checked = Visible;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonNumericUpDown.Ribbon.ViewRectangleToPoint(_ribbonNumericUpDown.NumericUpDownView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}
}
