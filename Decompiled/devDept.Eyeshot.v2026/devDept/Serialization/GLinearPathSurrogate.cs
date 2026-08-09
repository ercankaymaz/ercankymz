using devDept.Geometry;

namespace devDept.Serialization;

internal class GLinearPathSurrogate : GEntitySurrogate
{
	public Point3D[] Vertices;

	public GLinearPathSurrogate(GLinearPath gLinearPath)
		: base(gLinearPath)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GLinearPath gLinearPath = new GLinearPath();
		CopyDataToObject(gLinearPath);
		return gLinearPath;
	}

	protected override void CopyDataToObject(GEntity gEntity)
	{
		((GLinearPath)gEntity).Vertices = Vertices;
		base.CopyDataToObject(gEntity);
	}
}
