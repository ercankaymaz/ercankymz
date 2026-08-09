using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using MS.Internal;
using MS.Internal.Automation;
using MS.Internal.Interaction;
using MS.Internal.Properties;
using MS.Internal.Transforms;
using Microsoft.Windows.Design.Model;
using Microsoft.Windows.Design.Services;

namespace Microsoft.Windows.Design.Interaction;

public class DesignerView : Decorator
{
	[Flags]
	private enum FindCommandScope
	{
		SourceAdorner = 1,
		TargetAdorner = 2,
		Tool = 4,
		Adorners = 3,
		All = 7
	}

	private struct MouseState
	{
		internal Point MouseDownPosition;

		internal MouseButtonStage MouseButtonStage;

		internal int DispatcherClickCount;
	}

	private enum MouseButtonStage
	{
		None,
		MouseDown,
		DragIntentRaised
	}

	internal class OpaqueElement : UIElement
	{
		protected override GeometryHitTestResult HitTestCore(GeometryHitTestParameters hitTestParams)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			return new GeometryHitTestResult((Visual)(object)this, (IntersectionDetail)3);
		}

		protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParams)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			return (HitTestResult)new PointHitTestResult((Visual)(object)this, hitTestParams.HitPoint);
		}
	}

	private int _doubleClickSizeX;

	private int _doubleClickSizeY;

	private int _hoverSizeX;

	private int _hoverSizeY;

	private long _hoverTimeout;

	private double _minimumHorizontalDragDistance;

	private double _minimumVerticalDragDistance;

	private EditingContext _context;

	private AdornerLayer _adornerLayer;

	private OpaqueElement _hitTestLayer;

	private ViewService _viewService;

	private ModelService _modelService;

	private bool _inCall;

	private bool _pendingClearCapture;

	private bool _clearingCapture;

	private bool _abortCapture;

	private EventArgs _secondaryHitTestArgs;

	private Point _clickPoint;

	private int _clickCount;

	private ModelItem _clickModel;

	private DependencyObject _clickAdorner;

	private bool _capturingMouse;

	private UIElement _captureOwner;

	private DependencyObject _captureAdorner;

	private ModelItem _captureModel;

	private Point _capturePointInRootElementCoords;

	private DependencyObject _hitRawAdornerVisual;

	private ViewItem _hitRawModelVisual;

	private DependencyObject _hitAdorner;

	private ModelItem _hitModel;

	private ViewHitTestFilterCallback _modelHitTestFilter;

	private MouseState[] _mouseState;

	private DragDropEffects _dragAllowedEffects;

	private Point _lastCurrentPoint;

	private IDataObject _dragData;

	private DispatcherTimer _hoverTimer;

	private Point _hoverPoint;

	private DesignerViewAutomationPeer _designerViewAutomationPeer;

	private Task _focusedTask;

	private static Style _defaultFocusVisualStyle;

	private bool _protectReEntrantCode;

	private Point _lastPointInParentCoordinates = default(Point);

	private static readonly DependencyPropertyKey DesignerViewPropertyKey;

	public static readonly DependencyProperty DesignerViewProperty;

	public static readonly DependencyProperty AdornersVisibleProperty;

	public static readonly DependencyProperty ZoomLevelProperty;

	private static TraceSwitch _disableCatchAll;

	private static Style DefaultFocusVisualStyle
	{
		get
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			if (_defaultFocusVisualStyle == null)
			{
				_defaultFocusVisualStyle = new Style();
				_defaultFocusVisualStyle.Seal();
			}
			return _defaultFocusVisualStyle;
		}
	}

	public ICollection<UIElement> Adorners => _adornerLayer.Adorners;

	public EditingContext Context
	{
		get
		{
			return _context;
		}
		set
		{
			if (value != _context)
			{
				if (value != null && value.Items.Contains<CurrentDesignerView>() && value.Items.GetValue<CurrentDesignerView>().View != null)
				{
					throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_ContextHasView);
				}
				if (_context != null)
				{
					_context.Items.SetValue(new CurrentDesignerView(null));
					_context.Items.Unsubscribe<FocusedTask>(OnFocusedTaskChanged);
					_context.Items.Unsubscribe<Tool>(OnToolChanged);
					_context.Disposing -= OnContextDisposing;
				}
				ClearAllHitTestInfo();
				_context = value;
				_viewService = null;
				_modelService = null;
				_focusedTask = null;
				if (_context != null)
				{
					_context.Items.SetValue(new CurrentDesignerView(this));
					_context.Items.Subscribe<FocusedTask>(OnFocusedTaskChanged);
					_context.Items.Subscribe<Tool>(OnToolChanged);
					_context.Disposing += OnContextDisposing;
				}
				if (_designerViewAutomationPeer != null)
				{
					_designerViewAutomationPeer.Context = _context;
				}
				_adornerLayer.SetContext(_context);
			}
		}
	}

	public bool IsContentHitTestVisible
	{
		get
		{
			return !((UIElement)_hitTestLayer).IsHitTestVisible;
		}
		set
		{
			((UIElement)_hitTestLayer).IsHitTestVisible = !value;
			if (value)
			{
				KeyboardNavigation.SetControlTabNavigation((DependencyObject)(object)this, (KeyboardNavigationMode)0);
				KeyboardNavigation.SetDirectionalNavigation((DependencyObject)(object)this, (KeyboardNavigationMode)0);
				KeyboardNavigation.SetTabNavigation((DependencyObject)(object)this, (KeyboardNavigationMode)0);
			}
			else
			{
				((DependencyObject)this).ClearValue(KeyboardNavigation.ControlTabNavigationProperty);
				((DependencyObject)this).ClearValue(KeyboardNavigation.DirectionalNavigationProperty);
				((DependencyObject)this).ClearValue(KeyboardNavigation.TabNavigationProperty);
			}
		}
	}

	public ViewItem RootView
	{
		get
		{
			if (ModelService != null && ModelService.Root != null)
			{
				return ModelService.Root.View;
			}
			return null;
		}
	}

	public bool AdornersVisible
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AdornersVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdornersVisibleProperty, (object)value);
		}
	}

	private ViewService ViewService
	{
		get
		{
			if (_viewService == null && _context != null)
			{
				_viewService = _context.Services.GetService<ViewService>();
			}
			return _viewService;
		}
	}

	private double MinHorizontalDragDistance
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			Vector zoomRounding = DesignerUtilities.GetZoomRounding(this);
			return _minimumHorizontalDragDistance * ((Vector)(ref zoomRounding)).X;
		}
	}

	private double MinVerticalDragDistance
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			Vector zoomRounding = DesignerUtilities.GetZoomRounding(this);
			return _minimumVerticalDragDistance * ((Vector)(ref zoomRounding)).Y;
		}
	}

	private ModelService ModelService
	{
		get
		{
			if (_modelService == null && _context != null)
			{
				_modelService = _context.Services.GetService<ModelService>();
			}
			return _modelService;
		}
	}

	public override UIElement Child
	{
		get
		{
			return ((Decorator)this).Child;
		}
		set
		{
			UIElement child = ((Decorator)this).Child;
			if (child != value)
			{
				if (value == null)
				{
					((Decorator)this).Child = null;
					((Visual)this).RemoveVisualChild((Visual)(object)_hitTestLayer);
					((Visual)this).RemoveVisualChild((Visual)(object)_adornerLayer);
					((FrameworkElement)this).RemoveLogicalChild((object)_adornerLayer);
				}
				else
				{
					((Decorator)this).Child = value;
					((FrameworkElement)this).AddLogicalChild((object)_adornerLayer);
					((Visual)this).AddVisualChild((Visual)(object)_hitTestLayer);
					((Visual)this).AddVisualChild((Visual)(object)_adornerLayer);
				}
			}
		}
	}

	protected override int VisualChildrenCount
	{
		get
		{
			if (((Decorator)this).Child == null)
			{
				return 0;
			}
			return 3;
		}
	}

	public double ZoomLevel
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ZoomLevelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomLevelProperty, (object)value);
		}
	}

	public event EventHandler<CommandExceptionEventArgs> CommandException;

	public event EventHandler<MatchGestureEventArgs> MatchGesture;

	public event EventHandler ZoomLevelChanged;

	static DesignerView()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00bf: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		DesignerViewPropertyKey = DependencyProperty.RegisterAttachedReadOnly("DesignerView", typeof(DesignerView), typeof(DesignerView), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)96));
		DesignerViewProperty = DesignerViewPropertyKey.DependencyProperty;
		AdornersVisibleProperty = DependencyProperty.Register("AdornersVisible", typeof(bool), typeof(DesignerView), new PropertyMetadata((object)true, new PropertyChangedCallback(OnAdornersVisibleChanged)));
		ZoomLevelProperty = DependencyProperty.Register("ZoomLevel", typeof(double), typeof(DesignerView), (PropertyMetadata)new FrameworkPropertyMetadata((object)1.0, (FrameworkPropertyMetadataOptions)19, new PropertyChangedCallback(HandleZoomLevelChanged)), new ValidateValueCallback(IsZoomLevelValid));
		_disableCatchAll = new TraceSwitch("DisableCatchAll", "Cider Switches");
		KeyboardNavigation.ControlTabNavigationProperty.OverrideMetadata(typeof(DesignerView), (PropertyMetadata)new FrameworkPropertyMetadata((object)(KeyboardNavigationMode)3));
		KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof(DesignerView), (PropertyMetadata)new FrameworkPropertyMetadata((object)(KeyboardNavigationMode)3));
		KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof(DesignerView), (PropertyMetadata)new FrameworkPropertyMetadata((object)(KeyboardNavigationMode)3));
		UIElement.FocusableProperty.OverrideMetadata(typeof(DesignerView), (PropertyMetadata)new FrameworkPropertyMetadata((object)true));
		FrameworkElement.FocusVisualStyleProperty.OverrideMetadata(typeof(DesignerView), (PropertyMetadata)new FrameworkPropertyMetadata((object)DefaultFocusVisualStyle));
	}

	public DesignerView()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected O, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		_mouseState = new MouseState[5];
		_adornerLayer = new AdornerLayer();
		_hitTestLayer = new OpaqueElement();
		KeyboardNavigation.SetIsTabStop((DependencyObject)(object)_hitTestLayer, false);
		KeyboardNavigation.SetIsTabStop((DependencyObject)(object)_adornerLayer, false);
		KeyboardNavigation.SetControlTabNavigation((DependencyObject)(object)_adornerLayer, (KeyboardNavigationMode)4);
		KeyboardNavigation.SetDirectionalNavigation((DependencyObject)(object)_adornerLayer, (KeyboardNavigationMode)4);
		KeyboardNavigation.SetTabNavigation((DependencyObject)(object)_adornerLayer, (KeyboardNavigationMode)4);
		_doubleClickSizeX = SafeNativeMethods.GetSystemMetrics(36);
		_doubleClickSizeY = SafeNativeMethods.GetSystemMetrics(37);
		SafeNativeMethods.SystemParametersInfo(98, 0, out _hoverSizeX, 0);
		SafeNativeMethods.SystemParametersInfo(100, 0, out _hoverSizeY, 0);
		_minimumHorizontalDragDistance = SystemParameters.MinimumHorizontalDragDistance;
		_minimumVerticalDragDistance = SystemParameters.MinimumVerticalDragDistance;
		SafeNativeMethods.SystemParametersInfo(102, 0, out var value, 0);
		_hoverTimeout = value * 10000;
		((UIElement)_hitTestLayer).AllowDrop = true;
		((UIElement)_adornerLayer).AllowDrop = true;
		AddHandler((UIElement)(object)this, DragDrop.GiveFeedbackEvent, (Delegate)new GiveFeedbackEventHandler(OnDecoratorGiveFeedback));
		AddHandler((UIElement)(object)this, Keyboard.KeyDownEvent, (Delegate)new KeyEventHandler(OnDecoratorKeyDown));
		AddHandler((UIElement)(object)this, CommandManager.CanExecuteEvent, (Delegate)new CanExecuteRoutedEventHandler(OnCanExecuteCommand));
		AddHandler((UIElement)(object)this, CommandManager.ExecutedEvent, (Delegate)new ExecutedRoutedEventHandler(OnExecutedCommand));
		AddHandler((UIElement)(object)_hitTestLayer, DragDrop.DragEnterEvent, (Delegate)new DragEventHandler(OnDecoratorDragEnter));
		AddHandler((UIElement)(object)_hitTestLayer, DragDrop.DragLeaveEvent, (Delegate)new DragEventHandler(OnDecoratorDragLeave));
		AddHandler((UIElement)(object)_hitTestLayer, DragDrop.DragOverEvent, (Delegate)new DragEventHandler(OnDecoratorDragOver));
		AddHandler((UIElement)(object)_hitTestLayer, DragDrop.DropEvent, (Delegate)new DragEventHandler(OnDecoratorDrop));
		AddHandler((UIElement)(object)_adornerLayer, DragDrop.DragEnterEvent, (Delegate)new DragEventHandler(OnDecoratorDragEnter));
		AddHandler((UIElement)(object)_adornerLayer, DragDrop.DragLeaveEvent, (Delegate)new DragEventHandler(OnDecoratorDragLeave));
		AddHandler((UIElement)(object)_adornerLayer, DragDrop.DragOverEvent, (Delegate)new DragEventHandler(OnDecoratorDragOver));
		AddHandler((UIElement)(object)_adornerLayer, DragDrop.DropEvent, (Delegate)new DragEventHandler(OnDecoratorDrop));
		AddHandler((UIElement)(object)this, Mouse.MouseDownEvent, (Delegate)new MouseButtonEventHandler(OnMouseDown));
		AddHandler((UIElement)(object)this, Mouse.MouseMoveEvent, (Delegate)new MouseEventHandler(OnMouseMove));
		AddHandler((UIElement)(object)this, Mouse.MouseUpEvent, (Delegate)new MouseButtonEventHandler(OnMouseUp));
		AddHandler((UIElement)(object)this, Mouse.MouseWheelEvent, (Delegate)new MouseWheelEventHandler(OnMouseWheel));
		AddHandler((UIElement)(object)this, Mouse.MouseEnterEvent, (Delegate)new MouseEventHandler(OnMouseEnter));
		AddHandler((UIElement)(object)this, Mouse.MouseLeaveEvent, (Delegate)new MouseEventHandler(OnMouseLeave));
		AddHandler((UIElement)(object)this, Mouse.QueryCursorEvent, (Delegate)new QueryCursorEventHandler(OnHitTestQueryCursor));
		AddHandler((UIElement)(object)this, Mouse.LostMouseCaptureEvent, (Delegate)new MouseEventHandler(OnLostMouseCapture));
		((DependencyObject)this).SetValue(DesignerViewPropertyKey, (object)this);
	}

	public static DesignerView FromContext(EditingContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		CurrentDesignerView value = context.Items.GetValue<CurrentDesignerView>();
		return value.View;
	}

	public static DesignerView GetDesignerView(DependencyObject element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return element.GetValue(DesignerViewProperty) as DesignerView;
	}

	internal static Transform GetScaleTransform(Visual visual)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		DependencyObject val = (DependencyObject)(object)visual;
		DesignerView designerView;
		do
		{
			designerView = val as DesignerView;
			val = VisualTreeHelper.GetParent(val);
		}
		while (designerView == null && val != null);
		Transform val2 = ((designerView == null) ? null : TransformUtil.GetTransformToImmediateParent((DependencyObject)(object)designerView));
		if (val2 == null)
		{
			return Transform.Identity;
		}
		Matrix value = val2.Value;
		((Matrix)(ref value))._002Ector(((Matrix)(ref value)).M11, 0.0, 0.0, ((Matrix)(ref value)).M22, 0.0, 0.0);
		return (Transform)new MatrixTransform(TransformUtil.SafeInvert(value));
	}

	private static void AddHandler(UIElement element, RoutedEvent id, Delegate handler)
	{
		element.AddHandler(id, handler, true);
	}

	private void OnFocusedTaskChanged(FocusedTask focusedTask)
	{
		_focusedTask = focusedTask.Task;
		Mouse.UpdateCursor();
	}

	private void OnContextDisposing(object sender, EventArgs e)
	{
		if (_inCall)
		{
			throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_DisposingDuringCall);
		}
		Context = null;
	}

	private void OnToolChanged(Tool currentTool)
	{
		_clickCount = 0;
		for (int i = 0; i < _mouseState.Length; i++)
		{
			_mouseState[i] = default(MouseState);
		}
		Mouse.UpdateCursor();
	}

	private void AbortCapture()
	{
		if (_captureOwner != null)
		{
			_abortCapture = true;
			ClearCapture();
		}
	}

	private bool BeginCall()
	{
		bool inCall = _inCall;
		_inCall = true;
		return inCall;
	}

	private void ClearCapture()
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		if (_inCall)
		{
			_pendingClearCapture = true;
			return;
		}
		try
		{
			if (_abortCapture)
			{
				_abortCapture = false;
				if (_focusedTask != null)
				{
					_focusedTask.Revert();
				}
			}
		}
		finally
		{
			try
			{
				_clearingCapture = true;
				if ((object)_captureOwner == Mouse.Captured)
				{
					_captureOwner.ReleaseMouseCapture();
				}
			}
			finally
			{
				_clearingCapture = false;
				_pendingClearCapture = false;
				_captureOwner = null;
				_captureModel = null;
				_captureAdorner = null;
				_capturePointInRootElementCoords = default(Point);
				for (int i = 0; i < _mouseState.Length; i++)
				{
					_mouseState[i] = default(MouseState);
				}
			}
		}
	}

	private void ClearAdornerHitTestInfo()
	{
		_hitRawAdornerVisual = null;
		_hitAdorner = null;
	}

	private void ClearAllHitTestInfo()
	{
		ClearAdornerHitTestInfo();
		ClearModelHitTestInfo();
	}

	private void ClearModelHitTestInfo()
	{
		_hitRawModelVisual = null;
		_hitModel = null;
	}

	private void EndCall(bool nestedCall)
	{
		_inCall = nestedCall;
		if (!_inCall && _pendingClearCapture)
		{
			ClearCapture();
		}
	}

	private HitTestFilterBehavior ModelHitTestFilter(ViewItem hit)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		HitTestFilterBehavior result = (HitTestFilterBehavior)6;
		Task focusedTask = _focusedTask;
		ViewService viewService;
		if (focusedTask.ModelFilter != null && (viewService = ViewService) != null)
		{
			ModelItem modelItem = null;
			while (hit != null && (modelItem = viewService.GetModel(hit)) == null)
			{
				hit = hit.VisualParent;
			}
			if (modelItem != null)
			{
				result = focusedTask.ModelFilter(modelItem);
			}
		}
		return result;
	}

	private void PerformHitTest(EventArgs eventArgs)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Invalid comparison between Unknown and I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		_secondaryHitTestArgs = null;
		Point mousePosition = GetMousePosition(eventArgs, (IInputElement)(object)_adornerLayer);
		IInputElement focusedElement = Keyboard.FocusedElement;
		if (DesignerUtilities.FindPopupRoot((DependencyObject)(object)((focusedElement is DependencyObject) ? focusedElement : null)) != null)
		{
			ClearAllHitTestInfo();
			return;
		}
		if (((Point)(ref mousePosition)).X < 0.0 || ((Point)(ref mousePosition)).Y < 0.0)
		{
			ClearAllHitTestInfo();
			return;
		}
		Size renderSize = ((UIElement)_adornerLayer).RenderSize;
		if (((Point)(ref mousePosition)).X > ((Size)(ref renderSize)).Width || ((Point)(ref mousePosition)).Y > ((Size)(ref renderSize)).Height)
		{
			ClearAllHitTestInfo();
			return;
		}
		PerformAdornerHitTest(mousePosition);
		PerformModelHitTest(eventArgs);
		if (_hitModel != null)
		{
			return;
		}
		if (_hitAdorner != null)
		{
			ClearModelHitTestInfo();
			_hitModel = AdornerProperties.GetModel(_hitAdorner);
			if (_hitModel != null && _focusedTask != null && _focusedTask.ModelFilter != null)
			{
				HitTestFilterBehavior val = _focusedTask.ModelFilter(_hitModel);
				if ((int)val == 4 || (int)val == 0)
				{
					_hitModel = null;
				}
			}
		}
		if (_hitModel == null)
		{
			ModelService modelService = ModelService;
			if (modelService != null)
			{
				_hitModel = modelService.Root;
			}
		}
	}

	private void PerformAdornerHitTest(Point mouse)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		HitTestFilterCallback filterCallback = null;
		if (_focusedTask != null)
		{
			filterCallback = _focusedTask.AdornerFilter;
		}
		HitTestResult obj = HitTestHelper.HitTest((Visual)(object)_adornerLayer, mouse, ignoreDisabled: true, filterCallback);
		PointHitTestResult val = (PointHitTestResult)(object)((obj is PointHitTestResult) ? obj : null);
		if (val != null && val.VisualHit != null)
		{
			if ((object)val.VisualHit == _hitRawAdornerVisual)
			{
				return;
			}
			ClearAdornerHitTestInfo();
			_hitRawAdornerVisual = (DependencyObject)(object)val.VisualHit;
			DependencyObject val2;
			for (val2 = (DependencyObject)(object)val.VisualHit; val2 != null; val2 = VisualTreeHelper.GetParent(val2))
			{
				FrameworkElement val4;
				FrameworkContentElement val5;
				DependencyObject val3 = (((val4 = (FrameworkElement)(object)((val2 is FrameworkElement) ? val2 : null)) != null) ? val4.TemplatedParent : (((val5 = (FrameworkContentElement)(object)((val2 is FrameworkContentElement) ? val2 : null)) == null) ? null : val5.TemplatedParent));
				if (val3 == null)
				{
					break;
				}
			}
			_hitAdorner = val2;
		}
		else
		{
			ClearAdornerHitTestInfo();
		}
	}

	private void PerformModelHitTest(EventArgs eventArgs)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		ViewHitTestFilterCallback filterCallback = null;
		if (_focusedTask != null)
		{
			if (_modelHitTestFilter == null && _focusedTask.ModelFilter != null)
			{
				_modelHitTestFilter = ModelHitTestFilter;
			}
			else if (_focusedTask.ModelFilter == null)
			{
				_modelHitTestFilter = null;
			}
			filterCallback = _modelHitTestFilter;
		}
		ViewItem rootView = RootView;
		ViewHitTestResult viewHitTestResult = null;
		if (rootView != null)
		{
			Point mousePosition = GetMousePosition(eventArgs, (IInputElement)(object)((Decorator)this).Child);
			GeneralTransform val = rootView.TransformFromVisual((Visual)(object)((Decorator)this).Child);
			if (val != null)
			{
				viewHitTestResult = rootView.HitTest(filterCallback, null, (HitTestParameters)new PointHitTestParameters(val.Transform(mousePosition)));
			}
		}
		if (viewHitTestResult != null && viewHitTestResult.ViewHit != null)
		{
			if (!(viewHitTestResult.ViewHit != _hitRawModelVisual))
			{
				return;
			}
			ClearModelHitTestInfo();
			_hitRawModelVisual = viewHitTestResult.ViewHit;
			ViewService viewService = ViewService;
			if (viewService != null)
			{
				ViewItem viewItem = viewHitTestResult.ViewHit;
				while (viewItem != null && (_hitModel = viewService.GetModel(viewItem)) == null)
				{
					viewItem = viewItem.VisualParent;
				}
			}
		}
		else
		{
			ClearModelHitTestInfo();
		}
	}

	private Point GetCapturePoint()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		Point result = _capturePointInRootElementCoords;
		if (ModelService != null && ModelService.Root != _captureModel)
		{
			ViewItem rootView = RootView;
			if (rootView != null)
			{
				result = ((GeneralTransform)TransformUtil.GetTransformToAncestor(rootView, (Visual)(object)this)).Transform(_capturePointInRootElementCoords);
			}
		}
		return result;
	}

	private void SetCapturePoint(ViewItem rootElementOnSurface)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		_capturePointInRootElementCoords = Mouse.GetPosition((IInputElement)(object)this);
		if (ModelService != null && ModelService.Root != _captureModel && rootElementOnSurface != null)
		{
			GeneralTransform val = rootElementOnSurface.TransformFromVisual((Visual)(object)this);
			if (val != null)
			{
				_capturePointInRootElementCoords = val.Transform(_capturePointInRootElementCoords);
			}
		}
	}

	private void SetCapture(UIElement captureOwner)
	{
		_captureModel = _hitModel;
		_captureAdorner = _hitAdorner;
		_captureOwner = captureOwner;
		if (ModelService != null)
		{
			ViewItem rootView = RootView;
			SetCapturePoint(rootView);
		}
		try
		{
			_capturingMouse = true;
			_captureOwner.CaptureMouse();
		}
		finally
		{
			_capturingMouse = false;
		}
		for (int i = 0; i < _mouseState.Length; i++)
		{
			_mouseState[i] = default(MouseState);
		}
	}

	private Point GetMousePosition(EventArgs inputArgs, IInputElement relativeTo)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (inputArgs is ToolActionEventArgs e)
		{
			if (ToolAction.DragIntent == e.ToolAction)
			{
				for (int i = 0; i < _mouseState.Length; i++)
				{
					MouseState mouseState = _mouseState[i];
					if (mouseState.MouseButtonStage == MouseButtonStage.MouseDown)
					{
						return _mouseState[i].MouseDownPosition;
					}
				}
			}
			inputArgs = e.SourceEvent;
		}
		DragEventArgs e2;
		if ((e2 = (DragEventArgs)(object)((inputArgs is DragEventArgs) ? inputArgs : null)) != null)
		{
			return e2.GetPosition(relativeTo);
		}
		MouseEventArgs e3;
		if ((e3 = (MouseEventArgs)(object)((inputArgs is MouseEventArgs) ? inputArgs : null)) != null)
		{
			return e3.GetPosition(relativeTo);
		}
		return Mouse.GetPosition(relativeTo);
	}

	private GestureData CreateGestureData(Task sourceTask, EventArgs inputArgs)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		if (inputArgs is KeyEventArgs)
		{
			ModelItem modelItem = Context.Items.GetValue<Selection>().PrimarySelection;
			if (modelItem == null && ModelService != null)
			{
				modelItem = ModelService.Root;
			}
			if (modelItem != null)
			{
				return new GestureData(_context, modelItem, modelItem);
			}
		}
		ModelItem modelItem2 = _hitModel;
		if (modelItem2 == null)
		{
			modelItem2 = _captureModel;
		}
		if (inputArgs is ToolActionEventArgs e)
		{
			inputArgs = e.SourceEvent;
		}
		Point val = GetMousePosition(inputArgs, (IInputElement)(object)this);
		GiveFeedbackEventArgs e2;
		if ((e2 = (GiveFeedbackEventArgs)(object)((inputArgs is GiveFeedbackEventArgs) ? inputArgs : null)) != null)
		{
			val = _lastCurrentPoint;
		}
		_lastCurrentPoint = val;
		ModelItem sourceModel;
		DependencyObject sourceAdorner;
		DependencyObject hitAdorner;
		Point startPosition;
		if (_captureOwner != null)
		{
			sourceModel = _captureModel;
			sourceAdorner = _captureAdorner;
			hitAdorner = _hitAdorner;
			startPosition = GetCapturePoint();
		}
		else
		{
			sourceModel = _hitModel;
			startPosition = val;
			sourceAdorner = _hitAdorner;
			hitAdorner = _hitAdorner;
		}
		DragEventArgs e3;
		MouseWheelEventArgs e4;
		GestureData gestureData = (((e3 = (DragEventArgs)(object)((inputArgs is DragEventArgs) ? inputArgs : null)) != null) ? new DragGestureData(_context, sourceModel, modelItem2, (Visual)(object)this, startPosition, val, _dragAllowedEffects, e3.Data, sourceAdorner, hitAdorner) : ((e2 != null) ? new DragGestureData(_context, sourceModel, modelItem2, (Visual)(object)this, startPosition, val, _dragAllowedEffects, _dragData, sourceAdorner, hitAdorner) : (((e4 = (MouseWheelEventArgs)(object)((inputArgs is MouseWheelEventArgs) ? inputArgs : null)) == null) ? ((GestureData)new MouseGestureData(_context, sourceModel, modelItem2, (Visual)(object)this, startPosition, val, sourceAdorner, hitAdorner)) : ((GestureData)new WheelGestureData(_context, sourceModel, modelItem2, e4.Delta, sourceAdorner, hitAdorner)))));
		gestureData.SourceTask = sourceTask;
		return gestureData;
	}

	private void ExecuteCommand(MatchGestureEventArgs command, DragEventArgs args, bool updateHitTest)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		DragGestureData dragGestureData = (DragGestureData)command.Data;
		dragGestureData.Effects = args.Effects;
		ExecuteCommand(command, updateHitTest);
		args.Effects = dragGestureData.Effects;
		if ((int)args.Effects != 0)
		{
			((RoutedEventArgs)args).Handled = true;
		}
	}

	private void ExecuteCommand(MatchGestureEventArgs command, bool updateHitTest)
	{
		bool nestedCall = BeginCall();
		try
		{
			if (this.CommandException != null)
			{
				if (_disableCatchAll.Level == TraceLevel.Off)
				{
					try
					{
						command.Binding.Command.Execute(command.Data);
					}
					catch (Exception exception)
					{
						OnCommandException(new CommandExceptionEventArgs(command.Binding.Command, exception));
					}
				}
				else
				{
					command.Binding.Command.Execute(command.Data);
				}
			}
			else
			{
				command.Binding.Command.Execute(command.Data);
			}
		}
		finally
		{
			EndCall(nestedCall);
		}
		if (updateHitTest)
		{
			_secondaryHitTestArgs = (EventArgs)(object)command.InputEvent;
		}
	}

	private MatchGestureEventArgs FindCommand(InputEventArgs eventArgs, FindCommandScope scope)
	{
		MatchGestureEventArgs e = null;
		if (_secondaryHitTestArgs != null)
		{
			PerformHitTest(_secondaryHitTestArgs);
		}
		if (!_inCall && !_clearingCapture && _context != null && (_hitModel != null || _captureModel != null || eventArgs is KeyboardEventArgs))
		{
			Task sourceTask;
			InputBinding binding = FindInputBinding(eventArgs, scope, out sourceTask);
			e = new MatchGestureEventArgs(eventArgs, binding, sourceTask, (Task localTask, InputEventArgs localArgs) => CreateGestureData(localTask, (EventArgs)(object)localArgs));
			OnMatchGesture(e);
			if (e.Binding == null || !e.Binding.Command.CanExecute(e.Data))
			{
				e = null;
			}
		}
		return e;
	}

	private InputBinding FindInputBinding(InputEventArgs args, FindCommandScope scope, out Task sourceTask)
	{
		InputBinding val = null;
		sourceTask = null;
		if (_focusedTask != null)
		{
			sourceTask = _focusedTask;
			val = FindInputBindingForTask(args, _focusedTask);
		}
		else
		{
			bool flag = true;
			if ((scope & FindCommandScope.SourceAdorner) == FindCommandScope.SourceAdorner && _captureAdorner != null)
			{
				val = FindInputBindingForAdorner(args, _captureAdorner, out sourceTask);
				flag = false;
			}
			if (val == null && (scope & FindCommandScope.TargetAdorner) == FindCommandScope.TargetAdorner && _hitAdorner != null)
			{
				val = FindInputBindingForAdorner(args, _hitAdorner, out sourceTask);
				flag = false;
			}
			if (flag && val == null && (scope & FindCommandScope.Tool) == FindCommandScope.Tool)
			{
				Tool value = Context.Items.GetValue<Tool>();
				foreach (Task task in value.Tasks)
				{
					val = FindInputBindingForTask(args, task);
					if (val != null)
					{
						sourceTask = task;
						break;
					}
				}
			}
		}
		return val;
	}

	private static InputBinding FindInputBindingForAdorner(InputEventArgs args, DependencyObject adorner, out Task sourceTask)
	{
		InputBinding val = null;
		sourceTask = null;
		if (adorner.GetValue(AdornerProperties.TaskProperty) is Task task)
		{
			val = FindInputBindingForTask(args, task);
			if (val != null)
			{
				sourceTask = task;
			}
		}
		return val;
	}

	private static InputBinding FindInputBindingForTask(InputEventArgs args, Task task)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		foreach (InputBinding inputBinding in task.InputBindings)
		{
			InputBinding val = inputBinding;
			if (val.Gesture.Matches(((RoutedEventArgs)args).OriginalSource, args))
			{
				return val;
			}
		}
		return null;
	}

	private static bool IsChildOf(DependencyObject parent, DependencyObject child)
	{
		Visual val;
		if ((val = (Visual)(object)((parent is Visual) ? parent : null)) != null)
		{
			return val.IsAncestorOf(child);
		}
		Visual3D val2;
		if ((val2 = (Visual3D)(object)((parent is Visual3D) ? parent : null)) != null)
		{
			return val2.IsAncestorOf(child);
		}
		return false;
	}

	private static void OnAdornersVisibleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		if (sender is DesignerView designerView)
		{
			Visibility visibility = (Visibility)((!object.Equals(((DependencyPropertyChangedEventArgs)(ref args)).NewValue, true)) ? 2 : 0);
			((UIElement)designerView._adornerLayer).Visibility = visibility;
		}
	}

	protected virtual void OnCommandException(CommandExceptionEventArgs e)
	{
		if (this.CommandException != null)
		{
			this.CommandException(this, e);
		}
	}

	protected virtual void OnMatchGesture(MatchGestureEventArgs e)
	{
		if (this.MatchGesture != null)
		{
			this.MatchGesture(this, e);
		}
	}

	private void OnCanExecuteCommand(object sender, CanExecuteRoutedEventArgs args)
	{
		if (_context == null || ((RoutedEventArgs)args).OriginalSource == _adornerLayer || ((RoutedEventArgs)args).Handled)
		{
			return;
		}
		Tool value = _context.Items.GetValue<Tool>();
		ICommand command = args.Command;
		RoutedCommand val = (RoutedCommand)((command is RoutedCommand) ? command : null);
		if (val == null)
		{
			return;
		}
		DependencyObject sourceAdorner;
		DependencyObject hitAdorner;
		if (_captureOwner != null)
		{
			sourceAdorner = _captureAdorner;
			hitAdorner = _hitAdorner;
		}
		else
		{
			sourceAdorner = _hitAdorner;
			hitAdorner = _hitAdorner;
		}
		CommandBinding commandBinding = value.GetCommandBinding(args.Command, sourceAdorner, hitAdorner);
		if (commandBinding != null)
		{
			((RoutedEventArgs)args).Handled = true;
			try
			{
				((UIElement)_adornerLayer).CommandBindings.Add(commandBinding);
				args.CanExecute = val.CanExecute(args.Parameter, (IInputElement)(object)_adornerLayer);
			}
			finally
			{
				((UIElement)_adornerLayer).CommandBindings.Remove(commandBinding);
			}
		}
	}

	private void OnExecutedCommand(object sender, ExecutedRoutedEventArgs args)
	{
		if (_context == null || ((RoutedEventArgs)args).Handled || ((RoutedEventArgs)args).OriginalSource == _adornerLayer || ((RoutedEventArgs)args).Handled)
		{
			return;
		}
		Tool value = _context.Items.GetValue<Tool>();
		ICommand command = args.Command;
		RoutedCommand val = (RoutedCommand)((command is RoutedCommand) ? command : null);
		if (val == null)
		{
			return;
		}
		DependencyObject sourceAdorner;
		DependencyObject hitAdorner;
		if (_captureOwner != null)
		{
			sourceAdorner = _captureAdorner;
			hitAdorner = _hitAdorner;
		}
		else
		{
			sourceAdorner = _hitAdorner;
			hitAdorner = _hitAdorner;
		}
		CommandBinding commandBinding = value.GetCommandBinding(args.Command, sourceAdorner, hitAdorner);
		if (commandBinding == null)
		{
			return;
		}
		((RoutedEventArgs)args).Handled = true;
		try
		{
			((UIElement)_adornerLayer).CommandBindings.Add(commandBinding);
			if (this.CommandException != null)
			{
				try
				{
					val.Execute(args.Parameter, (IInputElement)(object)_adornerLayer);
					return;
				}
				catch (Exception exception)
				{
					OnCommandException(new CommandExceptionEventArgs((ICommand)val, exception));
					return;
				}
			}
			val.Execute(args.Parameter, (IInputElement)(object)_adornerLayer);
		}
		finally
		{
			((UIElement)_adornerLayer).CommandBindings.Remove(commandBinding);
		}
	}

	protected override Visual GetVisualChild(int index)
	{
		if (((Decorator)this).Child != null)
		{
			switch (index)
			{
			case 0:
				return (Visual)(object)((Decorator)this).Child;
			case 1:
				return (Visual)(object)_hitTestLayer;
			case 2:
				return (Visual)(object)_adornerLayer;
			}
		}
		return (Visual)(object)((Decorator)this).Child;
	}

	protected override Size ArrangeOverride(Size arrangeSize)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		Size result = ((Decorator)this).ArrangeOverride(arrangeSize);
		if (VisualTreeHelper.GetParent((DependencyObject)(object)_adornerLayer) != null)
		{
			((UIElement)_adornerLayer).Arrange(new Rect(arrangeSize));
			((UIElement)_hitTestLayer).Arrange(new Rect(arrangeSize));
		}
		return result;
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		Size result = ((Decorator)this).MeasureOverride(constraint);
		if (VisualTreeHelper.GetParent((DependencyObject)(object)_adornerLayer) != null)
		{
			((UIElement)_adornerLayer).Measure(constraint);
			((UIElement)_hitTestLayer).Measure(constraint);
		}
		return result;
	}

	private void OnDecoratorDragEnter(object sender, DragEventArgs args)
	{
		PerformHitTest((EventArgs)(object)args);
		if (!((RoutedEventArgs)args).Handled)
		{
			PerformDragEnterLeave(args, null, null);
			((RoutedEventArgs)args).Handled = true;
		}
	}

	private void OnDecoratorDragLeave(object sender, DragEventArgs args)
	{
		ModelItem hitModel = _hitModel;
		DependencyObject hitAdorner = _hitAdorner;
		ClearAllHitTestInfo();
		if (!((RoutedEventArgs)args).Handled)
		{
			PerformDragEnterLeave(args, hitModel, hitAdorner);
		}
	}

	private void OnDecoratorDragOver(object sender, DragEventArgs args)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		ModelItem hitModel = _hitModel;
		DependencyObject hitAdorner = _hitAdorner;
		args.Effects = (DragDropEffects)0;
		PerformHitTest((EventArgs)(object)args);
		_dragAllowedEffects = args.AllowedEffects;
		_dragData = args.Data;
		if (!((RoutedEventArgs)args).Handled)
		{
			PerformDragEnterLeave(args, hitModel, hitAdorner);
			ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.DragOver, (EventArgs)(object)args, (InputDevice)(object)Mouse.PrimaryDevice, Environment.TickCount);
			MatchGestureEventArgs e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.All);
			if (e != null)
			{
				ExecuteCommand(e, args, updateHitTest: true);
			}
			((RoutedEventArgs)args).Handled = true;
		}
	}

	private void OnDecoratorDrop(object sender, DragEventArgs args)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			PerformHitTest((EventArgs)(object)args);
			if (!((RoutedEventArgs)args).Handled)
			{
				ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.DragDrop, (EventArgs)(object)args, (InputDevice)(object)Mouse.PrimaryDevice, Environment.TickCount);
				MatchGestureEventArgs e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.All);
				if (e != null)
				{
					ExecuteCommand(e, args, updateHitTest: true);
				}
			}
		}
		finally
		{
			_dragAllowedEffects = (DragDropEffects)0;
			_dragData = null;
		}
	}

	private void OnDecoratorGiveFeedback(object sender, GiveFeedbackEventArgs args)
	{
		if (_dragData == null || ((RoutedEventArgs)args).Handled)
		{
			return;
		}
		ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.DragFeedback, (EventArgs)(object)args, (InputDevice)(object)Mouse.PrimaryDevice, Environment.TickCount);
		MatchGestureEventArgs e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.All);
		if (e != null)
		{
			ExecuteCommand(e, updateHitTest: false);
			args.UseDefaultCursors = false;
			((RoutedEventArgs)args).Handled = true;
			return;
		}
		Tool value = _context.Items.GetValue<Tool>();
		Cursor cursor = value.Cursor;
		if (cursor != null)
		{
			Mouse.SetCursor(cursor);
			args.UseDefaultCursors = false;
			((RoutedEventArgs)args).Handled = true;
		}
	}

	private void PerformDragEnterLeave(DragEventArgs args, ModelItem priorModelHit, DependencyObject priorAdornerHit)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		if (priorModelHit == _hitModel && priorAdornerHit == _hitAdorner)
		{
			return;
		}
		ToolActionEventArgs eventArgs;
		MatchGestureEventArgs e;
		if (priorModelHit != null)
		{
			ModelItem hitModel = _hitModel;
			DependencyObject hitAdorner = _hitAdorner;
			_hitModel = priorModelHit;
			_hitAdorner = priorAdornerHit;
			try
			{
				eventArgs = new ToolActionEventArgs(ToolAction.DragLeave, (EventArgs)(object)args, (InputDevice)(object)Mouse.PrimaryDevice, Environment.TickCount);
				e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.All);
				if (e != null)
				{
					ExecuteCommand(e, args, updateHitTest: true);
				}
			}
			finally
			{
				_hitModel = hitModel;
				_hitAdorner = hitAdorner;
				_dragAllowedEffects = (DragDropEffects)0;
				_dragData = null;
			}
		}
		_dragAllowedEffects = args.AllowedEffects;
		_dragData = args.Data;
		eventArgs = new ToolActionEventArgs(ToolAction.DragEnter, (EventArgs)(object)args, (InputDevice)(object)Mouse.PrimaryDevice, Environment.TickCount);
		e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.All);
		if (e != null)
		{
			ExecuteCommand(e, args, updateHitTest: true);
		}
	}

	private void OnMouseEnter(object sender, MouseEventArgs args)
	{
		ModelItem hitModel = _hitModel;
		DependencyObject hitAdorner = _hitAdorner;
		PerformHitTest((EventArgs)(object)args);
		if (!((RoutedEventArgs)args).Handled)
		{
			PerformMouseEnterLeave((InputEventArgs)(object)args, hitModel, hitAdorner, usePreviousModelForEnter: false);
		}
	}

	private void OnMouseLeave(object sender, MouseEventArgs args)
	{
		ModelItem hitModel = _hitModel;
		DependencyObject hitAdorner = _hitAdorner;
		PerformHitTest((EventArgs)(object)args);
		if (!((RoutedEventArgs)args).Handled)
		{
			PerformMouseEnterLeave((InputEventArgs)(object)args, hitModel, hitAdorner, usePreviousModelForEnter: false);
		}
	}

	private void OnMouseMove(object sender, MouseEventArgs args)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		Point lastPointInParentCoordinates = ((Visual)this).PointToScreen(args.GetPosition((IInputElement)(object)this));
		if (!((Point)(ref lastPointInParentCoordinates)).Equals(_lastPointInParentCoordinates) && !_capturingMouse)
		{
			ModelItem hitModel = _hitModel;
			DependencyObject hitAdorner = _hitAdorner;
			PerformHitTest((EventArgs)(object)args);
			PerformMouseEnterLeave((InputEventArgs)(object)args, hitModel, hitAdorner, usePreviousModelForEnter: false);
			PerformMouseMove(args);
			PerformMouseDragIntent(args);
			StartHoverCountdown();
			_lastPointInParentCoordinates = lastPointInParentCoordinates;
		}
	}

	private void OnMouseDown(object sender, MouseButtonEventArgs args)
	{
		StopHoverCountdown();
		ModelItem hitModel = _hitModel;
		DependencyObject hitAdorner = _hitAdorner;
		PerformHitTest((EventArgs)(object)args);
		if (hitModel != _hitModel || hitAdorner != _hitAdorner)
		{
			PerformMouseEnterLeave((InputEventArgs)(object)args, hitModel, hitAdorner, usePreviousModelForEnter: false);
		}
		if (!((RoutedEventArgs)args).Handled)
		{
			ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.Down, (InputEventArgs)(object)args);
			MatchGestureEventArgs e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.All);
			if (e != null)
			{
				SetMouseDownState(args);
				ExecuteCommand(e, updateHitTest: true);
				((RoutedEventArgs)args).Handled = true;
			}
			else if (_hitModel != null)
			{
				SetMouseDownState(args);
				((RoutedEventArgs)args).Handled = true;
			}
		}
	}

	private void OnMouseUp(object sender, MouseButtonEventArgs args)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected I4, but got Unknown
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		PerformHitTest((EventArgs)(object)args);
		int num = (int)args.ChangedButton;
		MouseState mouseState = _mouseState[num];
		ModelItem captureModel = _captureModel;
		DependencyObject captureAdorner = _captureAdorner;
		try
		{
			if (!_abortCapture)
			{
				bool handled = ((RoutedEventArgs)args).Handled;
				if (mouseState.MouseButtonStage != MouseButtonStage.None && !handled)
				{
					ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.Up, (InputEventArgs)(object)args);
					MatchGestureEventArgs e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.All);
					if (e != null)
					{
						ExecuteCommand(e, updateHitTest: true);
						((RoutedEventArgs)args).Handled = true;
					}
				}
				mouseState = _mouseState[num];
				if (mouseState.MouseButtonStage == MouseButtonStage.DragIntentRaised)
				{
					ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.DragComplete, (InputEventArgs)(object)args);
					PerformHitTest((EventArgs)(object)eventArgs);
					MatchGestureEventArgs e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.All);
					if (e != null)
					{
						ExecuteCommand(e, updateHitTest: true);
						((RoutedEventArgs)args).Handled = true;
					}
				}
				mouseState = _mouseState[num];
				if (mouseState.MouseButtonStage == MouseButtonStage.MouseDown)
				{
					if (mouseState.DispatcherClickCount > 0 && Math.Abs(((Point)(ref mouseState.MouseDownPosition)).X - ((Point)(ref _clickPoint)).X) < (double)_doubleClickSizeX && Math.Abs(((Point)(ref mouseState.MouseDownPosition)).Y - ((Point)(ref _clickPoint)).Y) < (double)_doubleClickSizeY)
					{
						_clickCount++;
					}
					else
					{
						_clickCount = 0;
					}
					if (_hitModel != null && _hitModel == _clickModel && _hitAdorner == _clickAdorner && !handled)
					{
						MatchGestureEventArgs e;
						if (_clickCount > 0)
						{
							ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.Click, (InputEventArgs)(object)args);
							PerformHitTest((EventArgs)(object)eventArgs);
							e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.SourceAdorner | FindCommandScope.Tool);
							if (e != null)
							{
								ExecuteCommand(e, updateHitTest: true);
								((RoutedEventArgs)args).Handled = true;
							}
						}
						e = FindCommand((InputEventArgs)(object)args, FindCommandScope.All);
						if (e != null)
						{
							ExecuteCommand(e, updateHitTest: true);
							((RoutedEventArgs)args).Handled = true;
						}
						if (_clickCount == 2 && !handled)
						{
							ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.DoubleClick, (InputEventArgs)(object)args);
							PerformHitTest((EventArgs)(object)eventArgs);
							e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.SourceAdorner | FindCommandScope.Tool);
							if (e != null)
							{
								ExecuteCommand(e, updateHitTest: true);
								((RoutedEventArgs)args).Handled = true;
							}
						}
					}
				}
			}
		}
		finally
		{
			mouseState.MouseButtonStage = MouseButtonStage.None;
			_mouseState[num] = mouseState;
			if (_captureOwner != null && (int)((MouseEventArgs)args).LeftButton == 0 && (int)((MouseEventArgs)args).MiddleButton == 0 && (int)((MouseEventArgs)args).RightButton == 0 && (int)((MouseEventArgs)args).XButton1 == 0 && (int)((MouseEventArgs)args).XButton2 == 0)
			{
				ClearCapture();
			}
		}
		PerformMouseEnterLeave((InputEventArgs)(object)args, captureModel, captureAdorner, usePreviousModelForEnter: false);
	}

	private void OnMouseWheel(object sender, MouseWheelEventArgs args)
	{
		if (!((RoutedEventArgs)args).Handled)
		{
			ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.Wheel, (InputEventArgs)(object)args);
			MatchGestureEventArgs e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.All);
			if (e != null)
			{
				ExecuteCommand(e, updateHitTest: true);
				((RoutedEventArgs)args).Handled = true;
			}
		}
	}

	private void OnHoverTimeout(object sender, EventArgs args)
	{
		_hoverTimer.Stop();
		ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.Hover, args, (InputDevice)(object)Mouse.PrimaryDevice, Environment.TickCount);
		MatchGestureEventArgs e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.All);
		if (e != null)
		{
			ExecuteCommand(e, updateHitTest: true);
		}
	}

	private void PerformMouseEnterLeave(InputEventArgs args, ModelItem priorModelHit, DependencyObject priorAdornerHit, bool usePreviousModelForEnter)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (priorModelHit == _hitModel && priorAdornerHit == _hitAdorner)
		{
			return;
		}
		_clickCount = 0;
		_clickPoint = default(Point);
		ModelItem hitModel = _hitModel;
		DependencyObject hitAdorner = _hitAdorner;
		ViewItem hitRawModelVisual = _hitRawModelVisual;
		if (priorModelHit != null)
		{
			_hitModel = priorModelHit;
			_hitAdorner = priorAdornerHit;
			try
			{
				ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.Leave, args);
				MatchGestureEventArgs e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.All);
				if (e != null)
				{
					ExecuteCommand(e, updateHitTest: true);
					((RoutedEventArgs)args).Handled = true;
				}
			}
			finally
			{
				_hitModel = hitModel;
				_hitAdorner = hitAdorner;
				_hitRawModelVisual = hitRawModelVisual;
			}
		}
		if (usePreviousModelForEnter)
		{
			_hitModel = priorModelHit;
			_hitAdorner = priorAdornerHit;
		}
		try
		{
			if (_hitModel != null)
			{
				ToolActionEventArgs eventArgs2 = new ToolActionEventArgs(ToolAction.Enter, args);
				MatchGestureEventArgs e2 = FindCommand((InputEventArgs)(object)eventArgs2, FindCommandScope.All);
				if (e2 != null)
				{
					ExecuteCommand(e2, updateHitTest: true);
					((RoutedEventArgs)args).Handled = true;
				}
			}
			else if (_captureOwner != null)
			{
				ToolActionEventArgs eventArgs3 = new ToolActionEventArgs(ToolAction.DragOutside, args);
				MatchGestureEventArgs e3 = FindCommand((InputEventArgs)(object)eventArgs3, FindCommandScope.All);
				if (e3 != null)
				{
					ExecuteCommand(e3, updateHitTest: true);
					((RoutedEventArgs)args).Handled = true;
				}
			}
		}
		finally
		{
			if (usePreviousModelForEnter)
			{
				_hitModel = hitModel;
				_hitAdorner = hitAdorner;
				_hitRawModelVisual = hitRawModelVisual;
			}
		}
	}

	private void PerformMouseDragIntent(MouseEventArgs args)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (_captureOwner == null)
		{
			return;
		}
		for (int i = 0; i < _mouseState.Length; i++)
		{
			MouseState mouseState = _mouseState[i];
			if (mouseState.MouseButtonStage != MouseButtonStage.MouseDown)
			{
				continue;
			}
			Point position = args.GetPosition((IInputElement)(object)this);
			if (!(Math.Abs(((Point)(ref position)).X - ((Point)(ref mouseState.MouseDownPosition)).X) >= MinHorizontalDragDistance) && !(Math.Abs(((Point)(ref position)).Y - ((Point)(ref mouseState.MouseDownPosition)).Y) >= MinVerticalDragDistance))
			{
				continue;
			}
			mouseState.MouseButtonStage = MouseButtonStage.DragIntentRaised;
			_mouseState[i] = mouseState;
			if (_hitModel != null)
			{
				ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.DragIntent, (InputEventArgs)(object)args);
				PerformHitTest((EventArgs)(object)eventArgs);
				MatchGestureEventArgs e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.SourceAdorner | FindCommandScope.Tool);
				if (e != null)
				{
					ExecuteCommand(e, updateHitTest: true);
					((RoutedEventArgs)args).Handled = true;
				}
			}
		}
	}

	private void PerformMouseMove(MouseEventArgs args)
	{
		ToolActionEventArgs eventArgs = new ToolActionEventArgs(ToolAction.Move, (InputEventArgs)(object)args);
		MatchGestureEventArgs e = FindCommand((InputEventArgs)(object)eventArgs, FindCommandScope.All);
		if (e != null)
		{
			ExecuteCommand(e, updateHitTest: true);
			((RoutedEventArgs)args).Handled = true;
		}
	}

	private void SetMouseDownState(MouseButtonEventArgs args)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected I4, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		if (_captureOwner == null)
		{
			SetCapture((UIElement)(object)this);
		}
		((UIElement)this).Focus();
		int num = (int)args.ChangedButton;
		MouseState mouseState = _mouseState[num];
		mouseState.MouseDownPosition = ((MouseEventArgs)args).GetPosition((IInputElement)(object)this);
		mouseState.MouseButtonStage = MouseButtonStage.MouseDown;
		mouseState.DispatcherClickCount = args.ClickCount;
		_mouseState[num] = mouseState;
		if (mouseState.DispatcherClickCount == 1)
		{
			_clickCount = 0;
			_clickModel = _hitModel;
			_clickAdorner = _hitAdorner;
			_clickPoint = mouseState.MouseDownPosition;
		}
	}

	private void StartHoverCountdown()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		Point position = Mouse.GetPosition((IInputElement)(object)this);
		if (_hoverTimer == null)
		{
			_hoverTimer = new DispatcherTimer(new TimeSpan(_hoverTimeout), (DispatcherPriority)2, (EventHandler)OnHoverTimeout, Dispatcher.CurrentDispatcher);
			_hoverTimer.Start();
			_hoverPoint = position;
		}
		else if (Math.Abs(((Point)(ref position)).X - ((Point)(ref _hoverPoint)).X) >= (double)_hoverSizeX || Math.Abs(((Point)(ref position)).Y - ((Point)(ref _hoverPoint)).Y) >= (double)_hoverSizeY)
		{
			_hoverPoint = position;
			_hoverTimer.Stop();
			_hoverTimer.Start();
		}
	}

	private void StopHoverCountdown()
	{
		if (_hoverTimer != null)
		{
			_hoverTimer.Stop();
		}
	}

	private void OnHitTestQueryCursor(object sender, QueryCursorEventArgs args)
	{
		if (!((RoutedEventArgs)args).Handled && _context != null)
		{
			Tool value = _context.Items.GetValue<Tool>();
			Cursor cursor = value.Cursor;
			if (cursor != null)
			{
				args.Cursor = cursor;
				((RoutedEventArgs)args).Handled = true;
			}
		}
	}

	private void OnDecoratorKeyDown(object sender, KeyEventArgs args)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		if (((RoutedEventArgs)args).Handled)
		{
			return;
		}
		if ((int)args.Key == 13)
		{
			AbortCapture();
			if (_focusedTask != null)
			{
				_focusedTask.Revert();
			}
			((RoutedEventArgs)args).Handled = true;
			return;
		}
		ModelItem hitModel = _hitModel;
		DependencyObject hitAdorner = _hitAdorner;
		PerformHitTest((EventArgs)(object)args);
		PerformMouseEnterLeave((InputEventArgs)(object)args, hitModel, hitAdorner, usePreviousModelForEnter: false);
		MatchGestureEventArgs e = FindCommand((InputEventArgs)(object)args, FindCommandScope.Tool);
		if (e != null)
		{
			ExecuteCommand(e, updateHitTest: true);
			((RoutedEventArgs)args).Handled = true;
		}
	}

	private void OnLostMouseCapture(object sender, MouseEventArgs args)
	{
		if (!_clearingCapture)
		{
			AbortCapture();
		}
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		if (!_protectReEntrantCode && _designerViewAutomationPeer == null)
		{
			try
			{
				_protectReEntrantCode = true;
				_designerViewAutomationPeer = new DesignerViewAutomationPeer(this);
			}
			finally
			{
				_protectReEntrantCode = false;
			}
		}
		return (AutomationPeer)(object)_designerViewAutomationPeer;
	}

	private static bool IsZoomLevelValid(object value)
	{
		double num = (double)value;
		return num > 0.0;
	}

	private static void HandleZoomLevelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is DesignerView designerView)
		{
			designerView.SetZoomTransform();
			if (designerView.ZoomLevelChanged != null)
			{
				designerView.ZoomLevelChanged(designerView, EventArgs.Empty);
			}
		}
	}

	public virtual Transform GetZoomTransform()
	{
		return TransformUtil.GetTransformToImmediateParent((DependencyObject)(object)this);
	}

	protected virtual void SetZoomTransform()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		double zoomLevel = ZoomLevel;
		((FrameworkElement)this).LayoutTransform = (Transform)new ScaleTransform(zoomLevel, zoomLevel);
	}
}
