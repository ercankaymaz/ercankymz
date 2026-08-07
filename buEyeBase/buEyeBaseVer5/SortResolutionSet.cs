// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortResolutionSet
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortResolutionSet : buSerilization5
{
  public Point3D Position;
  public double Diameter;
  public double Depth;
  public static byte f0006E0;
  public bool Solid;

  public override string ToString()
  {
    return "Entities Count: " + ((FlatViewSettings) this).Entities.Count.ToString();
  }

  public abstract void m0002AC();
}
