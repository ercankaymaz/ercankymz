// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortCamData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortCamData : buSerilization5
{
  public Point3D BoxMaxPoint;

  public override string ToString()
  {
    return "Points Count: " + ((ViewportSettings) this).Points.Count.ToString();
  }

  public abstract void m0002A3();
}
