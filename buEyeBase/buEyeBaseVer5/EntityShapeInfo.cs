// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.EntityShapeInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class EntityShapeInfo : buSerilization5
{
  public bool isCoordinateMode;
  public ContentAlignment Alignment;
  public Point3D Ratio;
  public bool ShowAligment;
  public bool isLengthMode;
  public bool KeepRatio;
  public bool LineEnable;
  public bool PolylineEnable;
  public bool CircleEnable;
  public bool ArcEnable;
  public bool EllipseEnable;
  public bool CompositeCurveEnable;
  public bool CurveEnable;
  public double LineLength;

  public override string ToString() => "Pos: " + ((MoveEventFormVars) this).Position.ToString();

  public abstract void m0001B2();

  public EntityShapeInfo()
  {
    ((ScaleEventFormVars) this).Enable = true;
    ((ScaleEventFormVars) this).Lock = false;
    ((ScaleEventFormVars) this).RealDrawMode = false;
    ((DevideEventFormVars) this).Selectable = true;
    ((DevideEventFormVars) this).Name = "Layer";
    ((DevideEventFormVars) this).NameExtra = "";
    ((DevideEventFormVars) this).MaterialName = "";
    ((DevideEventFormVars) this).Tag = "";
    ((DevideEventFormVars) this).Option = "";
    ((DevideEventFormVars) this).Note = "";
    ((DevideEventFormVars) this).ShownName = "";
    ((DevideEventFormVars) this).Defination = "";
    ((DevideEventFormVars) this).Mode = 0;
    ((DevideEventFormVars) this).LayerColor = Color.Black;
    ((DevideEventFormVars) this).Transparency = (int) byte.MaxValue;
    ((DevideEventFormVars) this).LayerThickness = 1f;
    ((DevideEventFormVars) this).Pattern = (drawingPattern) null;
    ((DevideEventFormVars) this).LayerPurposes = LayerPurpose.General;
    ((DeleteTypeEventFormVars) this).ToolSelected = (ToolBase5) null;
    ((DeleteTypeEventFormVars) this).Cam = (LayerCam) null;
    ((DeleteTypeEventFormVars) this).Tufting = (LayerTuftingProps) null;
    ((DeleteTypeEventFormVars) this).Diemaker = (LayerDiemakerProps) null;
    ((DeleteTypeEventFormVars) this).Jewelary = (LayerJewelProps) null;
    ((DeleteTypeEventFormVars) this).Router3AX = (LayerRouter3XProps) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
