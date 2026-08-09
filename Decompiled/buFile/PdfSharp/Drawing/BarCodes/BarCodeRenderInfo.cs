namespace PdfSharp.Drawing.BarCodes;

internal class BarCodeRenderInfo
{
	public XGraphics Gfx;

	public XBrush Brush;

	public XFont Font;

	public XPoint Position;

	public double BarHeight;

	public XPoint CurrPos;

	public int CurrPosInString;

	public double ThinBarWidth;

	public BarCodeRenderInfo(XGraphics gfx, XBrush brush, XFont font, XPoint position)
	{
		Gfx = gfx;
		Brush = brush;
		Font = font;
		Position = position;
	}
}
