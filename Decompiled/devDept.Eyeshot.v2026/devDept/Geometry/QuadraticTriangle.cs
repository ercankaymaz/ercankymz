using System;

namespace devDept.Geometry;

[Serializable]
public class QuadraticTriangle : IndexTriangle
{
	public int V4;

	public int V5;

	public int V6;

	public QuadraticTriangle(int v1, int v2, int v3, int v4, int v5, int v6)
		: base(v1, v2, v3)
	{
		V4 = v4;
		V5 = v5;
		V6 = v6;
	}

	protected QuadraticTriangle(QuadraticTriangle another)
		: base(another)
	{
		V4 = another.V4;
		V5 = another.V5;
		V6 = another.V6;
	}

	public override object Clone()
	{
		return new QuadraticTriangle(this);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660055), V1, V2, V3, V4, V5, V6);
	}
}
