using System;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ColorEventArgs : EventArgs
{
	private Color _color;

	public Color Color => _color;

	public ColorEventArgs(Color color)
	{
		_color = color;
	}
}
