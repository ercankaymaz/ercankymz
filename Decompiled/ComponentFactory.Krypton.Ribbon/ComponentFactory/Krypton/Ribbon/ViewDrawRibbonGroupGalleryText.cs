#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupGalleryText : ViewLeaf, IContentValues
{
	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupGallery _ribbonGallery;

	private RibbonGroupNormalDisabledTextToContent _contentProvider;

	private IDisposable _memento;

	private bool _firstText;

	private int _heightExtra;

	private Size _preferredSize;

	private Rectangle _displayRect;

	private int _dirtyPaletteSize;

	private int _dirtyPaletteLayout;

	private PaletteState _cacheState;

	public ViewDrawRibbonGroupGalleryText(KryptonRibbon ribbon, KryptonRibbonGroupGallery ribbonGallery, bool firstText)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonGallery != null);
		_ribbon = ribbon;
		_ribbonGallery = ribbonGallery;
		_firstText = firstText;
		_contentProvider = new RibbonGroupNormalDisabledTextToContent(ribbon.StateCommon.RibbonGeneral, ribbon.StateNormal.RibbonGroupButtonText, ribbon.StateDisabled.RibbonGroupButtonText);
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupGalleryText:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _memento != null)
		{
			_memento.Dispose();
			_memento = null;
		}
		base.Dispose(disposing);
	}

	public void MakeDirty()
	{
		_dirtyPaletteSize = 0;
		_dirtyPaletteLayout = 0;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (_cacheState != State)
		{
			MakeDirty();
			_cacheState = State;
		}
		if (_ribbon.DirtyPaletteCounter != _dirtyPaletteSize)
		{
			_preferredSize = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _contentProvider, this, VisualOrientation.Top, State, composition: false);
			_heightExtra = (_ribbon.CalculatedValues.DrawFontHeight - _ribbon.CalculatedValues.RawFontHeight) * 2;
			_preferredSize.Height -= _heightExtra;
			if (string.IsNullOrEmpty(GetShortText()))
			{
				_preferredSize.Width = 0;
			}
			_dirtyPaletteSize = _ribbon.DirtyPaletteCounter;
		}
		return _preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		if (_cacheState != State)
		{
			MakeDirty();
			_cacheState = State;
		}
		if (_displayRect != ClientRectangle || _ribbon.DirtyPaletteCounter != _dirtyPaletteLayout)
		{
			if (_memento != null)
			{
				_memento.Dispose();
				_memento = null;
			}
			Rectangle clientRectangle = ClientRectangle;
			clientRectangle.Height += _heightExtra;
			clientRectangle.Y -= _heightExtra / 2;
			_memento = context.Renderer.RenderStandardContent.LayoutContent(context, clientRectangle, _contentProvider, this, VisualOrientation.Top, PaletteState.Normal, composition: false);
			_displayRect = ClientRectangle;
			_dirtyPaletteLayout = _ribbon.DirtyPaletteCounter;
		}
	}

	public override void RenderBefore(RenderContext context)
	{
		Rectangle clientRectangle = ClientRectangle;
		clientRectangle.Height += _heightExtra;
		clientRectangle.Y -= _heightExtra / 2;
		if (_memento != null)
		{
			context.Renderer.RenderStandardContent.DrawContent(context, clientRectangle, _contentProvider, _memento, VisualOrientation.Top, State, composition: false, allowFocusRect: true);
		}
	}

	public Image GetImage(PaletteState state)
	{
		return null;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		if (_firstText)
		{
			return _ribbonGallery.TextLine1;
		}
		if (!string.IsNullOrEmpty(_ribbonGallery.TextLine2))
		{
			return _ribbonGallery.TextLine2;
		}
		return " ";
	}

	public string GetLongText()
	{
		return string.Empty;
	}
}
