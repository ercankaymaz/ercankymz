using System;

namespace devDept.Geometry;

public class IndexColorTriangle : ICloneable
{
	public byte Alpha;

	public byte R;

	public byte G;

	public byte B;

	public IndexColorTriangle(byte r, byte g, byte b)
	{
		Alpha = byte.MaxValue;
		R = r;
		G = g;
		B = b;
	}

	public IndexColorTriangle(byte alpha, byte r, byte g, byte b)
	{
		Alpha = alpha;
		R = r;
		G = g;
		B = b;
	}

	protected IndexColorTriangle(IndexColorTriangle another)
	{
		Alpha = another.Alpha;
		R = another.R;
		G = another.G;
		B = another.B;
	}

	public object Clone()
	{
		return new IndexColorTriangle(this);
	}
}
