namespace System.Windows.Forms;

public class Theme
{
	private static Theme _Default;

	private RibbonTheme _Theme;

	public static Theme Standard
	{
		get
		{
			if (_Default == null)
			{
				_Default = new Theme();
			}
			return _Default;
		}
	}

	public static bool StandardThemeIsGlobal { get; set; } = true;

	public RibbonProfesionalRendererColorTable RendererColorTable { get; set; } = new RibbonProfesionalRendererColorTable();

	public RibbonOrbStyle Style { get; set; }

	public RibbonTheme RibbonTheme
	{
		get
		{
			return _Theme;
		}
		set
		{
			_Theme = value;
			if (_Theme == RibbonTheme.Blue || _Theme == RibbonTheme.Normal)
			{
				RendererColorTable = new RibbonProfesionalRendererColorTable();
			}
			else if (_Theme == RibbonTheme.Black)
			{
				RendererColorTable = new RibbonProfesionalRendererColorTableBlack();
			}
			else if (_Theme == RibbonTheme.Blue_2010)
			{
				RendererColorTable = new RibbonProfesionalRendererColorTableBlue2010();
			}
			else if (_Theme == RibbonTheme.Green)
			{
				RendererColorTable = new RibbonProfesionalRendererColorTableGreen();
			}
			else if (_Theme == RibbonTheme.Purple)
			{
				RendererColorTable = new RibbonProfesionalRendererColorTablePurple();
			}
			else if (_Theme == RibbonTheme.JellyBelly)
			{
				RendererColorTable = new RibbonProfesionalRendererColorTableJellyBelly();
			}
			else if (_Theme == RibbonTheme.Halloween)
			{
				RendererColorTable = new RibbonProfesionalRendererColorTableHalloween();
			}
		}
	}

	[Obsolete("Either create a theme for your Ribbon or use 'Standard' instance!")]
	public static RibbonProfesionalRendererColorTable ColorTable
	{
		get
		{
			return Standard.RendererColorTable;
		}
		set
		{
			Standard.RendererColorTable = value;
		}
	}

	[Obsolete("Either create a theme for your Ribbon or use 'Standard' instance!")]
	public static RibbonOrbStyle ThemeStyle
	{
		get
		{
			return Standard.Style;
		}
		set
		{
			Standard.Style = value;
		}
	}

	[Obsolete("Either create a theme for your Ribbon or use 'Standard' instance!")]
	public RibbonTheme ThemeColor
	{
		get
		{
			return Standard.RibbonTheme;
		}
		set
		{
			Standard.RibbonTheme = value;
		}
	}

	public Theme()
	{
	}

	public Theme(RibbonOrbStyle style)
	{
		Style = style;
	}

	public Theme(RibbonOrbStyle style, RibbonTheme theme)
		: this(style)
	{
		RibbonTheme = theme;
	}

	public Theme(RibbonOrbStyle style, RibbonProfesionalRendererColorTable colorTable)
		: this(style)
	{
		RendererColorTable = colorTable;
	}
}
