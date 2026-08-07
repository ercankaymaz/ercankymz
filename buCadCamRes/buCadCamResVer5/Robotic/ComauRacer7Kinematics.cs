// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Robotic.ComauRacer7Kinematics
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buEyeBaseVer5.Apps.Robotic;
using devDept.Geometry;
using ns8;
using System;

#nullable disable
namespace buCadCamResVer5.Robotic;

public class ComauRacer7Kinematics
{
  public static RobotPose CalculateComauPose(
    Point3D position,
    Vector3DD approachVector,
    Vector3DD orientationVector = null)
  {
    Vector3DD vector3Dd1 = approachVector.Normalize();
    Vector3DD vector3Dd2;
    Vector3DD vector3Dd3;
    if (orientationVector != null)
    {
      Vector3DD b = orientationVector.Normalize();
      vector3Dd2 = Vector3DD.Cross(vector3Dd1, b).Normalize();
      vector3Dd3 = Vector3DD.Cross(vector3Dd2, vector3Dd1).Normalize();
    }
    else
    {
      vector3Dd3 = Class5.smethod_76(vector3Dd1);
      vector3Dd2 = Vector3DD.Cross(vector3Dd1, vector3Dd3).Normalize();
    }
    EulerAngles orientation = Class5.smethod_135(Class5.smethod_53(vector3Dd3, vector3Dd2, vector3Dd1));
    return new RobotPose(position, orientation);
  }

  public static string ToComauCommand(RobotPose pose, string moveType = "PTP", double speed = 100.0)
  {
    return $"{moveType} X{pose.Position.X:F1} Y{pose.Position.Y:F1} Z{pose.Position.Z:F1} " + $"A{pose.Orientation.Roll:F3} B{pose.Orientation.Pitch:F3} C{pose.Orientation.Yaw:F3} " + $"S{speed}";
  }

  public static double[] CalculateJointAngles(RobotPose pose, double[] dhParams = null)
  {
    double[] double_0 = dhParams;
    if (double_0 == null)
      double_0 = new double[24]
      {
        350.0,
        0.0,
        0.0,
        0.0,
        1150.0,
        -90.0,
        0.0,
        0.0,
        140.0,
        90.0,
        0.0,
        0.0,
        0.0,
        -90.0,
        1150.0,
        0.0,
        0.0,
        90.0,
        0.0,
        0.0,
        0.0,
        0.0,
        235.0,
        0.0
      };
    return Class5.smethod_117(double_0, pose);
  }

  public static bool CheckJointLimits(double[] jointAngles)
  {
    bool flag;
    for (int index = 0; (index >= jointAngles.Length ? 0 : (index < ComauRacer7Kinematics.RobotSpecs.JointLimits.Length ? 1 : 0)) != 0; ++index)
    {
      if (Math.Abs(jointAngles[index]) > ComauRacer7Kinematics.RobotSpecs.JointLimits[index])
      {
        flag = false;
        goto label_6;
      }
    }
    flag = true;
label_6:
    return flag;
  }

  public static class RobotSpecs
  {
    public const double MaxReach = 1700.0;
    public const double Payload = 7.0;
    public static readonly double[] JointLimits = new double[6]
    {
      360.0,
      130.0,
      158.0,
      360.0,
      130.0,
      360.0
    };
  }

  public static class ComauConventions
  {
    public const EulerSequence eulerSequence = EulerSequence.ZYZ;
    public static readonly Vector3DD WorldBase = new Vector3DD(0.0, 0.0, 0.0);
  }
}
