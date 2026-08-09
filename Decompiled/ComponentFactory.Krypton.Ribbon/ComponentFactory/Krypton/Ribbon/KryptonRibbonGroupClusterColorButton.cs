#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupClusterColorButton), "ToolboxBitmaps.KryptonRibbonGroupClusterColorButton.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupClusterColorButtonDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("SelectedColorChanged")]
[DefaultProperty("SelectedColor")]
public class KryptonRibbonGroupClusterColorButton : KryptonRibbonGroupItem
{
	private static readonly Image _defaultButtonImageSmall = Resources.ButtonColorImageSmall;

	private bool _enabled;

	private bool _visible;

	private bool _checked;

	private bool _autoRecentColors;

	private bool _visibleThemes;

	private bool _visibleStandard;

	private bool _visibleRecent;

	private bool _visibleNoColor;

	private bool _visibleMoreColors;

	private string _textLine;

	private string _keyTip;

	private string _toolTipTitle;

	private string _toolTipBody;

	private Rectangle _selectedRect;

	private Color _selectedColor;

	private Color _emptyBorderColor;

	private Image _toolTipImage;

	private Image _imageSmall;

	private Color _toolTipImageTransparentColor;

	private LabelStyle _toolTipStyle;

	private Keys _shortcutKeys;

	private KryptonCommand _command;

	private GroupItemSize _itemSizeMax;

	private GroupItemSize _itemSizeMin;

	private GroupItemSize _itemSizeCurrent;

	private GroupButtonType _buttonType;

	private EventHandler _kcmFinishDelegate;

	private ViewBase _clusterColorButtonView;

	private ColorScheme _schemeThemes;

	private ColorScheme _schemeStandard;

	private int _maxRecentColors;

	private List<Color> _recentColors;

	private KryptonContextMenu _kryptonContextMenu;

	private KryptonContextMenuSeparator _separatorTheme;

	private KryptonContextMenuSeparator _separatorStandard;

	private KryptonContextMenuSeparator _separatorRecent;

	private KryptonContextMenuHeading _headingTheme;

	private KryptonContextMenuHeading _headingStandard;

	private KryptonContextMenuHeading _headingRecent;

	private KryptonContextMenuColorColumns _colorsTheme;

	private KryptonContextMenuColorColumns _colorsStandard;

	private KryptonContextMenuColorColumns _colorsRecent;

	private KryptonContextMenuSeparator _separatorNoColor;

	private KryptonContextMenuItems _itemsNoColor;

	private KryptonContextMenuItem _itemNoColor;

	private KryptonContextMenuSeparator _separatorMoreColors;

	private KryptonContextMenuItems _itemsMoreColors;

