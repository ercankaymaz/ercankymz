#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawTrackTicks : ViewLeaf
{
	private ViewDrawTrackBar _drawTrackBar;

	private bool _topRight;

	public ViewDrawTrackTicks(ViewDrawTrackBar drawTrackBar, bool topRight)
	{
		_drawTrackBar = drawTrackBar;
		_topRight = topRight;
	}

	public override string ToString()
	{
		return "ViewDrawTrackTicks:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		return _drawTrackBar.TickSize;
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
		IPaletteElementColor elementPalette = ((!Enabled) ? ((IPaletteElementColor)_drawTrackBar.StateDisabled.Tick) : ((IPaletteElementColor)_drawTrackBar.StateNormal.Tick));
		context.Renderer.RenderGlyph.DrawTrackTicksGlyph(context, State, elementPalette, ClientRectangle, _drawTrackBar.Orientation, _topRight, _drawTrackBar.PositionSize, _drawTrackBar.Minimum, _drawTrackBar.Maximum, _drawTrackBar.TickFrequency);
	}
}
