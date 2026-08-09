#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawTrackTrack : ViewLeaf
{
	private ViewDrawTrackBar _drawTrackBar;

	public ViewDrawTrackTrack(ViewDrawTrackBar drawTrackBar)
	{
		_drawTrackBar = drawTrackBar;
	}

	public override string ToString()
	{
		return "ViewDrawTrackTrack:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		return _drawTrackBar.TrackSize;
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
		IPaletteElementColor elementPalette = ((!Enabled) ? ((IPaletteElementColor)_drawTrackBar.StateDisabled.Track) : ((IPaletteElementColor)_drawTrackBar.StateNormal.Track));
		context.Renderer.RenderGlyph.DrawTrackGlyph(context, State, elementPalette, ClientRectangle, _drawTrackBar.Orientation, _drawTrackBar.VolumeControl);
	}
}
