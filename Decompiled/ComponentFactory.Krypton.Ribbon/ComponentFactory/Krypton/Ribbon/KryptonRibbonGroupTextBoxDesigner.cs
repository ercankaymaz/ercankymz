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

internal class KryptonRibbonGroupTextBoxDesigner : ComponentDesigner, IKryptonDesignObject
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonGroupTextBox _ribbonTextBox;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _moveFirstVerb;

	private DesignerVerb _movePrevVerb;

	private DesignerVerb _moveNextVerb;

	private DesignerVerb _moveLastVerb;

	private DesignerVerb _deleteTextBoxVerb;

	private ContextMenuStrip _cms;

	private ToolStripMenuItem _toggleHelpersMenu;

	private ToolStripMenuItem _visibleMenu;

	private ToolStripMenuItem _moveFirstMenu;

	private ToolStripMenuItem _movePreviousMenu;

	private ToolStripMenuItem _moveNextMenu;

	private ToolStripMenuItem _moveLastMenu;

	private ToolStripMenuItem _deleteTextBoxMenu;

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
			if (_ribbonTextBox.RibbonContainer is KryptonRibbonGroupTriple)
			{
				KryptonRibbonGroupTriple kryptonRibbonGroupTriple = (KryptonRibbonGroupTriple)_ribbonTextBox.RibbonContainer;
				return kryptonRibbonGroupTriple.Items;
			}
			if (_ribbonTextBox.RibbonContainer is KryptonRibbonGroupLines)
			{
				KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_ribbonTextBox.RibbonContainer;
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
		_ribbonTextBox = (KryptonRibbonGroupTextBox)component;
		_ribbonTextBox.TextBoxDesigner = this;
		Visible = _ribbonTextBox.Visible;
		Enabled = _ribbonTextBox.Enabled;
		_ribbonTextBox.Visible = true;
		_ribbonTextBox.Enabled = true;
		_ribbonTextBox.TextBox.InRibbonDesignMode = true;
		_ribbonTextBox.DesignTimeContextMenu += OnContextMenu;
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
				_ribbonTextBox.DesignTimeContextMenu -= OnContextMenu;
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
				properties[array[i]] = TypeDescriptor.CreateProperty(typeof(KryptonRibbonGroupTextBoxDesigner), propertyDescriptor, attributes);
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
			_moveFirstVerb = new DesignerVerb("Move TextBox First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move TextBox Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move TextBox Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move TextBox Last", OnMoveLast);
			_deleteTextBoxVerb = new DesignerVerb("Delete TextBox", OnDeleteTextBox);
			_verbs.AddRange(new DesignerVerb[6] { _toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _deleteTextBoxVerb });
		}
		bool enabled = false;
		bool enabled2 = false;
		bool enabled3 = false;
		bool enabled4 = false;
		if (_ribbonTextBox != null && _ribbonTextBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			enabled = parentItems.IndexOf(_ribbonTextBox) > 0;
			enabled2 = parentItems.IndexOf(_ribbonTextBox) > 0;
			enabled3 = parentItems.IndexOf(_ribbonTextBox) < parentItems.Count - 1;
			enabled4 = parentItems.IndexOf(_ribbonTextBox) < parentItems.Count - 1;
		}
		_moveFirstVerb.Enabled = enabled;
		_movePrevVerb.Enabled = enabled2;
		_moveNextVerb.Enabled = enabled3;
		_moveLastVerb.Enabled = enabled4;
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonTextBox != null && _ribbonTextBox.Ribbon != null)
		{
			_ribbonTextBox.Ribbon.InDesignHelperMode = !_ribbonTextBox.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonTextBox != null && _ribbonTextBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTextBox MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTextBox.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonTextBox);
				parentItems.Insert(0, _ribbonTextBox);
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
		if (_ribbonTextBox != null && _ribbonTextBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTextBox MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTextBox.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				int val = parentItems.IndexOf(_ribbonTextBox) - 1;
				val = Math.Max(val, 0);
				parentItems.Remove(_ribbonTextBox);
				parentItems.Insert(val, _ribbonTextBox);
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
		if (_ribbonTextBox != null && _ribbonTextBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTextBox MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTextBox.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				int val = parentItems.IndexOf(_ribbonTextBox) + 1;
				val = Math.Min(val, parentItems.Count - 1);
				parentItems.Remove(_ribbonTextBox);
				parentItems.Insert(val, _ribbonTextBox);
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
		if (_ribbonTextBox != null && _ribbonTextBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTextBox MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTextBox.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonTextBox);
				parentItems.Insert(parentItems.Count, _ribbonTextBox);
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnDeleteTextBox(object sender, EventArgs e)
	{
		if (_ribbonTextBox != null && _ribbonTextBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTextBox DeleteTextBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTextBox.RibbonContainer)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonTextBox);
				_designerHost.DestroyComponent(_ribbonTextBox);
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
		if (_ribbonTextBox != null && _ribbonTextBox.Ribbon != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_ribbonTextBox)["Enabled"];
			bool flag = (bool)propertyDescriptor.GetValue(_ribbonTextBox);
			bool flag2 = !flag;
			_changeService.OnComponentChanged(_ribbonTextBox, null, flag, flag2);
			propertyDescriptor.SetValue(_ribbonTextBox, flag2);
		}
	}

	private void OnVisible(object sender, EventArgs e)
	{
		if (_ribbonTextBox != null && _ribbonTextBox.Ribbon != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_ribbonTextBox)["Visible"];
			bool flag = (bool)propertyDescriptor.GetValue(_ribbonTextBox);
			bool flag2 = !flag;
			_changeService.OnComponentChanged(_ribbonTextBox, null, flag, flag2);
			propertyDescriptor.SetValue(_ribbonTextBox, flag2);
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonTextBox != null && _ribbonTextBox.Ribbon != null)
		{
			if (_cms == null)
			{
				_cms = new ContextMenuStrip();
				_toggleHelpersMenu = new ToolStripMenuItem("Design Helpers", null, OnToggleHelpers);
				_visibleMenu = new ToolStripMenuItem("Visible", null, OnVisible);
				_moveFirstMenu = new ToolStripMenuItem("Move TextBox First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move TextBox Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move TextBox Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move TextBox Last", Resources.MoveLast, OnMoveLast);
				_deleteTextBoxMenu = new ToolStripMenuItem("Delete TextBox", Resources.delete2, OnDeleteTextBox);
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
					_deleteTextBoxMenu
				});
			}
			UpdateVerbStatus();
			_toggleHelpersMenu.Checked = _ribbonTextBox.Ribbon.InDesignHelperMode;
			_visibleMenu.Checked = Visible;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonTextBox.Ribbon.ViewRectangleToPoint(_ribbonTextBox.TextBoxView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}
}
