// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.WriteDxfDwgPropeties
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class WriteDxfDwgPropeties : buSerilization5
{
  public double OutsideOffset;
  public bool SilhouetteToPartEnd;
  public bool isVertical;
  public static byte f000848;
  public Plane refPlane;
  public Entity entityPlane;
  public Entity entityXVector;
  public Entity entityYVector;
  public Entity entityZVector;

  public override string ToString()
  {
    return $"{((ShapeRuntimeData) this).Index.ToString()} - Base: {((ShapeRuntimeData) this).BaseIndex.ToString()} - {((ShapeRuntimeData) this).Direction.ToString()} - {((ShapeRuntimeData) this).Entity.ToString()}";
  }

  public abstract void m0002FF();
}
