#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class GraphicsHint : GlobalId, IDisposable
{
	private Graphics _graphics;

	private SmoothingMode _smoothingMode;

	public GraphicsHint(Graphics graphics, PaletteGraphicsHint hint)
	{
		_graphics = graphics;
		_smoothingMode = _graphics.SmoothingMode;
		switch (hint)
		{
		case PaletteGraphicsHint.None:
			_graphics.SmoothingMode = SmoothingMode.None;
			break;
		case PaletteGraphicsHint.AntiAlias:
			_graphics.SmoothingMode = SmoothingMode.AntiAlias;
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
	}

	public void Dispose()
	{
		if (_graphics != null)
		{
			try
			{
				_graphics.SmoothingMode = _smoothingMode;
			}
			catch
			{
			}
		}
	}
}
