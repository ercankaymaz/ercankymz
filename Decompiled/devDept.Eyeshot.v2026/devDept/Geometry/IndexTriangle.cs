using System;
using System.Collections.Generic;
using System.ComponentModel;
using devDept.Geometry.Converters;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
[TypeConverter(typeof(IndexTriangleConverter))]
public class IndexTriangle : IndexLine, IEquatable<IndexTriangle>
{
	public int V3;

	public new int this[int i]
	{
		get
		{
			return i switch
			{
				0 => V1, 
				1 => V2, 
				_ => V3, 
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
			}
		}
	}

	public IndexTriangle()
	{
	}

	public IndexTriangle(int v1, int v2, int v3)
		: base(v1, v2)
	{
		V3 = v3;
	}

	protected IndexTriangle(IndexTriangle another)
		: base(another)
	{
		V3 = another.V3;
	}

	public override object Clone()
	{
		return new IndexTriangle(this);
	}

	public new int[] ToArray()
	{
		return new int[3] { V1, V2, V3 };
	}

	public double Quality(IList<Point3D> vertices)
	{
		Point2D point2D = vertices[V1];
		Point2D point2D2 = vertices[V2];
		Point2D point2D3 = vertices[V3];
		double num = Point2D.Distance(point2D, point2D2);
		double num2 = Point2D.Distance(point2D2, point2D3);
		double num3 = Point2D.Distance(point2D3, point2D);
		return (num2 + num3 - num) * (num3 + num - num2) * (num + num2 - num3) / (num * num2 * num3);
	}

	public bool Equals(IndexTriangle other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (Equals((IndexLine)other))
		{
			return other.V3 == V3;
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
		if (!(obj is IndexTriangle))
		{
			return false;
		}
		return Equals((IndexTriangle)obj);
	}

	public override int GetHashCode()
	{
		return (base.GetHashCode() * 397) ^ V3;
	}

	public override bool WouldContainDuplicates(IReadOnlyList<int> mappings)
	{
		if (!base.WouldContainDuplicates(mappings) && mappings[V2] != mappings[V3])
		{
			return mappings[V1] == mappings[V3];
		}
		return true;
	}

	public override void Reindex(IReadOnlyList<int> mappings)
	{
		base.Reindex(mappings);
		V3 = mappings[V3];
	}

	public static bool operator ==(IndexTriangle left, IndexTriangle right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(IndexTriangle left, IndexTriangle right)
	{
		return !object.Equals(left, right);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985861), V1, V2, V3);
	}

	public int GetThirdVertex(int v1, int v2)
	{
		if (V1 != v1 && V1 != v2)
		{
			return V1;
		}
		if (V2 != v1 && V2 != v2)
		{
			return V2;
		}
		return V3;
	}

	public void ReplaceVertexIndex(int oldVertex, int newVertex)
	{
		if (V1 == oldVertex)
		{
			V1 = newVertex;
		}
		else if (V2 == oldVertex)
		{
			V2 = newVertex;
		}
		else
		{
			V3 = newVertex;
		}
	}

	public override IndexLineSurrogate ConvertToSurrogate()
	{
		return new IndexTriangleSurrogate(this);
	}
}
