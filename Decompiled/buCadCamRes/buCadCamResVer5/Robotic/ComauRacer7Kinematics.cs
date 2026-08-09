using System;
using buEyeBaseVer5.Apps.Robotic;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.Robotic;

public class ComauRacer7Kinematics
{
	public static class RobotSpecs
	{
		public const double MaxReach = 1700.0;

		public const double Payload = 7.0;

		public static readonly double[] JointLimits = new double[6] { 360.0, 130.0, 158.0, 360.0, 130.0, 360.0 };
	}

	public static class ComauConventions
	{
		public const EulerSequence eulerSequence = EulerSequence.ZYZ;

		public static readonly Vector3DD WorldBase = new Vector3DD(0.0, 0.0, 0.0);
	}

	public static RobotPose CalculateComauPose(Point3D position, Vector3DD approachVector, Vector3DD orientationVector = null)
	{
		Vector3DD vector3DD = approachVector.Normalize();
		Vector3DD vector3DD3;
		Vector3DD vector3DD2;
		if (orientationVector == null)
		{
			vector3DD2 = Class5.smethod_76(vector3DD);
			vector3DD3 = Vector3DD.Cross(vector3DD, vector3DD2).Normalize();
		}
		else
		{
			vector3DD2 = orientationVector.Normalize();
			vector3DD3 = Vector3DD.Cross(vector3DD, vector3DD2).Normalize();
			vector3DD2 = Vector3DD.Cross(vector3DD3, vector3DD).Normalize();
		}
		double[,] double_ = Class5.smethod_53(vector3DD2, vector3DD3, vector3DD);
		EulerAngles orientation = Class5.smethod_135(double_);
		return new RobotPose(position, orientation);
	}

	public static string ToComauCommand(RobotPose pose, string moveType = "PTP", double speed = 100.0)
	{
		return $"{moveType} X{pose.Position.X:F1} Y{pose.Position.Y:F1} Z{pose.Position.Z:F1} " + $"A{pose.Orientation.Roll:F3} B{pose.Orientation.Pitch:F3} C{pose.Orientation.Yaw:F3} " + $"S{speed}";
	}

	public static double[] CalculateJointAngles(RobotPose pose, double[] dhParams = null)
	{
		double[] double_ = dhParams ?? new double[24]
		{
			350.0, 0.0, 0.0, 0.0, 1150.0, -90.0, 0.0, 0.0, 140.0, 90.0,
			0.0, 0.0, 0.0, -90.0, 1150.0, 0.0, 0.0, 90.0, 0.0, 0.0,
			0.0, 0.0, 235.0, 0.0
		};
		return Class5.smethod_117(double_, pose);
	}

	public static bool CheckJointLimits(double[] jointAngles)
	{
		for (int i = 0; i < jointAngles.Length && i < RobotSpecs.JointLimits.Length; i++)
		{
			if (Math.Abs(jointAngles[i]) > RobotSpecs.JointLimits[i])
			{
				return false;
			}
		}
		return true;
	}
}
