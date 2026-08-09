using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroup), "ToolboxBitmaps.KryptonRibbonGroup.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DefaultEvent("DialogBoxLauncherClick")]
[DefaultProperty("TextLine1")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
public class KryptonRibbonGroup : Component
{
	private static readonly Image _defaultGroupImage = Resources.GroupImageDefault;

	private object _tag;

	private bool _visible;

	private bool _allowCollapsed;

	private bool _isCollapsed;

	private Image _image;

	private string _textLine1;

	private string _textLine2;

	private string _keyTipGroup;

	private string _keyTipDialogLauncher;

	private bool _dialogBoxLauncher;

	private bool _showingAsPopup;

	private int _minimumWidth;

	private int _maximumWidth;

	private KryptonRibbon _ribbon;

	private KryptonRibbonTab _ribbonTab;

	private KryptonRibbonGroupContainerCollection _ribbonGroupItems;

	private ViewBase _groupView;

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
			foreach (KryptonRibbonGroupContainer ribbonGroupItem in _ribbonGroupItems)
			{
				ribbonGroupItem.Ribbon = value;
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonRibbonTab RibbonTab
	{
		get
		{
			return _ribbonTab;
		}
		internal set
		{
			_ribbonTab = value;
			foreach (KryptonRibbonGroupContainer ribbonGroupItem in _ribbonGroupItems)
			{
				ribbonGroupItem.RibbonTab = value;
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group display text line 1.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("Group")]
	public string TextLine1
	{
		get
		{
			return _textLine1;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "Group";
			}
			if (value != _textLine1)
			{
				_textLine1 = value;
				OnPropertyChanged("TextLine1");
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group display text line 2.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("")]
	public string TextLine2
	{
		get
		{
			return _textLine2;
		}
		set
		{
			if (value != _textLine2)
			{
				_textLine2 = value;
				OnPropertyChanged("TextLine2");
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group key tip used when collapsed.")]
	[DefaultValue("G")]
	public string KeyTipGroup
	{
		get
		{
			return _keyTipGroup;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "G";
			}
			_keyTipGroup = value.ToUpper();
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group key tip used for dialog box launcher.")]
	[DefaultValue("D")]
	public string KeyTipDialogLauncher
	{
		get
		{
			return _keyTipDialogLauncher;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "D";
			}
			_keyTipDialogLauncher = value.ToUpper();
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Group image when collapsed.")]
	[RefreshProperties(RefreshProperties.All)]
	public Image Image
	{
		get
		{
			return _image;
		}
		set
		{
			if (_image != value)
			{
				_image = value;
				OnPropertyChanged("Image");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the ribbon group is visible or hidden.")]
	[DefaultValue(true)]
	public bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			if (value != _visible)
			{
				_visible = value;
				OnPropertyChanged("Visible");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the ribbon group has a dialog box launcher button.")]
	[DefaultValue(true)]
	public bool DialogBoxLauncher
	{
		get
		{
			return _dialogBoxLauncher;
		}
		set
		{
			if (value != _dialogBoxLauncher)
			{
				_dialogBoxLauncher = value;
				OnPropertyChanged("DialogBoxLauncher");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the ribbon group is allowed to be collapsed.")]
	[DefaultValue(true)]
	public bool AllowCollapsed
	{
		get
		{
			return _allowCollapsed;
		}
		set
		{
			if (value != _allowCollapsed)
			{
				_allowCollapsed = value;
				OnPropertyChanged("AllowCollapsed");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Ribbon group minimum width, with -1 removing this limitation.")]
	[DefaultValue(-1)]
	public int MinimumWidth
	{
		get
		{
			return _minimumWidth;
		}
		set
		{
			if (value != _minimumWidth)
			{
				_minimumWidth = value;
				OnPropertyChanged("MinimumWidth");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Ribbon group maximum width, with -1 removing this limitation.")]
	[DefaultValue(-1)]
	public int MaximumWidth
	{
		get
		{
			return _maximumWidth;
		}
		set
		{
			if (value != _maximumWidth)
			{
				_maximumWidth = value;
				OnPropertyChanged("MaximumWidth");
			}
		}
	}

	[Category("Visuals")]
	[Description("Collection of ribbon group items.")]
	[MergableProperty(false)]
	[Editor("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainerCollectionEditor, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonRibbonGroupContainerCollection Items => _ribbonGroupItems;

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
	public ViewBase GroupView
	{
		get
		{
			return _groupView;
		}
		set
		{
			_groupView = value;
		}
	}

	internal bool IsCollapsed
	{
		get
		{
			return _isCollapsed;
		}
		set
		{
			_isCollapsed = value;
		}
	}

	internal bool ShowingAsPopup
	{
		get
		{
			return _showingAsPopup;
		}
		set
		{
			_showingAsPopup = value;
		}
	}

	[Category("Ribbon")]
	[Description("Occurs when the dialog box launcher button is clicked.")]
	public event EventHandler DialogBoxLauncherClick;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddTriple;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddLines;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddSeparator;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddGallery;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	public KryptonRibbonGroup()
	{
		_image = _defaultGroupImage;
		_textLine1 = "Group";
		_textLine2 = string.Empty;
		_keyTipGroup = "G";
		_keyTipDialogLauncher = "D";
		_visible = true;
		_allowCollapsed = true;
		_dialogBoxLauncher = true;
		_isCollapsed = false;
		_minimumWidth = -1;
		_maximumWidth = -1;
		_ribbonGroupItems = new KryptonRibbonGroupContainerCollection();
		_ribbonGroupItems.Clearing += OnRibbonGroupItemsClearing;
		_ribbonGroupItems.Cleared += OnRibbonGroupItemsCleared;
		_ribbonGroupItems.Inserted += OnRibbonGroupItemsInserted;
		_ribbonGroupItems.Removed += OnRibbonGroupItemsRemoved;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			foreach (KryptonRibbonGroupContainer item in Items)
			{
				item.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializeImage()
	{
		return Image != _defaultGroupImage;
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

	protected internal virtual void OnDialogBoxLauncherClick(EventArgs e)
	{
		if (Ribbon != null)
		{
			Ribbon.ActionOccured();
		}
		if (this.DialogBoxLauncherClick != null)
		{
			this.DialogBoxLauncherClick(this, e);
		}
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	internal void OnDesignTimeAddTriple()
	{
		if (this.DesignTimeAddTriple != null)
		{
			this.DesignTimeAddTriple(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddLines()
	{
		if (this.DesignTimeAddLines != null)
		{
			this.DesignTimeAddLines(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddSeparator()
	{
		if (this.DesignTimeAddSeparator != null)
		{
			this.DesignTimeAddSeparator(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeAddGallery()
	{
		if (this.DesignTimeAddGallery != null)
		{
			this.DesignTimeAddGallery(this, EventArgs.Empty);
		}
	}

	internal void OnDesignTimeContextMenu(MouseEventArgs e)
	{
		if (this.DesignTimeContextMenu != null)
		{
			this.DesignTimeContextMenu(this, e);
		}
	}

	internal bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		foreach (KryptonRibbonGroupContainer item in Items)
		{
			if (item.Visible && item.ProcessCmdKey(ref msg, keyData))
			{
				return true;
			}
		}
		return false;
	}

	private void OnRibbonGroupItemsClearing(object sender, EventArgs e)
	{
		foreach (KryptonRibbonGroupContainer ribbonGroupItem in _ribbonGroupItems)
		{
			ribbonGroupItem.Ribbon = null;
			ribbonGroupItem.RibbonTab = null;
			ribbonGroupItem.RibbonGroup = null;
		}
	}

	private void OnRibbonGroupItemsCleared(object sender, EventArgs e)
	{
		if (_ribbon != null && _ribbonTab != null && _ribbon.SelectedTab == _ribbonTab)
		{
			_ribbon.PerformNeedPaint(needLayout: true);
		}
	}

	private void OnRibbonGroupItemsInserted(object sender, TypedCollectionEventArgs<KryptonRibbonGroupContainer> e)
	{
		e.Item.Ribbon = _ribbon;
		e.Item.RibbonTab = _ribbonTab;
		e.Item.RibbonGroup = this;
		if (_ribbon != null && _ribbonTab != null && _ribbon.SelectedTab == _ribbonTab)
		{
			_ribbon.PerformNeedPaint(needLayout: true);
		}
	}

	private void OnRibbonGroupItemsRemoved(object sender, TypedCollectionEventArgs<KryptonRibbonGroupContainer> e)
	{
		e.Item.Ribbon = null;
		e.Item.RibbonTab = null;
		e.Item.RibbonGroup = null;
		if (_ribbon != null && _ribbonTab != null && _ribbon.SelectedTab == _ribbonTab)
		{
			_ribbon.PerformNeedPaint(needLayout: true);
		}
	}
}
