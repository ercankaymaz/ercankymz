using System;

namespace Zen.Barcode;

[Serializable]
public class BarcodeMetrics1d : BarcodeMetrics
{
	private int _minWidth;

	private int _maxWidth;

	private int _minHeight;

	private int _maxHeight;

	private int? _interGlyphSpacing;

	private bool _renderVertically;

	public int MinWidth
	{
		get
		{
			return _minWidth;
		}
		set
		{
			_minWidth = value;
		}
	}

	public int MaxWidth
	{
		get
		{
			return _maxWidth;
		}
		set
		{
			_maxWidth = value;
		}
	}

	public int MinHeight
	{
		get
		{
			return _minHeight;
		}
		set
		{
			_minHeight = value;
		}
	}

	public int MaxHeight
	{
		get
		{
			return _maxHeight;
		}
		set
		{
			_maxHeight = value;
		}
	}

	public int? InterGlyphSpacing
	{
		get
		{
			return _interGlyphSpacing;
		}
		set
		{
			_interGlyphSpacing = value;
		}
	}

	public bool RenderVertically
	{
		get
		{
			return _renderVertically;
		}
		set
		{
			_renderVertically = value;
		}
	}

	public BarcodeMetrics1d()
	{
	}

	public BarcodeMetrics1d(int width, int height)
	{
		_minWidth = (_maxWidth = width);
		_minHeight = (_maxHeight = height);
	}

	public BarcodeMetrics1d(int minWidth, int maxWidth, int height)
	{
		_minWidth = minWidth;
		_maxWidth = maxWidth;
		_minHeight = (_maxHeight = height);
	}

	public BarcodeMetrics1d(int minWidth, int maxWidth, int minHeight, int maxHeight)
	{
		_minWidth = minWidth;
		_maxWidth = maxWidth;
		_minHeight = minHeight;
		_maxHeight = maxHeight;
	}
}
