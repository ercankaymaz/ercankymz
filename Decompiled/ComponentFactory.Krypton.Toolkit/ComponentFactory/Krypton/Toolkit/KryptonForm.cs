#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonForm), "ToolboxBitmaps.KryptonForm.bmp")]
[Description("Draws the window chrome using a Krypton palette.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonForm : VisualForm, IContentValues
{
	public class FormButtonSpecCollection : ButtonSpecCollection<ButtonSpecAny>
	{
		public FormButtonSpecCollection(KryptonForm owner)
			: base((object)owner)
		{
		}
	}

	public class FormFixedButtonSpecCollection : ButtonSpecCollection<ButtonSpecFormFixed>
	{
		public FormFixedButtonSpecCollection(KryptonForm owner)
			: base((object)owner)
		{
		}
	}

	private static readonly Size CAPTION_ICON_SIZE = new Size(16, 16);

	private static readonly int _htCorner = 8;

	private FormButtonSpecCollection _buttonSpecs;

	private FormFixedButtonSpecCollection _buttonSpecsFixed;

	private ButtonSpecFormWindowMin _buttonSpecMin;

	private ButtonSpecFormWindowMax _buttonSpecMax;

	private ButtonSpecFormWindowClose _buttonSpecClose;

	private ButtonSpecManagerDraw _buttonManager;

	private VisualPopupToolTip _visualPopupToolTip;

	private ToolTipManager _toolTipManager;

	private ViewDrawForm _drawDocker;

	private ViewDrawDocker _drawHeading;

	private ViewDrawContent _drawContent;

	private ViewDecoratorFixedSize _headingFixedSize;

	private PaletteFormRedirect _stateCommon;

	private PaletteForm _stateInactive;

	private PaletteForm _stateActive;

	private ViewLayoutNull _layoutNull;

	private HeaderStyle _headerStyle;

	private HeaderStyle _headerStylePrev;

	private FormWindowState _regionWindowState;

	private FormWindowState _lastWindowState;

	private string _textExtra;

	private string _oldText;

	private bool _allowButtonSpecToolTips;

	private bool _allowFormChrome;

	private bool _allowStatusStripMerge;

	private bool _allowIconDisplay;

	private bool _inertForm;

	private bool _recreateButtons;

	private bool _firstCheckView;

	private bool _lastNotNormal;

	private StatusStrip _statusStrip;

	private Bitmap _cacheBitmap;

	private Icon _cacheIcon;

	private Rectangle _customCaptionArea;

	[Category("Appearance")]
	[Description("The extra text associated with the control.")]
	[DefaultValue("")]
	public string TextExtra
	{
		get
		{
			return _textExtra;
		}
		set
		{
			_textExtra = value;
			PerformNeedPaint(needLayout: true);
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
	[Description("Should custom chrome be allowed for this KryptonForm instance.")]
	[DefaultValue(true)]
	public bool AllowFormChrome
	{
		get
		{
			return _allowFormChrome;
		}
		set
		{
			if (_allowFormChrome != value)
			{
				_allowFormChrome = value;
				UpdateCustomChromeDecision();
			}
		}
	}

	[Category("Visuals")]
	[Description("Should the form status strip be considered for merging into chrome.")]
	[DefaultValue(true)]
	public bool AllowStatusStripMerge
	{
		get
		{
			return _allowStatusStripMerge;
		}
		set
		{
			if (_allowStatusStripMerge != value)
			{
				_allowStatusStripMerge = value;
				if (_statusStrip != null)
				{
					_statusStrip.Invalidate();
				}
				PerformNeedPaint(needLayout: false);
			}
		}
	}

	[Category("Visuals")]
	[Description("Header style for a main form.")]
	[DefaultValue(typeof(HeaderStyle), "Form")]
	public HeaderStyle HeaderStyle
	{
		get
		{
			return _headerStyle;
		}
		set
		{
			if (_headerStyle != value)
			{
				_headerStyle = value;
				PerformNeedPaint(needLayout: false);
			}
		}
	}

	[Category("Visuals")]
	[Description("Chrome group border style.")]
	[DefaultValue(typeof(PaletteBorderStyle), "FormMain")]
	public PaletteBorderStyle GroupBorderStyle
	{
		get
		{
			return _stateCommon.BorderStyle;
		}
		set
		{
			if (_stateCommon.BorderStyle != value)
			{
				_stateCommon.BorderStyle = value;
				PerformNeedPaint(needLayout: false);
			}
		}
	}

	[Category("Visuals")]
	[Description("Chrome group background style.")]
	[DefaultValue(typeof(PaletteBackStyle), "FormMain")]
	public PaletteBackStyle GroupBackStyle
	{
		get
		{
			return _stateCommon.BackStyle;
		}
		set
		{
			if (_stateCommon.BackStyle != value)
			{
				_stateCommon.BackStyle = value;
				PerformNeedPaint(needLayout: false);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining common form appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteFormRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining inactive form appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteForm StateInactive => _stateInactive;

	[Category("Visuals")]
	[Description("Overrides for defining active form appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteForm StateActive => _stateActive;

	[Category("Visuals")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public FormButtonSpecCollection ButtonSpecs => _buttonSpecs;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ButtonSpecFormWindowMin ButtonSpecMin => _buttonSpecMin;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ButtonSpecFormWindowMax ButtonSpecMax => _buttonSpecMax;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ButtonSpecFormWindowClose ButtonSpecClose => _buttonSpecClose;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool InertForm
	{
		get
		{
			return _inertForm;
		}
		set
		{
			_inertForm = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool AllowIconDisplay
	{
		get
		{
			return _allowIconDisplay;
		}
		set
		{
			_allowIconDisplay = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ToolTipManager ToolTipManager => _toolTipManager;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Rectangle CustomCaptionArea
	{
		get
		{
			return _customCaptionArea;
		}
		set
		{
			_customCaptionArea = value;
		}
	}

	internal bool StatusStripMerging => _allowStatusStripMerge && _statusStrip != null && _statusStrip.Visible && _statusStrip.Dock == DockStyle.Bottom && _statusStrip.Bottom == base.ClientRectangle.Bottom && _statusStrip.RenderMode == ToolStripRenderMode.ManagerRenderMode && (ToolStripManager.Renderer is KryptonOffice2007Renderer || ToolStripManager.Renderer is KryptonSparkleRenderer);

	public KryptonForm()
	{
		_headerStyle = HeaderStyle.Form;
		_headerStylePrev = _headerStyle;
		_allowButtonSpecToolTips = false;
		_allowFormChrome = true;
		_allowStatusStripMerge = true;
		_allowIconDisplay = true;
		_regionWindowState = FormWindowState.Normal;
		_recreateButtons = true;
		_firstCheckView = true;
		_lastNotNormal = false;
		_buttonSpecs = new FormButtonSpecCollection(this);
		_buttonSpecsFixed = new FormFixedButtonSpecCollection(this);
		_buttonSpecMin = new ButtonSpecFormWindowMin(this);
		_buttonSpecMax = new ButtonSpecFormWindowMax(this);
		_buttonSpecClose = new ButtonSpecFormWindowClose(this);
		_buttonSpecsFixed.AddRange(new ButtonSpecFormFixed[3] { _buttonSpecMin, _buttonSpecMax, _buttonSpecClose });
		_stateCommon = new PaletteFormRedirect(base.Redirector, base.NeedPaintDelegate);
		_stateInactive = new PaletteForm(_stateCommon, _stateCommon.Header, base.NeedPaintDelegate);
		_stateActive = new PaletteForm(_stateCommon, _stateCommon.Header, base.NeedPaintDelegate);
		_drawHeading = new ViewDrawDocker(_stateActive.Header.Back, _stateActive.Header.Border, _stateActive.Header, PaletteMetricBool.None, PaletteMetricPadding.None, VisualOrientation.Top);
		_drawHeading.ForceBorderFirst = true;
		_drawContent = new ViewDrawContent(_stateActive.Header.Content, this, VisualOrientation.Top);
		_drawHeading.Add(_drawContent, ViewDockStyle.Fill);
		_headingFixedSize = new ViewDecoratorFixedSize(_drawHeading, Size.Empty);
		_layoutNull = new ViewLayoutNull();
		_drawDocker = new ViewDrawForm(_stateActive.Back, _stateActive.Border);
		_drawDocker.Add(_headingFixedSize, ViewDockStyle.Top);
		_drawDocker.Add(_layoutNull, ViewDockStyle.Fill);
		_buttonManager = new ButtonSpecManagerDraw(this, base.Redirector, _buttonSpecs, _buttonSpecsFixed, new ViewDrawDocker[1] { _drawHeading }, new IPaletteMetric[1] { _stateCommon.Header }, new PaletteMetricInt[1] { PaletteMetricInt.HeaderButtonEdgeInsetForm }, new PaletteMetricPadding[1] { PaletteMetricPadding.HeaderButtonPaddingForm }, base.CreateToolStripRenderer, OnButtonManagerNeedPaint);
		_toolTipManager = new ToolTipManager();
		_toolTipManager.ShowToolTip += OnShowToolTip;
		_toolTipManager.CancelToolTip += OnCancelToolTip;
		_buttonManager.ToolTipManager = _toolTipManager;
		KryptonManager.GlobalAllowFormChromeChanged += OnGlobalAllowFormChromeChanged;
		KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;
		base.ViewManager = new ViewManager(this, _drawDocker);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			OnCancelToolTip(this, EventArgs.Empty);
			_buttonManager.Destruct();
			KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged;
			KryptonManager.GlobalAllowFormChromeChanged -= OnGlobalAllowFormChromeChanged;
			if (_cacheBitmap != null)
			{
				_cacheBitmap.Dispose();
				_cacheBitmap = null;
			}
			_buttonSpecMin.Dispose();
			_buttonSpecMax.Dispose();
			_buttonSpecClose.Dispose();
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateInactive()
	{
		return !_stateInactive.IsDefault;
	}

	private bool ShouldSerializeStateActive()
	{
		return !_stateActive.IsDefault;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void InjectViewElement(ViewBase element, ViewDockStyle style)
	{
		Debug.Assert(element != null);
		Debug.Assert(_drawHeading != null);
		if (base.IsDisposed)
		{
			return;
		}
		if (style == ViewDockStyle.Fill)
		{
			if (element is ViewLayoutDocker)
			{
				ViewLayoutDocker viewLayoutDocker = element as ViewLayoutDocker;
				_drawHeading.Remove(_drawContent);
				_drawHeading.Add(viewLayoutDocker, ViewDockStyle.Fill);
				viewLayoutDocker.Add(_drawContent, ViewDockStyle.Fill);
			}
		}
		else
		{
			_drawHeading.Add(element, style);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RevokeViewElement(ViewBase element, ViewDockStyle style)
	{
		Debug.Assert(element != null);
		if (base.IsDisposed)
		{
			return;
		}
		if (style == ViewDockStyle.Fill)
		{
			if (element is ViewLayoutDocker)
			{
				ViewLayoutDocker viewLayoutDocker = element as ViewLayoutDocker;
				viewLayoutDocker.Remove(_drawContent);
				_drawHeading.Remove(viewLayoutDocker);
				_drawHeading.Add(_drawContent, ViewDockStyle.Fill);
			}
		}
		else
		{
			_drawHeading.Remove(element);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RecreateMinMaxCloseButtons()
	{
		_recreateButtons = true;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public FormWindowState GetWindowState()
	{
		uint windowLong = PI.GetWindowLong(base.Handle, -16);
		if ((windowLong & 0x20000000) != 0)
		{
			return FormWindowState.Minimized;
		}
		if ((windowLong & 0x1000000) != 0)
		{
			return FormWindowState.Maximized;
		}
		return FormWindowState.Normal;
	}

	public override void WindowChromeCompositionLayout(ViewLayoutContext context, Rectangle compRect)
	{
		_buttonManager.RefreshButtons(composition: true);
		_drawContent.DrawContentOnComposition = true;
		_headingFixedSize.FixedSize = new Size(compRect.Height, compRect.Height);
		base.ViewManager.Layout(context);
	}

	public override void WindowChromeCompositionPaint(RenderContext context)
	{
		_drawDocker.DrawCanvas = false;
		_drawHeading.DrawCanvas = false;
		base.ViewManager.Paint(context);
	}

	public bool HitTestMinButton(Point pt)
	{
		return _buttonManager.GetButtonRectangle(_buttonSpecMin).Contains(pt);
	}

	public bool HitTestMaxButton(Point pt)
	{
		return _buttonManager.GetButtonRectangle(_buttonSpecMax).Contains(pt);
	}

	public bool HitTestCloseButton(Point pt)
	{
		return _buttonManager.GetButtonRectangle(_buttonSpecClose).Contains(pt);
	}

	public Image GetImage(PaletteState state)
	{
		Icon definedIcon = GetDefinedIcon();
		if (definedIcon != _cacheIcon)
		{
			if (_cacheBitmap != null)
			{
				_cacheBitmap.Dispose();
				_cacheBitmap = null;
			}
			_cacheIcon = null;
		}
		if (definedIcon != null && _cacheBitmap == null)
		{
			_cacheIcon = definedIcon;
			try
			{
				using Icon icon = new Icon(_cacheIcon, new Size(16, 16));
				_cacheBitmap = icon.ToBitmap();
			}
			catch
			{
				try
				{
					_cacheBitmap = _cacheIcon.ToBitmap();
				}
				catch
				{
				}
			}
			if (_cacheBitmap != null && _cacheBitmap.Size != CAPTION_ICON_SIZE)
			{
				Bitmap cacheBitmap = new Bitmap(_cacheBitmap, CAPTION_ICON_SIZE);
				_cacheBitmap.Dispose();
				_cacheBitmap = cacheBitmap;
			}
		}
		return _cacheBitmap;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		return Text;
	}

	public string GetLongText()
	{
		return _textExtra;
	}

	protected override void OnControlAdded(ControlEventArgs e)
	{
		if (e.Control is StatusStrip)
		{
			MonitorStatusStrip(e.Control as StatusStrip);
			RecalcNonClient();
		}
		base.OnControlAdded(e);
	}

	protected override void OnControlRemoved(ControlEventArgs e)
	{
		if (_statusStrip == e.Control)
		{
			UnmonitorStatusStrip();
			RecalcNonClient();
		}
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		UpdateCustomChromeDecision();
	}

	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		PerformNeedPaint(needLayout: true);
	}

	protected override void OnButtonSpecChanged(object sender, EventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		_buttonManager.RecreateButtons();
	}

	protected override void OnWindowActiveChanged()
	{
		if (base.WindowActive)
		{
			_drawDocker.SetPalettes(_stateActive.Back, _stateActive.Border);
			_drawHeading.SetPalettes(_stateActive.Header.Back, _stateActive.Header.Border);
			_drawContent.SetPalette(_stateActive.Header.Content);
		}
		else
		{
			_drawDocker.SetPalettes(_stateInactive.Back, _stateInactive.Border);
			_drawHeading.SetPalettes(_stateInactive.Header.Back, _stateInactive.Header.Border);
			_drawContent.SetPalette(_stateInactive.Header.Content);
		}
		_drawDocker.Enabled = base.WindowActive;
		_drawHeading.Enabled = base.WindowActive;
		_drawContent.Enabled = base.WindowActive;
		if (base.ApplyCustomChrome)
		{
			PerformNeedPaint(needLayout: false);
		}
		base.OnWindowActiveChanged();
	}

	protected override void OnPaletteChanged(EventArgs e)
	{
		base.OnPaletteChanged(e);
		UpdateCustomChromeDecision();
	}

	protected override void OnAllowFormChromeChanged(object sender, EventArgs e)
	{
		UpdateCustomChromeDecision();
	}

	protected override void WindowChromeStart()
	{
		if (_recreateButtons)
		{
			_buttonManager.RecreateButtons();
			_recreateButtons = false;
		}
		PerformNeedPaint(needLayout: true);
		base.WindowChromeStart();
	}

	protected override void WindowChromeEnd()
	{
		UpdateBorderRegion(null);
		base.WindowChromeEnd();
	}

	protected override IntPtr WindowChromeHitTest(Point pt, bool composition)
	{
		Point pt2 = pt;
		_ = CustomCaptionArea;
		if (CustomCaptionArea.Contains(pt))
		{
			return (IntPtr)2;
		}
		if (!composition && (_buttonManager.GetButtonRectangle(_buttonSpecMin).Contains(pt) || _buttonManager.GetButtonRectangle(_buttonSpecMax).Contains(pt) || _buttonManager.GetButtonRectangle(_buttonSpecClose).Contains(pt)))
		{
			ViewBase viewBase = base.ViewManager.Root.ViewFromPoint(pt);
			IMouseController mouseController = viewBase.FindMouseController();
			if (mouseController is ButtonController buttonController)
			{
				buttonController.NonClientAsNormal = true;
			}
		}
		if (InertForm)
		{
			return (IntPtr)1;
		}
		using (ViewLayoutContext context = new ViewLayoutContext(this, base.Renderer))
		{
			if (_drawContent.IsImageDisplayed(context) && _drawContent.ImageRectangle(context).Contains(pt))
			{
				return (IntPtr)5;
			}
		}
		FormBorderStyle formBorderStyle = base.FormBorderStyle;
		FormBorderStyle formBorderStyle2 = formBorderStyle;
		Padding padding = (((uint)formBorderStyle2 > 3u && formBorderStyle2 != FormBorderStyle.FixedToolWindow) ? ((base.WindowState != FormWindowState.Maximized) ? base.RealWindowBorders : Padding.Empty) : Padding.Empty);
		if (padding.Top > padding.Left)
		{
			padding.Top = padding.Left;
		}
		for (ViewBase viewBase2 = base.ViewManager.Root.ViewFromPoint(pt); viewBase2 != null; viewBase2 = viewBase2.Parent)
		{
			if (viewBase2 == _drawHeading && pt.X > padding.Left && pt.X < base.Width - padding.Right && pt.Y > padding.Top && pt.Y < base.Height - padding.Bottom)
			{
				return (IntPtr)2;
			}
			if (viewBase2 == _drawDocker)
			{
				if (padding.Left > 0 && pt.X <= padding.Left)
				{
					if (pt.Y <= _htCorner)
					{
						return (IntPtr)13;
					}
					if (pt.Y >= base.Height - _htCorner)
					{
						return (IntPtr)16;
					}
					return (IntPtr)10;
				}
				if (padding.Right > 0 && pt.X >= base.Width - padding.Right)
				{
					if (pt.Y <= _htCorner)
					{
						return (IntPtr)14;
					}
					if (pt.Y >= base.Height - _htCorner)
					{
						return (IntPtr)17;
					}
					return (IntPtr)11;
				}
				if (padding.Bottom > 0 && pt.Y >= base.Height - padding.Bottom)
				{
					if (pt.X <= _htCorner)
					{
						return (IntPtr)16;
					}
					if (pt.X >= base.Width - _htCorner)
					{
						return (IntPtr)17;
					}
					return (IntPtr)15;
				}
				if (padding.Top > 0 && pt.Y <= padding.Top)
				{
					if (pt.X <= _htCorner)
					{
						return (IntPtr)13;
					}
					if (pt.X >= base.Width - _htCorner)
					{
						return (IntPtr)14;
					}
					return (IntPtr)12;
				}
			}
		}
		return base.WindowChromeHitTest(pt2, composition);
	}

	protected override void WindowChromePaint(Graphics g, Rectangle bounds)
	{
		CheckViewLayout();
		PerformViewPaint(g, bounds);
	}

	protected override bool WindowChromeLeftMouseDown(Point pt)
	{
		bool result = base.WindowChromeLeftMouseDown(pt);
		if (base.ViewManager.ActiveView != null && base.ViewManager.MouseCaptured)
		{
			StartCapture(base.ViewManager.ActiveView);
			result = true;
		}
		return result;
	}

	private Icon GetDefinedIcon()
	{
		if (_allowIconDisplay)
		{
			FormBorderStyle formBorderStyle = base.FormBorderStyle;
			FormBorderStyle formBorderStyle2 = formBorderStyle;
			if (((uint)(formBorderStyle2 - 1) <= 1u || formBorderStyle2 == FormBorderStyle.Sizable) && base.ShowIcon && base.ControlBox)
			{
				return base.Icon;
			}
		}
		return null;
	}

	private void SetHeaderStyle(ViewDrawDocker drawDocker, PaletteTripleMetricRedirect palette, HeaderStyle style)
	{
		palette.SetStyles(style);
		switch (style)
		{
		case HeaderStyle.Primary:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetPrimary, PaletteMetricPadding.HeaderButtonPaddingPrimary);
			break;
		case HeaderStyle.Secondary:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetSecondary, PaletteMetricPadding.HeaderButtonPaddingSecondary);
			break;
		case HeaderStyle.DockActive:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetDockActive, PaletteMetricPadding.HeaderButtonPaddingDockActive);
			break;
		case HeaderStyle.DockInactive:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetDockInactive, PaletteMetricPadding.HeaderButtonPaddingDockInactive);
			break;
		case HeaderStyle.Form:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetForm, PaletteMetricPadding.HeaderButtonPaddingForm);
			break;
		case HeaderStyle.Calendar:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetCalendar, PaletteMetricPadding.HeaderButtonPaddingCalendar);
			break;
		case HeaderStyle.Custom1:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetCustom1, PaletteMetricPadding.HeaderButtonPaddingCustom1);
			break;
		case HeaderStyle.Custom2:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetCustom2, PaletteMetricPadding.HeaderButtonPaddingCustom2);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
	}

	private bool CheckViewLayout()
	{
		if (!base.IsDisposed && !base.Disposing && base.ViewManager != null)
		{
			if (base.WindowState == FormWindowState.Maximized)
			{
				_buttonSpecMax.ButtonSpecType = PaletteButtonSpecStyle.FormRestore;
			}
			else
			{
				_buttonSpecMax.ButtonSpecType = PaletteButtonSpecStyle.FormMax;
			}
			if (base.WindowState == FormWindowState.Minimized)
			{
				_buttonSpecMin.ButtonSpecType = PaletteButtonSpecStyle.FormRestore;
				_drawDocker.StatusStrip = null;
			}
			else
			{
				_buttonSpecMin.ButtonSpecType = PaletteButtonSpecStyle.FormMin;
				_drawDocker.StatusStrip = (StatusStripMerging ? _statusStrip : null);
			}
			_buttonManager.RefreshButtons();
			if (_headerStyle != _headerStylePrev)
			{
				SetHeaderStyle(_drawHeading, _stateCommon.Header, _headerStyle);
				_headerStylePrev = _headerStyle;
			}
			Padding realWindowBorders = base.RealWindowBorders;
			_headingFixedSize.FixedSize = new Size(realWindowBorders.Top, realWindowBorders.Top);
			_drawContent.DrawContentOnComposition = false;
			if (_lastWindowState != GetWindowState())
			{
				_lastWindowState = GetWindowState();
				base.NeedLayout = true;
			}
			if (_oldText != GetShortText())
			{
				_oldText = GetShortText();
				base.NeedLayout = true;
			}
			if (!base.NeedLayout)
			{
				bool flag = false;
				ButtonSpecView[] buttonSpecViews = _buttonManager.ButtonSpecViews;
				foreach (ButtonSpecView buttonSpecView in buttonSpecViews)
				{
					PaletteState paletteState = buttonSpecView.ViewButton.State;
					PaletteState paletteState2 = paletteState;
					if (paletteState2 == PaletteState.Tracking || paletteState2 == PaletteState.Pressed)
					{
						flag = true;
					}
				}
				if (_lastNotNormal != flag)
				{
					_lastNotNormal = flag;
					base.NeedLayout = true;
				}
			}
			if (base.NeedLayout || GetDefinedIcon() != _cacheIcon)
			{
				using (ViewLayoutContext context = new ViewLayoutContext(base.ViewManager, this, base.RealWindowRectangle, base.Renderer))
				{
					base.ViewManager.Layout(context);
				}
				base.NeedLayout = false;
				if (GetWindowState() == FormWindowState.Maximized)
				{
					UpdateRegionForMaximized();
				}
				else
				{
					_regionWindowState = base.WindowState;
					using RenderContext context2 = new RenderContext(this, null, base.Bounds, base.Renderer);
					using GraphicsPath graphicsPath = _drawDocker.GetOuterBorderPath(context2);
					if (!_firstCheckView)
					{
						SuspendPaint();
					}
					if (graphicsPath != null)
					{
						UpdateBorderRegion(new Region(graphicsPath));
					}
					else
					{
						UpdateBorderRegion(null);
					}
					if (!_firstCheckView)
					{
						ResumePaint();
					}
				}
				_firstCheckView = false;
				return true;
			}
		}
		return false;
	}

	private void PerformViewPaint(Graphics g, Rectangle rect)
	{
		if (!base.IsDisposed && !base.Disposing && base.ViewManager != null)
		{
			if (GetWindowState() == FormWindowState.Maximized && _regionWindowState != FormWindowState.Maximized)
			{
				UpdateRegionForMaximized();
			}
			_drawDocker.DrawCanvas = true;
			_drawHeading.DrawCanvas = true;
			base.ViewManager.Paint(base.Renderer, new PaintEventArgs(g, rect));
		}
	}

	private void UpdateRegionForMaximized()
	{
		if (base.MdiParent == null)
		{
			Padding realWindowBorders = base.RealWindowBorders;
			Rectangle rect = new Rectangle(realWindowBorders.Left, realWindowBorders.Left, base.Width - realWindowBorders.Horizontal, base.Height - realWindowBorders.Left - realWindowBorders.Bottom);
			SuspendPaint();
			_regionWindowState = FormWindowState.Maximized;
			UpdateBorderRegion(new Region(rect));
			ResumePaint();
		}
		else
		{
			UpdateBorderRegion(null);
		}
	}

	private void UpdateBorderRegion(Region newRegion)
	{
		Region region = base.Region;
		base.Region = newRegion;
		region?.Dispose();
	}

	private void UpdateCustomChromeDecision()
	{
		if (base.IsHandleCreated)
		{
			bool flag = AllowFormChrome && KryptonManager.AllowFormChrome && GetResolvedPalette().GetAllowFormChrome() == InheritBool.True;
			if (base.ApplyCustomChrome != flag)
			{
				_recreateButtons = true;
				_firstCheckView = true;
				base.ApplyCustomChrome = flag;
				PerformNeedPaint(flag);
			}
		}
	}

	private void MonitorStatusStrip(StatusStrip statusStrip)
	{
		if (_statusStrip != null)
		{
			UnmonitorStatusStrip();
		}
		_statusStrip = statusStrip;
		_statusStrip.VisibleChanged += OnStatusVisibleChanged;
		_statusStrip.DockChanged += OnStatusDockChanged;
	}

	private void UnmonitorStatusStrip()
	{
		if (_statusStrip != null)
		{
			_statusStrip.VisibleChanged -= OnStatusVisibleChanged;
			_statusStrip.DockChanged -= OnStatusDockChanged;
			_statusStrip = null;
		}
	}

	private void OnShowToolTip(object sender, ToolTipEventArgs e)
	{
		if (base.IsDisposed)
		{
			return;
		}
		Form form = FindForm();
		if ((form != null && !form.ContainsFocus) || base.DesignMode)
		{
			return;
		}
		IContentValues contentValues = null;
		ButtonSpec buttonSpec = _buttonManager.ButtonSpecFromView(e.Target);
		if (buttonSpec != null && AllowButtonSpecToolTips)
		{
			ButtonSpecToContent buttonSpecToContent = new ButtonSpecToContent(base.Redirector, buttonSpec);
			if (buttonSpecToContent.HasContent)
			{
				contentValues = buttonSpecToContent;
			}
		}
		if (contentValues != null)
		{
			if (_visualPopupToolTip != null)
			{
				_visualPopupToolTip.Dispose();
			}
			_visualPopupToolTip = new VisualPopupToolTip(base.Redirector, contentValues, base.Renderer, PaletteBackStyle.ControlToolTip, PaletteBorderStyle.ControlToolTip, PaletteContentStyle.LabelToolTip);
			_visualPopupToolTip.Disposed += OnVisualPopupToolTipDisposed;
			_visualPopupToolTip.ShowCalculatingSize(e.ScreenPt);
		}
	}

	private void OnCancelToolTip(object sender, EventArgs e)
	{
		if (_visualPopupToolTip != null)
		{
			_visualPopupToolTip.Dispose();
		}
	}

	private void OnVisualPopupToolTipDisposed(object sender, EventArgs e)
	{
		VisualPopupToolTip visualPopupToolTip = (VisualPopupToolTip)sender;
		visualPopupToolTip.Disposed -= OnVisualPopupToolTipDisposed;
		_visualPopupToolTip = null;
	}

	private void OnButtonManagerNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (sender is ButtonSpecView)
		{
			ButtonSpecView buttonSpecView = (ButtonSpecView)sender;
			ButtonSpec buttonSpec = buttonSpecView.ButtonSpec;
			if (buttonSpec == _buttonSpecMin || buttonSpec == _buttonSpecMax || buttonSpec == _buttonSpecClose)
			{
				Rectangle clientRectangle = buttonSpecView.ViewButton.ClientRectangle;
				Padding realWindowBorders = base.RealWindowBorders;
				clientRectangle.X -= realWindowBorders.Left;
				clientRectangle.Y -= realWindowBorders.Top;
				OnNeedPaint(sender, new NeedLayoutEventArgs(needLayout: false, clientRectangle));
				return;
			}
		}
		OnNeedPaint(sender, e);
	}

	private void OnStatusDockChanged(object sender, EventArgs e)
	{
		if (StatusStripMerging)
		{
			PerformNeedPaint(needLayout: false);
		}
	}

	private void OnStatusVisibleChanged(object sender, EventArgs e)
	{
		if (StatusStripMerging)
		{
			PerformNeedPaint(needLayout: false);
		}
	}

	private void OnGlobalAllowFormChromeChanged(object sender, EventArgs e)
	{
		UpdateCustomChromeDecision();
	}

	private void OnGlobalPaletteChanged(object sender, EventArgs e)
	{
		if (base.PaletteMode == PaletteMode.Global)
		{
			UpdateCustomChromeDecision();
		}
	}
}
