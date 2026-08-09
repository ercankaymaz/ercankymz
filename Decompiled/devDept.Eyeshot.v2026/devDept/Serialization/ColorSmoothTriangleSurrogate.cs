using devDept.Geometry;

namespace devDept.Serialization;

public class ColorSmoothTriangleSurrogate : SmoothTriangleSurrogate
{
	public byte R;

	public byte G;

	public byte B;

	public ColorSmoothTriangleSurrogate(ColorSmoothTriangle colorSmoothTriangle)
		: base(colorSmoothTriangle)
	{
	}

	protected override IndexLine ConvertToObject()
	{
		return new ColorSmoothTriangle(V1, V2, V3, N1, N2, N3, R, G, B);
	}

	protected override void CopyDataFromObject(IndexLine indexLine)
	{
		ColorSmoothTriangle colorSmoothTriangle = indexLine as ColorSmoothTriangle;
		R = colorSmoothTriangle.R;
		G = colorSmoothTriangle.G;
		B = colorSmoothTriangle.B;
		base.CopyDataFromObject(indexLine);
	}
}
