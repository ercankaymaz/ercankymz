using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class RenderDragDockingData
{
	private int _showTotal;

	private BoolFlags31 _flags;

	private Rectangle[] _rects;

	private Size _windowSize;

	public bool ShowBack => _showTotal > 1;

	public bool ShowLeft
	{
		get
		{
			return _flags.AreFlagsSet(2);
		}
		set
		{
			UpdateShowFlag(value, 2);
		}
	}

	public bool ShowRight
	{
		get
		{
			return _flags.AreFlagsSet(4);
		}
		set
		{
			UpdateShowFlag(value, 4);
		}
	}

	public bool ShowTop
	{
		get
		{
			return _flags.AreFlagsSet(8);
		}
		set
		{
			UpdateShowFlag(value, 8);
		}
	}

	public bool ShowBottom
	{
		get
		{
			return _flags.AreFlagsSet(16);
		}
		set
		{
			UpdateShowFlag(value, 16);
		}
	}

	public bool ShowMiddle
	{
		get
		{
			return _flags.AreFlagsSet(32);
		}
		set
		{
			UpdateShowFlag(value, 32);
		}
	}

	public int ActiveFlags => _flags.Flags & 0x7C0;

	public bool ActiveLeft
	{
		get
		{
			return _flags.AreFlagsSet(64);
		}
		set
		{
			UpdateFlag(value, 64);
		}
	}

	public bool ActiveRight
	{
		get
		{
			return _flags.AreFlagsSet(128);
		}
		set
		{
			UpdateFlag(value, 128);
		}
	}

	public bool ActiveTop
	{
		get
		{
			return _flags.AreFlagsSet(256);
		}
		set
		{
			UpdateFlag(value, 256);
		}
	}

	public bool ActiveBottom
	{
		get
		{
			return _flags.AreFlagsSet(512);
		}
		set
		{
			UpdateFlag(value, 512);
		}
	}

	public bool ActiveMiddle
	{
		get
		{
			return _flags.AreFlagsSet(1024);
		}
		set
		{
			UpdateFlag(value, 1024);
		}
	}

	public bool AnyActive => ActiveFlags != 0;

	public Rectangle RectLeft
	{
		get
		{
			return _rects[0];
		}
		set
		{
			_rects[0] = value;
		}
	}

	public Rectangle RectRight
	{
		get
		{
			return _rects[1];
		}
		set
		{
			_rects[1] = value;
		}
	}

	public Rectangle RectTop
	{
		get
		{
			return _rects[2];
		}
		set
		{
			_rects[2] = value;
		}
	}

	public Rectangle RectBottom
	{
		get
		{
			return _rects[3];
		}
		set
		{
			_rects[3] = value;
		}
	}

	public Rectangle RectMiddle
	{
		get
		{
			return _rects[4];
		}
		set
		{
			_rects[4] = value;
		}
	}

	public Size DockWindowSize
	{
		get
		{
			return _windowSize;
		}
		set
		{
			_windowSize = value;
		}
	}

	public RenderDragDockingData(bool showLeft, bool showRight, bool showTop, bool showBottom, bool showMiddle)
	{
		_flags = default(BoolFlags31);
		ShowLeft = showLeft;
		ShowRight = showRight;
		ShowTop = showTop;
		ShowBottom = showBottom;
		ShowMiddle = showMiddle;
		_windowSize = Size.Empty;
		_rects = new Rectangle[5];
		for (int i = 0; i < _rects.Length; i++)
		{
			_rects[i] = Rectangle.Empty;
		}
	}

	public void ClearActive()
	{
		_flags.ClearFlags(1984);
	}

	private void UpdateFlag(bool value, int flag)
	{
		if (value)
		{
			_flags.SetFlags(flag);
		}
		else
		{
			_flags.ClearFlags(flag);
		}
	}

	private void UpdateShowFlag(bool value, int flag)
	{
		if (value != _flags.AreFlagsSet(flag))
		{
			if (value)
			{
				_flags.SetFlags(flag);
				_showTotal++;
			}
			else
			{
				_flags.ClearFlags(flag);
				_showTotal--;
			}
		}
	}
}
