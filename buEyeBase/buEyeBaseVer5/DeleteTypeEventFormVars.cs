// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.DeleteTypeEventFormVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class DeleteTypeEventFormVars : buSerilization5
{
  public ToolBase5 ToolSelected;
  public LayerCam Cam;
  public LayerTuftingProps Tufting;
  public LayerDiemakerProps Diemaker;
  public LayerJewelProps Jewelary;
  public LayerRouter3XProps Router3AX;
  public static List<string> Captions;
  public static byte f000470;
  public string LayerOriginalName;
  public string LayerNewName;
  public string LayerExtraName;
  public Color LayerNewColor;
  public static byte f000475;
  public ContentAlignment Alignment;
  public Point3D CatchPoint;
  public bool ShowZ;
  public bool ShowAligment;
  public bool isCoordinateMode;

  public abstract void m0001AD();

  public DeleteTypeEventFormVars()
  {
    ((MoveEventFormVars) this).Position = new Pnt6D();
    ((MoveEventFormVars) this).Offset = new Pnt6D();
    ((MoveEventFormVars) this).CommonOffset = new Pnt6D();
    ((MoveEventFormVars) this).AngularPosition = 0.0;
    ((ScaleEventFormVars) this).Location = ToolLocationType.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
