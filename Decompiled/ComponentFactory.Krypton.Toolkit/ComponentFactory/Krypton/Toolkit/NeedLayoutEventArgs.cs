using System;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class NeedLayoutEventArgs : EventArgs
{
	private bool _needLayout;

	private Rectangle _invalidRect;

	public bool NeedLayout => _needLayout;

	public Rectangle InvalidRect => _invalidRect;

	public NeedLayoutEventArgs(bool needLayout)
		: this(needLayout, Rectangle.Empty)
	{
	}

	public NeedLayoutEventArgs(bool needLayout, Rectangle invalidRect)
	{
		_needLayout = needLayout;
		_invalidRect = invalidRect;
	}
}
