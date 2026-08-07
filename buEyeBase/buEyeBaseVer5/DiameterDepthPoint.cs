// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.DiameterDepthPoint
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class DiameterDepthPoint : buSerilization5
{
  public bool ShowViewCube;
  public bool ShowToolBar;
  public bool ReverseMouseWheel;

  public DiameterDepthPoint()
  {
    ((ViewportSettings) this).refPoint = new Point3D();
    ((ViewportSettings) this).AngleMin = 0.0;
    ((ViewportSettings) this).AngleMax = 0.0;
    ((ViewportSettings) this).Index = -1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DiameterDepthPoint(Point3D pntRef, double AngMin, double AngMax, int Indx)
  {
    ((ViewportSettings) this).refPoint = new Point3D();
    ((ViewportSettings) this).AngleMin = 0.0;
    ((ViewportSettings) this).AngleMax = 0.0;
    ((ViewportSettings) this).Index = -1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ViewportSettings) this).Index = Indx;
    ((ViewportSettings) this).AngleMax = AngMax;
    ((ViewportSettings) this).AngleMin = AngMin;
    ((ViewportSettings) this).refPoint = new Point3D(pntRef.X, pntRef.Y, pntRef.Z);
  }

  public DiameterDepthPoint(PointAndAngleRange data)
  {
    ((ViewportSettings) this).refPoint = new Point3D();
    ((ViewportSettings) this).AngleMin = 0.0;
    ((ViewportSettings) this).AngleMax = 0.0;
    ((ViewportSettings) this).Index = -1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    ((ViewportSettings) this).refPoint = new Point3D(((ViewportSettings) data).refPoint.X, ((ViewportSettings) data).refPoint.Y, ((ViewportSettings) data).refPoint.Z);
  }

  public override string ToString()
  {
    return $"X: {((ViewportSettings) this).refPoint.X.ToString("f3")} Y: {((ViewportSettings) this).refPoint.Y.ToString("f3")} Min: {((ViewportSettings) this).AngleMin.ToString("f1")} Max: {((ViewportSettings) this).AngleMax.ToString("f1")} Index: {((ViewportSettings) this).Index.ToString("")}";
  }
}
