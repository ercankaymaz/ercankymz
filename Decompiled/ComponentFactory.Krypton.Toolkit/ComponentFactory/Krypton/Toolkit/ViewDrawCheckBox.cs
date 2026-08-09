#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawCheckBox : ViewLeaf
{
	private IPalette _palette;

	private CheckState _checkState;

	private bool _tracking;

	private bool _pressed;

	private bool _forceTracking;

	public CheckState CheckState
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
			return _forceTracking || _tracking;
		}
		set
		{
			_tracking = value;
		}
	}

	public bool ForcedTracking
	{
		get
		{
			return _forceTracking;
		}
		set
		{
			_forceTracking = value;
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

	public ViewDrawCheckBox(IPalette palette)
	{
		Debug.Assert(palette != null);
		_palette = palette;
	}

	public override string ToString()
	{
		return "ViewDrawCheckBox:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		return context.Renderer.RenderGlyph.GetCheckBoxPreferredSize(context, _palette, Enabled, _checkState, Tracking, _pressed);
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
		context.Renderer.RenderGlyph.DrawCheckBox(context, ClientRectangle, _palette, Enabled, _checkState, Tracking, _pressed);
	}
}
