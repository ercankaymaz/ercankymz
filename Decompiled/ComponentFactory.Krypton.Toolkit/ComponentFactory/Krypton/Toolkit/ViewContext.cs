using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewContext : GlobalId, IDisposable
{
	private ViewManager _manager;

	private Control _control;

	private Control _alignControl;

	private Graphics _graphics;

	private Control _topControl;

	private IRenderer _renderer;

	private bool _disposeGraphics;

	private bool _disposeManager;

	public ViewManager ViewManager
	{
		[DebuggerStepThrough]
		get
		{
			return _manager;
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

	public Graphics Graphics
	{
		get
		{
			if (_graphics == null)
			{
				if (Control.IsHandleCreated)
				{
					_graphics = Control.CreateGraphics();
				}
				else
				{
					_graphics = Graphics.FromHwnd(IntPtr.Zero);
				}
				_disposeGraphics = true;
			}
			return _graphics;
		}
	}

	public Control TopControl
	{
		get
		{
			if (_topControl == null)
			{
				_topControl = _control.TopLevelControl;
				if (_topControl == null)
				{
					Control control = _control;
					while (control.Parent != null && !(control is Form))
					{
						control = control.Parent;
					}
					_topControl = control;
				}
			}
			return _topControl;
		}
	}

	public IRenderer Renderer
	{
		[DebuggerStepThrough]
		get
		{
			return _renderer;
		}
	}

	public ViewContext(ViewManager manager, Control control, Control alignControl, IRenderer renderer)
		: this(manager, control, alignControl, null, renderer)
	{
	}

	public ViewContext(Control control, Control alignControl, Graphics graphics, IRenderer renderer)
		: this(null, control, alignControl, graphics, renderer)
	{
	}

	public ViewContext(ViewManager manager, Control control, Control alignControl, Graphics graphics, IRenderer renderer)
	{
		if (manager != null)
		{
			_manager = manager;
		}
		else
		{
			_manager = new ViewManager(control, new ViewLayoutNull());
			_disposeManager = true;
		}
		_control = control;
		_alignControl = alignControl;
		_graphics = graphics;
		_renderer = renderer;
	}

	public void Dispose()
	{
		if (_graphics != null)
		{
			if (_disposeGraphics)
			{
				_graphics.Dispose();
			}
			_graphics = null;
		}
		if (_manager != null)
		{
			if (_disposeManager)
			{
				_manager.Dispose();
			}
			_manager = null;
		}
	}
}
