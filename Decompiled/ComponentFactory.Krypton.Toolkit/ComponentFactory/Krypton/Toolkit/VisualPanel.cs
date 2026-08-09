#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[DesignerCategory("code")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public abstract class VisualPanel : Panel, ISupportInitializeNotification, ISupportInitialize, IKryptonDebug
{
	private static MethodInfo _miPTB;

	private bool _initializing;

	private bool _initialized;

	private bool _refresh;

	private bool _refreshAll;

	private bool _layoutDirty;

	private bool _paintTransparent;

	private bool _evalTransparent;

	private bool _globalEvents;

	private Size _lastLayoutSize;

	private IPalette _localPalette;

	private IPalette _palette;

	private IRenderer _renderer;

	private PaletteRedirect _redirector;

	private PaletteMode _paletteMode;

	private ViewManager _viewManager;

	private SimpleCall _refreshCall;

	private NeedPaintHandler _needPaintDelegate;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool IsInitialized
	{
		[DebuggerStepThrough]
		get
		{
			return _initialized;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool IsInitializing
	{
		[DebuggerStepThrough]
		get
		{
			return _initializing;
		}
	}

	public override ContextMenuStrip ContextMenuStrip
	{
		[DebuggerStepThrough]
		get
		{
			return base.ContextMenuStrip;
		}
		set
		{
			if (base.ContextMenuStrip != null)
			{
				base.ContextMenuStrip.Opening -= OnContextMenuStripOpening;
				base.ContextMenuStrip.Closed -= OnContextMenuClosed;
			}
			base.ContextMenuStrip = value;
			if (base.ContextMenuStrip != null)
			{
				base.ContextMenuStrip.Opening += OnContextMenuStripOpening;
				base.ContextMenuStrip.Closed += OnContextMenuClosed;
			}
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
	[Bindable(false)]
	public override Image BackgroundImage
	{
		get
		{
			return base.BackgroundImage;
		}
		set
		{
			base.BackgroundImage = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override ImageLayout BackgroundImageLayout
	{
		get
		{
			return base.BackgroundImageLayout;
		}
		set
		{
			base.BackgroundImageLayout = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new BorderStyle BorderStyle
	{
		get
		{
			return base.BorderStyle;
		}
		set
		{
			base.BorderStyle = value;
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

	protected bool NeedTransparentPaint
	{
		get
		{
			if (_evalTransparent)
			{
				_paintTransparent = EvalTransparentPaint();
				_evalTransparent = false;
			}
			return _paintTransparent;
		}
	}

	protected virtual bool EvalInvokePaint => false;

	protected virtual Control TransparentParent => base.Parent;

	protected override Size DefaultSize => new Size(100, 100);

	[Category("Behavior")]
	[Description("Occurs when the control has been fully initialized.")]
	public event EventHandler Initialized;

	[Category("Property Changed")]
	[Description("Occurs when the value of the Palette property is changed.")]
	public event EventHandler PaletteChanged;

	protected VisualPanel()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		SetStyle(ControlStyles.ContainerControl, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		DoubleBuffered = true;
		_refreshCall = OnPerformRefresh;
		_needPaintDelegate = OnNeedPaint;
		_layoutDirty = true;
		_evalTransparent = true;
		_lastLayoutSize = Size.Empty;
		_localPalette = null;
		SetPalette(KryptonManager.CurrentGlobalPalette);
		_paletteMode = PaletteMode.Global;
		_redirector = new PaletteRedirect(_palette);
		AttachGlobalEvents();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (base.ContextMenuStrip != null)
			{
				base.ContextMenuStrip.Opening -= OnContextMenuStripOpening;
				base.ContextMenuStrip.Closed -= OnContextMenuClosed;
				base.ContextMenuStrip = null;
			}
			if (_palette != null)
			{
				_palette.PalettePaint -= OnNeedPaint;
				_palette.ButtonSpecChanged -= OnButtonSpecChanged;
			}
			UnattachGlobalEvents();
			ViewManager.Dispose();
			_palette = null;
			_renderer = null;
			_localPalette = null;
			Redirector.Target = null;
		}
		base.Dispose(disposing);
	}

	public virtual void BeginInit()
	{
		_initializing = true;
		SuspendLayout();
	}

	public virtual void EndInit()
	{
		_initialized = true;
		_initializing = false;
		OnNeedPaint(this, new NeedLayoutEventArgs(needLayout: true));
		ResumeLayout(performLayout: true);
		OnInitialized(EventArgs.Empty);
	}

	public void PerformNeedPaint(bool needLayout)
	{
		OnNeedPaint(this, new NeedLayoutEventArgs(needLayout));
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
	public ToolStripRenderer CreateToolStripRenderer()
	{
		return Renderer.RenderToolStrip(GetResolvedPalette());
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void AttachGlobalEvents()
	{
		if (!_globalEvents)
		{
			UpdateGlobalEvents(attach: true);
			_globalEvents = true;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void UnattachGlobalEvents()
	{
		if (_globalEvents)
		{
			UpdateGlobalEvents(attach: false);
			_globalEvents = false;
		}
	}

	protected virtual void ContextMenuClosed()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void KryptonResetCounters()
	{
		ViewManager.ResetCounters();
	}

	protected void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		_evalTransparent = true;
		if (e.NeedLayout)
		{
			_layoutDirty = true;
		}
		if (base.IsHandleCreated && (!_refreshAll || !e.InvalidRect.IsEmpty))
		{
			if (e.InvalidRect.IsEmpty)
			{
				_refreshAll = true;
				Invalidate();
			}
			else
			{
				Invalidate(e.InvalidRect);
			}
			if (!_refresh && EvalInvokePaint)
			{
				BeginInvoke(_refreshCall);
			}
			_refresh = true;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public IPalette GetResolvedPalette()
	{
		return _palette;
	}

	protected virtual void OnInitialized(EventArgs e)
	{
		if (this.Initialized != null)
		{
			this.Initialized(this, EventArgs.Empty);
		}
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

	protected virtual bool EvalTransparentPaint()
	{
		if (ViewManager != null)
		{
			return ViewManager.EvalTransparentPaint(_renderer);
		}
		return false;
	}

	protected virtual void OnButtonSpecChanged(object sender, EventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
	}

	protected virtual void UpdateGlobalEvents(bool attach)
	{
		if (attach)
		{
			KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;
			SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
		}
		else
		{
			KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged;
			SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
		}
	}

	protected override void OnRightToLeftChanged(EventArgs e)
	{
		OnNeedPaint(null, new NeedLayoutEventArgs(needLayout: true));
		base.OnRightToLeftChanged(e);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			int num = 5;
			do
			{
				_layoutDirty = false;
				ViewManager.Layout(_renderer);
			}
			while (_layoutDirty && num-- > 0);
			_lastLayoutSize = base.Size;
		}
		base.OnLayout(levent);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			if (_layoutDirty && !base.Size.Equals(_lastLayoutSize))
			{
				PerformLayout();
			}
			PaintTransparentBackground(e);
			ViewManager.Paint(_renderer, e);
			_refresh = false;
			_refreshAll = false;
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			ViewManager.MouseMove(e, new Point(e.X, e.Y));
		}
		base.OnMouseMove(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			ViewManager.MouseDown(e, new Point(e.X, e.Y));
		}
		base.OnMouseDown(e);
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			ViewManager.MouseUp(e, new Point(e.X, e.Y));
		}
		base.OnMouseUp(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			ViewManager.MouseLeave(e);
		}
		base.OnMouseLeave(e);
	}

	protected override void OnDoubleClick(EventArgs e)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			ViewManager.DoubleClick(PointToClient(Control.MousePosition));
		}
		base.OnDoubleClick(e);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			ViewManager.KeyDown(e);
		}
		base.OnKeyDown(e);
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			ViewManager.KeyPress(e);
		}
		base.OnKeyPress(e);
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			ViewManager.KeyUp(e);
		}
		base.OnKeyUp(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			ViewManager.GotFocus();
		}
		base.OnGotFocus(e);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			ViewManager.LostFocus();
		}
		base.OnLostFocus(e);
	}

	private void SetPalette(IPalette palette)
	{
		if (palette != _palette)
		{
			if (_palette != null)
			{
				_palette.PalettePaint -= OnNeedPaint;
				_palette.ButtonSpecChanged -= OnButtonSpecChanged;
			}
			_palette = palette;
			_renderer = _palette.GetRenderer();
			if (_palette != null)
			{
				_palette.PalettePaint += OnNeedPaint;
				_palette.ButtonSpecChanged += OnButtonSpecChanged;
			}
		}
	}

	private void PaintTransparentBackground(PaintEventArgs e)
	{
		Control transparentParent = TransparentParent;
		if (transparentParent != null && NeedTransparentPaint)
		{
			if (_miPTB == null)
			{
				_miPTB = typeof(Control).GetMethod("PaintTransparentBackground", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, CallingConventions.HasThis, new Type[3]
				{
					typeof(PaintEventArgs),
					typeof(Rectangle),
					typeof(Region)
				}, null);
			}
			_miPTB.Invoke(this, new object[3] { e, base.ClientRectangle, null });
		}
		else
		{
			e.Graphics.FillRectangle(SystemBrushes.Control, base.ClientRectangle);
		}
	}

	private void OnPerformRefresh()
	{
		if (_refresh)
		{
			Refresh();
			if (_layoutDirty)
			{
				PerformLayout();
				Refresh();
			}
			_refresh = false;
			_refreshAll = false;
		}
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
		PerformNeedPaint(needLayout: true);
	}

	private void OnContextMenuStripOpening(object sender, CancelEventArgs e)
	{
		ContextMenuStrip contextMenuStrip = base.ContextMenuStrip;
		contextMenuStrip.Renderer = CreateToolStripRenderer();
	}

	private void OnContextMenuClosed(object sender, ToolStripDropDownClosedEventArgs e)
	{
		ContextMenuClosed();
	}
}
