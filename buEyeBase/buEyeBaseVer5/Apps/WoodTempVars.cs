// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.WoodTempVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class WoodTempVars
{
  public double VShapeAngleRoughSpindleSpeed;
  public double VShapeAngleFinishSpindleSpeed;
  public double VShapeAngleOffset;
  public bool VShapeAngleZigzag;
  public int VShapeAngleToolNo;
  public int VShapeAngleFinishCount;

  public void CreateNotch(
    CutterNotchType notchType,
    Point3D Position,
    double Length,
    double DirectionAngle,
    double Angle,
    ICurve baseEntity,
    ref List<Entity> notchEntities)
  {
    // ISSUE: unable to decompile the method.
  }

  public void RotateNotch(ref Entity refEntities)
  {
    refEntities.Rotate(buString5.DegreeToRadian(180.0), new Vector3D(0.0, 0.0, 1.0), ((buRollerBendCalc) refEntities.EntityData).get_infoBasePoint());
    refEntities.Regen(0.01);
  }
}
