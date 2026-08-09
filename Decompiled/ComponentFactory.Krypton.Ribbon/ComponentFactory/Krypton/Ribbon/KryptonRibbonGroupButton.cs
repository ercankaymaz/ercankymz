#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupButton), "ToolboxBitmaps.KryptonRibbonGroupButton.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButtonDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("Click")]
[DefaultProperty("ButtonType")]
public class KryptonRibbonGroupButton : KryptonRibbonGroupItem
{
	private static readonly Image _defaultButtonImageSmall = Resources.ButtonImageSmall;

	private static readonly Image _defaultButtonImageLarge = Resources.ButtonImageLarge;

	private bool _enabled;

	private bool _visible;

	private bool _checked;

	private Image _imageSmall;

	private Image _imageLarge;

	private Image _toolTipImage;

	private Color _toolTipImageTransparentColor;

	private LabelStyle _toolTipStyle;

	private string _toolTipTitle;

	private string _toolTipBody;

	private string _textLine1;

	private string _textLine2;

	private string _keyTip;

	private Keys _shortcutKeys;

	private GroupButtonType _buttonType;

	private ContextMenuStrip _contextMenuStrip;

	private KryptonContextMenu _kryptonContextMenu;

	private EventHandler _kcmFinishDelegate;

	private ViewBase _buttonView;

	private GroupItemSize _itemSizeMax;

	private GroupItemSize _itemSizeMin;

	private GroupItemSize _itemSizeCurrent;

