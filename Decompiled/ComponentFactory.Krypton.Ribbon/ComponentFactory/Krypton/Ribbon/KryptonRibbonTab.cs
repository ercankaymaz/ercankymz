using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonTab), "ToolboxBitmaps.KryptonRibbonTab.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonTabDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DefaultProperty("Text")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
public class KryptonRibbonTab : Component
{
	private object _tag;

	private string _text;

	private string _keyTip;

	private string _contextName;

	private bool _visible;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupCollection _ribbonGroups;

	private ViewBase _tabView;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonRibbon Ribbon
	{
		get
		{
			return _ribbon;
		}
		internal set
		{
			_ribbon = value;
			foreach (KryptonRibbonGroup ribbonGroup in _ribbonGroups)
			{
				ribbonGroup.Ribbon = value;
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon tab display text.")]
	[DefaultValue("Tab")]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "Tab";
			}
			if (value != _text)
			{
				_text = value;
				OnPropertyChanged("Text");
				if (_ribbon != null && Visible)
				{
					_ribbon.PerformNeedPaint(needLayout: true);
				}
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon tab key tip.")]
	[DefaultValue("T")]
	public string KeyTip
	{
		get
		{
			return _keyTip;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "T";
			}
			_keyTip = value.ToUpper();
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Only display tab when this context is active.")]
	[DefaultValue("")]
	public string ContextName
	{
		get
		{
			return _contextName;
		}
		set
		{
			if (value == null)
			{
				value = string.Empty;
			}
			if (value != _contextName)
			{
				_contextName = value;
				OnPropertyChanged("ContextName");
				if (_ribbon != null && Visible)
				{
					_ribbon.PerformNeedPaint(needLayout: true);
				}
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the ribbon tab is visible or hidden.")]
	[DefaultValue(true)]
	public bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			if (value == _visible)
			{
				return;
			}
			_visible = value;
			OnPropertyChanged("Visible");
			if (_ribbon != null)
			{
				if (_ribbon.SelectedTab == this)
				{
					_ribbon.ResetSelectedTab();
				}
				_ribbon.PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Collection of ribbon tab groups.")]
	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonRibbonGroupCollection Groups => _ribbonGroups;

	[Category("Data")]
	[Description("User-defined data associated with the object.")]
	[TypeConverter(typeof(StringConverter))]
	[Bindable(true)]
	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			if (value != _tag)
			{
				_tag = value;
				OnPropertyChanged("Tag");
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public ViewBase TabView
	{
		get
		{
			return _tabView;
		}
		set
		{
			_tabView = value;
		}
	}

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddGroup;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	public KryptonRibbonTab()
	{
		_text = "Tab";
		_keyTip = "T";
		_contextName = string.Empty;
		_visible = true;
		_ribbonGroups = new KryptonRibbonGroupCollection();
		_ribbonGroups.Clearing += OnRibbonGroupsClearing;
		_ribbonGroups.Cleared += OnRibbonGroupsCleared;
		_ribbonGroups.Inserted += OnRibbonGroupsInserted;
		_ribbonGroups.Removed += OnRibbonGroupsRemoved;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			foreach (KryptonRibbonGroup group in Groups)
			{
				group.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializeContextName()
	{
		return !string.IsNullOrEmpty(_contextName);
	}

	private void ResetContextName()
	{
		ContextName = string.Empty;
	}

	public void Show()
	{
		Visible = true;
	}

	public void Hide()
	{
		Visible = false;
	}

	private bool ShouldSerializeTag()
	{
		return Tag != null;
	}

	private void ResetTag()
	{
		Tag = null;
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	internal void OnDesignTimeContextMenu(MouseEventArgs e)
	{
		if (this.DesignTimeContextMenu != null)
		{
			this.DesignTimeContextMenu(this, e);
		}
	}

	internal void OnDesignTimeAddGroup()
	{
		if (this.DesignTimeAddGroup != null)
		{
			this.DesignTimeAddGroup(this, EventArgs.Empty);
		}
	}

	internal bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		foreach (KryptonRibbonGroup group in Groups)
		{
			if (group.Visible && group.ProcessCmdKey(ref msg, keyData))
			{
				return true;
			}
		}
		return false;
	}

	private void OnRibbonGroupsClearing(object sender, EventArgs e)
	{
		foreach (KryptonRibbonGroup ribbonGroup in _ribbonGroups)
		{
			ribbonGroup.Ribbon = null;
			ribbonGroup.RibbonTab = null;
		}
	}

	private void OnRibbonGroupsCleared(object sender, EventArgs e)
	{
		if (_ribbon != null && _ribbon.SelectedTab == this)
		{
			_ribbon.PerformNeedPaint(needLayout: true);
		}
	}

	private void OnRibbonGroupsInserted(object sender, TypedCollectionEventArgs<KryptonRibbonGroup> e)
	{
		e.Item.Ribbon = _ribbon;
		e.Item.RibbonTab = this;
		if (_ribbon != null && _ribbon.SelectedTab == this && Visible)
		{
			_ribbon.PerformNeedPaint(needLayout: true);
		}
	}

	private void OnRibbonGroupsRemoved(object sender, TypedCollectionEventArgs<KryptonRibbonGroup> e)
	{
		e.Item.Ribbon = null;
		e.Item.RibbonTab = null;
		if (_ribbon != null && _ribbon.SelectedTab == this && Visible)
		{
			_ribbon.PerformNeedPaint(needLayout: true);
		}
	}
}
