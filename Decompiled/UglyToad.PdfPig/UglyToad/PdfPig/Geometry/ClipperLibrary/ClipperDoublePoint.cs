namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal struct ClipperDoublePoint(double x, double y)
{
	public double X = x;

	public double Y = y;

	public ClipperDoublePoint(ClipperDoublePoint dp)
		: this(dp.X, dp.Y)
	{
	}

	public ClipperDoublePoint(ClipperIntPoint ip)
		: this(ip.X, ip.Y)
	{
	}
}
