using System;
using buEyeBaseVer5.Apps.Robotic;

namespace buCadCamResVer5.Robotic;

public class RobotUtilities
{
	public static double[] ToRobotFormat(EulerAngles angles, bool useRadians = false)
	{
		if (!useRadians)
		{
			return new double[3] { angles.Roll, angles.Pitch, angles.Yaw };
		}
		return new double[3]
		{
			angles.Roll * Math.PI / 180.0,
			angles.Pitch * Math.PI / 180.0,
			angles.Yaw * Math.PI / 180.0
		};
	}

	public static double[] CalculateJointAngles(RobotPose pose, double[] linkLengths)
	{
		double x = pose.Position.X;
		double y = pose.Position.Y;
		double num = Math.Atan2(y, x);
		Math.Sqrt(x * x + y * y);
		return new double[6]
		{
			num * 180.0 / Math.PI,
			pose.Orientation.Pitch,
			pose.Orientation.Roll,
			pose.Orientation.Yaw,
			0.0,
			0.0
		};
	}

	public static string ToRobotCommand(RobotPose pose, string moveType = "LIN")
	{
		return $"{moveType} X{pose.Position.X:F3} Y{pose.Position.Y:F3} Z{pose.Position.Z:F3} " + $"A{pose.Orientation.Roll:F3} B{pose.Orientation.Pitch:F3} C{pose.Orientation.Yaw:F3}";
	}
}
