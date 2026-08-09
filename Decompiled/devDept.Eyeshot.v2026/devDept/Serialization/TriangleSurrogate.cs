using System.Diagnostics;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class TriangleSurrogate : EntitySurrogate
{
	internal GTriangle Primitive;

	public Point3D[] Vertices;

	public Vector3D Normal;

	public byte VisibleEdgeFlag;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D[] _0023_003DzME2BuaSnJsM4mEn84A_003D_003D;

	public TriangleSurrogate(Triangle triangle)
		: base(triangle)
	{
	}

	protected internal Point3D[] GetVertices()
	{
		if (_0023_003DzME2BuaSnJsM4mEn84A_003D_003D == null)
		{
			_0023_003DzME2BuaSnJsM4mEn84A_003D_003D = ((!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version)) ? Vertices : new Point3D[3] { Primitive.V1, Primitive.V2, Primitive.V3 });
		}
		return _0023_003DzME2BuaSnJsM4mEn84A_003D_003D;
	}

	protected override Entity ConvertToObject()
	{
		Triangle triangle = new Triangle(this);
		CopyDataToObject(triangle);
		return triangle;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		Triangle triangle = (Triangle)entity;
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			triangle.Normal = Primitive.Normal;
		}
		else
		{
			triangle.Normal = Normal;
		}
		triangle.VisibleEdgeFlag = VisibleEdgeFlag;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Triangle triangle = (Triangle)entity;
		Vertices = triangle.Vertices;
		Normal = triangle.Normal;
		VisibleEdgeFlag = triangle.VisibleEdgeFlag;
		base.CopyDataFromObject(entity);
	}
}
