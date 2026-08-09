using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class ConicalSurfaceSurrogate : CylindricalSurfaceSurrogate
{
	public double HalfAngle;

	public Point3D Tip;

	public ConicalSurfaceSurrogate(ConicalSurface conicalSurf)
		: base(conicalSurf)
	{
	}

	protected internal double GetHalfAngle()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return HalfAngle;
		}
		return ((GConicalSurface)Primitive).HalfAngle;
	}

	protected internal Point3D GetTip()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Tip;
		}
		return ((GConicalSurface)Primitive).Tip;
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return base.ConvertToObject();
		}
		ConicalSurface conicalSurface = new ConicalSurface(this);
		CopyDataToObject(conicalSurface);
		return conicalSurface;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		ConicalSurface conicalSurface = (ConicalSurface)entity;
		HalfAngle = conicalSurface.HalfAngle;
		Tip = conicalSurface.Tip;
		base.CopyDataFromObject(entity);
	}
}
