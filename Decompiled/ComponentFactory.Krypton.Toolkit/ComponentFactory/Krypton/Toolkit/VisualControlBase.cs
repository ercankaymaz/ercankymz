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
public abstract class VisualControlBase : Control, IKryptonDebug
{
	private static MethodInfo _miPTB;

	private bool _layoutDirty;

	private bool _refresh;

	private bool _refreshAll;

	private bool _paintTransparent;

	private bool _evalTransparent;

	private bool _globalEvents;

	private int _dirtyPaletteCounter;

	private IPalette _localPalette;

	private IPalette _palette;

	private IRenderer _renderer;

	private PaletteRedirect _redirector;

	private PaletteMode _paletteMode;

	private ViewManager _viewManager;

	private SimpleCall _refreshCall;

	private SimpleCall _layoutCall;

	private NeedPaintHandler _needPaintDelegate;

	private NeedPaintHandler _needPaintPaletteDelegate;

	private KryptonContextMenu _kryptonContextMenu;

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

	[Category("Behavior")]
	[Description("The shortcut menu to show when the user right-clicks the page.")]
	[DefaultValue(null)]
	public virtual KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _kryptonContextMenu;
		}
		set
		{
			if (_kryptonContextMenu != value)
			{
				if (_kryptonContextMenu != null)
				{
					_kryptonContextMenu.Closed -= OnContextMenuClosed;
					_kryptonContextMenu.Disposed -= OnKryptonContextMenuDisposed;
				}
				_kryptonContextMenu = value;
				if (_kryptonContextMenu != null)
				{
					_kryptonContextMenu.Closed += OnContextMenuClosed;
					_kryptonContextMenu.Disposed += OnKryptonContextMenuDisposed;
				}
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
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int DirtyPaletteCounter
	{
		get
		{
			return _dirtyPaletteCounter;
		}
		set
		{
			_dirtyPaletteCounter = value;
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

	protected NeedPaintHandler NeedPaintDelegate => _needPaintDelegate;

	protected NeedPaintHandler NeedPaintPaletteDelegate => _needPaintPaletteDelegate;

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

	[Category("Property Changed")]
	[Description("Occurs when the value of the Palette property is changed.")]
	public event EventHandler PaletteChanged;

	protected VisualControlBase()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		DoubleBuffered = true;
		_refreshCall = OnPerformRefresh;
		_layoutCall = OnPerformLayout;
		_needPaintDelegate = OnNeedPaint;
		_needPaintPaletteDelegate = OnPaletteNeedPaint;
		_layoutDirty = true;
		_evalTransparent = true;
		_dirtyPaletteCounter = 1;
		_localPalette = null;
		SetPalette(KryptonManager.CurrentGlobalPalette);
		_paletteMode = PaletteMode.Global;
		_redirector = CreateRedirector();
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
				_palette.PalettePaint -= OnPaletteNeedPaint;
				_palette.ButtonSpecChanged -= OnButtonSpecChanged;
				_palette.BasePaletteChanged -= OnBaseChanged;
				_palette.BaseRendererChanged -= OnBaseChanged;
			}
			UnattachGlobalEvents();
			if (ViewManager != null)
			{
				ViewManager.Dispose();
			}
			_palette = null;
			_renderer = null;
			_localPalette = null;
			Redirector.Target = null;
		}
		base.Dispose(disposing);
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public virtual void PerformNeedPaint(bool needLayout)
	{
		OnNeedPaint(this, new NeedLayoutEventArgs(needLayout));
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public void CheckPerformLayout()
	{
		if (base.IsDisposed || base.Disposing || !_layoutDirty)
		{
			return;
		}
		PerformLayout();
		if (ViewManager != null)
		{
			int num = 5;
			do
			{
				_layoutDirty = false;
				ViewManager.Layout(_renderer);
			}
			while (_layoutDirty && num-- > 0);
		}
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
	public ViewManager GetViewManager()
	{
		return _viewManager;
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public IPalette GetResolvedPalette()
	{
		return _palette;
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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void KryptonResetCounters()
	{
		ViewManager.ResetCounters();
	}

	public ViewBase ViewFromPoint(Point pt)
	{
		if (ViewManager != null && ViewManager.Root != null)
		{
			return ViewManager.Root.ViewFromPoint(pt);
		}
		return null;
	}

	protected bool ForceViewLayout()
	{
		if (!base.IsDisposed && !base.Disposing && ViewManager != null)
		{
			ViewManager.Layout(_renderer);
			return true;
		}
		return false;
	}

	protected void InvokeLayout()
	{
		BeginInvoke(_layoutCall);
	}

	protected void MarkLayoutDirty()
	{
		_layoutDirty = true;
	}

	protected virtual void PaintBackground(Graphics g, Brush backBrush, Rectangle backRect)
	{
		g.FillRectangle(backBrush, backRect);
	}

	protected bool CanProcessMnemonic()
	{
		for (Control control = this; control != null; control = control.Parent)
		{
			if (!control.Visible || !control.Enabled)
			{
				return false;
			}
		}
		return true;
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

	protected virtual void OnPaletteChanged(EventArgs e)
	{
		Redirector.Target = _palette;
		DirtyPaletteCounter++;
		OnNeedPaint(Palette, new NeedLayoutEventArgs(needLayout: true));
		if (this.PaletteChanged != null)
		{
			this.PaletteChanged(this, e);
		}
	}

	protected virtual void OnPaletteNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		DirtyPaletteCounter++;
		OnNeedPaint(sender, e);
	}

	protected virtual void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (base.IsDisposed || base.Disposing)
		{
			return;
		}
		_evalTransparent = true;
		if (e.NeedLayout && !_layoutDirty)
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

	protected virtual PaletteRedirect CreateRedirector()
	{
		return new PaletteRedirect(_palette);
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
		DirtyPaletteCounter++;
		OnNeedPaint(null, new NeedLayoutEventArgs(needLayout: true));
		base.OnRightToLeftChanged(e);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		if (!base.IsDisposed && !base.Disposing && ViewManager != null)
		{
			int num = 5;
			do
			{
				_layoutDirty = false;
				ViewManager.Layout(_renderer);
			}
			while (_layoutDirty && num-- > 0);
		}
		base.OnLayout(levent);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (base.IsDisposed || base.Disposing || ViewManager == null)
		{
			return;
		}
		if (_layoutDirty)
		{
			Size clientSize = base.ClientSize;
			PerformLayout();
			if (clientSize.Width < base.ClientSize.Width || clientSize.Height < base.ClientSize.Height)
			{
				_refresh = false;
				_refreshAll = false;
				PerformNeedPaint(needLayout: false);
			}
		}
		PaintTransparentBackground(e);
		ViewManager.Paint(_renderer, e);
		_refresh = false;
		_refreshAll = false;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && ViewManager != null)
		{
			ViewManager.MouseMove(e, new Point(e.X, e.Y));
		}
		base.OnMouseMove(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && ViewManager != null)
		{
			ViewManager.MouseDown(e, new Point(e.X, e.Y));
		}
		base.OnMouseDown(e);
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && ViewManager != null)
		{
			ViewManager.MouseUp(e, new Point(e.X, e.Y));
		}
		base.OnMouseUp(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && ViewManager != null)
		{
			ViewManager.MouseLeave(e);
		}
		base.OnMouseLeave(e);
	}

	protected override void OnDoubleClick(EventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && ViewManager != null)
		{
			ViewManager.DoubleClick(PointToClient(Control.MousePosition));
		}
		base.OnDoubleClick(e);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && ViewManager != null)
		{
			ViewManager.KeyDown(e);
		}
		base.OnKeyDown(e);
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && ViewManager != null)
		{
			ViewManager.KeyPress(e);
		}
		base.OnKeyPress(e);
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && ViewManager != null)
		{
			ViewManager.KeyUp(e);
		}
		base.OnKeyUp(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && ViewManager != null)
		{
			ViewManager.GotFocus();
		}
		base.OnGotFocus(e);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && ViewManager != null)
		{
			ViewManager.LostFocus();
		}
		base.OnLostFocus(e);
	}

	protected virtual void OnGlobalPaletteChanged(object sender, EventArgs e)
	{
		if (PaletteMode == PaletteMode.Global)
		{
			_localPalette = null;
			SetPalette(KryptonManager.CurrentGlobalPalette);
			Redirector.Target = _palette;
			DirtyPaletteCounter++;
			OnNeedPaint(Palette, new NeedLayoutEventArgs(needLayout: true));
			OnPaletteChanged(EventArgs.Empty);
		}
	}

	protected virtual void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
	{
		DirtyPaletteCounter++;
		PerformNeedPaint(needLayout: true);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (KryptonContextMenu != null && KryptonContextMenu.ProcessShortcut(keyData))
		{
			return true;
		}
		return base.ProcessCmdKey(ref msg, keyData);
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 123 && KryptonContextMenu != null)
		{
			Point p = new Point(PI.LOWORD(m.LParam), PI.HIWORD(m.LParam));
			if ((int)(long)m.LParam == -1)
			{
				p = new Point(base.Width / 2, base.Height / 2);
			}
			else
			{
				p = PointToClient(p);
				p.X--;
				p.Y--;
			}
			if (base.ClientRectangle.Contains(p))
			{
				KryptonContextMenu.Show(this, PointToScreen(p));
				return;
			}
		}
		base.WndProc(ref m);
	}

	protected virtual void ContextMenuClosed()
	{
	}

	private void SetPalette(IPalette palette)
	{
		if (palette != _palette)
		{
			if (_palette != null)
			{
				_palette.PalettePaint -= OnPaletteNeedPaint;
				_palette.ButtonSpecChanged -= OnButtonSpecChanged;
				_palette.BasePaletteChanged -= OnBaseChanged;
				_palette.BaseRendererChanged -= OnBaseChanged;
			}
			_palette = palette;
			_renderer = _palette.GetRenderer();
			if (_palette != null)
			{
				_palette.PalettePaint += OnPaletteNeedPaint;
				_palette.ButtonSpecChanged += OnButtonSpecChanged;
				_palette.BasePaletteChanged += OnBaseChanged;
				_palette.BaseRendererChanged += OnBaseChanged;
			}
		}
	}

	private void OnBaseChanged(object sender, EventArgs e)
	{
		_renderer = _palette.GetRenderer();
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
			PaintBackground(e.Graphics, SystemBrushes.Control, base.ClientRectangle);
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

	private void OnPerformLayout()
	{
		PerformLayout();
		BeginInvoke(_refreshCall);
	}

	private void OnContextMenuStripOpening(object sender, CancelEventArgs e)
	{
		ContextMenuStrip contextMenuStrip = base.ContextMenuStrip;
		contextMenuStrip.Renderer = CreateToolStripRenderer();
	}

	private void OnKryptonContextMenuDisposed(object sender, EventArgs e)
	{
		KryptonContextMenu = null;
	}

	private void OnContextMenuClosed(object sender, ToolStripDropDownClosedEventArgs e)
	{
		ContextMenuClosed();
	}
}
