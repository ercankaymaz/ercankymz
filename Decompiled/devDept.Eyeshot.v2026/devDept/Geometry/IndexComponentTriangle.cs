using System;

namespace devDept.Geometry;

public class IndexComponentTriangle : ICloneable
{
	public int N1;

	public int N2;

	public int N3;

	public IndexComponentTriangle(int n1, int n2, int n3)
	{
		N1 = n1;
		N2 = n2;
		N3 = n3;
	}

	protected IndexComponentTriangle(IndexComponentTriangle another)
	{
		N1 = another.N1;
		N2 = another.N2;
		N3 = another.N3;
	}

	public object Clone()
	{
		return new IndexComponentTriangle(this);
	}
}
