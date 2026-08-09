using System;

namespace PdfSharp.Drawing.BarCodes;

public class CodeDataMatrix : MatrixCode
{
	private int _quietZone;

	public int QuietZone
	{
		get
		{
			return _quietZone;
		}
		set
		{
			_quietZone = value;
		}
	}

	public CodeDataMatrix()
		: this("", "", 26, 26, 0, XSize.Empty)
	{
	}

	public CodeDataMatrix(string code, int length)
		: this(code, "", length, length, 0, XSize.Empty)
	{
	}

	public CodeDataMatrix(string code, int length, XSize size)
		: this(code, "", length, length, 0, size)
	{
	}

	public CodeDataMatrix(string code, DataMatrixEncoding dmEncoding, int length, XSize size)
		: this(code, CreateEncoding(dmEncoding, code.Length), length, length, 0, size)
	{
	}

	public CodeDataMatrix(string code, int rows, int columns)
		: this(code, "", rows, columns, 0, XSize.Empty)
	{
	}

	public CodeDataMatrix(string code, int rows, int columns, XSize size)
		: this(code, "", rows, columns, 0, size)
	{
	}

	public CodeDataMatrix(string code, DataMatrixEncoding dmEncoding, int rows, int columns, XSize size)
		: this(code, CreateEncoding(dmEncoding, code.Length), rows, columns, 0, size)
	{
	}

	public CodeDataMatrix(string code, int rows, int columns, int quietZone)
		: this(code, "", rows, columns, quietZone, XSize.Empty)
	{
	}

	public CodeDataMatrix(string code, string encoding, int rows, int columns, int quietZone, XSize size)
		: base(code, encoding, rows, columns, size)
	{
		QuietZone = quietZone;
	}

	public void SetEncoding(DataMatrixEncoding dmEncoding)
	{
		base.Encoding = CreateEncoding(dmEncoding, base.Text.Length);
	}

	private static string CreateEncoding(DataMatrixEncoding dmEncoding, int length)
	{
		string result = "";
		switch (dmEncoding)
		{
		case DataMatrixEncoding.Ascii:
			result = new string('a', length);
			break;
		case DataMatrixEncoding.C40:
			result = new string('c', length);
			break;
		case DataMatrixEncoding.Text:
			result = new string('t', length);
			break;
		case DataMatrixEncoding.X12:
			result = new string('x', length);
			break;
		case DataMatrixEncoding.EDIFACT:
			result = new string('e', length);
			break;
		case DataMatrixEncoding.Base256:
			result = new string('b', length);
			break;
		}
		return result;
	}

	protected internal override void Render(XGraphics gfx, XBrush brush, XPoint position)
	{
		XGraphicsState state = gfx.Save();
		switch (base.Direction)
		{
		case CodeDirection.RightToLeft:
			gfx.RotateAtTransform(180.0, position);
			break;
		case CodeDirection.TopToBottom:
			gfx.RotateAtTransform(90.0, position);
			break;
		case CodeDirection.BottomToTop:
			gfx.RotateAtTransform(-90.0, position);
			break;
		}
		XPoint xPoint = position + CodeBase.CalcDistance(base.Anchor, AnchorType.TopLeft, base.Size);
		if (base.MatrixImage == null)
		{
			base.MatrixImage = DataMatrixImage.GenerateMatrixImage(base.Text, base.Encoding, base.Rows, base.Columns);
		}
		if (QuietZone > 0)
		{
			XSize xSize = new XSize(base.Size.Width, base.Size.Height);
			xSize.Width = xSize.Width / (double)(base.Columns + 2 * QuietZone) * (double)base.Columns;
			xSize.Height = xSize.Height / (double)(base.Rows + 2 * QuietZone) * (double)base.Rows;
			XPoint xPoint2 = new XPoint(xPoint.X, xPoint.Y);
			xPoint2.X += base.Size.Width / (double)(base.Columns + 2 * QuietZone) * (double)QuietZone;
			xPoint2.Y += base.Size.Height / (double)(base.Rows + 2 * QuietZone) * (double)QuietZone;
			gfx.DrawRectangle(XBrushes.White, xPoint.X, xPoint.Y, base.Size.Width, base.Size.Height);
			gfx.DrawImage(base.MatrixImage, xPoint2.X, xPoint2.Y, xSize.Width, xSize.Height);
		}
		else
		{
			gfx.DrawImage(base.MatrixImage, xPoint.X, xPoint.Y, base.Size.Width, base.Size.Height);
		}
		gfx.Restore(state);
	}

	protected override void CheckCode(string text)
	{
		if (text == null)
		{
			throw new ArgumentNullException("text");
		}
		DataMatrixImage dataMatrixImage = new DataMatrixImage(base.Text, base.Encoding, base.Rows, base.Columns);
		dataMatrixImage.Iec16022Ecc200(base.Columns, base.Rows, base.Encoding, base.Text.Length, base.Text, 0, 0, 0);
	}
}
