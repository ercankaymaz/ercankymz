using System;
using System.Drawing;
using System.Drawing.Text;

namespace ComponentFactory.Krypton.Toolkit;

public class GraphicsTextHint : GlobalId, IDisposable
{
	private Graphics _graphics;

	private TextRenderingHint _textHint;

	public GraphicsTextHint(Graphics graphics, TextRenderingHint textHint)
	{
		_graphics = graphics;
		_textHint = _graphics.TextRenderingHint;
		_graphics.TextRenderingHint = textHint;
	}

	public void Dispose()
	{
		if (_graphics != null)
		{
			try
			{
				_graphics.TextRenderingHint = _textHint;
			}
			catch
			{
			}
		}
	}
}
