#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonRibbon), "ToolboxBitmaps.KryptonRibbon.bmp")]
[DefaultEvent("SelectedTabChanged")]
[DefaultProperty("RibbonTabs")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Ribbon control presents a tabbed set of user options.")]
[Docking(DockingBehavior.Never)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonRibbon : VisualSimple, IMessageFilter
{
	public class RibbonButtonSpecAnyCollection : ButtonSpecCollection<ButtonSpecAny>
	{
		public RibbonButtonSpecAnyCollection(KryptonRibbon owner)
			: base((object)owner)
		{
		}
	}

	private static readonly Size _keyTipInflateSize;

	private static MethodInfo _containerSelect;

	private CalculatedValues _calculatedValues;

	private NeedPaintHandler _needPaintGroups;

	private VisualPopupMinimized _minimizedPopup;

	private KryptonContextMenu _kcm;

	private EventHandler _kcmFinishDelegate;

	private IntPtr _keyboardFocusWindow;

	private bool _keyboardFocusCaret;

	private bool _keyboardMode;

	private bool _keyboardKeyTips;

	private bool _designHelpers;

	private bool _invalidateOnResize;

	private bool _uxthemeNotAvailable;

	private bool _lostFocusLosesKeyboard;

	private bool _ignoreRestoreFocus;

	private bool _altDown;

	private int _altUpCount;

	private int _keyboardAltUpCount;

	private ViewBase _focusView;

	private KeyTipControl _keyTipControlE;

	private KeyTipControl _keyTipControlD;

	private KeyTipMode _keyTipMode;

	private Control _keyTipRelative;

	private Button _hiddenFocusTarget;

	private ViewDrawRibbonPanel _drawPanel;

	private ViewDrawPanel _drawMinimizedPanel;

	private ViewLayoutDocker _rootDocker;

	private ViewLayoutDocker _ribbonDocker;

	private ViewDrawRibbonComposition _compositionArea;

	private ViewDrawRibbonCaptionArea _captionArea;

	private ViewLayoutRibbonTabsArea _tabsArea;

	private ViewLayoutRibbonGroupsArea _groupsArea;

	private ViewDrawRibbonQATBorder _qatBelowRibbon;

	private ViewLayoutRibbonQATFromRibbon _qatBelowContents;

	private ViewDrawRibbonMinimizeBar _minimizeBar;

	private RibbonButtonSpecAnyCollection _buttonSpecs;

	private PaletteRibbonStyles _ribbonStyles;

	private PaletteRibbonRedirect _stateCommon;

	private PaletteRibbonDisabled _stateDisabled;

	private PaletteRibbonNormal _stateNormal;

	private PaletteRibbonAppGroupTab _stateTracking;

	private PaletteRibbonAppButton _statePressed;

	private PaletteRibbonGroupAreaTab _stateCheckedNormal;

	private PaletteRibbonJustTab _stateCheckedTracking;

	private PaletteRibbonJustGroup _stateContextNormal;

	private PaletteRibbonGroupTab _stateContextTracking;

	private PaletteRibbonGroupAreaTab _stateContextCheckedNormal;

	private PaletteRibbonJustTab _stateContextCheckedTracking;

	private PaletteRibbonFocus _overrideFocus;

	private PaletteBackInheritRedirect _backPanelInherit;

	private bool _minimizedMode;

	private bool _qatUserChange;

	private bool _allowButtonSpecToolTips;

	private bool _allowFormIntegrate;

	private bool _allowMinimizedChange;

	private bool _showMinimizeButton;

	private string _selectedContext;

	private Size _hideRibbonSize;

	private QATLocation _qatLocation;

	private ButtonStyle _groupButtonStyle;

	private ButtonStyle _groupClusterButtonStyle;

	private ButtonStyle _groupDialogButtonStyle;

	private ButtonStyle _groupCollapsedButtonStyle;

	private ButtonStyle _qatButtonStyle;

	private ButtonStyle _scrollerStyle;

	private PaletteBackStyle _backStyle;

	private PaletteBackStyle _backInactiveStyle;

	private KryptonRibbonTab _minSelectedTab;

	private KryptonRibbonTab _selectedTab;

	private KryptonRibbonTabCollection _ribbonTabs;

	private KryptonRibbonContextCollection _ribbonContexts;

	private KryptonRibbonQATButtonCollection _qatButtons;

	private RibbonShortcuts _ribbonShortcuts;

	private RibbonStrings _ribbonStrings;

	private RibbonAppButton _ribbonAppButton;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override AnchorStyles Anchor
	{
		get
		{
			return base.Anchor;
		}
		set
		{
			base.Anchor = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override bool AutoSize
	{
		get
		{
			return base.AutoSize;
		}
		set
		{
			if (value)
			{
				base.AutoSize = value;
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override AutoSizeMode AutoSizeMode
	{
		get
		{
			return base.AutoSizeMode;
		}
		set
		{
			if (value == AutoSizeMode.GrowAndShrink)
			{
				base.AutoSizeMode = value;
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return base.ContextMenuStrip;
		}
		set
		{
			base.ContextMenuStrip = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override DockStyle Dock
	{
		get
		{
			return base.Dock;
		}
		set
		{
			if (value == DockStyle.Top)
			{
				base.Dock = value;
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Point Location
	{
		get
		{
			return base.Location;
		}
		set
		{
			base.Location = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Padding Margin
	{
		get
		{
			return base.Margin;
		}
		set
		{
			base.Margin = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Size MaximumSize
	{
		get
		{
			return base.MaximumSize;
		}
		set
		{
			base.MaximumSize = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Size MinimumSize
	{
		get
		{
			return base.MinimumSize;
		}
		set
		{
			base.MinimumSize = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	[Category("Visuals")]
	[Description("Is ribbon is allowed to override form chrome by integrating instead with operating system chrome.")]
	[DefaultValue(true)]
	public bool AllowFormIntegrate
	{
		get
		{
			return _allowFormIntegrate;
		}
		set
		{
			if (_allowFormIntegrate != value)
			{
				_allowFormIntegrate = value;
				CaptionArea.PerformFormChromeCheck();
			}
		}
	}

	[Category("Visuals")]
	[Description("Determines if the user is allowed to change the minimized mode.")]
	[DefaultValue(true)]
	public bool AllowMinimizedChange
	{
		get
		{
			return _allowMinimizedChange;
		}
		set
		{
			_allowMinimizedChange = value;
		}
	}

	[Category("Visuals")]
	[Description("Should tooltips be displayed for button specs.")]
	[DefaultValue(false)]
	public bool AllowButtonSpecToolTips
	{
		get
		{
			return _allowButtonSpecToolTips;
		}
		set
		{
			_allowButtonSpecToolTips = value;
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining common ribbon appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled ribbon appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonDisabled StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal ribbon appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonNormal StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining tracking ribbon appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonAppGroupTab StateTracking => _stateTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed ribbon appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonAppButton StatePressed => _statePressed;

	[Category("Visuals")]
	[Description("Overrides for defining checked normal ribbon appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonGroupAreaTab StateCheckedNormal => _stateCheckedNormal;

	[Category("Visuals")]
	[Description("Overrides for defining checked tracking ribbon appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonJustTab StateCheckedTracking => _stateCheckedTracking;

	[Category("Visuals")]
	[Description("Overrides for defining context normal ribbon appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonJustGroup StateContextNormal => _stateContextNormal;

	[Category("Visuals")]
	[Description("Overrides for defining context tracking ribbon appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonGroupTab StateContextTracking => _stateContextTracking;

	[Category("Visuals")]
	[Description("Overrides for defining checked context normal ribbon appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonGroupAreaTab StateContextCheckedNormal => _stateContextCheckedNormal;

	[Category("Visuals")]
	[Description("Overrides for defining checked context tracking ribbon appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonJustTab StateContextCheckedTracking => _stateContextCheckedTracking;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonFocus OverrideFocus => _overrideFocus;

	[Category("Values")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonButtonSpecAnyCollection ButtonSpecs => _buttonSpecs;

	[Category("Values")]
	[Description("Collection of ribbon tabs.")]
	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonRibbonTabCollection RibbonTabs => _ribbonTabs;

	[Category("Values")]
	[Description("Currently selected ribbon tab.")]
	public KryptonRibbonTab SelectedTab
	{
		get
		{
			return _selectedTab;
		}
		set
		{
			if (value == null || (!value.Visible && !InDesignHelperMode) || !RibbonTabs.Contains(value) || !TabIsContextValid(value) || _selectedTab == value)
			{
				return;
			}
			if (!base.IsInitializing || !RealMinimizedMode)
			{
				_selectedTab = value;
				OnSelectedTabChanged(EventArgs.Empty);
				PerformNeedPaint(needLayout: true);
			}
			if (!base.IsInitializing && RealMinimizedMode && _selectedTab != null)
			{
				_minSelectedTab = value;
				if (_minimizedPopup == null)
				{
					ShowMinimizedPopup();
				}
				else
				{
					UpdateMinimizedPopup();
				}
			}
		}
	}

	[Category("Values")]
	[Description("Common separated list of selected context names.")]
	[DefaultValue("")]
	public string SelectedContext
	{
		get
		{
			return _selectedContext;
		}
		set
		{
			if (value == null)
			{
				value = string.Empty;
			}
			if (_selectedContext != value)
			{
				_selectedContext = value;
				PerformNeedPaint(needLayout: true);
				OnSelectedContextChanged(EventArgs.Empty);
				ValidateSelectedTab();
			}
		}
	}

	[Category("Values")]
	[Description("Collection of ribbon context definitions.")]
	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonRibbonContextCollection RibbonContexts => _ribbonContexts;

	[Category("Values")]
	[Description("Collection of ribbon quick access toolbar buttons.")]
	[MergableProperty(false)]
	[Editor("ComponentFactory.Krypton.Ribbon.KryptonRibbonQATButtonCollectionEditor, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonRibbonQATButtonCollection QATButtons => _qatButtons;

	[Category("Values")]
	[Description("Collection of ribbon shortcuts.")]
	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonShortcuts RibbonShortcuts => _ribbonShortcuts;

	[Category("Values")]
	[Description("Collection of ribbon strings.")]
	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Localizable(true)]
	public RibbonStrings RibbonStrings => _ribbonStrings;

	[Category("Values")]
	[Description("Collection of ribbon app button settings.")]
	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Localizable(true)]
	public RibbonAppButton RibbonAppButton => _ribbonAppButton;

	[Category("Visuals")]
	[Description("Styles for various ribbon elements.")]
	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonStyles RibbonStyles => _ribbonStyles;

	[Category("Values")]
	[Description("Vertical and horizontal minimum sizes at which the ribbon hides itself.")]
	[DefaultValue(typeof(Size), "300,250")]
	public Size HideRibbonSize
	{
		get
		{
			return _hideRibbonSize;
		}
		set
		{
			if (_hideRibbonSize != value)
			{
				_hideRibbonSize = value;
				_tabsArea.CheckRibbonSize();
			}
		}
	}

	[Localizable(true)]
	[Category("Values")]
	[Description("Is the ribbon in minimized mode.")]
	[DefaultValue(false)]
	public bool MinimizedMode
	{
		get
		{
			return _minimizedMode;
		}
		set
		{
			if (_minimizedMode == value)
			{
				return;
			}
			_minimizedMode = value;
			_minimizeBar.Visible = RealMinimizedMode && QATLocation != QATLocation.Below;
			if (RealMinimizedMode)
			{
				_ribbonDocker.Remove(_groupsArea);
				if (!_drawMinimizedPanel.Contains(_groupsArea))
				{
					_drawMinimizedPanel.Add(_groupsArea);
				}
				foreach (Control control in Controls)
				{
					control.SetBounds(-control.Width, -control.Height, control.Width, control.Height);
				}
				_minSelectedTab = _selectedTab;
				ValidateSelectedTab();
				_tabsArea.RecreateButtons();
				PerformNeedPaint(needLayout: true);
			}
			else
			{
				using (new ScreenObscurer(_minimizedPopup, base.DesignMode))
				{
					KillMinimizedPopup();
					_drawMinimizedPanel.Remove(_groupsArea);
					if (!_ribbonDocker.Contains(_groupsArea))
					{
						_ribbonDocker.Insert(0, _groupsArea);
						_ribbonDocker.SetDock(_groupsArea, ViewDockStyle.Fill);
					}
					if (_minSelectedTab != null)
					{
						if (_minSelectedTab.Visible && RibbonTabs.Contains(_minSelectedTab) && TabIsContextValid(_minSelectedTab))
						{
							SelectedTab = _minSelectedTab;
						}
						_minSelectedTab = null;
					}
					ValidateSelectedTab();
					_tabsArea.RecreateButtons();
					PerformNeedPaint(needLayout: true);
					Application.DoEvents();
				}
			}
			OnMinimizedModeChanged(EventArgs.Empty);
		}
	}

	[Localizable(true)]
	[Category("Values")]
	[Description("Determines how the quick access toolbar is displayed.")]
	[DefaultValue(typeof(QATLocation), "Above")]
	public QATLocation QATLocation
	{
		get
		{
			return _qatLocation;
		}
		set
		{
			if (_qatLocation != value)
			{
				_qatLocation = value;
				using (new ScreenObscurer(this, base.DesignMode))
				{
					_minimizeBar.Visible = RealMinimizedMode && QATLocation != QATLocation.Below;
					_qatBelowRibbon.Visible = _qatLocation == QATLocation.Below;
					_captionArea.UpdateQAT();
					PerformLayout();
					Refresh();
				}
			}
		}
	}

	[Category("Values")]
	[Description("Is the user allowed to change the quick access toolbar entries.")]
	[DefaultValue(true)]
	public bool QATUserChange
	{
		get
		{
			return _qatUserChange;
		}
		set
		{
			_qatUserChange = value;
		}
	}

	[Category("Values")]
	[Description("Does a minimize/expand button appear on the ribbon tab ara.")]
	[DefaultValue(true)]
	public bool ShowMinimizeButton
	{
		get
		{
			return _showMinimizeButton;
		}
		set
		{
			if (_showMinimizeButton != value)
			{
				_showMinimizeButton = value;
				_tabsArea.RecreateButtons();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ToolTipManager ToolTipManager => _tabsArea.ToolTipManager;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ControlCollection Controls => base.Controls;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool InDesignMode => base.DesignMode;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool InDesignHelperMode
	{
		get
		{
			return InDesignMode && _designHelpers;
		}
		set
		{
			_designHelpers = value;
			ValidateSelectedTab();
			PerformNeedPaint(needLayout: true);
		}
	}

	[Browsable(false)]
	public bool KeyboardMode => _keyboardMode;

	internal bool RealMinimizedMode => MinimizedMode && !InDesignMode;

	internal ViewRibbonManager ViewRibbonManager => base.ViewManager as ViewRibbonManager;

	internal ViewDrawRibbonPanel MainPanel => _drawPanel;

	internal ViewLayoutRibbonTabsArea TabsArea => _tabsArea;

	internal ViewLayoutRibbonGroupsArea GroupsArea => _groupsArea;

	internal ViewDrawRibbonCaptionArea CaptionArea => _captionArea;

	internal CalculatedValues CalculatedValues => _calculatedValues;

	internal PaletteBackStyle BackStyle
	{
		get
		{
			return _backStyle;
		}
		set
		{
			_backStyle = value;
			UpdateBackStyle();
		}
	}

	internal PaletteBackStyle BackInactiveStyle
	{
		get
		{
			return _backInactiveStyle;
		}
		set
		{
			_backInactiveStyle = value;
			UpdateBackStyle();
		}
	}

	internal ButtonStyle ScrollerStyle
	{
		get
		{
			return _scrollerStyle;
		}
		set
		{
			if (_scrollerStyle != value)
			{
				_scrollerStyle = value;
				StateCommon.RibbonScroller.SetStyles(value);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	internal ButtonStyle GroupButtonStyle
	{
		get
		{
			return _groupButtonStyle;
		}
		set
		{
			if (_groupButtonStyle != value)
			{
				_groupButtonStyle = value;
				StateCommon.RibbonGroupButton.SetStyles(value);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	internal ButtonStyle GroupClusterButtonStyle
	{
		get
		{
			return _groupClusterButtonStyle;
		}
		set
		{
			if (_groupClusterButtonStyle != value)
			{
				_groupClusterButtonStyle = value;
				StateCommon.RibbonGroupClusterButton.SetStyles(value);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	internal ButtonStyle GroupCollapsedButtonStyle
	{
		get
		{
			return _groupCollapsedButtonStyle;
		}
		set
		{
			if (_groupCollapsedButtonStyle != value)
			{
				_groupCollapsedButtonStyle = value;
				StateCommon.RibbonGroupCollapsedButton.SetStyles(value);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	internal ButtonStyle GroupDialogButtonStyle
	{
		get
		{
			return _groupDialogButtonStyle;
		}
		set
		{
			if (_groupDialogButtonStyle != value)
			{
				_groupDialogButtonStyle = value;
				StateCommon.RibbonGroupDialogButton.SetStyles(value);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	internal Rectangle ClientRectangleWithoutComposition
	{
		get
		{
			Rectangle clientRectangle = base.ClientRectangle;
			if (_compositionArea.Visible)
			{
				clientRectangle.Y += _compositionArea.ClientHeight;
				clientRectangle.Height -= _compositionArea.ClientHeight;
			}
			return clientRectangle;
		}
	}

	internal ButtonStyle QATButtonStyle
	{
		get
		{
			return _qatButtonStyle;
		}
		set
		{
			if (_qatButtonStyle != value)
			{
				_qatButtonStyle = value;
				StateCommon.RibbonQATButton.SetStyles(value);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	internal bool InKeyboardMode => _keyboardMode;

	internal bool InKeyTipsMode => _keyboardKeyTips;

	internal KeyTipMode KeyTipMode
	{
		get
		{
			return _keyTipMode;
		}
		set
		{
			_keyTipMode = value;
			switch (_keyTipMode)
			{
			case KeyTipMode.PopupGroup:
				_keyTipRelative = VisualPopupManager.Singleton.TrackingByType(typeof(VisualPopupGroup));
				break;
			case KeyTipMode.PopupMinimized:
				_keyTipRelative = VisualPopupManager.Singleton.TrackingByType(typeof(VisualPopupMinimized));
				break;
			case KeyTipMode.PopupQATOverflow:
				_keyTipRelative = VisualPopupManager.Singleton.TrackingByType(typeof(VisualPopupQATOverflow));
				break;
			default:
				_keyTipRelative = this;
				break;
			}
		}
	}

	internal Rectangle ToolTipScreenRectangle
	{
		get
		{
			if (VisualPopupManager.Singleton.CurrentPopup != null)
			{
				Control currentPopup = VisualPopupManager.Singleton.CurrentPopup;
				if (currentPopup is VisualPopupGroup || currentPopup is VisualPopupMinimized)
				{
					return currentPopup.RectangleToScreen(currentPopup.ClientRectangle);
				}
				VisualPopup[] stackedPopups = VisualPopupManager.Singleton.StackedPopups;
				foreach (VisualPopup visualPopup in stackedPopups)
				{
					if (visualPopup is VisualPopupGroup || visualPopup is VisualPopupMinimized)
					{
						return visualPopup.RectangleToScreen(visualPopup.ClientRectangle);
					}
				}
			}
			return RectangleToScreen(base.ClientRectangle);
		}
	}

	internal ViewBase FocusView
	{
		get
		{
			return _focusView;
		}
		set
		{
			if (_focusView != value)
			{
				if (_focusView != null)
				{
					_focusView.LostFocus(this);
				}
				_focusView = value;
				if (_focusView != null)
				{
					_focusView.GotFocus(this);
				}
			}
		}
	}

	internal bool LostFocusLosesKeyboard
	{
		get
		{
			return _lostFocusLosesKeyboard;
		}
		set
		{
			_lostFocusLosesKeyboard = value;
		}
	}

	internal bool IgnoreRestoreFocus
	{
		get
		{
			return _ignoreRestoreFocus;
		}
		set
		{
			_ignoreRestoreFocus = value;
		}
	}

	internal PaletteRibbonShape RibbonShape => StateCommon.RibbonGeneral.GetRibbonShape();

	private bool IsAppThemed
	{
		get
		{
			if (_uxthemeNotAvailable)
			{
				return false;
			}
			try
			{
				return PI.IsAppThemed() && PI.IsThemeActive();
			}
			catch
			{
				_uxthemeNotAvailable = true;
				return false;
			}
		}
	}

	[Category("Ribbon")]
	[Description("Occurs when the selected tab changes.")]
	public event EventHandler SelectedTabChanged;

	[Category("Ribbon")]
	[Description("Occurs when the selected context changes.")]
	public event EventHandler SelectedContextChanged;

	[Category("Ribbon")]
	[Description("Occurs when application button menu is opening but not displayed as yet.")]
	public event CancelEventHandler AppButtonMenuOpening;

	[Category("Ribbon")]
	[Description("Occurs when the application button menu is fully opened for display.")]
	public event EventHandler AppButtonMenuOpened;

	[Category("Ribbon")]
	[Description("Occurs when the application button menu is about to close.")]
	public event CancelEventHandler AppButtonMenuClosing;

	[Category("Ribbon")]
	[Description("Occurs when the application button menu has been closed.")]
	public event ToolStripDropDownClosedEventHandler AppButtonMenuClosed;

	[Category("Ribbon")]
	[Description("Occurs when the ribbon context menu is about to be shown.")]
	public event EventHandler<ContextMenuArgs> ShowRibbonContextMenu;

	[Category("Ribbon")]
	[Description("Occurs when the quick access toolbar customize menu is about to be shown.")]
	public event EventHandler<ContextMenuArgs> ShowQATCustomizeMenu;

	[Category("Property Changed")]
	[Description("Occurs when the MinimizedMode property has changed value.")]
	public event EventHandler MinimizedModeChanged;

	[Category("Design Time Only")]
	[Description("Occurs add design time when the user requests a tab be added.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler DesignTimeAddTab;

	static KryptonRibbon()
	{
		_keyTipInflateSize = new Size(8, 30);
		_containerSelect = typeof(ContainerControl).GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic);
	}

	public KryptonRibbon()
	{
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.ResizeRedraw, value: false);
		CreateRibbonCollections();
		CreateButtonSpecs();
		CreateStorageObjects();
		CreateViewManager();
		CreateInternal();
		AssignDefaultFields();
		Application.AddMessageFilter(this);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Application.RemoveMessageFilter(this);
			SuspendLayout();
			_captionArea.Dispose();
			_tabsArea.Dispose();
			if (_kcm != null)
			{
				_kcm.Close();
				_kcm.Dispose();
				_kcm = null;
			}
			foreach (KryptonRibbonTab ribbonTab in RibbonTabs)
			{
				ribbonTab.Dispose();
			}
			ResumeLayout();
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeStateTracking()
	{
		return !_stateTracking.IsDefault;
	}

	private bool ShouldSerializeStatePressed()
	{
		return !_statePressed.IsDefault;
	}

	private bool ShouldSerializeStateCheckedNormal()
	{
		return !_stateCheckedNormal.IsDefault;
	}

	private bool ShouldSerializeStateCheckedTracking()
	{
		return !_stateCheckedTracking.IsDefault;
	}

	private bool ShouldSerializeStateContextNormal()
	{
		return !_stateContextNormal.IsDefault;
	}

	private bool ShouldSerializeStateContextTracking()
	{
		return !_stateContextTracking.IsDefault;
	}

	private bool ShouldSerializeStateContextCheckedNormal()
	{
		return !_stateContextCheckedNormal.IsDefault;
	}

	private bool ShouldSerializeStateContextCheckedTracking()
	{
		return !_stateContextCheckedTracking.IsDefault;
	}

	private bool ShouldSerializeOverrideFocus()
	{
		return !_overrideFocus.IsDefault;
	}

	public void ResetSelectedTab()
	{
		ValidateSelectedTab();
	}

	private bool ShouldSerializeSelectedContext()
	{
		return !string.IsNullOrEmpty(_selectedContext);
	}

	private void ResetSelectedContext()
	{
		SelectedContext = string.Empty;
	}

	private bool ShouldSerializeRibbonStyles()
	{
		return !_ribbonStyles.IsDefault;
	}

	private void ResetHideRibbonSize()
	{
		HideRibbonSize = new Size(300, 250);
	}

	public void ResetMinimizedMode()
	{
		MinimizedMode = false;
	}

	public void ResetQATLocation()
	{
		QATLocation = QATLocation.Above;
	}

	public void ResetQATUserChange()
	{
		QATUserChange = true;
	}

	public void ResetShowMinimizeButton()
	{
		ShowMinimizeButton = true;
	}

	public void ToggleKeyboardMode()
	{
		_keyboardMode = !_keyboardMode;
		if (_keyboardMode)
		{
			_keyboardAltUpCount = _altUpCount;
			_keyboardFocusWindow = PI.GetFocus();
			if (_keyboardFocusWindow != IntPtr.Zero)
			{
				_keyboardFocusCaret = PI.HideCaret(_keyboardFocusWindow);
			}
			PI.SetFocus(base.Handle);
			_keyboardKeyTips = true;
			SetKeyTips(GenerateKeyTipsAtTopLevel(), KeyTipMode.Root);
			return;
		}
		KillKeyboardKeyTips();
		if (!IgnoreRestoreFocus && _keyboardFocusWindow != IntPtr.Zero)
		{
			PI.SetFocus(_keyboardFocusWindow);
			if (_keyboardFocusCaret)
			{
				PI.ShowCaret(_keyboardFocusWindow);
			}
		}
		FocusView = null;
		IgnoreRestoreFocus = false;
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	public bool PreFilterMessage(ref Message m)
	{
		if (!base.IsDisposed && !base.DesignMode)
		{
			switch (m.Msg)
			{
			case 161:
			case 164:
			case 167:
			case 513:
			case 516:
			case 519:
				KillKeyboardMode();
				break;
			case 261:
				CheckForAltUp();
				break;
			case 256:
			case 260:
			{
				if (!base.Visible || !base.Enabled)
				{
					break;
				}
				Form form2 = FindForm();
				if (form2 != null && form2.Visible && form2.Enabled && form2.ContainsFocus)
				{
					Keys keys = (Keys)m.WParam.ToInt64();
					if (keys == Keys.F4 && (Control.ModifierKeys & Keys.Alt) == Keys.Alt)
					{
						form2.Close();
						return true;
					}
					return ProcessCmdKey(ref m, keys | Control.ModifierKeys);
				}
				break;
			}
			case 522:
			{
				if (!base.Visible || !base.Enabled || RealMinimizedMode || _keyboardMode || InDesignMode)
				{
					break;
				}
				Form form = FindForm();
				if (form != null && form.Visible && form.Enabled && form.ContainsFocus)
				{
					Point p = new Point
					{
						X = PI.LOWORD((int)m.LParam),
						Y = PI.HIWORD((int)m.LParam)
					};
					if (base.ClientRectangle.Contains(PointToClient(p)))
					{
						short num = (short)PI.HIWORD((int)m.WParam.ToInt64());
						_tabsArea.LayoutTabs.ProcessMouseWheel(num < 0);
						return true;
					}
				}
				break;
			}
			}
		}
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool DesignerGetHitTest(Point pt)
	{
		if (base.IsDisposed)
		{
			return false;
		}
		ViewBase viewBase = base.ViewManager.Root.ViewFromPoint(pt);
		return (viewBase != null && viewBase.Parent != null && (viewBase is ViewDrawRibbonScrollButton || viewBase is ViewDrawRibbonDesignBase || viewBase.Parent is ViewDrawRibbonDesignBase)) || DesignerComponentFromPoint(pt) != null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public void DesignerMouseLeave()
	{
		OnMouseLeave(EventArgs.Empty);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public Point ViewRectangleToPoint(ViewBase view)
	{
		Rectangle rectangle = view.OwningControl.RectangleToScreen(view.ClientRectangle);
		return new Point(rectangle.Left, rectangle.Bottom);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public Component DesignerComponentFromPoint(Point pt)
	{
		if (base.IsDisposed)
		{
			return null;
		}
		ViewBase viewBase = base.ViewManager.Root.ViewFromPoint(pt);
		if (viewBase is ViewDrawRibbonGroupDateTimePicker)
		{
			return ((ViewDrawRibbonGroupDateTimePicker)viewBase).Component;
		}
		return base.ViewManager.ComponentFromPoint(pt);
	}

	protected override void OnInitialized(EventArgs e)
	{
		if (SelectedTab == null)
		{
			ResetSelectedTab();
		}
		base.OnInitialized(e);
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		PerformNeedPaint(needLayout: true);
	}

	protected override ControlCollection CreateControlsInstance()
	{
		return new KryptonReadOnlyControls(this);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		if (!base.IsDisposed && !base.Disposing)
		{
			if (TabsArea != null)
			{
				TabsArea.AppButtonVisibleChanged();
			}
			if (CaptionArea != null)
			{
				CaptionArea.AppButtonVisibleChanged();
			}
		}
		if (_captionArea.KryptonForm != null)
		{
			_captionArea.KryptonForm.RecalculateComposition();
		}
		base.OnLayout(levent);
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 132)
		{
			Point p = new Point((int)m.LParam.ToInt64());
			Point pt = PointToClient(p);
			if (_compositionArea.Visible && _compositionArea.ClientRectangle.Contains(pt))
			{
				m.Result = (IntPtr)(-1);
				return;
			}
			if (_tabsArea != null && _tabsArea.LayoutTabs != null && _tabsArea.LayoutTabs.GetViewForSpare != null)
			{
				Rectangle clientRectangle = _tabsArea.LayoutTabs.GetViewForSpare.ClientRectangle;
				clientRectangle.Offset(_tabsArea.TabsContainerControl.ChildControl.Location);
				if (clientRectangle.Contains(pt))
				{
					m.Result = (IntPtr)(-1);
					return;
				}
			}
		}
		base.WndProc(ref m);
	}

	protected override bool ProcessDialogKey(Keys keyData)
	{
		if (_focusView != null)
		{
			switch (keyData)
			{
			case Keys.Tab:
			case Keys.Return:
			case Keys.Space:
			case Keys.Left:
			case Keys.Up:
			case Keys.Right:
			case Keys.Down:
			case Keys.Tab | Keys.Shift:
				KillKeyboardKeyTips();
				_focusView.KeyDown(new KeyEventArgs(keyData));
				return true;
			}
		}
		else if ((keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Shift)) && base.ContainsFocus)
		{
			SelectNonRibbonControl(keyData == Keys.Tab);
			return true;
		}
		return base.ProcessDialogKey(keyData);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		CheckForAltUp();
		CheckForAltDown();
		if (keyData == Keys.Escape && VisualPopupManager.Singleton.IsShowingCMS)
		{
			return false;
		}
		if (_keyboardMode && keyData == Keys.Escape)
		{
			if (VisualPopupManager.Singleton.IsTracking)
			{
				return false;
			}
			if (_keyboardKeyTips && KeyTipMode != KeyTipMode.Root)
			{
				SetKeyTips(GenerateKeyTipsAtTopLevel(), KeyTipMode.Root);
			}
			else
			{
				ToggleKeyboardMode();
			}
			return true;
		}
		if ((RibbonShortcuts.ToggleKeyboardAccess1 == keyData || RibbonShortcuts.ToggleKeyboardAccess2 == keyData) && !VisualPopupManager.Singleton.IsTracking)
		{
			if (InKeyboardMode)
			{
				if (_keyboardAltUpCount != _altUpCount)
				{
					ToggleKeyboardMode();
				}
			}
			else
			{
				ToggleKeyboardMode();
			}
			return true;
		}
		if (RibbonShortcuts.ToggleMinimizeMode == keyData && AllowMinimizedChange)
		{
			MinimizedMode = !MinimizedMode;
			return true;
		}
		if (RibbonAppButton.AppButtonMenuItems.ProcessShortcut(keyData))
		{
			ActionOccured();
			return true;
		}
		Keys keys = keyData & ~Keys.Alt;
		foreach (KryptonRibbonTab ribbonTab in RibbonTabs)
		{
			if (ribbonTab.Visible && ribbonTab.ProcessCmdKey(ref msg, keys))
			{
				return true;
			}
		}
		foreach (IQuickAccessToolbarButton qATButton in QATButtons)
		{
			if (qATButton.GetVisible() && qATButton.GetEnabled())
			{
				Keys shortcutKeys = qATButton.GetShortcutKeys();
				if (shortcutKeys != Keys.None && shortcutKeys == keyData)
				{
					qATButton.PerformClick();
					return true;
				}
			}
		}
		if (InKeyboardMode && InKeyTipsMode)
		{
			char c = (char)keys;
			if (char.IsLetterOrDigit(c))
			{
				_keyTipControlE.AppendKeyPress(c);
				return true;
			}
		}
		return base.ProcessCmdKey(ref msg, keyData);
	}

	protected override void OnButtonSpecChanged(object sender, EventArgs e)
	{
		_tabsArea.RecreateButtons();
		base.OnButtonSpecChanged(sender, e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (!base.IsDisposed && base.ViewManager != null)
		{
			base.ViewManager.MouseDown(e, new Point(e.X, e.Y));
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		if (!base.IsDisposed && base.ViewManager != null)
		{
			base.ViewManager.MouseUp(e, new Point(e.X, e.Y));
		}
	}

	protected override void OnGotFocus(EventArgs e)
	{
		ViewBase viewBase = null;
		if (SelectedTab != null)
		{
			viewBase = _tabsArea.LayoutTabs.GetViewForRibbonTab(SelectedTab);
		}
		else if (!RealMinimizedMode)
		{
			viewBase = _tabsArea.LayoutTabs.GetViewForFirstRibbonTab();
		}
		if (viewBase == null)
		{
			if (TabsArea.LayoutAppButton.Visible)
			{
				viewBase = TabsArea.LayoutAppButton.AppButton;
			}
			else if (TabsArea.LayoutAppTab.Visible)
			{
				viewBase = TabsArea.LayoutAppTab.AppTab;
			}
		}
		FocusView = viewBase;
		PerformNeedPaint(needLayout: true);
		Refresh();
	}

	protected override void OnLostFocus(EventArgs e)
	{
		if (LostFocusLosesKeyboard)
		{
			FocusView = null;
			KillKeyboardMode();
			VisualPopupManager.Singleton.EndAllTracking();
		}
		else
		{
			LostFocusLosesKeyboard = true;
		}
		PerformNeedPaint(needLayout: true);
		Refresh();
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		if (_keyboardMode && _keyboardKeyTips)
		{
			_keyTipControlE.AppendKeyPress(char.ToUpper(e.KeyChar));
		}
		else
		{
			base.OnKeyPress(e);
		}
	}

	protected override void OnResize(EventArgs e)
	{
		if (_invalidateOnResize || !IsAppThemed)
		{
			Invalidate();
		}
		base.OnResize(e);
	}

	protected override void OnPaintBackground(PaintEventArgs pevent)
	{
		if (_compositionArea.Visible)
		{
			AccurateText.DrawCompositionGlowingText(pevent.Graphics, string.Empty, Font, base.ClientRectangle, PaletteState.Normal, Color.Transparent, copyBackground: false);
			pevent.Graphics.SetClip(new Rectangle(_compositionArea.ClientLocation, new Size(_compositionArea.ClientWidth, _compositionArea.CompHeight)), CombineMode.Exclude);
		}
		base.OnPaintBackground(pevent);
	}

	protected override void PaintBackground(Graphics g, Brush backBrush, Rectangle backRect)
	{
		if (_compositionArea.Visible)
		{
			Region clip = g.Clip.Clone();
			g.SetClip(new Rectangle(_compositionArea.ClientLocation, new Size(_compositionArea.ClientWidth, _compositionArea.CompHeight)), CombineMode.Exclude);
			g.FillRectangle(backBrush, backRect);
			g.Clip.Dispose();
			g.Clip = clip;
		}
		else
		{
			g.FillRectangle(backBrush, backRect);
		}
	}

	protected override void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (RealMinimizedMode && _minimizedPopup != null)
		{
			_minimizedPopup.PerformNeedPaint(e.NeedLayout);
		}
		base.OnNeedPaint(sender, e);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected virtual void OnSelectedTabChanged(EventArgs e)
	{
		base.DirtyPaletteCounter++;
		if (this.SelectedTabChanged != null)
		{
			this.SelectedTabChanged(this, e);
		}
	}

	protected virtual void OnSelectedContextChanged(EventArgs e)
	{
		if (this.SelectedContextChanged != null)
		{
			this.SelectedContextChanged(this, e);
		}
	}

	protected virtual void OnShowRibbonContextMenu(ContextMenuArgs e)
	{
		if (this.ShowRibbonContextMenu != null)
		{
			this.ShowRibbonContextMenu(this, e);
		}
	}

	protected virtual void OnShowQATCustomizeMenu(ContextMenuArgs e)
	{
		if (this.ShowQATCustomizeMenu != null)
		{
			this.ShowQATCustomizeMenu(this, e);
		}
	}

	protected internal virtual void OnAppButtonMenuOpening(CancelEventArgs e)
	{
		if (this.AppButtonMenuOpening != null)
		{
			this.AppButtonMenuOpening(this, e);
		}
	}

	protected internal virtual void OnAppButtonMenuOpened(EventArgs e)
	{
		if (this.AppButtonMenuOpened != null)
		{
			this.AppButtonMenuOpened(this, e);
		}
	}

	protected internal virtual void OnAppButtonMenuClosing(CancelEventArgs e)
	{
		if (this.AppButtonMenuClosing != null)
		{
			this.AppButtonMenuClosing(this, e);
		}
	}

	protected internal virtual void OnAppButtonMenuClosed(ToolStripDropDownClosedEventArgs e)
	{
		if (this.AppButtonMenuClosed != null)
		{
			this.AppButtonMenuClosed(this, e);
		}
	}

	protected virtual void OnMinimizedModeChanged(EventArgs e)
	{
		if (this.MinimizedModeChanged != null)
		{
			this.MinimizedModeChanged(this, e);
		}
	}

	internal void OnDesignTimeAddTab()
	{
		if (this.DesignTimeAddTab != null)
		{
			this.DesignTimeAddTab(this, EventArgs.Empty);
		}
	}

	internal void UpdateBackStyle()
	{
		PaletteBackStyle paletteBackStyle = BackStyle;
		Form form = null;
		Control control = this;
		while (control.Parent != null)
		{
			control = control.Parent;
			if (control is Form)
			{
				form = (Form)control;
				break;
			}
		}
		if (form != null)
		{
			if (form is KryptonForm kryptonForm)
			{
				if (!kryptonForm.WindowActive)
				{
					paletteBackStyle = BackInactiveStyle;
				}
			}
			else if (!form.ContainsFocus)
			{
				paletteBackStyle = BackInactiveStyle;
			}
		}
		if (_groupsArea.BackStyle != paletteBackStyle)
		{
			_backPanelInherit.Style = paletteBackStyle;
			_groupsArea.BackStyle = paletteBackStyle;
			_tabsArea.RecreateButtons();
			PerformNeedPaint(needLayout: true);
		}
	}

	internal void TestForAppButtonDoubleClick()
	{
		TabsArea.TestForAppButtonDoubleClick();
	}

	internal void HideFocus(Control c)
	{
		while (c != null)
		{
			if (c is ViewLayoutRibbonScrollPort.RibbonViewControl)
			{
				((ViewLayoutRibbonScrollPort.RibbonViewControl)c).HideFocus();
				break;
			}
			if (c is VisualPopupGroup)
			{
				((VisualPopupGroup)c).HideFocus();
				break;
			}
			c = c.Parent;
		}
		if (c == null)
		{
			_hiddenFocusTarget.Focus();
		}
	}

	internal KryptonForm FindKryptonForm()
	{
		Control control = this;
		while (control != null && !(control is Form))
		{
			control = control.Parent;
		}
		if (control != null && control is KryptonForm)
		{
			return control as KryptonForm;
		}
		return null;
	}

	internal void DisplayQATCustomizeMenu(Rectangle screenRectangle, ViewLayoutRibbonQATContents contents, EventHandler finishDelegate)
	{
		ResetCachedKryptonContextMenu();
		KryptonContextMenuHeading kryptonContextMenuHeading = new KryptonContextMenuHeading();
		kryptonContextMenuHeading.Text = RibbonStrings.CustomizeQuickAccessToolbar;
		_kcm.Items.Add(kryptonContextMenuHeading);
		KryptonContextMenuItems kryptonContextMenuItems = new KryptonContextMenuItems();
		_kcm.Items.Add(kryptonContextMenuItems);
		if (QATUserChange)
		{
			foreach (IQuickAccessToolbarButton qATButton in QATButtons)
			{
				KryptonContextMenuItem kryptonContextMenuItem = new KryptonContextMenuItem();
				kryptonContextMenuItem.Text = qATButton.GetText();
				kryptonContextMenuItem.Checked = qATButton.GetVisible();
				kryptonContextMenuItem.Click += OnQATCustomizeClick;
				kryptonContextMenuItem.Tag = QATButtons.IndexOf(qATButton);
				kryptonContextMenuItems.Items.Add(kryptonContextMenuItem);
			}
		}
		if (QATLocation != QATLocation.Hidden)
		{
			KryptonContextMenuItem kryptonContextMenuItem2 = new KryptonContextMenuItem();
			if (QATLocation == QATLocation.Above)
			{
				kryptonContextMenuItem2.Text = RibbonStrings.ShowBelowRibbon;
			}
			else
			{
				kryptonContextMenuItem2.Text = RibbonStrings.ShowAboveRibbon;
			}
			kryptonContextMenuItem2.Click += OnInvertQATLocation;
			if (kryptonContextMenuItems.Items.Count > 0)
			{
				kryptonContextMenuItems.Items.Add(new KryptonContextMenuSeparator());
			}
			kryptonContextMenuItems.Items.Add(kryptonContextMenuItem2);
		}
		if (AllowMinimizedChange)
		{
			KryptonContextMenuItem kryptonContextMenuItem3 = new KryptonContextMenuItem();
			kryptonContextMenuItem3.Text = RibbonStrings.Minimize;
			kryptonContextMenuItem3.Checked = MinimizedMode;
			kryptonContextMenuItem3.Click += OnInvertMinimizeMode;
			if (kryptonContextMenuItems.Items.Count > 0)
			{
				kryptonContextMenuItems.Items.Add(new KryptonContextMenuSeparator());
			}
			kryptonContextMenuItems.Items.Add(kryptonContextMenuItem3);
		}
		ContextMenuArgs contextMenuArgs = new ContextMenuArgs(_kcm);
		OnShowQATCustomizeMenu(contextMenuArgs);
		if (!contextMenuArgs.Cancel && contextMenuArgs.KryptonContextMenu != null && CommonHelper.ValidKryptonContextMenu(_kcm))
		{
			_kcmFinishDelegate = finishDelegate;
			VisualPopupManager.Singleton.EndAllTracking();
			_kcm.Show(new Point(screenRectangle.X, screenRectangle.Bottom + 1));
		}
		else
		{
			finishDelegate?.Invoke(this, EventArgs.Empty);
		}
	}

	internal void DisplayQATOverflowMenu(Rectangle screenRectangle, ViewLayoutRibbonQATContents contents, EventHandler finishDelegate)
	{
		VisualPopupQATOverflow visualPopupQATOverflow = new VisualPopupQATOverflow(this, contents, base.Renderer);
		visualPopupQATOverflow.ShowCalculatingSize(screenRectangle, finishDelegate);
	}

	internal void DisplayRibbonContextMenu(MouseEventArgs e)
	{
		ResetCachedKryptonContextMenu();
		KryptonContextMenuItems kryptonContextMenuItems = new KryptonContextMenuItems();
		_kcm.Items.Add(kryptonContextMenuItems);
		if (QATLocation != QATLocation.Hidden)
		{
			KryptonContextMenuItem kryptonContextMenuItem = new KryptonContextMenuItem();
			if (QATLocation == QATLocation.Above)
			{
				kryptonContextMenuItem.Text = RibbonStrings.ShowQATBelowRibbon;
			}
			else
			{
				kryptonContextMenuItem.Text = RibbonStrings.ShowQATAboveRibbon;
			}
			kryptonContextMenuItem.Click += OnInvertQATLocation;
			kryptonContextMenuItems.Items.Add(kryptonContextMenuItem);
		}
		if (AllowMinimizedChange)
		{
			KryptonContextMenuItem kryptonContextMenuItem2 = new KryptonContextMenuItem();
			kryptonContextMenuItem2.Text = RibbonStrings.Minimize;
			kryptonContextMenuItem2.Checked = MinimizedMode;
			kryptonContextMenuItem2.Click += OnInvertMinimizeMode;
			kryptonContextMenuItems.Items.Add(new KryptonContextMenuSeparator());
			kryptonContextMenuItems.Items.Add(kryptonContextMenuItem2);
		}
		ContextMenuArgs contextMenuArgs = new ContextMenuArgs(_kcm);
		OnShowRibbonContextMenu(contextMenuArgs);
		if (!contextMenuArgs.Cancel && contextMenuArgs.KryptonContextMenu != null && CommonHelper.ValidKryptonContextMenu(_kcm))
		{
			VisualPopupManager.Singleton.EndAllTracking();
			_kcm.Show(PointToScreen(new Point(e.X, e.Y)));
		}
	}

	internal ViewBase GetFirstQATView()
	{
		switch (QATLocation)
		{
		case QATLocation.Above:
			return _captionArea.VisibleQAT.GetFirstQATView();
		case QATLocation.Below:
			return _qatBelowContents.GetFirstQATView();
		case QATLocation.Hidden:
			return null;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	internal ViewBase GetLastQATView()
	{
		switch (QATLocation)
		{
		case QATLocation.Above:
			return _captionArea.VisibleQAT.GetLastQATView();
		case QATLocation.Below:
			return _qatBelowContents.GetLastQATView();
		case QATLocation.Hidden:
			return null;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	internal ViewBase GetNextQATView(ViewBase qatView, bool tab)
	{
		ViewBase viewBase = null;
		switch (QATLocation)
		{
		case QATLocation.Above:
			viewBase = _captionArea.VisibleQAT.GetNextQATView(qatView);
			break;
		case QATLocation.Below:
			viewBase = _qatBelowContents.GetNextQATView(qatView);
			break;
		}
		if (viewBase == null)
		{
			viewBase = TabsArea.ButtonSpecManager.GetLastVisibleViewButton(PaletteRelativeEdgeAlign.Near);
		}
		if (viewBase == null)
		{
			viewBase = ((!tab || SelectedTab == null) ? TabsArea.LayoutTabs.GetViewForFirstRibbonTab() : TabsArea.LayoutTabs.GetViewForRibbonTab(SelectedTab));
		}
		if (viewBase == null)
		{
			viewBase = TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Far);
		}
		if (viewBase == null)
		{
			viewBase = TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Inherit);
		}
		if (viewBase == null)
		{
			if (TabsArea.LayoutAppButton.Visible)
			{
				viewBase = TabsArea.LayoutAppButton.AppButton;
			}
			else if (TabsArea.LayoutAppTab.Visible)
			{
				viewBase = TabsArea.LayoutAppTab.AppTab;
			}
		}
		return viewBase;
	}

	internal ViewBase GetPreviousQATView(ViewBase qatView)
	{
		ViewBase viewBase = null;
		switch (QATLocation)
		{
		case QATLocation.Above:
			viewBase = _captionArea.VisibleQAT.GetPreviousQATView(qatView);
			break;
		case QATLocation.Below:
			viewBase = _qatBelowContents.GetPreviousQATView(qatView);
			break;
		}
		if (viewBase == null)
		{
			if (TabsArea.LayoutAppButton.Visible)
			{
				viewBase = TabsArea.LayoutAppButton.AppButton;
			}
			else if (TabsArea.LayoutAppTab.Visible)
			{
				viewBase = TabsArea.LayoutAppTab.AppTab;
			}
		}
		return viewBase;
	}

	internal void KillKeyboardMode()
	{
		if (_keyboardMode)
		{
			ToggleKeyboardMode();
		}
	}

	internal void KillKeyboardKeyTips()
	{
		if (_keyboardKeyTips)
		{
			KeyTipMode = KeyTipMode.Root;
			_keyboardKeyTips = false;
			if (_keyTipControlE != null)
			{
				_keyTipControlE.Dispose();
				_keyTipControlE = null;
			}
			if (_keyTipControlD != null)
			{
				_keyTipControlD.Dispose();
				_keyTipControlD = null;
			}
		}
	}

	internal void KillMinimizedPopup()
	{
		if (_minimizedPopup != null)
		{
			_minimizedPopup.Disposed -= OnMinimizedPopupDisposed;
			VisualPopupManager.Singleton.EndAllTracking();
			_minimizedPopup = null;
			ValidateSelectedTab();
		}
	}

	internal void RestorePreviousFocus()
	{
		if (_keyboardFocusWindow != IntPtr.Zero)
		{
			PI.SetFocus(_keyboardFocusWindow);
			if (_keyboardFocusCaret)
			{
				PI.ShowCaret(_keyboardFocusWindow);
			}
		}
	}

	internal void ActionOccured()
	{
		if (_minimizedPopup != null)
		{
			KillMinimizedPopup();
		}
		else
		{
			VisualPopupManager.Singleton.EndAllTracking();
		}
		KillKeyboardMode();
	}

	internal void UpdateQAT()
	{
		if (_captionArea != null)
		{
			_captionArea.UpdateQAT();
		}
	}

	internal void SetKeyTips(KeyTipInfoList keyTipList, KeyTipMode newMode)
	{
		if (_keyTipControlE != null)
		{
			_keyTipControlE.Dispose();
		}
		if (_keyTipControlD != null)
		{
			_keyTipControlD.Dispose();
		}
		_keyTipControlE = new KeyTipControl(this, keyTipList, showDisabled: false);
		_keyTipControlD = new KeyTipControl(this, keyTipList, showDisabled: true);
		_keyTipMode = newMode;
	}

	internal void AppendKeyTipPress(char key)
	{
		if (InKeyboardMode && InKeyTipsMode && _keyTipControlE != null)
		{
			_keyTipControlE.AppendKeyPress(char.ToUpper(key));
		}
	}

	internal KeyTipInfoList GenerateKeyTipsAtTopLevel()
	{
		Refresh();
		KeyTipInfoList keyTipInfoList = new KeyTipInfoList();
		if (_tabsArea.LayoutAppButton.Visible)
		{
			keyTipInfoList.Add(_tabsArea.GetAppButtonKeyTip());
		}
		if (_tabsArea.LayoutAppTab.Visible)
		{
			keyTipInfoList.Add(_tabsArea.GetAppTabKeyTip());
		}
		if (QATLocation == QATLocation.Above)
		{
			keyTipInfoList.AddRange(_captionArea.VisibleQAT.GetQATKeyTips());
		}
		else
		{
			keyTipInfoList.AddRange(_qatBelowContents.GetQATKeyTips(null));
		}
		keyTipInfoList.AddRange(_tabsArea.GetTabKeyTips());
		return keyTipInfoList;
	}

	internal KeyTipInfoList GenerateKeyTipsForSelectedTab()
	{
		Refresh();
		KeyTipInfoList keyTipInfoList = new KeyTipInfoList();
		if (SelectedTab != null)
		{
			keyTipInfoList.AddRange(GroupsArea.ViewGroups.GetGroupKeyTips(SelectedTab));
		}
		return keyTipInfoList;
	}

	internal Point ViewPointToScreen(Point pt)
	{
		if (VisualPopupManager.Singleton.CurrentPopup != null)
		{
			return VisualPopupManager.Singleton.CurrentPopup.PointToScreen(pt);
		}
		return PointToScreen(pt);
	}

	internal Rectangle ViewRectangleToScreen(ViewBase view)
	{
		return view.OwningControl.RectangleToScreen(view.ClientRectangle);
	}

	internal Rectangle KeyTipToScreen(ViewBase view)
	{
		return view.OwningControl.RectangleToScreen(view.ClientRectangle);
	}

	internal PaletteRedirect GetRedirector()
	{
		return base.Redirector;
	}

	internal Control GetControllerControl(Control c)
	{
		while (c != null)
		{
			if (c is KryptonRibbon || c is VisualPopupGroup || c is VisualPopupMinimized)
			{
				return c;
			}
			c = c.Parent;
		}
		return c;
	}

	internal void MinimizedKeyDown(Keys keyData)
	{
		if (_focusView != null)
		{
			switch (keyData)
			{
			case Keys.Tab:
			case Keys.Return:
			case Keys.Space:
			case Keys.Left:
			case Keys.Up:
			case Keys.Right:
			case Keys.Down:
			case Keys.Tab | Keys.Shift:
				KillKeyboardKeyTips();
				_focusView.KeyDown(new KeyEventArgs(keyData));
				break;
			}
		}
	}

	private void AssignDefaultFields()
	{
		_designHelpers = true;
		AllowButtonSpecToolTips = false;
		AllowMinimizedChange = true;
		AutoSize = true;
		AutoSizeMode = AutoSizeMode.GrowAndShrink;
		Dock = DockStyle.Top;
		HideRibbonSize = new Size(300, 250);
		MinimizedMode = false;
		ScrollerStyle = ButtonStyle.Standalone;
		ShowMinimizeButton = true;
		QATLocation = QATLocation.Above;
		QATUserChange = true;
		AllowFormIntegrate = true;
		LostFocusLosesKeyboard = true;
		BackStyle = PaletteBackStyle.PanelClient;
		BackInactiveStyle = PaletteBackStyle.PanelRibbonInactive;
		GroupButtonStyle = ButtonStyle.ButtonSpec;
		GroupClusterButtonStyle = ButtonStyle.Cluster;
		GroupCollapsedButtonStyle = ButtonStyle.Alternate;
		GroupDialogButtonStyle = ButtonStyle.ButtonSpec;
		QATButtonStyle = ButtonStyle.ButtonSpec;
		ScrollerStyle = ButtonStyle.Standalone;
	}

	private void CreateInternal()
	{
		_calculatedValues = new CalculatedValues(this);
		_invalidateOnResize = Environment.OSVersion.Version.Major >= 6;
		_hiddenFocusTarget = new Button();
		_hiddenFocusTarget.TabStop = false;
		_hiddenFocusTarget.Location = new Point(-_hiddenFocusTarget.Width, -_hiddenFocusTarget.Height);
		CommonHelper.AddControlToParent(this, _hiddenFocusTarget);
	}

	private void CreateRibbonCollections()
	{
		_ribbonContexts = new KryptonRibbonContextCollection();
		_ribbonContexts.Clearing += OnRibbonContextsClearing;
		_ribbonContexts.Cleared += OnRibbonContextsCleared;
		_ribbonContexts.Inserted += OnRibbonContextsInserted;
		_ribbonContexts.Removed += OnRibbonContextsRemoved;
		_ribbonTabs = new KryptonRibbonTabCollection();
		_ribbonTabs.Clearing += OnRibbonTabsClearing;
		_ribbonTabs.Cleared += OnRibbonTabsCleared;
		_ribbonTabs.Inserted += OnRibbonTabsInserted;
		_ribbonTabs.Removed += OnRibbonTabsRemoved;
		_qatButtons = new KryptonRibbonQATButtonCollection();
		_qatButtons.Clearing += OnRibbonQATButtonsClearing;
		_qatButtons.Cleared += OnRibbonQATButtonsCleared;
		_qatButtons.Inserted += OnRibbonQATButtonsInserted;
		_qatButtons.Removed += OnRibbonQATButtonsRemoved;
	}

	private void CreateButtonSpecs()
	{
		_buttonSpecs = new RibbonButtonSpecAnyCollection(this);
	}

	private void CreateStorageObjects()
	{
		_ribbonShortcuts = new RibbonShortcuts();
		_ribbonStrings = new RibbonStrings();
		_ribbonAppButton = new RibbonAppButton(this);
		_ribbonStyles = new PaletteRibbonStyles(this, base.NeedPaintPaletteDelegate);
		_stateCommon = new PaletteRibbonRedirect(base.Redirector, PaletteBackStyle.PanelClient, base.NeedPaintPaletteDelegate);
		_stateDisabled = new PaletteRibbonDisabled(_stateCommon, base.NeedPaintPaletteDelegate);
		_stateNormal = new PaletteRibbonNormal(_stateCommon, base.NeedPaintPaletteDelegate);
		_stateTracking = new PaletteRibbonAppGroupTab(_stateCommon, base.NeedPaintPaletteDelegate);
		_statePressed = new PaletteRibbonAppButton(_stateCommon, base.NeedPaintPaletteDelegate);
		_stateCheckedNormal = new PaletteRibbonGroupAreaTab(_stateCommon, base.NeedPaintPaletteDelegate);
		_stateCheckedTracking = new PaletteRibbonJustTab(_stateCommon, base.NeedPaintPaletteDelegate);
		_stateContextNormal = new PaletteRibbonJustGroup(_stateCommon, base.NeedPaintPaletteDelegate);
		_stateContextTracking = new PaletteRibbonGroupTab(_stateCommon, base.NeedPaintPaletteDelegate);
		_stateContextCheckedNormal = new PaletteRibbonGroupAreaTab(_stateCommon, base.NeedPaintPaletteDelegate);
		_stateContextCheckedTracking = new PaletteRibbonJustTab(_stateCommon, base.NeedPaintPaletteDelegate);
		_overrideFocus = new PaletteRibbonFocus(base.Redirector, base.NeedPaintPaletteDelegate);
	}

	private void CreateViewManager()
	{
		_needPaintGroups = OnNeedPaintMinimizedGroups;
		_backPanelInherit = new PaletteBackInheritRedirect(base.Redirector, PaletteBackStyle.PanelClient);
		_drawPanel = new ViewDrawRibbonPanel(this, _backPanelInherit, base.NeedPaintDelegate);
		_drawMinimizedPanel = new ViewDrawPanel(_backPanelInherit);
		_rootDocker = new ViewLayoutDocker();
		_ribbonDocker = new ViewLayoutDocker();
		_compositionArea = new ViewDrawRibbonComposition(this, base.NeedPaintDelegate);
		_compositionArea.Visible = false;
		_captionArea = new ViewDrawRibbonCaptionArea(this, base.Redirector, _compositionArea, base.NeedPaintDelegate);
		_tabsArea = new ViewLayoutRibbonTabsArea(this, base.Redirector, _captionArea, _captionArea.ContextTitles, base.NeedPaintDelegate);
		_tabsArea.PaintBackground += OnTabsAreaPaintBackground;
		_groupsArea = new ViewLayoutRibbonGroupsArea(this, base.Redirector, _needPaintGroups);
		_qatBelowContents = new ViewLayoutRibbonQATFromRibbon(this, base.NeedPaintDelegate, showExtraButton: true);
		_qatBelowRibbon = new ViewDrawRibbonQATBorder(this, base.NeedPaintDelegate, minibar: false);
		_qatBelowRibbon.Visible = false;
		_qatBelowRibbon.Add(_qatBelowContents);
		_minimizeBar = new ViewDrawRibbonMinimizeBar(StateCommon.RibbonGeneral);
		_minimizeBar.Visible = false;
		_drawPanel.Add(_ribbonDocker);
		_ribbonDocker.Add(_groupsArea, ViewDockStyle.Fill);
		_ribbonDocker.Add(_minimizeBar, ViewDockStyle.Bottom);
		_ribbonDocker.Add(_qatBelowRibbon, ViewDockStyle.Bottom);
		_ribbonDocker.Add(_tabsArea, ViewDockStyle.Top);
		_ribbonDocker.Add(_captionArea, ViewDockStyle.Top);
		_rootDocker.Add(_drawPanel, ViewDockStyle.Fill);
		_rootDocker.Add(_compositionArea, ViewDockStyle.Top);
		_captionArea.HookToolTipHandling();
		_tabsArea.HookToolTipHandling();
		base.ViewManager = new ViewRibbonManager(this, _groupsArea.ViewGroups, _rootDocker, minimizedMode: false, base.NeedPaintDelegate);
	}

	private void CheckForAltUp()
	{
		if (_altDown && (Control.ModifierKeys & Keys.Alt) != Keys.Alt)
		{
			_altDown = false;
			_altUpCount++;
		}
	}

	private void CheckForAltDown()
	{
		if (!_altDown && (Control.ModifierKeys & Keys.Alt) == Keys.Alt)
		{
			_altDown = true;
		}
	}

	private bool TabIsContextValid(KryptonRibbonTab tab)
	{
		if (string.IsNullOrEmpty(tab.ContextName) || InDesignHelperMode)
		{
			return true;
		}
		if (!string.IsNullOrEmpty(SelectedContext))
		{
			string[] array = SelectedContext.Split(',');
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text == tab.ContextName)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void ValidateSelectedTab()
	{
		KryptonRibbonTab kryptonRibbonTab = null;
		if (!RealMinimizedMode)
		{
			if (SelectedTab == null || (!SelectedTab.Visible && !InDesignHelperMode) || !RibbonTabs.Contains(SelectedTab) || !TabIsContextValid(SelectedTab))
			{
				foreach (KryptonRibbonTab ribbonTab in RibbonTabs)
				{
					if (string.IsNullOrEmpty(ribbonTab.ContextName) && ribbonTab.Visible)
					{
						kryptonRibbonTab = ribbonTab;
						break;
					}
				}
				if (kryptonRibbonTab == null)
				{
					foreach (KryptonRibbonTab ribbonTab2 in RibbonTabs)
					{
						if (!string.IsNullOrEmpty(ribbonTab2.ContextName) && ribbonTab2.Visible && TabIsContextValid(ribbonTab2))
						{
							kryptonRibbonTab = ribbonTab2;
							break;
						}
					}
				}
			}
			else
			{
				kryptonRibbonTab = SelectedTab;
			}
		}
		if (SelectedTab != kryptonRibbonTab)
		{
			_selectedTab = kryptonRibbonTab;
			OnSelectedTabChanged(EventArgs.Empty);
			PerformNeedPaint(needLayout: true);
		}
	}

	private bool SelectNonRibbonControl(bool forward)
	{
		Control controlWithFocus = CommonHelper.GetControlWithFocus(this);
		if (controlWithFocus != null)
		{
			Control control = controlWithFocus.FindForm();
			if (control == null)
			{
				control = controlWithFocus;
				while (control.Parent != null)
				{
					control = control.Parent;
				}
			}
			Control control2 = controlWithFocus;
			bool flag = false;
			do
			{
				control2 = control.GetNextControl(control2, forward);
				if (control2 == null)
				{
					if (flag)
					{
						return false;
					}
					flag = true;
				}
				else if (control2 != this && !Contains(control2) && control2.CanSelect && control2.TabStop)
				{
					if (!(control2 is ContainerControl))
					{
						control2.Select();
						return true;
					}
					if (!control2.Contains(controlWithFocus))
					{
						_containerSelect.Invoke(control2, new object[2] { true, forward });
						return true;
					}
				}
			}
			while (control2 != controlWithFocus);
		}
		return false;
	}

	private void OnRibbonContextsClearing(object sender, EventArgs e)
	{
		foreach (KryptonRibbonContext ribbonContext in RibbonContexts)
		{
			ribbonContext.PropertyChanged -= OnContextPropertyChanged;
		}
	}

	private void OnRibbonContextsCleared(object sender, EventArgs e)
	{
		_captionArea.UpdateVisible();
		PerformNeedPaint(needLayout: true);
	}

	private void OnRibbonContextsInserted(object sender, TypedCollectionEventArgs<KryptonRibbonContext> e)
	{
		e.Item.PropertyChanged += OnContextPropertyChanged;
		_captionArea.UpdateVisible();
		PerformNeedPaint(needLayout: true);
	}

	private void OnRibbonContextsRemoved(object sender, TypedCollectionEventArgs<KryptonRibbonContext> e)
	{
		e.Item.PropertyChanged -= OnContextPropertyChanged;
		_captionArea.UpdateVisible();
		PerformNeedPaint(needLayout: true);
	}

	private void OnContextPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		PerformNeedPaint(needLayout: true);
	}

	private void OnRibbonTabsClearing(object sender, EventArgs e)
	{
		foreach (KryptonRibbonTab ribbonTab in RibbonTabs)
		{
			ribbonTab.PropertyChanged -= OnTabPropertyChanged;
			ribbonTab.Ribbon = null;
		}
	}

	private void OnRibbonTabsCleared(object sender, EventArgs e)
	{
		_minSelectedTab = null;
		ValidateSelectedTab();
		PerformNeedPaint(needLayout: true);
	}

	private void OnRibbonTabsInserted(object sender, TypedCollectionEventArgs<KryptonRibbonTab> e)
	{
		e.Item.Ribbon = this;
		e.Item.PropertyChanged += OnTabPropertyChanged;
		ValidateSelectedTab();
		PerformNeedPaint(needLayout: true);
	}

	private void OnRibbonTabsRemoved(object sender, TypedCollectionEventArgs<KryptonRibbonTab> e)
	{
		e.Item.PropertyChanged -= OnTabPropertyChanged;
		e.Item.Ribbon = null;
		if (_minSelectedTab == e.Item)
		{
			_minSelectedTab = null;
		}
		ValidateSelectedTab();
		PerformNeedPaint(needLayout: true);
	}

	private void OnTabPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		string text = propertyName;
		if (text == "Visible")
		{
			ValidateSelectedTab();
			PerformNeedPaint(needLayout: true);
		}
	}

	private void OnRibbonQATButtonsClearing(object sender, EventArgs e)
	{
		foreach (IQuickAccessToolbarButton qATButton in QATButtons)
		{
			qATButton.PropertyChanged -= OnQATButtonPropertyChanged;
		}
	}

	private void OnRibbonQATButtonsCleared(object sender, EventArgs e)
	{
		PerformNeedPaint(needLayout: true);
		_captionArea.QATButtonsChanged();
	}

	private void OnRibbonQATButtonsInserted(object sender, TypedCollectionEventArgs<Component> e)
	{
		IQuickAccessToolbarButton quickAccessToolbarButton = e.Item as IQuickAccessToolbarButton;
		Debug.Assert(quickAccessToolbarButton != null);
		quickAccessToolbarButton?.SetRibbon(this);
		quickAccessToolbarButton.PropertyChanged += OnQATButtonPropertyChanged;
		PerformNeedPaint(needLayout: true);
		_captionArea.QATButtonsChanged();
	}

	private void OnRibbonQATButtonsRemoved(object sender, TypedCollectionEventArgs<Component> e)
	{
		IQuickAccessToolbarButton quickAccessToolbarButton = e.Item as IQuickAccessToolbarButton;
		Debug.Assert(quickAccessToolbarButton != null);
		quickAccessToolbarButton.PropertyChanged -= OnQATButtonPropertyChanged;
		quickAccessToolbarButton?.SetRibbon(null);
		PerformNeedPaint(needLayout: true);
		_captionArea.QATButtonsChanged();
	}

	private void OnNeedPaintMinimizedGroups(object sender, NeedLayoutEventArgs e)
	{
		if (RealMinimizedMode)
		{
			if (_minimizedPopup != null)
			{
				_minimizedPopup.PerformNeedPaint(e.NeedLayout);
			}
		}
		else
		{
			OnNeedPaint(this, e);
		}
	}

	private void OnQATButtonPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		PerformNeedPaint(needLayout: true);
		_captionArea.QATButtonsChanged();
	}

	private void OnInvertQATLocation(object sender, EventArgs e)
	{
		VisualPopupManager.Singleton.EndAllTracking();
		KillKeyboardMode();
		if (QATLocation == QATLocation.Above)
		{
			QATLocation = QATLocation.Below;
		}
		else
		{
			QATLocation = QATLocation.Above;
		}
	}

	private void OnInvertMinimizeMode(object sender, EventArgs e)
	{
		VisualPopupManager.Singleton.EndAllTracking();
		KillKeyboardMode();
		MinimizedMode = !MinimizedMode;
	}

	private void ShowMinimizedPopup()
	{
		base.DirtyPaletteCounter++;
		ViewRibbonMinimizedManager viewRibbonMinimizedManager = new ViewRibbonMinimizedManager(this, _groupsArea.ViewGroups, _drawMinimizedPanel, minimizedMode: true, _needPaintGroups);
		_minimizedPopup = new VisualPopupMinimized(this, viewRibbonMinimizedManager, _captionArea, base.Renderer);
		_minimizedPopup.Disposed += OnMinimizedPopupDisposed;
		viewRibbonMinimizedManager.Attach(_minimizedPopup, _drawMinimizedPanel);
		_minimizedPopup.Show(_tabsArea, _drawMinimizedPanel);
	}

	private void UpdateMinimizedPopup()
	{
		_minimizedPopup.Show(_tabsArea, _drawMinimizedPanel);
	}

	private void OnMinimizedPopupDisposed(object sender, EventArgs e)
	{
		_minimizedPopup = null;
		ValidateSelectedTab();
		PerformNeedPaint(needLayout: true);
	}

	private void OnQATCustomizeClick(object sender, EventArgs e)
	{
		VisualPopupManager.Singleton.EndAllTracking();
		KillKeyboardMode();
		KryptonContextMenuItem kryptonContextMenuItem = (KryptonContextMenuItem)sender;
		int num = (int)kryptonContextMenuItem.Tag;
		if (num >= 0 && num < QATButtons.Count)
		{
			IQuickAccessToolbarButton quickAccessToolbarButton = (IQuickAccessToolbarButton)QATButtons[num];
			quickAccessToolbarButton.SetVisible(!quickAccessToolbarButton.GetVisible());
			_captionArea.UpdateQAT();
			PerformNeedPaint(needLayout: true);
		}
	}

	private void ResetCachedKryptonContextMenu()
	{
		if (_kcm == null)
		{
			_kcm = new KryptonContextMenu();
			_kcm.Closed += OnKryptonContextMenuClosed;
		}
		_kcm.Items.Clear();
	}

	private void OnKryptonContextMenuClosed(object sender, EventArgs e)
	{
		if (_kcmFinishDelegate != null)
		{
			_kcmFinishDelegate(this, e);
			_kcmFinishDelegate = null;
		}
	}

	private void OnTabsAreaPaintBackground(object sender, PaintEventArgs e)
	{
		_drawPanel.PaintRectangle(e.Graphics, e.ClipRectangle, edges: false, sender as Control);
	}
}
