#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewManager : GlobalId, IDisposable
{
	private ViewBase _root;

	private ViewBase _activeView;

	private bool _mouseCaptured;

	private bool _doNotLayoutControls;

	private bool _outputDebug;

	private Control _control;

	private Control _alignControl;

	private int _layoutCounter;

	private int _paintCounter;

	private long _outputStart;

	public ViewBase Root
	{
		[DebuggerStepThrough]
		get
		{
			return _root;
		}
		set
		{
			Debug.Assert(value != null);
			_root = value;
			_root.OwningControl = _control;
		}
	}

	public Control Control
	{
		[DebuggerStepThrough]
		get
		{
			return _control;
		}
		set
		{
			_control = value;
		}
	}

	public Control AlignControl
	{
		[DebuggerStepThrough]
		get
		{
			return _alignControl;
		}
		set
		{
			_alignControl = value;
		}
	}

	public bool DoNotLayoutControls
	{
		[DebuggerStepThrough]
		get
		{
			return _doNotLayoutControls;
		}
		set
		{
			_doNotLayoutControls = value;
		}
	}

	public bool OutputDebug
	{
		[DebuggerStepThrough]
		get
		{
			return _outputDebug;
		}
		set
		{
			_outputDebug = value;
		}
	}

	public ViewBase ActiveView
	{
		get
		{
			return _activeView;
		}
		set
		{
			if (value != _activeView)
			{
				if (_activeView != null)
				{
					_activeView.MouseLeave(value);
				}
				_activeView = value;
				if (_activeView != null)
				{
					_activeView.MouseEnter();
				}
			}
		}
	}

	public bool MouseCaptured
	{
		get
		{
			return _mouseCaptured;
		}
		set
		{
			_mouseCaptured = value;
		}
	}

	public int LayoutCounter => _layoutCounter;

	public int PaintCounter => _paintCounter;

	public event EventHandler LayoutBefore;

	public event EventHandler LayoutAfter;

	public event MouseEventHandler MouseDownProcessed;

	public event MouseEventHandler MouseUpProcessed;

	public event PointHandler DoubleClickProcessed;

	public ViewManager()
	{
	}

	public ViewManager(Control control, ViewBase root)
	{
		_root = root;
		_root.OwningControl = control;
		_control = control;
		_alignControl = control;
	}

	public virtual void Dispose()
	{
		if (_root != null)
		{
			_root.Dispose();
		}
	}

	public void Attach(Control control, ViewBase root)
	{
		_root = root;
		_root.OwningControl = control;
		_control = control;
		_alignControl = control;
	}

	public virtual Size GetPreferredSize(IRenderer renderer, Size proposedSize)
	{
		if (renderer == null || Root == null)
		{
			return Size.Empty;
		}
		Size size = Size.Empty;
		if (!_control.IsDisposed)
		{
			using ViewLayoutContext context = new ViewLayoutContext(this, _control, _alignControl, renderer, proposedSize);
			size = Root.GetPreferredSize(context);
		}
		if (_outputDebug)
		{
			Console.WriteLine("Id:{0} GetPreferredSize Type:{1} Ret:{2} Proposed:{3}", base.Id, _control.GetType().ToString(), size, proposedSize);
		}
		return size;
	}

	public bool EvalTransparentPaint(IRenderer renderer)
	{
		Debug.Assert(renderer != null);
		Debug.Assert(Root != null);
		if (renderer == null)
		{
			throw new ArgumentNullException("renderer");
		}
		using ViewContext context = new ViewContext(this, _control, _alignControl, renderer);
		return Root.EvalTransparentPaint(context);
	}

	public virtual Component ComponentFromPoint(Point pt)
	{
		for (ViewBase viewBase = Root.ViewFromPoint(pt); viewBase != null; viewBase = viewBase.Parent)
		{
			if (viewBase.Component != null)
			{
				return viewBase.Component;
			}
		}
		return null;
	}

	public virtual void Layout(IRenderer renderer)
	{
		Debug.Assert(renderer != null);
		Debug.Assert(Root != null);
		if (!_control.IsDisposed)
		{
			using (ViewLayoutContext context = new ViewLayoutContext(this, _control, _alignControl, renderer))
			{
				Layout(context);
			}
		}
	}

	public virtual void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Debug.Assert(context.Renderer != null);
		Debug.Assert(Root != null);
		if (!context.Control.IsDisposed)
		{
			if (_outputDebug)
			{
				PI.QueryPerformanceCounter(ref _outputStart);
			}
			if (context.Renderer == null)
			{
				throw new ArgumentNullException("renderer");
			}
			if (this.LayoutBefore != null)
			{
				this.LayoutBefore(this, EventArgs.Empty);
			}
			Root.Layout(context);
			if (this.LayoutAfter != null)
			{
				this.LayoutAfter(this, EventArgs.Empty);
			}
			if (_outputDebug)
			{
				long var = 0L;
				PI.QueryPerformanceCounter(ref var);
				long num = var - _outputStart;
				Console.WriteLine("Id:{0} Layout Type:{1} Elapsed:{2} Rect:{3}", base.Id, context.Control.GetType().ToString(), num.ToString(), context.DisplayRectangle);
			}
			_layoutCounter++;
		}
	}

	public virtual void Paint(IRenderer renderer, PaintEventArgs e)
	{
		Debug.Assert(renderer != null);
		Debug.Assert(e != null);
		if (renderer == null)
		{
			throw new ArgumentNullException("renderer");
		}
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (!_control.IsDisposed)
		{
			using (RenderContext context = new RenderContext(this, _control, _alignControl, e.Graphics, e.ClipRectangle, renderer))
			{
				Paint(context);
			}
		}
	}

	public virtual void Paint(RenderContext context)
	{
		Debug.Assert(context != null);
		Debug.Assert(Root != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (!_control.IsDisposed)
		{
			if (_outputDebug)
			{
				PI.QueryPerformanceCounter(ref _outputStart);
			}
			Root.Render(context);
			if (_outputDebug)
			{
				long var = 0L;
				PI.QueryPerformanceCounter(ref var);
				long num = var - _outputStart;
				Console.WriteLine("Id:{0} Paint Type:{1} Elapsed: {2}", base.Id, _control.GetType().ToString(), num.ToString());
			}
		}
		_paintCounter++;
	}

	public virtual void MouseMove(MouseEventArgs e, Point rawPt)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		UpdateViewFromPoint(pt: new Point(e.X, e.Y), control: _control);
		if (ActiveView != null)
		{
			ActiveView.MouseMove(rawPt);
		}
	}

	public virtual void MouseDown(MouseEventArgs e, Point rawPt)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		UpdateViewFromPoint(pt: new Point(e.X, e.Y), control: _control);
		if (ActiveView != null)
		{
			MouseCaptured = ActiveView.MouseDown(rawPt, e.Button);
		}
		PerformMouseDownProcessed(e);
	}

	public virtual void MouseUp(MouseEventArgs e, Point rawPt)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		UpdateViewFromPoint(pt: new Point(e.X, e.Y), control: _control);
		if (ActiveView != null)
		{
			ActiveView.MouseUp(rawPt, e.Button);
		}
		MouseCaptured = false;
		PerformMouseUpProcessed(e);
	}

	public virtual void MouseLeave(EventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (ActiveView != null)
		{
			ActiveView = null;
			MouseCaptured = false;
		}
	}

	public virtual void DoubleClick(Point pt)
	{
		if (ActiveView != null)
		{
			ActiveView.DoubleClick(pt);
		}
		if (this.DoubleClickProcessed != null)
		{
			this.DoubleClickProcessed(this, pt);
		}
	}

	public void PerformMouseDownProcessed(MouseEventArgs e)
	{
		if (this.MouseDownProcessed != null)
		{
			this.MouseDownProcessed(this, e);
		}
	}

	public void PerformMouseUpProcessed(MouseEventArgs e)
	{
		if (this.MouseUpProcessed != null)
		{
			this.MouseUpProcessed(this, e);
		}
	}

	public virtual void KeyDown(KeyEventArgs e)
	{
		if (ActiveView != null)
		{
			ActiveView.KeyDown(e);
		}
		else if (_root != null)
		{
			_root.KeyDown(e);
		}
	}

	public virtual void KeyPress(KeyPressEventArgs e)
	{
		if (ActiveView != null)
		{
			ActiveView.KeyPress(e);
		}
		else if (_root != null)
		{
			_root.KeyPress(e);
		}
	}

	public virtual void KeyUp(KeyEventArgs e)
	{
		if (ActiveView != null)
		{
			MouseCaptured = ActiveView.KeyUp(e);
		}
		else if (_root != null)
		{
			MouseCaptured = _root.KeyUp(e);
		}
	}

	public virtual void GotFocus()
	{
		if (ActiveView != null)
		{
			ActiveView.GotFocus(_control);
		}
		else if (_root != null)
		{
			_root.GotFocus(_control);
		}
	}

	public virtual void LostFocus()
	{
		if (ActiveView != null)
		{
			ActiveView.LostFocus(_control);
		}
		else if (_root != null)
		{
			_root.LostFocus(_control);
		}
	}

	public void ResetCounters()
	{
		_layoutCounter = 0;
		_paintCounter = 0;
	}

	protected virtual void UpdateViewFromPoint(Control control, Point pt)
	{
		if (!MouseCaptured)
		{
			ActiveView = Root.ViewFromPoint(pt);
		}
	}
}
