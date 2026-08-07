// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSpeedsV1
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.buEntities;
using buMutliTextbox;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSpeedsV1 : Form
{
  public buButton btn_laser;
  public buTab buTab_Main;
  public TabPage tabPage_horizontal;
  public TabPage tabPage_vertical;
  internal TabPage \u0001;
  public buButton btn_motorcurrent;
  public buMultiTextBox txt_gcode;
  public buButton btn_operation;
  public buButton btn_gcode;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  internal buLabel \u0004;
  internal buLabel \u0005;
  public buButton btn_toolpage;
  public buButton btn_g54list;
  public buButton btn_parklist;
  public buButton btn_spindlestart;
  public buButton btn_partzero;
  public buProgressBar progress_X;
  public buProgressBar progress_A;
  public buProgressBar progress_C;
  public buProgressBar progress_Z;
  public buProgressBar progress_Y;
  public buButton btn_crousecontrol;
  public buButton btn_rtcp;
  public buLabel lbl_totalline;
  public buLabel lbl_actualline;
  internal buSeparator \u0001;
  public buButton btn_gcodemaximize;
  public buButton btn_material;
  public buLabel lbl_millingheadlen;
  public buLabel lbl_millingheaddia;
  public buLabel lbl_millinglen;
  public buLabel lbl_millingdia;
  public buLabel lbl_sawtickness;

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
  }

  private void \u0001()
  {
    if (!((F_MarbleJobOPListV2) this).PropertiesForm.Inited)
      return;
    ((F_MarbleJobOPListV2) this).viewportLayout.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Clear();
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Rectangle)
    {
      CompositeCurve rectangle = CompositeCurve.CreateRectangle(((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Width, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height);
      Entity entSurface = (Entity) null;
      buCall.\u0001.surfaceFromOutterInner((ICurve) rectangle, (List<ICurve>) null, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth, ref entSurface);
      entSurface.Color = ((SortOptions) ((F_MarbleJobOPListV2) this).Material).Display.SkinColor;
      entSurface.ColorMethod = colorMethodType.byEntity;
      entSurface.Rotate(buString5.DegreeToRadian(((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle), Vector3D.AxisZ);
      ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Add(entSurface);
      if (((F_MarbleJobOPListV2) this).DrawDimension)
      {
        LinearDim linearDim1 = new LinearDim(Plane.XY, new Point3D(), new Point3D(((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Width, 0.0, 0.0), new Point3D(((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Width / 2.0, -200.0, 0.0), 100.0);
        linearDim1.TextOverride = $"{buLangTranslate.preDef.Width}: {linearDim1.Distance.ToString()}";
        ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Add((Entity) linearDim1);
        Plane drawingPlane = (Plane) null;
        buCall.\u0001.LinearDimCalculate(new Point3D(0.0, 0.0), new Point3D(0.0, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height), new Point3D(-200.0, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height / 2.0), 100.0, Plane.XY, ref drawingPlane);
        LinearDim linearDim2 = new LinearDim(drawingPlane, new Point3D(), new Point3D(0.0, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height, 0.0), new Point3D(-200.0, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height / 2.0, 0.0), 100.0);
        linearDim2.TextOverride = $"{buLangTranslate.preDef.Height}: {linearDim2.Distance.ToString()}";
        ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Add((Entity) linearDim2);
        buCall.\u0001.LinearDimCalculate(new Point3D(0.0, 0.0, 0.0), new Point3D(0.0, 0.0, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth), new Point3D(-200.0, 0.0, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth / 2.0), 100.0, Plane.XZ, ref drawingPlane);
        LinearDim linearDim3 = new LinearDim(drawingPlane, new Point3D(0.0, 0.0, 0.0), new Point3D(0.0, 0.0, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth), new Point3D(-200.0, 0.0, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth / 2.0), 100.0);
        linearDim3.TextOverride = $"{buLangTranslate.preDef.Depth}: {linearDim3.Distance.ToString()}";
        ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Add((Entity) linearDim3);
      }
    }
    else if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Circle)
    {
      Circle Outters = new Circle(new Point3D(), ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Diameter / 2.0);
      Outters.Translate(((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Diameter / 2.0, ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Diameter / 2.0);
      Entity entSurface = (Entity) null;
      buCall.\u0001.surfaceFromOutterInner((ICurve) Outters, (List<ICurve>) null, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth, ref entSurface);
      entSurface.Color = ((SortOptions) ((F_MarbleJobOPListV2) this).Material).Display.SkinColor;
      entSurface.ColorMethod = colorMethodType.byEntity;
      ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Add(entSurface);
    }
    else if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Ellipse)
    {
      Ellipse Outters = new Ellipse(new Point3D(), ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).MajorRadius, ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).MinorRadius);
      Outters.Translate(((SortAskMe) ((F_MarbleJobOPListV2) this).Material).MajorRadius, ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).MinorRadius);
      Entity entSurface = (Entity) null;
      buCall.\u0001.surfaceFromOutterInner((ICurve) Outters, (List<ICurve>) null, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth, ref entSurface);
      entSurface.Color = ((SortOptions) ((F_MarbleJobOPListV2) this).Material).Display.SkinColor;
      entSurface.ColorMethod = colorMethodType.byEntity;
      entSurface.Rotate(buString5.DegreeToRadian(((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle), Vector3D.AxisZ);
      ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Add(entSurface);
    }
    else if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Irregular)
    {
      LinearPath Outters = new LinearPath((ICollection<Point3D>) ((SortOptions) ((F_MarbleJobOPListV2) this).Material).Points);
      Entity entSurface = (Entity) null;
      if (((SortOptions) ((F_MarbleJobOPListV2) this).Material).Points.Count >= 3)
      {
        buCall.\u0001.surfaceFromOutterInner((ICurve) Outters, (List<ICurve>) null, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth, ref entSurface);
        entSurface.Color = ((SortOptions) ((F_MarbleJobOPListV2) this).Material).Display.SkinColor;
        entSurface.ColorMethod = colorMethodType.byEntity;
        entSurface.Rotate(buString5.DegreeToRadian(((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle), Vector3D.AxisZ);
        ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Add(entSurface);
      }
    }
    else if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.RectangleRound)
    {
      CompositeCurve roundedRectangle = CompositeCurve.CreateRoundedRectangle(((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Width, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height, ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Radius);
      roundedRectangle.Regen(0.01);
      Entity entSurface = (Entity) null;
      buCall.\u0001.surfaceFromOutterInner((ICurve) roundedRectangle, (List<ICurve>) null, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth, ref entSurface);
      entSurface.Color = ((SortOptions) ((F_MarbleJobOPListV2) this).Material).Display.SkinColor;
      entSurface.ColorMethod = colorMethodType.byEntity;
      entSurface.Rotate(buString5.DegreeToRadian(((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle), Vector3D.AxisZ);
      ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Add(entSurface);
    }
    else if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.RectangleChamfer)
    {
      buCall.\u0001.RectangleChamfer(new Point3D(), new Point3D(((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Width, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height), ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).ChamferLength, Plane.XY, ref ((SortOptions) ((F_MarbleJobOPListV2) this).Material).Points);
      LinearPath Outters = new LinearPath((ICollection<Point3D>) ((SortOptions) ((F_MarbleJobOPListV2) this).Material).Points);
      Entity entSurface = (Entity) null;
      if (((SortOptions) ((F_MarbleJobOPListV2) this).Material).Points.Count >= 3)
      {
        buCall.\u0001.surfaceFromOutterInner((ICurve) Outters, (List<ICurve>) null, ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth, ref entSurface);
        entSurface.Color = ((SortOptions) ((F_MarbleJobOPListV2) this).Material).Display.SkinColor;
        entSurface.ColorMethod = colorMethodType.byEntity;
        entSurface.Rotate(buString5.DegreeToRadian(((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle), Vector3D.AxisZ);
        ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Add(entSurface);
      }
    }
    if (((F_MarbleJobOPListV2) this).OptionEntity != null)
    {
      for (int index = 0; index <= ((F_MarbleJobOPListV2) this).OptionEntity.Count - 1; ++index)
        ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Add(((F_MarbleJobOPListV2) this).OptionEntity[index]);
    }
    if (((F_MarbleJobOPListV2) this).EntClamper != null)
    {
      ((F_MarbleJobOPListV2) this).EntClamper.Regen(0.01);
      double ClamperLength = ((F_MarbleJobOPListV2) this).EntClamper.BoxMax.X - ((F_MarbleJobOPListV2) this).EntClamper.BoxMin.X;
      double X1 = 0.0;
      double X2 = 0.0;
      this.FindFirstClamperPositions(((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Width, ClamperLength, ref X1, ref X2);
      Entity copiedEntity1 = (Entity) null;
      Entity copiedEntity2 = (Entity) null;
      buRadialDim.Copy(((F_MarbleJobOPListV2) this).EntClamper, ref copiedEntity1);
      copiedEntity1.Rotate(Math.PI, Vector3D.AxisZ);
      copiedEntity1.Translate(X1, 0.0);
      copiedEntity1.LayerName = "Default";
      copiedEntity1.Color = Color.Gray;
      copiedEntity1.ColorMethod = colorMethodType.byEntity;
      buRadialDim.Copy(((F_MarbleJobOPListV2) this).EntClamper, ref copiedEntity2);
      copiedEntity2.Rotate(Math.PI, Vector3D.AxisZ);
      copiedEntity2.Translate(X2, 0.0);
      copiedEntity2.LayerName = "Default";
      copiedEntity2.Color = Color.Gray;
      copiedEntity2.ColorMethod = colorMethodType.byEntity;
      ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Add(copiedEntity1);
      ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Add(copiedEntity2);
    }
    ((F_MarbleJobOPListV2) this).viewportLayout.ActiveViewport.OriginSymbol.StyleMode = originSymbolStyleType.Ball;
    if (((F_MarbleJobOPListV2) this).EntClamper != null)
    {
      ((F_MarbleJobOPListV2) this).viewportLayout.SetView(viewType.Top, true, false);
      ((F_MarbleJobOPListV2) this).viewportLayout.ActiveViewport.RotateCamera(Vector3D.AxisZ, 180.0, false);
      ((F_MarbleJobOPListV2) this).viewportLayout.ActiveViewport.RotateCamera(Vector3D.AxisX, 45.0, false);
    }
    else
    {
      ((F_MarbleJobOPListV2) this).viewportLayout.SetView(viewType.Top, true, false);
      ((F_MarbleJobOPListV2) this).viewportLayout.ActiveViewport.RotateCamera(Vector3D.AxisX, -45.0, false);
      ((F_MarbleJobOPListV2) this).viewportLayout.ActiveViewport.RotateCamera(Vector3D.AxisZ, 20.0, false);
    }
    ((F_MarbleJobOPListV2) this).viewportLayout.ZoomFit(10);
    ((F_MarbleJobOPListV2) this).viewportLayout.Invalidate();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
    if (!((F_MarbleJobOPListV2) this).PropertiesForm.Inited)
      return;
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Rectangle)
    {
      ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Width = (double) ((F_MarbleJobOPListV2) this).\u0001.Value;
      ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height = (double) ((F_MarbleJobOPListV2) this).\u0002.Value;
      ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth = (double) ((F_MarbleJobOPListV2) this).\u0003.Value;
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle = (double) ((F_MarbleStartLine) this).\u0004.Value;
      this.\u0001();
    }
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Circle)
    {
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Diameter = (double) ((F_MarbleJobOPListV2) this).\u0001.Value;
      ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth = (double) ((F_MarbleJobOPListV2) this).\u0002.Value;
      this.\u0001();
    }
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Ellipse)
    {
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).MajorRadius = (double) ((F_MarbleJobOPListV2) this).\u0001.Value;
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).MinorRadius = (double) ((F_MarbleJobOPListV2) this).\u0002.Value;
      ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth = (double) ((F_MarbleJobOPListV2) this).\u0003.Value;
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle = (double) ((F_MarbleStartLine) this).\u0004.Value;
      this.\u0001();
    }
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.RectangleRound)
    {
      ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Width = (double) ((F_MarbleJobOPListV2) this).\u0001.Value;
      ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height = (double) ((F_MarbleJobOPListV2) this).\u0002.Value;
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Radius = (double) ((F_MarbleJobOPListV2) this).\u0003.Value;
      ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth = (double) ((F_MarbleStartLine) this).\u0004.Value;
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle = (double) ((F_MarbleStartLine) this).\u0005.Value;
      this.\u0001();
    }
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.RectangleChamfer)
    {
      ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Width = (double) ((F_MarbleJobOPListV2) this).\u0001.Value;
      ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height = (double) ((F_MarbleJobOPListV2) this).\u0002.Value;
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).ChamferLength = (double) ((F_MarbleJobOPListV2) this).\u0003.Value;
      ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth = (double) ((F_MarbleStartLine) this).\u0004.Value;
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle = (double) ((F_MarbleStartLine) this).\u0005.Value;
      this.\u0001();
    }
    ((F_MarbleJobOPListV2) this).PropertiesForm.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleJobOPListV2) this).PropertiesForm.Inited)
      return;
    if (((F_MarbleJobOPListV2) this).\u0001.SelectedIndex == 0)
    {
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes = MaterialShapes.Rectangle;
      ((F_MarbleJobList) this).TypeToControl();
      this.\u0001();
    }
    if (((F_MarbleJobOPListV2) this).\u0001.SelectedIndex == 1)
    {
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes = MaterialShapes.Circle;
      ((F_MarbleJobList) this).TypeToControl();
      this.\u0001();
    }
    if (((F_MarbleJobOPListV2) this).\u0001.SelectedIndex == 2)
    {
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes = MaterialShapes.Ellipse;
      ((F_MarbleJobList) this).TypeToControl();
      this.\u0001();
    }
    if (((F_MarbleJobOPListV2) this).\u0001.SelectedIndex == 3)
    {
      ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes = MaterialShapes.RectangleRound;
      ((F_MarbleJobList) this).TypeToControl();
      this.\u0001();
    }
    if (((F_MarbleJobOPListV2) this).\u0001.SelectedIndex != 4)
      return;
    ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes = MaterialShapes.RectangleChamfer;
    ((F_MarbleJobList) this).TypeToControl();
    this.\u0001();
  }

  public void FindFirstClamperPositions(
    double Width,
    double ClamperLength,
    ref double X1,
    ref double X2)
  {
    X2 = ClamperLength / 2.0;
    X1 = Width - ClamperLength / 2.0;
    if (X1 - X2 >= ClamperLength + 10.0)
      return;
    double num = ClamperLength + 10.0 - (X2 - X1);
    if (num <= 0.0)
      return;
    X2 += num / 2.0;
    X1 -= num / 2.0;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleJobOPListV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleJobOPListV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleSpeedsV1() => F_MarbleJobOPListV2.Captions = new List<string>();

  public F_MarbleSpeedsV1()
  {
    // ISSUE: unable to decompile the method.
  }
}
