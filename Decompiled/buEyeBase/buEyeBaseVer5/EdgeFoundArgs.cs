using System;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class EdgeFoundArgs : buSerilization5
{
	public double FoundAngle = 0.0;

	public bool Outside = false;

	public Point3D pntPick = new Point3D();

	public override string ToString()
	{
		return "FoundAngle: " + FoundAngle + " - Outside: " + Outside + " - pntPick: " + pntPick.ToString();
	}
}
