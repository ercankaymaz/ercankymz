using System.Diagnostics;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class QuadSurrogate : EntitySurrogate
{
	internal GQuad Primitive;

	public Point3D[] Vertices;

	public Vector3D Normal;

	public byte VisibleEdgeFlag;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D[] _0023_003DzME2BuaSnJsM4mEn84A_003D_003D;

	public QuadSurrogate(Quad quad)
		: base(quad)
	{
	}

	protected internal Point3D[] GetVertices()
	{
		if (_0023_003DzME2BuaSnJsM4mEn84A_003D_003D == null)
		{
			_0023_003DzME2BuaSnJsM4mEn84A_003D_003D = ((!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version)) ? Vertices : new Point3D[4] { Primitive.V1, Primitive.V2, Primitive.V3, Primitive.V4 });
		}
		return _0023_003DzME2BuaSnJsM4mEn84A_003D_003D;
	}

	protected override Entity ConvertToObject()
	{
		Quad quad = new Quad(this);
		CopyDataToObject(quad);
		return quad;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		Quad quad = (Quad)entity;
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			quad._0023_003Dz2h5Pusvr_xOb(Primitive.Normal);
		}
		else
		{
			quad._0023_003Dz2h5Pusvr_xOb(Normal);
		}
		quad.VisibleEdgeFlag = VisibleEdgeFlag;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Quad quad = (Quad)entity;
		Vertices = quad.Vertices;
		Normal = quad.Normal;
		VisibleEdgeFlag = quad.VisibleEdgeFlag;
		base.CopyDataFromObject(entity);
	}
}
