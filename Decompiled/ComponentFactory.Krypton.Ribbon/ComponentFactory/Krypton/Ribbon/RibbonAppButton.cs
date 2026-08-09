#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class RibbonAppButton : Storage
{
	public class AppMenuButtonSpecCollection : ButtonSpecCollection<ButtonSpecAppMenu>
	{
		public AppMenuButtonSpecCollection(KryptonRibbon owner)
			: base((object)owner)
		{
		}
	}

	private static readonly Image _defaultAppImage = Resources.AppButtonDefault;

	private static readonly string _defaultAppText = "File";

	private static readonly Color _defaultAppBaseColorDark = Color.FromArgb(31, 72, 161);

	private static readonly Color _defaultAppBaseColorLight = Color.FromArgb(84, 158, 243);

	private KryptonRibbon _ribbon;

	private Image _appButtonImage;

	private Image _appButtonToolTipImage;

	private string _appButtonToolTipTitle;

	private string _appButtonToolTipBody;

	private Color _appButtonToolTipImageTransparentColor;

	private KryptonContextMenuItems _appButtonMenuItems;

	private KryptonRibbonRecentDocCollection _appButtonRecentDocs;

	private LabelStyle _appButtonToolTipStyle;

	private AppMenuButtonSpecCollection _appButtonSpecs;

	private Size _appButtonMinRecentSize;

	private Size _appButtonMaxRecentSize;

	private bool _appButtonShowRecentDocs;

	private bool _appButtonVisible;

	private Color _appButtonBaseColorDark;

	private Color _appButtonBaseColorLight;

	private Color _appButtonTextColor;

	private string _appButtonText;

	[Browsable(false)]
	public override bool IsDefault => AppButtonImage == _defaultAppImage && AppButtonText == _defaultAppText && AppButtonBaseColorDark == _defaultAppBaseColorDark && AppButtonBaseColorLight == _defaultAppBaseColorLight && AppButtonTextColor == Color.White && AppButtonMenuItems.Count == 0 && AppButtonRecentDocs.Count == 0 && AppButtonMinRecentSize.Equals(new Size(250, 250)) && AppButtonMaxRecentSize.Equals(new Size(350, 350)) && AppButtonShowRecentDocs && AppButtonSpecs.Count == 0 && string.IsNullOrEmpty(AppButtonToolTipBody) && string.IsNullOrEmpty(AppButtonToolTipBody) && AppButtonToolTipImage == null && AppButtonToolTipImageTransparentColor == Color.Empty && AppButtonToolTipStyle == LabelStyle.SuperTip && AppButtonVisible;

	[Localizable(true)]
	[Category("Values")]
	[Description("Application button image.")]
	[RefreshProperties(RefreshProperties.All)]
	public Image AppButtonImage
	{
		get
		{
			return _appButtonImage;
		}
		set
		{
			if (_appButtonImage != value)
			{
				_appButtonImage = value;
				if (_ribbon.CaptionArea != null)
				{
					_ribbon.CaptionArea.AppButtonChanged();
				}
			}
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Darker base color used for drawing an Office 2010 style application button.")]
	[KryptonDefaultColor]
	[DefaultValue(typeof(Color), "31, 72, 161")]
	public Color AppButtonBaseColorDark
	{
		get
		{
			return _appButtonBaseColorDark;
		}
		set
		{
			_ = _appButtonBaseColorDark;
			if (true)
			{
				_appButtonBaseColorDark = value;
				_ribbon.PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Lighter base color used for drawing an Office 2010 style application button.")]
	[KryptonDefaultColor]
	[DefaultValue(typeof(Color), "84, 158, 243")]
	public Color AppButtonBaseColorLight
	{
		get
		{
			return _appButtonBaseColorLight;
		}
		set
		{
			_ = _appButtonBaseColorLight;
			if (true)
			{
				_appButtonBaseColorLight = value;
				_ribbon.PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Text color used for drawing an Office 2010 style application button.")]
	[KryptonDefaultColor]
	[DefaultValue(typeof(Color), "White")]
	public Color AppButtonTextColor
	{
		get
		{
			return _appButtonTextColor;
		}
		set
		{
			_ = _appButtonTextColor;
			if (true)
			{
				_appButtonTextColor = value;
				_ribbon.PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Text used for drawing an Office 2010 style application button.")]
	[KryptonDefaultColor]
	[DefaultValue("File")]
	[Localizable(true)]
	public string AppButtonText
	{
		get
		{
			return _appButtonText;
		}
		set
		{
			if (_appButtonText != null)
			{
				_appButtonText = value;
				_ribbon.PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Values")]
	[Description("Context menu items for the application button.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemCollectionEditor, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
	public virtual KryptonContextMenuItemCollection AppButtonMenuItems => _appButtonMenuItems.Items;

	[Category("Values")]
	[Description("Recent document entries for the application buttton.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("ComponentFactory.Krypton.Ribbon.KryptonRibbonRecentDocCollectionEditor, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
	public virtual KryptonRibbonRecentDocCollection AppButtonRecentDocs => _appButtonRecentDocs;

	[Category("Values")]
	[Description("Minimum size of the recent documents area of the application button.")]
	[DefaultValue(typeof(Size), "250,250")]
	public Size AppButtonMinRecentSize
	{
		get
		{
			return _appButtonMinRecentSize;
		}
		set
		{
			_appButtonMinRecentSize = value;
		}
	}

	[Category("Values")]
	[Description("Maximum size of the recent documents area of the application button.")]
	[DefaultValue(typeof(Size), "350,350")]
	public Size AppButtonMaxRecentSize
	{
		get
		{
			return _appButtonMaxRecentSize;
		}
		set
		{
			_appButtonMaxRecentSize = value;
		}
	}

	[Category("Visuals")]
	[Description("Collection of button specifications for the app button context menu.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public AppMenuButtonSpecCollection AppButtonSpecs => _appButtonSpecs;

	[Category("Visuals")]
	[Description("Determine if the recent documents area should be shown in the application button.")]
	[DefaultValue(true)]
	public bool AppButtonShowRecentDocs
	{
		get
		{
			return _appButtonShowRecentDocs;
		}
		set
		{
			_appButtonShowRecentDocs = value;
		}
	}

	[Category("Appearance")]
	[Description("Tooltip style for the application button.")]
	[DefaultValue(typeof(LabelStyle), "SuperTip")]
	[Localizable(true)]
	public LabelStyle AppButtonToolTipStyle
	{
		get
		{
			return _appButtonToolTipStyle;
		}
		set
		{
			_appButtonToolTipStyle = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Display image associated ToolTip.")]
	[DefaultValue(null)]
	[Localizable(true)]
	public Image AppButtonToolTipImage
	{
		get
		{
			return _appButtonToolTipImage;
		}
		set
		{
			_appButtonToolTipImage = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Color to draw as transparent in the ToolTipImage.")]
	[KryptonDefaultColor]
	[Localizable(true)]
	public Color AppButtonToolTipImageTransparentColor
	{
		get
		{
			return _appButtonToolTipImageTransparentColor;
		}
		set
		{
			_appButtonToolTipImageTransparentColor = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Title text for use in associated ToolTip.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	[Localizable(true)]
	public string AppButtonToolTipTitle
	{
		get
		{
			return _appButtonToolTipTitle;
		}
		set
		{
			_appButtonToolTipTitle = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Body text for use in associated ToolTip.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	[Localizable(true)]
	public string AppButtonToolTipBody
	{
		get
		{
			return _appButtonToolTipBody;
		}
		set
		{
			_appButtonToolTipBody = value;
		}
	}

	[Category("Visuals")]
	[Description("Determine if the application button is shown.")]
	[DefaultValue(true)]
	public bool AppButtonVisible
	{
		get
		{
			return _appButtonVisible;
		}
		set
		{
			if (_appButtonVisible != value)
			{
				_appButtonVisible = value;
				if (_ribbon.CaptionArea != null)
				{
					_ribbon.TabsArea.AppButtonVisibleChanged();
					_ribbon.CaptionArea.AppButtonVisibleChanged();
					_ribbon.CaptionArea.PerformFormChromeCheck();
				}
			}
		}
	}

	public RibbonAppButton(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_appButtonMenuItems = new KryptonContextMenuItems();
		_appButtonMenuItems.ImageColumn = false;
		_appButtonImage = _defaultAppImage;
		_appButtonSpecs = new AppMenuButtonSpecCollection(ribbon);
		_appButtonRecentDocs = new KryptonRibbonRecentDocCollection();
		_appButtonToolTipTitle = string.Empty;
		_appButtonToolTipBody = string.Empty;
		_appButtonToolTipImageTransparentColor = Color.Empty;
		_appButtonToolTipStyle = LabelStyle.SuperTip;
		_appButtonMinRecentSize = new Size(250, 250);
		_appButtonMaxRecentSize = new Size(350, 350);
		_appButtonShowRecentDocs = true;
		_appButtonVisible = true;
		_appButtonBaseColorDark = _defaultAppBaseColorDark;
		_appButtonBaseColorLight = _defaultAppBaseColorLight;
		_appButtonTextColor = Color.White;
		_appButtonText = _defaultAppText;
	}

	private bool ShouldSerializeAppButtonImage()
	{
		return AppButtonImage != _defaultAppImage;
	}
}
