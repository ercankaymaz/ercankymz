// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.hmiUIBasicSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class hmiUIBasicSettings : buSerilization5
{
  public static double StartLen;
  public static double EndLen;

  public override string ToString()
  {
    string str = "Null";
    if (((WriteDxfDwgPropeties) this).refPlane != (Plane) null)
      str = "refPlane: " + ((WriteDxfDwgPropeties) this).refPlane.ToString();
    return str;
  }

  public abstract void m00033B();

  public hmiUIBasicSettings()
  {
    ((GCodeConverter) this).entitiesPoint = (List<buEntity>) null;
    ((GCodeConverter) this).entitiesCurve = (List<buEntity>) null;
    ((GCodeConverter) this).entitiesText = (List<buEntity>) null;
    ((GCodeConverter) this).entitiesSolid = (List<buEntity>) null;
    ((GCodeConverter) this).entitiesDimension = (List<buEntity>) null;
    ((GCodeConverter) this).entitiesImage = (List<buEntity>) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((GCodeConverter) this).entitiesPoint = new List<buEntity>();
    ((GCodeConverter) this).entitiesCurve = new List<buEntity>();
    ((GCodeConverter) this).entitiesText = new List<buEntity>();
    ((GCodeConverter) this).entitiesSolid = new List<buEntity>();
    ((GCodeConverter) this).entitiesDimension = new List<buEntity>();
    ((GCodeConverter) this).entitiesImage = new List<buEntity>();
  }

  public hmiUIBasicSettings()
  {
    ((GCodeConverter) this).Selections = new List<SelectionEntity>();
    ((GCodeConverter) this).SelectionBoxMin = new Point3D();
    ((GCodeConverter) this).SelectionBoxMid = new Point3D();
    ((GCodeConverter) this).SelectionBoxMax = new Point3D();
    ((GCodeConverter) this).ClickList = new List<Point3D>();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
