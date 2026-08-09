using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class SolidSurrogate : EntitySurrogate
{
	internal GSolid Primitive;

	public byte BRepMode;

	public TextureMappingData TextureMapping;

	public List<Solid.Portion> Portions;

	public double SmoothingAngle;

	public bool UseInnerColors;

	public SolidSurrogate(Solid solid)
		: base(solid)
	{
	}

	internal Solid.brepType _0023_003DzavTT22ksPV_0024U()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return (Solid.brepType)BRepMode;
		}
		return Primitive.BRepMode;
	}

	protected internal TextureMappingData GetTextureMapping()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return TextureMapping;
		}
		return Primitive.TextureMapping;
	}

	internal List<Solid.Portion> _0023_003DzZIEWoy_6KiDwkpoZBg_003D_003D()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Portions;
		}
		return GEntity.CreateEntitiesFromPrimitives(Primitive.Portions).Cast<Solid.Portion>().ToList();
	}

	protected override Entity ConvertToObject()
	{
		Solid solid;
		if (base.Content == contentType.Tessellation)
		{
			solid = new Solid(_0023_003DzZIEWoy_6KiDwkpoZBg_003D_003D());
			CopyDataToObject(solid);
			Mesh mesh = solid.ConvertToMesh(0.0, 0.0, Mesh.natureType.Smooth, weld: false);
			CopyDataToObject(mesh);
			return mesh;
		}
		solid = new Solid(this);
		CopyDataToObject(solid);
		return solid;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is Solid solid)
		{
			if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
			{
				solid._0023_003DzfD12v8o3kSVM(Primitive.BRepMode);
				solid.textureMapping = Primitive.TextureMapping;
				solid.portions = GEntity.CreateEntitiesFromPrimitives(Primitive.Portions).Cast<Solid.Portion>().ToList();
				solid.smoothingAngle = Primitive.SmoothingAngle;
			}
			else
			{
				solid._0023_003DzfD12v8o3kSVM((Solid.brepType)BRepMode);
				solid.textureMapping = TextureMapping;
				solid.portions = Portions ?? new List<Solid.Portion>();
				solid.smoothingAngle = SmoothingAngle;
			}
			solid.UseInnerColors = UseInnerColors;
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Solid solid = (Solid)entity;
		BRepMode = (byte)solid._brepMode;
		TextureMapping = solid.TextureMapping;
		Portions = solid.Portions;
		SmoothingAngle = solid.SmoothingAngle;
		UseInnerColors = solid.UseInnerColors;
		base.CopyDataFromObject(entity);
	}
}
