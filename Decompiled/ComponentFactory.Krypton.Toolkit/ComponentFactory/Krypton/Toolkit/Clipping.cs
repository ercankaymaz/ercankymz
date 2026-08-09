using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class Clipping : GlobalId, IDisposable
{
	private Graphics _graphics;

	private Region _previousRegion;

	private Region _newRegion;

	public Clipping(Graphics graphics, GraphicsPath path)
		: this(graphics, path, exclude: false)
	{
	}

	public Clipping(Graphics graphics, GraphicsPath path, bool exclude)
	{
		_graphics = graphics;
		_previousRegion = _graphics.Clip;
		_newRegion = _previousRegion.Clone();
		if (exclude)
		{
			_newRegion.Exclude(path);
		}
		else
		{
			_newRegion.Intersect(path);
		}
		_graphics.Clip = _newRegion;
	}

	public Clipping(Graphics graphics, Region region)
		: this(graphics, region, exclude: false)
	{
	}

	public Clipping(Graphics graphics, Region region, bool exclude)
	{
		_graphics = graphics;
		_previousRegion = _graphics.Clip;
		_newRegion = _previousRegion.Clone();
		if (exclude)
		{
			_newRegion.Exclude(region);
		}
		else
		{
			_newRegion.Intersect(region);
		}
		_graphics.Clip = _newRegion;
	}

	public Clipping(Graphics graphics, Rectangle rect)
		: this(graphics, rect, exclude: false)
	{
	}

	public Clipping(Graphics graphics, Rectangle rect, bool exclude)
	{
		_graphics = graphics;
		_previousRegion = _graphics.Clip;
		_newRegion = _previousRegion.Clone();
		if (exclude)
		{
			_newRegion.Exclude(rect);
		}
		else
		{
			_newRegion.Intersect(rect);
		}
		_graphics.Clip = _newRegion;
	}

	public void Dispose()
	{
		if (_graphics != null)
		{
			try
			{
				_graphics.Clip = _previousRegion;
			}
			catch
			{
			}
		}
		if (_newRegion != null)
		{
			try
			{
				_newRegion.Dispose();
				_newRegion = null;
			}
			catch
			{
			}
		}
	}
}
