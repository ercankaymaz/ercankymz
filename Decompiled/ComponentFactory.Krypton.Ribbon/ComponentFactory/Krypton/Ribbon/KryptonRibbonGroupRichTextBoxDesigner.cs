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

internal class KryptonRibbonGroupRichTextBoxDesigner : ComponentDesigner, IKryptonDesignObject
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonGroupRichTextBox _ribbonRichTextBox;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _moveFirstVerb;

	private DesignerVerb _movePrevVerb;

	private DesignerVerb _moveNextVerb;

	private DesignerVerb _moveLastVerb;

	private DesignerVerb _deleteRichTextBoxVerb;

	private ContextMenuStrip _cms;

	private ToolStripMenuItem _toggleHelpersMenu;

	private ToolStripMenuItem _visibleMenu;

	private ToolStripMenuItem _moveFirstMenu;

	private ToolStripMenuItem _movePreviousMenu;

	private ToolStripMenuItem _moveNextMenu;

	private ToolStripMenuItem _moveLastMenu;

	private ToolStripMenuItem _deleteRichTextBoxMenu;

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
			if (_ribbonRichTextBox.RibbonContainer is KryptonRibbonGroupTriple)
			{
				KryptonRibbonGroupTriple kryptonRibbonGroupTriple = (KryptonRibbonGroupTriple)_ribbonRichTextBox.RibbonContainer;
				return kryptonRibbonGroupTriple.Items;
			}
			if (_ribbonRichTextBox.RibbonContainer is KryptonRibbonGroupLines)
			{
				KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_ribbonRichTextBox.RibbonContainer;
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
		_ribbonRichTextBox = (KryptonRibbonGroupRichTextBox)component;
		_ribbonRichTextBox.RichTextBoxDesigner = this;
		Visible = _ribbonRichTextBox.Visible;
		Enabled = _ribbonRichTextBox.Enabled;
		_ribbonRichTextBox.Visible = true;
		_ribbonRichTextBox.Enabled = true;
		_ribbonRichTextBox.RichTextBox.InRibbonDesignMode = true;
		_ribbonRichTextBox.DesignTimeContextMenu += OnContextMenu;
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
				_ribbonRichTextBox.DesignTimeContextMenu -= OnContextMenu;
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
				properties[array[i]] = TypeDescriptor.CreateProperty(typeof(KryptonRibbonGroupRichTextBoxDesigner), propertyDescriptor, attributes);
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
			_moveFirstVerb = new DesignerVerb("Move RichTextBox First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move RichTextBox Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move RichTextBox Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move RichTextBox Last", OnMoveLast);
			_deleteRichTextBoxVerb = new DesignerVerb("Delete RichTextBox", OnDeleteTextBox);
			_verbs.AddRange(new DesignerVerb[6] { _toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _deleteRichTextBoxVerb });
		}
		bool enabled = false;
		bool enabled2 = false;
		bool enabled3 = false;
		bool enabled4 = false;
		if (_ribbonRichTextBox != null && _ribbonRichTextBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			enabled = parentItems.IndexOf(_ribbonRichTextBox) > 0;
			enabled2 = parentItems.IndexOf(_ribbonRichTextBox) > 0;
			enabled3 = parentItems.IndexOf(_ribbonRichTextBox) < parentItems.Count - 1;
			enabled4 = parentItems.IndexOf(_ribbonRichTextBox) < parentItems.Count - 1;
		}
		_moveFirstVerb.Enabled = enabled;
		_movePrevVerb.Enabled = enabled2;
		_moveNextVerb.Enabled = enabled3;
		_moveLastVerb.Enabled = enabled4;
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonRichTextBox != null && _ribbonRichTextBox.Ribbon != null)
		{
			_ribbonRichTextBox.Ribbon.InDesignHelperMode = !_ribbonRichTextBox.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonRichTextBox != null && _ribbonRichTextBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupRichTextBox MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonRichTextBox.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonRichTextBox);
				parentItems.Insert(0, _ribbonRichTextBox);
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
		if (_ribbonRichTextBox != null && _ribbonRichTextBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupRichTextBox MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonRichTextBox.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				int val = parentItems.IndexOf(_ribbonRichTextBox) - 1;
				val = Math.Max(val, 0);
				parentItems.Remove(_ribbonRichTextBox);
				parentItems.Insert(val, _ribbonRichTextBox);
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
		if (_ribbonRichTextBox != null && _ribbonRichTextBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupRichTextBox MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonRichTextBox.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				int val = parentItems.IndexOf(_ribbonRichTextBox) + 1;
				val = Math.Min(val, parentItems.Count - 1);
				parentItems.Remove(_ribbonRichTextBox);
				parentItems.Insert(val, _ribbonRichTextBox);
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
		if (_ribbonRichTextBox != null && _ribbonRichTextBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupRichTextBox MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonRichTextBox.RibbonContainer)["Items"];
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonRichTextBox);
				parentItems.Insert(parentItems.Count, _ribbonRichTextBox);
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
		if (_ribbonRichTextBox != null && _ribbonRichTextBox.Ribbon != null)
		{
			TypedRestrictCollection<KryptonRibbonGroupItem> parentItems = ParentItems;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupRichTextBox DeleteRichTextBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonRichTextBox.RibbonContainer)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				parentItems.Remove(_ribbonRichTextBox);
				_designerHost.DestroyComponent(_ribbonRichTextBox);
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
		if (_ribbonRichTextBox != null && _ribbonRichTextBox.Ribbon != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_ribbonRichTextBox)["Enabled"];
			bool flag = (bool)propertyDescriptor.GetValue(_ribbonRichTextBox);
			bool flag2 = !flag;
			_changeService.OnComponentChanged(_ribbonRichTextBox, null, flag, flag2);
			propertyDescriptor.SetValue(_ribbonRichTextBox, flag2);
		}
	}

	private void OnVisible(object sender, EventArgs e)
	{
		if (_ribbonRichTextBox != null && _ribbonRichTextBox.Ribbon != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_ribbonRichTextBox)["Visible"];
			bool flag = (bool)propertyDescriptor.GetValue(_ribbonRichTextBox);
			bool flag2 = !flag;
			_changeService.OnComponentChanged(_ribbonRichTextBox, null, flag, flag2);
			propertyDescriptor.SetValue(_ribbonRichTextBox, flag2);
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonRichTextBox != null && _ribbonRichTextBox.Ribbon != null)
		{
			if (_cms == null)
			{
				_cms = new ContextMenuStrip();
				_toggleHelpersMenu = new ToolStripMenuItem("Design Helpers", null, OnToggleHelpers);
				_visibleMenu = new ToolStripMenuItem("Visible", null, OnVisible);
				_moveFirstMenu = new ToolStripMenuItem("Move RichTextBox First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move RichTextBox Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move RichTextBox Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move RichTextBox Last", Resources.MoveLast, OnMoveLast);
				_deleteRichTextBoxMenu = new ToolStripMenuItem("Delete RichTextBox", Resources.delete2, OnDeleteTextBox);
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
					_deleteRichTextBoxMenu
				});
			}
			UpdateVerbStatus();
			_toggleHelpersMenu.Checked = _ribbonRichTextBox.Ribbon.InDesignHelperMode;
			_visibleMenu.Checked = Visible;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonRichTextBox.Ribbon.ViewRectangleToPoint(_ribbonRichTextBox.RichTextBoxView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}
}
