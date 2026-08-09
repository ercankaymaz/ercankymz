using devDept.Geometry;

namespace devDept.Serialization;

public class SmoothTriangleSurrogate : IndexTriangleSurrogate
{
	public int N1;

	public int N2;

	public int N3;

	public SmoothTriangleSurrogate(SmoothTriangle smoothTriangle)
		: base(smoothTriangle)
	{
	}

	protected override IndexLine ConvertToObject()
	{
		return new SmoothTriangle(V1, V2, V3, N1, N2, N3);
	}

	protected override void CopyDataFromObject(IndexLine indexLine)
	{
		SmoothTriangle smoothTriangle = indexLine as SmoothTriangle;
		N1 = smoothTriangle.N1;
		N2 = smoothTriangle.N2;
		N3 = smoothTriangle.N3;
		base.CopyDataFromObject(indexLine);
	}
}
