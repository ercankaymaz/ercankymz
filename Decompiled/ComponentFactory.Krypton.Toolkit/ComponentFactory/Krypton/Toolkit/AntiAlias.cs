using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class AntiAlias : GlobalId, IDisposable
{
	private Graphics _g;

	private SmoothingMode _old;

	public AntiAlias(Graphics g)
	{
		_g = g;
		_old = _g.SmoothingMode;
		_g.SmoothingMode = SmoothingMode.AntiAlias;
	}

	public void Dispose()
	{
		if (_g != null)
		{
			try
			{
				_g.SmoothingMode = _old;
			}
			catch
			{
			}
		}
	}
}
