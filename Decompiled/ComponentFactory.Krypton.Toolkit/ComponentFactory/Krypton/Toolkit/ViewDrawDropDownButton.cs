#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawDropDownButton : ViewLeaf
{
	private IPalette _palette;

	private VisualOrientation _orientation;

	public IPalette Palette
	{
		get
		{
			return _palette;
		}
		set
		{
			_palette = value;
		}
	}

	public VisualOrientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			_orientation = value;
		}
	}

	public ViewDrawDropDownButton()
	{
		_orientation = VisualOrientation.Top;
	}

	public override string ToString()
	{
		return "ViewDrawDropDownButton:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		return context.Renderer.RenderGlyph.GetDropDownButtonPreferredSize(context, _palette, State, Orientation);
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
		context.Renderer.RenderGlyph.DrawDropDownButton(context, ClientRectangle, _palette, State, Orientation);
	}
}
