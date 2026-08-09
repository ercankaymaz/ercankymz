using System;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class SortbuMostClosedResult : buSerilization5
{
	public int Sequence = -1;

	public Point3D pntFound = new Point3D();

	public StartEndType FoundLocation = StartEndType.Start;

	public double FoundDistance = 0.0;

	public bool isPointCatch = false;

	public bool isPointCatchAnyWay = false;

	public bool isPointCatchCamSelected = false;

	public Point3D pntCatch = new Point3D();

	public Point3D pntCatchCamSelected = new Point3D();
}
