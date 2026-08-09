using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupCheckBox), "ToolboxBitmaps.KryptonRibbonGroupCheckBox.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupCheckBoxDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("CheckedChanged")]
[DefaultProperty("Checked")]
public class KryptonRibbonGroupCheckBox : KryptonRibbonGroupItem
{
	private bool _enabled;

	private bool _visible;

	private CheckState _checkState;

	private bool _checked;

	private bool _threeState;

	private bool _autoCheck;

	private Image _toolTipImage;

	private Color _toolTipImageTransparentColor;

	private LabelStyle _toolTipStyle;

	private string _textLine1;

	private string _textLine2;

	private string _keyTip;

	private string _toolTipTitle;

	private string _toolTipBody;

	private Keys _shortcutKeys;

	private ViewBase _checkBoxView;

	private GroupItemSize _itemSizeMax;

	private GroupItemSize _itemSizeMin;

	private GroupItemSize _itemSizeCurrent;

	private KryptonCommand _command;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Check box display text line 1.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("CheckBox")]
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
				value = "CheckBox";
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
	[Description("Check box display text line 2.")]
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
	[Description("Ribbon group check box key tip.")]
	[DefaultValue("C")]
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
				value = "C";
			}
			_keyTip = value.ToUpper();
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the check box is visible or hidden.")]
	[DefaultValue(true)]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override bool Visible
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
	[Description("Determines whether the group check box is enabled.")]
	[DefaultValue(true)]
	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			if (value != _enabled)
			{
				_enabled = value;
				OnPropertyChanged("Enabled");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the group check box is checked.")]
	[DefaultValue(typeof(CheckState), "Unchecked")]
	public CheckState CheckState
	{
		get
		{
			return _checkState;
		}
		set
		{
			if (value != _checkState)
			{
				_checkState = value;
				bool flag = _checkState != CheckState.Unchecked;
				bool flag2 = _checked != flag;
				_checked = flag;
				OnPropertyChanged("Checked");
				if (flag2)
				{
					OnCheckedChanged(EventArgs.Empty);
				}
				OnCheckStateChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Behavior")]
	[Description("Indicates if the check box is in the checked state.")]
	[DefaultValue(false)]
	public bool Checked
	{
		get
		{
			return _checked;
		}
		set
		{
			if (_checked != value)
			{
				_checked = value;
				_checkState = (_checked ? CheckState.Checked : CheckState.Unchecked);
				OnPropertyChanged("CheckState");
				OnCheckedChanged(EventArgs.Empty);
				OnCheckStateChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Behavior")]
	[Description("Causes the check box to automatically change state when clicked.")]
	[DefaultValue(true)]
	public bool AutoCheck
	{
		get
		{
			return _autoCheck;
		}
		set
		{
			if (_autoCheck != value)
			{
				_autoCheck = value;
				OnPropertyChanged("AutoCheck");
			}
		}
	}

	[Category("Behavior")]
	[Description("Indicates if the check bix allows three states instead of two.")]
	[DefaultValue(false)]
	public bool ThreeState
	{
		get
		{
			return _threeState;
		}
		set
		{
			if (_threeState != value)
			{
				_threeState = value;
				OnPropertyChanged("ThreeState");
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Shortcut key combination to fire click event of the check box.")]
	public Keys ShortcutKeys
	{
		get
		{
			return _shortcutKeys;
		}
		set
		{
			_shortcutKeys = value;
		}
	}

	[Category("Appearance")]
	[Description("Tooltip style for the group check box.")]
	[DefaultValue(typeof(LabelStyle), "SuperTip")]
	public LabelStyle ToolTipStyle
	{
		get
		{
			return _toolTipStyle;
		}
		set
		{
			_toolTipStyle = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Display image associated ToolTip.")]
	[DefaultValue(null)]
	[Localizable(true)]
	public Image ToolTipImage
	{
		get
		{
			return _toolTipImage;
		}
		set
		{
			_toolTipImage = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Color to draw as transparent in the ToolTipImage.")]
	[KryptonDefaultColor]
	[Localizable(true)]
	public Color ToolTipImageTransparentColor
	{
		get
		{
			return _toolTipImageTransparentColor;
		}
		set
		{
			_toolTipImageTransparentColor = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Title text for use in associated ToolTip.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	[Localizable(true)]
	public string ToolTipTitle
	{
		get
		{
			return _toolTipTitle;
		}
		set
		{
			_toolTipTitle = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Body text for use in associated ToolTip.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	[Localizable(true)]
	public string ToolTipBody
	{
		get
		{
			return _toolTipBody;
		}
		set
		{
			_toolTipBody = value;
		}
	}

	[Category("Behavior")]
	[Description("Command associated with the check box.")]
	[DefaultValue(null)]
	public KryptonCommand KryptonCommand
	{
		get
		{
			return _command;
		}
		set
		{
			if (_command != value)
			{
				if (_command != null)
				{
					_command.PropertyChanged -= OnCommandPropertyChanged;
				}
				_command = value;
				OnPropertyChanged("KryptonCommand");
				if (_command != null)
				{
					_command.PropertyChanged += OnCommandPropertyChanged;
				}
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMaximum
	{
		get
		{
			return _itemSizeMax;
		}
		set
		{
			if (_itemSizeMax != value)
			{
				_itemSizeMax = value;
				OnPropertyChanged("ItemSizeMaximum");
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMinimum
	{
		get
		{
			return _itemSizeMin;
		}
		set
		{
			if (_itemSizeMin != value)
			{
				_itemSizeMin = value;
				OnPropertyChanged("ItemSizeMinimum");
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeCurrent
	{
		get
		{
			return _itemSizeCurrent;
		}
		set
		{
			if (_itemSizeCurrent != value)
			{
				_itemSizeCurrent = value;
				OnPropertyChanged("ItemSizeCurrent");
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public ViewBase CheckBoxView
	{
		get
		{
			return _checkBoxView;
		}
		set
		{
			_checkBoxView = value;
		}
	}

	internal override LabelStyle InternalToolTipStyle => ToolTipStyle;

	internal override Image InternalToolTipImage => ToolTipImage;

	internal override Color InternalToolTipImageTransparentColor => ToolTipImageTransparentColor;

	internal override string InternalToolTipTitle => ToolTipTitle;

	internal override string InternalToolTipBody => ToolTipBody;

	[Category("Ribbon")]
	[Description("Occurs when the check box is clicked.")]
	public event EventHandler Click;

	[Category("Ribbon")]
	[Description("Occurs whenever the Checked property has changed.")]
	public event EventHandler CheckedChanged;

	[Category("Ribbon")]
	[Description("Occurs whenever the CheckState property has changed.")]
	public event EventHandler CheckStateChanged;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	public KryptonRibbonGroupCheckBox()
	{
		_enabled = true;
		_visible = true;
		_checked = false;
		_threeState = false;
		_checkState = CheckState.Unchecked;
		_autoCheck = true;
		_shortcutKeys = Keys.None;
		_textLine1 = "CheckBox";
		_textLine2 = string.Empty;
		_keyTip = "C";
		_itemSizeMax = GroupItemSize.Large;
		_itemSizeMin = GroupItemSize.Small;
		_itemSizeCurrent = GroupItemSize.Large;
		_toolTipImageTransparentColor = Color.Empty;
		_toolTipTitle = string.Empty;
		_toolTipBody = string.Empty;
		_toolTipStyle = LabelStyle.SuperTip;
	}

	public void Show()
	{
		Visible = true;
	}

	public void Hide()
	{
		Visible = false;
	}

	private bool ShouldSerializeShortcutKeys()
	{
		return ShortcutKeys != Keys.None;
	}

	public void ResetShortcutKeys()
	{
		ShortcutKeys = Keys.None;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupCheckBox(ribbon, this, needPaint);
	}

	public void PerformClick()
	{
		PerformClick(null);
	}

	public void PerformClick(EventHandler finishDelegate)
	{
		OnClick(finishDelegate);
	}

	protected virtual void OnCommandPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "TextLine1":
			OnPropertyChanged("TextLine1");
			break;
		case "TextLine2":
			OnPropertyChanged("TextLine2");
			break;
		case "Enabled":
			OnPropertyChanged("Enabled");
			break;
		case "Checked":
		case "CheckState":
			OnPropertyChanged("CheckState");
			break;
		}
	}

	protected virtual void OnClick(EventHandler finishDelegate)
	{
		bool flag = true;
		if (!Ribbon.InDesignMode && Enabled)
		{
			if (AutoCheck)
			{
				CheckState checkState = CheckState.Unchecked;
				checkState = ((KryptonCommand == null) ? CheckState : KryptonCommand.CheckState);
				switch (checkState)
				{
				case CheckState.Unchecked:
					checkState = CheckState.Checked;
					break;
				case CheckState.Checked:
					checkState = (ThreeState ? CheckState.Indeterminate : CheckState.Unchecked);
					break;
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
			if (VisualPopupManager.Singleton.CurrentPopup != null)
			{
				if (flag)
				{
					finishDelegate?.Invoke(this, EventArgs.Empty);
				}
				flag = false;
			}
			if (this.Click != null)
			{
				this.Click(this, EventArgs.Empty);
			}
			if (KryptonCommand != null)
			{
				KryptonCommand.PerformExecute();
			}
		}
		if (flag)
		{
			finishDelegate?.Invoke(this, EventArgs.Empty);
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

	internal override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (Enabled && base.ChainVisible && ShortcutKeys != Keys.None && ShortcutKeys == keyData)
		{
			PerformClick();
			return true;
		}
		return false;
	}
}
