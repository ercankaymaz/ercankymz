// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MaterialBase5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class MaterialBase5 : buSerilization5
{
  public projectionType ProjetionType;
  public originSymbolStyleType OrigineSymbol;
  public waitCursorType WaitCursorMode;
  public DockStyle Dock;
  public bool ShowProgress;
  public bool GridVisible;
  public double GridStepX;
  public double GridStepY;
  public bool OriginSymbolVisible;
  public bool OrigineCaptionVisible;
  public int OrigineSize;
  public bool ViewCubeIconVisible;
  public bool ReverseMouseWheel;
  public bool CoordinateSystemIconVisible;
  public bool ToolBorVisible;
  public int Width;
  public int Height;
  public MouseButton PanMouseButtons;
  public MouseButton RotateMouseButtons;
  public MouseButton ZoomMouseButtons;
  public Color BottomColor;
  public Color IntermediateColor;
  public Color TopColor;
  public displayType DisplayType;
  public projectionType ProjectionType;
  public originSymbolStyleType OriginSymbol;
  public MouseButton PanMouseButton;
  public MouseButton RotateMouseButton;
  public MouseButton ZoomMouseButton;
  public bool ShowGrid;
  public bool ShowOrigin;
  public bool ShowOriginCaption;
  public bool ShowCoordinateArrow;

  public abstract void m00028E();

  public MaterialBase5()
  {
    ((EyeCreateProps) this).PointGetType = HitSurfacePointsGetType.Top;
    ((EyeCreateProps) this).TangentAngleFromNormal = -90.0;
    ((EyeCreateProps) this).SurfaceNormalLength = 30.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MaterialBase5(HitSurfacePointsSettings Data)
  {
    ((EyeCreateProps) this).PointGetType = HitSurfacePointsGetType.Top;
    ((EyeCreateProps) this).TangentAngleFromNormal = -90.0;
    ((EyeCreateProps) this).SurfaceNormalLength = 30.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) Data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public MaterialBase5()
  {
    ((EyeCreateProps) this).normalPoint = new Pnt6D();
    ((EyeCreateProps) this).normalEntities = (Entity) null;
    ((EyeCreateProps) this).NormalVector = new Vector3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MaterialBase5(HitSurfacePointsCalculations Data)
  {
    ((EyeCreateProps) this).normalPoint = new Pnt6D();
    ((EyeCreateProps) this).normalEntities = (Entity) null;
    ((EyeCreateProps) this).NormalVector = new Vector3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) Data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
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
    if (((EyeCreateProps) Data).normalEntities != null)
      ((EyeCreateProps) this).normalEntities = buVector5.CopyEntities(((EyeCreateProps) Data).normalEntities);
    ((EyeCreateProps) this).NormalVector = new Vector3D(((EyeCreateProps) Data).NormalVector.X, ((EyeCreateProps) Data).NormalVector.Y, ((EyeCreateProps) Data).NormalVector.Z);
  }

  public MaterialBase5()
  {
    ((EyeCreateProps) this).pntBottomLeft = new Point3D();
    ((EyeCreateProps) this).pntBottomCenter = new Point3D();
    ((EyeCreateProps) this).pntBottomRight = new Point3D();
    ((EyeCreateProps) this).pntMiddleLeft = new Point3D();
    ((EyeCreateProps) this).pntMiddleCenter = new Point3D();
    ((EyeCreateProps) this).pntMiddleRight = new Point3D();
    ((EyeCreateProps) this).pntTopLeft = new Point3D();
    ((EyeCreateProps) this).pntTopCenter = new Point3D();
    ((EyeCreateProps) this).pntTopRight = new Point3D();
    ((EyeCreateProps) this).MovePoints = new List<Point3D>();
    ((ViewportSettings) this).TipPoints = new List<Point3D>();
    ((ViewportSettings) this).BoxSizePoints = new List<Point3D>();
    ((ViewportSettings) this).RotatePoints = new List<Point3D>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MaterialBase5(AlingmentPoints3D data)
  {
    ((EyeCreateProps) this).pntBottomLeft = new Point3D();
    ((EyeCreateProps) this).pntBottomCenter = new Point3D();
    ((EyeCreateProps) this).pntBottomRight = new Point3D();
    ((EyeCreateProps) this).pntMiddleLeft = new Point3D();
    ((EyeCreateProps) this).pntMiddleCenter = new Point3D();
    ((EyeCreateProps) this).pntMiddleRight = new Point3D();
    ((EyeCreateProps) this).pntTopLeft = new Point3D();
    ((EyeCreateProps) this).pntTopCenter = new Point3D();
    ((EyeCreateProps) this).pntTopRight = new Point3D();
    ((EyeCreateProps) this).MovePoints = new List<Point3D>();
    ((ViewportSettings) this).TipPoints = new List<Point3D>();
    ((ViewportSettings) this).BoxSizePoints = new List<Point3D>();
    ((ViewportSettings) this).RotatePoints = new List<Point3D>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
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
    ((EyeCreateProps) this).MovePoints.Clear();
    ((EyeCreateProps) this).MovePoints = new List<Point3D>();
    for (int index = 0; index <= ((EyeCreateProps) data).MovePoints.Count - 1; ++index)
      ((EyeCreateProps) this).MovePoints.Add(F_NotchEdit.ToPoint3D(((EyeCreateProps) data).MovePoints[index]));
    ((ViewportSettings) this).TipPoints.Clear();
    ((ViewportSettings) this).TipPoints = new List<Point3D>();
    for (int index = 0; index <= ((ViewportSettings) data).TipPoints.Count - 1; ++index)
      ((ViewportSettings) this).TipPoints.Add(F_NotchEdit.ToPoint3D(((ViewportSettings) data).TipPoints[index]));
    ((ViewportSettings) this).BoxSizePoints.Clear();
    ((ViewportSettings) this).BoxSizePoints = new List<Point3D>();
    for (int index = 0; index <= ((ViewportSettings) data).BoxSizePoints.Count - 1; ++index)
      ((ViewportSettings) this).BoxSizePoints.Add(F_NotchEdit.ToPoint3D(((ViewportSettings) data).BoxSizePoints[index]));
    ((ViewportSettings) this).RotatePoints.Clear();
    ((ViewportSettings) this).RotatePoints = new List<Point3D>();
    for (int index = 0; index <= ((ViewportSettings) data).RotatePoints.Count - 1; ++index)
      ((ViewportSettings) this).RotatePoints.Add(F_NotchEdit.ToPoint3D(((ViewportSettings) data).RotatePoints[index]));
  }
}
