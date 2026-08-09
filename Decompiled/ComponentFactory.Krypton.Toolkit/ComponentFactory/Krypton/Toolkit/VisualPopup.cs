#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[DesignerCategory("code")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class VisualPopup : ContainerControl
{
	private bool _layoutDirty;

	private bool _refresh;

	private bool _refreshAll;

	private SimpleCall _refreshCall;

	private ViewManager _viewManager;

	private IRenderer _renderer;

	private NeedPaintHandler _needPaintDelegate;

	private EventHandler _dismissedDelegate;

	private VisualPopupShadow _shadow;

	public virtual bool AllowBecomeActiveWhenCurrent => true;

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
		set
		{
			_renderer = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public EventHandler DismissedDelegate
	{
		get
		{
			return _dismissedDelegate;
		}
		set
		{
			_dismissedDelegate = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public virtual bool KeyboardInert => false;

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

	protected NeedPaintHandler NeedPaintDelegate
	{
		[DebuggerStepThrough]
		get
		{
			return _needPaintDelegate;
		}
	}

	protected virtual bool EvalInvokePaint => false;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.Parent = IntPtr.Zero;
			createParams.Style = int.MinValue;
			createParams.ExStyle = 136;
			return createParams;
		}
	}

	public VisualPopup(bool shadow)
		: this(new ViewManager(), null, shadow)
	{
	}

	public VisualPopup(IRenderer renderer, bool shadow)
		: this(new ViewManager(), renderer, shadow)
	{
	}

	public VisualPopup(ViewManager viewManager, IRenderer renderer, bool shadow)
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		_renderer = renderer;
		_viewManager = viewManager;
		_needPaintDelegate = OnNeedPaint;
		_refreshCall = OnPerformRefresh;
		_layoutDirty = true;
		_refresh = true;
		if (shadow)
		{
			_shadow = new VisualPopupShadow();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _shadow != null)
		{
			_shadow.Dispose();
			_shadow = null;
		}
		base.Dispose(disposing);
		if (ViewManager != null)
		{
			ViewManager.ActiveView = null;
			ViewManager.Dispose();
		}
		if (_dismissedDelegate != null)
		{
			_dismissedDelegate(this, EventArgs.Empty);
			_dismissedDelegate = null;
		}
	}

	public virtual void Show(Rectangle screenRect)
	{
		SetBounds(screenRect.X, screenRect.Y, screenRect.Width, screenRect.Height);
		if (_shadow != null)
		{
			_shadow.Show(screenRect);
		}
		PI.ShowWindow(base.Handle, 4);
		VisualPopupManager.Singleton.StartTracking(this);
	}

	public virtual void Show(Rectangle parentScreenRect, Size popupSize)
	{
		Show(CalculateBelowPopupRect(parentScreenRect, popupSize));
	}

	public virtual void DefineShadowPaths(GraphicsPath path1, GraphicsPath path2, GraphicsPath path3)
	{
		if (_shadow != null)
		{
			_shadow.DefinePaths(path1, path2, path3);
			return;
		}
		path1.Dispose();
		path2.Dispose();
		path3.Dispose();
	}

	public virtual bool DoesCurrentMouseDownEndAllTracking(Message m, Point pt)
	{
		bool flag = !base.ClientRectangle.Contains(pt);
		if (flag && base.ContainsFocus)
		{
			Point point = PointToScreen(pt);
			IntPtr intPtr = PI.WindowFromPoint(new PI.POINT
			{
				x = point.X,
				y = point.Y
			});
			if (intPtr != IntPtr.Zero)
			{
				StringBuilder stringBuilder = new StringBuilder(256);
				int className = PI.GetClassName(intPtr, stringBuilder, stringBuilder.Capacity);
				if (className > 0 && stringBuilder.ToString() == "ComboLBox")
				{
					flag = false;
				}
			}
		}
		return flag;
	}

	public virtual bool DoesCurrentMouseDownContinueTracking(Message m, Point pt)
	{
		return !DoesCurrentMouseDownEndAllTracking(m, pt);
	}

	public virtual bool DoesStackedClientMouseDownBecomeCurrent(Message m, Point pt)
	{
		return base.ClientRectangle.Contains(pt);
	}

	public virtual bool DoesMouseDownGetEaten(Message m, Point pt)
	{
		return false;
	}

	public virtual bool AllowMouseMove(Message m, Point pt)
	{
		if (base.ContainsFocus)
		{
			return true;
		}
		return RectangleToScreen(base.ClientRectangle).Contains(pt);
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public ToolStripRenderer CreateToolStripRenderer()
	{
		return Renderer.RenderToolStrip(GetResolvedPalette());
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual IPalette GetResolvedPalette()
	{
		return null;
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public void PerformNeedPaint(bool needLayout)
	{
		OnNeedPaint(this, new NeedLayoutEventArgs(needLayout));
	}

	public ViewManager GetViewManager()
	{
		return ViewManager;
	}

	protected virtual void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
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

	protected override void OnLayout(LayoutEventArgs levent)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			int num = 5;
			do
			{
				_layoutDirty = false;
				ViewManager.Layout(Renderer);
			}
			while (_layoutDirty && num-- > 0);
		}
		base.OnLayout(levent);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (base.IsDisposed || ViewManager == null)
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
		ViewManager.Paint(Renderer, e);
		_refresh = false;
		_refreshAll = false;
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
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			ViewManager.MouseUp(e, new Point(e.X, e.Y));
		}
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

	protected override bool ProcessDialogKey(Keys keyData)
	{
		if (!base.IsDisposed && keyData == Keys.Escape)
		{
			Dispose();
			return true;
		}
		return base.ProcessDialogKey(keyData);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (!base.IsDisposed)
		{
			if (e.KeyData == Keys.Escape)
			{
				Dispose();
			}
			else if (ViewManager != null)
			{
				ViewManager.KeyDown(e);
			}
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

	protected override void WndProc(ref Message m)
	{
		int msg = m.Msg;
		int num = msg;
		if (num == 33)
		{
			m.Result = (IntPtr)3;
		}
		else
		{
			base.WndProc(ref m);
		}
	}

	private Rectangle CalculateBelowPopupRect(Rectangle parentScreenRect, Size popupSize)
	{
		Screen screen = Screen.FromRectangle(parentScreenRect);
		Point location = new Point(parentScreenRect.X, parentScreenRect.Bottom);
		if (parentScreenRect.Bottom + popupSize.Height <= screen.WorkingArea.Bottom)
		{
			location.Y = parentScreenRect.Bottom;
		}
		else if (parentScreenRect.Top - popupSize.Height >= screen.WorkingArea.Top)
		{
			location.Y = parentScreenRect.Top - popupSize.Height;
		}
		else
		{
			int num = parentScreenRect.Top - screen.WorkingArea.Top;
			int num2 = screen.WorkingArea.Bottom - parentScreenRect.Bottom;
			if (num > num2)
			{
				location.Y = screen.WorkingArea.Top;
			}
			else
			{
				location.Y = parentScreenRect.Bottom;
			}
		}
		if (location.X < screen.WorkingArea.Left)
		{
			location.X = screen.WorkingArea.Left;
		}
		if (location.X + popupSize.Width > screen.WorkingArea.Right)
		{
			location.X = screen.WorkingArea.Right - popupSize.Width;
		}
		return new Rectangle(location, popupSize);
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
}
