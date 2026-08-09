using System.Collections.Generic;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

internal class GSolidSurrogate : GEntitySurrogate
{
	internal byte BRepMode;

	public TextureMappingData TextureMapping;

	public List<GSolid.Portion> Portions;

	public double SmoothingAngle;

	public GSolidSurrogate(GSolid gSolid)
		: base(gSolid)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GSolid gSolid = new GSolid();
		CopyDataToObject(gSolid);
		return gSolid;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		if (entity is GSolid gSolid)
		{
			gSolid.BRepMode = (Solid.brepType)BRepMode;
			gSolid.TextureMapping = TextureMapping;
			gSolid.Portions = Portions;
			gSolid.SmoothingAngle = SmoothingAngle;
		}
		base.CopyDataToObject(entity);
	}
}
