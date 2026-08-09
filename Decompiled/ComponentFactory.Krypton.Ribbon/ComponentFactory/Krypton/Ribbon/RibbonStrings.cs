using System.ComponentModel;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class RibbonStrings : Storage
{
	private static readonly string _defaultAppButtonKeyTip = "F";

	private static readonly string _defaultCustomizeQuickAccessToolbar = "Customize Quick Access Toolbar";

	private static readonly string _defaultMinimize = "Mi&nimize the Ribbon";

	private static readonly string _defaultMoreColors = "&More Colors...";

	private static readonly string _defaultNoColor = "&No Color";

	private static readonly string _defaultRecentDocuments = "Recent Documents";

	private static readonly string _defaultRecentColors = "Recent Colors";

	private static readonly string _defaultShowQATAboveRibbon = "&Show Quick Access Toolbar Above the Ribbon";

	private static readonly string _defaultShowQATBelowRibbon = "&Show Quick Access Toolbar Below the Ribbon";

	private static readonly string _defaultShowAboveRibbon = "&Show Above the Ribbon";

	private static readonly string _defaultShowBelowRibbon = "&Show Below the Ribbon";

	private static readonly string _defaultStandardColors = "Standard Colors";

	private static readonly string _defaultThemeColors = "Theme Colors";

	private string _appButtonKeyTip;

	private string _customizeQuickAccessToolbar;

	private string _minimize;

	private string _moreColors;

	private string _noColor;

	private string _recentDocuments;

	private string _recentColors;

	private string _showAboveRibbon;

	private string _showBelowRibbon;

	private string _showQATAboveRibbon;

	private string _showQATBelowRibbon;

	private string _standardColors;

	private string _themeColors;

	[Browsable(false)]
	public override bool IsDefault => AppButtonKeyTip.Equals(_defaultAppButtonKeyTip) && CustomizeQuickAccessToolbar.Equals(_defaultCustomizeQuickAccessToolbar) && Minimize.Equals(_defaultMinimize) && MoreColors.Equals(_defaultMoreColors) && NoColor.Equals(_defaultNoColor) && RecentDocuments.Equals(_defaultRecentDocuments) && RecentColors.Equals(_defaultRecentColors) && ShowAboveRibbon.Equals(_defaultShowAboveRibbon) && ShowBelowRibbon.Equals(_defaultShowBelowRibbon) && ShowQATAboveRibbon.Equals(_defaultShowQATAboveRibbon) && ShowQATBelowRibbon.Equals(_defaultShowQATBelowRibbon) && StandardColors.Equals(_defaultStandardColors) && ThemeColors.Equals(_defaultThemeColors);

	[Localizable(true)]
	[Category("Values")]
	[Description("Application button key tip string.")]
	[DefaultValue("F")]
	[RefreshProperties(RefreshProperties.All)]
	public string AppButtonKeyTip
	{
		get
		{
			return _appButtonKeyTip;
		}
		set
		{
			if (!string.IsNullOrEmpty(value))
			{
				_appButtonKeyTip = value.ToUpper();
			}
		}
	}

	[Localizable(true)]
	[Category("Values")]
	[Description("Heading for quick access toolbar menu.")]
	[DefaultValue("Customize Quick Access Toolbar")]
	[RefreshProperties(RefreshProperties.All)]
	public string CustomizeQuickAccessToolbar
	{
		get
		{
			return _customizeQuickAccessToolbar;
		}
		set
		{
			_customizeQuickAccessToolbar = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Menu string for minimizing the ribbon option.")]
	[DefaultValue("Mi&nimize the Ribbon")]
	[RefreshProperties(RefreshProperties.All)]
	public string Minimize
	{
		get
		{
			return _minimize;
		}
		set
		{
			_minimize = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Menu string for a 'more colors' entry.")]
	[DefaultValue("&More Colors...")]
	[RefreshProperties(RefreshProperties.All)]
	public string MoreColors
	{
		get
		{
			return _moreColors;
		}
		set
		{
			_moreColors = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Menu string for a 'no color' entry.")]
	[DefaultValue("&No Color")]
	[RefreshProperties(RefreshProperties.All)]
	public string NoColor
	{
		get
		{
			return _noColor;
		}
		set
		{
			_noColor = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Title for recent documents section of the application menu.")]
	[DefaultValue("Recent Documents")]
	[RefreshProperties(RefreshProperties.All)]
	public string RecentDocuments
	{
		get
		{
			return _recentDocuments;
		}
		set
		{
			_recentDocuments = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Title for recent colors section of the color button menu.")]
	[DefaultValue("Recent Colors")]
	[RefreshProperties(RefreshProperties.All)]
	public string RecentColors
	{
		get
		{
			return _recentColors;
		}
		set
		{
			_recentColors = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Menu string for showing above the ribbon.")]
	[DefaultValue("&Show Above the Ribbon")]
	[RefreshProperties(RefreshProperties.All)]
	public string ShowAboveRibbon
	{
		get
		{
			return _showAboveRibbon;
		}
		set
		{
			_showAboveRibbon = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Menu string for showing below the ribbon.")]
	[DefaultValue("&Show Below the Ribbon")]
	[RefreshProperties(RefreshProperties.All)]
	public string ShowBelowRibbon
	{
		get
		{
			return _showBelowRibbon;
		}
		set
		{
			_showBelowRibbon = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Menu string for showing QAT above the ribbon.")]
	[DefaultValue("&Show Quick Access Toolbar Above the Ribbon")]
	[RefreshProperties(RefreshProperties.All)]
	public string ShowQATAboveRibbon
	{
		get
		{
			return _showQATAboveRibbon;
		}
		set
		{
			_showQATAboveRibbon = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Menu string for showing QAT below the ribbon.")]
	[DefaultValue("&Show Quick Access Toolbar Below the Ribbon")]
	[RefreshProperties(RefreshProperties.All)]
	public string ShowQATBelowRibbon
	{
		get
		{
			return _showQATBelowRibbon;
		}
		set
		{
			_showQATBelowRibbon = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Title for standard colors section of the color button menu.")]
	[DefaultValue("Standard Colors")]
	[RefreshProperties(RefreshProperties.All)]
	public string StandardColors
	{
		get
		{
			return _standardColors;
		}
		set
		{
			_standardColors = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Title for theme colors section of the color button menu.")]
	[DefaultValue("Theme Colors")]
	[RefreshProperties(RefreshProperties.All)]
	public string ThemeColors
	{
		get
		{
			return _themeColors;
		}
		set
		{
			_themeColors = value;
		}
	}

	public RibbonStrings()
	{
		_appButtonKeyTip = _defaultAppButtonKeyTip;
		_customizeQuickAccessToolbar = _defaultCustomizeQuickAccessToolbar;
		_minimize = _defaultMinimize;
		_moreColors = _defaultMoreColors;
		_noColor = _defaultNoColor;
		_recentDocuments = _defaultRecentDocuments;
		_recentColors = _defaultRecentColors;
		_showAboveRibbon = _defaultShowAboveRibbon;
		_showBelowRibbon = _defaultShowBelowRibbon;
		_showQATAboveRibbon = _defaultShowQATAboveRibbon;
		_showQATBelowRibbon = _defaultShowQATBelowRibbon;
		_standardColors = _defaultStandardColors;
		_themeColors = _defaultThemeColors;
	}
}
