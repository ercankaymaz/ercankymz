#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawGroupBoxDocker : ViewDrawDocker
{
	private double _overlap;

	private Rectangle _cacheClientRect;

	public double CaptionOverlap
	{
		get
		{
			return _overlap;
		}
		set
		{
			_overlap = value;
		}
	}

	public override bool DrawBorderLast => false;

	public ViewDrawGroupBoxDocker(IPaletteBack paletteBack, IPaletteBorder paletteBorder)
		: base(paletteBack, paletteBorder)
	{
		_overlap = 0.5;
	}

	public override string ToString()
	{
		return "ViewDrawGroupBoxDocker:" + base.Id;
	}

	public override bool EvalTransparentPaint(ViewContext context)
	{
		return true;
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (this[0].Visible)
		{
			ViewDrawContent viewDrawContent = (ViewDrawContent)this[0];
			_cacheClientRect = ClientRectangle;
			Rectangle clientRectangle = viewDrawContent.ClientRectangle;
			switch (GetDock(viewDrawContent))
			{
			case ViewDockStyle.Top:
				if (clientRectangle.Height > 0)
				{
					int num4 = (int)((double)clientRectangle.Height * CaptionOverlap);
					ClientRectangle = new Rectangle(_cacheClientRect.X, _cacheClientRect.Y + num4, _cacheClientRect.Width, _cacheClientRect.Height - num4);
				}
				break;
			case ViewDockStyle.Left:
				if (clientRectangle.Width > 0)
				{
					int num2 = (int)((double)clientRectangle.Width * CaptionOverlap);
					ClientRectangle = new Rectangle(_cacheClientRect.X + num2, _cacheClientRect.Y, _cacheClientRect.Width - num2, _cacheClientRect.Height);
				}
				break;
			case ViewDockStyle.Bottom:
				if (clientRectangle.Height > 0)
				{
					int num3 = (int)((double)clientRectangle.Height * CaptionOverlap);
					ClientRectangle = new Rectangle(_cacheClientRect.X, _cacheClientRect.Y, _cacheClientRect.Width, _cacheClientRect.Height - num3);
				}
				break;
			case ViewDockStyle.Right:
				if (clientRectangle.Width > 0)
				{
					int num = (int)((double)clientRectangle.Width * CaptionOverlap);
					ClientRectangle = new Rectangle(_cacheClientRect.X, _cacheClientRect.Y, _cacheClientRect.Width - num, _cacheClientRect.Height);
				}
				break;
			}
		}
		base.RenderBefore(context);
	}

	public override void RenderAfter(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base.RenderAfter(context);
		if (this[0].Visible)
		{
			ClientRectangle = _cacheClientRect;
		}
	}

	public override void RenderBorder(RenderContext context)
	{
		ViewDrawContent viewDrawContent = (ViewDrawContent)this[0];
		Region region = context.Graphics.Clip.Clone();
		Region region2 = region.Clone();
		Rectangle rect = viewDrawContent.ImageRectangle(context);
		Rectangle rect2 = viewDrawContent.ShortTextRect(context);
		Rectangle rect3 = viewDrawContent.LongTextRect(context);
		rect.Inflate(1, 1);
		rect2.Inflate(1, 1);
		rect3.Inflate(1, 1);
		region2.Exclude(rect);
		region2.Exclude(rect2);
		region2.Exclude(rect3);
		context.Graphics.Clip = region2;
		base.RenderBorder(context);
		context.Graphics.Clip = region;
	}
}
