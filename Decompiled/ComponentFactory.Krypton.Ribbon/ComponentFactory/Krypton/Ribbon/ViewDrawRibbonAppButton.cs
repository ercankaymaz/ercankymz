#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonAppButton : ViewLeaf
{
	private static readonly Size SIZE_FULL = new Size(39, 39);

	private static readonly Size SIZE_TOP = new Size(39, 22);

	private static readonly Size SIZE_BOTTOM = new Size(39, 17);

	private IDisposable[] _mementos;

	private KryptonRibbon _ribbon;

	private bool _bottomHalf;

	private Rectangle _clipRect;

	private Size _size;

	public override bool Visible
	{
		get
		{
			return base.Visible && (base.Parent == null || base.Parent.Visible);
		}
		set
		{
			base.Visible = value;
		}
	}

	public ViewDrawRibbonAppButton(KryptonRibbon ribbon, bool bottomHalf)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_bottomHalf = bottomHalf;
		_size = (_bottomHalf ? SIZE_BOTTOM : SIZE_TOP);
		_mementos = new IDisposable[3];
	}

	public override string ToString()
	{
		return "ViewDrawRibbonAppButton:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _mementos != null)
		{
			IDisposable[] mementos = _mementos;
			for (int i = 0; i < mementos.Length; i++)
			{
				mementos[i]?.Dispose();
			}
			_mementos = null;
		}
		base.Dispose(disposing);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return _size;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		_clipRect = ClientRectangle;
		if (_bottomHalf)
		{
			Rectangle clientRectangle = ClientRectangle;
			clientRectangle.Y -= SIZE_FULL.Height - SIZE_BOTTOM.Height;
			ClientRectangle = clientRectangle;
		}
		ClientHeight = SIZE_FULL.Height;
	}

	public override void RenderBefore(RenderContext context)
	{
		using Region region = new Region(_clipRect);
		Region region2 = context.Graphics.Clip.Clone();
		region.Intersect(region2);
		context.Graphics.Clip = region;
		IPaletteRibbonBack ribbonAppButton;
		int num;
		switch (State)
		{
		default:
			ribbonAppButton = _ribbon.StateNormal.RibbonAppButton;
			num = 0;
			break;
		case PaletteState.Tracking:
			ribbonAppButton = _ribbon.StateTracking.RibbonAppButton;
			num = 1;
			break;
		case PaletteState.Pressed:
			ribbonAppButton = _ribbon.StatePressed.RibbonAppButton;
			num = 2;
			break;
		}
		_mementos[num] = context.Renderer.RenderRibbon.DrawRibbonApplicationButton(_ribbon.RibbonShape, context, ClientRectangle, State, ribbonAppButton, _mementos[num]);
		if (_ribbon.RibbonAppButton.AppButtonImage != null)
		{
			Rectangle rectangle = new Rectangle(ClientLocation.X + 7, ClientLocation.Y + 6, 24, 24);
			if (_ribbon.Enabled)
			{
				context.Graphics.DrawImage(_ribbon.RibbonAppButton.AppButtonImage, rectangle);
			}
			else
			{
				using ImageAttributes imageAttributes = new ImageAttributes();
				imageAttributes.SetColorMatrix(CommonHelper.MatrixDisabled);
				context.Graphics.DrawImage(_ribbon.RibbonAppButton.AppButtonImage, rectangle, 0, 0, _ribbon.RibbonAppButton.AppButtonImage.Width, _ribbon.RibbonAppButton.AppButtonImage.Height, GraphicsUnit.Pixel, imageAttributes);
			}
		}
		context.Graphics.Clip = region2;
	}
}
