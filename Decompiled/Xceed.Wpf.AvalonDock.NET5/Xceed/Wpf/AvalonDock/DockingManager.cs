using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock.Controls;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.AvalonDock.Themes;

namespace Xceed.Wpf.AvalonDock;

[ContentProperty("Layout")]
[TemplatePart(Name = "PART_AutoHideArea")]
public class DockingManager : Control, IOverlayWindowHost, IWeakEventListener
{
	private ResourceDictionary currentThemeResourceDictionary;

	private AutoHideWindowManager _autoHideWindowManager;

	private FrameworkElement _autohideArea;

	private List<LayoutFloatingWindowControl> _fwList = new List<LayoutFloatingWindowControl>();

	private OverlayWindow _overlayWindow;

	private List<IDropArea> _areas;

	private bool _insideInternalSetActiveContent;

	private List<LayoutItem> _layoutItems = new List<LayoutItem>();

	private bool _suspendLayoutItemCreation;

	private DispatcherOperation _collectLayoutItemsOperations;

	private NavigatorWindow _navigatorWindow;

	internal bool SuspendDocumentsSourceBinding;

	internal bool SuspendAnchorablesSourceBinding;

	public static readonly DependencyProperty AllowMovingFloatingWindowWithKeyboardProperty;

	public static readonly DependencyProperty LayoutProperty;

	public static readonly DependencyProperty LayoutUpdateStrategyProperty;

	public static readonly DependencyProperty AnchorSideTemplateProperty;

	public static readonly DependencyProperty AnchorGroupTemplateProperty;

	public static readonly DependencyProperty AnchorTemplateProperty;

	public static readonly DependencyProperty DocumentPaneControlStyleProperty;

	public static readonly DependencyProperty AnchorablePaneControlStyleProperty;

	public static readonly DependencyProperty DocumentHeaderTemplateProperty;

	public static readonly DependencyProperty DocumentHeaderTemplateSelectorProperty;

	public static readonly DependencyProperty DocumentTitleTemplateProperty;

	public static readonly DependencyProperty DocumentTitleTemplateSelectorProperty;

	public static readonly DependencyProperty AnchorableTitleTemplateProperty;

	public static readonly DependencyProperty AnchorableTitleTemplateSelectorProperty;

	public static readonly DependencyProperty AnchorableHeaderTemplateProperty;

	public static readonly DependencyProperty AnchorableHeaderTemplateSelectorProperty;

	public static readonly DependencyProperty LayoutRootPanelProperty;

	public static readonly DependencyProperty RightSidePanelProperty;

	public static readonly DependencyProperty LeftSidePanelProperty;

	public static readonly DependencyProperty TopSidePanelProperty;

	public static readonly DependencyProperty BottomSidePanelProperty;

	private List<WeakReference> _logicalChildren = new List<WeakReference>();

	private static readonly DependencyPropertyKey AutoHideWindowPropertyKey;

	public static readonly DependencyProperty AutoHideWindowProperty;

	public static readonly DependencyProperty AutoHideWindowClosingTimerProperty;

	public static readonly DependencyProperty LayoutItemTemplateProperty;

	public static readonly DependencyProperty LayoutItemTemplateSelectorProperty;

	public static readonly DependencyProperty DocumentsSourceProperty;

	public static readonly DependencyProperty DocumentContextMenuProperty;

	public static readonly DependencyProperty AnchorablesSourceProperty;

	public static readonly DependencyProperty ActiveContentProperty;

	public static readonly DependencyProperty AnchorableContextMenuProperty;

	public static readonly DependencyProperty ThemeProperty;

	public static readonly DependencyProperty GridSplitterWidthProperty;

	public static readonly DependencyProperty GridSplitterHeightProperty;

	public static readonly DependencyProperty DocumentPaneMenuItemHeaderTemplateProperty;

	public static readonly DependencyProperty DocumentPaneMenuItemHeaderTemplateSelectorProperty;

	public static readonly DependencyProperty IconContentTemplateProperty;

	public static readonly DependencyProperty IconContentTemplateSelectorProperty;

	public static readonly DependencyProperty LayoutItemContainerStyleProperty;

	public static readonly DependencyProperty LayoutItemContainerStyleSelectorProperty;

	public static readonly DependencyProperty ShowSystemMenuProperty;

	public static readonly DependencyProperty AllowMixedOrientationProperty;

	public static readonly RoutedEvent PreviewFloatEvent;

	public static readonly RoutedEvent FloatedEvent;

	public static readonly RoutedEvent PreviewDockEvent;

	public static readonly RoutedEvent DockedEvent;

