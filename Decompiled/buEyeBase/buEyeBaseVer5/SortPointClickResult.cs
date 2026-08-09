using System;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class SortPointClickResult : buSerilization5
{
	public Point3D FirstPoint = new Point3D();

	public Point3D LastPoint = new Point3D();

	public SortingResultType ResultType = SortingResultType.None;
}
