using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Security.Permissions;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms;

[Designer(typeof(RibbonDesigner))]
public class Ribbon : Control, IMessageFilter
{
	private delegate void HandlerCallbackMethode();

	public const string Version = "5.0";

	private const int DefaultTabSpacing = 6;

	private const int DefaultPanelSpacing = 3;

	public static int CaptionBarHeight = 24;

	private int _contextspace;

	private bool? _isopeninvisualstudiodesigner;

	internal bool ForceOrbMenu;

	private Size _lastSizeMeasured;

	private Padding _tabsMargin;

	internal bool _minimized = true;

	internal bool _expanded;

	internal bool _expanding;

	private int _expandedHeight;

	private RibbonRenderer _renderer;

	private bool _useAlwaysStandardTheme;

	private Theme _theme;

	private Padding _panelMargin;

	private RibbonTab _activeTab;

	private RibbonTab _lastSelectedTab;

	private bool _updatingSuspended;

	private bool _orbSelected;

	private bool _orbPressed;

	private bool _orbVisible;

	private Image _orbImage;

	private string _orbText;

	private Size _orbTextSize = Size.Empty;

	private RibbonWindowMode _borderMode;

	private GlobalHook _mouseHook;

	private GlobalHook _keyboardHook;

	private Font _RibbonItemFont = new Font("Trebuchet MS", 9f);

	private Font _RibbonTabFont = new Font("Trebuchet MS", 9f);

	private bool _CaptionBarVisible;

	private bool _enabled;

	internal RibbonItem ActiveTextBox;

