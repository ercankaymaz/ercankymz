using devDept.Geometry;

namespace devDept.Serialization;

public class ColorTriangleSurrogate : IndexTriangleSurrogate
{
	public byte R;

	public byte G;

	public byte B;

	public ColorTriangleSurrogate(ColorTriangle colorTriangle)
		: base(colorTriangle)
	{
	}

	protected override IndexLine ConvertToObject()
	{
		return new ColorTriangle(V1, V2, V3, R, G, B);
	}

	protected override void CopyDataFromObject(IndexLine indexLine)
	{
		ColorTriangle colorTriangle = indexLine as ColorTriangle;
		R = colorTriangle.R;
		G = colorTriangle.G;
		B = colorTriangle.B;
		base.CopyDataFromObject(indexLine);
	}
}
