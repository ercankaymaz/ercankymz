namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal struct ClipperIntRect(long l, long t, long r, long b)
{
	public long Left = l;

	public long Top = t;

	public long Right = r;

	public long Bottom = b;

	public ClipperIntRect(ClipperIntRect ir)
		: this(ir.Left, ir.Top, ir.Right, ir.Bottom)
	{
	}
}