	internal bool AltPressed;

	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(0)]
	[Category("Behavior")]
	public int ContextSpace
	{
		get
		{
			return _contextspace;
		}
		set
		{
			_contextspace = value;
			OrbStyle = OrbStyle;
		}
	}

	[DefaultValue(null)]
	[Category("Behavior")]
	public string AltKey { get; set; }

	[DefaultValue(true)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Expanded
	{
		get
		{
			return _expanded;
		}
		set
		{
			_expanded = value;
			if (!IsDesignMode() && Minimized)
			{
				_expanding = true;
				if (_expanded)
				{
					base.Height = _expandedHeight;
				}
				else
				{
					base.Height = MinimizedHeight;
				}
				OnExpandedChanged(EventArgs.Empty);
				if (_expanded)
				{
					SetUpHooks();
				}
				else if (!_expanded && RibbonPopupManager.PopupCount == 0)
				{
					DisposeHooks();
				}
				Invalidate();
				_expanding = false;
			}
		}
	}

	[DefaultValue(true)]
	[Category("Behavior")]
	[Description("Sets if the Ribbon should be enabled")]
	public new bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			_enabled = value;
			Invalidate();
			UpdateRegions();
		}
	}

	[Browsable(false)]
	[Description("Gets the height of the ribbon when collapsed")]
	public int MinimizedHeight
	{
		get
		{
			int val = ((Tabs.Count > 0) ? Tabs[0].Bounds.Bottom : 0);
			return Math.Max(OrbBounds.Bottom, val) + 1;
		}
	}

	public new Size Size
	{
		get
		{
			return base.Size;
		}
		set
		{
			base.Size = value;
			base.Height = value.Height;
			if (!Minimized || (!_expanding && Expanded))
			{
				_expandedHeight = base.Height;
			}
		}
	}

	internal Rectangle CaptionTextBounds
	{
		get
		{
			if (RightToLeft == RightToLeft.No)
			{
				int num = 0;
				int num2 = base.Width - 100;
				int num3 = num2;
				int num4 = num;
				if (OrbVisible)
				{
					num = OrbBounds.Right;
				}
				if (QuickAccessToolbar.Visible)
				{
					num = QuickAccessToolbar.Bounds.Right + 20;
				}
				if (QuickAccessToolbar.Visible && QuickAccessToolbar.DropDownButtonVisible)
				{
					num = QuickAccessToolbar.DropDownButton.Bounds.Right;
				}
				foreach (RibbonContext context in Contexts)
				{
					if (context.Visible)
					{
						num3 = Math.Min(num3, context.Bounds.Left);
						num4 = Math.Max(num4, context.Bounds.Right);
					}
				}
				if (num3 - num > num2 - num4)
				{
					return Rectangle.FromLTRB(num, 0, num3, CaptionBarSize);
				}
				return Rectangle.FromLTRB(num4, 0, num2, CaptionBarSize);
			}
			int num5 = base.ClientRectangle.Right;
			int num6 = 100;
			int num7 = num5;
			int num8 = num6;
			if (OrbVisible)
			{
				num5 = OrbBounds.Left;
			}
			if (QuickAccessToolbar.Visible)
			{
				num5 = QuickAccessToolbar.Bounds.Left - 20;
			}
			if (QuickAccessToolbar.Visible && QuickAccessToolbar.DropDownButtonVisible)
			{
				num5 = QuickAccessToolbar.DropDownButton.Bounds.Left;
			}
			foreach (RibbonContext context2 in Contexts)
			{
				if (context2.Visible)
				{
					num7 = Math.Min(num7, context2.Bounds.Left);
					num8 = Math.Max(num8, context2.Bounds.Right);
				}
			}
			if (num7 - num6 > num5 - num8)
			{
				return Rectangle.FromLTRB(num6, 0, num7, CaptionBarSize);
			}
			return Rectangle.FromLTRB(num8, 0, num5, CaptionBarSize);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool CaptionButtonsVisible { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonCaptionButton CloseButton { get; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonCaptionButton MaximizeRestoreButton { get; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonCaptionButton MinimizeButton { get; }

	[Browsable(false)]
	public RibbonFormHelper FormHelper
	{
		get
		{
			if (base.Parent is IRibbonForm ribbonForm)
			{
				return ribbonForm.Helper;
			}
			return null;
		}
	}

	[Browsable(false)]
	public LayoutHelper LayoutHelper { get; }

	[Browsable(false)]
	public RibbonWindowMode ActualBorderMode { get; private set; }

	[DefaultValue(RibbonWindowMode.NonClientAreaGlass)]
	[Category("Appearance")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[Description("Specifies how the Ribbon is placed on the window border and the non-client area")]
	public RibbonWindowMode BorderMode
	{
		get
		{
			return _borderMode;
		}
		set
		{
			_borderMode = value;
			RibbonWindowMode actualBorderMode = value;
			if (value == RibbonWindowMode.NonClientAreaGlass && !WinApi.IsGlassEnabled)
			{
				actualBorderMode = RibbonWindowMode.NonClientAreaCustomDrawn;
			}
			if (FormHelper == null || (value == RibbonWindowMode.NonClientAreaCustomDrawn && Environment.OSVersion.Platform != PlatformID.Win32NT))
			{
				actualBorderMode = RibbonWindowMode.InsideWindow;
			}
			SetActualBorderMode(actualBorderMode);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Category("Orb")]
	[Browsable(true)]
	public RibbonOrbDropDown OrbDropDown { get; }

	[DefaultValue(15)]
	[Category("Appearance")]
	[Description("Gets or sets the height of the Panel Caption area")]
	public int PanelCaptionHeight
	{
		get
		{
			return _panelMargin.Bottom;
		}
		set
		{
			_panelMargin.Bottom = value;
			UpdateRegions();
			Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonQuickAccessToolbar QuickAccessToolbar { get; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Theme Theme
	{
		get
		{
			if (_theme != null)
			{
				return _theme;
			}
			return Theme.Standard;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[Category("Orb")]
	[DefaultValue(RibbonOrbStyle.Office_2007)]
	public RibbonOrbStyle OrbStyle
	{
		get
		{
			return Theme.Style;
		}
		set
		{
			bool num = value != Theme.Style;
			EnsureCustomThemeCreated(value, ThemeColor);
			Theme.Style = value;
			switch (value)
			{
			case RibbonOrbStyle.Office_2007:
				TabsPadding = new Padding(8, 4, 8, 4);
				OrbsPadding = new Padding(8, 4, 8, 4);
				if (CaptionBarVisible)
				{
					_tabsMargin = new Padding(12, CaptionBarHeight + 2 + ContextSpace, 20, 0);
				}
				else
				{
					_tabsMargin = new Padding(12, 2 + ContextSpace, 20, 0);
				}
				TabContentMargin = new Padding(1, 0, 2, 2);
				TabContentPadding = new Padding(0);
				TabSpacing = 6;
				PanelSpacing = 4;
				PanelPadding = new Padding(3);
				_panelMargin = new Padding(3, 2, 3, 15);
				PanelMoreSize = new Size(6, 6);
				PanelMoreMargin = new Padding(0, 0, 1, 1);
				ItemMargin = new Padding(4, 2, 4, 2);
				ItemPadding = new Padding(1, 0, 1, 0);
				ItemImageToTextSpacing = 4;
				break;
			case RibbonOrbStyle.Office_2010:
			case RibbonOrbStyle.Office_2010_Extended:
				TabsPadding = new Padding(10, 3, 7, 2);
				OrbsPadding = new Padding(17, 4, 15, 4);
				if (CaptionBarVisible)
				{
					TabsMargin = new Padding(6, CaptionBarHeight + 2 + ContextSpace, 20, 0);
				}
				else
				{
					TabsMargin = new Padding(6, 2 + ContextSpace, 20, 0);
				}
				TabContentMargin = new Padding(0, 0, 0, 2);
				TabContentPadding = new Padding(0);
				TabSpacing = 3;
				PanelSpacing = 0;
				PanelPadding = new Padding(0, 1, 1, 1);
				_panelMargin = new Padding(2, 2, 2, 15);
				PanelMoreSize = new Size(6, 6);
				PanelMoreMargin = new Padding(0, 0, 2, 0);
				ItemMargin = new Padding(3, 2, 0, 2);
				ItemPadding = new Padding(1, 0, 1, 0);
				ItemImageToTextSpacing = 11;
				break;
			case RibbonOrbStyle.Office_2013:
				TabsPadding = new Padding(8, 4, 8, 1);
				OrbsPadding = new Padding(15, 3, 15, 3);
				if (CaptionBarVisible)
				{
					_tabsMargin = new Padding(5, CaptionBarHeight + 2 + ContextSpace, 20, 0);
				}
				else
				{
					_tabsMargin = new Padding(5, 2 + ContextSpace, 20, 0);
				}
				TabContentMargin = new Padding(0, 0, 0, 2);
				TabContentPadding = new Padding(0);
				TabSpacing = 4;
				PanelSpacing = 0;
				PanelPadding = new Padding(3);
				_panelMargin = new Padding(3, 2, 3, 15);
				PanelMoreSize = new Size(6, 6);
				PanelMoreMargin = new Padding(0, 0, 1, 0);
				ItemMargin = new Padding(2, 2, 0, 2);
				ItemPadding = new Padding(1, 0, 1, 0);
				ItemImageToTextSpacing = 11;
				break;
			}
			UpdateRegions();
			Invalidate();
			if (num)
			{
				this.OrbStyleChanged?.Invoke(this, EventArgs.Empty);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[Category("Appearance")]
	[DefaultValue(RibbonTheme.Normal)]
	public RibbonTheme ThemeColor
	{
		get
		{
			return Theme.RibbonTheme;
		}
		set
		{
			EnsureCustomThemeCreated(OrbStyle, value);
			Theme.RibbonTheme = value;
			OnRegionsChanged();
			Invalidate();
		}
	}

	[DefaultValue(false)]
	[Category("Appearance")]
	[Description("If this value is set, you can still link a Ribbon fixed to the Standard Theme.")]
	public bool UseAlwaysStandardTheme
	{
		get
		{
			return _useAlwaysStandardTheme;
		}
		set
		{
			_useAlwaysStandardTheme = value;
			if (value)
			{
				_theme = null;
			}
		}
	}

	[DefaultValue(null)]
	[Category("Orb")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public string OrbText
	{
		get
		{
			return _orbText;
		}
		set
		{
			_orbText = value;
			RecalculateOrbTextSize();
			OnRegionsChanged();
			Invalidate();
		}
	}

	[DefaultValue(null)]
	[Category("Orb")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public Image OrbImage
	{
		get
		{
			return _orbImage;
		}
		set
		{
			_orbImage = value;
			OnRegionsChanged();
			Invalidate(OrbBounds);
		}
	}

	[DefaultValue(true)]
	[Category("Orb")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public bool OrbVisible
	{
		get
		{
			return _orbVisible;
		}
		set
		{
			_orbVisible = value;
			OnRegionsChanged();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool OrbSelected
	{
		get
		{
			return _orbSelected;
		}
		set
		{
			_orbSelected = value;
			Invalidate(OrbBounds);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool OrbPressed
	{
		get
		{
			return _orbPressed;
		}
		set
		{
			_orbPressed = value;
			Invalidate(OrbBounds);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int CaptionBarSize => CaptionBarHeight;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle OrbBounds
	{
		get
		{
			if (OrbStyle == RibbonOrbStyle.Office_2007)
			{
				if (OrbVisible && RightToLeft == RightToLeft.No && CaptionBarVisible)
				{
					return new Rectangle(4, 4, 36, 36);
				}
				if (OrbVisible && RightToLeft == RightToLeft.Yes && CaptionBarVisible)
				{
					return new Rectangle(base.Width - 36 - 4, 4, 36, 36);
				}
				if (RightToLeft == RightToLeft.No)
				{
					return new Rectangle(4, 4, 0, 0);
				}
				return new Rectangle(base.Width - 4, 4, 0, 0);
			}
			if (OrbStyle == RibbonOrbStyle.Office_2010 || OrbStyle == RibbonOrbStyle.Office_2010_Extended)
			{
				Size orbTextSize = _orbTextSize;
				if (OrbImage != null)
				{
					orbTextSize.Width = Math.Max(orbTextSize.Width, OrbImage.Size.Width);
					orbTextSize.Height = Math.Max(orbTextSize.Height, OrbImage.Size.Height);
				}
				if (OrbVisible && RightToLeft == RightToLeft.No)
				{
					return new Rectangle(1, TabsMargin.Top, orbTextSize.Width + OrbsPadding.Left + OrbsPadding.Right, OrbsPadding.Top + orbTextSize.Height + OrbsPadding.Bottom);
				}
				if (OrbVisible && RightToLeft == RightToLeft.Yes && CaptionBarVisible)
				{
					return new Rectangle(base.Width - orbTextSize.Width - OrbsPadding.Left - OrbsPadding.Right - 1, TabsMargin.Top, orbTextSize.Width + OrbsPadding.Left + OrbsPadding.Right, OrbsPadding.Top + orbTextSize.Height + OrbsPadding.Bottom);
				}
				if (RightToLeft == RightToLeft.No)
				{
					return new Rectangle(4, 4, 0, 0);
				}
				return new Rectangle(base.Width - 4, 4, 0, 0);
			}
			Size orbTextSize2 = _orbTextSize;
			if (OrbImage != null)
			{
				orbTextSize2.Width = Math.Max(orbTextSize2.Width, OrbImage.Size.Width);
				orbTextSize2.Height = Math.Max(orbTextSize2.Height, OrbImage.Size.Height);
			}
			if (OrbVisible && RightToLeft == RightToLeft.No)
			{
				return new Rectangle(0, TabsMargin.Top, orbTextSize2.Width + OrbsPadding.Left + OrbsPadding.Right, OrbsPadding.Top + orbTextSize2.Height + OrbsPadding.Bottom + 1);
			}
			if (OrbVisible && RightToLeft == RightToLeft.Yes && CaptionBarVisible)
			{
				return new Rectangle(base.Width - orbTextSize2.Width - OrbsPadding.Left - OrbsPadding.Right - 4, TabsMargin.Top, orbTextSize2.Width + OrbsPadding.Left + OrbsPadding.Right, OrbsPadding.Top + orbTextSize2.Height + OrbsPadding.Bottom);
			}
			if (RightToLeft == RightToLeft.No)
			{
				return new Rectangle(4, 4, 0, 0);
			}
			return new Rectangle(base.Width - 4, 4, 0, 0);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonTab NextTab
	{
		get
		{
			if (ActiveTab == null || Tabs.Count == 0)
			{
				if (Tabs.Count == 0)
				{
					return null;
				}
				return Tabs[0];
			}
			int num = Tabs.IndexOf(ActiveTab);
			if (num == Tabs.Count - 1)
			{
				return ActiveTab;
			}
			return Tabs[num + 1];
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonTab PreviousTab
	{
		get
		{
			if (ActiveTab == null || Tabs.Count == 0)
			{
				if (Tabs.Count == 0)
				{
					return null;
				}
				return Tabs[0];
			}
			int num = Tabs.IndexOf(ActiveTab);
			if (num == 0)
			{
				return ActiveTab;
			}
			return Tabs[num - 1];
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding TabTextMargin { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding DropDownMargin { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding ItemPadding { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ItemImageToTextSpacing { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding ItemMargin { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonTab ActiveTab
	{
		get
		{
			return _activeTab;
		}
		set
		{
			RibbonTab ribbonTab = _activeTab;
			foreach (RibbonTab tab in Tabs)
			{
				if (tab != value)
				{
					tab.SetActive(active: false);
				}
				else
				{
					ribbonTab = tab;
				}
			}
			ribbonTab.SetActive(active: true);
			_activeTab = value;
			RemoveHelperControls();
			value.UpdatePanelsRegions();
			Invalidate();
			RenewSensor();
			OnActiveTabChanged(EventArgs.Empty);
		}
	}

	[DefaultValue(3)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int PanelSpacing { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Size PanelMoreSize { get; set; } = new Size(7, 7);

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding PanelPadding { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding PanelMargin
	{
		get
		{
			return _panelMargin;
		}
		set
		{
			_panelMargin = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding PanelMoreMargin { get; set; }

	[Browsable(false)]
	[DefaultValue(6)]
	public int TabSpacing { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonTabCollection Tabs { get; }

	[Category("Appearance")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public bool Minimized
	{
		get
		{
			return _minimized;
		}
		set
		{
			_minimized = value;
			if (!IsDesignMode())
			{
				if (_minimized)
				{
					base.Height = MinimizedHeight;
				}
				else
				{
					base.Height = _expandedHeight;
				}
				Expanded = !Minimized;
				UpdateRegions();
				Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonContextCollection Contexts { get; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonRenderer Renderer
	{
		get
		{
			return _renderer;
		}
		set
		{
			_renderer = value ?? throw new ArgumentNullException("Renderer", "Null renderer!");
			Invalidate();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding TabContentMargin { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding TabContentPadding { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding TabsMargin
	{
		get
		{
			return _tabsMargin;
		}
		set
		{
			_tabsMargin = value;
			UpdateRegions();
			Invalidate();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding TabsPadding { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding OrbsPadding { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Size MaximumSize
	{
		get
		{
			return new Size(0, 200);
		}
		set
		{
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Size MinimumSize
	{
		get
		{
			return new Size(0, 27);
		}
		set
		{
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DefaultValue(DockStyle.Top)]
	public override DockStyle Dock
	{
		get
		{
			return base.Dock;
		}
		set
		{
			base.Dock = value;
		}
	}

	[Browsable(false)]
	public RibbonMouseSensor Sensor { get; private set; }

	[DefaultValue(RightToLeft.No)]
	public override RightToLeft RightToLeft
	{
		get
		{
			return base.RightToLeft;
		}
		set
		{
			base.RightToLeft = value;
			OnRegionsChanged();
		}
	}

	[Category("Appearance")]
	[DefaultValue(true)]
	public bool CaptionBarVisible
	{
		get
		{
			return _CaptionBarVisible;
		}
		set
		{
			_CaptionBarVisible = value;
			OrbStyle = OrbStyle;
		}
	}

	private string cr => "Professional Ribbon\n\n2009 Jos?Manuel Menéndez Poo\nwww.menendezpoo.com";

	[DefaultValue(null)]
	[Category("Appearance")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public Font RibbonTabFont
	{
		get
		{
			return _RibbonTabFont;
		}
		set
		{
			_RibbonTabFont = value;
			RecalculateOrbTextSize();
		}
	}

	[Category("Appearance")]
	[Description("Specifies if a Tab is invisible in case it is the only one and the text is set to string.Empty.")]
	[DefaultValue(true)]
	public bool HideSingleTabIfTextEmpty { get; set; } = true;

	public event EventHandler OrbClicked;

	public event EventHandler OrbDoubleClick;

	public event EventHandler ActiveTabChanged;

	public event EventHandler ActualBorderModeChanged;

	public event EventHandler CaptionButtonsVisibleChanged;

	public event EventHandler ExpandedChanged;

	public event EventHandler OrbStyleChanged;

	public Ribbon()
	{
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.UserPaint, value: true);
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
		Dock = DockStyle.Top;
		Tabs = new RibbonTabCollection(this);
		Contexts = new RibbonContextCollection(this);
		OrbsPadding = new Padding(8, 5, 8, 3);
		TabsPadding = new Padding(8, 5, 8, 3);
		_tabsMargin = new Padding(12, 26, 20, 0);
		TabTextMargin = new Padding(4, 2, 4, 2);
		TabContentMargin = new Padding(1, 0, 1, 2);
		PanelPadding = new Padding(3);
		_panelMargin = new Padding(3, 2, 3, 15);
		PanelMoreMargin = new Padding(0, 0, 1, 1);
		PanelSpacing = 3;
		ItemPadding = new Padding(1, 0, 1, 0);
		ItemMargin = new Padding(4, 2, 4, 2);
		ItemImageToTextSpacing = 3;
		TabSpacing = 6;
		DropDownMargin = new Padding(2);
		_renderer = new RibbonProfessionalRenderer(this);
		_orbVisible = true;
		OrbDropDown = new RibbonOrbDropDown(this);
		QuickAccessToolbar = new RibbonQuickAccessToolbar(this);
		MinimizeButton = new RibbonCaptionButton(RibbonCaptionButton.CaptionButton.Minimize);
		MaximizeRestoreButton = new RibbonCaptionButton(RibbonCaptionButton.CaptionButton.Maximize);
		CloseButton = new RibbonCaptionButton(RibbonCaptionButton.CaptionButton.Close);
		LayoutHelper = new LayoutHelper(this);
		MinimizeButton.SetOwner(this);
		MaximizeRestoreButton.SetOwner(this);
		CloseButton.SetOwner(this);
		_CaptionBarVisible = true;
		Font = SystemFonts.CaptionFont;
		BorderMode = RibbonWindowMode.NonClientAreaGlass;
		_minimized = false;
		_expanded = true;
		_enabled = true;
		RibbonPopupManager.PopupRegistered += OnPopupRegistered;
		RibbonPopupManager.PopupUnRegistered += OnPopupUnregistered;
		Control parent = null;
		base.ParentChanged += delegate
		{
			if (parent != null)
			{
				parent.KeyUp -= Ribbon_KeyUp;
				parent.KeyDown -= parent_KeyDown;
			}
			parent = base.Parent;
			Application.AddMessageFilter(this);
			if (parent is Form)
			{
				Form obj = parent as Form;
				obj.KeyPreview = true;
				obj.FormClosing += delegate
				{
					Application.RemoveMessageFilter(this);
				};
			}
			if (parent != null)
			{
				parent.KeyDown += parent_KeyDown;
				parent.KeyUp += Ribbon_KeyUp;
			}
		};
	}

	public bool PreFilterMessage(ref Message m)
	{
		if (m.Msg == 261)
		{
			AltPressed = false;
			Invalidate();
		}
		return false;
	}

	private void parent_KeyDown(object sender, KeyEventArgs e)
	{
		AltPressed = e.Alt;
		Invalidate();
	}

	private bool IsTargetedAltKey(string key, string altKey)
	{
		if (!string.IsNullOrEmpty(key) && string.Equals(key, altKey, StringComparison.InvariantCultureIgnoreCase))
		{
			return true;
		}
		return false;
	}

	private void ParseItem(RibbonItem item)
	{
		if (item is RibbonButton)
		{
			(item as RibbonButton).PerformClick();
		}
		else if (item is RibbonCheckBox)
		{
			(item as RibbonCheckBox).Checked = !(item as RibbonCheckBox).Checked;
		}
		else if (item is RibbonTextBox)
		{
			(item as RibbonTextBox).SetSelected(selected: true);
		}
	}

	public void Ribbon_KeyUp(object sender, KeyEventArgs e)
	{
		string altKey = new KeysConverter().ConvertToString(e.KeyValue);
		if (!e.Alt || e.KeyValue <= 0)
		{
			return;
		}
		if (OrbPressed)
		{
			foreach (RibbonItem menuItem in OrbDropDown.MenuItems)
			{
				if (IsTargetedAltKey(menuItem.AltKey, altKey))
				{
					ParseItem(menuItem);
					return;
				}
			}
		}
		if (ActiveTab != null)
		{
			foreach (RibbonPanel panel in ActiveTab.Panels)
			{
				foreach (RibbonItem item in panel.GetItems())
				{
					if (IsTargetedAltKey(item.AltKey, altKey))
					{
						ParseItem(item);
						return;
					}
				}
			}
		}
		if (IsTargetedAltKey(AltKey, altKey))
		{
			ShowOrbDropDown();
			return;
		}
		foreach (RibbonTab tab in Tabs)
		{
			if (IsTargetedAltKey(tab.AltKey, altKey))
			{
				ActiveTab = tab;
				break;
			}
		}
	}

	protected bool IsOpenInVisualStudioDesigner()
	{
		if (!_isopeninvisualstudiodesigner.HasValue)
		{
			_isopeninvisualstudiodesigner = LicenseManager.UsageMode == LicenseUsageMode.Designtime || base.DesignMode;
			if (!_isopeninvisualstudiodesigner.Value)
			{
				try
				{
					using Process process = Process.GetCurrentProcess();
					_isopeninvisualstudiodesigner = process.ProcessName.ToLowerInvariant().Contains("devenv");
				}
				catch
				{
				}
			}
		}
		return _isopeninvisualstudiodesigner.Value;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && RibbonDesigner.Current == null)
		{
			try
			{
				foreach (RibbonTab tab in Tabs)
				{
					tab.Dispose();
				}
			}
			catch (InvalidOperationException)
			{
				if (!IsOpenInVisualStudioDesigner())
				{
					throw;
				}
			}
			OrbDropDown.Dispose();
			QuickAccessToolbar.Dispose();
			MinimizeButton.Dispose();
			MaximizeRestoreButton.Dispose();
			if (_RibbonItemFont != null)
			{
				_RibbonItemFont.Dispose();
			}
			if (_RibbonTabFont != null)
			{
				_RibbonTabFont.Dispose();
			}
			CloseButton.Dispose();
			RibbonPopupManager.PopupRegistered -= OnPopupRegistered;
			RibbonPopupManager.PopupUnRegistered -= OnPopupUnregistered;
		}
		DisposeHooks();
		base.Dispose(disposing);
	}

	private void DisposeHooks()
	{
		if (_mouseHook != null)
		{
			_mouseHook.MouseWheel -= _mouseHook_MouseWheel;
			_mouseHook.MouseDown -= _mouseHook_MouseDown;
			_mouseHook.Dispose();
			_mouseHook = null;
		}
		if (_keyboardHook != null)
		{
			_keyboardHook.KeyDown -= _keyboardHook_KeyDown;
			_keyboardHook.Dispose();
			_keyboardHook = null;
		}
	}

	public override void Refresh()
	{
		try
		{
			if (!base.IsDisposed)
			{
				if (base.InvokeRequired)
				{
					HandlerCallbackMethode method = Refresh;
					Invoke(method);
				}
				else
				{
					base.Refresh();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void _mouseHook_MouseDown(object sender, MouseEventArgs e)
	{
		bool flag = false;
		if (!RectangleToScreen(OrbBounds).Contains(e.Location))
		{
			flag = RibbonPopupManager.FeedHookClick(e);
		}
		if (RectangleToScreen(base.Bounds).Contains(e.Location))
		{
			flag = true;
		}
		if (Minimized && !flag)
		{
			Expanded = false;
		}
	}

	private void _mouseHook_MouseWheel(object sender, MouseEventArgs e)
	{
		if (!RibbonPopupManager.FeedMouseWheel(e) && RectangleToScreen(new Rectangle(Point.Empty, Size)).Contains(e.Location))
		{
			OnMouseWheel(e);
		}
	}

	internal virtual void OnOrbClicked(EventArgs e)
	{
		if (OrbPressed)
		{
			RibbonPopupManager.Dismiss(RibbonPopupManager.DismissReason.ItemClicked);
		}
		else
		{
			ShowOrbDropDown();
		}
		if (this.OrbClicked != null)
		{
			this.OrbClicked(this, e);
		}
	}

	internal virtual void OnOrbDoubleClicked(EventArgs e)
	{
		if (this.OrbDoubleClick != null)
		{
			this.OrbDoubleClick(this, e);
		}
	}

	private void SetUpHooks()
	{
		if (RibbonDesigner.Current == null)
		{
			if (_mouseHook == null)
			{
				_mouseHook = new GlobalHook(GlobalHook.HookTypes.Mouse);
				_mouseHook.MouseWheel += _mouseHook_MouseWheel;
				_mouseHook.MouseDown += _mouseHook_MouseDown;
			}
			if (_keyboardHook == null)
			{
				_keyboardHook = new GlobalHook(GlobalHook.HookTypes.Keyboard);
				_keyboardHook.KeyDown += _keyboardHook_KeyDown;
			}
		}
	}

	private void _keyboardHook_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			RibbonPopupManager.Dismiss(RibbonPopupManager.DismissReason.EscapePressed);
		}
	}

	public void ShowOrbDropDown()
	{
		OrbPressed = true;
		if (RightToLeft == RightToLeft.No)
		{
			if (OrbStyle == RibbonOrbStyle.Office_2007)
			{
				OrbDropDown.Show(PointToScreen(new Point(OrbBounds.X - 4, OrbBounds.Bottom - OrbDropDown.ContentMargin.Top + 2)));
			}
			else if (OrbStyle == RibbonOrbStyle.Office_2010 || OrbStyle == RibbonOrbStyle.Office_2010_Extended || OrbStyle == RibbonOrbStyle.Office_2013)
			{
				OrbDropDown.Show(PointToScreen(new Point(OrbBounds.X - 4, OrbBounds.Bottom)));
			}
			else if (OrbStyle == RibbonOrbStyle.Office_2007)
			{
				OrbDropDown.Show(PointToScreen(new Point(OrbBounds.Right + 4 - OrbDropDown.Width, OrbBounds.Bottom - OrbDropDown.ContentMargin.Top + 2)));
			}
			else if (OrbStyle == RibbonOrbStyle.Office_2010 || OrbStyle == RibbonOrbStyle.Office_2010_Extended || OrbStyle == RibbonOrbStyle.Office_2013)
			{
				OrbDropDown.Show(PointToScreen(new Point(OrbBounds.Right + 4 - OrbDropDown.Width, OrbBounds.Bottom)));
			}
		}
	}

	public void ShowOrbDropDown(Point pt)
	{
		OrbPressed = true;
		OrbDropDown.Show(PointToScreen(pt));
	}

	private void RenewSensor()
	{
		if (ActiveTab != null)
		{
			if (Sensor != null)
			{
				Sensor.Dispose();
			}
			Sensor = new RibbonMouseSensor(this, this, ActiveTab);
			if (CaptionButtonsVisible)
			{
				Sensor.Items.AddRange(new RibbonItem[3] { CloseButton, MaximizeRestoreButton, MinimizeButton });
			}
		}
	}

	private void SetActualBorderMode(RibbonWindowMode borderMode)
	{
		bool num = ActualBorderMode != borderMode;
		ActualBorderMode = borderMode;
		if (num)
		{
			OnActualBorderModeChanged(EventArgs.Empty);
		}
		SetCaptionButtonsVisible(borderMode == RibbonWindowMode.NonClientAreaCustomDrawn);
	}

	private void SetCaptionButtonsVisible(bool visible)
	{
		bool num = CaptionButtonsVisible != visible;
		CaptionButtonsVisible = visible;
		if (num)
		{
			OnCaptionButtonsVisibleChanged(EventArgs.Empty);
		}
	}

	public void SuspendUpdating()
	{
		_updatingSuspended = true;
	}

	public void ResumeUpdating()
	{
		ResumeUpdating(update: true);
	}

	public void ResumeUpdating(bool update)
	{
		_updatingSuspended = false;
		if (update)
		{
			OnRegionsChanged();
		}
	}

	private void RemoveHelperControls()
	{
		RibbonPopupManager.Dismiss(RibbonPopupManager.DismissReason.AppClicked);
		while (base.Controls.Count > 0)
		{
			Control control = base.Controls[0];
			control.Visible = false;
			base.Controls.Remove(control);
		}
	}

	internal bool TabHitTest(int x, int y)
	{
		foreach (RibbonTab tab in Tabs)
		{
			if (tab.TabBounds.Contains(x, y))
			{
				ActiveTab = tab;
				Expanded = true;
				return true;
			}
		}
		return false;
	}

	internal bool ContextHitTest(int x, int y)
	{
		foreach (RibbonContext context in Contexts)
		{
			if (context.Bounds.Contains(x, y))
			{
				return true;
			}
		}
		return false;
	}

	internal void UpdateRegions()
	{
		UpdateRegions(null);
	}

	internal void UpdateRegions(Graphics g)
	{
		bool flag = false;
		if (base.IsDisposed || _updatingSuspended)
		{
			return;
		}
		if (g == null)
		{
			g = CreateGraphics();
			flag = true;
		}
		UpdateRegionsTabsConsiderRTL(g);
		if (RightToLeft == RightToLeft.No)
		{
			QuickAccessToolbar.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.Compact));
			if (OrbStyle == RibbonOrbStyle.Office_2007)
			{
				QuickAccessToolbar.SetBounds(new Rectangle(new Point(OrbBounds.Right + QuickAccessToolbar.Margin.Left, OrbBounds.Top - 2), QuickAccessToolbar.LastMeasuredSize));
			}
			else if (OrbStyle == RibbonOrbStyle.Office_2010 || OrbStyle == RibbonOrbStyle.Office_2010_Extended)
			{
				QuickAccessToolbar.SetBounds(new Rectangle(new Point(QuickAccessToolbar.Margin.Left, 0), QuickAccessToolbar.LastMeasuredSize));
			}
			else if (OrbStyle == RibbonOrbStyle.Office_2013)
			{
				QuickAccessToolbar.SetBounds(new Rectangle(new Point(QuickAccessToolbar.Margin.Left, 0), QuickAccessToolbar.LastMeasuredSize));
			}
			if (CaptionButtonsVisible)
			{
				Size size = new Size(20, 20);
				int num = 2;
				CloseButton.SetBounds(new Rectangle(new Point(base.ClientRectangle.Right - size.Width - num, num), size));
				MaximizeRestoreButton.SetBounds(new Rectangle(new Point(CloseButton.Bounds.Left - size.Width, num), size));
				MinimizeButton.SetBounds(new Rectangle(new Point(MaximizeRestoreButton.Bounds.Left - size.Width, num), size));
			}
		}
		else
		{
			QuickAccessToolbar.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.Compact));
			if (OrbStyle == RibbonOrbStyle.Office_2007)
			{
				QuickAccessToolbar.SetBounds(new Rectangle(new Point(OrbBounds.Left - QuickAccessToolbar.Margin.Right - QuickAccessToolbar.LastMeasuredSize.Width, OrbBounds.Top - 2), QuickAccessToolbar.LastMeasuredSize));
			}
			else if (OrbStyle == RibbonOrbStyle.Office_2010 || OrbStyle == RibbonOrbStyle.Office_2010_Extended)
			{
				QuickAccessToolbar.SetBounds(new Rectangle(new Point(base.ClientRectangle.Right - QuickAccessToolbar.Margin.Right - QuickAccessToolbar.LastMeasuredSize.Width, 0), QuickAccessToolbar.LastMeasuredSize));
			}
			else if (OrbStyle == RibbonOrbStyle.Office_2013)
			{
				QuickAccessToolbar.SetBounds(new Rectangle(new Point(base.ClientRectangle.Right - QuickAccessToolbar.Margin.Right - QuickAccessToolbar.LastMeasuredSize.Width, 0), QuickAccessToolbar.LastMeasuredSize));
			}
			if (CaptionButtonsVisible)
			{
				Size size2 = new Size(20, 20);
				int num2 = 2;
				CloseButton.SetBounds(new Rectangle(new Point(base.ClientRectangle.Left, num2), size2));
				MaximizeRestoreButton.SetBounds(new Rectangle(new Point(CloseButton.Bounds.Right, num2), size2));
				MinimizeButton.SetBounds(new Rectangle(new Point(MaximizeRestoreButton.Bounds.Right, num2), size2));
			}
		}
		if (flag)
		{
			g.Dispose();
		}
		_lastSizeMeasured = Size;
		RenewSensor();
	}

	private void UpdateRegionsTabsConsiderRTL(Graphics g)
	{
		int num = 0;
		Point point = new Point((RightToLeft == RightToLeft.No) ? (OrbBounds.Width + TabsMargin.Left) : (OrbBounds.Left - TabsMargin.Left + 4), 0);
		int num2 = 0;
		int num3 = 0;
		foreach (RibbonTab tab in Tabs)
		{
			if (tab.Visible || IsDesignMode())
			{
				Size size = tab.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.None));
				if (tab.Contextual && tab.Context.ContextualTabsCount == 1)
				{
					Size size2 = tab.Context.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.None));
					size.Width = Math.Max(size.Width, size2.Width);
				}
				num3 = ((!tab.Invisible || OrbVisible) ? TabsMargin.Top : (TabsMargin.Top - size.Height - 8 + ((OrbStyle == RibbonOrbStyle.Office_2013) ? 2 : 0)));
				Rectangle rectangle = new Rectangle(0, num3, TabsPadding.Left + size.Width + TabsPadding.Right, TabsPadding.Top + size.Height + TabsPadding.Bottom);
				rectangle = LayoutHelper.CalcNewPosition(point, rectangle, LayoutHelper.RTLLayoutPosition.Far, TabSpacing);
				tab.SetTabBounds(rectangle);
				point = LayoutHelper.CalcNewPosition(rectangle, point, LayoutHelper.RTLLayoutPosition.Far, 0);
				num2 = Math.Max(rectangle.Width, num2);
				num = Math.Max(rectangle.Bottom, num);
				tab.SetTabContentBounds(Rectangle.FromLTRB(TabContentMargin.Left, num + TabContentMargin.Top, base.ClientSize.Width - TabContentMargin.Right, base.ClientSize.Height - TabContentMargin.Bottom));
				if (tab.Active)
				{
					tab.UpdatePanelsRegions();
				}
			}
			else
			{
				tab.SetTabBounds(Rectangle.Empty);
				tab.SetTabContentBounds(Rectangle.Empty);
				if (tab.Contextual)
				{
					tab.Context.SetBounds(Rectangle.Empty);
					tab.Context.SetHeaderBounds(Rectangle.Empty);
				}
			}
		}
		foreach (RibbonContext context in Contexts)
		{
			if (context.ContextualTabsCount == 0 && IsDesignMode())
			{
				Size size3 = context.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.None));
				num3 = ((context.Visible || OrbVisible) ? TabsMargin.Top : (TabsMargin.Top - size3.Height - 8 + ((OrbStyle == RibbonOrbStyle.Office_2013) ? 2 : 0)));
				Rectangle rectangle2 = new Rectangle(0, num3 - CaptionBarHeight, TabsPadding.Left + size3.Width + TabsPadding.Right, TabsPadding.Top + size3.Height + TabsPadding.Bottom + CaptionBarHeight);
				Rectangle rect = new Rectangle(rectangle2.Left, rectangle2.Top, rectangle2.Width, CaptionBarHeight);
				rectangle2 = LayoutHelper.CalcNewPosition(point, rectangle2, LayoutHelper.RTLLayoutPosition.Far, TabSpacing);
				rect = LayoutHelper.CalcNewPosition(point, rect, LayoutHelper.RTLLayoutPosition.Far, TabSpacing);
				context.SetBounds(rectangle2);
				context.SetHeaderBounds(rect);
				point = LayoutHelper.CalcNewPosition(rectangle2, point, LayoutHelper.RTLLayoutPosition.Far, 0);
				num2 = Math.Max(rectangle2.Width, num2);
				num = Math.Max(rectangle2.Bottom, num);
			}
		}
		while (((RightToLeft == RightToLeft.No) ? (point.X > base.ClientRectangle.Right) : (point.X < base.ClientRectangle.Left)) && num2 > 0)
		{
			point = new Point((RightToLeft == RightToLeft.No) ? (OrbBounds.Width + TabsMargin.Left) : (OrbBounds.Left - TabsMargin.Left + 4), 0);
			num2--;
			foreach (RibbonTab tab2 in Tabs)
			{
				if (tab2.Visible)
				{
					Size size4 = tab2.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.None));
					if (size4.Width >= num2)
					{
						size4.Width = num2;
					}
					if (tab2.Contextual && tab2.Context.ContextualTabsCount == 1)
					{
						Size size5 = tab2.Context.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.None));
						size4.Width = Math.Max(size4.Width, size5.Width);
					}
					num3 = ((!tab2.Invisible || OrbVisible) ? TabsMargin.Top : (TabsMargin.Top - size4.Height - 8 + ((OrbStyle == RibbonOrbStyle.Office_2013) ? 2 : 0)));
					Rectangle rectangle3 = new Rectangle(0, num3, TabsPadding.Left + size4.Width + TabsPadding.Right, TabsPadding.Top + size4.Height + TabsPadding.Bottom);
					rectangle3 = LayoutHelper.CalcNewPosition(point, rectangle3, LayoutHelper.RTLLayoutPosition.Far, TabSpacing);
					tab2.SetTabBounds(rectangle3);
					point = LayoutHelper.CalcNewPosition(rectangle3, point, LayoutHelper.RTLLayoutPosition.Far, 0);
				}
			}
			foreach (RibbonContext context2 in Contexts)
			{
				if (context2.ContextualTabsCount == 0 && IsDesignMode())
				{
					Size size6 = context2.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.None));
					if (size6.Width >= num2)
					{
						size6.Width = num2;
					}
					num3 = ((context2.Visible || OrbVisible) ? TabsMargin.Top : (TabsMargin.Top - size6.Height - 8 + ((OrbStyle == RibbonOrbStyle.Office_2013) ? 2 : 0)));
					Rectangle rectangle4 = new Rectangle(0, num3 - CaptionBarHeight, TabsPadding.Left + size6.Width + TabsPadding.Right, TabsPadding.Top + size6.Height + TabsPadding.Bottom + CaptionBarHeight);
					Rectangle rect2 = new Rectangle(rectangle4.Left, rectangle4.Top, rectangle4.Width, CaptionBarHeight);
					rectangle4 = LayoutHelper.CalcNewPosition(point, rectangle4, LayoutHelper.RTLLayoutPosition.Far, TabSpacing);
					rect2 = LayoutHelper.CalcNewPosition(point, rect2, LayoutHelper.RTLLayoutPosition.Far, TabSpacing);
					context2.SetBounds(rectangle4);
					context2.SetHeaderBounds(rect2);
					point = LayoutHelper.CalcNewPosition(rectangle4, point, LayoutHelper.RTLLayoutPosition.Far, 0);
				}
			}
		}
		foreach (RibbonContext context3 in Contexts)
		{
			if (context3.ContextualTabsCount <= 0)
			{
				continue;
			}
			foreach (RibbonTab contextualTab in context3.ContextualTabs)
			{
				Rectangle bounds = context3.ContextualTabs[context3.ContextualTabs.Count - 1].Bounds;
				Rectangle bounds2 = context3.ContextualTabs[0].Bounds;
				int num4 = Math.Max(bounds.Right, bounds2.Right);
				int num5 = Math.Min(bounds.Left, bounds2.Left);
				Rectangle bounds3 = new Rectangle(num5, num3 - CaptionBarHeight, num4 - num5, TabsPadding.Top + bounds.Height + TabsPadding.Bottom + CaptionBarHeight);
				Rectangle headerBounds = new Rectangle(bounds3.Left, bounds3.Top, bounds3.Width, CaptionBarHeight);
				contextualTab.Context.SetBounds(bounds3);
				contextualTab.Context.SetHeaderBounds(headerBounds);
			}
		}
	}

	internal void OnRegionsChanged()
	{
		if (!_updatingSuspended)
		{
			if (Tabs.Count == 1 && ActiveTab != Tabs[0])
			{
				ActiveTab = Tabs[0];
			}
			_lastSizeMeasured = Size.Empty;
			Refresh();
		}
	}

	internal void RedrawTab(RibbonTab tab)
	{
		using Graphics graphics = CreateGraphics();
		Rectangle clip = Rectangle.FromLTRB(tab.TabBounds.Left, tab.TabBounds.Top, tab.TabBounds.Right, tab.TabBounds.Bottom);
		graphics.SetClip(clip);
		SmoothingMode smoothingMode = graphics.SmoothingMode;
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
		tab.OnPaint(this, new RibbonElementPaintEventArgs(tab.TabBounds, graphics, RibbonElementSizeMode.None));
		graphics.SmoothingMode = smoothingMode;
		graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
	}

	private void SetSelectedTab(RibbonTab tab)
	{
		if (tab != _lastSelectedTab)
		{
			if (_lastSelectedTab != null)
			{
				_lastSelectedTab.SetSelected(selected: false);
				RedrawTab(_lastSelectedTab);
			}
			if (tab != null)
			{
				tab.SetSelected(selected: true);
				RedrawTab(tab);
			}
			_lastSelectedTab = tab;
		}
	}

	internal void SuspendSensor()
	{
		if (Sensor != null)
		{
			Sensor.Suspend();
		}
	}

	internal void ResumeSensor()
	{
		Sensor.Resume();
	}

	public void RedrawArea(Rectangle area)
	{
		Sensor.Control.Invalidate(area);
	}

	public void ActivateNextTab()
	{
		RibbonTab nextTab = NextTab;
		if (nextTab != null)
		{
			ActiveTab = nextTab;
		}
	}

	public void ActivatePreviousTab()
	{
		RibbonTab previousTab = PreviousTab;
		if (previousTab != null)
		{
			ActiveTab = previousTab;
		}
	}

	internal void OrbMouseDown()
	{
		OnOrbClicked(EventArgs.Empty);
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	protected override void WndProc(ref Message m)
	{
		bool flag = false;
		if (WinApi.IsWindows && (ActualBorderMode == RibbonWindowMode.NonClientAreaGlass || ActualBorderMode == RibbonWindowMode.NonClientAreaCustomDrawn) && m.Msg == 132)
		{
			Form form = FindForm();
			Rectangle r;
			if (RightToLeft == RightToLeft.No)
			{
				int left = (QuickAccessToolbar.Visible ? QuickAccessToolbar.Bounds.Right : OrbBounds.Right);
				if (QuickAccessToolbar.Visible && QuickAccessToolbar.DropDownButtonVisible)
				{
					left = QuickAccessToolbar.DropDownButton.Bounds.Right;
				}
				r = Rectangle.FromLTRB(left, 0, base.Width, CaptionBarSize);
			}
			else
			{
				int right = (QuickAccessToolbar.Visible ? QuickAccessToolbar.Bounds.Left : OrbBounds.Left);
				if (QuickAccessToolbar.Visible && QuickAccessToolbar.DropDownButtonVisible)
				{
					right = QuickAccessToolbar.DropDownButton.Bounds.Left;
				}
				r = Rectangle.FromLTRB(0, 0, right, CaptionBarSize);
			}
			Point point = new Point(WinApi.LoWord((int)m.LParam), WinApi.HiWord((int)m.LParam));
			Point pt = PointToClient(point);
			bool flag2 = false;
			if (CaptionButtonsVisible)
			{
				flag2 = CloseButton.Bounds.Contains(pt) || MinimizeButton.Bounds.Contains(pt) || MaximizeRestoreButton.Bounds.Contains(pt);
			}
			if (RectangleToScreen(r).Contains(point) && !flag2)
			{
				Point point2 = PointToScreen(point);
				WinApi.SendMessage(form.Handle, 132, m.WParam, WinApi.MakeLParam(point2.X, point2.Y));
				m.Result = new IntPtr(-1);
				flag = true;
				CloseButton.SetSelected(selected: false);
				MinimizeButton.SetSelected(selected: false);
				MaximizeRestoreButton.SetSelected(selected: false);
				OrbSelected = false;
				QuickAccessToolbar.DropDownButton.SetSelected(selected: false);
			}
		}
		if (!flag)
		{
			base.WndProc(ref m);
		}
	}

	private void PaintOn(Graphics g, Rectangle clip)
	{
		try
		{
			if (WinApi.IsWindows && Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			}
			Renderer.OnRenderRibbonBackground(new RibbonRenderEventArgs(this, g, clip));
			Renderer.OnRenderRibbonCaptionBar(new RibbonRenderEventArgs(this, g, clip));
			if (CaptionButtonsVisible)
			{
				MinimizeButton.OnPaint(this, new RibbonElementPaintEventArgs(clip, g, RibbonElementSizeMode.Medium));
				MaximizeRestoreButton.OnPaint(this, new RibbonElementPaintEventArgs(clip, g, RibbonElementSizeMode.Medium));
				CloseButton.OnPaint(this, new RibbonElementPaintEventArgs(clip, g, RibbonElementSizeMode.Medium));
			}
			Renderer.OnRenderRibbonOrb(new RibbonRenderEventArgs(this, g, clip));
			QuickAccessToolbar.OnPaint(this, new RibbonElementPaintEventArgs(clip, g, RibbonElementSizeMode.Compact));
			foreach (RibbonContext context in Contexts)
			{
				if (context.Visible || IsDesignMode())
				{
					context.OnPaint(this, new RibbonElementPaintEventArgs(context.Bounds, g, RibbonElementSizeMode.None, this));
				}
			}
			foreach (RibbonTab tab in Tabs)
			{
				if (tab.Visible || IsDesignMode())
				{
					tab.OnPaint(this, new RibbonElementPaintEventArgs(tab.TabBounds, g, RibbonElementSizeMode.None, this));
				}
			}
			if (OrbVisible && !_expanded && !string.IsNullOrEmpty(OrbText))
			{
				if (OrbStyle == RibbonOrbStyle.Office_2010 || OrbStyle == RibbonOrbStyle.Office_2010_Extended)
				{
					Pen pen = new Pen(Theme.RendererColorTable.TabBorder);
					g.DrawLine(pen, OrbBounds.Left, OrbBounds.Bottom, base.Bounds.Right, OrbBounds.Bottom);
				}
				else
				{
					_ = OrbStyle;
					_ = 3;
				}
			}
		}
		catch
		{
		}
	}

	private void PaintDoubleBuffered(Graphics wndGraphics, Rectangle clip)
	{
		using Bitmap image = new Bitmap(base.Width, base.Height);
		using Graphics graphics = Graphics.FromImage(image);
		graphics.Clear(Color.Black);
		PaintOn(graphics, clip);
		graphics.Flush();
		WinApi.BitBlt(wndGraphics.GetHdc(), clip.X, clip.Y, clip.Width, clip.Height, graphics.GetHdc(), clip.X, clip.Y, 13369376u);
	}

	internal bool IsDesignMode()
	{
		if (Site != null)
		{
			return Site.DesignMode;
		}
		return false;
	}

	private void EnsureCustomThemeCreated(RibbonOrbStyle orbStyle, RibbonTheme theme)
	{
		if (_theme == null && !Theme.StandardThemeIsGlobal && !UseAlwaysStandardTheme)
		{
			_theme = new Theme(orbStyle, theme);
		}
	}

	private void RecalculateOrbTextSize()
	{
		if (string.IsNullOrEmpty(OrbText))
		{
			_orbTextSize = Size.Empty;
			return;
		}
		try
		{
			using Graphics graphics = CreateGraphics();
			_orbTextSize = Size.Ceiling(graphics.MeasureString(OrbText, RibbonTabFont));
		}
		catch
		{
		}
	}

	protected virtual void OnActiveTabChanged(EventArgs e)
	{
		if (this.ActiveTabChanged != null)
		{
			this.ActiveTabChanged(this, e);
		}
	}

	protected virtual void OnActualBorderModeChanged(EventArgs e)
	{
		if (this.ActualBorderModeChanged != null)
		{
			this.ActualBorderModeChanged(this, e);
		}
	}

	protected virtual void OnCaptionButtonsVisibleChanged(EventArgs e)
	{
		if (this.CaptionButtonsVisibleChanged != null)
		{
			this.CaptionButtonsVisibleChanged(this, e);
		}
	}

	protected virtual void OnExpandedChanged(EventArgs e)
	{
		if (this.ExpandedChanged != null)
		{
			this.ExpandedChanged(this, e);
		}
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		base.OnMouseDoubleClick(e);
		if (OrbBounds.Contains(e.Location))
		{
			OnOrbDoubleClicked(EventArgs.Empty);
		}
		if (Tabs.Count == 1 && Tabs[0].Invisible)
		{
			return;
		}
		foreach (RibbonTab tab in Tabs)
		{
			if (tab.Bounds.Contains(e.Location))
			{
				Minimized = !Minimized;
				break;
			}
		}
	}

	protected override void OnPaintBackground(PaintEventArgs pevent)
	{
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (!_updatingSuspended)
		{
			if (Size != _lastSizeMeasured)
			{
				UpdateRegions(e.Graphics);
			}
			PaintOn(e.Graphics, e.ClipRectangle);
		}
	}

	protected override void OnClick(EventArgs e)
	{
		base.OnClick(e);
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		SetSelectedTab(null);
		if (!Expanded)
		{
			foreach (RibbonTab tab in Tabs)
			{
				tab.SetSelected(selected: false);
			}
		}
		Invalidate();
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (ActiveTab == null)
		{
			return;
		}
		bool flag = false;
		if (!ActiveTab.TabContentBounds.Contains(e.X, e.Y))
		{
			if (OrbVisible && OrbBounds.Contains(e.Location) && !OrbSelected)
			{
				OrbSelected = true;
				Invalidate(OrbBounds);
			}
			else if (!QuickAccessToolbar.Visible || !QuickAccessToolbar.Bounds.Contains(e.Location))
			{
				foreach (RibbonTab tab in Tabs)
				{
					if (tab.TabBounds.Contains(e.X, e.Y))
					{
						SetSelectedTab(tab);
						flag = true;
						tab.OnMouseMove(e);
					}
				}
			}
		}
		if (!flag)
		{
			SetSelectedTab(null);
		}
		if (OrbSelected && !OrbBounds.Contains(e.Location))
		{
			OrbSelected = false;
			Invalidate(OrbBounds);
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (ActiveTextBox != null)
		{
			(ActiveTextBox as RibbonTextBox).EndEdit();
		}
		base.OnMouseDown(e);
		if (OrbBounds.Contains(e.Location))
		{
			OrbMouseDown();
		}
		else
		{
			TabHitTest(e.X, e.Y);
		}
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		base.OnMouseWheel(e);
	}

	internal void OnRibbonHostMouseMove(MouseEventArgs e)
	{
		OnMouseMove(e);
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		UpdateRegions();
		RemoveHelperControls();
		base.OnSizeChanged(e);
	}

	protected override void OnParentChanged(EventArgs e)
	{
		base.OnParentChanged(e);
		if (Site == null || !Site.DesignMode)
		{
			BorderMode = BorderMode;
			if (base.Parent is IRibbonForm)
			{
				FormHelper.Ribbon = this;
			}
		}
		if (base.Parent != null)
		{
			Control control = base.Parent;
			while (control.Parent != null)
			{
				control = control.Parent;
			}
			if (control is Form form)
			{
				form.Deactivate += parentForm_Deactivate;
			}
		}
	}

	private void parentForm_Deactivate(object sender, EventArgs e)
	{
		if (Form.ActiveForm == null)
		{
			RibbonPopupManager.Dismiss(RibbonPopupManager.DismissReason.AppFocusChanged);
		}
	}

	private void OnPopupRegistered(object sender, EventArgs args)
	{
		if (RibbonPopupManager.PopupCount == 1)
		{
			SetUpHooks();
		}
	}

	private void OnPopupUnregistered(object sender, EventArgs args)
	{
		if (RibbonPopupManager.PopupCount == 0 && (!Minimized || (Minimized && !Expanded)))
		{
			DisposeHooks();
		}
	}

	protected override void OnVisibleChanged(EventArgs e)
	{
		base.OnVisibleChanged(e);
		if (base.Visible)
		{
			UpdateRegions();
			Invalidate();
		}
	}
}
