#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupTitle : ViewLeaf, IContentValues
{
	private KryptonRibbon _ribbon;

	private KryptonRibbonGroup _ribbonGroup;

	private RibbonGroupTextToContent _contentProvider;

	private IDisposable _memento;

	private int _height;

	private Rectangle _displayRect;

	private int _dirtyPaletteLayout;

	private PaletteState _cacheState;

	public IPaletteRibbonText PaletteRibbonGroup
	{
		get
		{
			return _contentProvider.PaletteRibbonGroup;
		}
		set
		{
			_contentProvider.PaletteRibbonGroup = value;
		}
	}

	public int Height
	{
		get
		{
			return _height;
		}
		set
		{
			_height = value;
		}
	}

	public ViewDrawRibbonGroupTitle(KryptonRibbon ribbon, KryptonRibbonGroup ribbonGroup)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonGroup != null);
		_ribbon = ribbon;
		_ribbonGroup = ribbonGroup;
		_contentProvider = new RibbonGroupTextToContent(ribbon.StateCommon.RibbonGeneral, ribbon.StateNormal.RibbonGroupNormalTitle);
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupTitle:" + base.Id;
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
		_dirtyPaletteLayout = 0;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return new Size(0, _height);
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
			_memento = context.Renderer.RenderStandardContent.LayoutContent(context, ClientRectangle, _contentProvider, this, VisualOrientation.Top, PaletteState.Normal, composition: false);
			_displayRect = ClientRectangle;
			_dirtyPaletteLayout = _ribbon.DirtyPaletteCounter;
		}
	}

	public override void RenderBefore(RenderContext context)
	{
		if (_memento != null)
		{
			context.Renderer.RenderStandardContent.DrawContent(context, ClientRectangle, _contentProvider, _memento, VisualOrientation.Top, PaletteState.Normal, composition: false, allowFocusRect: true);
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
		if (!string.IsNullOrEmpty(_ribbonGroup.TextLine2))
		{
			return _ribbonGroup.TextLine1 + " " + _ribbonGroup.TextLine2;
		}
		return _ribbonGroup.TextLine1;
	}

	public string GetLongText()
	{
		return string.Empty;
	}
}