	public bool AllowMovingFloatingWindowWithKeyboard
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowMovingFloatingWindowWithKeyboardProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(AllowMovingFloatingWindowWithKeyboardProperty, (object)value);
		}
	}

	public LayoutRoot Layout
	{
		get
		{
			return (LayoutRoot)((DependencyObject)this).GetValue(LayoutProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutProperty, (object)value);
		}
	}

	public ILayoutUpdateStrategy LayoutUpdateStrategy
	{
		get
		{
			return (ILayoutUpdateStrategy)((DependencyObject)this).GetValue(LayoutUpdateStrategyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutUpdateStrategyProperty, (object)value);
		}
	}

	public ControlTemplate AnchorSideTemplate
	{
		get
		{
			return (ControlTemplate)((DependencyObject)this).GetValue(AnchorSideTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnchorSideTemplateProperty, (object)value);
		}
	}

	public ControlTemplate AnchorGroupTemplate
	{
		get
		{
			return (ControlTemplate)((DependencyObject)this).GetValue(AnchorGroupTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnchorGroupTemplateProperty, (object)value);
		}
	}

	public ControlTemplate AnchorTemplate
	{
		get
		{
			return (ControlTemplate)((DependencyObject)this).GetValue(AnchorTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnchorTemplateProperty, (object)value);
		}
	}

	public Style DocumentPaneControlStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(DocumentPaneControlStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentPaneControlStyleProperty, (object)value);
		}
	}

	public Style AnchorablePaneControlStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(AnchorablePaneControlStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnchorablePaneControlStyleProperty, (object)value);
		}
	}

	public DataTemplate DocumentHeaderTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(DocumentHeaderTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentHeaderTemplateProperty, (object)value);
		}
	}

	public DataTemplateSelector DocumentHeaderTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)((DependencyObject)this).GetValue(DocumentHeaderTemplateSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentHeaderTemplateSelectorProperty, (object)value);
		}
	}

	public DataTemplate DocumentTitleTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(DocumentTitleTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentTitleTemplateProperty, (object)value);
		}
	}

	public DataTemplateSelector DocumentTitleTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)((DependencyObject)this).GetValue(DocumentTitleTemplateSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentTitleTemplateSelectorProperty, (object)value);
		}
	}

	public DataTemplate AnchorableTitleTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(AnchorableTitleTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnchorableTitleTemplateProperty, (object)value);
		}
	}

	public DataTemplateSelector AnchorableTitleTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)((DependencyObject)this).GetValue(AnchorableTitleTemplateSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnchorableTitleTemplateSelectorProperty, (object)value);
		}
	}

	public DataTemplate AnchorableHeaderTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(AnchorableHeaderTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnchorableHeaderTemplateProperty, (object)value);
		}
	}

	public DataTemplateSelector AnchorableHeaderTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)((DependencyObject)this).GetValue(AnchorableHeaderTemplateSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnchorableHeaderTemplateSelectorProperty, (object)value);
		}
	}

	public LayoutPanelControl LayoutRootPanel
	{
		get
		{
			return (LayoutPanelControl)((DependencyObject)this).GetValue(LayoutRootPanelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutRootPanelProperty, (object)value);
		}
	}

	public LayoutAnchorSideControl RightSidePanel
	{
		get
		{
			return (LayoutAnchorSideControl)((DependencyObject)this).GetValue(RightSidePanelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RightSidePanelProperty, (object)value);
		}
	}

	public LayoutAnchorSideControl LeftSidePanel
	{
		get
		{
			return (LayoutAnchorSideControl)((DependencyObject)this).GetValue(LeftSidePanelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LeftSidePanelProperty, (object)value);
		}
	}

	public LayoutAnchorSideControl TopSidePanel
	{
		get
		{
			return (LayoutAnchorSideControl)((DependencyObject)this).GetValue(TopSidePanelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TopSidePanelProperty, (object)value);
		}
	}

	public LayoutAnchorSideControl BottomSidePanel
	{
		get
		{
			return (LayoutAnchorSideControl)((DependencyObject)this).GetValue(BottomSidePanelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BottomSidePanelProperty, (object)value);
		}
	}

	protected override IEnumerator LogicalChildren => _logicalChildren.Select((WeakReference ch) => ch.GetValueOrDefault<object>()).GetEnumerator();

	public IEnumerator LogicalChildrenPublic => LogicalChildren;

	public LayoutAutoHideWindowControl AutoHideWindow => (LayoutAutoHideWindowControl)((DependencyObject)this).GetValue(AutoHideWindowProperty);

	public int AutoHideWindowClosingTimer
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(AutoHideWindowClosingTimerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoHideWindowClosingTimerProperty, (object)value);
		}
	}

	public IEnumerable<LayoutFloatingWindowControl> FloatingWindows => _fwList;

	public DataTemplate LayoutItemTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(LayoutItemTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutItemTemplateProperty, (object)value);
		}
	}

	public DataTemplateSelector LayoutItemTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)((DependencyObject)this).GetValue(LayoutItemTemplateSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutItemTemplateSelectorProperty, (object)value);
		}
	}

	public IEnumerable DocumentsSource
	{
		get
		{
			return (IEnumerable)((DependencyObject)this).GetValue(DocumentsSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentsSourceProperty, (object)value);
		}
	}

	public ContextMenu DocumentContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(DocumentContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentContextMenuProperty, (object)value);
		}
	}

	public IEnumerable AnchorablesSource
	{
		get
		{
			return (IEnumerable)((DependencyObject)this).GetValue(AnchorablesSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnchorablesSourceProperty, (object)value);
		}
	}

	public object ActiveContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(ActiveContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveContentProperty, value);
		}
	}

	public ContextMenu AnchorableContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(AnchorableContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnchorableContextMenuProperty, (object)value);
		}
	}

	public Theme Theme
	{
		get
		{
			return (Theme)((DependencyObject)this).GetValue(ThemeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThemeProperty, (object)value);
		}
	}

	public double GridSplitterWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(GridSplitterWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GridSplitterWidthProperty, (object)value);
		}
	}

	public double GridSplitterHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(GridSplitterHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GridSplitterHeightProperty, (object)value);
		}
	}

	public DataTemplate DocumentPaneMenuItemHeaderTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(DocumentPaneMenuItemHeaderTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentPaneMenuItemHeaderTemplateProperty, (object)value);
		}
	}

	public DataTemplateSelector DocumentPaneMenuItemHeaderTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)((DependencyObject)this).GetValue(DocumentPaneMenuItemHeaderTemplateSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentPaneMenuItemHeaderTemplateSelectorProperty, (object)value);
		}
	}

	public DataTemplate IconContentTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(IconContentTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconContentTemplateProperty, (object)value);
		}
	}

	public DataTemplateSelector IconContentTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)((DependencyObject)this).GetValue(IconContentTemplateSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconContentTemplateSelectorProperty, (object)value);
		}
	}

	public Style LayoutItemContainerStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(LayoutItemContainerStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutItemContainerStyleProperty, (object)value);
		}
	}

	public StyleSelector LayoutItemContainerStyleSelector
	{
		get
		{
			return (StyleSelector)((DependencyObject)this).GetValue(LayoutItemContainerStyleSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutItemContainerStyleSelectorProperty, (object)value);
		}
	}

	public bool ShowSystemMenu
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowSystemMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSystemMenuProperty, (object)value);
		}
	}

	public bool AllowMixedOrientation
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowMixedOrientationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowMixedOrientationProperty, (object)value);
		}
	}

	internal bool IsNavigatorWindowActive => _navigatorWindow != null;

	DockingManager IOverlayWindowHost.Manager => this;

	public event EventHandler LayoutChanged;

	public event EventHandler LayoutChanging;

	public event EventHandler<DocumentClosingEventArgs> DocumentClosing;

	public event EventHandler<DocumentClosedEventArgs> DocumentClosed;

	public event EventHandler ActiveContentChanged;

	public event RoutedEventHandler PreviewFloat
	{
		add
		{
			AddHandler(PreviewFloatEvent, value);
		}
		remove
		{
			RemoveHandler(PreviewFloatEvent, value);
		}
	}

	public event RoutedEventHandler Floated
	{
		add
		{
			AddHandler(FloatedEvent, value);
		}
		remove
		{
			RemoveHandler(FloatedEvent, value);
		}
	}

	public event RoutedEventHandler PreviewDock
	{
		add
		{
			AddHandler(PreviewDockEvent, value);
		}
		remove
		{
			RemoveHandler(PreviewDockEvent, value);
		}
	}

	public event RoutedEventHandler Docked
	{
		add
		{
			AddHandler(DockedEvent, value);
		}
		remove
		{
			RemoveHandler(DockedEvent, value);
		}
	}

	static DockingManager()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0065: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01b4: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_01f5: Expected O, but got Unknown
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0236: Expected O, but got Unknown
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_0277: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Expected O, but got Unknown
		//IL_02b8: Expected O, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_032e: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Expected O, but got Unknown
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected O, but got Unknown
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Expected O, but got Unknown
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Expected O, but got Unknown
		//IL_04fa: Expected O, but got Unknown
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Expected O, but got Unknown
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		//IL_058f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0599: Expected O, but got Unknown
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f7: Expected O, but got Unknown
		//IL_0622: Unknown result type (might be due to invalid IL or missing references)
		//IL_062c: Expected O, but got Unknown
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Expected O, but got Unknown
		//IL_0721: Unknown result type (might be due to invalid IL or missing references)
		//IL_072d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Expected O, but got Unknown
		//IL_0737: Expected O, but got Unknown
		//IL_0762: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0778: Expected O, but got Unknown
		//IL_0778: Expected O, but got Unknown
		//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ff: Expected O, but got Unknown
		//IL_082a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0834: Expected O, but got Unknown
		AllowMovingFloatingWindowWithKeyboardProperty = DependencyProperty.Register("AllowMovingFloatingWindowWithKeyboard", typeof(bool), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		LayoutProperty = DependencyProperty.Register("Layout", typeof(LayoutRoot), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnLayoutChanged), new CoerceValueCallback(CoerceLayoutValue)));
		LayoutUpdateStrategyProperty = DependencyProperty.Register("LayoutUpdateStrategy", typeof(ILayoutUpdateStrategy), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		AnchorSideTemplateProperty = DependencyProperty.Register("AnchorSideTemplate", typeof(ControlTemplate), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		AnchorGroupTemplateProperty = DependencyProperty.Register("AnchorGroupTemplate", typeof(ControlTemplate), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		AnchorTemplateProperty = DependencyProperty.Register("AnchorTemplate", typeof(ControlTemplate), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		DocumentPaneControlStyleProperty = DependencyProperty.Register("DocumentPaneControlStyle", typeof(Style), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnDocumentPaneControlStyleChanged)));
		AnchorablePaneControlStyleProperty = DependencyProperty.Register("AnchorablePaneControlStyle", typeof(Style), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnAnchorablePaneControlStyleChanged)));
		DocumentHeaderTemplateProperty = DependencyProperty.Register("DocumentHeaderTemplate", typeof(DataTemplate), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnDocumentHeaderTemplateChanged), new CoerceValueCallback(CoerceDocumentHeaderTemplateValue)));
		DocumentHeaderTemplateSelectorProperty = DependencyProperty.Register("DocumentHeaderTemplateSelector", typeof(DataTemplateSelector), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnDocumentHeaderTemplateSelectorChanged), new CoerceValueCallback(CoerceDocumentHeaderTemplateSelectorValue)));
		DocumentTitleTemplateProperty = DependencyProperty.Register("DocumentTitleTemplate", typeof(DataTemplate), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnDocumentTitleTemplateChanged), new CoerceValueCallback(CoerceDocumentTitleTemplateValue)));
		DocumentTitleTemplateSelectorProperty = DependencyProperty.Register("DocumentTitleTemplateSelector", typeof(DataTemplateSelector), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnDocumentTitleTemplateSelectorChanged), new CoerceValueCallback(CoerceDocumentTitleTemplateSelectorValue)));
		AnchorableTitleTemplateProperty = DependencyProperty.Register("AnchorableTitleTemplate", typeof(DataTemplate), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnAnchorableTitleTemplateChanged), new CoerceValueCallback(CoerceAnchorableTitleTemplateValue)));
		AnchorableTitleTemplateSelectorProperty = DependencyProperty.Register("AnchorableTitleTemplateSelector", typeof(DataTemplateSelector), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnAnchorableTitleTemplateSelectorChanged)));
		AnchorableHeaderTemplateProperty = DependencyProperty.Register("AnchorableHeaderTemplate", typeof(DataTemplate), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnAnchorableHeaderTemplateChanged), new CoerceValueCallback(CoerceAnchorableHeaderTemplateValue)));
		AnchorableHeaderTemplateSelectorProperty = DependencyProperty.Register("AnchorableHeaderTemplateSelector", typeof(DataTemplateSelector), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnAnchorableHeaderTemplateSelectorChanged)));
		LayoutRootPanelProperty = DependencyProperty.Register("LayoutRootPanel", typeof(LayoutPanelControl), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnLayoutRootPanelChanged)));
		RightSidePanelProperty = DependencyProperty.Register("RightSidePanel", typeof(LayoutAnchorSideControl), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnRightSidePanelChanged)));
		LeftSidePanelProperty = DependencyProperty.Register("LeftSidePanel", typeof(LayoutAnchorSideControl), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnLeftSidePanelChanged)));
		TopSidePanelProperty = DependencyProperty.Register("TopSidePanel", typeof(LayoutAnchorSideControl), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnTopSidePanelChanged)));
		BottomSidePanelProperty = DependencyProperty.Register("BottomSidePanel", typeof(LayoutAnchorSideControl), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnBottomSidePanelChanged)));
		AutoHideWindowPropertyKey = DependencyProperty.RegisterReadOnly("AutoHideWindow", typeof(LayoutAutoHideWindowControl), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnAutoHideWindowChanged)));
		AutoHideWindowProperty = AutoHideWindowPropertyKey.DependencyProperty;
		AutoHideWindowClosingTimerProperty = DependencyProperty.Register("AutoHideWindowClosingTimer", typeof(int), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata(1500, new PropertyChangedCallback(OnAutoHideWindowClosingTimerChanged), new CoerceValueCallback(CoerceAutoHideWindowClosingTimer)));
		LayoutItemTemplateProperty = DependencyProperty.Register("LayoutItemTemplate", typeof(DataTemplate), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnLayoutItemTemplateChanged)));
		LayoutItemTemplateSelectorProperty = DependencyProperty.Register("LayoutItemTemplateSelector", typeof(DataTemplateSelector), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnLayoutItemTemplateSelectorChanged)));
		DocumentsSourceProperty = DependencyProperty.Register("DocumentsSource", typeof(IEnumerable), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnDocumentsSourceChanged)));
		DocumentContextMenuProperty = DependencyProperty.Register("DocumentContextMenu", typeof(ContextMenu), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		AnchorablesSourceProperty = DependencyProperty.Register("AnchorablesSource", typeof(IEnumerable), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnAnchorablesSourceChanged)));
		ActiveContentProperty = DependencyProperty.Register("ActiveContent", typeof(object), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnActiveContentChanged)));
		AnchorableContextMenuProperty = DependencyProperty.Register("AnchorableContextMenu", typeof(ContextMenu), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		ThemeProperty = DependencyProperty.Register("Theme", typeof(Theme), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnThemeChanged)));
		GridSplitterWidthProperty = DependencyProperty.Register("GridSplitterWidth", typeof(double), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)6.0));
		GridSplitterHeightProperty = DependencyProperty.Register("GridSplitterHeight", typeof(double), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)6.0));
		DocumentPaneMenuItemHeaderTemplateProperty = DependencyProperty.Register("DocumentPaneMenuItemHeaderTemplate", typeof(DataTemplate), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnDocumentPaneMenuItemHeaderTemplateChanged), new CoerceValueCallback(CoerceDocumentPaneMenuItemHeaderTemplateValue)));
		DocumentPaneMenuItemHeaderTemplateSelectorProperty = DependencyProperty.Register("DocumentPaneMenuItemHeaderTemplateSelector", typeof(DataTemplateSelector), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnDocumentPaneMenuItemHeaderTemplateSelectorChanged), new CoerceValueCallback(CoerceDocumentPaneMenuItemHeaderTemplateSelectorValue)));
		IconContentTemplateProperty = DependencyProperty.Register("IconContentTemplate", typeof(DataTemplate), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		IconContentTemplateSelectorProperty = DependencyProperty.Register("IconContentTemplateSelector", typeof(DataTemplateSelector), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		LayoutItemContainerStyleProperty = DependencyProperty.Register("LayoutItemContainerStyle", typeof(Style), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnLayoutItemContainerStyleChanged)));
		LayoutItemContainerStyleSelectorProperty = DependencyProperty.Register("LayoutItemContainerStyleSelector", typeof(StyleSelector), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnLayoutItemContainerStyleSelectorChanged)));
		ShowSystemMenuProperty = DependencyProperty.Register("ShowSystemMenu", typeof(bool), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		AllowMixedOrientationProperty = DependencyProperty.Register("AllowMixedOrientation", typeof(bool), typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		PreviewFloatEvent = EventManager.RegisterRoutedEvent("PreviewFloat", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DockingManager));
		FloatedEvent = EventManager.RegisterRoutedEvent("Floated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DockingManager));
		PreviewDockEvent = EventManager.RegisterRoutedEvent("PreviewDock", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DockingManager));
		DockedEvent = EventManager.RegisterRoutedEvent("Docked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DockingManager));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(DockingManager)));
		UIElement.FocusableProperty.OverrideMetadata(typeof(DockingManager), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		HwndSource.DefaultAcquireHwndFocusInMenuMode = false;
	}

	public DockingManager()
	{
		Layout = new LayoutRoot
		{
			RootPanel = new LayoutPanel(new LayoutDocumentPaneGroup(new LayoutDocumentPane()))
		};
		base.Loaded += DockingManager_Loaded;
		base.Unloaded += DockingManager_Unloaded;
	}

	private static object CoerceLayoutValue(DependencyObject d, object value)
	{
		if (value == null)
		{
			return new LayoutRoot
			{
				RootPanel = new LayoutPanel(new LayoutDocumentPaneGroup(new LayoutDocumentPane()))
			};
		}
		((DockingManager)(object)d).OnLayoutChanging(value as LayoutRoot);
		return value;
	}

	private static void OnLayoutChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DockingManager)(object)d).OnLayoutChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as LayoutRoot, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as LayoutRoot);
	}

	protected virtual void OnLayoutChanged(LayoutRoot oldLayout, LayoutRoot newLayout)
	{
		if (oldLayout != null)
		{
			oldLayout.PropertyChanged -= OnLayoutRootPropertyChanged;
			oldLayout.Updated -= OnLayoutRootUpdated;
		}
		LayoutFloatingWindowControl[] array = _fwList.ToArray();
		foreach (LayoutFloatingWindowControl obj in array)
		{
			obj.KeepContentVisibleOnClose = true;
			obj.InternalClose();
		}
		_fwList.Clear();
		DetachDocumentsSource(oldLayout, DocumentsSource);
		DetachAnchorablesSource(oldLayout, AnchorablesSource);
		if (oldLayout != null && oldLayout.Manager == this)
		{
			oldLayout.Manager = null;
		}
		ClearLogicalChildrenList();
		DetachLayoutItems();
		Layout.Manager = this;
		AttachLayoutItems();
		AttachDocumentsSource(newLayout, DocumentsSource);
		AttachAnchorablesSource(newLayout, AnchorablesSource);
		if (base.IsLoaded)
		{
			LayoutRootPanel = CreateUIElementForModel(Layout.RootPanel) as LayoutPanelControl;
			LeftSidePanel = CreateUIElementForModel(Layout.LeftSide) as LayoutAnchorSideControl;
			TopSidePanel = CreateUIElementForModel(Layout.TopSide) as LayoutAnchorSideControl;
			RightSidePanel = CreateUIElementForModel(Layout.RightSide) as LayoutAnchorSideControl;
			BottomSidePanel = CreateUIElementForModel(Layout.BottomSide) as LayoutAnchorSideControl;
			LayoutFloatingWindow[] array2 = Layout.FloatingWindows.ToArray();
			foreach (LayoutFloatingWindow layoutFloatingWindow in array2)
			{
				if (layoutFloatingWindow.IsValid)
				{
					_fwList.Add(CreateUIElementForModel(layoutFloatingWindow) as LayoutFloatingWindowControl);
				}
			}
			foreach (LayoutFloatingWindowControl fw in _fwList)
			{
				_ = fw;
			}
		}
		if (newLayout != null)
		{
			newLayout.PropertyChanged += OnLayoutRootPropertyChanged;
			newLayout.Updated += OnLayoutRootUpdated;
		}
		if (this.LayoutChanged != null)
		{
			this.LayoutChanged(this, EventArgs.Empty);
		}
		CommandManager.InvalidateRequerySuggested();
	}

	private static void OnDocumentPaneControlStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnDocumentPaneControlStyleChanged(e);
	}

	protected virtual void OnDocumentPaneControlStyleChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static void OnAnchorablePaneControlStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnAnchorablePaneControlStyleChanged(e);
	}

	protected virtual void OnAnchorablePaneControlStyleChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static void OnDocumentHeaderTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnDocumentHeaderTemplateChanged(e);
	}

	protected virtual void OnDocumentHeaderTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceDocumentHeaderTemplateValue(DependencyObject d, object value)
	{
		if (value != null && d.GetValue(DocumentHeaderTemplateSelectorProperty) != null)
		{
			return null;
		}
		return value;
	}

	private static void OnDocumentHeaderTemplateSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnDocumentHeaderTemplateSelectorChanged(e);
	}

	protected virtual void OnDocumentHeaderTemplateSelectorChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null && DocumentHeaderTemplate != null)
		{
			DocumentHeaderTemplate = null;
		}
		if (DocumentPaneMenuItemHeaderTemplateSelector == null)
		{
			DocumentPaneMenuItemHeaderTemplateSelector = DocumentHeaderTemplateSelector;
		}
	}

	private static object CoerceDocumentHeaderTemplateSelectorValue(DependencyObject d, object value)
	{
		return value;
	}

	private static void OnDocumentTitleTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnDocumentTitleTemplateChanged(e);
	}

	protected virtual void OnDocumentTitleTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceDocumentTitleTemplateValue(DependencyObject d, object value)
	{
		if (value != null && d.GetValue(DocumentTitleTemplateSelectorProperty) != null)
		{
			return null;
		}
		return value;
	}

	private static void OnDocumentTitleTemplateSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnDocumentTitleTemplateSelectorChanged(e);
	}

	protected virtual void OnDocumentTitleTemplateSelectorChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			DocumentTitleTemplate = null;
		}
	}

	private static object CoerceDocumentTitleTemplateSelectorValue(DependencyObject d, object value)
	{
		return value;
	}

	private static void OnAnchorableTitleTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnAnchorableTitleTemplateChanged(e);
	}

	protected virtual void OnAnchorableTitleTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceAnchorableTitleTemplateValue(DependencyObject d, object value)
	{
		if (value != null && d.GetValue(AnchorableTitleTemplateSelectorProperty) != null)
		{
			return null;
		}
		return value;
	}

	private static void OnAnchorableTitleTemplateSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnAnchorableTitleTemplateSelectorChanged(e);
	}

	protected virtual void OnAnchorableTitleTemplateSelectorChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null && AnchorableTitleTemplate != null)
		{
			AnchorableTitleTemplate = null;
		}
	}

	private static void OnAnchorableHeaderTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnAnchorableHeaderTemplateChanged(e);
	}

	protected virtual void OnAnchorableHeaderTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceAnchorableHeaderTemplateValue(DependencyObject d, object value)
	{
		if (value != null && d.GetValue(AnchorableHeaderTemplateSelectorProperty) != null)
		{
			return null;
		}
		return value;
	}

	private static void OnAnchorableHeaderTemplateSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnAnchorableHeaderTemplateSelectorChanged(e);
	}

	protected virtual void OnAnchorableHeaderTemplateSelectorChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			AnchorableHeaderTemplate = null;
		}
	}

	private static void OnLayoutRootPanelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnLayoutRootPanelChanged(e);
	}

	protected virtual void OnLayoutRootPanelChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue != null)
		{
			InternalRemoveLogicalChild(((DependencyPropertyChangedEventArgs)(ref e)).OldValue);
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			InternalAddLogicalChild(((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private static void OnRightSidePanelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnRightSidePanelChanged(e);
	}

	protected virtual void OnRightSidePanelChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue != null)
		{
			InternalRemoveLogicalChild(((DependencyPropertyChangedEventArgs)(ref e)).OldValue);
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			InternalAddLogicalChild(((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private static void OnLeftSidePanelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnLeftSidePanelChanged(e);
	}

	protected virtual void OnLeftSidePanelChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue != null)
		{
			InternalRemoveLogicalChild(((DependencyPropertyChangedEventArgs)(ref e)).OldValue);
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			InternalAddLogicalChild(((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private static void OnTopSidePanelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnTopSidePanelChanged(e);
	}

	protected virtual void OnTopSidePanelChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue != null)
		{
			InternalRemoveLogicalChild(((DependencyPropertyChangedEventArgs)(ref e)).OldValue);
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			InternalAddLogicalChild(((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private static void OnBottomSidePanelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnBottomSidePanelChanged(e);
	}

	protected virtual void OnBottomSidePanelChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue != null)
		{
			InternalRemoveLogicalChild(((DependencyPropertyChangedEventArgs)(ref e)).OldValue);
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			InternalAddLogicalChild(((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	internal void InternalAddLogicalChild(object element)
	{
		if (!_logicalChildren.Select((WeakReference ch) => ch.GetValueOrDefault<object>()).Contains(element))
		{
			_logicalChildren.Add(new WeakReference(element));
			AddLogicalChild(element);
		}
	}

	internal void InternalRemoveLogicalChild(object element)
	{
		WeakReference weakReference = _logicalChildren.FirstOrDefault((WeakReference ch) => ch.GetValueOrDefault<object>() == element);
		if (weakReference != null)
		{
			_logicalChildren.Remove(weakReference);
		}
		RemoveLogicalChild(element);
	}

	private void ClearLogicalChildrenList()
	{
		object[] array = _logicalChildren.Select((WeakReference ch) => ch.GetValueOrDefault<object>()).ToArray();
		foreach (object child in array)
		{
			RemoveLogicalChild(child);
		}
		_logicalChildren.Clear();
	}

	protected void SetAutoHideWindow(LayoutAutoHideWindowControl value)
	{
		((DependencyObject)this).SetValue(AutoHideWindowPropertyKey, (object)value);
	}

	private static void OnAutoHideWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnAutoHideWindowChanged(e);
	}

	protected virtual void OnAutoHideWindowChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue != null)
		{
			InternalRemoveLogicalChild(((DependencyPropertyChangedEventArgs)(ref e)).OldValue);
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			InternalAddLogicalChild(((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private static void OnAutoHideWindowClosingTimerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnAutoHideWindowClosingTimerChanged(e);
	}

	protected virtual void OnAutoHideWindowClosingTimerChanged(DependencyPropertyChangedEventArgs e)
	{
		if (_autoHideWindowManager != null)
		{
			_autoHideWindowManager.UpdateCloseTimerInterval((int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private static object CoerceAutoHideWindowClosingTimer(DependencyObject d, object value)
	{
		if ((int)value >= 0)
		{
			return value;
		}
		return 1500;
	}

	private static void OnLayoutItemTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnLayoutItemTemplateChanged(e);
	}

	protected virtual void OnLayoutItemTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static void OnLayoutItemTemplateSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnLayoutItemTemplateSelectorChanged(e);
	}

	protected virtual void OnLayoutItemTemplateSelectorChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static void OnDocumentsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnDocumentsSourceChanged(e);
	}

	protected virtual void OnDocumentsSourceChanged(DependencyPropertyChangedEventArgs e)
	{
		DetachDocumentsSource(Layout, ((DependencyPropertyChangedEventArgs)(ref e)).OldValue as IEnumerable);
		AttachDocumentsSource(Layout, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as IEnumerable);
	}

	private static void OnAnchorablesSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnAnchorablesSourceChanged(e);
	}

	protected virtual void OnAnchorablesSourceChanged(DependencyPropertyChangedEventArgs e)
	{
		DetachAnchorablesSource(Layout, ((DependencyPropertyChangedEventArgs)(ref e)).OldValue as IEnumerable);
		AttachAnchorablesSource(Layout, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as IEnumerable);
	}

	private static void OnActiveContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).InternalSetActiveContent(((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		((DockingManager)(object)d).OnActiveContentChanged(e);
	}

	protected virtual void OnActiveContentChanged(DependencyPropertyChangedEventArgs e)
	{
		if (this.ActiveContentChanged != null)
		{
			this.ActiveContentChanged(this, EventArgs.Empty);
		}
	}

	private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnThemeChanged(e);
	}

	protected virtual void OnThemeChanged(DependencyPropertyChangedEventArgs e)
	{
		Theme oldTheme = ((DependencyPropertyChangedEventArgs)(ref e)).OldValue as Theme;
		Theme theme = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as Theme;
		ResourceDictionary resources = base.Resources;
		if (oldTheme != null)
		{
			if (oldTheme is DictionaryTheme)
			{
				if (currentThemeResourceDictionary != null)
				{
					resources.MergedDictionaries.Remove(currentThemeResourceDictionary);
					currentThemeResourceDictionary = null;
				}
			}
			else
			{
				ResourceDictionary resourceDictionary = resources.MergedDictionaries.FirstOrDefault((ResourceDictionary r) => r.Source == oldTheme.GetResourceUri());
				if (resourceDictionary != null)
				{
					resources.MergedDictionaries.Remove(resourceDictionary);
				}
			}
		}
		if (theme != null)
		{
			if (theme is DictionaryTheme)
			{
				currentThemeResourceDictionary = ((DictionaryTheme)theme).ThemeResourceDictionary;
				resources.MergedDictionaries.Add(currentThemeResourceDictionary);
			}
			else
			{
				resources.MergedDictionaries.Add(new ResourceDictionary
				{
					Source = theme.GetResourceUri()
				});
			}
		}
		foreach (LayoutFloatingWindowControl fw in _fwList)
		{
			fw.UpdateThemeResources(oldTheme);
		}
		if (_navigatorWindow != null)
		{
			_navigatorWindow.UpdateThemeResources();
		}
		if (_overlayWindow != null)
		{
			_overlayWindow.UpdateThemeResources();
		}
	}

	private static void OnDocumentPaneMenuItemHeaderTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnDocumentPaneMenuItemHeaderTemplateChanged(e);
	}

	protected virtual void OnDocumentPaneMenuItemHeaderTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceDocumentPaneMenuItemHeaderTemplateValue(DependencyObject d, object value)
	{
		if (value != null && d.GetValue(DocumentPaneMenuItemHeaderTemplateSelectorProperty) != null)
		{
			return null;
		}
		if (value == null)
		{
			return d.GetValue(DocumentHeaderTemplateProperty);
		}
		return value;
	}

	private static void OnDocumentPaneMenuItemHeaderTemplateSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnDocumentPaneMenuItemHeaderTemplateSelectorChanged(e);
	}

	protected virtual void OnDocumentPaneMenuItemHeaderTemplateSelectorChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null && DocumentPaneMenuItemHeaderTemplate != null)
		{
			DocumentPaneMenuItemHeaderTemplate = null;
		}
	}

	private static object CoerceDocumentPaneMenuItemHeaderTemplateSelectorValue(DependencyObject d, object value)
	{
		return value;
	}

	private static void OnLayoutItemContainerStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnLayoutItemContainerStyleChanged(e);
	}

	protected virtual void OnLayoutItemContainerStyleChanged(DependencyPropertyChangedEventArgs e)
	{
		AttachLayoutItems();
	}

	private static void OnLayoutItemContainerStyleSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((DockingManager)(object)d).OnLayoutItemContainerStyleSelectorChanged(e);
	}

	protected virtual void OnLayoutItemContainerStyleSelectorChanged(DependencyPropertyChangedEventArgs e)
	{
		AttachLayoutItems();
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_autohideArea = GetTemplateChild("PART_AutoHideArea") as FrameworkElement;
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
	}

	protected override Size ArrangeOverride(Size arrangeBounds)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_areas = null;
		return base.ArrangeOverride(arrangeBounds);
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		if ((Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)) && e.IsDown && (int)e.Key == 3 && !IsNavigatorWindowActive)
		{
			ShowNavigatorWindow();
			e.Handled = true;
		}
		base.OnPreviewKeyDown(e);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if ((Keyboard.IsKeyDown((Key)116) || Keyboard.IsKeyDown((Key)117)) && e.IsDown && Keyboard.IsKeyDown((Key)99))
		{
			object activeContent = ActiveContent;
			DependencyObject val = (DependencyObject)((activeContent is DependencyObject) ? activeContent : null);
			while (val != null)
			{
				val = VisualTreeHelper.GetParent(val);
				if (val is LayoutDocumentControl || val is LayoutAnchorableControl)
				{
					break;
				}
			}
			if (val != null)
			{
				if (val is LayoutDocumentControl layoutDocumentControl && DocumentContextMenu != null)
				{
					DocumentContextMenu.PlacementTarget = layoutDocumentControl;
					DocumentContextMenu.Placement = PlacementMode.Relative;
					DocumentContextMenu.DataContext = layoutDocumentControl.LayoutItem;
					DocumentContextMenu.IsOpen = true;
				}
				else if (val is LayoutAnchorableControl layoutAnchorableControl && AnchorableContextMenu != null)
				{
					AnchorableContextMenu.PlacementTarget = layoutAnchorableControl;
					AnchorableContextMenu.Placement = PlacementMode.Relative;
					AnchorableContextMenu.DataContext = layoutAnchorableControl.LayoutItem;
					AnchorableContextMenu.Opened += AnchorableContextMenu_Opened;
					AnchorableContextMenu.IsOpen = true;
				}
			}
		}
		base.OnKeyDown(e);
	}

	public virtual NavigatorWindow CreateNavigatorWindow()
	{
		return new NavigatorWindow(this);
	}

	public LayoutItem GetLayoutItemFromModel(LayoutContent content)
	{
		if (_layoutItems == null)
		{
			return null;
		}
		return _layoutItems.FirstOrDefault((LayoutItem item) => item.LayoutElement == content);
	}

	public LayoutFloatingWindowControl CreateFloatingWindow(LayoutContent contentModel, bool isContentImmutable)
	{
		LayoutFloatingWindowControl layoutFloatingWindowControl = null;
		if (contentModel is LayoutAnchorable && !(contentModel.Parent is ILayoutPane))
		{
			LayoutAnchorablePane paneModel = new LayoutAnchorablePane(contentModel as LayoutAnchorable)
			{
				FloatingTop = contentModel.FloatingTop,
				FloatingLeft = contentModel.FloatingLeft,
				FloatingWidth = contentModel.FloatingWidth,
				FloatingHeight = contentModel.FloatingHeight
			};
			layoutFloatingWindowControl = CreateFloatingWindowForLayoutAnchorableWithoutParent(paneModel, isContentImmutable);
		}
		if (layoutFloatingWindowControl == null)
		{
			layoutFloatingWindowControl = CreateFloatingWindowCore(contentModel, isContentImmutable);
		}
		return layoutFloatingWindowControl;
	}

	internal UIElement CreateUIElementForModel(ILayoutElement model)
	{
		if (model is LayoutPanel)
		{
			return new LayoutPanelControl(model as LayoutPanel);
		}
		if (model is LayoutAnchorablePaneGroup)
		{
			return new LayoutAnchorablePaneGroupControl(model as LayoutAnchorablePaneGroup);
		}
		if (model is LayoutDocumentPaneGroup)
		{
			return new LayoutDocumentPaneGroupControl(model as LayoutDocumentPaneGroup);
		}
		if (model is LayoutAnchorSide)
		{
			LayoutAnchorSideControl layoutAnchorSideControl = new LayoutAnchorSideControl(model as LayoutAnchorSide);
			layoutAnchorSideControl.SetBinding(Control.TemplateProperty, new Binding(AnchorSideTemplateProperty.Name)
			{
				Source = this
			});
			return layoutAnchorSideControl;
		}
		if (model is LayoutAnchorGroup)
		{
			LayoutAnchorGroupControl layoutAnchorGroupControl = new LayoutAnchorGroupControl(model as LayoutAnchorGroup);
			layoutAnchorGroupControl.SetBinding(Control.TemplateProperty, new Binding(AnchorGroupTemplateProperty.Name)
			{
				Source = this
			});
			return layoutAnchorGroupControl;
		}
		if (model is LayoutDocumentPane)
		{
			LayoutDocumentPaneControl layoutDocumentPaneControl = new LayoutDocumentPaneControl(model as LayoutDocumentPane);
			layoutDocumentPaneControl.SetBinding(FrameworkElement.StyleProperty, new Binding(DocumentPaneControlStyleProperty.Name)
			{
				Source = this
			});
			return layoutDocumentPaneControl;
		}
		if (model is LayoutAnchorablePane)
		{
			LayoutAnchorablePaneControl layoutAnchorablePaneControl = new LayoutAnchorablePaneControl(model as LayoutAnchorablePane);
			layoutAnchorablePaneControl.SetBinding(FrameworkElement.StyleProperty, new Binding(AnchorablePaneControlStyleProperty.Name)
			{
				Source = this
			});
			return layoutAnchorablePaneControl;
		}
		if (model is LayoutAnchorableFloatingWindow)
		{
			if (DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this))
			{
				return null;
			}
			LayoutAnchorableFloatingWindow layoutAnchorableFloatingWindow = model as LayoutAnchorableFloatingWindow;
			LayoutAnchorableFloatingWindowControl newFW = new LayoutAnchorableFloatingWindowControl(layoutAnchorableFloatingWindow);
			newFW.SetParentToMainWindowOf(this);
			for (FrameworkElement frameworkElement = base.Parent as FrameworkElement; frameworkElement != null; frameworkElement = frameworkElement.Parent as FrameworkElement)
			{
				newFW.InputBindings.AddRange(frameworkElement.InputBindings);
			}
			LayoutAnchorablePane paneForExtensions = layoutAnchorableFloatingWindow.RootPanel.Descendents().OfType<LayoutAnchorablePane>().FirstOrDefault();
			if (paneForExtensions != null)
			{
				paneForExtensions.KeepInsideNearestMonitor();
				newFW.Left = paneForExtensions.FloatingLeft;
				newFW.Top = paneForExtensions.FloatingTop;
				newFW.Width = paneForExtensions.FloatingWidth;
				newFW.Height = paneForExtensions.FloatingHeight;
			}
			newFW.ShowInTaskbar = false;
			((DispatcherObject)this).Dispatcher.BeginInvoke((Delegate)(Action)delegate
			{
				if (!newFW.IsClosing())
				{
					newFW.Show();
					if (paneForExtensions != null && paneForExtensions.IsMaximized)
					{
						newFW.WindowState = WindowState.Maximized;
					}
				}
			}, (DispatcherPriority)8, Array.Empty<object>());
			return newFW;
		}
		if (model is LayoutDocumentFloatingWindow)
		{
			if (DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this))
			{
				return null;
			}
			LayoutDocumentFloatingWindow layoutDocumentFloatingWindow = model as LayoutDocumentFloatingWindow;
			LayoutDocumentFloatingWindowControl layoutDocumentFloatingWindowControl = new LayoutDocumentFloatingWindowControl(layoutDocumentFloatingWindow);
			layoutDocumentFloatingWindowControl.SetParentToMainWindowOf(this);
			for (FrameworkElement frameworkElement2 = base.Parent as FrameworkElement; frameworkElement2 != null; frameworkElement2 = frameworkElement2.Parent as FrameworkElement)
			{
				layoutDocumentFloatingWindowControl.InputBindings.AddRange(frameworkElement2.InputBindings);
			}
			LayoutDocument rootDocument = layoutDocumentFloatingWindow.RootDocument;
			if (rootDocument != null)
			{
				rootDocument.KeepInsideNearestMonitor();
				layoutDocumentFloatingWindowControl.Left = rootDocument.FloatingLeft;
				layoutDocumentFloatingWindowControl.Top = rootDocument.FloatingTop;
				layoutDocumentFloatingWindowControl.Width = rootDocument.FloatingWidth;
				layoutDocumentFloatingWindowControl.Height = rootDocument.FloatingHeight;
			}
			layoutDocumentFloatingWindowControl.ShowInTaskbar = false;
			layoutDocumentFloatingWindowControl.Show();
			if (rootDocument != null && rootDocument.IsMaximized)
			{
				layoutDocumentFloatingWindowControl.WindowState = WindowState.Maximized;
			}
			return layoutDocumentFloatingWindowControl;
		}
		if (model is LayoutDocument)
		{
			LayoutDocumentControl layoutDocumentControl = new LayoutDocumentControl();
			layoutDocumentControl.Model = model as LayoutDocument;
			layoutDocumentControl.SetResourcesFromObject(this);
			return layoutDocumentControl;
		}
		return null;
	}

	internal void ShowAutoHideWindow(LayoutAnchorControl anchor)
	{
		_autoHideWindowManager.ShowAutoHideWindow(anchor);
	}

	internal void HideAutoHideWindow(LayoutAnchorControl anchor)
	{
		_autoHideWindowManager.HideAutoWindow(anchor);
	}

	internal FrameworkElement GetAutoHideAreaElement()
	{
		return _autohideArea;
	}

	internal void StartDraggingFloatingWindowForContent(LayoutContent contentModel, bool startDrag = true)
	{
		if (contentModel == null || !contentModel.CanFloat)
		{
			return;
		}
		LayoutFloatingWindowControl fwc = CreateFloatingWindow(contentModel, isContentImmutable: false);
		if (fwc == null)
		{
			return;
		}
		((DispatcherObject)this).Dispatcher.BeginInvoke((Delegate)(Action)delegate
		{
			if (!fwc.IsClosing())
			{
				if (startDrag)
				{
					fwc.AttachDrag();
				}
				fwc.Show();
			}
		}, (DispatcherPriority)10, Array.Empty<object>());
	}

	internal void StartDraggingFloatingWindowForPane(LayoutAnchorablePane paneModel)
	{
		LayoutFloatingWindowControl layoutFloatingWindowControl = CreateFloatingWindowForLayoutAnchorableWithoutParent(paneModel, isContentImmutable: false);
		if (layoutFloatingWindowControl != null)
		{
			layoutFloatingWindowControl.AttachDrag();
			layoutFloatingWindowControl.Show();
		}
	}

	internal IEnumerable<LayoutFloatingWindowControl> GetFloatingWindowsByZOrder()
	{
		Window window = Window.GetWindow((DependencyObject)(object)this);
		IntPtr hWnd;
		if (window != null)
		{
			hWnd = new WindowInteropHelper(window).Handle;
		}
		else
		{
			Process currentProcess = Process.GetCurrentProcess();
			if (currentProcess == null)
			{
				yield break;
			}
			hWnd = currentProcess.MainWindowHandle;
		}
		IntPtr currentHandle = Win32Helper.GetWindow(hWnd, 0u);
		while (currentHandle != IntPtr.Zero)
		{
			LayoutFloatingWindowControl layoutFloatingWindowControl = _fwList.FirstOrDefault((LayoutFloatingWindowControl fw) => new WindowInteropHelper(fw).Handle == currentHandle);
			if (layoutFloatingWindowControl != null && layoutFloatingWindowControl.Model.Root.Manager == this)
			{
				yield return layoutFloatingWindowControl;
			}
			currentHandle = Win32Helper.GetWindow(currentHandle, 2u);
		}
	}

	internal IEnumerable<Window> GetWindowsByZOrder()
	{
		Window parentWindow = Window.GetWindow((DependencyObject)(object)this);
		IntPtr windowParentHanlde;
		if (parentWindow != null)
		{
			windowParentHanlde = new WindowInteropHelper(parentWindow).Handle;
		}
		else
		{
			Process currentProcess = Process.GetCurrentProcess();
			if (currentProcess == null)
			{
				yield break;
			}
			windowParentHanlde = currentProcess.MainWindowHandle;
		}
		IntPtr currentHandle = Win32Helper.GetWindow(windowParentHanlde, 0u);
		while (currentHandle != IntPtr.Zero)
		{
			if (windowParentHanlde == currentHandle)
			{
				yield return parentWindow;
			}
			else
			{
				LayoutFloatingWindowControl layoutFloatingWindowControl = _fwList.FirstOrDefault((LayoutFloatingWindowControl fw) => new WindowInteropHelper(fw).Handle == currentHandle);
				if (layoutFloatingWindowControl != null && layoutFloatingWindowControl.Model.Root.Manager == this)
				{
					yield return layoutFloatingWindowControl;
				}
			}
			currentHandle = Win32Helper.GetWindow(currentHandle, 2u);
		}
	}

	internal void RemoveFloatingWindow(LayoutFloatingWindowControl floatingWindow)
	{
		_fwList.Remove(floatingWindow);
	}

	internal void _ExecuteCloseCommand(LayoutDocument document)
	{
		if (this.DocumentClosing != null)
		{
			DocumentClosingEventArgs e = new DocumentClosingEventArgs(document);
			this.DocumentClosing(this, e);
			if (e.Cancel)
			{
				return;
			}
		}
		if (document.CloseDocument())
		{
			RemoveViewFromLogicalChild(document);
			if (this.DocumentClosed != null)
			{
				DocumentClosedEventArgs e2 = new DocumentClosedEventArgs(document);
				this.DocumentClosed(this, e2);
			}
		}
	}

	internal void _ExecuteCloseAllButThisCommand(LayoutContent contentSelected)
	{
		LayoutContent[] array = (from d in Layout.Descendents().OfType<LayoutContent>()
			where d != contentSelected && (d.Parent is LayoutDocumentPane || d.Parent is LayoutDocumentFloatingWindow)
			select d).ToArray();
		foreach (LayoutContent contentToClose in array)
		{
			Close(contentToClose);
		}
	}

	internal void _ExecuteCloseAllCommand(LayoutContent contentSelected)
	{
		LayoutContent[] array = (from d in Layout.Descendents().OfType<LayoutContent>()
			where d.Parent is LayoutDocumentPane || d.Parent is LayoutDocumentFloatingWindow
			select d).ToArray();
		foreach (LayoutContent contentToClose in array)
		{
			Close(contentToClose);
		}
	}

	internal void _ExecuteCloseCommand(LayoutAnchorable anchorable)
	{
		if (anchorable != null && anchorable.CloseAnchorable())
		{
			RemoveViewFromLogicalChild(anchorable);
		}
	}

	internal void _ExecuteHideCommand(LayoutAnchorable anchorable)
	{
		anchorable?.Hide();
	}

	internal void _ExecuteAutoHideCommand(LayoutAnchorable _anchorable)
	{
		_anchorable.ToggleAutoHide();
	}

	internal void _ExecuteFloatCommand(LayoutContent contentToFloat)
	{
		contentToFloat.Float();
	}

	internal void _ExecuteDockCommand(LayoutAnchorable anchorable)
	{
		anchorable.Dock();
	}

	internal void _ExecuteDockAsDocumentCommand(LayoutContent content)
	{
		content.DockAsDocument();
	}

	internal void _ExecuteContentActivateCommand(LayoutContent content)
	{
		content.IsActive = true;
	}

	protected internal virtual void ShowNavigatorWindow()
	{
		if (_navigatorWindow == null)
		{
			_navigatorWindow = CreateNavigatorWindow();
			_navigatorWindow.Owner = Window.GetWindow((DependencyObject)(object)this);
			_navigatorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
		}
		_navigatorWindow.ShowDialog();
		_navigatorWindow = null;
	}

	private void OnLayoutRootPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "RootPanel")
		{
			if (base.IsInitialized)
			{
				LayoutPanelControl layoutRootPanel = CreateUIElementForModel(Layout.RootPanel) as LayoutPanelControl;
				LayoutRootPanel = layoutRootPanel;
			}
		}
		else if (e.PropertyName == "ActiveContent")
		{
			if (Layout.ActiveContent != null && Layout.ActiveContent != null)
			{
				FocusElementManager.SetFocusOnLastElement(Layout.ActiveContent);
			}
			if (!_insideInternalSetActiveContent)
			{
				((DependencyObject)this).SetCurrentValue(ActiveContentProperty, (object)((Layout.ActiveContent != null) ? Layout.ActiveContent : null));
			}
		}
	}

	private void OnLayoutRootUpdated(object sender, EventArgs e)
	{
		CommandManager.InvalidateRequerySuggested();
	}

	private void OnLayoutChanging(LayoutRoot newLayout)
	{
		if (this.LayoutChanging != null)
		{
			this.LayoutChanging(this, EventArgs.Empty);
		}
	}

	private void DockingManager_Loaded(object sender, RoutedEventArgs e)
	{
		if (DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this))
		{
			return;
		}
		if (Layout.Manager == this)
		{
			LayoutRootPanel = CreateUIElementForModel(Layout.RootPanel) as LayoutPanelControl;
			LeftSidePanel = CreateUIElementForModel(Layout.LeftSide) as LayoutAnchorSideControl;
			TopSidePanel = CreateUIElementForModel(Layout.TopSide) as LayoutAnchorSideControl;
			RightSidePanel = CreateUIElementForModel(Layout.RightSide) as LayoutAnchorSideControl;
			BottomSidePanel = CreateUIElementForModel(Layout.BottomSide) as LayoutAnchorSideControl;
		}
		SetupAutoHideWindow();
		foreach (LayoutFloatingWindow item in Layout.FloatingWindows.Where((LayoutFloatingWindow fw) => !_fwList.Any((LayoutFloatingWindowControl fwc) => fwc.Model == fw)))
		{
			_fwList.Add(CreateUIElementForModel(item) as LayoutFloatingWindowControl);
		}
		if (base.IsVisible)
		{
			CreateOverlayWindow();
		}
		FocusElementManager.SetupFocusManagement(this);
	}

	private void DockingManager_Unloaded(object sender, RoutedEventArgs e)
	{
		if (DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this))
		{
			return;
		}
		if (_autoHideWindowManager != null)
		{
			_autoHideWindowManager.HideAutoWindow();
		}
		if (AutoHideWindow != null)
		{
			AutoHideWindow.Dispose();
		}
		LayoutFloatingWindowControl[] array = _fwList.ToArray();
		foreach (LayoutFloatingWindowControl fw in array)
		{
			fw.SetParentWindowToNull();
			fw.KeepContentVisibleOnClose = true;
			((DispatcherObject)this).Dispatcher.BeginInvoke((Delegate)(Action)delegate
			{
				fw.Close();
			}, (DispatcherPriority)10, Array.Empty<object>());
		}
		_fwList.Clear();
		DestroyOverlayWindow();
		FocusElementManager.FinalizeFocusManagement(this);
	}

	private void SetupAutoHideWindow()
	{
		if (_autoHideWindowManager != null)
		{
			_autoHideWindowManager.HideAutoWindow();
		}
		else
		{
			_autoHideWindowManager = new AutoHideWindowManager(this);
		}
		if (AutoHideWindow != null)
		{
			AutoHideWindow.Dispose();
		}
		SetAutoHideWindow(new LayoutAutoHideWindowControl());
	}

	private void CreateOverlayWindow()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (_overlayWindow == null)
		{
			_overlayWindow = new OverlayWindow(this);
		}
		Rect val = default(Rect);
		((Rect)(ref val))._002Ector(this.PointToScreenDPIWithoutFlowDirection(default(Point)), this.TransformActualSizeToAncestor());
		_overlayWindow.Left = ((Rect)(ref val)).Left;
		_overlayWindow.Top = ((Rect)(ref val)).Top;
		_overlayWindow.Width = ((Rect)(ref val)).Width;
		_overlayWindow.Height = ((Rect)(ref val)).Height;
	}

	private void DestroyOverlayWindow()
	{
		if (_overlayWindow != null)
		{
			_overlayWindow.Close();
			_overlayWindow = null;
		}
	}

	private void AttachDocumentsSource(LayoutRoot layout, IEnumerable documentsSource)
	{
		if (documentsSource == null || layout == null)
		{
			return;
		}
		object[] collection = (from d in layout.Descendents().OfType<LayoutDocument>()
			select d.Content).ToArray();
		List<object> list = new List<object>(documentsSource.OfType<object>());
		object[] array = list.ToArray();
		foreach (object item in array)
		{
			if (collection.Contains(item))
			{
				list.Remove(item);
			}
		}
		LayoutDocumentPane layoutDocumentPane = null;
		if (layout.LastFocusedDocument != null)
		{
			layoutDocumentPane = layout.LastFocusedDocument.Parent as LayoutDocumentPane;
		}
		if (layoutDocumentPane == null)
		{
			layoutDocumentPane = layout.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();
		}
		_suspendLayoutItemCreation = true;
		foreach (object item2 in list)
		{
			LayoutDocument layoutDocument = new LayoutDocument
			{
				Content = item2,
				ContentId = Guid.NewGuid().ToString()
			};
			bool flag = false;
			if (LayoutUpdateStrategy != null)
			{
				flag = LayoutUpdateStrategy.BeforeInsertDocument(layout, layoutDocument, layoutDocumentPane);
			}
			if (!flag)
			{
				if (layoutDocumentPane == null)
				{
					throw new InvalidOperationException("Layout must contains at least one LayoutDocumentPane in order to host documents");
				}
				layoutDocumentPane.Children.Add(layoutDocument);
				flag = true;
			}
			if (LayoutUpdateStrategy != null)
			{
				LayoutUpdateStrategy.AfterInsertDocument(layout, layoutDocument);
			}
			CreateDocumentLayoutItem(layoutDocument);
		}
		_suspendLayoutItemCreation = false;
		if (documentsSource is INotifyCollectionChanged notifyCollectionChanged)
		{
			CollectionChangedEventManager.AddListener(notifyCollectionChanged, (IWeakEventListener)(object)this);
		}
	}

	private void DocumentsSourceElementsChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (Layout == null || SuspendDocumentsSourceBinding)
		{
			return;
		}
		if ((e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace) && e.OldItems != null)
		{
			LayoutDocument[] array = (from d in Layout.Descendents().OfType<LayoutDocument>()
				where e.OldItems.Contains(d.Content)
				select d).ToArray();
			for (int num = 0; num < array.Count(); num++)
			{
				LayoutDocument layoutDocument = array[num];
				layoutDocument.Parent.RemoveChild(layoutDocument);
				RemoveViewFromLogicalChild(layoutDocument);
				RemoveDocumentLayoutItem(layoutDocument);
				layoutDocument.Content = null;
			}
		}
		if (e.NewItems != null && (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace) && e.NewItems != null)
		{
			LayoutDocumentPane layoutDocumentPane = null;
			if (Layout.LastFocusedDocument != null)
			{
				layoutDocumentPane = Layout.LastFocusedDocument.Parent as LayoutDocumentPane;
			}
			if (layoutDocumentPane == null)
			{
				layoutDocumentPane = Layout.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();
			}
			_suspendLayoutItemCreation = true;
			foreach (object newItem in e.NewItems)
			{
				LayoutDocument layoutDocument2 = new LayoutDocument
				{
					Content = newItem
				};
				bool flag = false;
				if (LayoutUpdateStrategy != null)
				{
					flag = LayoutUpdateStrategy.BeforeInsertDocument(Layout, layoutDocument2, layoutDocumentPane);
				}
				if (!flag)
				{
					if (layoutDocumentPane == null)
					{
						throw new InvalidOperationException("Layout must contains at least one LayoutDocumentPane in order to host documents");
					}
					layoutDocumentPane.Children.Add(layoutDocument2);
					flag = true;
				}
				if (LayoutUpdateStrategy != null)
				{
					LayoutUpdateStrategy.AfterInsertDocument(Layout, layoutDocument2);
				}
				ILayoutRoot root = layoutDocument2.Root;
				if (root != null && root.Manager == this)
				{
					CreateDocumentLayoutItem(layoutDocument2);
				}
			}
			_suspendLayoutItemCreation = false;
		}
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			LayoutDocument[] array2 = Layout.Descendents().OfType<LayoutDocument>().ToArray();
			foreach (LayoutDocument layoutDocument3 in array2)
			{
				layoutDocument3.Parent.RemoveChild(layoutDocument3);
				RemoveViewFromLogicalChild(layoutDocument3);
				RemoveDocumentLayoutItem(layoutDocument3);
				layoutDocument3.Content = null;
			}
		}
		if (Layout != null)
		{
			Layout.CollectGarbage();
		}
	}

	private void DetachDocumentsSource(LayoutRoot layout, IEnumerable documentsSource)
	{
		if (documentsSource != null && layout != null)
		{
			LayoutDocument[] array = (from d in layout.Descendents().OfType<LayoutDocument>()
				where documentsSource.Contains(d.Content)
				select d).ToArray();
			foreach (LayoutDocument layoutDocument in array)
			{
				layoutDocument.Parent.RemoveChild(layoutDocument);
				RemoveViewFromLogicalChild(layoutDocument);
			}
			if (documentsSource is INotifyCollectionChanged notifyCollectionChanged)
			{
				CollectionChangedEventManager.RemoveListener(notifyCollectionChanged, (IWeakEventListener)(object)this);
			}
			Layout.CollectGarbage();
		}
	}

	private void Close(LayoutContent contentToClose)
	{
		if (!contentToClose.CanClose)
		{
			return;
		}
		LayoutItem layoutItemFromModel = GetLayoutItemFromModel(contentToClose);
		if (layoutItemFromModel.CloseCommand != null)
		{
			if (layoutItemFromModel.CloseCommand.CanExecute(null))
			{
				layoutItemFromModel.CloseCommand.Execute(null);
			}
		}
		else if (contentToClose is LayoutDocument)
		{
			_ExecuteCloseCommand(contentToClose as LayoutDocument);
		}
		else if (contentToClose is LayoutAnchorable)
		{
			_ExecuteCloseCommand(contentToClose as LayoutAnchorable);
		}
	}

	private void AttachAnchorablesSource(LayoutRoot layout, IEnumerable anchorablesSource)
	{
		if (anchorablesSource == null || layout == null)
		{
			return;
		}
		object[] collection = (from d in layout.Descendents().OfType<LayoutAnchorable>()
			select d.Content).ToArray();
		List<object> list = new List<object>(anchorablesSource.OfType<object>());
		object[] array = list.ToArray();
		foreach (object item in array)
		{
			if (collection.Contains(item))
			{
				list.Remove(item);
			}
		}
		LayoutAnchorablePane layoutAnchorablePane = null;
		if (layout.ActiveContent != null)
		{
			layoutAnchorablePane = layout.ActiveContent.Parent as LayoutAnchorablePane;
		}
		if (layoutAnchorablePane == null)
		{
			layoutAnchorablePane = (from pane in layout.Descendents().OfType<LayoutAnchorablePane>()
				where !pane.IsHostedInFloatingWindow && pane.GetSide() == AnchorSide.Right
				select pane).FirstOrDefault();
		}
		if (layoutAnchorablePane == null)
		{
			layoutAnchorablePane = layout.Descendents().OfType<LayoutAnchorablePane>().FirstOrDefault();
		}
		_suspendLayoutItemCreation = true;
		foreach (object item2 in list)
		{
			LayoutAnchorable layoutAnchorable = new LayoutAnchorable
			{
				Content = item2,
				ContentId = Guid.NewGuid().ToString()
			};
			bool flag = false;
			if (LayoutUpdateStrategy != null)
			{
				flag = LayoutUpdateStrategy.BeforeInsertAnchorable(layout, layoutAnchorable, layoutAnchorablePane);
			}
			if (!flag)
			{
				if (layoutAnchorablePane == null)
				{
					LayoutPanel layoutPanel = new LayoutPanel
					{
						Orientation = Orientation.Horizontal
					};
					if (layout.RootPanel != null)
					{
						layoutPanel.Children.Add(layout.RootPanel);
					}
					layout.RootPanel = layoutPanel;
					layoutAnchorablePane = new LayoutAnchorablePane
					{
						DockWidth = new GridLength(200.0, GridUnitType.Pixel)
					};
					layoutPanel.Children.Add(layoutAnchorablePane);
				}
				layoutAnchorablePane.Children.Add(layoutAnchorable);
				flag = true;
			}
			if (LayoutUpdateStrategy != null)
			{
				LayoutUpdateStrategy.AfterInsertAnchorable(layout, layoutAnchorable);
			}
			CreateAnchorableLayoutItem(layoutAnchorable);
		}
		_suspendLayoutItemCreation = false;
		if (anchorablesSource is INotifyCollectionChanged notifyCollectionChanged)
		{
			CollectionChangedEventManager.AddListener(notifyCollectionChanged, (IWeakEventListener)(object)this);
		}
	}

	private void anchorablesSourceElementsChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (Layout == null || SuspendAnchorablesSourceBinding)
		{
			return;
		}
		if ((e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace) && e.OldItems != null)
		{
			LayoutAnchorable[] array = (from d in Layout.Descendents().OfType<LayoutAnchorable>()
				where e.OldItems.Contains(d.Content)
				select d).ToArray();
			foreach (LayoutAnchorable layoutAnchorable in array)
			{
				layoutAnchorable.Content = null;
				layoutAnchorable.Parent.RemoveChild(layoutAnchorable);
				RemoveViewFromLogicalChild(layoutAnchorable);
			}
		}
		if (e.NewItems != null && (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace) && e.NewItems != null)
		{
			LayoutAnchorablePane layoutAnchorablePane = null;
			if (Layout.ActiveContent != null)
			{
				layoutAnchorablePane = Layout.ActiveContent.Parent as LayoutAnchorablePane;
			}
			if (layoutAnchorablePane == null)
			{
				layoutAnchorablePane = (from pane in Layout.Descendents().OfType<LayoutAnchorablePane>()
					where !pane.IsHostedInFloatingWindow && pane.GetSide() == AnchorSide.Right
					select pane).FirstOrDefault();
			}
			if (layoutAnchorablePane == null)
			{
				layoutAnchorablePane = Layout.Descendents().OfType<LayoutAnchorablePane>().FirstOrDefault();
			}
			_suspendLayoutItemCreation = true;
			foreach (object newItem in e.NewItems)
			{
				LayoutAnchorable layoutAnchorable2 = new LayoutAnchorable
				{
					Content = newItem
				};
				bool flag = false;
				if (LayoutUpdateStrategy != null)
				{
					flag = LayoutUpdateStrategy.BeforeInsertAnchorable(Layout, layoutAnchorable2, layoutAnchorablePane);
				}
				if (!flag)
				{
					if (layoutAnchorablePane == null)
					{
						LayoutPanel layoutPanel = new LayoutPanel
						{
							Orientation = Orientation.Horizontal
						};
						if (Layout.RootPanel != null)
						{
							layoutPanel.Children.Add(Layout.RootPanel);
						}
						Layout.RootPanel = layoutPanel;
						layoutAnchorablePane = new LayoutAnchorablePane
						{
							DockWidth = new GridLength(200.0, GridUnitType.Pixel)
						};
						layoutPanel.Children.Add(layoutAnchorablePane);
					}
					layoutAnchorablePane.Children.Add(layoutAnchorable2);
					flag = true;
				}
				if (LayoutUpdateStrategy != null)
				{
					LayoutUpdateStrategy.AfterInsertAnchorable(Layout, layoutAnchorable2);
				}
				ILayoutRoot root = layoutAnchorable2.Root;
				if (root != null && root.Manager == this)
				{
					CreateAnchorableLayoutItem(layoutAnchorable2);
				}
			}
			_suspendLayoutItemCreation = false;
		}
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			LayoutAnchorable[] array = Layout.Descendents().OfType<LayoutAnchorable>().ToArray();
			foreach (LayoutAnchorable layoutAnchorable3 in array)
			{
				layoutAnchorable3.Parent.RemoveChild(layoutAnchorable3);
				RemoveViewFromLogicalChild(layoutAnchorable3);
			}
		}
		if (Layout != null)
		{
			Layout.CollectGarbage();
		}
	}

	private void DetachAnchorablesSource(LayoutRoot layout, IEnumerable anchorablesSource)
	{
		if (anchorablesSource != null && layout != null)
		{
			LayoutAnchorable[] array = (from d in layout.Descendents().OfType<LayoutAnchorable>()
				where anchorablesSource.Contains(d.Content)
				select d).ToArray();
			foreach (LayoutAnchorable layoutAnchorable in array)
			{
				layoutAnchorable.Parent.RemoveChild(layoutAnchorable);
				RemoveViewFromLogicalChild(layoutAnchorable);
			}
			if (anchorablesSource is INotifyCollectionChanged notifyCollectionChanged)
			{
				CollectionChangedEventManager.RemoveListener(notifyCollectionChanged, (IWeakEventListener)(object)this);
			}
			Layout.CollectGarbage();
		}
	}

	private void RemoveViewFromLogicalChild(LayoutContent layoutContent)
	{
		if (layoutContent != null)
		{
			LayoutItem layoutItemFromModel = GetLayoutItemFromModel(layoutContent);
			if (layoutItemFromModel != null && layoutItemFromModel.IsViewExists())
			{
				BindingOperations.ClearAllBindings((DependencyObject)(object)layoutItemFromModel.View);
				InternalRemoveLogicalChild(layoutItemFromModel.View);
				layoutItemFromModel._view = null;
			}
		}
	}

	private void InternalSetActiveContent(object activeContent)
	{
		LayoutContent activeLayoutContent = activeContent as LayoutContent;
		LayoutContent activeContent2 = Layout.Descendents().OfType<LayoutContent>().FirstOrDefault(delegate(LayoutContent lc)
		{
			if (activeLayoutContent == null)
			{
				if (lc != activeContent)
				{
					return lc.Content == activeContent;
				}
				return true;
			}
			if (activeLayoutContent.Content != null)
			{
				if (lc != activeLayoutContent.Content)
				{
					return lc.Content == activeLayoutContent.Content;
				}
				return true;
			}
			if (activeLayoutContent.ContentId != null)
			{
				return lc.ContentId == activeLayoutContent.ContentId;
			}
			return lc == null || lc.Content == null;
		});
		_insideInternalSetActiveContent = true;
		Layout.ActiveContent = activeContent2;
		_insideInternalSetActiveContent = false;
	}

	private void DetachLayoutItems()
	{
		if (Layout != null)
		{
			Extensions.ForEach(_layoutItems, delegate(LayoutItem i)
			{
				i.Detach();
			});
			_layoutItems.Clear();
			Layout.ElementAdded -= Layout_ElementAdded;
			Layout.ElementRemoved -= Layout_ElementRemoved;
		}
	}

	private void Layout_ElementRemoved(object sender, LayoutElementEventArgs e)
	{
		if (!_suspendLayoutItemCreation)
		{
			CollectLayoutItemsDeleted();
		}
	}

	private void Layout_ElementAdded(object sender, LayoutElementEventArgs e)
	{
		if (_suspendLayoutItemCreation)
		{
			return;
		}
		foreach (LayoutContent item in Layout.Descendents().OfType<LayoutContent>())
		{
			if (item is LayoutDocument)
			{
				CreateDocumentLayoutItem(item as LayoutDocument);
			}
			else
			{
				CreateAnchorableLayoutItem(item as LayoutAnchorable);
			}
		}
		CollectLayoutItemsDeleted();
	}

	private void CollectLayoutItemsDeleted()
	{
		if (_collectLayoutItemsOperations != null)
		{
			return;
		}
		_collectLayoutItemsOperations = ((DispatcherObject)this).Dispatcher.BeginInvoke((Delegate)(Action)delegate
		{
			_collectLayoutItemsOperations = null;
			LayoutItem[] array = _layoutItems.Where((LayoutItem item) => item.LayoutElement.Root != Layout).ToArray();
			for (int num = 0; num < array.Count(); num++)
			{
				LayoutItem layoutItem = array[num];
				RemoveDocumentLayoutItem(layoutItem.LayoutElement as LayoutDocument);
			}
		}, Array.Empty<object>());
	}

	private void AttachLayoutItems()
	{
		if (Layout != null)
		{
			LayoutDocument[] array = Layout.Descendents().OfType<LayoutDocument>().ToArray();
			foreach (LayoutDocument contentToAttach in array)
			{
				CreateDocumentLayoutItem(contentToAttach);
			}
			LayoutAnchorable[] array2 = Layout.Descendents().OfType<LayoutAnchorable>().ToArray();
			foreach (LayoutAnchorable contentToAttach2 in array2)
			{
				CreateAnchorableLayoutItem(contentToAttach2);
			}
			Layout.ElementAdded += Layout_ElementAdded;
			Layout.ElementRemoved += Layout_ElementRemoved;
		}
	}

	private void ApplyStyleToLayoutItem(LayoutItem layoutItem)
	{
		layoutItem._ClearDefaultBindings();
		if (LayoutItemContainerStyle != null)
		{
			layoutItem.Style = LayoutItemContainerStyle;
		}
		else if (LayoutItemContainerStyleSelector != null)
		{
			layoutItem.Style = LayoutItemContainerStyleSelector.SelectStyle(layoutItem.Model, (DependencyObject)(object)layoutItem);
		}
		layoutItem._SetDefaultBindings();
	}

	private void CreateAnchorableLayoutItem(LayoutAnchorable contentToAttach)
	{
		if (_layoutItems.Any((LayoutItem item) => item.LayoutElement == contentToAttach))
		{
			foreach (LayoutItem layoutItem in _layoutItems)
			{
				ApplyStyleToLayoutItem(layoutItem);
			}
			return;
		}
		LayoutAnchorableItem layoutAnchorableItem = new LayoutAnchorableItem();
		layoutAnchorableItem.Attach(contentToAttach);
		ApplyStyleToLayoutItem(layoutAnchorableItem);
		_layoutItems.Add(layoutAnchorableItem);
		if (contentToAttach != null && contentToAttach.Content != null && contentToAttach.Content is UIElement)
		{
			InternalAddLogicalChild(contentToAttach.Content);
		}
	}

	private void CreateDocumentLayoutItem(LayoutDocument contentToAttach)
	{
		if (_layoutItems.Any((LayoutItem item) => item.LayoutElement == contentToAttach))
		{
			foreach (LayoutItem layoutItem in _layoutItems)
			{
				ApplyStyleToLayoutItem(layoutItem);
			}
			return;
		}
		LayoutDocumentItem layoutDocumentItem = new LayoutDocumentItem();
		layoutDocumentItem.Attach(contentToAttach);
		ApplyStyleToLayoutItem(layoutDocumentItem);
		_layoutItems.Add(layoutDocumentItem);
		if (contentToAttach != null && contentToAttach.Content != null && contentToAttach.Content is UIElement)
		{
			InternalAddLogicalChild(contentToAttach.Content);
		}
	}

	private void RemoveDocumentLayoutItem(LayoutDocument contentToRemove)
	{
		LayoutItem layoutItem = _layoutItems.FirstOrDefault((LayoutItem item) => item.LayoutElement == contentToRemove);
		if (layoutItem != null)
		{
			layoutItem._ClearDefaultBindings();
			layoutItem.Detach();
			_layoutItems.Remove(layoutItem);
			if (contentToRemove != null && contentToRemove.Content != null && contentToRemove.Content is UIElement)
			{
				InternalRemoveLogicalChild(contentToRemove.Content);
			}
		}
	}

	private LayoutFloatingWindowControl CreateFloatingWindowForLayoutAnchorableWithoutParent(LayoutAnchorablePane paneModel, bool isContentImmutable)
	{
		LayoutContent selectedContent = paneModel.SelectedContent;
		RaisePreviewFloatEvent(selectedContent);
		if (paneModel.Children.Any((LayoutAnchorable c) => !c.CanFloat))
		{
			return null;
		}
		double num = ((ILayoutElementForFloatingWindow)paneModel).FloatingWidth;
		double num2 = ((ILayoutElementForFloatingWindow)paneModel).FloatingHeight;
		double floatingLeft = ((ILayoutElementForFloatingWindow)paneModel).FloatingLeft;
		double floatingTop = ((ILayoutElementForFloatingWindow)paneModel).FloatingTop;
		if (num == 0.0)
		{
			num = ((ILayoutPositionableElementWithActualSize)paneModel).ActualWidth + 10.0;
		}
		if (num2 == 0.0)
		{
			num2 = ((ILayoutPositionableElementWithActualSize)paneModel).ActualHeight + 10.0;
		}
		LayoutAnchorablePane layoutAnchorablePane = new LayoutAnchorablePane
		{
			DockWidth = ((ILayoutPositionableElement)paneModel).DockWidth,
			DockHeight = ((ILayoutPositionableElement)paneModel).DockHeight,
			DockMinHeight = ((ILayoutPositionableElement)paneModel).DockMinHeight,
			DockMinWidth = ((ILayoutPositionableElement)paneModel).DockMinWidth,
			FloatingLeft = ((ILayoutElementForFloatingWindow)paneModel).FloatingLeft,
			FloatingTop = ((ILayoutElementForFloatingWindow)paneModel).FloatingTop,
			FloatingWidth = ((ILayoutElementForFloatingWindow)paneModel).FloatingWidth,
			FloatingHeight = ((ILayoutElementForFloatingWindow)paneModel).FloatingHeight
		};
		bool flag = paneModel.FindParent<LayoutFloatingWindow>() == null;
		int selectedContentIndex = paneModel.SelectedContentIndex;
		while (paneModel.Children.Count > 0)
		{
			LayoutAnchorable layoutAnchorable = paneModel.Children[paneModel.Children.Count - 1];
			if (flag)
			{
				((ILayoutPreviousContainer)layoutAnchorable).PreviousContainer = paneModel;
				layoutAnchorable.PreviousContainerIndex = paneModel.Children.Count - 1;
			}
			paneModel.RemoveChildAt(paneModel.Children.Count - 1);
			layoutAnchorablePane.Children.Insert(0, layoutAnchorable);
		}
		if (layoutAnchorablePane.Children.Count > 0)
		{
			layoutAnchorablePane.SelectedContentIndex = selectedContentIndex;
		}
		LayoutFloatingWindow layoutFloatingWindow = new LayoutAnchorableFloatingWindow
		{
			RootPanel = new LayoutAnchorablePaneGroup(layoutAnchorablePane)
			{
				DockHeight = layoutAnchorablePane.DockHeight,
				DockWidth = layoutAnchorablePane.DockWidth,
				DockMinHeight = layoutAnchorablePane.DockMinHeight,
				DockMinWidth = layoutAnchorablePane.DockMinWidth
			}
		};
		Layout.FloatingWindows.Add(layoutFloatingWindow);
		LayoutFloatingWindowControl layoutFloatingWindowControl = new LayoutAnchorableFloatingWindowControl(layoutFloatingWindow as LayoutAnchorableFloatingWindow, isContentImmutable)
		{
			Width = num,
			Height = num2,
			Top = floatingTop,
			Left = floatingLeft
		};
		ShowInTaskbar(layoutFloatingWindowControl);
		for (FrameworkElement frameworkElement = base.Parent as FrameworkElement; frameworkElement != null; frameworkElement = frameworkElement.Parent as FrameworkElement)
		{
			layoutFloatingWindowControl.InputBindings.AddRange(frameworkElement.InputBindings);
		}
		foreach (LayoutAnchorable child in layoutAnchorablePane.Children)
		{
			child.IsFloating = true;
		}
		_fwList.Add(layoutFloatingWindowControl);
		RaiseFloatedEvent(selectedContent);
		Layout.CollectGarbage();
		InvalidateArrange();
		return layoutFloatingWindowControl;
	}

	private LayoutFloatingWindowControl CreateFloatingWindowCore(LayoutContent contentModel, bool isContentImmutable)
	{
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		RaisePreviewFloatEvent(contentModel);
		if (!contentModel.CanFloat)
		{
			return null;
		}
		if (contentModel is LayoutAnchorable { IsAutoHidden: not false } layoutAnchorable)
		{
			layoutAnchorable.ToggleAutoHide();
		}
		UpdateStarSize(contentModel);
		ILayoutPane layoutPane = contentModel.Parent as ILayoutPane;
		ILayoutPositionableElement layoutPositionableElement = contentModel.Parent as ILayoutPositionableElement;
		ILayoutPositionableElementWithActualSize layoutPositionableElementWithActualSize = contentModel.Parent as ILayoutPositionableElementWithActualSize;
		int num = layoutPane.Children.ToList().IndexOf(contentModel);
		if (contentModel.FindParent<LayoutFloatingWindow>() == null)
		{
			((ILayoutPreviousContainer)contentModel).PreviousContainer = layoutPane;
			contentModel.PreviousContainerIndex = num;
		}
		layoutPane.RemoveChildAt(num);
		while (layoutPane != null && layoutPane.ChildrenCount == 0)
		{
			ILayoutPane layoutPane2 = layoutPane.Parent as ILayoutPane;
			layoutPane2?.RemoveChild(layoutPane);
			layoutPane = layoutPane2;
		}
		double num2 = contentModel.FloatingWidth;
		double num3 = contentModel.FloatingHeight;
		if (num2 == 0.0)
		{
			num2 = layoutPositionableElement.FloatingWidth;
		}
		if (num3 == 0.0)
		{
			num3 = layoutPositionableElement.FloatingHeight;
		}
		if (num2 == 0.0)
		{
			num2 = layoutPositionableElementWithActualSize.ActualWidth + 10.0;
		}
		if (num3 == 0.0)
		{
			num3 = layoutPositionableElementWithActualSize.ActualHeight + 10.0;
		}
		LayoutFloatingWindowControl layoutFloatingWindowControl;
		if (contentModel is LayoutAnchorable)
		{
			LayoutAnchorable anchorable = contentModel as LayoutAnchorable;
			LayoutFloatingWindow layoutFloatingWindow = new LayoutAnchorableFloatingWindow
			{
				RootPanel = new LayoutAnchorablePaneGroup(new LayoutAnchorablePane(anchorable)
				{
					DockWidth = layoutPositionableElement.DockWidth,
					DockHeight = layoutPositionableElement.DockHeight,
					DockMinHeight = layoutPositionableElement.DockMinHeight,
					DockMinWidth = layoutPositionableElement.DockMinWidth,
					FloatingLeft = layoutPositionableElement.FloatingLeft,
					FloatingTop = layoutPositionableElement.FloatingTop,
					FloatingWidth = layoutPositionableElement.FloatingWidth,
					FloatingHeight = layoutPositionableElement.FloatingHeight
				})
			};
			Layout.FloatingWindows.Add(layoutFloatingWindow);
			Size val = UpdateFloatingDimensions(contentModel, new Size(num2, num3));
			layoutFloatingWindowControl = new LayoutAnchorableFloatingWindowControl(layoutFloatingWindow as LayoutAnchorableFloatingWindow, isContentImmutable)
			{
				Width = ((Size)(ref val)).Width,
				Height = ((Size)(ref val)).Height,
				Left = contentModel.FloatingLeft,
				Top = contentModel.FloatingTop
			};
		}
		else
		{
			LayoutDocument rootDocument = contentModel as LayoutDocument;
			LayoutFloatingWindow layoutFloatingWindow = new LayoutDocumentFloatingWindow
			{
				RootDocument = rootDocument
			};
			Layout.FloatingWindows.Add(layoutFloatingWindow);
			Size val2 = UpdateFloatingDimensions(contentModel, new Size(num2, num3));
			layoutFloatingWindowControl = new LayoutDocumentFloatingWindowControl(layoutFloatingWindow as LayoutDocumentFloatingWindow, isContentImmutable)
			{
				Width = ((Size)(ref val2)).Width,
				Height = ((Size)(ref val2)).Height,
				Left = contentModel.FloatingLeft,
				Top = contentModel.FloatingTop
			};
		}
		ShowInTaskbar(layoutFloatingWindowControl);
		contentModel.IsFloating = true;
		for (FrameworkElement frameworkElement = base.Parent as FrameworkElement; frameworkElement != null; frameworkElement = frameworkElement.Parent as FrameworkElement)
		{
			layoutFloatingWindowControl.InputBindings.AddRange(frameworkElement.InputBindings);
		}
		_fwList.Add(layoutFloatingWindowControl);
		RaiseFloatedEvent(contentModel);
		Layout.CollectGarbage();
		UpdateLayout();
		return layoutFloatingWindowControl;
	}

	private void ShowInTaskbar(LayoutFloatingWindowControl fwc)
	{
		IEnumerable<LayoutContent> enumerable = from l in fwc.Model.Descendents().OfType<LayoutContent>()
			where l != null
			select l;
		if (enumerable != null)
		{
			fwc.ShowInTaskbar = true;
			if (enumerable.Count() > 1)
			{
				LayoutContent layoutContent = enumerable.FirstOrDefault((LayoutContent l) => l.IsSelected);
				fwc.Title = ((layoutContent != null) ? layoutContent.Title : "");
			}
			else
			{
				fwc.Title = enumerable.ElementAt(0).Title ?? "";
			}
		}
		RenameWindowTitleForMultipleDockingManagerRunningInstances(fwc);
	}

	private void RenameWindowTitleForMultipleDockingManagerRunningInstances(LayoutFloatingWindowControl fwc)
	{
		if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count() > 1)
		{
			string title = Window.GetWindow((DependencyObject)(object)this).Title;
			if (!string.IsNullOrEmpty(title))
			{
				fwc.Title = title + " - " + fwc.Title;
			}
		}
	}

	private Size UpdateFloatingDimensions(ILayoutElementForFloatingWindow contentModel, Size currentSize)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		if (contentModel.FloatingWidth != 0.0)
		{
			((Size)(ref currentSize)).Width = contentModel.FloatingWidth;
		}
		if (contentModel.FloatingHeight != 0.0)
		{
			((Size)(ref currentSize)).Height = contentModel.FloatingHeight;
		}
		return currentSize;
	}

	private void UpdateStarSize(LayoutContent contentModel)
	{
		if (contentModel == null)
		{
			return;
		}
		ILayoutPositionableElement parentPane = contentModel.Parent as ILayoutPositionableElement;
		if (parentPane == null)
		{
			return;
		}
		if (parentPane is ILayoutContainer { ChildrenCount: 1 })
		{
			if (parentPane.DockWidth.IsStar)
			{
				parentPane.DockWidth = new GridLength(1.0, GridUnitType.Star);
			}
			if (parentPane.DockHeight.IsStar)
			{
				parentPane.DockHeight = new GridLength(1.0, GridUnitType.Star);
			}
		}
		ILayoutOrientableGroup layoutOrientableGroup = parentPane.Parent as ILayoutOrientableGroup;
		ILayoutPositionableElement layoutPositionableElement = parentPane.Parent as ILayoutPositionableElement;
		if (layoutOrientableGroup == null || layoutPositionableElement == null)
		{
			return;
		}
		if (layoutOrientableGroup.Orientation == Orientation.Horizontal)
		{
			if (!layoutPositionableElement.DockWidth.IsStar)
			{
				return;
			}
			ILayoutContainer parent = parentPane.Parent;
			if (parent == null)
			{
				return;
			}
			IEnumerable<ILayoutPositionableElement> enumerable = from ILayoutPositionableElement child in parent.Children.Where((ILayoutElement child) => (child.Equals(parentPane) && parentPane is ILayoutContainer && ((ILayoutContainer)parentPane).ChildrenCount > 1) || (!child.Equals(parentPane) && child is ILayoutContainer && ((ILayoutContainer)child).ChildrenCount > 0))
				where child.DockWidth.IsStar
				select child;
			double num = enumerable.Sum((ILayoutPositionableElement child) => child.DockWidth.Value);
			{
				foreach (ILayoutPositionableElement item in enumerable)
				{
					item.DockWidth = new GridLength(item.DockWidth.Value / num, GridUnitType.Star);
				}
				return;
			}
		}
		if (!layoutPositionableElement.DockHeight.IsStar)
		{
			return;
		}
		ILayoutContainer parent2 = parentPane.Parent;
		if (parent2 == null)
		{
			return;
		}
		IEnumerable<ILayoutPositionableElement> enumerable2 = from ILayoutPositionableElement child in parent2.Children.Where((ILayoutElement child) => (child.Equals(parentPane) && parentPane is ILayoutContainer && ((ILayoutContainer)parentPane).ChildrenCount > 1) || !child.Equals(parentPane))
			where child.DockHeight.IsStar
			select child;
		double num2 = enumerable2.Sum((ILayoutPositionableElement child) => child.DockHeight.Value);
		foreach (ILayoutPositionableElement item2 in enumerable2)
		{
			item2.DockHeight = new GridLength(item2.DockHeight.Value / num2, GridUnitType.Star);
		}
	}

	private void AnchorableContextMenu_Opened(object sender, RoutedEventArgs e)
	{
		if (sender is ContextMenu contextMenu)
		{
			if (contextMenu.PlacementTarget is Control)
			{
				contextMenu.VerticalOffset = ((Control)contextMenu.PlacementTarget).ActualHeight - contextMenu.ActualHeight;
			}
			AnchorableContextMenu.Opened -= AnchorableContextMenu_Opened;
		}
	}

	bool IOverlayWindowHost.HitTest(Point dragPoint)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Rect val = default(Rect);
		((Rect)(ref val))._002Ector(this.PointToScreenDPIWithoutFlowDirection(default(Point)), this.TransformActualSizeToAncestor());
		return ((Rect)(ref val)).Contains(dragPoint);
	}

	IOverlayWindow IOverlayWindowHost.ShowOverlayWindow(LayoutFloatingWindowControl draggingWindow)
	{
		CreateOverlayWindow();
		_overlayWindow.Owner = draggingWindow;
		_overlayWindow.EnableDropTargets();
		_overlayWindow.Show();
		return _overlayWindow;
	}

	void IOverlayWindowHost.HideOverlayWindow()
	{
		_areas = null;
		_overlayWindow.Owner = null;
		_overlayWindow.HideDropTargets();
	}

	IEnumerable<IDropArea> IOverlayWindowHost.GetDropAreas(LayoutFloatingWindowControl draggingWindow)
	{
		if (_areas != null)
		{
			return _areas;
		}
		DockingManager manager = draggingWindow.Model.Root.Manager;
		bool flag = draggingWindow.Model is LayoutDocumentFloatingWindow;
		_areas = new List<IDropArea>();
		if (!flag)
		{
			if (manager == this)
			{
				_areas.Add(new DropArea<DockingManager>(this, DropAreaType.DockingManager));
			}
			foreach (LayoutAnchorablePaneControl item in ((DependencyObject)(object)this).FindVisualChildren<LayoutAnchorablePaneControl>())
			{
				if (item.Model.Descendents().Any() && manager == item.Model.Root.Manager)
				{
					_areas.Add(new DropArea<LayoutAnchorablePaneControl>(item, DropAreaType.AnchorablePane));
				}
			}
		}
		foreach (LayoutDocumentPaneControl item2 in ((DependencyObject)(object)this).FindVisualChildren<LayoutDocumentPaneControl>())
		{
			if ((flag || (!flag && draggingWindow.Model.Descendents().OfType<LayoutAnchorable>().All((LayoutAnchorable x) => x.CanDockAsTabbedDocument))) && manager == item2.Model.Root.Manager)
			{
				_areas.Add(new DropArea<LayoutDocumentPaneControl>(item2, DropAreaType.DocumentPane));
			}
		}
		foreach (LayoutDocumentPaneGroupControl item3 in ((DependencyObject)(object)this).FindVisualChildren<LayoutDocumentPaneGroupControl>())
		{
			if ((item3.Model as LayoutDocumentPaneGroup).Children.Where((ILayoutDocumentPane c) => c.IsVisible).Count() == 0 && manager == item3.Model.Root.Manager)
			{
				_areas.Add(new DropArea<LayoutDocumentPaneGroupControl>(item3, DropAreaType.DocumentPaneGroup));
			}
		}
		return _areas;
	}

	protected virtual void RaisePreviewFloatEvent(LayoutContent layoutContent)
	{
		RoutedEventArgs e = new RoutedEventArgs(PreviewFloatEvent, layoutContent);
		RaiseEvent(e);
	}

	protected virtual void RaiseFloatedEvent(LayoutContent layoutContent)
	{
		RoutedEventArgs e = new RoutedEventArgs(FloatedEvent, layoutContent);
		RaiseEvent(e);
	}

	protected internal virtual void RaisePreviewDockEvent(LayoutContent layoutContent)
	{
		RoutedEventArgs e = new RoutedEventArgs(PreviewDockEvent, layoutContent);
		RaiseEvent(e);
	}

	protected internal virtual void RaiseDockedEvent(LayoutContent layoutContent)
	{
		RoutedEventArgs e = new RoutedEventArgs(DockedEvent, layoutContent);
		RaiseEvent(e);
	}

	bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
	{
		return OnReceiveWeakEvent(managerType, sender, e);
	}

	protected virtual bool OnReceiveWeakEvent(Type managerType, object sender, EventArgs e)
	{
		if (typeof(CollectionChangedEventManager) == managerType)
		{
			NotifyCollectionChangedEventArgs e2 = (NotifyCollectionChangedEventArgs)e;
			if (sender == DocumentsSource)
			{
				DocumentsSourceElementsChanged(sender, e2);
			}
			else if (sender == AnchorablesSource)
			{
				anchorablesSourceElementsChanged(sender, e2);
			}
			return true;
		}
		return false;
	}
}
