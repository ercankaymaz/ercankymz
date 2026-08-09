using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class ViewBase : GlobalId, IDisposable, IList<ViewBase>, ICollection<ViewBase>, IEnumerable<ViewBase>, IEnumerable
{
	private bool _disposed;

	private bool _enabled;

	private bool _enableDependant;

	private bool _visible;

	private bool _fixed;

	private ViewBase _parent;

	private ViewBase _enableDependantView;

	private Component _component;

	private Rectangle _clientRect;

	private PaletteState _fixedState;

	private PaletteState _elementState;

	private IMouseController _mouseController;

	private IKeyController _keyController;

	private ISourceController _sourceController;

	private Control _owningControl;

	public bool IsDisposed => _disposed;

	public virtual Control OwningControl
	{
		get
		{
			if (_owningControl != null)
			{
				return _owningControl;
			}
			if (Parent != null)
			{
				return Parent.OwningControl;
			}
			return null;
		}
		set
		{
			_owningControl = value;
		}
	}

	public virtual bool Enabled
	{
		[DebuggerStepThrough]
		get
		{
			return _enabled;
		}
		set
		{
			_enabled = value;
		}
	}

	public virtual bool Visible
	{
		[DebuggerStepThrough]
		get
		{
			return _visible;
		}
		set
		{
			_visible = value;
		}
	}

	public virtual Rectangle ClientRectangle
	{
		[DebuggerStepThrough]
		get
		{
			return _clientRect;
		}
		set
		{
			_clientRect = value;
		}
	}

	public virtual Point ClientLocation
	{
		[DebuggerStepThrough]
		get
		{
			return _clientRect.Location;
		}
		set
		{
			_clientRect.Location = value;
		}
	}

	public virtual Size ClientSize
	{
		[DebuggerStepThrough]
		get
		{
			return _clientRect.Size;
		}
		set
		{
			_clientRect.Size = value;
		}
	}

	public virtual int ClientWidth
	{
		[DebuggerStepThrough]
		get
		{
			return _clientRect.Width;
		}
		set
		{
			_clientRect.Width = value;
		}
	}

	public virtual int ClientHeight
	{
		[DebuggerStepThrough]
		get
		{
			return _clientRect.Height;
		}
		set
		{
			_clientRect.Height = value;
		}
	}

	public virtual Component Component
	{
		get
		{
			return _component;
		}
		set
		{
			_component = value;
		}
	}

	public ViewBase Parent
	{
		[DebuggerStepThrough]
		get
		{
			return _parent;
		}
		set
		{
			_parent = value;
		}
	}

	public abstract int Count { get; }

	public bool IsReadOnly
	{
		[DebuggerStepThrough]
		get
		{
			return false;
		}
	}

	public abstract ViewBase this[int index] { get; set; }

	public virtual IMouseController MouseController
	{
		[DebuggerStepThrough]
		get
		{
			return _mouseController;
		}
		set
		{
			_mouseController = value;
		}
	}

	public virtual IKeyController KeyController
	{
		[DebuggerStepThrough]
		get
		{
			return _keyController;
		}
		set
		{
			_keyController = value;
		}
	}

	public virtual ISourceController SourceController
	{
		[DebuggerStepThrough]
		get
		{
			return _sourceController;
		}
		set
		{
			_sourceController = value;
		}
	}

	public virtual PaletteState ElementState
	{
		[DebuggerStepThrough]
		get
		{
			return _elementState;
		}
		set
		{
			_elementState = value;
		}
	}

	public virtual PaletteState State
	{
		get
		{
			if (IsFixed)
			{
				return _fixedState;
			}
			if (IsEnableDependant)
			{
				if (!_enableDependantView.Enabled)
				{
					return PaletteState.Disabled;
				}
			}
			else if (!Enabled)
			{
				return PaletteState.Disabled;
			}
			return ElementState;
		}
	}

	public virtual PaletteState FixedState
	{
		[DebuggerStepThrough]
		get
		{
			return _fixedState;
		}
		set
		{
			_fixed = true;
			_fixedState = value;
		}
	}

	public virtual bool IsFixed
	{
		[DebuggerStepThrough]
		get
		{
			return _fixed;
		}
	}

	public virtual ViewBase DependantEnabledState
	{
		[DebuggerStepThrough]
		get
		{
			return _enableDependantView;
		}
		set
		{
			if (value != null)
			{
				_enableDependant = true;
				_enableDependantView = value;
			}
			else
			{
				_enableDependant = false;
				_enableDependantView = null;
			}
		}
	}

	public virtual bool IsEnableDependant
	{
		[DebuggerStepThrough]
		get
		{
			return _enableDependant;
		}
	}

	protected ViewBase()
	{
		_enabled = true;
		_visible = true;
		_fixed = false;
		_enableDependant = false;
		_clientRect = Rectangle.Empty;
		_elementState = PaletteState.Normal;
	}

	~ViewBase()
	{
		if (!IsDisposed)
		{
			Dispose(disposing: false);
		}
	}

	public void Dispose()
	{
		if (!IsDisposed)
		{
			Dispose(disposing: true);
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			_parent = null;
			GC.SuppressFinalize(this);
		}
		_disposed = true;
	}

	public override string ToString()
	{
		return "ViewBase:" + base.Id;
	}

	public abstract bool EvalTransparentPaint(ViewContext context);

	public abstract Size GetPreferredSize(ViewLayoutContext context);

	public abstract void Layout(ViewLayoutContext context);

	public abstract void Render(RenderContext context);

	public virtual void RenderBefore(RenderContext context)
	{
	}

	public virtual void RenderAfter(RenderContext context)
	{
	}

	public abstract void Add(ViewBase item);

	public abstract void Clear();

	public abstract bool Contains(ViewBase item);

	public abstract bool ContainsRecurse(ViewBase item);

	public abstract void CopyTo(ViewBase[] array, int arrayIndex);

	public abstract bool Remove(ViewBase item);

	public abstract int IndexOf(ViewBase item);

	public abstract void Insert(int index, ViewBase item);

	public abstract void RemoveAt(int index);

	public abstract IEnumerator<ViewBase> GetEnumerator();

	public abstract IEnumerable<ViewBase> Recurse();

	public abstract IEnumerable<ViewBase> Reverse();

	public abstract IEnumerable<ViewBase> ReverseRecurse();

	[DebuggerStepThrough]
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public virtual IMouseController FindMouseController()
	{
		if (MouseController != null)
		{
			return MouseController;
		}
		if (Parent != null)
		{
			return Parent.FindMouseController();
		}
		return null;
	}

	public virtual void MouseEnter()
	{
		if (MouseController != null)
		{
			MouseController.MouseEnter(OwningControl);
		}
		else if (Parent != null)
		{
			Parent.MouseEnter();
		}
	}

	public virtual void MouseMove(Point pt)
	{
		if (MouseController != null)
		{
			MouseController.MouseMove(OwningControl, pt);
		}
		else if (Parent != null)
		{
			Parent.MouseMove(pt);
		}
	}

	public virtual bool MouseDown(Point pt, MouseButtons button)
	{
		if (MouseController != null)
		{
			return MouseController.MouseDown(OwningControl, pt, button);
		}
		if (Parent != null)
		{
			return Parent.MouseDown(pt, button);
		}
		return false;
	}

	public virtual void MouseUp(Point pt, MouseButtons button)
	{
		if (MouseController != null)
		{
			MouseController.MouseUp(OwningControl, pt, button);
		}
		else if (Parent != null)
		{
			Parent.MouseUp(pt, button);
		}
	}

	public virtual void MouseLeave(ViewBase next)
	{
		if (MouseController != null)
		{
			MouseController.MouseLeave(OwningControl, next);
		}
		else if (Parent != null)
		{
			Parent.MouseLeave(next);
		}
	}

	public virtual void DoubleClick(Point pt)
	{
		if (MouseController != null)
		{
			MouseController.DoubleClick(pt);
		}
		else if (Parent != null)
		{
			Parent.DoubleClick(pt);
		}
	}

	public virtual void KeyDown(KeyEventArgs e)
	{
		if (KeyController != null)
		{
			KeyController.KeyDown(OwningControl, e);
		}
		else if (Parent != null)
		{
			Parent.KeyDown(e);
		}
	}

	public virtual void KeyPress(KeyPressEventArgs e)
	{
		if (KeyController != null)
		{
			KeyController.KeyPress(OwningControl, e);
		}
		else if (Parent != null)
		{
			Parent.KeyPress(e);
		}
	}

	public virtual bool KeyUp(KeyEventArgs e)
	{
		if (KeyController != null)
		{
			return KeyController.KeyUp(OwningControl, e);
		}
		if (Parent != null)
		{
			return Parent.KeyUp(e);
		}
		return false;
	}

	public virtual void GotFocus(Control c)
	{
		if (SourceController != null)
		{
			SourceController.GotFocus(c);
		}
		else if (Parent != null)
		{
			Parent.GotFocus(c);
		}
	}

	public virtual void LostFocus(Control c)
	{
		if (SourceController != null)
		{
			SourceController.LostFocus(c);
		}
		else if (Parent != null)
		{
			Parent.LostFocus(c);
		}
	}

	public virtual void ClearFixedState()
	{
		_fixed = false;
	}

	public abstract ViewBase ViewFromPoint(Point pt);
}
