// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buRegion
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.ClassViewer;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buRegion : buEntity
{
  internal buSeparator \u0001;
  internal buSeparator \u0002;
  internal buSeparator \u0003;

  public abstract void m00175B();

  public buRegion()
  {
    ((buMaterialMoveable) this).OkCaption = "Ok";
    ((buMaterialMoveable) this).CancelCaption = "Cancel";
    ((buMaterialMoveable) this).FormCaption = "";
    ((buMaterialMoveable) this).ParCaptions = new List<string>();
    ((buMaterialMoveable) this).Result = DialogResult.None;
    ((buMaterialMoveable) this).ValuePersentage = 50.0;
    ((buUpperLineEnt) this).DecimalPlace = 3;
    ((buUpperLineEnt) this).Value = (object) null;
    ((buUpperLineEnt) this).\u0001 = (object) null;
    ((buUpperLineEnt) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u0007.\u0001.\u0001((F_ClassViewerDialog5) this);
  }

  public new void Init()
  {
    if (((buMaterialMoveable) this).FormCaption.Length > 0)
      ((Control) this).Text = ((buMaterialMoveable) this).FormCaption;
    if (((buMaterialMoveable) this).OkCaption.Length > 0)
      ((buUpperLineEnt) this).btn_ok.Text = ((buMaterialMoveable) this).OkCaption;
    if (((buMaterialMoveable) this).CancelCaption.Length > 0)
      ((buUpperLineEnt) this).btn_cancel.Text = ((buMaterialMoveable) this).CancelCaption;
    buSerilization5.CopyClass(((buUpperLineEnt) this).Value, ref ((buUpperLineEnt) this).\u0001);
    ((buMachinePart) ((buUpperLineEnt) this).\u0001).ClassObject = ((buUpperLineEnt) this).\u0001;
    ((buMachinePart) ((buUpperLineEnt) this).\u0001).RowSpace = 1;
    ((buUpperLineEnt) this).\u0001.Width = ((Control) this).Width - 15;
    ((buUpperLineEnt) this).\u0001.Visible = true;
    ((buMachinePart) ((buUpperLineEnt) this).\u0001).DecimalPlace = ((buUpperLineEnt) this).DecimalPlace;
    ((buMachinePart) ((buUpperLineEnt) this).\u0001).ValueWidth = Convert.ToInt32((double) ((Control) this).Width * (((buMaterialMoveable) this).ValuePersentage / 100.0)) - 8;
    ((buMachinePart) ((buUpperLineEnt) this).\u0001).ParCaptions.Clear();
    for (int index = 0; index <= ((buMaterialMoveable) this).ParCaptions.Count - 1; ++index)
      ((buMachinePart) ((buUpperLineEnt) this).\u0001).ParCaptions.Add(((buMaterialMoveable) this).ParCaptions[index]);
    ((buLinearPath) ((buUpperLineEnt) this).\u0001).Init();
  }

  internal new void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    buSerilization5.CopyClass(((buUpperLineEnt) this).\u0001, ref ((buUpperLineEnt) this).Value);
    ((buMaterialMoveable) this).Result = DialogResult.OK;
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Component) this).Dispose());
  }

  internal new void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((buMaterialMoveable) this).Result = DialogResult.Cancel;
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Component) this).Dispose());
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((buUpperLineEnt) this).\u0001 != null ? 1 : 0)) != 0)
      ((buUpperLineEnt) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  public abstract void m001761();

  public static void BoxSizeCalculate(
    List<Point3D> Points,
    ref Point3D MinPoint,
    ref Point3D MaxPoint)
  {
    try
    {
      MinPoint = new Point3D(double.MaxValue, double.MaxValue, double.MaxValue);
      MaxPoint = new Point3D(double.MinValue, double.MinValue, double.MinValue);
      for (int index = 0; index <= Points.Count - 1; ++index)
      {
        if (Points[index].X > MaxPoint.X)
          MaxPoint.X = Points[index].X;
        if (Points[index].Y > MaxPoint.Y)
          MaxPoint.Y = Points[index].Y;
        if (Points[index].Z > MaxPoint.Z)
          MaxPoint.Z = Points[index].Z;
        if (Points[index].X < MinPoint.X)
          MinPoint.X = Points[index].X;
        if (Points[index].Y < MinPoint.Y)
          MinPoint.Y = Points[index].Y;
        if (Points[index].Z < MinPoint.Z)
          MinPoint.Z = Points[index].Z;
      }
    }
    catch (Exception ex)
    {
      string str = "Count: " + Points.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static buEntity convEntity(ICurve refEntity)
  {
    buEntity buEntity = (buEntity) null;
    if (refEntity.GetType() == typeof (Point))
      buEntity = (buEntity) new buMultilineText((Point) refEntity);
    else if (refEntity.GetType() == typeof (Line))
      buEntity = (buEntity) new buMultilineText((Line) refEntity);
    else if (refEntity.GetType() == typeof (Arc))
      buEntity = (buEntity) new buEntityList((Arc) refEntity);
    else if (refEntity.GetType() == typeof (Circle))
      buEntity = (buEntity) new buShape((Circle) refEntity);
    else if (refEntity.GetType() == typeof (Ellipse))
      buEntity = (buEntity) new buShape((Ellipse) refEntity);
    else if (refEntity.GetType() == typeof (Curve))
      buEntity = (buEntity) new buShapeRectangle((Curve) refEntity);
    else if (refEntity.GetType() == typeof (LinearPath))
      buEntity = (buEntity) new buShape((LinearPath) refEntity);
    else if (refEntity.GetType() == typeof (CompositeCurve))
      buEntity = (buEntity) new buShapeCircle((CompositeCurve) refEntity);
    else if (refEntity.GetType() == typeof (Region))
      buEntity = (buEntity) new buShapePolygon((Region) refEntity);
    else if (refEntity.GetType() == typeof (Mesh))
      buEntity = (buEntity) new buShapeFreeLines((Mesh) refEntity);
    return buEntity;
  }
}
