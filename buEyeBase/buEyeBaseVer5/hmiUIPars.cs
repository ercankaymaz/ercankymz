// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.hmiUIPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class hmiUIPars : buSerilization
{
  public static double Width;
  public static double Height;
  public static string Command;
  public static string Info;
  public static double Rad;
  public static double MajorRad;
  public static double MinorRad;
  public static double Ratio;
  public static Point3D Center;
  public static byte f0008A9;
  public List<Point3D> PointsList;
  public List<IndexTriangle> TriangleIndexList;
  public List<Vector3D> Normals;
  public autodeskVersionType Version;
  public double Deviation;
  public bool ExplodeViews;
  public string Password;

  public hmiUIPars()
  {
    ((GCodeConverter) this).Index = -1;
    ((GCodePoint5) this).SubIndex = -1;
    ((GCodePoint5) this).SelectedEntity = (Entity) null;
    ((GCodePoint5) this).SelectedSubEntity = (Entity) null;
    ((GCodePoint5) this).SelectedLinearPaths = (List<Entity>) null;
    ((GCodePoint5) this).SelectedVertices = new List<List<Point3D>>();
    ((GCodePoint5) this).BoxMin = new Point3D();
    ((GCodePoint5) this).BoxMax = new Point3D();
    ((GCodePoint5) this).pntClick = new Point3D();
    ((GCodePoint5) this).pntClickEntityOver = (Point3D) null;
    ((GCodePoint5) this).EntitiesBoxPointList = new List<Point3D>();
    ((GCodePoint5) this).AlingPoints = (SelectionAlingmentPoints) new hmiUIBasicPars();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public hmiUIPars(int index)
  {
    ((GCodeConverter) this).Index = -1;
    ((GCodePoint5) this).SubIndex = -1;
    ((GCodePoint5) this).SelectedEntity = (Entity) null;
    ((GCodePoint5) this).SelectedSubEntity = (Entity) null;
    ((GCodePoint5) this).SelectedLinearPaths = (List<Entity>) null;
    ((GCodePoint5) this).SelectedVertices = new List<List<Point3D>>();
    ((GCodePoint5) this).BoxMin = new Point3D();
    ((GCodePoint5) this).BoxMax = new Point3D();
    ((GCodePoint5) this).pntClick = new Point3D();
    ((GCodePoint5) this).pntClickEntityOver = (Point3D) null;
    ((GCodePoint5) this).EntitiesBoxPointList = new List<Point3D>();
    ((GCodePoint5) this).AlingPoints = (SelectionAlingmentPoints) new hmiUIBasicPars();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((GCodeConverter) this).Index = index;
  }
}
