// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Robotic.RobotKinematicsCalculator
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buEyeBaseVer5.Apps.Robotic;
using ns8;
using System;

#nullable disable
namespace buCadCamResVer5.Robotic;

public class RobotKinematicsCalculator
{
  public static EulerAngles CalculateEulerAngles(
    Vector3DD position,
    Vector3DD approachVector,
    Vector3DD orientationVector = null)
  {
    Vector3DD vector3Dd = approachVector.Normalize();
    Vector3DD a;
    Vector3DD b1;
    if (orientationVector != null)
    {
      Vector3DD b2 = orientationVector.Normalize();
      a = Vector3DD.Cross(vector3Dd, b2).Normalize();
      b1 = Vector3DD.Cross(a, vector3Dd).Normalize();
    }
    else
    {
      b1 = Math.Abs(vector3Dd.Z) <= 0.999 ? new Vector3DD(-vector3Dd.Y, vector3Dd.X, 0.0).Normalize() : new Vector3DD(1.0, 0.0, 0.0);
      a = Vector3DD.Cross(vector3Dd, b1).Normalize();
    }
    return Class5.smethod_133(new double[3, 3]
    {
      {
        b1.X,
        a.X,
        vector3Dd.X
      },
      {
        b1.Y,
        a.Y,
        vector3Dd.Y
      },
      {
        b1.Z,
        a.Z,
        vector3Dd.Z
      }
    });
  }

  public static EulerAngles CalculateBasicOrientation(Vector3DD approachVector)
  {
    Vector3DD vector3Dd = approachVector.Normalize();
    double pitch = Math.Asin(-vector3Dd.X) * 180.0 / Math.PI;
    return new EulerAngles(Math.Atan2(vector3Dd.Y, vector3Dd.Z) * 180.0 / Math.PI, pitch, 0.0);
  }
}
