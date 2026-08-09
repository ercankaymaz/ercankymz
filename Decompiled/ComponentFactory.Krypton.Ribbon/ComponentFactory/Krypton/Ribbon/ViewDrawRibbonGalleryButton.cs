#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGalleryButton : ViewLeaf, IContentValues
{
	private IPalette _palette;

	private GalleryImages _images;

	private GalleryButtonController _controller;

	private PaletteRibbonGalleryButton _button;

	private PaletteBackToPalette _paletteBack;

	private PaletteBorderToPalette _paletteBorder;

	private PaletteContentToPalette _paletteContent;

	private PaletteRelativeAlign _alignment;

	private IDisposable _mementoBack;

	private IDisposable _mementoContent;

	private NeedPaintHandler _needPaint;

	public event MouseEventHandler Click;

	public ViewDrawRibbonGalleryButton(IPalette palette, PaletteRelativeAlign alignment, PaletteRibbonGalleryButton button, GalleryImages images, NeedPaintHandler needPaint)
	{
		_palette = palette;
		_alignment = alignment;
		_button = button;
		_images = images;
		_needPaint = needPaint;
		_paletteBack = new PaletteBackToPalette(palette, PaletteBackStyle.ButtonGallery);
		_paletteBorder = new PaletteBorderToPalette(palette, PaletteBorderStyle.ButtonGallery);
		_paletteContent = new PaletteContentToPalette(palette, PaletteContentStyle.ButtonGallery);
		_controller = new GalleryButtonController(this, needPaint, alignment != PaletteRelativeAlign.Far);
		_controller.Click += OnButtonClick;
		MouseController = _controller;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGalleryButton:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (_mementoBack != null)
			{
				_mementoBack.Dispose();
				_mementoBack = null;
			}
			if (_mementoContent != null)
			{
				_mementoContent.Dispose();
				_mementoContent = null;
			}
		}
		base.Dispose(disposing);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _paletteContent, this, VisualOrientation.Top, State, composition: false);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		if (_mementoContent != null)
		{
			_mementoContent.Dispose();
			_mementoContent = null;
		}
		_mementoContent = context.Renderer.RenderStandardContent.LayoutContent(context, ClientRectangle, _paletteContent, this, VisualOrientation.Top, State, composition: false);
	}

	public override void RenderBefore(RenderContext context)
	{
		Rectangle clientRectangle = ClientRectangle;
		clientRectangle.Inflate(-1, -1);
		if (!Enabled)
		{
			ElementState = PaletteState.Disabled;
		}
		else if (ElementState == PaletteState.Disabled)
		{
			ElementState = PaletteState.Normal;
		}
		using GraphicsPath path = CreateBorderPath(ClientRectangle);
		if (_paletteBack.GetBackDraw(State) == InheritBool.True)
		{
			_mementoBack = context.Renderer.RenderStandardBack.DrawBack(context, clientRectangle, path, _paletteBack, VisualOrientation.Top, State, _mementoBack);
		}
		if (_paletteContent.GetContentDraw(State) == InheritBool.True)
		{
			context.Renderer.RenderStandardContent.DrawContent(context, ClientRectangle, _paletteContent, _mementoContent, VisualOrientation.Top, State, composition: false, allowFocusRect: false);
		}
		if (_paletteBorder.GetBorderDraw(State) != InheritBool.True)
		{
			return;
		}
		Color borderColor = _paletteBorder.GetBorderColor1(State);
		using (new AntiAlias(context.Graphics))
		{
			using Pen pen = new Pen(borderColor);
			context.Graphics.DrawPath(pen, path);
		}
	}

	public void ForceLeave()
	{
		_controller.ForceLeave();
	}

	private GraphicsPath CreateBorderPath(Rectangle rect)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		switch (_alignment)
		{
		case PaletteRelativeAlign.Near:
			graphicsPath.AddLine(rect.Left, rect.Bottom - 1, rect.Left, rect.Top);
			graphicsPath.AddLine(rect.Left, rect.Top, rect.Right - 2, rect.Top);
			graphicsPath.AddLine(rect.Right - 2, rect.Top, rect.Right - 1, rect.Top + 1);
			graphicsPath.AddLine(rect.Right - 1, rect.Top + 1, rect.Right - 1, rect.Bottom - 1);
			graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 1, rect.Left, rect.Bottom - 1);
			graphicsPath.CloseFigure();
			break;
		case PaletteRelativeAlign.Far:
			graphicsPath.AddLine(rect.Left, rect.Top, rect.Right - 1, rect.Top);
			graphicsPath.AddLine(rect.Right - 1, rect.Top, rect.Right - 1, rect.Bottom - 2);
			graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 1);
			graphicsPath.AddLine(rect.Right - 2, rect.Bottom - 1, rect.Left, rect.Bottom - 1);
			graphicsPath.AddLine(rect.Left, rect.Bottom - 1, rect.Left, rect.Top);
			graphicsPath.CloseFigure();
			break;
		case PaletteRelativeAlign.Center:
			graphicsPath.AddLine(rect.Left, rect.Top, rect.Right - 1, rect.Top);
			graphicsPath.AddLine(rect.Right - 1, rect.Top, rect.Right - 1, rect.Bottom - 1);
			graphicsPath.AddLine(rect.Right - 1, rect.Bottom - 1, rect.Left, rect.Bottom - 1);
			graphicsPath.AddLine(rect.Left, rect.Bottom - 1, rect.Left, rect.Top);
			graphicsPath.CloseFigure();
			break;
		}
		return graphicsPath;
	}

	public virtual Image GetImage(PaletteState state)
	{
		GalleryButtonImages galleryButtonImages = null;
		switch (_button)
		{
		case PaletteRibbonGalleryButton.Up:
			galleryButtonImages = _images.Up;
			break;
		case PaletteRibbonGalleryButton.Down:
			galleryButtonImages = _images.Down;
			break;
		case PaletteRibbonGalleryButton.DropDown:
			galleryButtonImages = _images.DropDown;
			break;
		}
		Image image = null;
		switch (State)
		{
		case PaletteState.Disabled:
			image = galleryButtonImages.Disabled;
			break;
		case PaletteState.Normal:
			image = galleryButtonImages.Normal;
			break;
		case PaletteState.Tracking:
			image = galleryButtonImages.Tracking;
			break;
		case PaletteState.Pressed:
			image = galleryButtonImages.Pressed;
			break;
		}
		if (image == null)
		{
			image = galleryButtonImages.Common;
		}
		if (image == null)
		{
			return _palette.GetGalleryButtonImage(_button, State);
		}
		return image;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		return string.Empty;
	}

	public string GetLongText()
	{
		return string.Empty;
	}

	private void OnButtonClick(object sender, MouseEventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, e);
		}
	}
}
