using System;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class RichTriangle : IndexTriangle, ITriangleSupportsTextureCoords
{
	public int T1 { get; set; }

	public int T2 { get; set; }

	public int T3 { get; set; }

	public RichTriangle()
	{
	}

	public RichTriangle(int v1, int v2, int v3)
		: base(v1, v2, v3)
	{
	}

	public RichTriangle(int v1, int v2, int v3, int t1, int t2, int t3)
		: base(v1, v2, v3)
	{
		T1 = t1;
		T2 = t2;
		T3 = t3;
	}

	protected RichTriangle(RichTriangle another)
		: base(another)
	{
		T1 = another.T1;
		T2 = another.T2;
		T3 = another.T3;
	}

	public override object Clone()
	{
		return new RichTriangle(this);
	}

	public override IndexLineSurrogate ConvertToSurrogate()
	{
		return new RichTriangleSurrogate(this);
	}
}
