// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.SewingDevideOptions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingDevideOptions : buSerilization5
{
  public double BlockDepth;
  public Entity entityDisk;
  public Entity entityBlock;
  public static byte f003C6F;
  public string pathLRAFiles;
  public int SimulationIntervalMs;
  public bool CollisionCheck;
  public static List<string> Captions;
  public static byte f003C74;
  public bool ShowOperationInfo;

  public void CreateDoorEntityFromMaterial(MaterialBase5 Mat, ref Entity entDoor)
  {
    List<Point3D> points = new List<Point3D>();
    points.Add(new Point3D(0.0, 0.0, ((SortResult) Mat).Size.Depth));
    points.Add(new Point3D(0.0, ((SortResult) Mat).Size.Height, ((SortResult) Mat).Size.Depth));
    Point3D point3D1 = new Point3D(0.0, ((SortResult) Mat).Size.Height, 0.0);
    if (((SortResult) Mat).BackAngle != 0.0)
    {
      double num = Math.Tan(buConversion.DegreeToRadian(((SortResult) Mat).BackAngle)) * ((SortResult) Mat).Size.Depth;
      point3D1 = new Point3D(0.0, ((SortResult) Mat).Size.Height - num, 0.0);
    }
    points.Add(point3D1);
    Point3D point3D2 = new Point3D(0.0, 0.0, 0.0);
    if (((SortResult) Mat).FrontAngle != 0.0)
      point3D2 = new Point3D(0.0, Math.Tan(buConversion.DegreeToRadian(((SortResult) Mat).FrontAngle)) * ((SortResult) Mat).Size.Depth, 0.0);
    points.Add(point3D2);
    points.Add(new Point3D(0.0, 0.0, ((SortResult) Mat).Size.Depth));
    devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((ICurve) new CompositeCurve((IEnumerable<ICurve>) new List<ICurve>()
    {
      (ICurve) new LinearPath((ICollection<Point3D>) points)
    }), Plane.YZ);
    entDoor = (Entity) region.ExtrudeAsBrep(((SortResult) Mat).Size.Width, 0.0, 0.0);
    entDoor.Color = ((SortOptions) Mat).Display.SkinColor;
    entDoor.ColorMethod = colorMethodType.byEntity;
  }

  public void CreateCaseEntityFromMaterial(
    SizeObject Case1,
    SizeObject Case2,
    Color clr,
    double Space,
    ref Entity entCase1,
    ref Entity entCase2)
  {
    devDept.Eyeshot.Entities.Region region1 = new devDept.Eyeshot.Entities.Region((ICurve) new LinearPath((ICollection<Point3D>) new List<Point3D>()
    {
      new Point3D(0.0, 0.0, 0.0),
      new Point3D(Case1.Width, 0.0, 0.0),
      new Point3D(Case1.Width, Case1.Height, 0.0),
      new Point3D(0.0, Case1.Height, 0.0),
      new Point3D(0.0, 0.0, 0.0)
    }), Plane.XY);
    entCase1 = (Entity) region1.ExtrudeAsBrep(Case1.Depth, 0.0, 0.0);
    entCase1.Color = clr;
    entCase1.ColorMethod = colorMethodType.byEntity;
    entCase1.Regen(0.1);
    devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region((ICurve) new LinearPath((ICollection<Point3D>) new List<Point3D>()
    {
      new Point3D(0.0, 0.0, 0.0),
      new Point3D(Case2.Width, 0.0, 0.0),
      new Point3D(Case2.Width, Case2.Height, 0.0),
      new Point3D(0.0, Case2.Height, 0.0),
      new Point3D(0.0, 0.0, 0.0)
    }), Plane.XY);
    entCase2 = (Entity) region2.ExtrudeAsBrep(Case2.Depth, 0.0, 0.0);
    entCase2.Color = clr;
    entCase2.ColorMethod = colorMethodType.byEntity;
    entCase2.Translate(0.0, Case1.Height + Space);
    entCase2.Regen(0.1);
  }
}
