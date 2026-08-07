// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.FindEntitiesGroupSettings
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
public class FindEntitiesGroupSettings : buSerilization5
{
  public buEntity Entity;
  public static byte f0008E3;
  public string X;
  public string Y;
  public string Z;

  public abstract void m000350();

  public FindEntitiesGroupSettings()
  {
  }

  static FindEntitiesGroupSettings()
  {
    hmiUISettings.Len = 0.0;
    hmiUISettings.Ang = 0.0;
    hmiUISettings.StartAng = 0.0;
    hmiUISettings.EndAng = 0.0;
    hmiUISettings.dX = 0.0;
    hmiUISettings.dY = 0.0;
    hmiUISettings.dZ = 0.0;
    hmiUIBasicSettings.StartLen = 0.0;
    hmiUIBasicSettings.EndLen = 0.0;
    hmiUIPars.Width = 0.0;
    hmiUIPars.Height = 0.0;
    hmiUIPars.Command = "";
    hmiUIPars.Info = "";
    hmiUIPars.Rad = 0.0;
    hmiUIPars.MajorRad = 0.0;
    hmiUIPars.MinorRad = 0.0;
    hmiUIPars.Ratio = 1.0;
    hmiUIPars.Center = new Point3D();
  }

  public FindEntitiesGroupSettings()
  {
    ((hmiUIPars) this).PointsList = new List<Point3D>();
    ((hmiUIPars) this).TriangleIndexList = new List<IndexTriangle>();
    ((hmiUIPars) this).Normals = new List<Vector3D>();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
