using buEyeBaseVer5.Apps.Robotic;

namespace buCadCamResVer5.Robotic;

public class ComauFormats
{
	public static string ToPgfFormat(RobotPose pose, string pointName = "P1")
	{
		return $"POINT {pointName}\r\n  X = {pose.Position.X:F1}\r\n  Y = {pose.Position.Y:F1} \r\n  Z = {pose.Position.Z:F1}\r\n  A = {pose.Orientation.Roll:F3}\r\n  B = {pose.Orientation.Pitch:F3}\r\n  C = {pose.Orientation.Yaw:F3}\r\n  S = 100\r\n  T = 0\r\nEND";
	}

	public static string ToJointPositionFormat(double[] joints, string positionName = "JP1")
	{
		return $"JOINTPOS {positionName}\r\n  J1 = {joints[0]:F3}\r\n  J2 = {joints[1]:F3}\r\n  J3 = {joints[2]:F3}\r\n  J4 = {joints[3]:F3}\r\n  J5 = {joints[4]:F3}\r\n  J6 = {joints[5]:F3}\r\nEND";
	}
}
