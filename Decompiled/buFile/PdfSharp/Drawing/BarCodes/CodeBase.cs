namespace PdfSharp.Drawing.BarCodes;

public abstract class CodeBase
{
	private struct Delta(int x, int y)
	{
		public readonly int X = x;

		public readonly int Y = y;
	}

	private XSize _size;

	private string _text;

	private AnchorType _anchor;

	private CodeDirection _direction;

	private static readonly Delta[,] Deltas = new Delta[9, 9]
	{
		{
			new Delta(0, 0),
			new Delta(1, 0),
			new Delta(2, 0),
			new Delta(0, 1),
			new Delta(1, 1),
			new Delta(2, 1),
			new Delta(0, 2),
			new Delta(1, 2),
			new Delta(2, 2)
		},
		{
			new Delta(-1, 0),
			new Delta(0, 0),
			new Delta(1, 0),
			new Delta(-1, 1),
			new Delta(0, 1),
			new Delta(1, 1),
			new Delta(-1, 2),
			new Delta(0, 2),
			new Delta(1, 2)
		},
		{
			new Delta(-2, 0),
			new Delta(-1, 0),
			new Delta(0, 0),
			new Delta(-2, 1),
			new Delta(-1, 1),
			new Delta(0, 1),
			new Delta(-2, 2),
			new Delta(-1, 2),
			new Delta(0, 2)
		},
		{
			new Delta(0, -1),
			new Delta(1, -1),
			new Delta(2, -1),
			new Delta(0, 0),
			new Delta(1, 0),
			new Delta(2, 0),
			new Delta(0, 1),
			new Delta(1, 1),
			new Delta(2, 1)
		},
		{
			new Delta(-1, -1),
			new Delta(0, -1),
			new Delta(1, -1),
			new Delta(-1, 0),
			new Delta(0, 0),
			new Delta(1, 0),
			new Delta(-1, 1),
			new Delta(0, 1),
			new Delta(1, 1)
		},
		{
			new Delta(-2, -1),
			new Delta(-1, -1),
			new Delta(0, -1),
			new Delta(-2, 0),
			new Delta(-1, 0),
			new Delta(0, 0),
			new Delta(-2, 1),
			new Delta(-1, 1),
			new Delta(0, 1)
		},
		{
			new Delta(0, -2),
			new Delta(1, -2),
			new Delta(2, -2),
			new Delta(0, -1),
			new Delta(1, -1),
			new Delta(2, -1),
			new Delta(0, 0),
			new Delta(1, 0),
			new Delta(2, 0)
		},
		{
			new Delta(-1, -2),
			new Delta(0, -2),
			new Delta(1, -2),
			new Delta(-1, -1),
			new Delta(0, -1),
			new Delta(1, -1),
			new Delta(-1, 0),
			new Delta(0, 0),
			new Delta(1, 0)
		},
		{
			new Delta(-2, -2),
			new Delta(-1, -2),
			new Delta(0, -2),
			new Delta(-2, -1),
			new Delta(-1, -1),
			new Delta(0, -1),
			new Delta(-2, 0),
			new Delta(-1, 0),
			new Delta(0, 0)
		}
	};

	public XSize Size
	{
		get
		{
			return _size;
		}
		set
		{
			_size = value;
		}
	}

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			CheckCode(value);
			_text = value;
		}
	}

	public AnchorType Anchor
	{
		get
		{
			return _anchor;
		}
		set
		{
			_anchor = value;
		}
	}

	public CodeDirection Direction
	{
		get
		{
			return _direction;
		}
		set
		{
			_direction = value;
		}
	}

	public CodeBase(string text, XSize size, CodeDirection direction)
	{
		_text = text;
		_size = size;
		_direction = direction;
	}

	protected abstract void CheckCode(string text);

	public static XVector CalcDistance(AnchorType oldType, AnchorType newType, XSize size)
	{
		if (oldType == newType)
		{
			return default(XVector);
		}
		Delta delta = Deltas[(int)oldType, (int)newType];
		return new XVector(size.Width / 2.0 * (double)delta.X, size.Height / 2.0 * (double)delta.Y);
	}
}
