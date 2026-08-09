using System;
using System.Collections.Generic;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Robotic;

public class buRoboticCalc
{
	public static RoboticSettings varRoboticSettings = new RoboticSettings();

	public static RoboticRuntimeSettings varRoboticRunSettings = new RoboticRuntimeSettings();

	public buRoboticCalc()
	{
		if (!buVector5.smethod_0("buRobotic"))
		{
			throw new RegisterException("buRobotic");
		}
	}

	public bool DevideToolPath(RobotPose PrePos, RobotPose NextPos, int Count, ref List<RobotPose> Devided)
	{
		try
		{
			if (Count > 1)
			{
				List<Point3D> Values = new List<Point3D>();
				List<Point3D> Values2 = new List<Point3D>();
				List<Vector3D> Values3 = new List<Vector3D>();
				List<Vector3D> Values4 = new List<Vector3D>();
				List<EulerAngles> Values5 = new List<EulerAngles>();
				List<PlaneAngles> Values6 = new List<PlaneAngles>();
				buNumeric5.DevideMinMaxValueByNumber(PrePos.Position, NextPos.Position, Count, ref Values);
				buNumeric5.DevideMinMaxValueByNumber(PrePos.PositionNoTool, NextPos.PositionNoTool, Count, ref Values2);
				buNumeric5.DevideMinMaxValueByNumber(PrePos.IJKVector, NextPos.IJKVector, Count, ref Values3);
				buNumeric5.DevideMinMaxValueByNumber(PrePos.DirectionVector, NextPos.DirectionVector, Count, ref Values4);
				buNumeric5.DevideMinMaxValueByNumber(PrePos.Orientation, NextPos.Orientation, Count, ref Values5);
				buNumeric5.DevideMinMaxValueByNumber(PrePos.PlaneAngle, NextPos.PlaneAngle, Count, ref Values6);
				if (Devided == null)
				{
					Devided = new List<RobotPose>();
				}
				Devided.Clear();
				for (int i = 0; i <= Values.Count - 1; i++)
				{
					RobotPose robotPose = new RobotPose(Values[i], Values5[i], Values3[i]);
					robotPose.PositionNoTool = new Point3D(Values2[i].X, Values2[i].Y, Values2[i].Z);
					robotPose.DirectionVector = new Vector3D(Values4[i].X, Values4[i].Y, Values4[i].Z);
					robotPose.PlaneAngle = new PlaneAngles(Values6[i].A, Values6[i].B, Values6[i].C);
					Devided.Add(robotPose);
				}
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
