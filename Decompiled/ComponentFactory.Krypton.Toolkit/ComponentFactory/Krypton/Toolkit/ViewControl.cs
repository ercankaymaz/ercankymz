#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
public class ViewControl : Control
{
	private static MethodInfo _miPTB;

	private VisualControl _rootControl;

	private VisualPopup _rootPopup;

	private ViewLayoutControl _viewLayout;

	private NeedPaintHandler _needPaintDelegate;

	private bool _transparentBackground;

	private bool _inDesignMode;

	public ViewLayoutControl ViewLayoutControl
	{
		get
		{
			return _viewLayout;
		}
		set
		{
			_viewLayout = value;
		}
	}

	public bool TransparentBackground
	{
		get
		{
			return _transparentBackground;
		}
		set
		{
			_transparentBackground = value;
		}
	}

	public bool InDesignMode
	{
		get
		{
			return _inDesignMode;
		}
		set
		{
			_inDesignMode = value;
		}
	}

	public NeedPaintHandler NeedPaintDelegate => _needPaintDelegate;

	private Control RootInstance
	{
		get
		{
			if (_rootControl != null)
			{
				return _rootControl;
			}
			if (_rootPopup != null)
			{
				return _rootPopup;
			}
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IRenderer Renderer
	{
		get
		{
			if (_rootControl != null)
			{
				return _rootControl.Renderer;
			}
			if (_rootPopup != null)
			{
				return _rootPopup.Renderer;
			}
			Debug.Assert(condition: false);
			return null;
		}
	}

	public event PaintEventHandler PaintBackground;

	public event EventHandler<ViewControlHitTestArgs> WndProcHitTest;

	public ViewControl(VisualControl rootControl)
	{
		Debug.Assert(rootControl != null);
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		_transparentBackground = false;
		_inDesignMode = false;
		_rootControl = rootControl;
		_needPaintDelegate = OnNeedPaint;
	}

	public void UpdateParent(Control parent)
	{
		while (parent != null)
		{
			if (parent is VisualControl)
			{
				_rootControl = (VisualControl)parent;
				_rootPopup = null;
				break;
			}
			if (parent is VisualPopup)
			{
				_rootControl = null;
				_rootPopup = (VisualPopup)parent;
				break;
			}
			parent = parent.Parent;
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && !RootInstance.IsDisposed)
		{
			if (TransparentBackground)
			{
				PaintTransparentBackground(e);
			}
			if (this.PaintBackground != null)
			{
				this.PaintBackground(this, e);
			}
			using RenderContext context = new RenderContext(GetViewManager(), this, RootInstance, e.Graphics, e.ClipRectangle, Renderer);
			_viewLayout.ChildView.Render(context);
		}
	}

	protected override void OnDoubleClick(EventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && !RootInstance.IsDisposed && GetViewManager() != null)
		{
			GetViewManager().DoubleClick(PointToClient(Control.MousePosition));
		}
		base.OnDoubleClick(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && !RootInstance.IsDisposed && GetViewManager() != null)
		{
			Point point = RootInstance.PointToClient(PointToScreen(new Point(e.X, e.Y)));
			GetViewManager().MouseMove(new MouseEventArgs(e.Button, e.Clicks, point.X, point.Y, e.Delta), new Point(e.X, e.Y));
		}
		base.OnMouseMove(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && !RootInstance.IsDisposed)
		{
			if (GetViewManager() != null)
			{
				Point point = RootInstance.PointToClient(PointToScreen(new Point(e.X, e.Y)));
				GetViewManager().MouseDown(new MouseEventArgs(e.Button, e.Clicks, point.X, point.Y, e.Delta), new Point(e.X, e.Y));
			}
			if (!RootInstance.ContainsFocus && RootInstance.CanSelect && !InDesignMode)
			{
				RootInstance.Focus();
			}
		}
		base.OnMouseDown(e);
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && !RootInstance.IsDisposed && GetViewManager() != null)
		{
			Point point = RootInstance.PointToClient(PointToScreen(new Point(e.X, e.Y)));
			GetViewManager().MouseUp(new MouseEventArgs(e.Button, e.Clicks, point.X, point.Y, e.Delta), new Point(e.X, e.Y));
		}
		base.OnMouseUp(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && !RootInstance.IsDisposed && GetViewManager() != null)
		{
			GetViewManager().MouseLeave(e);
		}
		base.OnMouseLeave(e);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && !RootInstance.IsDisposed && GetViewManager() != null)
		{
			GetViewManager().KeyDown(e);
		}
		base.OnKeyDown(e);
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && !RootInstance.IsDisposed && GetViewManager() != null)
		{
			GetViewManager().KeyPress(e);
		}
		base.OnKeyPress(e);
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		if (!base.IsDisposed && !base.Disposing && !RootInstance.IsDisposed && GetViewManager() != null)
		{
			GetViewManager().KeyUp(e);
		}
		base.OnKeyUp(e);
	}

	protected virtual void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (base.IsHandleCreated)
		{
			if (e.InvalidRect.IsEmpty)
			{
				Invalidate(invalidateChildren: true);
			}
			else
			{
				Invalidate(e.InvalidRect, invalidateChildren: true);
			}
		}
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 132)
		{
			Point p = new Point((int)m.LParam.ToInt64());
			ViewControlHitTestArgs viewControlHitTestArgs = new ViewControlHitTestArgs(PointToClient(p));
			OnWndProcHitTest(viewControlHitTestArgs);
			if (!viewControlHitTestArgs.Cancel)
			{
				m.Result = viewControlHitTestArgs.Result;
				return;
			}
		}
		base.WndProc(ref m);
	}

	protected virtual void OnWndProcHitTest(ViewControlHitTestArgs e)
	{
		if (this.WndProcHitTest != null)
		{
			this.WndProcHitTest(this, e);
		}
	}

	private ViewManager GetViewManager()
	{
		if (_rootControl != null)
		{
			return _rootControl.GetViewManager();
		}
		if (_rootPopup != null)
		{
			return _rootPopup.GetViewManager();
		}
		Debug.Assert(condition: false);
		return null;
	}

	private void PaintTransparentBackground(PaintEventArgs e)
	{
		Control control = base.Parent;
		if (control != null)
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
			try
			{
				_miPTB.Invoke(this, new object[3] { e, base.ClientRectangle, null });
			}
			catch
			{
				_miPTB = null;
			}
		}
	}
}
