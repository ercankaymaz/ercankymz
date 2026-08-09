namespace PdfSharp.Drawing.BarCodes;

public class CodeOmr(string text, XSize size, CodeDirection direction) : BarCode(text, size, direction)
{
	private bool _synchronizeCode;

	private double _makerDistance = 12.0;

	private double _makerThickness = 1.0;

	public bool SynchronizeCode
	{
		get
		{
			return _synchronizeCode;
		}
		set
		{
			_synchronizeCode = value;
		}
	}

	public double MakerDistance
	{
		get
		{
			return _makerDistance;
		}
		set
		{
			_makerDistance = value;
		}
	}

	public double MakerThickness
	{
		get
		{
			return _makerThickness;
		}
		set
		{
			_makerThickness = value;
		}
	}

	protected internal override void Render(XGraphics gfx, XBrush brush, XFont font, XPoint position)
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
		XPoint xPoint = position - CodeBase.CalcDistance(AnchorType.TopLeft, base.Anchor, base.Size);
		uint.TryParse(base.Text, out var result);
		result |= 1;
		_synchronizeCode = true;
		if (_synchronizeCode)
		{
			XRect rect = new XRect(xPoint.X, xPoint.Y, _makerThickness, base.Size.Height);
			gfx.DrawRectangle(brush, rect);
			xPoint.X += 2.0 * _makerDistance;
		}
		for (int i = 0; i < 32; i++)
		{
			if ((result & 1) == 1)
			{
				XRect rect2 = new XRect(xPoint.X + (double)i * _makerDistance, xPoint.Y, _makerThickness, base.Size.Height);
				gfx.DrawRectangle(brush, rect2);
			}
			result >>= 1;
		}
		gfx.Restore(state);
	}

	protected override void CheckCode(string text)
	{
	}
}
