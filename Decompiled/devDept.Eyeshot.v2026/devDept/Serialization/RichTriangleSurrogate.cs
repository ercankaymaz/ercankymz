using devDept.Geometry;

namespace devDept.Serialization;

public class RichTriangleSurrogate : IndexTriangleSurrogate
{
	public int T1;

	public int T2;

	public int T3;

	public RichTriangleSurrogate(RichTriangle richTriangle)
		: base(richTriangle)
	{
	}

	protected override IndexLine ConvertToObject()
	{
		return new RichTriangle(V1, V2, V3, T1, T2, T3);
	}

	protected override void CopyDataFromObject(IndexLine indexLine)
	{
		RichTriangle richTriangle = indexLine as RichTriangle;
		T1 = richTriangle.T1;
		T2 = richTriangle.T2;
		T3 = richTriangle.T3;
		base.CopyDataFromObject((IndexLine)richTriangle);
	}
}
