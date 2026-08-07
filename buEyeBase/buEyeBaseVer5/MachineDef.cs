// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MachineDef
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class MachineDef : buSerilization5
{
  public static byte f000549;
  public bool isError;
  public List<AnalyseEntitiesResultError> ErrorList;
  public static byte f00054C;

  public MachineDef(Point3D startPoint, Point3D endPoint)
  {
    ((EntityDataSet) this).StartPoint = new Point3D();
    ((EntitiesCopySettings) this).EndPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((EntityDataSet) this).StartPoint = F_NotchEdit.ToPoint3D(startPoint);
    ((EntitiesCopySettings) this).EndPoint = F_NotchEdit.ToPoint3D(endPoint);
  }

  public MachineDef(Point3D startPoint, double dX, double dY)
  {
    ((EntityDataSet) this).StartPoint = new Point3D();
    ((EntitiesCopySettings) this).EndPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((EntityDataSet) this).StartPoint = F_NotchEdit.ToPoint3D(startPoint);
    ((EntitiesCopySettings) this).EndPoint = new Point3D(startPoint.X + dX, startPoint.Y + dY, startPoint.Z);
  }
}
