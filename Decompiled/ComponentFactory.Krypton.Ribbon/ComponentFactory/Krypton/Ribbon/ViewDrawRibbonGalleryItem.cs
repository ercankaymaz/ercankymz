#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGalleryItem : ViewDrawButton, IContentValues
{
	private KryptonGallery _gallery;

	private GalleryItemController _controller;

	private ImageList _imageList;

	private Image _image;

	private int _imageIndex;

	public ImageList ImageList
	{
		set
		{
			if (_imageList != value)
			{
				if (_image != null)
				{
					_image.Dispose();
					_image = null;
				}
				_imageList = value;
			}
		}
	}

	public int ImageIndex
	{
		set
		{
			if (_imageIndex != value)
			{
				if (_image != null)
				{
					_image.Dispose();
					_image = null;
				}
				_imageIndex = value;
			}
		}
	}

	public ViewDrawRibbonGalleryItem(KryptonGallery gallery, IPaletteTriple palette, ViewLayoutRibbonGalleryItems layout, NeedPaintHandler needPaint)
		: base(palette, palette, palette, palette, null, null, VisualOrientation.Top, useMnemonic: false)
	{
		_gallery = gallery;
		base.ButtonValues = this;
		_controller = new GalleryItemController(this, layout, needPaint);
		_controller.Click += OnItemClick;
		MouseController = _controller;
		SourceController = _controller;
		KeyController = _controller;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGalleryItem:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _image != null)
		{
			_image.Dispose();
			_image = null;
		}
		base.Dispose(disposing);
	}

	public void Track()
	{
		if (_gallery.TrackingIndex != _imageIndex)
		{
			_gallery.SetTrackingIndex(_imageIndex, bringIntoView: false);
		}
	}

	public void Untrack()
	{
		if (_gallery.TrackingIndex == _imageIndex)
		{
			_gallery.SetTrackingIndex(-1, bringIntoView: false);
		}
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		PaletteState elementState = ElementState;
		if (_gallery.TrackingIndex == _imageIndex)
		{
			switch (elementState)
			{
			case PaletteState.Normal:
				ElementState = PaletteState.Tracking;
				break;
			case PaletteState.CheckedNormal:
				ElementState = PaletteState.CheckedTracking;
				break;
			}
		}
		base.Render(context);
		ElementState = elementState;
	}

	public virtual Image GetImage(PaletteState state)
	{
		if (_image == null && _imageList != null && _imageIndex >= 0)
		{
			_image = _imageList.Images[_imageIndex];
		}
		return _image;
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

	private void OnItemClick(object sender, MouseEventArgs e)
	{
		_gallery.SelectedIndex = _imageIndex;
	}
}
