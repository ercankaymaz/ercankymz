#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawTrackPosition : ViewLeaf
{
	private ViewDrawTrackBar _drawTrackBar;

	public ViewDrawTrackPosition(ViewDrawTrackBar drawTrackBar)
	{
		_drawTrackBar = drawTrackBar;
	}

	public override string ToString()
	{
		return "ViewDrawTrackPosition:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		return _drawTrackBar.PositionSize;
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
		IPaletteElementColor paletteElementColor = null;
		paletteElementColor = State switch
		{
			PaletteState.Disabled => _drawTrackBar.StateDisabled.Position, 
			PaletteState.Tracking => _drawTrackBar.StateTracking.Position, 
			PaletteState.Pressed => _drawTrackBar.StatePressed.Position, 
			_ => _drawTrackBar.StateNormal.Position, 
		};
		context.Renderer.RenderGlyph.DrawTrackPositionGlyph(context, State, paletteElementColor, ClientRectangle, _drawTrackBar.Orientation, _drawTrackBar.TickStyle);
	}
}
