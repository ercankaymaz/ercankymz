using System;
using System.Drawing;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleCommandArgs
{
	public MarbleMotionCommands Cmd = MarbleMotionCommands.None;

	public Point3D pntMove = new Point3D();

	public Plane refPlane = null;

	public Point pntScreen = default(Point);
}
