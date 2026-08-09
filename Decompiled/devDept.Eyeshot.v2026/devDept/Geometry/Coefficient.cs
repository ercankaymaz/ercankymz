using System;

namespace devDept.Geometry;

public struct Coefficient(int position, double value) : IEquatable<Coefficient>
{
	public int Pos = position;

	public double Val = value;

	public bool Equals(Coefficient other)
	{
		return Pos == other.Pos;
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655299), Pos, Val);
	}
}
