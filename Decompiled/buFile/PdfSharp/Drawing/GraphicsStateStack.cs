using System;
using System.Collections.Generic;

namespace PdfSharp.Drawing;

internal class GraphicsStateStack
{
	private readonly InternalGraphicsState _current;

	private readonly Stack<InternalGraphicsState> _stack = new Stack<InternalGraphicsState>();

	public int Count => _stack.Count;

	public InternalGraphicsState Current
	{
		get
		{
			if (_stack.Count == 0)
			{
				return _current;
			}
			return _stack.Peek();
		}
	}

	public GraphicsStateStack(XGraphics gfx)
	{
		_current = new InternalGraphicsState(gfx);
	}

	public void Push(InternalGraphicsState state)
	{
		_stack.Push(state);
		state.Pushed();
	}

	public int Restore(InternalGraphicsState state)
	{
		if (!_stack.Contains(state))
		{
			throw new ArgumentException("State not on stack.", "state");
		}
		if (state.Invalid)
		{
			throw new ArgumentException("State already restored.", "state");
		}
		int num = 1;
		InternalGraphicsState internalGraphicsState = _stack.Pop();
		internalGraphicsState.Popped();
		while (internalGraphicsState != state)
		{
			num++;
			state.Invalid = true;
			internalGraphicsState = _stack.Pop();
			internalGraphicsState.Popped();
		}
		state.Invalid = true;
		return num;
	}
}
