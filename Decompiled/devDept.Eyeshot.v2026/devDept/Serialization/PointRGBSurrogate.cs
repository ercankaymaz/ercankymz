using devDept.Geometry;

namespace devDept.Serialization;

public class PointRGBSurrogate : Point3DSurrogate
{
	public byte R;

	public byte G;

	public byte B;

	public PointRGBSurrogate(PointRGB pointRgb)
		: base(pointRgb)
	{
	}

	protected override Point2D ConvertToObject()
	{
		return new PointRGB(X, Y, Z, R, G, B);
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		PointRGB pointRGB = p as PointRGB;
		R = pointRGB.R;
		G = pointRGB.G;
		B = pointRGB.B;
		base.CopyDataFromObject(p);
	}
}
