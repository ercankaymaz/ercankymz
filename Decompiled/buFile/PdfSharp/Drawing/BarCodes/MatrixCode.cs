namespace PdfSharp.Drawing.BarCodes;

public abstract class MatrixCode : CodeBase
{
	private string _encoding;

	private int _columns;

	private int _rows;

	private XImage _matrixImage;

	public string Encoding
	{
		get
		{
			return _encoding;
		}
		set
		{
			_encoding = value;
			_matrixImage = null;
		}
	}

	public int Columns
	{
		get
		{
			return _columns;
		}
		set
		{
			_columns = value;
			_matrixImage = null;
		}
	}

	public int Rows
	{
		get
		{
			return _rows;
		}
		set
		{
			_rows = value;
			_matrixImage = null;
		}
	}

	public new string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
			_matrixImage = null;
		}
	}

	internal XImage MatrixImage
	{
		get
		{
			return _matrixImage;
		}
		set
		{
			_matrixImage = value;
		}
	}

	public MatrixCode(string text, string encoding, int rows, int columns, XSize size)
		: base(text, size, CodeDirection.LeftToRight)
	{
		_encoding = encoding;
		if (string.IsNullOrEmpty(_encoding))
		{
			_encoding = new string('a', Text.Length);
		}
		if (columns < rows)
		{
			_rows = columns;
			_columns = rows;
		}
		else
		{
			_columns = columns;
			_rows = rows;
		}
		Text = text;
	}

	protected internal abstract void Render(XGraphics gfx, XBrush brush, XPoint center);

	protected override void CheckCode(string text)
	{
	}
}