	private KryptonContextMenuItem _itemMoreColors;

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Selected color.")]
	[DefaultValue(typeof(Color), "Red")]
	public Color SelectedColor
	{
		get
		{
			return _selectedColor;
		}
		set
		{
			if (value != _selectedColor)
			{
				_selectedColor = value;
				UpdateRecentColors(_selectedColor);
				OnSelectedColorChanged(_selectedColor);
				OnPropertyChanged("SelectedColor");
			}
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Border color of selected block when selected color is empty.")]
	[DefaultValue(typeof(Color), "DarkGray")]
	public Color EmptyBorderColor
	{
		get
		{
			return _emptyBorderColor;
		}
		set
		{
			if (value != _emptyBorderColor)
			{
				_emptyBorderColor = value;
				OnPropertyChanged("EmptyBorderColor");
			}
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Selected color drawing rectangle.")]
	[DefaultValue(typeof(Rectangle), "0,12,16,4")]
	public Rectangle SelectedRect
	{
		get
		{
			return _selectedRect;
		}
		set
		{
			_selectedRect = value;
			OnPropertyChanged("SelectedRect");
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Color button display text line.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("")]
	public string TextLine
	{
		get
		{
			return _textLine;
		}
		set
		{
			if (value != _textLine)
			{
				_textLine = value;
				OnPropertyChanged("TextLine");
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group cluster color button key tip.")]
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
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Small color button image.")]
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

	[Category("Behavior")]
	[Description("Determine the maximum number of recent colors to store and display.")]
	[DefaultValue(10)]
	public int MaxRecentColors
	{
		get
		{
			return _maxRecentColors;
		}
		set
		{
			if (value != _maxRecentColors)
			{
				_maxRecentColors = value;
				OnPropertyChanged("MaxRecentColors");
			}
		}
	}

	[Category("Behavior")]
	[Description("Determine the visible state of the themes color set.")]
	[DefaultValue(true)]
	public bool VisibleThemes
	{
		get
		{
			return _visibleThemes;
		}
		set
		{
			if (value != _visibleThemes)
			{
				_visibleThemes = value;
				OnPropertyChanged("VisibleThemes");
			}
		}
	}

	[Category("Behavior")]
	[Description("Determine the visible state of the standard color set.")]
	[DefaultValue(true)]
	public bool VisibleStandard
	{
		get
		{
			return _visibleStandard;
		}
		set
		{
			if (value != _visibleStandard)
			{
				_visibleStandard = value;
				OnPropertyChanged("VisibleStandard");
			}
		}
	}

	[Category("Behavior")]
	[Description("Determine the visible state of the recent color set.")]
	[DefaultValue(true)]
	public bool VisibleRecent
	{
		get
		{
			return _visibleRecent;
		}
		set
		{
			if (value != _visibleRecent)
			{
				_visibleRecent = value;
				OnPropertyChanged("VisibleRecent");
			}
		}
	}

	[Category("Behavior")]
	[Description("Determine if the 'No Color' menu item is used.")]
	[DefaultValue(true)]
	public bool VisibleNoColor
	{
		get
		{
			return _visibleNoColor;
		}
		set
		{
			if (value != _visibleNoColor)
			{
				_visibleNoColor = value;
				OnPropertyChanged("VisibleNoColor");
			}
		}
	}

	[Category("Behavior")]
	[Description("Determine if the 'More Colors...' menu item is used.")]
	[DefaultValue(true)]
	public bool VisibleMoreColors
	{
		get
		{
			return _visibleMoreColors;
		}
		set
		{
			if (value != _visibleMoreColors)
			{
				_visibleMoreColors = value;
				OnPropertyChanged("VisibleMoreColors");
			}
		}
	}

	[Category("Behavior")]
	[Description("Should recent colors be automatically updated.")]
	[DefaultValue(true)]
	public bool AutoRecentColors
	{
		get
		{
			return _autoRecentColors;
		}
		set
		{
			if (value != _autoRecentColors)
			{
				_autoRecentColors = value;
				OnPropertyChanged("AutoRecentColors");
			}
		}
	}

	[Category("Behavior")]
	[Description("Color scheme to use for the themes color set.")]
	[DefaultValue(typeof(ColorScheme), "OfficeThemes")]
	public ColorScheme SchemeThemes
	{
		get
		{
			return _schemeThemes;
		}
		set
		{
			if (value != _schemeThemes)
			{
				_schemeThemes = value;
				OnPropertyChanged("SchemeThemes");
			}
		}
	}

	[Category("Behavior")]
	[Description("Color scheme to use for the standard color set.")]
	[DefaultValue(typeof(ColorScheme), "OfficeStandard")]
	public ColorScheme SchemeStandard
	{
		get
		{
			return _schemeStandard;
		}
		set
		{
			if (value != _schemeStandard)
			{
				_schemeStandard = value;
				OnPropertyChanged("SchemeStandard");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the cluster color button is visible or hidden.")]
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
	[Description("Determines whether the group color button is enabled.")]
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
	[Description("Determines whether the group color button is checked.")]
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
	[Description("Determines how the group color button operation.")]
	[DefaultValue(typeof(GroupButtonType), "Split")]
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
	[Description("Shortcut key combination to fire click event of the cluster color button.")]
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
	[Description("Tooltip style for the group color cluster button.")]
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

	[Category("Appearance")]
	[Description("Collection of recent colors.")]
	public Color[] RecentColors
	{
		get
		{
			return _recentColors.ToArray();
		}
		set
		{
			ClearRecentColors();
			if (value != null)
			{
				_recentColors.AddRange(value);
			}
		}
	}

	[Category("Behavior")]
	[Description("Command associated with the color button.")]
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
			if (value == GroupItemSize.Large)
			{
				value = GroupItemSize.Medium;
			}
			if (_itemSizeMax != value)
			{
				_itemSizeMax = value;
				if (_itemSizeMax == GroupItemSize.Small)
				{
					_itemSizeMin = GroupItemSize.Small;
				}
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
			if (value == GroupItemSize.Large)
			{
				value = GroupItemSize.Medium;
			}
			if (_itemSizeMin != value)
			{
				_itemSizeMin = value;
				if (_itemSizeMin == GroupItemSize.Medium)
				{
					_itemSizeMax = GroupItemSize.Medium;
				}
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
	public ViewBase ClusterColorButtonView
	{
		get
		{
			return _clusterColorButtonView;
		}
		set
		{
			_clusterColorButtonView = value;
		}
	}

	internal override LabelStyle InternalToolTipStyle => ToolTipStyle;

	internal override Image InternalToolTipImage => ToolTipImage;

	internal override Color InternalToolTipImageTransparentColor => ToolTipImageTransparentColor;

	internal override string InternalToolTipTitle => ToolTipTitle;

	internal override string InternalToolTipBody => ToolTipBody;

	[Category("Ribbon")]
	[Description("Occurs when the color button is clicked.")]
	public event EventHandler Click;

	[Category("Ribbon")]
	[Description("Occurs when the drop down color button type is pressed.")]
	public event EventHandler<ContextMenuArgs> DropDown;

	[Category("Ribbon")]
	[Description("Occurs when the SelectedColor property changes value.")]
	public event EventHandler<ColorEventArgs> SelectedColorChanged;

	[Category("Ribbon")]
	[Description("Occurs when user is tracking over a color.")]
	public event EventHandler<ColorEventArgs> TrackingColor;

	[Category("Ribbon")]
	[Description("Occurs when user selects the more colors option.")]
	public event CancelEventHandler MoreColors;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	public KryptonRibbonGroupClusterColorButton()
	{
		_enabled = true;
		_visible = true;
		_checked = false;
		_autoRecentColors = true;
		_keyTip = "B";
		_textLine = string.Empty;
		_shortcutKeys = Keys.None;
		_selectedColor = Color.Red;
		_emptyBorderColor = Color.DarkGray;
		_selectedRect = new Rectangle(0, 12, 16, 4);
		_schemeThemes = ColorScheme.OfficeThemes;
		_schemeStandard = ColorScheme.OfficeStandard;
		_visibleThemes = true;
		_visibleStandard = true;
		_visibleRecent = true;
		_visibleNoColor = true;
		_visibleMoreColors = true;
		_itemSizeMax = GroupItemSize.Medium;
		_itemSizeMin = GroupItemSize.Small;
		_itemSizeCurrent = GroupItemSize.Medium;
		_imageSmall = _defaultButtonImageSmall;
		_buttonType = GroupButtonType.Split;
		_toolTipImageTransparentColor = Color.Empty;
		_toolTipTitle = string.Empty;
		_toolTipBody = string.Empty;
		_toolTipStyle = LabelStyle.SuperTip;
		_maxRecentColors = 10;
		_recentColors = new List<Color>();
		_kryptonContextMenu = new KryptonContextMenu();
		_separatorTheme = new KryptonContextMenuSeparator();
		_headingTheme = new KryptonContextMenuHeading("Theme Colors");
		_colorsTheme = new KryptonContextMenuColorColumns(ColorScheme.OfficeThemes);
		_separatorStandard = new KryptonContextMenuSeparator();
		_headingStandard = new KryptonContextMenuHeading("Standard Colors");
		_colorsStandard = new KryptonContextMenuColorColumns(ColorScheme.OfficeStandard);
		_separatorRecent = new KryptonContextMenuSeparator();
		_headingRecent = new KryptonContextMenuHeading("Recent Colors");
		_colorsRecent = new KryptonContextMenuColorColumns(ColorScheme.None);
		_separatorNoColor = new KryptonContextMenuSeparator();
		_itemNoColor = new KryptonContextMenuItem("&No Color", Resources.ButtonNoColor, OnClickNoColor);
		_itemsNoColor = new KryptonContextMenuItems();
		_itemsNoColor.Items.Add(_itemNoColor);
		_separatorMoreColors = new KryptonContextMenuSeparator();
		_itemMoreColors = new KryptonContextMenuItem("&More Colors...", OnClickMoreColors);
		_itemsMoreColors = new KryptonContextMenuItems();
		_itemsMoreColors.Items.Add(_itemMoreColors);
		_kryptonContextMenu.Items.AddRange(new KryptonContextMenuItemBase[13]
		{
			_separatorTheme, _headingTheme, _colorsTheme, _separatorStandard, _headingStandard, _colorsStandard, _separatorRecent, _headingRecent, _colorsRecent, _separatorNoColor,
			_itemsNoColor, _separatorMoreColors, _itemsMoreColors
		});
	}

	private bool ShouldSerializeImageSmall()
	{
		return ImageSmall != _defaultButtonImageSmall;
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

	public void ClearRecentColors()
	{
		_recentColors.Clear();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupClusterColorButton(ribbon, this, needPaint);
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
		case "Text":
			OnPropertyChanged("TextLine");
			break;
		case "ImageSmall":
			OnPropertyChanged("ImageSmall");
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
		if (!Ribbon.InDesignMode && Enabled && (ButtonType == GroupButtonType.DropDown || ButtonType == GroupButtonType.Split) && _kryptonContextMenu != null)
		{
			UpdateContextMenu();
			ContextMenuArgs contextMenuArgs = new ContextMenuArgs(_kryptonContextMenu);
			if (this.DropDown != null)
			{
				this.DropDown(this, contextMenuArgs);
			}
			if (!contextMenuArgs.Cancel && contextMenuArgs.KryptonContextMenu != null)
			{
				Rectangle rectangle = Rectangle.Empty;
				if (Ribbon != null && ClusterColorButtonView != null)
				{
					rectangle = Ribbon.ViewRectangleToScreen(ClusterColorButtonView);
				}
				if (CommonHelper.ValidKryptonContextMenu(contextMenuArgs.KryptonContextMenu))
				{
					_kcmFinishDelegate = finishDelegate;
					DecideOnVisible(_separatorTheme, _colorsTheme);
					DecideOnVisible(_separatorStandard, _colorsStandard);
					DecideOnVisible(_separatorRecent, _colorsRecent);
					DecideOnVisible(_separatorNoColor, _itemsNoColor);
					DecideOnVisible(_separatorMoreColors, _itemsMoreColors);
					HookContextMenuEvents(_kryptonContextMenu.Items, hook: true);
					contextMenuArgs.KryptonContextMenu.Closed += OnKryptonContextMenuClosed;
					if (contextMenuArgs.KryptonContextMenu.Show(this, new Point(rectangle.X, rectangle.Bottom + 1)))
					{
						flag = false;
					}
				}
			}
		}
		if (flag)
		{
			finishDelegate?.Invoke(this, EventArgs.Empty);
		}
	}

	protected virtual void OnSelectedColorChanged(Color selectedColor)
	{
		if (this.SelectedColorChanged != null)
		{
			this.SelectedColorChanged(this, new ColorEventArgs(selectedColor));
		}
	}

	protected virtual void OnTrackingColor(ColorEventArgs e)
	{
		if (this.TrackingColor != null)
		{
			this.TrackingColor(this, e);
		}
	}

	protected virtual void OnMoreColors(CancelEventArgs e)
	{
		if (this.MoreColors != null)
		{
			this.MoreColors(this, e);
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
			if ((ButtonType == GroupButtonType.DropDown || ButtonType == GroupButtonType.Split) && _kryptonContextMenu != null && _kryptonContextMenu.ProcessShortcut(keyData))
			{
				return true;
			}
		}
		return false;
	}

	private void HookContextMenuEvents(KryptonContextMenuCollection collection, bool hook)
	{
		foreach (KryptonContextMenuItemBase item in collection)
		{
			if (item is KryptonContextMenuColorColumns)
			{
				KryptonContextMenuColorColumns kryptonContextMenuColorColumns = (KryptonContextMenuColorColumns)item;
				kryptonContextMenuColorColumns.SelectedColor = _selectedColor;
				if (hook)
				{
					kryptonContextMenuColorColumns.TrackingColor += OnColumnsTrackingColor;
					kryptonContextMenuColorColumns.SelectedColorChanged += OnColumnsSelectedColorChanged;
				}
				else
				{
					kryptonContextMenuColorColumns.TrackingColor -= OnColumnsTrackingColor;
					kryptonContextMenuColorColumns.SelectedColorChanged -= OnColumnsSelectedColorChanged;
				}
			}
		}
	}

	private void UpdateRecentColors(Color color)
	{
		if (!AutoRecentColors)
		{
			return;
		}
		foreach (KryptonContextMenuItemBase item in _kryptonContextMenu.Items)
		{
			if (item is KryptonContextMenuColorColumns && item != _colorsRecent)
			{
				KryptonContextMenuColorColumns kryptonContextMenuColorColumns = (KryptonContextMenuColorColumns)item;
				if ((item != _colorsTheme || VisibleThemes) && (item != _colorsStandard || VisibleStandard) && kryptonContextMenuColorColumns.ContainsColor(color))
				{
					return;
				}
			}
		}
		if (color.Equals(Color.Empty))
		{
			return;
		}
		bool flag = false;
		foreach (Color recentColor in _recentColors)
		{
			if (recentColor.Equals(color))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			_recentColors.Insert(0, color);
			if (_recentColors.Count > MaxRecentColors)
			{
				_recentColors.RemoveRange(MaxRecentColors, _recentColors.Count - MaxRecentColors);
			}
		}
	}

	private void UpdateContextMenu()
	{
		KryptonContextMenuSeparator separatorTheme = _separatorTheme;
		KryptonContextMenuHeading headingTheme = _headingTheme;
		bool flag = (_colorsTheme.Visible = _visibleThemes);
		bool visible = (headingTheme.Visible = flag);
		separatorTheme.Visible = visible;
		KryptonContextMenuSeparator separatorStandard = _separatorStandard;
		KryptonContextMenuHeading headingStandard = _headingStandard;
		flag = (_colorsStandard.Visible = _visibleStandard);
		visible = (headingStandard.Visible = flag);
		separatorStandard.Visible = visible;
		KryptonContextMenuSeparator separatorRecent = _separatorRecent;
		KryptonContextMenuHeading headingRecent = _headingRecent;
		flag = (_colorsRecent.Visible = _visibleRecent && _recentColors.Count > 0);
		visible = (headingRecent.Visible = flag);
		separatorRecent.Visible = visible;
		_itemsNoColor.Visible = _visibleNoColor;
		_itemsMoreColors.Visible = _visibleMoreColors;
		_headingTheme.Text = Ribbon.RibbonStrings.ThemeColors;
		_headingStandard.Text = Ribbon.RibbonStrings.StandardColors;
		_headingRecent.Text = Ribbon.RibbonStrings.RecentColors;
		_itemNoColor.Text = Ribbon.RibbonStrings.NoColor;
		_itemMoreColors.Text = Ribbon.RibbonStrings.MoreColors;
		_colorsTheme.ColorScheme = SchemeThemes;
		_colorsStandard.ColorScheme = SchemeStandard;
		if (_recentColors.Count == 0)
		{
			_colorsRecent.SetCustomColors(null);
		}
		else
		{
			Color[][] array = new Color[_recentColors.Count][];
			for (int i = 0; i < _recentColors.Count; i++)
			{
				array[i] = new Color[1] { _recentColors[i] };
			}
			_colorsRecent.SetCustomColors(array);
		}
		_itemNoColor.Checked = _selectedColor.Equals(Color.Empty);
	}

	private void DecideOnVisible(KryptonContextMenuItemBase visible, KryptonContextMenuItemBase target)
	{
		bool visible2 = false;
		if (target.Visible)
		{
			foreach (KryptonContextMenuItemBase item in _kryptonContextMenu.Items)
			{
				if (item == target)
				{
					break;
				}
				if (!(item is KryptonContextMenuSeparator) && !(item is KryptonContextMenuHeading) && item.Visible)
				{
					visible2 = true;
					break;
				}
			}
		}
		visible.Visible = visible2;
	}

	private void OnColumnsTrackingColor(object sender, ColorEventArgs e)
	{
		OnTrackingColor(new ColorEventArgs(e.Color));
	}

	private void OnColumnsSelectedColorChanged(object sender, ColorEventArgs e)
	{
		SelectedColor = e.Color;
	}

	private void OnClickNoColor(object sender, EventArgs e)
	{
		SelectedColor = Color.Empty;
	}

	private void OnClickMoreColors(object sender, EventArgs e)
	{
		CancelEventArgs e2 = new CancelEventArgs();
		OnMoreColors(e2);
		if (!e2.Cancel)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = SelectedColor;
			colorDialog.FullOpen = true;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				SelectedColor = colorDialog.Color;
			}
		}
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
		HookContextMenuEvents(_kryptonContextMenu.Items, hook: false);
	}
}
