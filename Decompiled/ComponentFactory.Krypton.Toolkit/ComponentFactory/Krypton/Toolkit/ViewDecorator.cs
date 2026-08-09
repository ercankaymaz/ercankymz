#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class ViewDecorator : ViewBase
{
	private ViewBase _child;

	public override bool Enabled
	{
		get
		{
			return _child.Enabled;
		}
		set
		{
			_child.Enabled = value;
		}
	}

	public override bool Visible
	{
		get
		{
			return _child.Visible;
		}
		set
		{
			_child.Visible = value;
		}
	}

	public override Rectangle ClientRectangle
	{
		get
		{
			return _child.ClientRectangle;
		}
		set
		{
			_child.ClientRectangle = value;
		}
	}

	public override Point ClientLocation
	{
		get
		{
			return _child.ClientLocation;
		}
		set
		{
			_child.ClientLocation = value;
		}
	}

	public override Size ClientSize
	{
		get
		{
			return _child.ClientSize;
		}
		set
		{
			_child.ClientSize = value;
		}
	}

	public override int ClientWidth
	{
		get
		{
			return _child.ClientWidth;
		}
		set
		{
			_child.ClientWidth = value;
		}
	}

	public override int ClientHeight
	{
		get
		{
			return _child.ClientHeight;
		}
		set
		{
			_child.ClientHeight = value;
		}
	}

	public override int Count => _child.Count;

	public override ViewBase this[int index]
	{
		get
		{
			return _child[index];
		}
		set
		{
			_child[index] = value;
		}
	}

	public override IMouseController MouseController
	{
		get
		{
			return _child.MouseController;
		}
		set
		{
			_child.MouseController = value;
		}
	}

	public override IKeyController KeyController
	{
		get
		{
			return _child.KeyController;
		}
		set
		{
			_child.KeyController = value;
		}
	}

	public override ISourceController SourceController
	{
		get
		{
			return _child.SourceController;
		}
		set
		{
			_child.SourceController = value;
		}
	}

	public override PaletteState ElementState
	{
		get
		{
			return _child.ElementState;
		}
		set
		{
			_child.ElementState = value;
		}
	}

	public override PaletteState State
	{
		[DebuggerStepThrough]
		get
		{
			return _child.State;
		}
	}

	public override PaletteState FixedState
	{
		get
		{
			return _child.FixedState;
		}
		set
		{
			_child.FixedState = value;
		}
	}

	public override bool IsFixed => _child.IsFixed;

	public override ViewBase DependantEnabledState
	{
		get
		{
			return _child.DependantEnabledState;
		}
		set
		{
			_child.DependantEnabledState = value;
		}
	}

	public override bool IsEnableDependant => _child.IsEnableDependant;

	protected ViewDecorator(ViewBase child)
	{
		Debug.Assert(child != null);
		_child = child;
		_child.Parent = this;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _child != null)
		{
			_child.Dispose();
			_child = null;
		}
	}

	public override string ToString()
	{
		return "ViewDecorator:" + base.Id;
	}

	public override bool EvalTransparentPaint(ViewContext context)
	{
		return _child.EvalTransparentPaint(context);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return _child.GetPreferredSize(context);
	}

	public override void Layout(ViewLayoutContext context)
	{
		_child.Layout(context);
	}

	public override void Render(RenderContext context)
	{
		_child.Render(context);
	}

	public override void Add(ViewBase item)
	{
		_child.Add(item);
	}

	public override void Clear()
	{
		_child.Clear();
	}

	public override bool Contains(ViewBase item)
	{
		return _child.Contains(item);
	}

	public override bool ContainsRecurse(ViewBase item)
	{
		return _child.ContainsRecurse(item);
	}

	public override void CopyTo(ViewBase[] array, int arrayIndex)
	{
		_child.CopyTo(array, arrayIndex);
	}

	public override bool Remove(ViewBase item)
	{
		return _child.Remove(item);
	}

	public override int IndexOf(ViewBase item)
	{
		return _child.IndexOf(item);
	}

	public override void Insert(int index, ViewBase item)
	{
		_child.Insert(index, item);
	}

	public override void RemoveAt(int index)
	{
		_child.RemoveAt(index);
	}

	public override IEnumerator<ViewBase> GetEnumerator()
	{
		return _child.GetEnumerator();
	}

	public override IEnumerable<ViewBase> Recurse()
	{
		return _child.Recurse();
	}

	public override IEnumerable<ViewBase> Reverse()
	{
		return _child.Reverse();
	}

	public override IEnumerable<ViewBase> ReverseRecurse()
	{
		return _child.ReverseRecurse();
	}

	public override void MouseEnter()
	{
		if (base.Parent != null)
		{
			base.Parent.MouseEnter();
		}
	}

	public override void MouseMove(Point pt)
	{
		if (base.Parent != null)
		{
			base.Parent.MouseMove(pt);
		}
	}

	public override bool MouseDown(Point pt, MouseButtons button)
	{
		if (base.Parent != null)
		{
			return base.Parent.MouseDown(pt, button);
		}
		return false;
	}

	public override void MouseUp(Point pt, MouseButtons button)
	{
		if (base.Parent != null)
		{
			base.Parent.MouseUp(pt, button);
		}
	}

	public override void MouseLeave(ViewBase next)
	{
		if (base.Parent != null)
		{
			base.Parent.MouseLeave(next);
		}
	}

	public override void KeyDown(KeyEventArgs e)
	{
		if (base.Parent != null)
		{
			base.Parent.KeyDown(e);
		}
	}

	public override void KeyPress(KeyPressEventArgs e)
	{
		if (base.Parent != null)
		{
			base.Parent.KeyPress(e);
		}
	}

	public override bool KeyUp(KeyEventArgs e)
	{
		if (base.Parent != null)
		{
			return base.Parent.KeyUp(e);
		}
		return false;
	}

	public override void GotFocus(Control c)
	{
		if (base.Parent != null)
		{
			base.Parent.GotFocus(c);
		}
	}

	public override void LostFocus(Control c)
	{
		if (base.Parent != null)
		{
			base.Parent.LostFocus(c);
		}
	}

	public override void ClearFixedState()
	{
		_child.ClearFixedState();
	}

	public override ViewBase ViewFromPoint(Point pt)
	{
		return _child.ViewFromPoint(pt);
	}
}
