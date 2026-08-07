// Decompiled with JetBrains decompiler
// Type: buClass.OsnapProps
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class OsnapProps : buSerilization
{
  public bool Snap = false;
  public bool Osnap = false;
  public bool Ortho = false;
  public bool Track = false;
  public bool Over = false;
  public bool Alingment = false;
  public bool OrthoAuto = false;
  public bool LimitedDistance = false;
  public double LimitedValue = 5.0;
  public double CatchResolution = 10.0;
  public double OverResolution = 5.0;
  public double OrthoAutoAngle = 3.0;
  public double TrackPerpendicularAngleLimit = 3.0;
  public Vec3D SnapDistance = new Vec3D(50.0, 50.0, 0.0);
  public bool OsnapPoint = true;
  public bool OsnapOnlyStartEndPoint = true;
  public bool OsnapMiddle = false;
  public bool OsnapOutside = false;
  public bool OsnapIntersection = false;
  public bool OsnapVertice = false;
  public bool OsnapCenter = true;
  public bool OsnapBoxSize = false;
  public bool OsnapZeroPoint = true;
  public bool OsnapControlPoints = true;
  public bool OsnapBrep = false;
  public bool OsnapEntities = true;
  public int TrackCatchTime = 1000;
  public bool ConstantPlaneEnable = true;
  public double ConstantPlaneHeight = 0.0;
  public static List<string> Captions = new List<string>();

  public OsnapProps()
  {
  }

  public OsnapProps(OsnapProps data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
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

  public override string ToString()
  {
    return $"Osnap : {this.Osnap.ToString()} ;  Snap : {this.Snap.ToString()}";
  }
}
