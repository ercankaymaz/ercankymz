using devDept.Eyeshot;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class MeasureItem
{
	public object Object = null;

	public string Explanation = "";

	public selectionFilterType Type = selectionFilterType.Face;

	public Point3D PointOverEntity = new Point3D();

	public Point3D BoxMin = new Point3D();

	public Point3D BoxMax = new Point3D();

	public MeasureItem()
	{
	}

	public MeasureItem(object obj, selectionFilterType type, Point3D pnt)
	{
		Object = obj;
		Type = type;
		PointOverEntity = new Point3D(pnt.X, pnt.Y, pnt.Z);
	}
}
