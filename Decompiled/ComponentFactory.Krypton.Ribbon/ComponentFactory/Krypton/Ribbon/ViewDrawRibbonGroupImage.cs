#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupImage : ViewLeaf
{
	private static readonly Size _viewSize_2007 = new Size(30, 31);

	private static readonly Size _viewSize_2010 = new Size(31, 31);

	private static readonly Size _imageSize = new Size(16, 16);

	private static readonly int _imageOffsetX = 7;

	private static readonly int _imageOffsetY_2007 = 4;

	private static readonly int _imageOffsetY_2010 = 7;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroup _ribbonGroup;

	private ViewDrawRibbonGroup _viewGroup;

	private IDisposable _memento1;

	private IDisposable _memento2;

	private Size _viewSize;

	private int _offsetY;

	public ViewDrawRibbonGroupImage(KryptonRibbon ribbon, KryptonRibbonGroup ribbonGroup, ViewDrawRibbonGroup viewGroup)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonGroup != null);
		Debug.Assert(viewGroup != null);
		_ribbon = ribbon;
		_ribbonGroup = ribbonGroup;
		_viewGroup = viewGroup;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupImage:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (_memento1 != null)
			{
				_memento1.Dispose();
				_memento1 = null;
			}
			if (_memento2 != null)
			{
				_memento2.Dispose();
				_memento2 = null;
			}
		}
		base.Dispose(disposing);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		PaletteRibbonShape ribbonShape = _ribbon.RibbonShape;
		PaletteRibbonShape paletteRibbonShape = ribbonShape;
		if (paletteRibbonShape == PaletteRibbonShape.Office2007 || paletteRibbonShape != PaletteRibbonShape.Office2010)
		{
			_viewSize = _viewSize_2007;
			_offsetY = _imageOffsetY_2007;
		}
		else
		{
			_viewSize = _viewSize_2010;
			_offsetY = _imageOffsetY_2010;
		}
		return _viewSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		ClientRectangle = context.DisplayRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		if (_ribbon.SelectedTab != null && !string.IsNullOrEmpty(_ribbon.SelectedTab.ContextName))
		{
			ElementState = (_viewGroup.Pressed ? PaletteState.Pressed : (_viewGroup.Tracking ? PaletteState.ContextTracking : PaletteState.ContextNormal));
		}
		else
		{
			ElementState = (_viewGroup.Pressed ? PaletteState.Pressed : (_viewGroup.Tracking ? PaletteState.Tracking : PaletteState.Normal));
		}
		IPaletteRibbonBack ribbonGroupCollapsedFrameBorder;
		IPaletteRibbonBack ribbonGroupCollapsedFrameBack;
		switch (State)
		{
		case PaletteState.Pressed:
			ribbonGroupCollapsedFrameBorder = _ribbon.StatePressed.RibbonGroupCollapsedFrameBorder;
			ribbonGroupCollapsedFrameBack = _ribbon.StatePressed.RibbonGroupCollapsedFrameBack;
			break;
		case PaletteState.ContextNormal:
			ribbonGroupCollapsedFrameBorder = _ribbon.StateContextNormal.RibbonGroupCollapsedFrameBorder;
			ribbonGroupCollapsedFrameBack = _ribbon.StateContextNormal.RibbonGroupCollapsedFrameBack;
			break;
		case PaletteState.ContextTracking:
			ribbonGroupCollapsedFrameBorder = _ribbon.StateContextTracking.RibbonGroupCollapsedFrameBorder;
			ribbonGroupCollapsedFrameBack = _ribbon.StateContextTracking.RibbonGroupCollapsedFrameBack;
			break;
		case PaletteState.Tracking:
			ribbonGroupCollapsedFrameBorder = _ribbon.StateTracking.RibbonGroupCollapsedFrameBorder;
			ribbonGroupCollapsedFrameBack = _ribbon.StateTracking.RibbonGroupCollapsedFrameBack;
			break;
		default:
			ribbonGroupCollapsedFrameBorder = _ribbon.StateNormal.RibbonGroupCollapsedFrameBorder;
			ribbonGroupCollapsedFrameBack = _ribbon.StateNormal.RibbonGroupCollapsedFrameBack;
			break;
		}
		Rectangle clientRectangle = ClientRectangle;
		clientRectangle.Inflate(-1, -1);
		_memento1 = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, clientRectangle, State, ribbonGroupCollapsedFrameBack, VisualOrientation.Top, composition: false, _memento1);
		_memento2 = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, ClientRectangle, State, ribbonGroupCollapsedFrameBorder, VisualOrientation.Top, composition: false, _memento2);
		if (_ribbonGroup.Image != null)
		{
			Rectangle rect = new Rectangle(new Point(ClientLocation.X + _imageOffsetX, ClientLocation.Y + _offsetY), _imageSize);
			context.Graphics.DrawImage(_ribbonGroup.Image, rect);
		}
	}
}
