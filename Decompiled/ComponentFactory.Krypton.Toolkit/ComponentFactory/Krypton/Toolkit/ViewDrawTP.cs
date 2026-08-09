#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawTP : ViewComposite
{
	private ViewDrawTrackBar _drawTrackBar;

	private ViewDrawTrackTrack _drawTrack;

	private ViewDrawTrackPosition _drawPosition;

	public ViewDrawTrackBar ViewDrawTrackBar => _drawTrackBar;

	public ViewDrawTrackPosition ViewDrawTrackPosition => _drawPosition;

	public override bool Enabled
	{
		get
		{
			return base.Enabled;
		}
		set
		{
			base.Enabled = value;
			_drawTrack.Enabled = value;
			_drawPosition.Enabled = value;
		}
	}

	private Rectangle TrackArea
	{
		get
		{
			Rectangle clientRectangle = ClientRectangle;
			Rectangle clientRectangle2 = ViewDrawTrackPosition.ClientRectangle;
			if (_drawTrackBar.Orientation == Orientation.Horizontal)
			{
				clientRectangle.Width -= clientRectangle2.Width;
				clientRectangle.X += clientRectangle2.Width / 2;
			}
			else
			{
				clientRectangle.Height -= clientRectangle2.Height;
				clientRectangle.Y += clientRectangle2.Height / 2;
			}
			return clientRectangle;
		}
	}

	public ViewDrawTP(ViewDrawTrackBar drawTrackBar)
	{
		_drawTrackBar = drawTrackBar;
		_drawTrack = new ViewDrawTrackTrack(_drawTrackBar);
		_drawPosition = new ViewDrawTrackPosition(_drawTrackBar);
		Add(_drawTrack);
		Add(_drawPosition);
		drawTrackBar.SourceController = (ISourceController)(drawTrackBar.KeyController = (IKeyController)(drawTrackBar.MouseController = new TrackBarController(this)));
		TrackPositionController mouseController2 = new TrackPositionController(this);
		_drawPosition.MouseController = mouseController2;
	}

	public override string ToString()
	{
		return "ViewDrawTP:" + base.Id;
	}

	public virtual void SetFixedState(PaletteState state)
	{
		if (state == PaletteState.Normal || state == PaletteState.Disabled)
		{
			_drawTrack.FixedState = state;
		}
		_drawPosition.FixedState = state;
	}

	public int NearestValueFromPoint(Point pt)
	{
		int minimum = _drawTrackBar.Minimum;
		int maximum = _drawTrackBar.Maximum;
		int num = Math.Abs(maximum - minimum);
		if (num == 0)
		{
			return minimum;
		}
		Rectangle trackArea = TrackArea;
		if (_drawTrackBar.Orientation == Orientation.Horizontal)
		{
			if (_drawTrackBar.RightToLeft == RightToLeft.Yes)
			{
				if (pt.X <= trackArea.X)
				{
					return maximum;
				}
				if (pt.X >= trackArea.Right - 1)
				{
					return minimum;
				}
				float num2 = trackArea.Right - pt.X;
				float num3 = num2 / (float)trackArea.Width;
				float num4 = (float)minimum + num3 * (float)num;
				return (int)Math.Round(num4, 0, MidpointRounding.AwayFromZero);
			}
			if (pt.X <= trackArea.X)
			{
				return minimum;
			}
			if (pt.X >= trackArea.Right - 1)
			{
				return maximum;
			}
			float num5 = pt.X - trackArea.X;
			float num6 = num5 / (float)trackArea.Width;
			float num7 = (float)minimum + num6 * (float)num;
			return (int)Math.Round(num7, 0, MidpointRounding.AwayFromZero);
		}
		if (pt.Y <= trackArea.Y)
		{
			return maximum;
		}
		if (pt.Y >= trackArea.Bottom - 1)
		{
			return minimum;
		}
		float num8 = trackArea.Bottom - pt.Y;
		float num9 = num8 / (float)trackArea.Height;
		float num10 = (float)minimum + num9 * (float)num;
		return (int)Math.Round(num10, 0, MidpointRounding.AwayFromZero);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		Size preferredSize = _drawTrack.GetPreferredSize(context);
		Size preferredSize2 = _drawPosition.GetPreferredSize(context);
		int minimum = _drawTrackBar.Minimum;
		int maximum = _drawTrackBar.Maximum;
		int num = maximum - minimum;
		int num2 = _drawTrackBar.Value - minimum;
		Rectangle clientRectangle = ClientRectangle;
		Rectangle clientRectangle2 = ClientRectangle;
		if (_drawTrackBar.Orientation == Orientation.Horizontal)
		{
			float num3 = ClientWidth - preferredSize2.Width;
			if (_drawTrackBar.RightToLeft == RightToLeft.Yes)
			{
				if (num3 > 0f)
				{
					clientRectangle2.X = clientRectangle2.Right - preferredSize2.Width - (int)Math.Round(num3 / (float)num * (float)num2, 0, MidpointRounding.AwayFromZero);
				}
			}
			else if (num3 > 0f)
			{
				clientRectangle2.X += (int)Math.Round(num3 / (float)num * (float)num2, 0, MidpointRounding.AwayFromZero);
			}
			clientRectangle.Y += (ClientHeight - preferredSize.Height) / 2;
			clientRectangle.Height = preferredSize.Height;
			clientRectangle2.Y += (ClientHeight - preferredSize2.Height) / 2;
			clientRectangle2.Height = preferredSize2.Height;
			clientRectangle2.Width = preferredSize2.Width;
		}
		else
		{
			float num4 = ClientHeight - preferredSize2.Height;
			if (num4 > 0f)
			{
				clientRectangle2.Y = clientRectangle2.Bottom - preferredSize2.Height - (int)Math.Round(num4 / (float)num * (float)num2, 0, MidpointRounding.AwayFromZero);
			}
			clientRectangle.X += (ClientWidth - preferredSize.Width) / 2;
			clientRectangle.Width = preferredSize.Width;
			clientRectangle2.X += (ClientWidth - preferredSize2.Width) / 2;
			clientRectangle2.Width = preferredSize2.Width;
			clientRectangle2.Height = preferredSize2.Height;
		}
		context.DisplayRectangle = clientRectangle;
		_drawTrack.Layout(context);
		context.DisplayRectangle = clientRectangle2;
		_drawPosition.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}
}
