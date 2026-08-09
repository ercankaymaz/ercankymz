using System.Collections.Generic;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class IndexQuad : IndexTriangle
{
	public int V4;

	public new int this[int i]
	{
		get
		{
			return i switch
			{
				0 => V1, 
				1 => V2, 
				2 => V3, 
				_ => V4, 
			};
		}
		set
		{
			switch (i)
			{
			case 0:
				V1 = value;
				break;
			case 1:
				V2 = value;
				break;
			case 2:
				V3 = value;
				break;
			default:
				V4 = value;
				break;
			}
		}
	}

	public IndexQuad()
	{
	}

	public IndexQuad(int v1, int v2, int v3, int v4)
		: base(v1, v2, v3)
	{
		V4 = v4;
	}

	protected IndexQuad(IndexQuad another)
		: base(another)
	{
		V4 = another.V4;
	}

	public override object Clone()
	{
		return new IndexQuad(this);
	}

	public override bool Equals(object obj)
	{
		if (obj is IndexQuad other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(IndexQuad other)
	{
		if (Equals((IndexTriangle)other))
		{
			return V4 == other.V4;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode() ^ V4.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988079), V1, V2, V3, V4);
	}

	public new int[] ToArray()
	{
		return new int[4] { V1, V2, V3, V4 };
	}

	public override bool WouldContainDuplicates(IReadOnlyList<int> mappings)
	{
		if (!base.WouldContainDuplicates(mappings) && mappings[V1] != mappings[V4] && mappings[V2] != mappings[V4])
		{
			return mappings[V3] == mappings[V4];
		}
		return true;
	}

	public override void Reindex(IReadOnlyList<int> mappings)
	{
		base.Reindex(mappings);
		V4 = mappings[V4];
	}
}
