using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteColorButtonStrings : Storage
{
	private static readonly string _defaultMoreColors = "&More Colors...";

	private static readonly string _defaultNoColor = "&No Color";

	private static readonly string _defaultRecentColors = "Recent Colors";

	private static readonly string _defaultStandardColors = "Standard Colors";

	private static readonly string _defaultThemeColors = "Theme Colors";

	private string _moreColors;

	private string _noColor;

	private string _recentColors;

	private string _standardColors;

	private string _themeColors;

	[Browsable(false)]
	public override bool IsDefault => MoreColors.Equals(_defaultMoreColors) && NoColor.Equals(_defaultNoColor) && RecentColors.Equals(_defaultRecentColors) && StandardColors.Equals(_defaultStandardColors) && ThemeColors.Equals(_defaultThemeColors);

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

	public PaletteColorButtonStrings()
	{
		_moreColors = _defaultMoreColors;
		_noColor = _defaultNoColor;
		_recentColors = _defaultRecentColors;
		_standardColors = _defaultStandardColors;
		_themeColors = _defaultThemeColors;
	}
}
