using devDept.Geometry;

namespace buEyeBaseVer5;

public class SortPointClickData : buSerilization5
{
	public bool isPointOnEntity = false;

	public int SelectedIndex = 0;

	public int PreviousSelectedIndex = -1;

	public int FoundCount = 0;

	public Point3D CatchPoint = null;

	public Point3D PreCatchPoint = null;

	public Point3D IntersectionPoint = null;
}