	private KryptonCommand _command;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Small button image.")]
	[RefreshProperties(RefreshProperties.All)]
	public Image ImageSmall
	{
		get
		{
			return _imageSmall;
		}
		set
		{
			if (_imageSmall != value)
			{
				_imageSmall = value;
				OnPropertyChanged("ImageSmall");
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Large button image.")]
	[RefreshProperties(RefreshProperties.All)]
	public Image ImageLarge
	{
		get
		{
			return _imageLarge;
		}
		set
		{
			if (_imageLarge != value)
			{
				_imageLarge = value;
				OnPropertyChanged("ImageLarge");
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Button display text line 1.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("Button")]
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
				value = "Button";
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
	[Description("Button display text line 2.")]
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
	[Description("Ribbon group button key tip.")]
	[DefaultValue("B")]
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
				value = "B";
			}
			_keyTip = value.ToUpper();
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the button is visible or hidden.")]
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
	[Description("Determines whether the group button is enabled.")]
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
	[Description("Determines whether the group button is checked.")]
	[DefaultValue(false)]
	public bool Checked
	{
		get
		{
			return _checked;
		}
		set
		{
			if (value != _checked)
			{
				_checked = value;
				OnPropertyChanged("Checked");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines how the group button operation.")]
	[DefaultValue(typeof(GroupButtonType), "Push")]
	public GroupButtonType ButtonType
	{
		get
		{
			return _buttonType;
		}
		set
		{
			if (value != _buttonType)
			{
				_buttonType = value;
				OnPropertyChanged("ButtonType");
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Shortcut key combination to fire click event of the button.")]
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
	[Description("Tooltip style for the group button.")]
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
	[Description("Context menu strip to be shown when the button is pressed.")]
	[DefaultValue(null)]
	public ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return _contextMenuStrip;
		}
		set
		{
			if (value != _contextMenuStrip)
			{
				_contextMenuStrip = value;
				OnPropertyChanged("ContextMenuStrip");
			}
		}
	}

	[Category("Behavior")]
	[Description("KryptonContextMenu to be shown when the button is pressed.")]
	[DefaultValue(null)]
	public KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _kryptonContextMenu;
		}
		set
		{
			if (value != _kryptonContextMenu)
			{
				_kryptonContextMenu = value;
				OnPropertyChanged("KryptonContextMenu");
			}
		}
	}

	[Category("Behavior")]
	[Description("Command associated with the group button.")]
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
	public ViewBase ButtonView
	{
		get
		{
			return _buttonView;
		}
		set
		{
			_buttonView = value;
		}
	}

	internal override LabelStyle InternalToolTipStyle => ToolTipStyle;

	internal override Image InternalToolTipImage => ToolTipImage;

	internal override Color InternalToolTipImageTransparentColor => ToolTipImageTransparentColor;

	internal override string InternalToolTipTitle => ToolTipTitle;

	internal override string InternalToolTipBody => ToolTipBody;

	[Category("Ribbon")]
	[Description("Occurs when the button is clicked.")]
	public event EventHandler Click;

	[Category("Ribbon")]
	[Description("Occurs when the drop down button type is pressed.")]
	public event EventHandler<ContextMenuArgs> DropDown;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	public KryptonRibbonGroupButton()
	{
		_enabled = true;
		_visible = true;
		_checked = false;
		_shortcutKeys = Keys.None;
		_imageSmall = _defaultButtonImageSmall;
		_imageLarge = _defaultButtonImageLarge;
		_textLine1 = "Button";
		_textLine2 = string.Empty;
		_keyTip = "B";
		_buttonType = GroupButtonType.Push;
		_contextMenuStrip = null;
		_kryptonContextMenu = null;
		_itemSizeMax = GroupItemSize.Large;
		_itemSizeMin = GroupItemSize.Small;
		_itemSizeCurrent = GroupItemSize.Large;
		_toolTipImageTransparentColor = Color.Empty;
		_toolTipTitle = string.Empty;
		_toolTipBody = string.Empty;
		_toolTipStyle = LabelStyle.SuperTip;
	}

	private bool ShouldSerializeImageSmall()
	{
		return ImageSmall != _defaultButtonImageSmall;
	}

	private bool ShouldSerializeImageLarge()
	{
		return ImageLarge != _defaultButtonImageLarge;
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
		return new ViewDrawRibbonGroupButton(ribbon, this, needPaint);
	}

	public void PerformClick()
	{
		PerformClick(null);
	}

	public void PerformClick(EventHandler finishDelegate)
	{
		OnClick(finishDelegate);
	}

	public void PerformDropDown()
	{
		PerformDropDown(null);
	}

	public void PerformDropDown(EventHandler finishDelegate)
	{
		OnDropDown(finishDelegate);
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
		case "ImageSmall":
			OnPropertyChanged("ImageSmall");
			break;
		case "ImageLarge":
			OnPropertyChanged("ImageLarge");
			break;
		case "Enabled":
			OnPropertyChanged("Enabled");
			break;
		case "Checked":
			OnPropertyChanged("Checked");
			break;
		}
	}

	protected virtual void OnClick(EventHandler finishDelegate)
	{
		bool flag = true;
		if (!Ribbon.InDesignMode && Enabled)
		{
			if (ButtonType == GroupButtonType.Check)
			{
				if (KryptonCommand != null)
				{
					KryptonCommand.Checked = !KryptonCommand.Checked;
				}
				else
				{
					Checked = !Checked;
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

	protected virtual void OnDropDown(EventHandler finishDelegate)
	{
		bool flag = true;
		if (!Ribbon.InDesignMode && Enabled && (ButtonType == GroupButtonType.DropDown || ButtonType == GroupButtonType.Split))
		{
			if (KryptonContextMenu != null)
			{
				ContextMenuArgs contextMenuArgs = new ContextMenuArgs(KryptonContextMenu);
				if (this.DropDown != null)
				{
					this.DropDown(this, contextMenuArgs);
				}
				if (!contextMenuArgs.Cancel && contextMenuArgs.KryptonContextMenu != null)
				{
					Rectangle rectangle = Rectangle.Empty;
					if (Ribbon != null && ButtonView != null)
					{
						rectangle = Ribbon.ViewRectangleToScreen(ButtonView);
					}
					if (CommonHelper.ValidKryptonContextMenu(contextMenuArgs.KryptonContextMenu))
					{
						_kcmFinishDelegate = finishDelegate;
						contextMenuArgs.KryptonContextMenu.Closed += OnKryptonContextMenuClosed;
						if (contextMenuArgs.KryptonContextMenu.Show(this, new Point(rectangle.X, rectangle.Bottom + 1)))
						{
							flag = false;
						}
					}
				}
			}
			else if (ContextMenuStrip != null)
			{
				ContextMenuArgs contextMenuArgs2 = new ContextMenuArgs(ContextMenuStrip);
				if (this.DropDown != null)
				{
					this.DropDown(this, contextMenuArgs2);
				}
				if (!contextMenuArgs2.Cancel && contextMenuArgs2.ContextMenuStrip != null)
				{
					Rectangle rectangle2 = Rectangle.Empty;
					if (Ribbon != null && ButtonView != null)
					{
						rectangle2 = Ribbon.ViewRectangleToScreen(ButtonView);
					}
					if (CommonHelper.ValidContextMenuStrip(contextMenuArgs2.ContextMenuStrip))
					{
						flag = false;
						VisualPopupManager.Singleton.ShowContextMenuStrip(contextMenuArgs2.ContextMenuStrip, new Point(rectangle2.X, rectangle2.Bottom + 1), finishDelegate);
					}
				}
			}
		}
		if (flag)
		{
			finishDelegate?.Invoke(this, EventArgs.Empty);
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
		if (Enabled && base.ChainVisible)
		{
			if (ShortcutKeys != Keys.None && ShortcutKeys == keyData)
			{
				switch (ButtonType)
				{
				case GroupButtonType.Push:
				case GroupButtonType.Check:
					PerformClick();
					return true;
				case GroupButtonType.DropDown:
				case GroupButtonType.Split:
					PerformDropDown();
					return true;
				default:
					Debug.Assert(condition: false);
					return true;
				}
			}
			if (ButtonType == GroupButtonType.DropDown || ButtonType == GroupButtonType.Split)
			{
				if (KryptonContextMenu != null && KryptonContextMenu.ProcessShortcut(keyData))
				{
					return true;
				}
				if (ContextMenuStrip != null && CommonHelper.CheckContextMenuForShortcut(ContextMenuStrip, ref msg, keyData))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void OnKryptonContextMenuClosed(object sender, EventArgs e)
	{
		KryptonContextMenu kryptonContextMenu = (KryptonContextMenu)sender;
		kryptonContextMenu.Closed -= OnKryptonContextMenuClosed;
		if (_kcmFinishDelegate != null)
		{
			_kcmFinishDelegate(this, e);
			_kcmFinishDelegate = null;
		}
	}
}
