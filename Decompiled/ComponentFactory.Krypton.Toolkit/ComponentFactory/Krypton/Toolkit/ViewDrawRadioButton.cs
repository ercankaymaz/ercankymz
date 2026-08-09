#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawRadioButton : ViewLeaf
{
	private IPalette _palette;

	private bool _checkState;

	private bool _tracking;

	private bool _pressed;

	public bool CheckState
	{
		get
		{
			return _checkState;
		}
		set
		{
			_checkState = value;
		}
	}

	public bool Tracking
	{
		get
		{
			return _tracking;
		}
		set
		{
			_tracking = value;
		}
	}

	public bool Pressed
	{
		get
		{
			return _pressed;
		}
		set
		{
			_pressed = value;
		}
	}

	public ViewDrawRadioButton(IPalette palette)
	{
		Debug.Assert(palette != null);
		_palette = palette;
	}

	public override string ToString()
	{
		return "ViewDrawRadioButton:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		return context.Renderer.RenderGlyph.GetRadioButtonPreferredSize(context, _palette, Enabled, _checkState, _tracking, _pressed);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		context.Renderer.RenderGlyph.DrawRadioButton(context, ClientRectangle, _palette, Enabled, _checkState, _tracking, _pressed);
	}
}
