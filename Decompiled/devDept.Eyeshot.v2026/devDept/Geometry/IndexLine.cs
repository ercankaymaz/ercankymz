using System;
using System.Collections.Generic;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class IndexLine : ICloneable, IEquatable<IndexLine>, IIndexObject
{
	public int V1;

	public int V2;

	public int this[int i]
	{
		get
		{
			if (i == 0)
			{
				return V1;
			}
			return V2;
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
			}
		}
	}

	public IndexLine()
	{
	}

	public IndexLine(int v1, int v2)
	{
		V1 = v1;
		V2 = v2;
	}

	protected IndexLine(IndexLine another)
	{
		V1 = another.V1;
		V2 = another.V2;
	}

	public virtual object Clone()
	{
		return new IndexLine(this);
	}

	public int[] ToArray()
	{
		return new int[2] { V1, V2 };
	}

	public bool Equals(IndexLine other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (other.V1 == V1)
		{
			return other.V2 == V2;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (!(obj is IndexLine))
		{
			return false;
		}
		return Equals((IndexLine)obj);
	}

	public override int GetHashCode()
	{
		return (V1 * 397) ^ V2;
	}

	public static bool operator ==(IndexLine left, IndexLine right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(IndexLine left, IndexLine right)
	{
		return !object.Equals(left, right);
	}

	public virtual bool WouldContainDuplicates(IReadOnlyList<int> mappings)
	{
		return mappings[V1] == mappings[V2];
	}

	public virtual void Reindex(IReadOnlyList<int> mappings)
	{
		V1 = mappings[V1];
		V2 = mappings[V2];
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982525), V1, V2);
	}

	public virtual IndexLineSurrogate ConvertToSurrogate()
	{
		return new IndexLineSurrogate(this);
	}
}
