// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortSettings : buSerilization5
{
  public ProjectionModeType Projection;
  public DisplayModeType DisplayMode;
  public OriginIconType OrigineIcon;
  public Color BottomColor;

  public SortSettings(Point3D refPnt, int Indx, double domainVal)
  {
    ((ViewportSettings) this).refPoint = new Point3D();
    ((ViewportSettings) this).Index = -1;
    ((ViewportSettings) this).DomainValue = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ViewportSettings) this).refPoint = new Point3D(refPnt.X, refPnt.Y, refPnt.Z);
    ((ViewportSettings) this).Index = Indx;
    ((ViewportSettings) this).DomainValue = domainVal;
  }

  public SortSettings(PointAndIndex data)
  {
    ((ViewportSettings) this).refPoint = new Point3D();
    ((ViewportSettings) this).Index = -1;
    ((ViewportSettings) this).DomainValue = 0.0;
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
}
