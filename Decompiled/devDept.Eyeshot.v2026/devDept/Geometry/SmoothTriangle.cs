using System;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class SmoothTriangle : IndexTriangle, ITriangleSupportsNormals
{
	public int N1 { get; set; }

	public int N2 { get; set; }

	public int N3 { get; set; }

	public SmoothTriangle()
	{
	}

	public SmoothTriangle(int v1, int v2, int v3)
		: base(v1, v2, v3)
	{
	}

	public SmoothTriangle(int v1, int v2, int v3, int n1, int n2, int n3)
		: base(v1, v2, v3)
	{
		N1 = n1;
		N2 = n2;
		N3 = n3;
	}

	protected SmoothTriangle(SmoothTriangle another)
		: base(another)
	{
		N1 = another.N1;
		N2 = another.N2;
		N3 = another.N3;
	}

	public override object Clone()
	{
		return new SmoothTriangle(this);
	}

	public override IndexLineSurrogate ConvertToSurrogate()
	{
		return new SmoothTriangleSurrogate(this);
	}
}
