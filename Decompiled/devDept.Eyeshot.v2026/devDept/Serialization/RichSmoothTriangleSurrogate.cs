using devDept.Geometry;

namespace devDept.Serialization;

public class RichSmoothTriangleSurrogate : SmoothTriangleSurrogate
{
	public int T1;

	public int T2;

	public int T3;

	public RichSmoothTriangleSurrogate(RichSmoothTriangle richSmoothTriangle)
		: base(richSmoothTriangle)
	{
	}

	protected override IndexLine ConvertToObject()
	{
		return new RichSmoothTriangle(V1, V2, V3, N1, N2, N3, T1, T2, T3);
	}

	protected override void CopyDataFromObject(IndexLine indexLine)
	{
		RichSmoothTriangle richSmoothTriangle = indexLine as RichSmoothTriangle;
		T1 = richSmoothTriangle.T1;
		T2 = richSmoothTriangle.T2;
		T3 = richSmoothTriangle.T3;
		base.CopyDataFromObject(indexLine);
	}
}
