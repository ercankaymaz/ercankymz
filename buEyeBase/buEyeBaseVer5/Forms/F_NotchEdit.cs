// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_NotchEdit
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_NotchEdit : Form
{
  public double OperationTimeAsSec;
  public double QuickMoveTimeAsSec;
  public double TotalMCodeTimeAsSec;
  public double TotalLengthAsMeter;
  public double OperationLengthAsMeter;
  public double QuickMoveLengthAsMeter;
  public int NumberOfToolChange;
  public List<string> NoDefinedMCodes;
  public static byte f000A2C;
  public static buShape lastShape;
  public static buShape lastCut;
  public static buShape lastDrill;
  public static buShape lastProfiling;
  public static buShape lastEngrave;
  public static buShape lastJunction;
  public static ShapeSettingData ShapeSettingsParameters;
  public static ShapeRuntimeData ShapeDataParameters;
  public static ShapeTempData ShapeTempPar;
  public static ShapeCreateParameters shapeCreatePar;
  public static buShapeVisualition VarbuShapeVisilation;
  public static MachineSimulation SimVars;
  public AnalyseEntitiesSetting AnalyseEntitySetting;
  public DirectionArrowSetting DirectionArrowSettings;
  public CopyEventFormVars copyEventFormVar;
  public MoveEventFormVars moveEventFormVar;
  public ScaleEventFormVars scaleEventFormVar;

  public static List<Point3D> VerticeToPointsList(List<Point3D> Vertice)
  {
    List<Point3D> PointList = new List<Point3D>();
    F_CutterOffsetEntities.VerticeToPointsList(Vertice, ref PointList);
    return PointList;
  }

  public static List<PointRGB> VerticeToPointsList(List<Point3D> Vertice, Color Color)
  {
    List<PointRGB> PointList = new List<PointRGB>();
    F_CutterOffsetEntities.VerticeToPointsList(Vertice, ref PointList, Color);
    return PointList;
  }

  public static Pnt3D ToPnt3D(Point3D Pnt) => new Pnt3D(Pnt.X, Pnt.Y, Pnt.Z);

  public static Point3D ToPoint3D(Point3D Pnt, int Round = 0)
  {
    return !(Pnt != (Point3D) null) ? new Point3D() : (Round != 0 ? new Point3D(Math.Round(Pnt.X, Round), Math.Round(Pnt.Y, Round), Math.Round(Pnt.Z, Round)) : new Point3D(Pnt.X, Pnt.Y, Pnt.Z));
  }

  public static Point3D ToPoint3D(Pnt3D Pnt) => new Point3D(Pnt.X, Pnt.Y, Pnt.Z);

  public static Point3D ToPoint3D(Pnt6D Pnt) => new Point3D(Pnt.X, Pnt.Y, Pnt.Z);

  public static Point3D ToPoint3D(Pnt6DSimMove Pnt)
  {
    return new Point3D(((MeshToSurfacePointsSettings) Pnt).X, ((MeshToSurfacePointsSettings) Pnt).Y, ((MeshToSurfacePointsSettings) Pnt).Z);
  }

  public static Point3D ToPoint3D(Pnt9D Pnt) => new Point3D(Pnt.X, Pnt.Y, Pnt.Z);
}
