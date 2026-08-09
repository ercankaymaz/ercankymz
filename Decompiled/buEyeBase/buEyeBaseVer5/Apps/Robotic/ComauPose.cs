using System;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class ComauPose : RobotPose
{
	public ComauPose(Point3D position, EulerAngles orientation)
		: base(position, orientation)
	{
	}

	public override string ToString()
	{
		return $"X{Position.X:F3} Y{Position.Y:F3} Z{Position.Z:F3} A{Orientation.Roll:F3} B{Orientation.Pitch:F3} C{Orientation.Yaw:F3}";
	}

	public string ToComauProgram(string pointName = "P", int pointNumber = 1)
	{
		return $"POINT {pointName}{pointNumber:00}\n" + $"  X = {Position.X:F1}\n" + $"  Y = {Position.Y:F1}\n" + $"  Z = {Position.Z:F1}\n" + $"  A = {Orientation.Roll:F3}\n" + $"  B = {Orientation.Pitch:F3}\n" + $"  C = {Orientation.Yaw:F3}\n" + "  S = 100\n  T = 0\nEND";
	}
}
