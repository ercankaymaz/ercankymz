using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonContextMenuItem), "ToolboxBitmaps.KryptonContextMenuItem.bmp")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("Text")]
[DefaultEvent("Click")]
public class KryptonContextMenuItem : KryptonContextMenuItemBase
{
	private bool _enabled;

	private bool _splitSubMenu;

	private bool _checkOnClick;

	private bool _showShortcutKeys;

	private bool _autoClose;

	private bool _largeKryptonCommandImage;

	private string _text;

	private string _extraText;

	private string _shortcutKeyDisplayString;

	private Image _image;

	private Color _imageTransparentColor;

	private CheckState _checkState;

	private Keys _shortcutKeys;

	private KryptonContextMenuCollection _items;

	private PaletteContextMenuItemStateRedirect _stateRedirect;

	private PaletteContextMenuItemState _stateNormal;

	private PaletteContextMenuItemState _stateDisabled;

	private PaletteContextMenuItemStateHighlight _stateHighlight;

	private PaletteContextMenuItemStateChecked _stateChecked;

	private KryptonCommand _command;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int ItemChildCount => 0;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override KryptonContextMenuItemBase this[int index] => null;

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Standard menu item text.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("MenuItem")]
	[Localizable(true)]
	[Bindable(true)]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			if (_text != value)
			{
				_text = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Text"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Standard menu item extra text.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	[Localizable(true)]
	[Bindable(true)]
	public string ExtraText
	{
		get
		{
			return _extraText;
		}
		set
		{
			if (_extraText != value)
			{
				_extraText = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ExtraText"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Standard menu item image.")]
	[DefaultValue(null)]
	[Localizable(true)]
	[Bindable(true)]
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
				OnPropertyChanged(new PropertyChangedEventArgs("Image"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Heading image color to make transparent.")]
	[Localizable(true)]
	[Bindable(true)]
	public Color ImageTransparentColor
	{
		get
		{
			return _imageTransparentColor;
		}
		set
		{
			if (_imageTransparentColor != value)
			{
				_imageTransparentColor = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ImageTransparentColor"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("The shortcut key combination associated with the menu item.")]
	[DefaultValue(typeof(Keys), "None")]
	[Localizable(true)]
	public Keys ShortcutKeys
	{
		get
		{
			return _shortcutKeys;
		}
		set
		{
			if (_shortcutKeys != value)
			{
				_shortcutKeys = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ShortcutKeys"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates if clicking the menu item automatically closes the context menu.")]
	[DefaultValue(true)]
	public bool AutoClose
	{
		get
		{
			return _autoClose;
		}
		set
		{
			if (_autoClose != value)
			{
				_autoClose = value;
				OnPropertyChanged(new PropertyChangedEventArgs("AutoClose"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates whether the menu item toggles checked state when clicked.")]
	[DefaultValue(false)]
	public bool SplitSubMenu
	{
		get
		{
			return _splitSubMenu;
		}
		set
		{
			if (_splitSubMenu != value)
			{
				_splitSubMenu = value;
				OnPropertyChanged(new PropertyChangedEventArgs("SplitSubMenu"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Determines if the shortcut display text is shown.")]
	[DefaultValue(false)]
	public bool CheckOnClick
	{
		get
		{
			return _checkOnClick;
		}
		set
		{
			if (_checkOnClick != value)
			{
				_checkOnClick = value;
				OnPropertyChanged(new PropertyChangedEventArgs("CheckOnClick"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Determines if the shortcut display text is shown.")]
	[DefaultValue(true)]
	[Localizable(true)]
	public bool ShowShortcutKeys
	{
		get
		{
			return _showShortcutKeys;
		}
		set
		{
			if (_showShortcutKeys != value)
			{
				_showShortcutKeys = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ShowShortcutKeys"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Determines if the large image is used from the attached KryptonCommand.")]
	[DefaultValue(false)]
	public bool LargeKryptonCommandImage
	{
		get
		{
			return _largeKryptonCommandImage;
		}
		set
		{
			if (_largeKryptonCommandImage != value)
			{
				_largeKryptonCommandImage = value;
				OnPropertyChanged(new PropertyChangedEventArgs("LargeKryptonCommandImage"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Display text to use in preference to the shortcut key setting.")]
	[DefaultValue("")]
	[Localizable(true)]
	public string ShortcutKeyDisplayString
	{
		get
		{
			return _shortcutKeyDisplayString;
		}
		set
		{
			if (_shortcutKeyDisplayString != value)
			{
				_shortcutKeyDisplayString = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ShortcutKeyDisplayString"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Indicates if the menu item is in the checked state.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(false)]
	[Bindable(true)]
	public bool Checked
	{
		get
		{
			return CheckState != CheckState.Unchecked;
		}
		set
		{
			bool flag = CheckState != CheckState.Unchecked;
			if (flag != value)
			{
				CheckState checkState = (value ? CheckState.Checked : CheckState.Unchecked);
				bool flag2 = checkState != _checkState;
				_checkState = checkState;
				OnCheckedChanged(EventArgs.Empty);
				if (flag2)
				{
					OnCheckStateChanged(EventArgs.Empty);
				}
				OnPropertyChanged(new PropertyChangedEventArgs("Checked"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Indicates the checked state of the menu item.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(typeof(CheckState), "Unchecked")]
	[Bindable(true)]
	public CheckState CheckState
	{
		get
		{
			return _checkState;
		}
		set
		{
			if (_checkState != value)
			{
				bool flag = Checked;
				_checkState = value;
				if (Checked != flag)
				{
					OnCheckedChanged(EventArgs.Empty);
				}
				OnCheckStateChanged(EventArgs.Empty);
				OnPropertyChanged(new PropertyChangedEventArgs("CheckState"));
			}
		}
	}

	[Category("Data")]
	[Description("Collection of sub-menu items.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("ComponentFactory.Krypton.Toolkit.KryptonContextMenuCollectionEditor, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
	public KryptonContextMenuCollection Items => _items;

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates whether the menu item is enabled.")]
	[DefaultValue(true)]
	[Bindable(true)]
	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			if (_enabled != value)
			{
				_enabled = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Enabled"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining menu item disabled appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuItemState StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining menu item normal appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuItemState StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining menu item checked appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuItemStateChecked StateChecked => _stateChecked;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining menu item highlight appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuItemStateHighlight StateHighlight => _stateHighlight;

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Command associated with the menu item.")]
	[DefaultValue(null)]
	public virtual KryptonCommand KryptonCommand
	{
		get
		{
			return _command;
		}
		set
		{
			if (_command != value)
			{
				_command = value;
				OnPropertyChanged(new PropertyChangedEventArgs("KryptonCommand"));
			}
		}
	}

	[Category("Action")]
	[Description("Occurs when the menu item is clicked.")]
	public event EventHandler Click;

	[Category("Property Changed")]
	[Description("Occurs when the checked property changes.")]
	public event EventHandler CheckedChanged;

	[Category("Property Changed")]
	[Description("Occurs when the check state property changes.")]
	public event EventHandler CheckStateChanged;

	public KryptonContextMenuItem()
		: this("Menu Item", null, null, Keys.None)
	{
	}

	public KryptonContextMenuItem(string initialText)
		: this(initialText, null, null, Keys.None)
	{
	}

	public KryptonContextMenuItem(string initialText, EventHandler clickHandler)
		: this(initialText, null, clickHandler, Keys.None)
	{
	}

	public KryptonContextMenuItem(string initialText, EventHandler clickHandler, Keys shortcut)
		: this(initialText, null, clickHandler, shortcut)
	{
	}

	public KryptonContextMenuItem(string initialText, Image initialImage, EventHandler clickHandler)
		: this(initialText, initialImage, clickHandler, Keys.None)
	{
	}

	public KryptonContextMenuItem(string initialText, Image initialImage, EventHandler clickHandler, Keys shortcut)
	{
		_text = initialText;
		_image = initialImage;
		if (clickHandler != null)
		{
			Click += clickHandler;
		}
		_enabled = true;
		_autoClose = true;
		_splitSubMenu = false;
		_checkOnClick = false;
		_showShortcutKeys = true;
		_largeKryptonCommandImage = false;
		_extraText = string.Empty;
		_imageTransparentColor = Color.Empty;
		_shortcutKeys = shortcut;
		_shortcutKeyDisplayString = string.Empty;
		_checkState = CheckState.Unchecked;
		_items = new KryptonContextMenuCollection();
		_stateRedirect = new PaletteContextMenuItemStateRedirect();
		_stateNormal = new PaletteContextMenuItemState(_stateRedirect);
		_stateDisabled = new PaletteContextMenuItemState(_stateRedirect);
		_stateHighlight = new PaletteContextMenuItemStateHighlight(_stateRedirect);
		_stateChecked = new PaletteContextMenuItemStateChecked(_stateRedirect);
	}

	public override string ToString()
	{
		return Text;
	}

	public override bool ProcessShortcut(Keys keyData)
	{
		if (_shortcutKeys == keyData)
		{
			PerformClick();
			return true;
		}
		return false;
	}

	public override ViewBase GenerateView(IContextMenuProvider provider, object parent, ViewLayoutStack columns, bool standardStyle, bool imageColumn)
	{
		return new ViewDrawMenuItem(provider, this, columns, standardStyle, imageColumn);
	}

	private bool ShouldSerializeImageTransparentColor()
	{
		_ = _imageTransparentColor;
		return !_imageTransparentColor.Equals(Color.Empty);
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeStateChecked()
	{
		return !_stateChecked.IsDefault;
	}

	private bool ShouldSerializeStateHighlight()
	{
		return !_stateHighlight.IsDefault;
	}

	public void PerformClick()
	{
		if (CheckOnClick)
		{
			CheckState checkState = ((KryptonCommand == null) ? CheckState : KryptonCommand.CheckState);
			switch (checkState)
			{
			case CheckState.Unchecked:
				checkState = CheckState.Checked;
				break;
			case CheckState.Checked:
			case CheckState.Indeterminate:
				checkState = CheckState.Unchecked;
				break;
			}
			if (KryptonCommand != null)
			{
				KryptonCommand.CheckState = checkState;
			}
			else
			{
				CheckState = checkState;
			}
		}
		OnClick(EventArgs.Empty);
		if (KryptonCommand != null)
		{
			KryptonCommand.PerformExecute();
		}
	}

	protected virtual void OnClick(EventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, e);
		}
	}

	protected virtual void OnCheckedChanged(EventArgs e)
	{
		if (this.CheckedChanged != null)
		{
			this.CheckedChanged(this, e);
		}
	}

	protected virtual void OnCheckStateChanged(EventArgs e)
	{
		if (this.CheckStateChanged != null)
		{
			this.CheckStateChanged(this, e);
		}
	}

	internal void SetPaletteRedirect(IContextMenuProvider provider)
	{
		_stateRedirect.SetRedirector(provider);
	}
}
