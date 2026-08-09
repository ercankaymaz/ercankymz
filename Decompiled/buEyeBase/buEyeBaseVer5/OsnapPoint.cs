using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class OsnapPoint : Point3D
{
	public osnapType Type = osnapType.None;

	public string EntName = "";

	public bool Enable = true;

	public string LayerName = "";

	public string OtherEntName = "";

	public OsnapPoint()
	{
		Type = osnapType.None;
	}

	public OsnapPoint(Point3D point3D, osnapType objectSnapType)
		: base(point3D.X, point3D.Y, point3D.Z)
	{
		Type = objectSnapType;
	}

	public OsnapPoint(Point3D point3D, osnapType objectSnapType, string entName, string layerName, string otherName)
		: base(point3D.X, point3D.Y, point3D.Z)
	{
		Type = objectSnapType;
		EntName = entName;
		LayerName = layerName;
		OtherEntName = otherName;
	}

	public override string ToString()
	{
		return base.ToString() + " | " + Type;
	}
}
