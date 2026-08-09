#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.Win32;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public abstract class VisualForm : Form, IKryptonDebug
{
	private static readonly int DEFAULT_COMPOSITION_HEIGHT;

	private static bool _themedApp;

	private bool _activated;

	private bool _windowActive;

	private bool _trackingMouse;

	private bool _applyCustomChrome;

	private bool _allowComposition;

	private bool _applyComposition;

	private bool _insideUpdateComposition;

	private bool _needLayout;

	private bool _captured;

	private bool _disposing;

	private int _compositionHeight;

	private int _ignoreCount;

	private int _paintCount;

	private ViewBase _capturedElement;

	private IKryptonComposition _compositionElement;

	private IPalette _localPalette;

	private IPalette _palette;

	private IRenderer _renderer;

	private PaletteMode _paletteMode;

	private PaletteRedirect _redirector;

	private NeedPaintHandler _needPaintDelegate;

	private ViewManager _viewManager;

	private IntPtr _screenDC;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ApplyCustomChrome
	{
		[DebuggerStepThrough]
		get
		{
			return _applyCustomChrome;
		}
		internal set
		{
			if (_applyCustomChrome == value)
			{
				return;
			}
			bool applyCustomChrome = _applyCustomChrome;
			_applyCustomChrome = value;
			if (_applyCustomChrome)
			{
				try
				{
					_applyCustomChrome = false;
					if (PI.IsAppThemed() && PI.IsThemeActive())
					{
						_applyCustomChrome = true;
						UpdateComposition();
						if (!ApplyComposition)
						{
							PI.SetWindowTheme(base.Handle, "", "");
						}
						else
						{
							PI.SetWindowTheme(base.Handle, null, null);
						}
						WindowChromeStart();
					}
				}
				catch
				{
					_applyCustomChrome = false;
				}
			}
			else
			{
				try
				{
					UpdateComposition();
					PI.SetWindowTheme(base.Handle, null, null);
					WindowChromeEnd();
				}
				catch
				{
				}
			}
			if (_applyCustomChrome != applyCustomChrome)
			{
				OnApplyCustomChromeChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ApplyComposition => _applyComposition;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool AllowComposition
	{
		get
		{
			return _allowComposition;
		}
		set
		{
			if (_allowComposition != value)
			{
				_allowComposition = value;
				if (ApplyCustomChrome)
				{
					UpdateComposition();
				}
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IKryptonComposition Composition
	{
		get
		{
			return _compositionElement;
		}
		set
		{
			_compositionElement = value;
		}
	}

	[Category("Visuals")]
	[Description("Palette applied to drawing.")]
	public PaletteMode PaletteMode
	{
		[DebuggerStepThrough]
		get
		{
			return _paletteMode;
		}
		set
		{
			if (_paletteMode != value)
			{
				if (value != PaletteMode.Custom)
				{
					_paletteMode = value;
					_localPalette = null;
					SetPalette(KryptonManager.GetPaletteForMode(_paletteMode));
					OnPaletteChanged(EventArgs.Empty);
					PerformLayout();
				}
			}
		}
	}

	[Category("Visuals")]
	[Description("Custom palette applied to drawing.")]
	[DefaultValue(null)]
	public IPalette Palette
	{
		[DebuggerStepThrough]
		get
		{
			return _localPalette;
		}
		set
		{
			if (_localPalette != value)
			{
				IPalette localPalette = _localPalette;
				SetPalette(value);
				if (value == null)
				{
					_paletteMode = PaletteMode.Global;
					_localPalette = null;
					SetPalette(KryptonManager.GetPaletteForMode(_paletteMode));
				}
				else
				{
					_localPalette = value;
					_paletteMode = PaletteMode.Custom;
				}
				if (localPalette != _localPalette)
				{
					OnPaletteChanged(EventArgs.Empty);
					PerformLayout();
				}
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IRenderer Renderer
	{
		[DebuggerStepThrough]
		get
		{
			return _renderer;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Padding RealWindowBorders => CommonHelper.GetWindowBorders(CreateParams);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int PaintCount => _paintCount;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool WindowActive
	{
		get
		{
			return _windowActive;
		}
		set
		{
			if (_windowActive != value)
			{
				_windowActive = value;
				OnWindowActiveChanged();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int KryptonLayoutCounter => ViewManager.LayoutCounter;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int KryptonPaintCounter => ViewManager.PaintCounter;

	protected ViewManager ViewManager
	{
		[DebuggerStepThrough]
		get
		{
			return _viewManager;
		}
		set
		{
			_viewManager = value;
		}
	}

	protected PaletteRedirect Redirector
	{
		[DebuggerStepThrough]
		get
		{
			return _redirector;
		}
	}

	protected NeedPaintHandler NeedPaintDelegate
	{
		[DebuggerStepThrough]
		get
		{
			return _needPaintDelegate;
		}
	}

	protected Rectangle RealWindowRectangle
	{
		get
		{
			PI.RECT rect = default(PI.RECT);
			PI.GetWindowRect(base.Handle, ref rect);
			return new Rectangle(0, 0, rect.right - rect.left, rect.bottom - rect.top);
		}
	}

	protected bool NeedLayout
	{
		get
		{
			return _needLayout;
		}
		set
		{
			_needLayout = value;
		}
	}

	[Category("Property Changed")]
	[Description("Occurs when the value of the Palette property is changed.")]
	public event EventHandler PaletteChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event EventHandler ApplyCustomChromeChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event EventHandler WindowActiveChanged;

	static VisualForm()
	{
		DEFAULT_COMPOSITION_HEIGHT = 30;
		try
		{
			_themedApp = VisualStyleInformation.IsEnabledByUser && !string.IsNullOrEmpty(VisualStyleInformation.ColorScheme);
		}
		catch
		{
		}
	}

	public VisualForm()
	{
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		_screenDC = PI.CreateCompatibleDC(IntPtr.Zero);
		_needPaintDelegate = OnNeedPaint;
		_localPalette = null;
		SetPalette(KryptonManager.CurrentGlobalPalette);
		_paletteMode = PaletteMode.Global;
		_needLayout = true;
		_compositionHeight = DEFAULT_COMPOSITION_HEIGHT;
		_redirector = CreateRedirector();
		KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;
		SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
	}

	protected override void Dispose(bool disposing)
	{
		_disposing = true;
		if (disposing)
		{
			if (_palette != null)
			{
				_palette.PalettePaint -= OnNeedPaint;
				_palette.ButtonSpecChanged -= OnButtonSpecChanged;
				_palette.AllowFormChromeChanged -= OnAllowFormChromeChanged;
				_palette.BasePaletteChanged -= OnBaseChanged;
				_palette.BaseRendererChanged -= OnBaseChanged;
			}
			KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged;
			SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
		}
		base.Dispose(disposing);
		if (ViewManager != null)
		{
			ViewManager.Dispose();
		}
		if (_screenDC != IntPtr.Zero)
		{
			PI.DeleteDC(_screenDC);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RecalculateComposition()
	{
		UpdateComposition();
	}

	private bool ShouldSerializePaletteMode()
	{
		return PaletteMode != PaletteMode.Global;
	}

	public void ResetPaletteMode()
	{
		PaletteMode = PaletteMode.Global;
	}

	public void ResetPalette()
	{
		PaletteMode = PaletteMode.Global;
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public void PerformNeedPaint(bool needLayout)
	{
		OnNeedPaint(this, new NeedLayoutEventArgs(needLayout));
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public IPalette GetResolvedPalette()
	{
		return _palette;
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public ToolStripRenderer CreateToolStripRenderer()
	{
		return Renderer.RenderToolStrip(GetResolvedPalette());
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void SendSysCommand(int sysCommand)
	{
		SendSysCommand(sysCommand, IntPtr.Zero);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void SendSysCommand(int sysCommand, IntPtr lParam)
	{
		PI.SendMessage(base.Handle, 274, (IntPtr)sysCommand, lParam);
	}

	public void RedrawNonClient()
	{
		InvalidateNonClient(Rectangle.Empty, excludeClientArea: true);
	}

	public void RecalcNonClient()
	{
		if (!base.IsDisposed && !base.Disposing && base.IsHandleCreated)
		{
			PI.SetWindowPos(base.Handle, IntPtr.Zero, 0, 0, 0, 0, 567u);
		}
	}

	public virtual void WindowChromeCompositionLayout(ViewLayoutContext context, Rectangle compRect)
	{
	}

	public virtual void WindowChromeCompositionPaint(RenderContext context)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void KryptonResetCounters()
	{
		ViewManager.ResetCounters();
	}

	protected Point ScreenToWindow(Point screenPt)
	{
		Point result = PointToClient(screenPt);
		Padding realWindowBorders = RealWindowBorders;
		result.Offset(realWindowBorders.Left, (!ApplyComposition) ? realWindowBorders.Top : 0);
		return result;
	}

	public void InvalidateNonClient()
	{
		InvalidateNonClient(Rectangle.Empty, excludeClientArea: true);
	}

	protected void InvalidateNonClient(Rectangle invalidRect)
	{
		InvalidateNonClient(invalidRect, excludeClientArea: true);
	}

	protected void InvalidateNonClient(Rectangle invalidRect, bool excludeClientArea)
	{
		if (base.IsDisposed || base.Disposing || !base.IsHandleCreated)
		{
			return;
		}
		if (invalidRect.IsEmpty)
		{
			Padding realWindowBorders = RealWindowBorders;
			Rectangle realWindowRectangle = RealWindowRectangle;
			invalidRect = new Rectangle(-realWindowBorders.Left, -realWindowBorders.Top, realWindowRectangle.Width, realWindowRectangle.Height);
		}
		using Region region = new Region(invalidRect);
		if (excludeClientArea)
		{
			region.Exclude(base.ClientRectangle);
		}
		using Graphics g = Graphics.FromHwnd(base.Handle);
		IntPtr hrgn = region.GetHrgn(g);
		PI.RedrawWindow(base.Handle, IntPtr.Zero, hrgn, 1281u);
		PI.DeleteObject(hrgn);
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		try
		{
			PI.DisableProcessWindowsGhosting();
		}
		catch
		{
		}
		base.OnHandleCreated(e);
	}

	protected void StartCapture(ViewBase element)
	{
		base.Capture = true;
		_captured = true;
		_capturedElement = element;
	}

	protected override void OnResize(EventArgs e)
	{
		ResumePaint();
		base.OnResize(e);
		if (ApplyCustomChrome && (base.MdiParent == null || !CommonHelper.IsFormMaximized(this)))
		{
			PerformNeedPaint(needLayout: true);
		}
		SuspendPaint();
	}

	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
		int num = height;
		if (ApplyComposition && base.FormBorderStyle != FormBorderStyle.None)
		{
			num = height - RealWindowBorders.Top;
		}
		base.SetBoundsCore(x, y, width, num, specified);
	}

	protected override void OnActivated(EventArgs e)
	{
		WindowActive = true;
		base.OnActivated(e);
	}

	protected override void OnDeactivate(EventArgs e)
	{
		WindowActive = false;
		base.OnDeactivate(e);
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
		if (ApplyCustomChrome && ApplyComposition)
		{
			Rectangle rect = new Rectangle(0, 0, base.Width, _compositionHeight);
			e.Graphics.FillRectangle(Brushes.Black, rect);
			e.Graphics.SetClip(rect, CombineMode.Exclude);
		}
		base.OnPaintBackground(e);
	}

	protected override void OnShown(EventArgs e)
	{
		if (Environment.OSVersion.Version.Major >= 6)
		{
			PerformNeedPaint(needLayout: true);
		}
		base.OnShown(e);
	}

	protected virtual void SuspendPaint()
	{
		_ignoreCount++;
	}

	protected virtual void ResumePaint()
	{
		_ignoreCount--;
	}

	protected virtual PaletteRedirect CreateRedirector()
	{
		return new PaletteRedirect(_palette);
	}

	protected virtual void OnButtonSpecChanged(object sender, EventArgs e)
	{
	}

	protected virtual void OnPaletteChanged(EventArgs e)
	{
		Redirector.Target = _palette;
		OnNeedPaint(Palette, new NeedLayoutEventArgs(needLayout: true));
		if (this.PaletteChanged != null)
		{
			this.PaletteChanged(this, e);
		}
	}

	protected virtual void OnApplyCustomChromeChanged(EventArgs e)
	{
		if (this.ApplyCustomChromeChanged != null)
		{
			this.ApplyCustomChromeChanged(this, e);
		}
	}

	protected virtual void OnAllowFormChromeChanged(object sender, EventArgs e)
	{
	}

	protected virtual void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (!ApplyCustomChrome)
		{
			return;
		}
		if (ApplyComposition)
		{
			_compositionElement.CompNeedPaint(e.NeedLayout);
			return;
		}
		if (e.NeedLayout)
		{
			_needLayout = true;
		}
		InvalidateNonClient();
	}

	protected override void WndProc(ref Message m)
	{
		bool flag = false;
		if (m.Msg == 131 && _themedApp && (base.MdiParent == null || ApplyCustomChrome))
		{
			flag = OnWM_NCCALCSIZE(ref m);
		}
		if (ApplyCustomChrome && !base.IsDisposed && !base.Disposing)
		{
			switch (m.Msg)
			{
			case 133:
				if (!ApplyComposition)
				{
					flag = _ignoreCount > 0 || OnWM_NCPAINT(ref m);
				}
				break;
			case 132:
				flag = ((!ApplyComposition) ? OnWM_NCHITTEST(ref m) : OnCompWM_NCHITTEST(ref m));
				break;
			case 134:
				flag = OnWM_NCACTIVATE(ref m);
				break;
			case 160:
				flag = OnWM_NCMOUSEMOVE(ref m);
				break;
			case 161:
				flag = OnWM_NCLBUTTONDOWN(ref m);
				break;
			case 162:
				flag = OnWM_NCLBUTTONUP(ref m);
				break;
			case 512:
				if (_captured)
				{
					flag = OnWM_MOUSEMOVE(ref m);
				}
				break;
			case 514:
				if (_captured)
				{
					flag = OnWM_LBUTTONUP(ref m);
				}
				break;
			case 674:
				if (!_captured)
				{
					flag = OnWM_NCMOUSELEAVE(ref m);
				}
				if (ApplyComposition)
				{
					_compositionElement.CompNeedPaint(needLayout: true);
				}
				break;
			case 163:
				flag = OnWM_NCLBUTTONDBLCLK(ref m);
				break;
			case 274:
				if ((int)m.WParam.ToInt64() == 61536)
				{
					PropertyInfo property = typeof(Form).GetProperty("CloseReason", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
					property.SetValue(this, CloseReason.UserClosing, null);
				}
				if ((int)m.WParam.ToInt64() != 61696)
				{
					flag = OnPaintNonClient(ref m);
				}
				break;
			case 12:
			case 83:
			case 278:
				flag = OnPaintNonClient(ref m);
				break;
			case 174:
				flag = true;
				break;
			case 49596:
				PerformNeedPaint(needLayout: true);
				break;
			}
		}
		if (!flag)
		{
			base.WndProc(ref m);
		}
	}

	protected virtual bool OnWM_NCCALCSIZE(ref Message m)
	{
		if (m.WParam != IntPtr.Zero)
		{
			Padding padding = ((base.FormBorderStyle != FormBorderStyle.None) ? RealWindowBorders : Padding.Empty);
			PI.NCCALCSIZE_PARAMS nCCALCSIZE_PARAMS = (PI.NCCALCSIZE_PARAMS)m.GetLParam(typeof(PI.NCCALCSIZE_PARAMS));
			if (ApplyComposition)
			{
				padding.Top = 0;
			}
			nCCALCSIZE_PARAMS.rectProposed.left += padding.Left;
			nCCALCSIZE_PARAMS.rectProposed.top += padding.Top;
			nCCALCSIZE_PARAMS.rectProposed.right -= padding.Right;
			nCCALCSIZE_PARAMS.rectProposed.bottom -= padding.Bottom;
			Marshal.StructureToPtr((object)nCCALCSIZE_PARAMS, m.LParam, false);
		}
		return true;
	}

	protected virtual bool OnWM_NCPAINT(ref Message m)
	{
		if (!_disposing)
		{
			OnNonClientPaint(m.HWnd);
		}
		m.Result = (IntPtr)1;
		return true;
	}

	protected virtual bool OnWM_NCHITTEST(ref Message m)
	{
		Point screenPt = new Point((int)m.LParam.ToInt64());
		Point pt = ScreenToWindow(screenPt);
		m.Result = WindowChromeHitTest(pt, composition: false);
		return true;
	}

	protected virtual bool OnCompWM_NCHITTEST(ref Message m)
	{
		PI.DwmDefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam, out var result);
		m.Result = result;
		if (m.Result == (IntPtr)0)
		{
			DefWndProc(ref m);
		}
		if (m.Result == (IntPtr)2 || m.Result == (IntPtr)1)
		{
			Point screenPt = new Point((int)m.LParam.ToInt64());
			Point pt = ScreenToWindow(screenPt);
			m.Result = WindowChromeHitTest(pt, composition: true);
		}
		return true;
	}

	protected virtual bool OnWM_NCACTIVATE(ref Message m)
	{
		WindowActive = m.WParam == (IntPtr)1;
		if (!ApplyComposition)
		{
			if (base.MdiParent == null || _activated)
			{
				m.Result = (IntPtr)1;
				return true;
			}
			_activated = true;
		}
		return false;
	}

	protected virtual bool OnPaintNonClient(ref Message m)
	{
		DefWndProc(ref m);
		InvalidateNonClient();
		return true;
	}

	protected virtual bool OnWM_NCMOUSEMOVE(ref Message m)
	{
		Point screenPt = new Point((int)m.LParam.ToInt64());
		Point pt = ScreenToWindow(screenPt);
		if (ApplyComposition)
		{
			pt.X -= RealWindowBorders.Left;
		}
		WindowChromeNonClientMouseMove(pt);
		if (!_trackingMouse)
		{
			PI.TRACKMOUSEEVENTS tme = new PI.TRACKMOUSEEVENTS
			{
				cbSize = (uint)Marshal.SizeOf(typeof(PI.TRACKMOUSEEVENTS)),
				dwHoverTime = 100u,
				dwFlags = 18u,
				hWnd = base.Handle
			};
			PI.TrackMouseEvent(ref tme);
			_trackingMouse = true;
		}
		m.Result = IntPtr.Zero;
		return true;
	}

	protected virtual bool OnWM_NCLBUTTONDOWN(ref Message m)
	{
		Point screenPt = new Point((int)m.LParam.ToInt64());
		Point pt = ScreenToWindow(screenPt);
		if (ApplyComposition)
		{
			pt.X -= RealWindowBorders.Left;
		}
		return WindowChromeLeftMouseDown(pt);
	}

	protected virtual bool OnWM_NCLBUTTONUP(ref Message m)
	{
		Point screenPt = new Point((int)m.LParam.ToInt64());
		Point pt = ScreenToWindow(screenPt);
		if (ApplyComposition)
		{
			pt.X -= RealWindowBorders.Left;
		}
		return WindowChromeLeftMouseUp(pt);
	}

	protected virtual bool OnWM_NCMOUSELEAVE(ref Message m)
	{
		_trackingMouse = false;
		WindowChromeMouseLeave();
		m.Result = IntPtr.Zero;
		InvalidateNonClient();
		return true;
	}

	protected virtual bool OnWM_MOUSEMOVE(ref Message m)
	{
		Point p = new Point((int)m.LParam);
		Point screenPt = PointToScreen(p);
		Point pt = ScreenToWindow(screenPt);
		WindowChromeNonClientMouseMove(pt);
		return true;
	}

	protected virtual bool OnWM_LBUTTONUP(ref Message m)
	{
		_captured = false;
		base.Capture = false;
		_capturedElement = null;
		_trackingMouse = false;
		Point p = new Point((int)m.LParam);
		Point screenPt = PointToScreen(p);
		Point rawPt = ScreenToWindow(screenPt);
		ViewManager.MouseUp(new MouseEventArgs(MouseButtons.Left, 0, rawPt.X, rawPt.Y, 0), rawPt);
		ViewManager.MouseLeave(EventArgs.Empty);
		InvalidateNonClient();
		return true;
	}

	protected virtual bool OnWM_NCLBUTTONDBLCLK(ref Message m)
	{
		Point screenPt = new Point((int)m.LParam.ToInt64());
		Point pt = ScreenToWindow(screenPt);
		ViewBase viewBase = ViewManager.Root.ViewFromPoint(pt);
		if (viewBase != null)
		{
			IMouseController mouseController = viewBase.FindMouseController();
			if (mouseController != null)
			{
				return true;
			}
		}
		return false;
	}

	protected virtual void OnNonClientPaint(IntPtr hWnd)
	{
		Rectangle realWindowRectangle = RealWindowRectangle;
		if (realWindowRectangle.Width > 0 && realWindowRectangle.Height > 0)
		{
			IntPtr windowDC = PI.GetWindowDC(base.Handle);
			if (windowDC != IntPtr.Zero)
			{
				try
				{
					Padding realWindowBorders = RealWindowBorders;
					Rectangle rectangle = new Rectangle(realWindowBorders.Left, realWindowBorders.Top, realWindowRectangle.Width - realWindowBorders.Horizontal, realWindowRectangle.Height - realWindowBorders.Vertical);
					bool flag = CommonHelper.IsFormMinimized(this);
					if (flag || (rectangle.Width > 0 && rectangle.Height > 0))
					{
						if (!flag)
						{
							PI.ExcludeClipRect(windowDC, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
						}
						IntPtr intPtr = PI.CreateCompatibleBitmap(windowDC, realWindowRectangle.Width, realWindowRectangle.Height);
						if (intPtr != IntPtr.Zero)
						{
							try
							{
								PI.SelectObject(_screenDC, intPtr);
								using (Graphics g = Graphics.FromHdc(_screenDC))
								{
									WindowChromePaint(g, realWindowRectangle);
								}
								PI.BitBlt(windowDC, 0, 0, realWindowRectangle.Width, realWindowRectangle.Height, _screenDC, 0, 0, 13369376);
							}
							finally
							{
								PI.DeleteObject(intPtr);
							}
						}
						else
						{
							using Graphics g2 = Graphics.FromHdc(windowDC);
							WindowChromePaint(g2, realWindowRectangle);
						}
					}
				}
				finally
				{
					PI.ReleaseDC(base.Handle, windowDC);
				}
			}
		}
		_paintCount++;
	}

	protected virtual void OnWindowActiveChanged()
	{
		if (this.WindowActiveChanged != null)
		{
			this.WindowActiveChanged(this, EventArgs.Empty);
		}
	}

	protected virtual void WindowChromeStart()
	{
	}

	protected virtual void WindowChromeEnd()
	{
	}

	protected virtual IntPtr WindowChromeHitTest(Point pt, bool composition)
	{
		return (IntPtr)1;
	}

	protected virtual void WindowChromePaint(Graphics g, Rectangle bounds)
	{
	}

	protected virtual void WindowChromeNonClientMouseMove(Point pt)
	{
		ViewManager.MouseMove(new MouseEventArgs(MouseButtons.None, 0, pt.X, pt.Y, 0), pt);
	}

	protected virtual bool WindowChromeLeftMouseDown(Point pt)
	{
		ViewManager.MouseDown(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0), pt);
		if (ViewManager.ActiveView != null)
		{
			IMouseController mouseController = ViewManager.ActiveView.FindMouseController();
			if (mouseController != null)
			{
				return mouseController.IgnoreVisualFormLeftButtonDown;
			}
		}
		return false;
	}

	protected virtual bool WindowChromeLeftMouseUp(Point pt)
	{
		ViewManager.MouseUp(new MouseEventArgs(MouseButtons.Left, 0, pt.X, pt.Y, 0), pt);
		return false;
	}

	protected virtual void WindowChromeMouseLeave()
	{
		ViewManager.MouseLeave(EventArgs.Empty);
	}

	private void UpdateComposition()
	{
		if (_insideUpdateComposition)
		{
			return;
		}
		_insideUpdateComposition = true;
		bool flag = !base.DesignMode && base.TopLevel && ApplyCustomChrome && AllowComposition && DWM.IsCompositionEnabled;
		if (ApplyComposition != flag)
		{
			_applyComposition = flag;
			if (Composition != null)
			{
				Composition.CompVisible = _applyComposition;
				Composition.CompOwnerForm = this;
				_compositionHeight = Composition.CompHeight;
			}
			else
			{
				_compositionHeight = DEFAULT_COMPOSITION_HEIGHT;
			}
			DWM.ExtendFrameIntoClientArea(base.Handle, new Padding(0, _applyComposition ? _compositionHeight : 0, 0, 0));
			if (ApplyCustomChrome)
			{
				ApplyCustomChrome = false;
				ApplyCustomChrome = true;
			}
		}
		else if (ApplyComposition)
		{
			int num = DEFAULT_COMPOSITION_HEIGHT;
			if (Composition != null)
			{
				num = Composition.CompHeight;
			}
			if (num != _compositionHeight)
			{
				_compositionHeight = num;
				DWM.ExtendFrameIntoClientArea(base.Handle, new Padding(0, _applyComposition ? _compositionHeight : 0, 0, 0));
			}
		}
		_insideUpdateComposition = false;
	}

	private void OnGlobalPaletteChanged(object sender, EventArgs e)
	{
		if (PaletteMode == PaletteMode.Global)
		{
			_localPalette = null;
			SetPalette(KryptonManager.CurrentGlobalPalette);
			Redirector.Target = _palette;
			OnNeedPaint(Palette, new NeedLayoutEventArgs(needLayout: true));
		}
	}

	private void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
	{
		switch (e.Category)
		{
		case UserPreferenceCategory.Color:
		case UserPreferenceCategory.Desktop:
		case UserPreferenceCategory.General:
		case UserPreferenceCategory.Icon:
		case UserPreferenceCategory.Menu:
		case UserPreferenceCategory.Window:
		case UserPreferenceCategory.VisualStyle:
			UpdateComposition();
			PerformNeedPaint(needLayout: true);
			break;
		case UserPreferenceCategory.Keyboard:
		case UserPreferenceCategory.Mouse:
		case UserPreferenceCategory.Policy:
		case UserPreferenceCategory.Power:
		case UserPreferenceCategory.Screensaver:
		case UserPreferenceCategory.Locale:
			break;
		}
	}

	private void SetPalette(IPalette palette)
	{
		if (palette != _palette)
		{
			if (_palette != null)
			{
				_palette.PalettePaint -= OnNeedPaint;
				_palette.ButtonSpecChanged -= OnButtonSpecChanged;
				_palette.AllowFormChromeChanged -= OnAllowFormChromeChanged;
				_palette.BasePaletteChanged -= OnBaseChanged;
				_palette.BaseRendererChanged -= OnBaseChanged;
			}
			_palette = palette;
			_renderer = _palette.GetRenderer();
			if (_palette != null)
			{
				_palette.PalettePaint += OnNeedPaint;
				_palette.ButtonSpecChanged += OnButtonSpecChanged;
				_palette.AllowFormChromeChanged += OnAllowFormChromeChanged;
				_palette.BasePaletteChanged += OnBaseChanged;
				_palette.BaseRendererChanged += OnBaseChanged;
			}
		}
	}

	private void OnBaseChanged(object sender, EventArgs e)
	{
		_renderer = _palette.GetRenderer();
	}
}
