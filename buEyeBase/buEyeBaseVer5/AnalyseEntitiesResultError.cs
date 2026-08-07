// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.AnalyseEntitiesResultError
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class AnalyseEntitiesResultError : buSerilization5
{
  public int CamSelectedCount;
  public bool CamSelectable;
  public string CamPlungeAxis;
  public string CamLeaveAxis;
  public double CamSpeed;
  public double PlungeSpeed;
  public double SpindleSpeed;

  public abstract void m000206();

  public AnalyseEntitiesResultError()
  {
    ((EntityDataSet) this).StartPoint = new Point3D();
    ((EntityDataSet) this).Width = 0.0;
    ((EntityDataSet) this).Height = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public AnalyseEntitiesResultError(Rectangle2D data)
  {
    ((EntityDataSet) this).StartPoint = new Point3D();
    ((EntityDataSet) this).Width = 0.0;
    ((EntityDataSet) this).Height = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((EntityDataSet) this).StartPoint = new Point3D(((EntityDataSet) data).StartPoint.X, ((EntityDataSet) data).StartPoint.Y, ((EntityDataSet) data).StartPoint.Z);
    ((EntityDataSet) this).Width = ((EntityDataSet) data).Width;
    ((EntityDataSet) this).Height = ((EntityDataSet) data).Height;
  }
}
