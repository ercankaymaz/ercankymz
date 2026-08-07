// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Robotic.RobotUtilities
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buEyeBaseVer5.Apps.Robotic;
using System;

#nullable disable
namespace buCadCamResVer5.Robotic;

public class RobotUtilities
{
  public static double[] ToRobotFormat(EulerAngles angles, bool useRadians = false)
  {
    double[] robotFormat;
    if (useRadians)
      robotFormat = new double[3]
      {
        angles.Roll * Math.PI / 180.0,
        angles.Pitch * Math.PI / 180.0,
        angles.Yaw * Math.PI / 180.0
      };
    else
      robotFormat = new double[3]
      {
        angles.Roll,
        angles.Pitch,
        angles.Yaw
      };
    return robotFormat;
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
