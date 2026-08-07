// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Editor.Sketcher2D
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Sewing;
using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using ns8;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Editor;

public class Sketcher2D : Design
{
  public static bool isDrawing = false;
  public static bool isSelectionDone = false;
  public static bool isAreaSelection = false;
  public static bool selectionProcess = false;
  public static bool buttonPressedForSelection = false;
  public static bool OrthoPossible = false;
  public static bool FirstMove = false;
  public static bool ForbiddenAreaClicked = false;
  public static int indexLabel = -1;
  public static int rightClickCnt = 0;
  protected DimensionPreviewDrawParams PreviewDrawParams = new DimensionPreviewDrawParams(Color.Blue)
  {
    LineSize = 1f,
    WidthFactor = 0.9
  };
  public Point3D mouseWorldLoc = Point3D.Origin;
  public Point3D mouseLastClick = Point3D.Origin;
  public Point2D mouseScreenLoc = new Point2D();
  public static Point3D mouseWorldCoord = new Point3D();
  public static Point2D mousePlnLoc = new Point2D();
  public static System.Drawing.Point mouseDownLocation;
  protected System.Drawing.Point mouseloc;
  public static List<List<Point3D>> DrawingPoints = new List<List<Point3D>>();
  public static List<UClick> Clicks = new List<UClick>();
  public static List<Point3D> selectedPoint = new List<Point3D>();
  public static List<Circle> selectedCircle = new List<Circle>();
  public static pickStateType currPickState;
  public static ISelectableItem entityMouseUnder = (ISelectableItem) null;
  private ISelectableItem iselectableItem_0;
  public static double PixelVsMilimeter = 1.0;
  public static Entity entitySelected = (Entity) null;
  public static List<Entity> entitiesSelected = new List<Entity>();
  public static List<List<int>> selectedIndex = new List<List<int>>();
  private devDept.Eyeshot.Entities.Point point_0;
  private devDept.Eyeshot.Entities.Point point_1;
  private bool bool_0;
  internal OsnapPoint[] osnapPoint_0;
  private OsnapPoint osnapPoint_1 = (OsnapPoint) null;
  private int[] int_0 = (int[]) null;
  private Plane plane_0;
  private System.Drawing.Point point_2;
  private int int_1 = -1;
  private int int_2 = -1;
  private Point2D point2D_0;
  private bool bool_1;
  private Entity entity_0;
  private List<Entity> list_0 = new List<Entity>();
  public static Entity secondSelectedEntity = (Entity) null;
  public static Entity firstSelectedEntity = (Entity) null;
  internal double double_0 = 500.0;
  private string string_0 = "";
  internal Point3D point3D_0;
  internal Point3D point3D_1;

  public List<Point4D> ControlPoints(Curve curve)
  {
    return ((IEnumerable<Curve>) curve.Decompose()).SelectMany<Curve, Point4D>((Func<Curve, IEnumerable<Point4D>>) (curve_0 => (IEnumerable<Point4D>) curve_0.ControlPoints)).ToList<Point4D>();
  }

  public Sketcher2D()
  {
    if (this.IsDesignMode())
      return;
    this.LoadDocument((DesignDocument) new SketcherDesignDocument());
    this.WaitCursorMode = waitCursorType.Never;
    this.string_0 = this.Layers[0].Name;
    this.Clear();
  }

  protected override void OnMouseMove(MouseEventArgs mea)
  {
    try
    {
      this.mouseloc = mea.Location;
      System.Drawing.Point location1 = mea.Location;
      double x = (double) location1.X;
      int height = this.Height;
      location1 = mea.Location;
      int y1 = location1.Y;
      double y2 = (double) (height - y1);
      this.mouseScreenLoc = new Point2D(x, y2);
      System.Drawing.Point location2 = mea.Location;
      if (this.mouseloc == this.point_2)
        return;
      this.ScreenToPlane(location2, Plane.XY, out this.mouseWorldLoc);
      if (this.mouseWorldLoc == (Point3D) null)
        return;
      Sketcher2D.mouseWorldCoord.X = this.mouseWorldLoc.X;
      Sketcher2D.mouseWorldCoord.Y = this.mouseWorldLoc.Y;
      if (clsVar.varEditorSet.Ortho & Sketcher2D.OrthoPossible)
      {
        int OrthoDir = 0;
        Point3D point3D = new Point3D();
        clsInit.cVector5.OrthoFunction(this.mouseWorldLoc, this.mouseLastClick, Plane.XY, ref this.mouseWorldLoc, ref OrthoDir);
      }
      this.osnapPoint_1 = (OsnapPoint) null;
      this.osnapPoint_0 = this.GetSnapPoints(this.mouseloc);
      if ((this.osnapPoint_0 == null ? 0 : (this.osnapPoint_0.Length != 0 ? 1 : 0)) != 0)
      {
        this.osnapPoint_1 = this.method_17(this.osnapPoint_0);
        if ((Point3D) this.osnapPoint_1 != (Point3D) null)
          this.mouseWorldLoc = (Point3D) this.osnapPoint_1;
      }
      if ((Point3D) this.osnapPoint_1 == (Point3D) null & !Sketcher2D.selectionProcess)
      {
        this.osnapPoint_1 = this.Snaping();
        if ((Point3D) this.osnapPoint_1 != (Point3D) null)
        {
          this.mouseWorldLoc = (Point3D) this.osnapPoint_1;
          this.mouseScreenLoc = (Point2D) this.WorldToScreen(this.mouseWorldLoc);
        }
      }
      if ((Point3D) this.osnapPoint_1 == (Point3D) null)
      {
        this.osnapPoint_0 = new OsnapPoint[1];
        this.osnapPoint_0[0] = new OsnapPoint(new Point3D(), osnapType.Point);
        this.osnapPoint_1 = this.method_17(this.osnapPoint_0);
        if ((Point3D) this.osnapPoint_1 != (Point3D) null)
          this.mouseWorldLoc = (Point3D) this.osnapPoint_1;
      }
      this.int_0 = (int[]) null;
      Sketcher2D.entityMouseUnder = (ISelectableItem) this.GetEntityByPosition(mea.Location);
      this.int_0 = this.GetAllEntitiesUnderMouseCursor(mea.Location);
      Sketcher2D.indexLabel = this.GetLabelUnderMouseCursor(mea.Location);
      this.TempEntities.Clear();
      if (Sketcher2D.entityMouseUnder == null || this.Entities.Count > 0)
        ;
      if (Sketcher2D.entityMouseUnder == null & Sketcher2D.indexLabel >= 0 && this.ActiveViewport.Labels[Sketcher2D.indexLabel] is StackedLabel)
        this.CurrentSketch.DisplayConstraintEntities((this.ActiveViewport.Labels[Sketcher2D.indexLabel] as StackedLabel).Constraint);
      if (this.bool_1)
      {
        Point3D intPoint;
        this.ScreenToPlane(mea.Location, this.CurrentSketch.DrawingPlane, out intPoint);
        Point2D point2D = this.CurrentSketch.DrawingPlane.Project(intPoint);
        if (this.iselectableItem_0 is Entity)
          this.CurrentSketch.DragTo(Sketcher2D.mousePlnLoc);
        this.point2D_0 = point2D;
        if (this.CurrentSketch.DOF > 0)
          this.CurrentSketch.UpdateAndInvalidate();
      }
      if (Sketcher2D.buttonPressedForSelection & Sketcher2D.selectionProcess)
      {
        int num = mea.Location.X - Sketcher2D.mouseDownLocation.X;
        if (num > 10)
        {
          if (!clsVar.varSelection.DontUseRectangleSelection)
            Sketcher2D.currPickState = pickStateType.Enclosed;
        }
        else if (num < -10)
        {
          if (!clsVar.varSelection.DontUseRectangleSelection)
            Sketcher2D.currPickState = pickStateType.Crossing;
        }
        else
          Sketcher2D.currPickState = pickStateType.Pick;
        if (ccVars.selectionOnlyPick)
          Sketcher2D.currPickState = pickStateType.Pick;
      }
      if (clsInit.appEditor.action == actionTypeBU.eventTrim)
        this.method_4();
      Point3D point3D1 = this.mouseWorldLoc;
      if ((object) point3D1 == null)
        point3D1 = Point3D.Origin;
      this.mouseWorldLoc = point3D1;
      Sketcher2D.mousePlnLoc = Plane.XY.Project(this.mouseWorldLoc);
      this.point_2 = this.mouseloc;
      if (clsItem.frmEditor != null)
      {
        clsItem.frmEditor.lbl_x.Text = "X: " + this.mouseWorldLoc.X.ToString("f2");
        clsItem.frmEditor.lbl_y.Text = "Y: " + this.mouseWorldLoc.Y.ToString("f2");
      }
      if (clsItem.frmEditor != null)
        clsItem.frmEditor.Viewport_MouseMove((object) null, mea);
      this.Invalidate();
      base.OnMouseMove(mea);
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnMouseDown(MouseEventArgs mea)
  {
    try
    {
      Entity entity = (Entity) null;
      this.iselectableItem_0 = (ISelectableItem) this.GetEntityByPosition(mea.Location);
      if (this.iselectableItem_0 is Entity)
      {
        entity = (Entity) this.iselectableItem_0;
        if (clsInit.appEditor.action == actionTypeBU.None && clsVar.varEditorRuntimeSet.isSketchMode)
        {
          this.bool_1 = true;
          if (!entity.Selected)
          {
            this.CurrentSketch.DragStart(Sketcher2D.mousePlnLoc, entity);
            entity.Selected = true;
          }
          else
          {
            this.ActionMode = devDept.Eyeshot.actionType.None;
            this.CurrentSketch.DragStart(Sketcher2D.mousePlnLoc, this.Entities.Where<Entity>((Func<Entity, bool>) (entity_0 => entity_0.Selected)).ToArray<Entity>());
          }
        }
      }
      if (this.mouseWorldLoc == (Point3D) null)
        return;
      this.int_2 = -1;
      int[] underMouseCursor = this.GetAllEntitiesUnderMouseCursor(mea.Location);
      this.int_2 = this.GetEntityUnderMouseCursor(mea.Location);
      Sketcher2D.entitySelected = (Entity) null;
      if (mea.Button == MouseButtons.Left & Sketcher2D.selectionProcess & Sketcher2D.selectionProcess & !Sketcher2D.ForbiddenAreaClicked & !this.bool_1)
      {
        Sketcher2D.buttonPressedForSelection = true;
        Sketcher2D.mouseDownLocation = mea.Location;
        Sketcher2D.currPickState = pickStateType.Pick;
      }
      if (mea.Button == MouseButtons.Left)
      {
        if (clsInit.appEditor.action != 0 & !Sketcher2D.selectionProcess)
          Sketcher2D.Clicks.Add(new UClick(Sketcher2D.mousePlnLoc, new Point3D(Sketcher2D.mousePlnLoc.X, Sketcher2D.mousePlnLoc.Y), entity, this.bool_0));
        this.mouseLastClick.X = this.mouseWorldLoc.X;
        this.mouseLastClick.Y = this.mouseWorldLoc.Y;
        this.MouseDownDrawings(entity, mea);
        if (!Sketcher2D.selectionProcess)
          this.MouseDownEvents(underMouseCursor, mea);
        if (clsInit.appEditor.action == actionTypeBU.sewingSorting)
        {
          clsInit.appSewing.doSortMainEntitiesByRefPoint(this.mouseWorldLoc, clsSewing.varSewingRunSettings.NextRules);
          clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, this.Entities);
        }
        if (clsInit.appEditor.action == actionTypeBU.sewingPunteriz)
        {
          clsInit.appSewing.doDefinePunteriz(this.mouseWorldLoc, clsSewing.varSewingRunSettings.ShowDialog);
          clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, this.Entities);
        }
        if (clsInit.appEditor.action == actionTypeBU.sewingLockStitch)
        {
          clsInit.appSewing.doDefineLockStitch(this.mouseWorldLoc, clsSewing.varSewingRunSettings.ShowDialog);
          clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, this.Entities);
        }
        if (clsInit.appEditor.action == actionTypeBU.sewingScale)
        {
          clsInit.appSewing.Selected.Clear();
          clsInit.appSewing.doDefineScale(this.mouseWorldLoc, clsSewing.varSewingRunSettings.ShowDialog);
        }
        if (clsInit.appEditor.action == actionTypeBU.sewingRotate)
        {
          clsInit.appSewing.Selected.Clear();
          clsInit.appSewing.doDefineRotate(this.mouseWorldLoc, clsSewing.varSewingRunSettings.ShowDialog);
        }
        if (clsInit.appEditor.action == actionTypeBU.sewingDeleteVertex)
        {
          clsInit.appSewing.Selected.Clear();
          clsInit.appSewing.doDeleteVertex(this.mouseWorldLoc);
        }
        if (clsInit.appEditor.action == actionTypeBU.sewingMoveVertex | clsInit.appEditor.action == actionTypeBU.sewingFootHeight | clsInit.appEditor.action == actionTypeBU.sewingChangeDirection | clsInit.appEditor.action == actionTypeBU.sewingSpeed)
        {
          clsInit.appSewing.Selected.Clear();
          clsInit.appSewing.doDefineSelectVertex(this.mouseWorldLoc, clsInit.appEditor.action);
        }
        if (clsInit.appEditor.action == actionTypeBU.sewingAddCode)
        {
          clsInit.appSewing.doDefineAddCodes(this.mouseWorldLoc);
          clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, this.Entities);
          clsInit.appSewing.JobUpdate();
        }
        if (clsInit.appEditor.action == actionTypeBU.miscAutoSort)
          clsInit.appEditor.ManuelSort(this.mouseWorldLoc);
        if (clsInit.appEditor.action == actionTypeBU.libraryVertical && (entity == null ? 0 : (entity is Line ? 1 : 0)) != 0)
          clsInit.appEditor.CreateConstraintVertical((Line) entity);
        if (clsInit.appEditor.action == actionTypeBU.libraryHorizontal && (entity == null ? 0 : (entity is Line ? 1 : 0)) != 0)
          clsInit.appEditor.CreateConstraintHorizontal((Line) entity);
        if (clsInit.appEditor.action == actionTypeBU.libraryLength)
        {
          if (Sketcher2D.isSelectionDone & Sketcher2D.entitiesSelected.Count > 0)
          {
            clsInit.appEditor.CreateConstraintLength((Line) Sketcher2D.entitiesSelected[0], (Point2D) this.mouseWorldLoc);
            Sketcher2D.isSelectionDone = false;
            Sketcher2D.entitiesSelected.Clear();
          }
          if ((entity == null ? 0 : (entity is Line ? 1 : 0)) != 0)
          {
            Sketcher2D.entitySelected = entity;
            Sketcher2D.entitiesSelected.Add(entity);
          }
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryRadius)
        {
          if (Sketcher2D.isSelectionDone & Sketcher2D.entitiesSelected.Count > 0)
          {
            clsInit.appEditor.CreateConstraintDiameter((Circle) Sketcher2D.entitiesSelected[0]);
            Sketcher2D.isSelectionDone = false;
            Sketcher2D.entitiesSelected.Clear();
          }
          if ((entity == null ? 0 : (entity is Circle ? 1 : 0)) != 0)
          {
            Sketcher2D.entitySelected = entity;
            Sketcher2D.entitiesSelected.Add(entity);
          }
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryFixPoint)
          clsInit.appEditor.CreateConstraintFixPoint(entity, this.mouseWorldLoc);
        if (clsInit.appEditor.action == actionTypeBU.libraryAngle)
        {
          if ((entity == null ? 0 : (entity is Arc & !Sketcher2D.isSelectionDone ? 1 : 0)) != 0)
          {
            entity.Selected = true;
            Sketcher2D.entitiesSelected.Add(entity);
            return;
          }
          if (Sketcher2D.entitiesSelected.Count == 1 & Sketcher2D.isSelectionDone)
            clsInit.appEditor.CreateConstraintAngle((Arc) Sketcher2D.entitiesSelected[0], (Point2D) this.mouseWorldLoc);
          if ((entity == null ? 0 : (entity is Line & !Sketcher2D.isSelectionDone ? 1 : 0)) != 0)
          {
            entity.Selected = true;
            Sketcher2D.entitiesSelected.Add(entity);
            if (Sketcher2D.entitiesSelected.Count == 2)
            {
              Line L1 = Sketcher2D.entitiesSelected[0] as Line;
              Line L2 = Sketcher2D.entitiesSelected[1] as Line;
              clsInit.appEditor.AngleCalculation(ref L1, ref L2);
            }
          }
          if (Sketcher2D.entitiesSelected.Count == 2 & Sketcher2D.isSelectionDone)
            clsInit.appEditor.CreateConstraintAngle((Line) Sketcher2D.entitiesSelected[0], (Line) Sketcher2D.entitiesSelected[1], (Point2D) this.mouseWorldLoc);
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryFillet)
        {
          if ((entity == null ? 0 : (entity is Line | entity is Arc | entity is Curve ? 1 : 0)) != 0)
          {
            entity.Selected = true;
            Sketcher2D.entitiesSelected.Add(entity);
          }
          if (Sketcher2D.entitiesSelected.Count == 2)
          {
            clsInit.appEditor.FilletChamferCalculation(true);
            Sketcher2D.entitiesSelected.Clear();
          }
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryChamfer)
        {
          if ((entity == null ? 0 : (entity is Line | entity is Arc | entity is Curve ? 1 : 0)) != 0)
          {
            entity.Selected = true;
            Sketcher2D.entitiesSelected.Add(entity);
          }
          if (Sketcher2D.entitiesSelected.Count == 2)
          {
            clsInit.appEditor.FilletChamferCalculation(false);
            Sketcher2D.entitiesSelected.Clear();
          }
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryEqualLength)
        {
          if ((entity == null ? 0 : (entity is ICurve ? 1 : 0)) != 0)
          {
            entity.Selected = true;
            Sketcher2D.entitiesSelected.Add(entity);
          }
          if (Sketcher2D.entitiesSelected.Count == 2)
          {
            clsInit.appEditor.CreateConstraintEqualLength(Sketcher2D.entitiesSelected[0], Sketcher2D.entitiesSelected[1], false);
            Sketcher2D.entitiesSelected.Clear();
          }
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryEqualRadius)
        {
          if ((entity == null ? 0 : (entity is Circle | entity is Arc ? 1 : 0)) != 0)
          {
            entity.Selected = true;
            Sketcher2D.entitiesSelected.Add(entity);
          }
          if (Sketcher2D.entitiesSelected.Count == 2)
          {
            clsInit.appEditor.CreateConstraintEqualLength(Sketcher2D.entitiesSelected[0], Sketcher2D.entitiesSelected[1], true);
            Sketcher2D.entitiesSelected.Clear();
          }
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryLineLine)
        {
          if ((entity == null ? 0 : (entity is Line & !Sketcher2D.isSelectionDone ? 1 : 0)) != 0)
          {
            entity.Selected = true;
            Sketcher2D.entitiesSelected.Add(entity);
          }
          if (Sketcher2D.entitiesSelected.Count == 2 & Sketcher2D.isSelectionDone)
          {
            clsInit.appEditor.CreateConstraintLineLineDistance((Line) Sketcher2D.entitiesSelected[0], (Line) Sketcher2D.entitiesSelected[1], (Point2D) this.mouseWorldLoc);
            Sketcher2D.entitiesSelected.Clear();
          }
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryLinePoint)
        {
          if ((entity == null || Sketcher2D.entitiesSelected.Count != 0 ? 0 : ((entity is Line | entity is devDept.Eyeshot.Entities.Point) & !Sketcher2D.isSelectionDone ? 1 : 0)) != 0)
          {
            entity.Selected = true;
            Sketcher2D.entitiesSelected.Add(entity);
            return;
          }
          bool flag = false;
          if ((entity == null || Sketcher2D.entitiesSelected.Count != 1 ? 0 : ((entity is Line | entity is devDept.Eyeshot.Entities.Point) & !Sketcher2D.isSelectionDone ? 1 : 0)) != 0)
          {
            if (Sketcher2D.entitiesSelected[0] is Line & entity is devDept.Eyeshot.Entities.Point)
            {
              entity.Selected = true;
              Sketcher2D.entitiesSelected.Add(entity);
              flag = true;
            }
            else if (Sketcher2D.entitiesSelected[0] is devDept.Eyeshot.Entities.Point & entity is Line)
            {
              entity.Selected = true;
              Sketcher2D.entitiesSelected.Add(entity);
              flag = true;
            }
          }
          if (!flag && Sketcher2D.entitiesSelected.Count == 1 && Sketcher2D.entitiesSelected[0] is Line)
          {
            for (int index = 0; index <= this.Entities.Count - 1; ++index)
            {
              if (this.Entities[index] is devDept.Eyeshot.Entities.Point && Point3D.Distance(((devDept.Eyeshot.Entities.Point) this.Entities[index]).Position, this.mouseWorldLoc) < 0.1)
              {
                entity = this.Entities[index];
                entity.Selected = true;
                Sketcher2D.entitiesSelected.Add(entity);
                index = this.Entities.Count;
              }
            }
          }
          if (Sketcher2D.entitiesSelected.Count == 2 & Sketcher2D.isSelectionDone)
          {
            if (Sketcher2D.entitiesSelected[0] is Line & Sketcher2D.entitiesSelected[1] is devDept.Eyeshot.Entities.Point)
              clsInit.appEditor.CreateConstraintLinePointDistance((devDept.Eyeshot.Entities.Point) Sketcher2D.entitiesSelected[1], (Line) Sketcher2D.entitiesSelected[0], (Point2D) this.mouseWorldLoc);
            else if (Sketcher2D.entitiesSelected[0] is devDept.Eyeshot.Entities.Point & Sketcher2D.entitiesSelected[1] is Line)
              clsInit.appEditor.CreateConstraintLinePointDistance((devDept.Eyeshot.Entities.Point) Sketcher2D.entitiesSelected[0], (Line) Sketcher2D.entitiesSelected[1], (Point2D) this.mouseWorldLoc);
            Sketcher2D.entitiesSelected.Clear();
          }
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryPointPoint)
        {
          bool flag = false;
          if (entity != null & !Sketcher2D.isSelectionDone && entity is devDept.Eyeshot.Entities.Point)
          {
            entity.Selected = true;
            Sketcher2D.entitiesSelected.Add(entity);
            flag = true;
          }
          if (!flag & !Sketcher2D.isSelectionDone)
          {
            for (int index = 0; index <= this.Entities.Count - 1; ++index)
            {
              if (this.Entities[index] is devDept.Eyeshot.Entities.Point && Point3D.Distance(((devDept.Eyeshot.Entities.Point) this.Entities[index]).Position, this.mouseWorldLoc) < 0.1)
              {
                entity = this.Entities[index];
                entity.Selected = true;
                Sketcher2D.entitiesSelected.Add(entity);
              }
            }
          }
          if (Sketcher2D.entitiesSelected.Count == 2 & Sketcher2D.isSelectionDone)
          {
            if (Vector3D.AreParallel(this.plane_0.AxisX, clsItem.frmEditor.viewport.CurrentSketch.Plane.AxisX))
              clsInit.appEditor.CreateConstraintPointPointHorizontalDistance((devDept.Eyeshot.Entities.Point) Sketcher2D.entitiesSelected[0], (devDept.Eyeshot.Entities.Point) Sketcher2D.entitiesSelected[1], (Point2D) this.mouseWorldLoc);
            else if (Vector3D.AreParallel(this.plane_0.AxisX, clsItem.frmEditor.viewport.CurrentSketch.Plane.AxisY))
              clsInit.appEditor.CreateConstraintPointPointVerticalDistance((devDept.Eyeshot.Entities.Point) Sketcher2D.entitiesSelected[0], (devDept.Eyeshot.Entities.Point) Sketcher2D.entitiesSelected[1], (Point2D) this.mouseWorldLoc);
            else
              clsInit.appEditor.CreateConstraintPointPointAlignedDistance((devDept.Eyeshot.Entities.Point) Sketcher2D.entitiesSelected[0], (devDept.Eyeshot.Entities.Point) Sketcher2D.entitiesSelected[1], (Point2D) this.mouseWorldLoc);
            Sketcher2D.entitiesSelected.Clear();
          }
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryCollinear && (entity == null ? 0 : (entity is Line ? 1 : 0)) != 0)
        {
          entity.Selected = true;
          Sketcher2D.entitiesSelected.Add(entity);
          if (Sketcher2D.entitiesSelected.Count == 2)
          {
            Line L1 = Sketcher2D.entitiesSelected[0] as Line;
            Line L2 = Sketcher2D.entitiesSelected[1] as Line;
            clsInit.appEditor.CreateConstraintCollinear(L1, L2);
          }
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryParalel && (entity == null ? 0 : (entity is Line ? 1 : 0)) != 0)
        {
          entity.Selected = true;
          Sketcher2D.entitiesSelected.Add(entity);
          if (Sketcher2D.entitiesSelected.Count == 2)
          {
            Line L1 = Sketcher2D.entitiesSelected[0] as Line;
            Line L2 = Sketcher2D.entitiesSelected[1] as Line;
            clsInit.appEditor.CreateConstraintParallel(L1, L2);
          }
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryPerpendiculat && (entity == null ? 0 : (entity is Line ? 1 : 0)) != 0)
        {
          entity.Selected = true;
          Sketcher2D.entitiesSelected.Add(entity);
          if (Sketcher2D.entitiesSelected.Count == 2)
          {
            Line L1 = Sketcher2D.entitiesSelected[0] as Line;
            Line L2 = Sketcher2D.entitiesSelected[1] as Line;
            clsInit.appEditor.CreateConstraintPerpendicular(L1, L2);
          }
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryTangent && (entity == null ? 0 : (entity is ICurve ? 1 : 0)) != 0)
        {
          entity.Selected = true;
          Sketcher2D.entitiesSelected.Add(entity);
          if (Sketcher2D.entitiesSelected.Count == 2)
            clsInit.appEditor.CreateConstraintTangent(Sketcher2D.entitiesSelected[0], Sketcher2D.entitiesSelected[1]);
        }
        if (clsInit.appEditor.action == actionTypeBU.libraryDeleteEntity && (entity == null ? 0 : (entity is ICurve ? 1 : 0)) != 0)
          clsInit.appEditor.cmdDeleteEntity(entity);
      }
      if (mea.Button == MouseButtons.Right)
      {
        if (clsInit.appEditor.action == actionTypeBU.drawSpline)
        {
          if (Sketcher2D.Clicks.Count == 1)
          {
            if (clsVar.varEditorRuntimeSet.isSketchMode)
            {
              this.point_0 = Sketcher2D.Clicks[0].Entity is devDept.Eyeshot.Entities.Point ? (devDept.Eyeshot.Entities.Point) Sketcher2D.Clicks[0].Entity : clsItem.frmEditor.viewport.CurrentSketch.AddPoint(Sketcher2D.Clicks[0].Position);
              return;
            }
            this.point_0 = new devDept.Eyeshot.Entities.Point(Sketcher2D.Clicks[0].Position.X, Sketcher2D.Clicks[0].Position.Y);
          }
          if (buCompare5.EQ(Sketcher2D.Clicks[0].Position, Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Position, 0.5))
          {
            Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Position = new Point2D(Sketcher2D.Clicks[0].Position.X, Sketcher2D.Clicks[0].Position.Y);
            if (Sketcher2D.Clicks.Last<UClick>().Position == (Point2D) this.point_0.Position)
              clsInit.appEditor.AddSpline(this.point_0, Sketcher2D.Clicks);
          }
          else
            clsInit.appEditor.AddSpline(this.point_0, Sketcher2D.Clicks);
        }
        if (clsInit.appEditor.action == actionTypeBU.eventAlingLeft | clsInit.appEditor.action == actionTypeBU.eventAlingRight | clsInit.appEditor.action == actionTypeBU.eventAlingTop | clsInit.appEditor.action == actionTypeBU.eventAlingBottom | clsInit.appEditor.action == actionTypeBU.eventAlingHorizontal | clsInit.appEditor.action == actionTypeBU.eventAlingVertical)
          clsInit.appEditor.Align();
        if (clsInit.appEditor.action == actionTypeBU.eventEqualHorizontal | clsInit.appEditor.action == actionTypeBU.eventEqualVertical)
          clsInit.appEditor.EqualDistanceEvent((double) clsItem.frmEditor.spn_value.Value);
        if (clsInit.appEditor.action == actionTypeBU.eventRotateValue)
          clsInit.appEditor.Rotate(clsVar.varEditorRuntimeSet.LastRotateAngle);
        if (clsInit.appEditor.action == actionTypeBU.eventMirrorValue)
          clsInit.appEditor.Mirror(clsVar.varEditorRuntimeSet.LastMirrorType);
        if (clsInit.appEditor.action == actionTypeBU.eventTurnOver)
          clsInit.appEditor.TurnOver();
        ++Sketcher2D.rightClickCnt;
        int num = 1;
        if (clsInit.appEditor.action != 0 & Sketcher2D.selectionProcess)
          num = 2;
        if (Sketcher2D.rightClickCnt >= num)
        {
          clsInit.appEditor.Reset();
          Sketcher2D.Clicks.Clear();
          Sketcher2D.entitiesSelected.Clear();
          Sketcher2D.selectedIndex.Clear();
          Sketcher2D.entitySelected = (Entity) null;
          clsInit.appEditor.action = actionTypeBU.None;
          this.ActionMode = devDept.Eyeshot.actionType.None;
          Sketcher2D.isDrawing = false;
        }
      }
      base.OnMouseDown(mea);
    }
    catch (Exception ex)
    {
    }
  }

  public void MouseDownDrawings(Entity ent, MouseEventArgs mea)
  {
    if (clsInit.appEditor.action == actionTypeBU.drawPoint)
    {
      if (ent != null)
      {
        if (Sketcher2D.Clicks.Count == 1)
          clsInit.appEditor.AddPoint(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1]);
      }
      else if (!clsVar.varEditorRuntimeSet.isSketchMode)
        clsInit.appEditor.AddPoint(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1]);
    }
    if (clsInit.appEditor.action == actionTypeBU.drawLine)
    {
      if (Sketcher2D.Clicks.Count >= 1)
        Sketcher2D.OrthoPossible = true;
      if (Sketcher2D.Clicks.Count == 2)
        Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Entity = (Entity) clsInit.appEditor.AddLine(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 2], Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1]);
      else if (Sketcher2D.Clicks.Count > 2)
      {
        if (clsVar.varEditorRuntimeSet.isSketchMode)
          Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Entity = (Entity) clsInit.appEditor.ExtendLine((Line) Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 2].Entity, Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1]);
        else
          clsInit.appEditor.AddLine(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 2], Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1]);
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.drawCircle)
    {
      if (Sketcher2D.Clicks.Count >= 1)
        Sketcher2D.OrthoPossible = true;
      if (Sketcher2D.Clicks.Count >= 2)
        Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Entity = (Entity) clsInit.appEditor.AddCircle(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 2], Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1]);
    }
    if (clsInit.appEditor.action == actionTypeBU.drawCircle3Point)
    {
      if (Sketcher2D.Clicks.Count >= 1)
        Sketcher2D.OrthoPossible = true;
      if (Sketcher2D.Clicks.Count >= 2)
        Sketcher2D.OrthoPossible = false;
      if (Sketcher2D.Clicks.Count >= 3)
        clsInit.appEditor.AddCircle(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 3], Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 2], Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1]);
    }
    if (clsInit.appEditor.action == actionTypeBU.drawArc3PointSEM)
    {
      if (Sketcher2D.Clicks.Count >= 1)
        Sketcher2D.OrthoPossible = true;
      if (Sketcher2D.Clicks.Count >= 2)
        Sketcher2D.OrthoPossible = false;
      if (Sketcher2D.Clicks.Count >= 3)
        Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Entity = (Entity) clsInit.appEditor.AddArc(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 3], Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1], Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 2]);
    }
    if (clsInit.appEditor.action == actionTypeBU.drawRectangle && Sketcher2D.Clicks.Count == 2)
      clsInit.appEditor.AddRectangle(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 2], Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1]);
    if (clsInit.appEditor.action == actionTypeBU.drawEllipse && Sketcher2D.Clicks.Count == 2)
      clsInit.appEditor.AddEllipse(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 2], Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1]);
    if (clsInit.appEditor.action == actionTypeBU.drawPolygon)
    {
      if (Sketcher2D.Clicks.Count >= 1)
        Sketcher2D.OrthoPossible = true;
      if (Sketcher2D.Clicks.Count == 2)
        clsInit.appEditor.AddPolygon(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 2], Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1]);
    }
    if (clsInit.appEditor.action == actionTypeBU.drawKeyHole && Sketcher2D.Clicks.Count >= 1)
      clsInit.appEditor.AddKeyHole(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1]);
    if (clsInit.appEditor.action == actionTypeBU.drawSlot)
    {
      if (Sketcher2D.Clicks.Count >= 1)
        Sketcher2D.OrthoPossible = true;
      if (Sketcher2D.Clicks.Count >= 2)
        Sketcher2D.OrthoPossible = false;
      if (Sketcher2D.Clicks.Count == 3)
        clsInit.appEditor.AddSLot(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 3], Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 2], Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1]);
    }
    if (clsInit.appEditor.action == actionTypeBU.drawSpline)
    {
      if (Sketcher2D.Clicks.Count == 1)
      {
        if (clsVar.varEditorRuntimeSet.isSketchMode)
        {
          this.point_0 = Sketcher2D.Clicks[0].Entity is devDept.Eyeshot.Entities.Point ? (devDept.Eyeshot.Entities.Point) Sketcher2D.Clicks[0].Entity : clsItem.frmEditor.viewport.CurrentSketch.AddPoint(Sketcher2D.Clicks[0].Position);
          return;
        }
        this.point_0 = new devDept.Eyeshot.Entities.Point(Sketcher2D.Clicks[0].Position.X, Sketcher2D.Clicks[0].Position.Y);
      }
      if (buCompare5.EQ(Sketcher2D.Clicks[0].Position, Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Position, 0.5))
      {
        Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Position = new Point2D(Sketcher2D.Clicks[0].Position.X, Sketcher2D.Clicks[0].Position.Y);
        if (Sketcher2D.Clicks.Last<UClick>().Position == (Point2D) this.point_0.Position)
          clsInit.appEditor.AddSpline(this.point_0, Sketcher2D.Clicks);
      }
    }
    if (clsInit.appEditor.action != actionTypeBU.drawMeasure)
      return;
    if (Sketcher2D.Clicks.Count >= 1)
      Sketcher2D.OrthoPossible = true;
    if (Sketcher2D.Clicks.Count < 2)
      return;
    Sketcher2D.Clicks.RemoveAt(0);
  }

  public void MouseDownEvents(int[] indx, MouseEventArgs mea)
  {
    if (clsInit.appEditor.action == actionTypeBU.eventMove)
    {
      if (Sketcher2D.Clicks.Count == 1)
      {
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[1], buLangTranslate.preDef.Move);
        Sketcher2D.OrthoPossible = true;
      }
      else if (Sketcher2D.Clicks.Count == 2)
      {
        clsInit.appEditor.UndoBuffer();
        foreach (Entity entity in Sketcher2D.entitiesSelected)
          entity.Translate(new Vector3D(Sketcher2D.Clicks[0].Pnt3D, Sketcher2D.Clicks[1].Pnt3D));
        clsItem.frmEditor.viewport.Entities.Regen();
        clsInit.appEditor.Reset();
        return;
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventCopy)
    {
      if (Sketcher2D.Clicks.Count == 1)
      {
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[1], buLangTranslate.preDef.Copy);
        Sketcher2D.OrthoPossible = true;
      }
      else if (Sketcher2D.Clicks.Count == 2)
      {
        clsInit.appEditor.UndoBuffer();
        List<Entity> refEntities = (List<Entity>) null;
        if (clsVar.varEditorRuntimeSet.isSewingMode)
          refEntities = new List<Entity>();
        foreach (Entity refEntity in Sketcher2D.entitiesSelected)
        {
          Entity copiedEntity1 = (Entity) null;
          buEntity.Copy(refEntity, ref copiedEntity1);
          if (copiedEntity1 != null)
          {
            Vector3D v = new Vector3D(Sketcher2D.Clicks[0].Pnt3D, Sketcher2D.Clicks[1].Pnt3D);
            copiedEntity1.Translate(v);
            copiedEntity1.ColorMethod = colorMethodType.byEntity;
            copiedEntity1.Color = clsVar.varEditorSet.colorEntity;
            copiedEntity1.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
            copiedEntity1.LineWeightMethod = colorMethodType.byEntity;
            if (clsVar.varEditorRuntimeSet.isSewingMode)
            {
              Entity copiedEntity2 = (Entity) null;
              buEntity.Copy(copiedEntity1, ref copiedEntity2);
              refEntities.Add(copiedEntity2);
            }
            clsItem.frmEditor.viewport.Entities.Add(copiedEntity1);
          }
        }
        clsItem.frmEditor.viewport.Entities.Regen();
        clsInit.appEditor.Reset();
        if (!clsVar.varEditorRuntimeSet.isSewingMode || !(clsInit.appSewing != null & refEntities != null))
          return;
        clsInit.appSewing.doAddEntities(refEntities);
        return;
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventMirror)
    {
      if (Sketcher2D.Clicks.Count == 1)
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[122], buLangTranslate.preDef.Mirror);
      else if (Sketcher2D.Clicks.Count == 2)
      {
        List<Entity> entityList = new List<Entity>();
        clsInit.appEditor.UndoBuffer();
        foreach (Entity entity1 in Sketcher2D.entitiesSelected)
        {
          if ((Sketcher2D.Clicks[1].Pnt3D.X < Sketcher2D.Clicks[0].Pnt3D.X ? 1 : (Sketcher2D.Clicks[1].Pnt3D.Y < Sketcher2D.Clicks[0].Pnt3D.Y ? 1 : 0)) != 0)
          {
            Point3D pnt3D1 = Sketcher2D.Clicks[0].Pnt3D;
            Point3D pnt3D2 = Sketcher2D.Clicks[1].Pnt3D;
            Utility.Swap<Point3D>(ref pnt3D1, ref pnt3D2);
            Sketcher2D.Clicks[0].Pnt3D = pnt3D1;
            Sketcher2D.Clicks[1].Pnt3D = pnt3D2;
          }
          Vector3D X = new Vector3D(Sketcher2D.Clicks[0].Pnt3D, Sketcher2D.Clicks[1].Pnt3D);
          Plane plane = new Plane(Sketcher2D.Clicks[0].Pnt3D, X, Vector3D.AxisZ);
          Entity entity2 = (Entity) entity1.Clone();
          Mirror xform = new Mirror(plane);
          entity2.TransformBy((Transformation) xform);
          entity2.ColorMethod = colorMethodType.byEntity;
          entity2.Color = clsVar.varEditorSet.colorEntity;
          entity2.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
          entity2.LineWeightMethod = colorMethodType.byEntity;
          entityList.Add(entity2);
        }
        clsItem.frmEditor.viewport.Entities.DeleteSelected();
        for (int index = 0; index <= entityList.Count - 1; ++index)
          clsItem.frmEditor.viewport.Entities.Add(entityList[index]);
        clsItem.frmEditor.viewport.Entities.Regen();
        clsInit.appEditor.Reset();
        return;
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventOffset)
    {
      clsInit.appEditor.UndoBuffer();
      foreach (Entity entity in Sketcher2D.entitiesSelected)
      {
        Entity selEntity = (Entity) entity.Clone();
        Entity entityOffseted = (Entity) null;
        if (!clsInit.appEditor.Offset(selEntity, this.mouseWorldLoc, ref entityOffseted))
          return;
        if (entityOffseted != null)
        {
          entityOffseted.ColorMethod = colorMethodType.byEntity;
          entityOffseted.Color = clsVar.varEditorSet.colorEntity;
          entityOffseted.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
          entityOffseted.LineWeightMethod = colorMethodType.byEntity;
          if (clsInit.appSewing != null)
          {
            clsInit.appSewing.doOffset(entityOffseted);
            return;
          }
          clsItem.frmEditor.viewport.Entities.Add(entityOffseted);
          clsItem.frmEditor.viewport.Entities.Regen();
          clsInit.appEditor.Reset();
          clsInit.appEditor.cmdEventsOffset();
          return;
        }
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventRotate)
    {
      if (Sketcher2D.Clicks.Count == 1)
      {
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[21], buLangTranslate.preDef.Rotate);
        Sketcher2D.OrthoPossible = true;
      }
      else if (Sketcher2D.Clicks.Count == 2)
      {
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[21], buLangTranslate.preDef.Rotate);
        Sketcher2D.OrthoPossible = false;
      }
      else if (Sketcher2D.Clicks.Count == 3)
      {
        double double_1 = 0.0;
        clsInit.appEditor.UndoBuffer();
        this.method_3(ref double_1);
        foreach (Entity entity in Sketcher2D.entitiesSelected)
        {
          entity.Rotate(double_1, Vector3D.AxisZ, Sketcher2D.Clicks[0].Pnt3D);
          if (entity is devDept.Eyeshot.Entities.Text)
            entity.Regen(new RegenParams(0.0, (IWorkspace) this));
        }
        clsItem.frmEditor.viewport.Entities.Regen();
        clsInit.appEditor.Reset();
        return;
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventBreak && Sketcher2D.entityMouseUnder != null & indx.Length != 0)
    {
      clsInit.appEditor.UndoBuffer();
      if (Sketcher2D.entityMouseUnder is Entity & indx[0] >= 0 & indx[0] <= this.Entities.Count - 1)
      {
        Entity entityFirst = (Entity) null;
        Entity entitySecond = (Entity) null;
        clsInit.appEditor.Break((Entity) Sketcher2D.entityMouseUnder, this.mouseWorldLoc, ref entityFirst, ref entitySecond);
        if (entityFirst != null & entitySecond != null)
        {
          this.Entities.RemoveAt(indx[0]);
          entityFirst.ColorMethod = colorMethodType.byEntity;
          entityFirst.Color = clsVar.varEditorSet.colorEntity;
          entityFirst.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
          entityFirst.LineWeightMethod = colorMethodType.byEntity;
          entitySecond.ColorMethod = colorMethodType.byEntity;
          entitySecond.Color = clsVar.varEditorSet.colorEntity;
          entitySecond.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
          entitySecond.LineWeightMethod = colorMethodType.byEntity;
          this.Entities.Add(entityFirst);
          this.Entities.Add(entitySecond);
          clsItem.frmEditor.viewport.Entities.Regen();
          clsInit.appEditor.Reset();
          clsInit.appEditor.cmdEventsBreak();
          return;
        }
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventScale)
    {
      if (Sketcher2D.Clicks.Count == 1)
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[32 /*0x20*/], buLangTranslate.preDef.Scale);
      else if (Sketcher2D.Clicks.Count == 2)
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[32 /*0x20*/], buLangTranslate.preDef.Scale);
      else if (Sketcher2D.Clicks.Count == 3 && Sketcher2D.Clicks[0].Pnt3D.DistanceTo(Sketcher2D.Clicks[1].Pnt3D) > 0.0)
      {
        clsInit.appEditor.UndoBuffer();
        double factor = Sketcher2D.Clicks[0].Pnt3D.DistanceTo(this.mouseWorldLoc) / Sketcher2D.Clicks[0].Pnt3D.DistanceTo(Sketcher2D.Clicks[1].Pnt3D);
        foreach (Entity entity in Sketcher2D.entitiesSelected)
        {
          if (factor >= 0.01)
            entity.Scale(Sketcher2D.Clicks[0].Pnt3D, factor);
        }
        clsItem.frmEditor.viewport.Entities.Regen();
        clsInit.appEditor.Reset();
        return;
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventExtend && Sketcher2D.entityMouseUnder != null & this.int_0.Length >= 0 && Sketcher2D.entityMouseUnder is Entity & this.int_0[0] >= 0 & this.int_0[0] <= this.Entities.Count - 1)
    {
      Entity entityExtended = (Entity) null;
      clsInit.appCommand.Extend(clsItem.frmEditor.viewport.Entities, this.int_0[0], this.mouseWorldLoc, clsVar.varEditorRuntimeSet.ExtendLength, ref entityExtended);
      if (entityExtended != null)
      {
        clsInit.appEditor.UndoBuffer();
        this.Entities.RemoveAt(this.int_0[0]);
        entityExtended.ColorMethod = colorMethodType.byEntity;
        entityExtended.Color = clsVar.varEditorSet.colorEntity;
        entityExtended.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
        entityExtended.LineWeightMethod = colorMethodType.byEntity;
        this.Entities.Add(entityExtended);
        clsItem.frmEditor.viewport.Entities.Regen();
        clsInit.appEditor.Reset();
        clsInit.appEditor.cmdEventsExtend();
        return;
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventTrim)
    {
      int underMouseCursor = this.GetEntityUnderMouseCursor(mea.Location);
      if (underMouseCursor == -1)
        return;
      Entity entity = this.Entities[underMouseCursor];
      if (entity == null)
        return;
      clsInit.appEditor.UndoBuffer();
      List<Entity> leftOverEntities;
      if (Utility.Trim((IDesign) this, mea.Location, out leftOverEntities))
        this.Entities.AddRange((IEnumerable<Entity>) leftOverEntities);
      else
        this.Entities.Remove(entity);
      this.Entities.Regen();
    }
    if (clsInit.appEditor.action == actionTypeBU.eventFillet)
      this.method_1();
    if (clsInit.appEditor.action != actionTypeBU.eventChamfer)
      return;
    this.method_2();
  }

  protected override void OnMouseUp(MouseEventArgs mea)
  {
    int[] selectedIndices = (int[]) null;
    this.int_1 = -1;
    if (Sketcher2D.selectionProcess & mea.Button == MouseButtons.Left & Sketcher2D.buttonPressedForSelection)
    {
      List<int> intList1 = new List<int>();
      List<int> intList2 = new List<int>();
      if (Sketcher2D.buttonPressedForSelection)
      {
        if (this.CurrentBlockReference != null)
        {
          EntityList entities = this.Blocks[this.CurrentBlockReference.BlockName].Entities;
        }
        else
        {
          List<Entity> entityList = new List<Entity>((IEnumerable<Entity>) this.Entities);
        }
        Sketcher2D.buttonPressedForSelection = false;
        System.Drawing.Point location1 = mea.Location;
        int num1 = location1.X - Sketcher2D.mouseDownLocation.X;
        location1 = mea.Location;
        int num2 = location1.Y - Sketcher2D.mouseDownLocation.Y;
        System.Drawing.Point mouseDownLocation = Sketcher2D.mouseDownLocation;
        System.Drawing.Point location2 = mea.Location;
        Class5.smethod_87(ref mouseDownLocation, ref location2);
        switch (Sketcher2D.currPickState)
        {
          case pickStateType.Pick:
            this.int_1 = this.GetEntityUnderMouseCursor(mea.Location);
            int[] underMouseCursor = this.GetAllEntitiesUnderMouseCursor(mea.Location);
            if (this.int_1 >= 0 && this.Entities[this.int_1].Selectable)
            {
              if (!this.Entities[this.int_1].Selected)
                this.Entities[this.int_1].Selected = true;
              else
                this.Entities[this.int_1].Selected = false;
            }
            if (clsInit.appEditor.action == actionTypeBU.sewingMove && clsInit.appSewing != null)
              clsInit.appSewing.doDefineMove();
            if (clsInit.appEditor.action == actionTypeBU.sewingChangeStitchLen && clsInit.appSewing != null)
            {
              Sketcher2D.entitiesSelected.Clear();
              clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
              clsInit.appSewing.cmdChangeStitchLength(Sketcher2D.entitiesSelected, clsSewing.varSewingRunSettings.ShowDialog);
            }
            if (clsInit.appEditor.action == actionTypeBU.sewingStitchToJump && clsInit.appSewing != null)
              clsInit.appSewing.cmdStitchToJump();
            if (clsInit.appEditor.action == actionTypeBU.sewingJumpToStitch && clsInit.appSewing != null)
              clsInit.appSewing.cmdJumpToStitch();
            if (clsInit.appEditor.action == actionTypeBU.sewingDelete && clsInit.appSewing != null)
              clsInit.appSewing.doDeleteByQuestion(this.mouseWorldLoc);
            if (clsInit.appEditor.action == actionTypeBU.sewingMoveVertex | clsInit.appEditor.action == actionTypeBU.sewingFootHeight | clsInit.appEditor.action == actionTypeBU.sewingSpeed)
            {
              for (int index = 0; index <= underMouseCursor.Length - 1; ++index)
              {
                if (this.Entities[underMouseCursor[index]].GetType() == typeof (devDept.Eyeshot.Entities.Point))
                  this.Entities[underMouseCursor[index]].Selected = true;
                else
                  this.Entities[underMouseCursor[index]].Selected = false;
              }
              if (clsInit.appSewing != null)
              {
                clsInit.appSewing.doDefineSelectVertex(new Point3D(), clsInit.appEditor.action);
                break;
              }
              break;
            }
            break;
          case pickStateType.Enclosed:
            if ((num1 == 0 ? 0 : (num2 != 0 ? 1 : 0)) != 0)
            {
              this.GetEnclosedEntities(new Rectangle(mouseDownLocation, new Size(Math.Abs(num1), Math.Abs(num2))), false, out selectedIndices);
              if (selectedIndices != null)
              {
                for (int index = 0; index < selectedIndices.Length; ++index)
                {
                  if (this.Entities[selectedIndices[index]].Selectable)
                  {
                    if (!this.Entities[selectedIndices[index]].Selected)
                      this.Entities[selectedIndices[index]].Selected = true;
                    else
                      this.Entities[selectedIndices[index]].Selected = false;
                  }
                }
                break;
              }
              break;
            }
            break;
          case pickStateType.Crossing:
            if ((num1 == 0 ? 0 : (num2 != 0 ? 1 : 0)) != 0)
            {
              this.GetCrossingEntities(new Rectangle(mouseDownLocation, new Size(Math.Abs(num1), Math.Abs(num2))), false, out selectedIndices);
              if (selectedIndices != null)
              {
                for (int index = 0; index < selectedIndices.Length; ++index)
                {
                  if (this.Entities[selectedIndices[index]].Selectable)
                  {
                    if (!this.Entities[selectedIndices[index]].Selected)
                      this.Entities[selectedIndices[index]].Selected = true;
                    else
                      this.Entities[selectedIndices[index]].Selected = false;
                  }
                }
                break;
              }
              break;
            }
            break;
        }
        if (mea.Button == MouseButtons.Left)
        {
          bool flag1 = false;
          if (selectedIndices == null)
            flag1 = true;
          else if (selectedIndices.Length == 0)
            flag1 = true;
          if (Sketcher2D.isAreaSelection & flag1 & this.int_1 == -1)
          {
            List<Entity> SortedEntities = new List<Entity>();
            GetChainEntitiesSettings Settings = new GetChainEntitiesSettings();
            SelectionOperation SelectionOP = new SelectionOperation();
            List<int> SortedEntitesIndex = new List<int>();
            Entity foundEntity = (Entity) null;
            double LimitDistance = 0.0;
            clsInit.cVector5.GetClosestEntityToRefPoint(this.Entities.ToList<Entity>(), this.mouseWorldLoc, ref foundEntity, LimitDistance);
            if (foundEntity != null)
            {
              clsInit.cVector5.GetChainEntities(((ICurve) foundEntity).StartPoint, this.Entities.ToList<Entity>(), new BlockKeyedCollection(), Settings, ref SortedEntities, ref SortedEntitesIndex, ref SelectionOP);
              bool flag2 = clsInit.cVector5.isEntitiesClosed(SortedEntities);
              List<Point3D> Points = new List<Point3D>();
              clsInit.cVector5.EntitiesToPointsWithCamDirection(SortedEntities, 0.01, ref Points);
              bool flag3;
              if (!(flag3 = clsInit.cVector5.IsPointInsidePolygon(Points, this.mouseWorldLoc)))
              {
                for (int index1 = SortedEntitesIndex.Count - 1; index1 >= 0; --index1)
                {
                  bool flag4 = false;
                  for (int index2 = 0; index2 <= Sketcher2D.selectedIndex.Count - 1; ++index2)
                  {
                    for (int index3 = 0; index3 <= Sketcher2D.selectedIndex[index2].Count - 1; ++index3)
                    {
                      if (Sketcher2D.selectedIndex[index2][index3] == SortedEntitesIndex[index1])
                        flag4 = true;
                    }
                  }
                  if (!flag4 && SortedEntitesIndex[index1] >= 0 & SortedEntitesIndex[index1] <= this.Entities.Count - 1)
                    this.Entities[SortedEntitesIndex[index1]].Selected = false;
                }
                this.Invalidate();
                return;
              }
              if (!clsInit.cVector5.isSelectedIndexAvailableInSelectionList(Sketcher2D.selectedIndex, SortedEntitesIndex) & flag2 & flag3)
                Sketcher2D.selectedIndex.Add(SortedEntitesIndex);
            }
          }
        }
        this.Invalidate();
        return;
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.sewingDelete)
    {
      if (clsInit.appSewing == null)
        return;
      clsInit.appSewing.doDelete();
    }
    else if (clsInit.appEditor.action == actionTypeBU.sewingMove)
    {
      if (clsInit.appSewing == null)
        return;
      clsInit.appSewing.doDefineMove();
    }
    else
    {
      if (clsInit.appEditor.action == actionTypeBU.sewingChangeDirection)
        clsInit.appSewing.doChangeDirection(this.mouseWorldLoc, clsInit.appEditor.action);
      if (clsInit.appEditor.action == actionTypeBU.eventDelete)
      {
        clsItem.frmEditor.viewport.Entities.DeleteSelected();
        clsItem.frmEditor.viewport.Invalidate();
        clsInit.appEditor.Reset();
      }
      if (clsInit.appEditor.action == actionTypeBU.eventMove | clsInit.appEditor.action == actionTypeBU.eventCopy | clsInit.appEditor.action == actionTypeBU.eventOffset | clsInit.appEditor.action == actionTypeBU.eventRotate | clsInit.appEditor.action == actionTypeBU.eventScale | clsInit.appEditor.action == actionTypeBU.eventMirror && Sketcher2D.selectionProcess)
      {
        Sketcher2D.entitiesSelected.Clear();
        clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
        if (Sketcher2D.entitiesSelected.Count > 0)
        {
          if (clsInit.appEditor.action == actionTypeBU.eventCopy)
            clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[0], buLangTranslate.preDef.Copy);
          if (clsInit.appEditor.action == actionTypeBU.eventMove)
            clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[0], buLangTranslate.preDef.Move);
          if (clsInit.appEditor.action == actionTypeBU.eventOffset)
            clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[33], buLangTranslate.preDef.Move);
          if (clsInit.appEditor.action == actionTypeBU.eventRotate)
            clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[20], buLangTranslate.preDef.Rotate);
          if (clsInit.appEditor.action == actionTypeBU.eventScale)
            clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[31 /*0x1F*/], buLangTranslate.preDef.Scale);
          if (clsInit.appEditor.action == actionTypeBU.eventMirror)
            clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[122], buLangTranslate.preDef.Mirror);
          Sketcher2D.selectionProcess = false;
        }
      }
      if (this.bool_1)
      {
        this.CurrentSketch.DragEnd();
        this.bool_1 = false;
      }
      base.OnMouseUp(mea);
    }
  }

  protected override void DrawOverlay(DrawSceneParams data)
  {
    if (!Sketcher2D.FirstMove)
    {
      if (this.Entities.Count > 0 && this.Entities[0] is CompositeCurve)
        this.Entities.RemoveAt(0);
      Sketcher2D.FirstMove = true;
    }
    if (this.IsDesignMode())
      return;
    Point3D intPoint1 = (Point3D) null;
    Point3D intPoint2 = (Point3D) null;
    this.ScreenToPlane(new System.Drawing.Point(1, 1), Plane.XY, out intPoint1);
    this.ScreenToPlane(new System.Drawing.Point(2, 2), Plane.XY, out intPoint2);
    if (intPoint1 != (Point3D) null & intPoint2 != (Point3D) null)
      Sketcher2D.PixelVsMilimeter = Point3D.Distance(intPoint1, intPoint2);
    if (Sketcher2D.entityMouseUnder != null & Sketcher2D.entityMouseUnder is ICurve)
      this.method_6((ICurve) Sketcher2D.entityMouseUnder, false, Color.Red, 2f);
    if (Sketcher2D.buttonPressedForSelection)
    {
      switch (Sketcher2D.currPickState)
      {
        case pickStateType.Enclosed:
          this.method_0(Sketcher2D.mouseDownLocation, this.mouseloc, clsVar.varSelection.colorSelectionRightToLeft, clsVar.varSelection.SelectionTransparancy, true, false);
          break;
        case pickStateType.Crossing:
          this.method_0(Sketcher2D.mouseDownLocation, this.mouseloc, clsVar.varSelection.colorSelectionLeftToRight, clsVar.varSelection.SelectionTransparancy, true, true);
          break;
      }
    }
    this.RenderContext.SetColorWireframe(Color.Black);
    double num1 = (double) this.RenderContext.SetLineSize(2f);
    if (clsInit.appEditor.action == actionTypeBU.drawLine && Sketcher2D.Clicks.Count > 0)
      this.Draw((ICurve) new Line(Plane.XY, Sketcher2D.Clicks.Last<UClick>().Position, Sketcher2D.mousePlnLoc));
    if (clsInit.appEditor.action == actionTypeBU.drawCircle && Sketcher2D.Clicks.Count > 0)
    {
      double radius = Point2D.Distance(Sketcher2D.Clicks.Last<UClick>().Position, Sketcher2D.mousePlnLoc);
      if (radius > 0.0)
      {
        if (this.CurrentSketch != null)
          this.Draw((ICurve) new Circle(this.CurrentSketch.DrawingPlane, Sketcher2D.Clicks.Last<UClick>().Position, radius));
        else
          this.Draw((ICurve) new Circle(Plane.XY, Sketcher2D.Clicks.Last<UClick>().Position, radius));
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.drawCircle3Point)
    {
      int num2 = Sketcher2D.Clicks.Count < 3 ? Sketcher2D.Clicks.Count : (Sketcher2D.Clicks.Count - 3) % 2 + 1;
      if ((Sketcher2D.Clicks.Count == 1 ? 1 : (Sketcher2D.Clicks.Count == 2 ? 1 : 0)) != 0)
      {
        if (this.CurrentSketch != null)
          this.Draw((ICurve) new devDept.Eyeshot.Entities.Point(this.CurrentSketch.DrawingPlane, Sketcher2D.Clicks[0].Position), new float?(8f));
        else
          this.Draw((ICurve) new devDept.Eyeshot.Entities.Point(Plane.XY, Sketcher2D.Clicks[0].Position), new float?(8f));
      }
      if (num2 == 1)
      {
        if (this.CurrentSketch != null)
          this.Draw((ICurve) new Line(this.CurrentSketch.DrawingPlane, Sketcher2D.Clicks.Last<UClick>().Position, Sketcher2D.mousePlnLoc));
        else
          this.Draw((ICurve) new Line(Plane.XY, Sketcher2D.Clicks.Last<UClick>().Position, Sketcher2D.mousePlnLoc));
      }
      else
      {
        try
        {
          if (Sketcher2D.Clicks.Count >= 2)
          {
            Point2D position1 = Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 2].Position;
            Point2D position2 = Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Position;
            if (this.CurrentSketch != null)
              this.Draw((ICurve) new devDept.Eyeshot.Entities.Point(this.CurrentSketch.DrawingPlane, position2), new float?(8f));
            else
              this.Draw((ICurve) new devDept.Eyeshot.Entities.Point(Plane.XY, position2), new float?(8f));
            if (clsInit.appEditor.EvaluateArc(position1, Sketcher2D.mousePlnLoc, position2, out bool _))
              this.Draw((ICurve) new Circle(Plane.XY, position1, Sketcher2D.mousePlnLoc, position2));
            else if (this.CurrentSketch != null)
              this.Draw((ICurve) new Line(this.CurrentSketch.DrawingPlane, position1, Sketcher2D.mousePlnLoc));
            else
              this.Draw((ICurve) new Line(Plane.XY, position1, Sketcher2D.mousePlnLoc));
          }
        }
        catch
        {
        }
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.drawArc3PointSEM)
    {
      int num3 = Sketcher2D.Clicks.Count < 3 ? Sketcher2D.Clicks.Count : (Sketcher2D.Clicks.Count - 3) % 2 + 1;
      if ((Sketcher2D.Clicks.Count == 1 ? 1 : (Sketcher2D.Clicks.Count == 2 ? 1 : 0)) != 0)
        this.Draw((ICurve) new devDept.Eyeshot.Entities.Point(Plane.XY, Sketcher2D.Clicks[0].Position), new float?(8f));
      if (num3 == 1)
      {
        this.Draw((ICurve) new Line(Plane.XY, Sketcher2D.Clicks.Last<UClick>().Position, Sketcher2D.mousePlnLoc));
      }
      else
      {
        try
        {
          if (Sketcher2D.Clicks.Count >= 2)
          {
            Point2D position3 = Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 2].Position;
            Point2D position4 = Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Position;
            this.Draw((ICurve) new devDept.Eyeshot.Entities.Point(Plane.XY, position4), new float?(8f));
            bool flip;
            if (clsInit.appEditor.EvaluateArc(position3, Sketcher2D.mousePlnLoc, position4, out flip))
              this.Draw((ICurve) new Arc(Plane.XY, position3, Sketcher2D.mousePlnLoc, position4, flip));
            else
              this.Draw((ICurve) new Line(Plane.XY, position3, Sketcher2D.mousePlnLoc));
          }
        }
        catch
        {
        }
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.drawRectangle && Sketcher2D.Clicks.Count > 0)
    {
      Point2D position = Sketcher2D.Clicks.First<UClick>().Position;
      this.Draw((ICurve) new Line(Plane.XY, position.X, position.Y, Sketcher2D.mousePlnLoc.X, position.Y));
      this.Draw((ICurve) new Line(Plane.XY, Sketcher2D.mousePlnLoc.X, position.Y, Sketcher2D.mousePlnLoc.X, Sketcher2D.mousePlnLoc.Y));
      this.Draw((ICurve) new Line(Plane.XY, Sketcher2D.mousePlnLoc.X, Sketcher2D.mousePlnLoc.Y, position.X, Sketcher2D.mousePlnLoc.Y));
      this.Draw((ICurve) new Line(Plane.XY, position.X, Sketcher2D.mousePlnLoc.Y, position.X, position.Y));
    }
    if (clsInit.appEditor.action == actionTypeBU.drawEllipse && Sketcher2D.Clicks.Count > 0)
    {
      Point2D position = Sketcher2D.Clicks.First<UClick>().Position;
      double rx = position.DistanceTo((Point2D) new Point3D(Sketcher2D.mousePlnLoc.X, position.Y));
      double ry = position.DistanceTo((Point2D) new Point3D(position.X, Sketcher2D.mousePlnLoc.Y));
      if ((rx <= 0.001 ? 0 : (ry > 0.001 ? 1 : 0)) != 0)
        this.Draw((ICurve) new Ellipse(Plane.XY, position, rx, ry));
    }
    if (clsInit.appEditor.action == actionTypeBU.drawPolygon && Sketcher2D.Clicks.Count > 0)
    {
      LinearPath lp = (LinearPath) null;
      clsInit.appEditor.DrawPolygon(Sketcher2D.Clicks[0].Position, Sketcher2D.mousePlnLoc, ref lp);
      if (lp != null)
        this.Draw((ICurve) lp);
    }
    if (clsInit.appEditor.action == actionTypeBU.drawKeyHole)
    {
      buArc HeadArc = new buArc();
      buArc TaleArc = new buArc();
      buLine FirstLine = new buLine();
      buLine SecondLine = new buLine();
      clsInit.cVector5.KeyHole(new Point3D(Sketcher2D.mousePlnLoc.X, Sketcher2D.mousePlnLoc.Y), clsVar.varEditorRuntimeSet.KeyHoleHeadDiameter / 2.0, clsVar.varEditorRuntimeSet.KeyHoleWidth / 2.0, clsVar.varEditorRuntimeSet.KeyHoleLength, clsVar.varEditorRuntimeSet.KeyHoleAngle, false, Plane.XY, ref HeadArc, ref TaleArc, ref FirstLine, ref SecondLine);
      List<buEntity> RefEntities = new List<buEntity>();
      if (HeadArc.Vertices.Count > 0)
        RefEntities.Add((buEntity) HeadArc);
      if (FirstLine.Vertices.Count > 0)
        RefEntities.Add((buEntity) FirstLine);
      if (TaleArc.Vertices.Count > 0)
        RefEntities.Add((buEntity) TaleArc);
      if (SecondLine.Vertices.Count > 0)
        RefEntities.Add((buEntity) SecondLine);
      clsInit.cVector5.SplitArcEntitiesIfGreaterThen180Degree(ref RefEntities, 150.0);
      buCompositeCurve calcCompositeCurve = (buCompositeCurve) null;
      clsInit.cVector5.CreateCompositeCurveFromEntities(RefEntities, ref calcCompositeCurve);
      Entity copiedEntity = (Entity) null;
      buEntity.Copy((buEntity) calcCompositeCurve, ref copiedEntity);
      if (copiedEntity != null)
        this.Draw((ICurve) copiedEntity);
    }
    if (clsInit.appEditor.action == actionTypeBU.drawSlot)
    {
      if (Sketcher2D.Clicks.Count == 1)
        this.Draw((ICurve) new Line(Plane.XY, Sketcher2D.Clicks.First<UClick>().Position, Sketcher2D.mousePlnLoc));
      if (Sketcher2D.Clicks.Count == 2 && Sketcher2D.Clicks[1].Position.DistanceTo(Sketcher2D.mousePlnLoc) > 0.0)
        this.Draw((ICurve) clsInit.appEditor.ThreePointsSlot(Sketcher2D.Clicks[0].Position, Sketcher2D.Clicks[1].Position, Sketcher2D.mousePlnLoc));
    }
    if (clsInit.appEditor.action == actionTypeBU.drawSpline)
    {
      if (clsVar.varEditorRuntimeSet.isSketchMode)
      {
        if (Sketcher2D.Clicks.Count > 1)
        {
          List<Point3D> Q = Class5.smethod_172(this);
          Q.Add(this.mouseWorldLoc);
          Curve curve = Sketcher2D.Clicks.Count != 2 || !(this.mouseWorldLoc == this.point_0.Position) ? Curve.CubicSplineInterpolation<Point3D>((IList<Point3D>) Q) : clsInit.appEditor.InterpolateTwoPoints(Sketcher2D.Clicks[0], Sketcher2D.Clicks[1]);
          this.Draw((ICurve) curve);
          List<Point4D> point4DList = this.ControlPoints(curve);
          foreach (Point3D p in point4DList)
            this.Draw((ICurve) new devDept.Eyeshot.Entities.Point(p), new float?(3f));
          for (int index = 0; index < point4DList.Count - 1; index += 2)
            this.Draw((ICurve) new Line((Point3D) point4DList[index], (Point3D) point4DList[index + 1]), new float?(1f), new Color?(Color.Gray));
        }
        else if (Sketcher2D.Clicks.Count == 1)
          this.Draw((ICurve) new Line(Plane.XY, Sketcher2D.Clicks[0].Position, Sketcher2D.mousePlnLoc));
        foreach (UClick click in Sketcher2D.Clicks)
          this.Draw((ICurve) new devDept.Eyeshot.Entities.Point(Plane.XY, click.Position), new float?(8f));
      }
      else
      {
        if (Sketcher2D.Clicks.Count > 1)
        {
          List<Point3D> Q = new List<Point3D>();
          for (int index = 0; index <= Sketcher2D.Clicks.Count - 1; ++index)
            Q.Add(new Point3D(Sketcher2D.Clicks[index].Position.X, Sketcher2D.Clicks[index].Position.Y, 0.0));
          Q.Add(this.mouseWorldLoc);
          Curve curve = (Curve) null;
          if (Q.Count == 2)
          {
            this.Draw((ICurve) new Line(Plane.XY, (Point2D) Q[0], (Point2D) Q[1]));
          }
          else
          {
            if (buCompare5.EQ(Q[0], Q[Q.Count - 1], 0.5))
              Q[Q.Count - 1] = Q[0];
            curve = Curve.CubicSplineInterpolation<Point3D>((IList<Point3D>) Q);
          }
          if (curve != null)
          {
            this.Draw((ICurve) curve);
            List<Point4D> point4DList = this.ControlPoints(curve);
            foreach (Point3D p in point4DList)
              this.Draw((ICurve) new devDept.Eyeshot.Entities.Point(p), new float?(3f));
            for (int index = 0; index < point4DList.Count - 1; index += 2)
              this.Draw((ICurve) new Line((Point3D) point4DList[index], (Point3D) point4DList[index + 1]), new float?(1f), new Color?(Color.Gray));
          }
        }
        else if (Sketcher2D.Clicks.Count == 1)
          this.Draw((ICurve) new Line(Plane.XY, Sketcher2D.Clicks[0].Position, Sketcher2D.mousePlnLoc));
        foreach (UClick click in Sketcher2D.Clicks)
          this.Draw((ICurve) new devDept.Eyeshot.Entities.Point(Plane.XY, click.Position), new float?(8f));
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.drawMeasure && Sketcher2D.Clicks.Count > 0)
    {
      this.Draw((ICurve) new Line(Plane.XY, Sketcher2D.Clicks.Last<UClick>().Position, Sketcher2D.mousePlnLoc));
      if (Sketcher2D.Clicks.Count >= 1)
      {
        int x = (int) this.WorldToScreen(Sketcher2D.mousePlnLoc.X, Sketcher2D.mousePlnLoc.Y, 0.0).X;
        int y = (int) this.WorldToScreen(Sketcher2D.mousePlnLoc.X, Sketcher2D.mousePlnLoc.Y, 0.0).Y;
        double num4 = clsInit.cVector5.PointAngle(this.mouseWorldLoc, new Point3D(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Position.X, Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Position.Y));
        string text = $"{$"{buLangTranslate.preDef.Length}: {Point2D.Distance(Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Position, new Point2D(Sketcher2D.mousePlnLoc.X, Sketcher2D.mousePlnLoc.Y)).ToString("f2")}"} - {buLangTranslate.preDef.Angle}: {num4.ToString("f2")}";
        double num5 = Sketcher2D.mousePlnLoc.Y - Sketcher2D.Clicks[Sketcher2D.Clicks.Count - 1].Position.Y;
        int num6 = 10;
        if (num5 < 0.0)
          num6 = -10;
        this.DrawText(x, y + num6, text, new Font("Arial", (float) clsVar.varView.DynamicTextSize), Color.Black, ContentAlignment.MiddleLeft);
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventMove | clsInit.appEditor.action == actionTypeBU.eventCopy && Sketcher2D.Clicks.Count == 1)
    {
      foreach (Entity entity1 in Sketcher2D.entitiesSelected)
      {
        Entity entity2 = (Entity) entity1.Clone();
        Vector3D v = new Vector3D(Sketcher2D.Clicks[0].Pnt3D, this.mouseWorldLoc);
        entity2.Translate(v);
        if (entity2 is devDept.Eyeshot.Entities.Text)
          entity2.Regen(new RegenParams(0.0, (IWorkspace) this));
        this.Draw((ICurve) entity2);
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventMirror && Sketcher2D.Clicks.Count == 1)
    {
      foreach (Entity entity3 in Sketcher2D.entitiesSelected)
      {
        Point3D point3D1 = buVector5.ToPoint3D(Sketcher2D.Clicks[0].Pnt3D);
        Point3D point3D2 = buVector5.ToPoint3D(this.mouseWorldLoc);
        if ((point3D2.X < point3D1.X ? 1 : (point3D2.Y < point3D1.Y ? 1 : 0)) != 0)
        {
          Point3D first = point3D1;
          Point3D second = point3D2;
          Utility.Swap<Point3D>(ref first, ref second);
          point3D1 = first;
          point3D2 = second;
        }
        if (Point3D.Distance(point3D1, point3D2) > 0.01)
        {
          Vector3D X = new Vector3D(point3D1, point3D2);
          Plane plane = new Plane(point3D1, X, Vector3D.AxisZ);
          Entity entity4 = (Entity) entity3.Clone();
          Mirror xform = new Mirror(plane);
          entity4.TransformBy((Transformation) xform);
          this.Draw((ICurve) entity4);
        }
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventOffset)
    {
      foreach (Entity entity in Sketcher2D.entitiesSelected)
      {
        Entity selEntity = (Entity) entity.Clone();
        Entity entityOffseted = (Entity) null;
        if (!clsInit.appEditor.Offset(selEntity, this.mouseWorldLoc, ref entityOffseted))
          return;
        this.Draw((ICurve) entityOffseted);
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventRotate)
    {
      if (Sketcher2D.Clicks.Count == 1)
        this.Draw((ICurve) new Line(Sketcher2D.Clicks[0].Pnt3D, this.mouseWorldLoc));
      else if (Sketcher2D.Clicks.Count == 2)
      {
        double double_1 = 0.0;
        this.method_3(ref double_1);
        foreach (Entity entity5 in Sketcher2D.entitiesSelected)
        {
          Entity entity6 = (Entity) entity5.Clone();
          entity6.Rotate(double_1, Vector3D.AxisZ, Sketcher2D.Clicks[0].Pnt3D);
          if (entity6 is devDept.Eyeshot.Entities.Text)
            entity6.Regen(new RegenParams(0.0, (IWorkspace) this));
          this.Draw((ICurve) entity6);
        }
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventBreak && Sketcher2D.entityMouseUnder != null && Sketcher2D.entityMouseUnder is Entity)
    {
      Entity entityFirst = (Entity) null;
      Entity entitySecond = (Entity) null;
      clsInit.appEditor.Break((Entity) Sketcher2D.entityMouseUnder, this.mouseWorldLoc, ref entityFirst, ref entitySecond);
      if (entityFirst != null & entitySecond != null)
      {
        this.Draw((ICurve) entityFirst, new float?(3f), new Color?(Color.Blue));
        this.Draw((ICurve) entitySecond, new float?(3f), new Color?(Color.Cyan));
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventScale)
    {
      if (Sketcher2D.Clicks.Count == 1)
        this.Draw((ICurve) new Line(Sketcher2D.Clicks[0].Pnt3D, this.mouseWorldLoc));
      else if (Sketcher2D.Clicks.Count == 2)
      {
        this.Draw((ICurve) new Line(Sketcher2D.Clicks[0].Pnt3D, Sketcher2D.Clicks[1].Pnt3D));
        this.Draw((ICurve) new Line(Sketcher2D.Clicks[0].Pnt3D, this.mouseWorldLoc));
        double num7 = Sketcher2D.Clicks[0].Pnt3D.DistanceTo(Sketcher2D.Clicks[1].Pnt3D);
        if (num7 > 0.0)
        {
          double factor = Sketcher2D.Clicks[0].Pnt3D.DistanceTo(this.mouseWorldLoc) / num7;
          foreach (Entity entity7 in Sketcher2D.entitiesSelected)
          {
            Entity entity8 = (Entity) entity7.Clone();
            if (factor >= 0.01)
            {
              entity8.Scale(Sketcher2D.Clicks[0].Pnt3D, factor);
              this.Draw((ICurve) entity8);
            }
          }
        }
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.eventExtend && Sketcher2D.entityMouseUnder != null & this.int_0.Length >= 0 && Sketcher2D.entityMouseUnder is Entity & this.int_0[0] >= 0 & this.int_0[0] <= this.Entities.Count - 1)
    {
      Entity entityExtended = (Entity) null;
      clsInit.appCommand.Extend(clsItem.frmEditor.viewport.Entities, this.int_0[0], this.mouseWorldLoc, clsVar.varEditorRuntimeSet.ExtendLength, ref entityExtended);
      if (entityExtended != null)
        this.Draw((ICurve) entityExtended, new float?(3f), new Color?(Color.Blue));
    }
    if (clsInit.appEditor.action == actionTypeBU.eventTrim)
      this.method_5();
    if (clsInit.appEditor.action == actionTypeBU.libraryLength && Sketcher2D.entitySelected != null)
    {
      UtilityEx.DrawLinearDimPreview((Workspace) clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, (Line) Sketcher2D.entitySelected, this.mouseloc, this.PreviewDrawParams);
      Sketcher2D.isSelectionDone = true;
    }
    if (clsInit.appEditor.action == actionTypeBU.libraryRadius && Sketcher2D.entitySelected != null)
    {
      if (Sketcher2D.entitySelected.GetType() == typeof (Arc))
      {
        UtilityEx.DrawRadialDimPreview((Workspace) clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, (Circle) Sketcher2D.entitySelected, this.mouseloc, this.PreviewDrawParams);
        Sketcher2D.isSelectionDone = true;
      }
      else if (Sketcher2D.entitySelected.GetType() == typeof (Circle))
      {
        UtilityEx.DrawDiametricDimPreview((Workspace) clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, (Circle) Sketcher2D.entitySelected, this.mouseloc, this.PreviewDrawParams);
        Sketcher2D.isSelectionDone = true;
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.libraryAngle)
    {
      if ((Sketcher2D.entitiesSelected == null ? 0 : (Sketcher2D.entitiesSelected.Count == 1 ? 1 : 0)) != 0 && Sketcher2D.entitiesSelected[0] is Arc)
      {
        UtilityEx.DrawAngularDimPreview((Workspace) clsItem.frmEditor.viewport, (Arc) Sketcher2D.entitiesSelected[0], this.mouseloc, this.PreviewDrawParams);
        Sketcher2D.isSelectionDone = true;
      }
      if ((Sketcher2D.entitiesSelected == null ? 0 : (Sketcher2D.entitiesSelected.Count == 2 ? 1 : 0)) != 0)
      {
        UtilityEx.DrawAngularDimPreview((Workspace) clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, (Line) Sketcher2D.entitiesSelected[0], (Line) Sketcher2D.entitiesSelected[1], this.mouseloc, this.PreviewDrawParams);
        Sketcher2D.isSelectionDone = true;
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.libraryLineLine && (Sketcher2D.entitiesSelected == null ? 0 : (Sketcher2D.entitiesSelected.Count >= 2 ? 1 : 0)) != 0 && Sketcher2D.entitiesSelected[0] is Line & Sketcher2D.entitiesSelected[1] is Line)
    {
      Point3D startPoint = ((Line) Sketcher2D.entitiesSelected[0]).StartPoint;
      double t;
      ((Line) Sketcher2D.entitiesSelected[1]).Project(startPoint, out t);
      Point3D end = ((Line) Sketcher2D.entitiesSelected[1]).PointAt(t);
      UtilityEx.DrawLinearDimPreview((Workspace) clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, new Line(startPoint, end), this.mouseloc, this.PreviewDrawParams);
      Sketcher2D.isSelectionDone = true;
    }
    if (clsInit.appEditor.action == actionTypeBU.libraryLinePoint && (Sketcher2D.entitiesSelected == null ? 0 : (Sketcher2D.entitiesSelected.Count >= 2 ? 1 : 0)) != 0)
    {
      if (Sketcher2D.entitiesSelected[0] is Line & Sketcher2D.entitiesSelected[1] is devDept.Eyeshot.Entities.Point)
      {
        Line line = Sketcher2D.entitiesSelected[0] as Line;
        devDept.Eyeshot.Entities.Point point = Sketcher2D.entitiesSelected[1] as devDept.Eyeshot.Entities.Point;
        double t;
        line.Project(point.Position, out t);
        Point3D end = line.PointAt(t);
        UtilityEx.DrawLinearDimPreview((Workspace) clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, new Line(point.Position, end), this.mouseloc, this.PreviewDrawParams);
        Sketcher2D.isSelectionDone = true;
      }
      if (Sketcher2D.entitiesSelected[0] is devDept.Eyeshot.Entities.Point & Sketcher2D.entitiesSelected[1] is Line)
      {
        Line line = Sketcher2D.entitiesSelected[1] as Line;
        devDept.Eyeshot.Entities.Point point = Sketcher2D.entitiesSelected[0] as devDept.Eyeshot.Entities.Point;
        double t;
        line.Project(point.Position, out t);
        Point3D end = line.PointAt(t);
        UtilityEx.DrawLinearDimPreview((Workspace) clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, new Line(point.Position, end), this.mouseloc, this.PreviewDrawParams);
        Sketcher2D.isSelectionDone = true;
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.libraryPointPoint && (Sketcher2D.entitiesSelected == null ? 0 : (Sketcher2D.entitiesSelected.Count >= 2 ? 1 : 0)) != 0 && Sketcher2D.entitiesSelected[0] is devDept.Eyeshot.Entities.Point & Sketcher2D.entitiesSelected[1] is devDept.Eyeshot.Entities.Point)
    {
      Point3D position5 = ((devDept.Eyeshot.Entities.Point) Sketcher2D.entitiesSelected[0]).Position;
      Point3D position6 = ((devDept.Eyeshot.Entities.Point) Sketcher2D.entitiesSelected[1]).Position;
      if (Point3D.Distance(position5, position6) > 0.0)
      {
        this.plane_0 = UtilityEx.DrawLinearDimPreview((Workspace) clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, position5, position6, this.mouseloc, this.PreviewDrawParams).Plane;
        Sketcher2D.isSelectionDone = true;
      }
    }
    if (clsInit.appEditor.action == actionTypeBU.miscAutoSort && clsInit.appEditor.ManuelSortClickResult.ResultType != 0)
      this.Draw((ICurve) new Line(Plane.XY, (Point2D) clsInit.appEditor.ManuelSortClickResult.LastPoint, (Point2D) this.mouseWorldLoc));
    if (Sketcher2D.DrawingPoints.Count > 0)
    {
      for (int index = 0; index <= Sketcher2D.DrawingPoints.Count - 1; ++index)
      {
        if (Sketcher2D.DrawingPoints[index].Count > 0)
          this.Draw((ICurve) new LinearPath((ICollection<Point3D>) Sketcher2D.DrawingPoints[index]), new float?((float) clsVar.varEditorSet.thicknessDrawingPoints), new Color?(clsVar.varEditorSet.colorDrawingPoints));
      }
    }
    if (Sketcher2D.selectedPoint.Count > 0)
    {
      for (int index = 0; index <= Sketcher2D.selectedPoint.Count - 1; ++index)
        this.DrawPoint(Sketcher2D.selectedPoint[index], 6f, Color.Green);
    }
    if (Sketcher2D.selectedCircle.Count > 0)
    {
      for (int index = 0; index <= Sketcher2D.selectedCircle.Count - 1; ++index)
        this.DrawCircle(Sketcher2D.selectedCircle[index]);
    }
    if (clsVar.varEditorSet.ShowPoints)
    {
      for (int index = 0; index <= this.Entities.Count - 1; ++index)
      {
        if (this.Entities[index] is ICurve)
        {
          this.DrawPoint(((ICurve) this.Entities[index]).StartPoint, 6f, Color.Green);
          this.DrawPoint(((ICurve) this.Entities[index]).EndPoint, 6f, Color.Green);
        }
      }
    }
    if (clsVar.varEditorSet.ShowBoxSize & this.Entities.Count > 0)
    {
      if (this.Entities.BoxMin == (Point3D) null)
        this.Entities.UpdateBoundingBox();
      double boxSizeOffset1 = clsVar.varEditorSet.BoxSizeOffset;
      double boxSizeOffset2 = clsVar.varEditorSet.BoxSizeOffset;
      this.Draw((ICurve) new Line(Plane.XY, (Point2D) new Point3D(this.Entities.BoxMin.X - boxSizeOffset1, this.Entities.BoxMin.Y - boxSizeOffset2), (Point2D) new Point3D(this.Entities.BoxMax.X + boxSizeOffset1, this.Entities.BoxMin.Y - boxSizeOffset2)), new float?(3f), new Color?(Color.Blue));
      this.Draw((ICurve) new Line(Plane.XY, (Point2D) new Point3D(this.Entities.BoxMax.X + boxSizeOffset1, this.Entities.BoxMin.Y - boxSizeOffset2), (Point2D) new Point3D(this.Entities.BoxMax.X + boxSizeOffset1, this.Entities.BoxMax.Y + boxSizeOffset2)), new float?(3f), new Color?(Color.Blue));
      this.Draw((ICurve) new Line(Plane.XY, (Point2D) new Point3D(this.Entities.BoxMax.X + boxSizeOffset1, this.Entities.BoxMax.Y + boxSizeOffset2), (Point2D) new Point3D(this.Entities.BoxMin.X - boxSizeOffset1, this.Entities.BoxMax.Y + boxSizeOffset2)), new float?(3f), new Color?(Color.Blue));
      this.Draw((ICurve) new Line(Plane.XY, (Point2D) new Point3D(this.Entities.BoxMin.X - boxSizeOffset1, this.Entities.BoxMax.Y + boxSizeOffset2), (Point2D) new Point3D(this.Entities.BoxMin.X - boxSizeOffset1, this.Entities.BoxMin.Y - boxSizeOffset2)), new float?(3f), new Color?(Color.Blue));
    }
    if (clsVar.varEditorSet.DrawDirrectionArrow)
    {
      for (int index = 0; index <= this.Entities.Count - 1; ++index)
      {
        if (this.Entities[index] is ICurve && this.Entities[index].GetType() != typeof (devDept.Eyeshot.Entities.Point))
          this.DrawArrow((ICurve) this.Entities[index], ((ICurve) this.Entities[index]).Domain.Mid, height: 8, width: 20);
      }
    }
    if (clsInit.appEditor.sortedEntities.Count > 0)
    {
      for (int index = 0; index <= clsInit.appEditor.sortedEntities.Count - 1; ++index)
      {
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(clsInit.appEditor.sortedEntities[index], ref copiedEntity);
        List<Point3D> copiedPoint = new List<Point3D>();
        buVector5.Copy(clsInit.appEditor.sortedEntities[index].Vertices, ref copiedPoint);
        if (clsInit.appEditor.sortedEntities[index].sortDirection == entitySortDirection.Reverse)
          copiedPoint.Reverse();
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) copiedPoint);
        this.DrawArrow((ICurve) linearPath, linearPath.Domain.Mid, width: 15);
        if (linearPath != null)
        {
          float num8 = 2f;
          Color color = Color.Black;
          if (clsInit.appEditor.sortedEntities[index].Info.CamSelectedCount >= 2)
          {
            num8 += (float) clsInit.appEditor.sortedEntities[index].Info.CamSelectedCount;
            color = Color.Red;
          }
          this.Draw((ICurve) linearPath, new float?(num8), new Color?(color));
        }
      }
      Point3D pntEnd = new Point3D();
      clsInit.cVector5.GetEntityEndPointByCamDirection(clsInit.appEditor.sortedEntities[clsInit.appEditor.sortedEntities.Count - 1], ref pntEnd);
      Point2D screen = (Point2D) this.WorldToScreen(pntEnd);
      this.DrawCircle(new System.Drawing.Point((int) screen.X, (int) screen.Y));
    }
    if ((Point3D) this.osnapPoint_1 != (Point3D) null)
      this.method_18(this.osnapPoint_1);
    double num9 = (double) this.RenderContext.SetLineSize(1.5f);
    if (Sketcher2D.isDrawing)
      this.DrawCursor();
    base.DrawOverlay(data);
  }

  private void method_0(
    System.Drawing.Point point_3,
    System.Drawing.Point point_4,
    Color color_0,
    int int_3,
    bool bool_2,
    bool bool_3)
  {
    point_3.Y = this.Height - point_3.Y;
    point_4.Y = this.Height - point_4.Y;
    Class5.smethod_87(ref point_3, ref point_4);
    int[] viewFrame = this.Viewports[0].GetViewFrame();
    int num1 = viewFrame[0];
    int num2 = viewFrame[1] + viewFrame[3];
    int num3 = num1 + viewFrame[2];
    int num4 = viewFrame[1];
    if (point_4.X > num3 - 1)
      point_4.X = num3 - 1;
    if (point_4.Y > num2 - 1)
      point_4.Y = num2 - 1;
    if (point_3.X < num1 + 1)
      point_3.X = num1 + 1;
    if (point_3.Y < num4 + 1)
      point_3.Y = num4 + 1;
    int num5 = (int) this.RenderContext.SetState(blendStateType.Blend);
    this.RenderContext.SetColorWireframe(Color.FromArgb(int_3, (int) color_0.R, (int) color_0.G, (int) color_0.B));
    int num6 = (int) this.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
    int num7 = point_4.X - point_3.X;
    int num8 = point_4.Y - point_3.Y;
    this.RenderContext.DrawQuad(new RectangleF((float) (point_3.X + 1), (float) (point_3.Y + 1), (float) (num7 - 1), (float) (num8 - 1)));
    int num9 = (int) this.RenderContext.SetState(blendStateType.NoBlend);
    if (!bool_2)
      return;
    this.RenderContext.SetColorWireframe(Color.FromArgb((int) byte.MaxValue, (int) color_0.R, (int) color_0.G, (int) color_0.B));
    if (bool_3)
    {
      this.RenderContext.SetLineStipple(1, (ushort) 3855, this.Viewports[0].Camera);
      this.RenderContext.EnableLineStipple(true);
    }
    int x1 = point_3.X;
    int x2 = point_4.X;
    if (this.RenderContext.IsDirect3D)
    {
      ++x1;
      ++x2;
    }
    this.RenderContext.DrawLines(new List<Point3D>((IEnumerable<Point3D>) new Point3D[8]
    {
      new Point3D((double) x1, (double) point_3.Y),
      new Point3D((double) point_4.X, (double) point_3.Y),
      new Point3D((double) x2, (double) point_3.Y),
      new Point3D((double) x2, (double) point_4.Y),
      new Point3D((double) x2, (double) point_4.Y),
      new Point3D((double) x1, (double) point_4.Y),
      new Point3D((double) x1, (double) point_4.Y),
      new Point3D((double) x1, (double) point_3.Y)
    }).ToArray());
    if (!bool_3)
      return;
    this.RenderContext.EnableLineStipple(false);
  }

  internal void method_1()
  {
    if (Sketcher2D.firstSelectedEntity == null)
    {
      if (this.int_2 != -1)
      {
        Sketcher2D.firstSelectedEntity = this.Entities[this.int_2];
        Sketcher2D.firstSelectedEntity.Selected = true;
        this.int_2 = -1;
        this.ScreenToPlane(this.mouseloc, Plane.XY, out this.point3D_0);
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[125], buLangTranslate.preDef.Fillet);
        return;
      }
    }
    else if (Sketcher2D.secondSelectedEntity == null)
      this.RenderContext.EnableXOR(false);
    if (Sketcher2D.secondSelectedEntity == null && this.int_2 != -1)
    {
      Sketcher2D.secondSelectedEntity = this.Entities[this.int_2];
      Sketcher2D.secondSelectedEntity.Selected = true;
    }
    if ((!(Sketcher2D.firstSelectedEntity is ICurve) ? 0 : (Sketcher2D.secondSelectedEntity is ICurve ? 1 : 0)) == 0)
      return;
    if ((!(Sketcher2D.firstSelectedEntity is Line) ? 0 : (Sketcher2D.secondSelectedEntity is Line ? 1 : 0)) != 0 && Vector3D.AreParallel((Sketcher2D.firstSelectedEntity as Line).StartTangent, (Sketcher2D.secondSelectedEntity as Line).StartTangent))
    {
      clsInit.appEditor.Reset();
    }
    else
    {
      try
      {
        if (Sketcher2D.firstSelectedEntity.Equals((object) Sketcher2D.secondSelectedEntity))
        {
          clsInit.appEditor.Reset();
          return;
        }
        this.ScreenToPlane(this.mouseloc, Plane.XY, out this.point3D_1);
        Sketcher2D.firstSelectedEntity = this.method_13(Sketcher2D.firstSelectedEntity);
        Sketcher2D.secondSelectedEntity = this.method_13(Sketcher2D.secondSelectedEntity);
        ICurve icurve_4_1 = (ICurve) Sketcher2D.firstSelectedEntity.Clone();
        ICurve icurve_0_1 = (ICurve) Sketcher2D.secondSelectedEntity.Clone();
        ICurve icurve_3 = (ICurve) null;
        ICurve icurve_5 = (ICurve) null;
        ICurve C1 = (ICurve) null;
        ICurve C2 = (ICurve) null;
        switch (Sketcher2D.firstSelectedEntity)
        {
          case Arc _:
            Arc firstSelectedEntity1 = Sketcher2D.firstSelectedEntity as Arc;
            C1 = (ICurve) new Circle(firstSelectedEntity1.Center, firstSelectedEntity1.Radius);
            break;
          case Line _:
            C1 = Class5.smethod_175(this, (ICurve) Sketcher2D.firstSelectedEntity);
            break;
          case EllipticalArc _:
            EllipticalArc firstSelectedEntity2 = Sketcher2D.firstSelectedEntity as EllipticalArc;
            C1 = (ICurve) new Ellipse(firstSelectedEntity2.Center, firstSelectedEntity2.RadiusX, firstSelectedEntity2.RadiusY);
            break;
        }
        switch (Sketcher2D.secondSelectedEntity)
        {
          case Arc _:
            Arc secondSelectedEntity1 = Sketcher2D.secondSelectedEntity as Arc;
            C2 = (ICurve) new Circle(secondSelectedEntity1.Center, secondSelectedEntity1.Radius);
            break;
          case Line _:
            C2 = Class5.smethod_175(this, (ICurve) Sketcher2D.secondSelectedEntity);
            break;
          case EllipticalArc _:
            EllipticalArc secondSelectedEntity2 = Sketcher2D.secondSelectedEntity as EllipticalArc;
            C2 = (ICurve) new Ellipse(secondSelectedEntity2.Center, secondSelectedEntity2.RadiusX, secondSelectedEntity2.RadiusY);
            break;
        }
        ICurve icurve_2_1 = icurve_4_1;
        ICurve icurve_1_1 = icurve_0_1;
        if ((Utility.Intersection((ICurve) Sketcher2D.firstSelectedEntity, (ICurve) Sketcher2D.secondSelectedEntity).Length > 1 ? 1 : (C1 == null || C2 == null ? 0 : (Utility.Intersection(C1, C2).Length > 1 ? 1 : 0))) != 0)
          Class5.smethod_193(icurve_0_1, ref icurve_1_1, out icurve_2_1, out icurve_3, icurve_4_1, out icurve_5, this);
        ICurve[] curveArray1 = new ICurve[8]
        {
          Class5.smethod_33(icurve_2_1, this),
          Class5.smethod_33(icurve_2_1, this),
          Class5.smethod_33(icurve_2_1, this),
          Class5.smethod_33(icurve_2_1, this),
          null,
          null,
          null,
          null
        };
        ICurve[] curveArray2 = new ICurve[8]
        {
          Class5.smethod_33(icurve_1_1, this),
          Class5.smethod_33(icurve_1_1, this),
          Class5.smethod_33(icurve_1_1, this),
          Class5.smethod_33(icurve_1_1, this),
          null,
          null,
          null,
          null
        };
        Arc[] gparam_0 = new Arc[8];
        ICurve firstSelectedEntity3 = Sketcher2D.firstSelectedEntity as ICurve;
        ICurve secondSelectedEntity3 = Sketcher2D.secondSelectedEntity as ICurve;
        double num1 = Point3D.Distance(this.point3D_0, firstSelectedEntity3.StartPoint);
        double num2 = Point3D.Distance(this.point3D_1, firstSelectedEntity3.EndPoint);
        if ((num2 >= num1 ? 0 : (secondSelectedEntity3 is Arc ? 1 : (secondSelectedEntity3 is EllipticalArc ? 1 : 0))) != 0)
          firstSelectedEntity3.Reverse();
        double num3 = Point3D.Distance(this.point3D_0, secondSelectedEntity3.StartPoint);
        double num4 = Point3D.Distance(this.point3D_1, secondSelectedEntity3.EndPoint);
        if ((num4 >= num3 ? 0 : (secondSelectedEntity3 is Arc ? 1 : (secondSelectedEntity3 is EllipticalArc ? 1 : 0))) != 0)
          secondSelectedEntity3.Reverse();
        for (int index = 4; index < curveArray1.Length; ++index)
          curveArray1[index] = Class5.smethod_33(icurve_2_1, this);
        for (int index = 4; index < curveArray2.Length; ++index)
          curveArray2[index] = Class5.smethod_33(icurve_1_1, this);
        clsInit.appEditor.UndoBuffer();
        Curve.Fillet(curveArray1[0], curveArray2[0], clsVar.varEditorRuntimeSet.FilletRadius, false, false, true, true, out gparam_0[0]);
        Curve.Fillet(curveArray1[1], curveArray2[1], clsVar.varEditorRuntimeSet.FilletRadius, false, true, true, true, out gparam_0[1]);
        Curve.Fillet(curveArray1[2], curveArray2[2], clsVar.varEditorRuntimeSet.FilletRadius, true, false, true, true, out gparam_0[2]);
        Curve.Fillet(curveArray1[3], curveArray2[3], clsVar.varEditorRuntimeSet.FilletRadius, true, true, true, true, out gparam_0[3]);
        Curve.Fillet(curveArray1[4], curveArray2[4], clsVar.varEditorRuntimeSet.FilletRadius, false, false, true, true, out gparam_0[4]);
        Curve.Fillet(curveArray1[5], curveArray2[5], clsVar.varEditorRuntimeSet.FilletRadius, false, true, true, true, out gparam_0[5]);
        Curve.Fillet(curveArray1[6], curveArray2[6], clsVar.varEditorRuntimeSet.FilletRadius, true, false, true, true, out gparam_0[6]);
        Curve.Fillet(curveArray1[7], curveArray2[7], clsVar.varEditorRuntimeSet.FilletRadius, true, true, true, true, out gparam_0[7]);
        int index1 = this.method_12<Arc>(gparam_0);
        if (index1 >= 0)
        {
          this.Entities.Remove(Sketcher2D.firstSelectedEntity);
          this.Entities.Remove(Sketcher2D.secondSelectedEntity);
          ICurve icurve_0_2 = curveArray1[index1];
          ICurve icurve_0_3 = curveArray2[index1];
          bool bool_0_1 = icurve_0_2 is EllipticalArc && (icurve_0_2 as EllipticalArc).Center.X > this.point3D_0.X;
          ICurve curve1 = Class5.smethod_169(this, icurve_0_2, icurve_3, bool_0_1);
          if (curve1 != null)
            curveArray1[index1] = curve1;
          bool bool_0_2 = icurve_0_3 is EllipticalArc && (icurve_0_3 as EllipticalArc).Center.X > this.point3D_1.X;
          ICurve curve2 = Class5.smethod_169(this, icurve_0_3, icurve_5, bool_0_2);
          if (curve2 != null)
            curveArray2[index1] = curve2;
          this.method_7(!Class5.smethod_137(Sketcher2D.firstSelectedEntity) ? (Entity) curveArray1[index1] : Sketcher2D.firstSelectedEntity, this.string_0);
          this.method_7(!Class5.smethod_137(Sketcher2D.secondSelectedEntity) ? (Entity) curveArray2[index1] : Sketcher2D.secondSelectedEntity, this.string_0);
          this.method_7((Entity) gparam_0[index1], this.string_0);
        }
        else if ((firstSelectedEntity3.StartPoint.Equals(secondSelectedEntity3.StartPoint) || firstSelectedEntity3.StartPoint.Equals(secondSelectedEntity3.EndPoint) || secondSelectedEntity3.StartPoint.Equals(firstSelectedEntity3.EndPoint) ? 0 : (!secondSelectedEntity3.EndPoint.Equals(firstSelectedEntity3.EndPoint) ? 1 : 0)) != 0)
        {
          int num5;
          switch (Sketcher2D.secondSelectedEntity)
          {
            case Arc _:
            case EllipticalArc _:
              num5 = Sketcher2D.firstSelectedEntity is Line ? 1 : 0;
              break;
            default:
              num5 = 0;
              break;
          }
          if (num5 != 0)
          {
            if (!Class5.smethod_137(Sketcher2D.secondSelectedEntity))
              this.method_8();
            Utility.Swap<Entity>(ref Sketcher2D.firstSelectedEntity, ref Sketcher2D.secondSelectedEntity);
            this.method_8();
            Utility.Swap<Entity>(ref Sketcher2D.firstSelectedEntity, ref Sketcher2D.secondSelectedEntity);
          }
          else
          {
            Utility.Swap<Entity>(ref Sketcher2D.firstSelectedEntity, ref Sketcher2D.secondSelectedEntity);
            this.method_8();
            Utility.Swap<Entity>(ref Sketcher2D.firstSelectedEntity, ref Sketcher2D.secondSelectedEntity);
            this.method_8();
            if ((num2 >= num1 ? 0 : (firstSelectedEntity3 is Arc ? 1 : (secondSelectedEntity3 is Arc ? 1 : 0))) != 0)
              firstSelectedEntity3.Reverse();
            if ((num4 >= num3 ? 0 : (firstSelectedEntity3 is Arc ? 1 : (secondSelectedEntity3 is Arc ? 1 : 0))) != 0)
              secondSelectedEntity3.Reverse();
          }
          if (clsVar.varEditorRuntimeSet.FilletRadius > 0.0)
          {
            ICurve icurve_4_2 = (ICurve) Sketcher2D.firstSelectedEntity.Clone();
            ICurve icurve_0_4 = (ICurve) Sketcher2D.secondSelectedEntity.Clone();
            ICurve icurve_2_2 = icurve_4_2;
            ICurve icurve_1_2 = icurve_0_4;
            if ((Utility.Intersection((ICurve) Sketcher2D.firstSelectedEntity, (ICurve) Sketcher2D.secondSelectedEntity).Length > 1 ? 1 : (C1 == null || C2 == null ? 0 : (Utility.Intersection(C1, C2).Length > 1 ? 1 : 0))) != 0)
              Class5.smethod_193(icurve_0_4, ref icurve_1_2, out icurve_2_2, out icurve_3, icurve_4_2, out icurve_5, this);
            for (int index2 = 0; index2 < curveArray1.Length; ++index2)
              curveArray1[index2] = Class5.smethod_33(icurve_2_2, this);
            for (int index3 = 0; index3 < curveArray2.Length; ++index3)
              curveArray2[index3] = Class5.smethod_33(icurve_1_2, this);
            Curve.Fillet(curveArray1[0], curveArray2[0], clsVar.varEditorRuntimeSet.FilletRadius, false, false, true, true, out gparam_0[0]);
            Curve.Fillet(curveArray1[1], curveArray2[1], clsVar.varEditorRuntimeSet.FilletRadius, false, true, true, true, out gparam_0[1]);
            Curve.Fillet(curveArray1[2], curveArray2[2], clsVar.varEditorRuntimeSet.FilletRadius, true, false, true, true, out gparam_0[2]);
            Curve.Fillet(curveArray1[3], curveArray2[3], clsVar.varEditorRuntimeSet.FilletRadius, true, true, true, true, out gparam_0[3]);
            Curve.Fillet(curveArray1[4], curveArray2[4], clsVar.varEditorRuntimeSet.FilletRadius, false, false, true, true, out gparam_0[4]);
            Curve.Fillet(curveArray1[5], curveArray2[5], clsVar.varEditorRuntimeSet.FilletRadius, false, true, true, true, out gparam_0[5]);
            Curve.Fillet(curveArray1[6], curveArray2[6], clsVar.varEditorRuntimeSet.FilletRadius, true, false, true, true, out gparam_0[6]);
            Curve.Fillet(curveArray1[7], curveArray2[7], clsVar.varEditorRuntimeSet.FilletRadius, true, true, true, true, out gparam_0[7]);
            int index4 = this.method_12<Arc>(gparam_0);
            if (index4 >= 0)
            {
              this.Entities.Remove(Sketcher2D.secondSelectedEntity);
              this.Entities.Remove(Sketcher2D.firstSelectedEntity);
              ICurve curve3 = Class5.smethod_169(this, curveArray1[index4], icurve_3, true);
              if (curve3 != null)
                curveArray1[index4] = curve3;
              ICurve curve4 = Class5.smethod_169(this, curveArray2[index4], icurve_5, true);
              if (curve4 != null)
                curveArray2[index4] = curve4;
              this.method_7(!Class5.smethod_137(Sketcher2D.firstSelectedEntity) ? (Entity) curveArray1[index4] : Sketcher2D.firstSelectedEntity, this.string_0);
              this.method_7(!Class5.smethod_137(Sketcher2D.secondSelectedEntity) ? (Entity) curveArray2[index4] : Sketcher2D.secondSelectedEntity, this.string_0);
              this.method_7((Entity) gparam_0[index4], this.string_0);
            }
            else
            {
              this.method_7(Sketcher2D.firstSelectedEntity, this.string_0);
              this.method_7(Sketcher2D.secondSelectedEntity, this.string_0);
            }
          }
        }
        clsInit.appEditor.Reset();
      }
      catch
      {
      }
      clsInit.appEditor.Reset();
    }
  }

  internal void method_2()
  {
    if (Sketcher2D.firstSelectedEntity == null)
    {
      if (this.int_2 != -1)
      {
        Sketcher2D.firstSelectedEntity = this.Entities[this.int_2];
        Sketcher2D.firstSelectedEntity.Selected = true;
        this.int_2 = -1;
        this.ScreenToPlane(this.mouseloc, Plane.XY, out this.point3D_0);
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[125], buLangTranslate.preDef.Chamfer);
        return;
      }
    }
    else if (Sketcher2D.secondSelectedEntity == null)
      this.RenderContext.EnableXOR(false);
    if (Sketcher2D.secondSelectedEntity == null && this.int_2 != -1)
    {
      Sketcher2D.secondSelectedEntity = this.Entities[this.int_2];
      Sketcher2D.secondSelectedEntity.Selected = true;
    }
    if ((!(Sketcher2D.firstSelectedEntity is ICurve) ? 0 : (Sketcher2D.secondSelectedEntity is ICurve ? 1 : 0)) == 0)
      return;
    if (Sketcher2D.firstSelectedEntity.Equals((object) Sketcher2D.secondSelectedEntity))
    {
      clsInit.appEditor.Reset();
    }
    else
    {
      Sketcher2D.firstSelectedEntity = this.method_13(Sketcher2D.firstSelectedEntity);
      Sketcher2D.secondSelectedEntity = this.method_13(Sketcher2D.secondSelectedEntity);
      this.ScreenToPlane(this.mouseloc, Plane.XY, out this.point3D_1);
      double chamferLength = clsVar.varEditorRuntimeSet.ChamferLength;
      ICurve icurve_4_1 = (ICurve) Sketcher2D.firstSelectedEntity.Clone();
      ICurve icurve_0_1 = (ICurve) Sketcher2D.secondSelectedEntity.Clone();
      ICurve icurve_3 = (ICurve) null;
      ICurve icurve_5 = (ICurve) null;
      ICurve C1 = (ICurve) null;
      ICurve C2 = (ICurve) null;
      switch (Sketcher2D.firstSelectedEntity)
      {
        case Arc _:
          Arc firstSelectedEntity1 = Sketcher2D.firstSelectedEntity as Arc;
          C1 = (ICurve) new Circle(firstSelectedEntity1.Center, firstSelectedEntity1.Radius);
          break;
        case Line _:
          C1 = Class5.smethod_175(this, (ICurve) Sketcher2D.firstSelectedEntity);
          break;
        case EllipticalArc _:
          EllipticalArc firstSelectedEntity2 = (EllipticalArc) Sketcher2D.firstSelectedEntity;
          C1 = (ICurve) new Ellipse(firstSelectedEntity2.Center, firstSelectedEntity2.RadiusX, firstSelectedEntity2.RadiusY);
          break;
      }
      switch (Sketcher2D.secondSelectedEntity)
      {
        case Arc _:
          Arc secondSelectedEntity1 = Sketcher2D.secondSelectedEntity as Arc;
          C2 = (ICurve) new Circle(secondSelectedEntity1.Center, secondSelectedEntity1.Radius);
          break;
        case Line _:
          C2 = Class5.smethod_175(this, (ICurve) Sketcher2D.secondSelectedEntity);
          break;
        case EllipticalArc _:
          EllipticalArc secondSelectedEntity2 = Sketcher2D.secondSelectedEntity as EllipticalArc;
          C2 = (ICurve) new Ellipse(secondSelectedEntity2.Center, secondSelectedEntity2.RadiusX, secondSelectedEntity2.RadiusY);
          break;
      }
      ICurve icurve_2_1 = icurve_4_1;
      ICurve icurve_1_1 = icurve_0_1;
      if ((Utility.Intersection((ICurve) Sketcher2D.firstSelectedEntity, (ICurve) Sketcher2D.secondSelectedEntity).Length > 1 ? 1 : (C1 == null || C2 == null ? 0 : (Utility.Intersection(C1, C2).Length > 1 ? 1 : 0))) != 0)
        Class5.smethod_193(icurve_0_1, ref icurve_1_1, out icurve_2_1, out icurve_3, icurve_4_1, out icurve_5, this);
      ICurve[] curveArray1 = new ICurve[8]
      {
        Class5.smethod_33(icurve_2_1, this),
        Class5.smethod_33(icurve_2_1, this),
        Class5.smethod_33(icurve_2_1, this),
        Class5.smethod_33(icurve_2_1, this),
        null,
        null,
        null,
        null
      };
      ICurve[] curveArray2 = new ICurve[8]
      {
        Class5.smethod_33(icurve_1_1, this),
        Class5.smethod_33(icurve_1_1, this),
        Class5.smethod_33(icurve_1_1, this),
        Class5.smethod_33(icurve_1_1, this),
        null,
        null,
        null,
        null
      };
      Line[] gparam_0 = new Line[8];
      ICurve firstSelectedEntity3 = Sketcher2D.firstSelectedEntity as ICurve;
      ICurve secondSelectedEntity3 = Sketcher2D.secondSelectedEntity as ICurve;
      double num1 = Point3D.Distance(this.point3D_0, firstSelectedEntity3.StartPoint);
      double num2 = Point3D.Distance(this.point3D_1, firstSelectedEntity3.EndPoint);
      if ((num2 >= num1 ? 0 : (secondSelectedEntity3 is Arc ? 1 : (secondSelectedEntity3 is EllipticalArc ? 1 : 0))) != 0)
        firstSelectedEntity3.Reverse();
      double num3 = Point3D.Distance(this.point3D_0, secondSelectedEntity3.StartPoint);
      double num4 = Point3D.Distance(this.point3D_1, secondSelectedEntity3.EndPoint);
      if ((num4 >= num3 ? 0 : (secondSelectedEntity3 is Arc ? 1 : (secondSelectedEntity3 is EllipticalArc ? 1 : 0))) != 0)
        secondSelectedEntity3.Reverse();
      for (int index = 4; index < curveArray1.Length; ++index)
        curveArray1[index] = Class5.smethod_33(icurve_2_1, this);
      for (int index = 4; index < curveArray2.Length; ++index)
        curveArray2[index] = Class5.smethod_33(icurve_1_1, this);
      clsInit.appEditor.UndoBuffer();
      Curve.Chamfer(curveArray1[0], curveArray2[0], chamferLength, false, false, true, true, out gparam_0[0]);
      Curve.Chamfer(curveArray1[1], curveArray2[1], chamferLength, false, true, true, true, out gparam_0[1]);
      Curve.Chamfer(curveArray1[2], curveArray2[2], chamferLength, true, false, true, true, out gparam_0[2]);
      Curve.Chamfer(curveArray1[3], curveArray2[3], chamferLength, true, true, true, true, out gparam_0[3]);
      Curve.Chamfer(curveArray1[4], curveArray2[4], chamferLength, false, false, true, true, out gparam_0[4]);
      Curve.Chamfer(curveArray1[5], curveArray2[5], chamferLength, false, true, true, true, out gparam_0[5]);
      Curve.Chamfer(curveArray1[6], curveArray2[6], chamferLength, true, false, true, true, out gparam_0[6]);
      Curve.Chamfer(curveArray1[7], curveArray2[7], chamferLength, true, true, true, true, out gparam_0[7]);
      int index1 = this.method_12<Line>(gparam_0);
      if (index1 >= 0)
      {
        this.Entities.Remove(Sketcher2D.firstSelectedEntity);
        this.Entities.Remove(Sketcher2D.secondSelectedEntity);
        bool bool_0_1 = curveArray1[index1] is EllipticalArc && ((Ellipse) curveArray1[index1]).Center.X > this.point3D_0.X;
        ICurve curve1 = Class5.smethod_169(this, curveArray1[index1], icurve_3, bool_0_1);
        if (curve1 != null)
          curveArray1[index1] = curve1;
        bool bool_0_2 = curveArray2[index1] is EllipticalArc && ((Ellipse) curveArray2[index1]).Center.X > this.point3D_1.X;
        ICurve curve2 = Class5.smethod_169(this, curveArray2[index1], icurve_5, bool_0_2);
        if (curve2 != null)
          curveArray2[index1] = curve2;
        this.method_7(!Class5.smethod_137(Sketcher2D.firstSelectedEntity) ? (Entity) curveArray1[index1] : Sketcher2D.firstSelectedEntity, this.string_0);
        this.method_7(!Class5.smethod_137(Sketcher2D.secondSelectedEntity) ? (Entity) curveArray2[index1] : Sketcher2D.secondSelectedEntity, this.string_0);
        this.method_7((Entity) gparam_0[index1], this.string_0);
      }
      else if ((firstSelectedEntity3.StartPoint.Equals(secondSelectedEntity3.StartPoint) || firstSelectedEntity3.StartPoint.Equals(secondSelectedEntity3.EndPoint) || secondSelectedEntity3.StartPoint.Equals(firstSelectedEntity3.EndPoint) ? 0 : (!secondSelectedEntity3.EndPoint.Equals(firstSelectedEntity3.EndPoint) ? 1 : 0)) != 0)
      {
        int num5;
        switch (Sketcher2D.secondSelectedEntity)
        {
          case Arc _:
          case EllipticalArc _:
            num5 = Sketcher2D.firstSelectedEntity is Line ? 1 : 0;
            break;
          default:
            num5 = 0;
            break;
        }
        if (num5 != 0)
        {
          if (!Class5.smethod_137(Sketcher2D.secondSelectedEntity))
            this.method_8();
          Utility.Swap<Entity>(ref Sketcher2D.firstSelectedEntity, ref Sketcher2D.secondSelectedEntity);
          this.method_8();
          Utility.Swap<Entity>(ref Sketcher2D.firstSelectedEntity, ref Sketcher2D.secondSelectedEntity);
        }
        else
        {
          Utility.Swap<Entity>(ref Sketcher2D.firstSelectedEntity, ref Sketcher2D.secondSelectedEntity);
          this.method_8();
          Utility.Swap<Entity>(ref Sketcher2D.firstSelectedEntity, ref Sketcher2D.secondSelectedEntity);
          this.method_8();
          if ((num2 >= num1 ? 0 : (firstSelectedEntity3 is Arc ? 1 : (secondSelectedEntity3 is Arc ? 1 : 0))) != 0)
            firstSelectedEntity3.Reverse();
          if ((num4 >= num3 ? 0 : (firstSelectedEntity3 is Arc ? 1 : (secondSelectedEntity3 is Arc ? 1 : 0))) != 0)
            secondSelectedEntity3.Reverse();
        }
        if (chamferLength > 0.0)
        {
          ICurve icurve_4_2 = (ICurve) Sketcher2D.firstSelectedEntity.Clone();
          ICurve icurve_0_2 = (ICurve) Sketcher2D.secondSelectedEntity.Clone();
          ICurve icurve_2_2 = icurve_4_2;
          ICurve icurve_1_2 = icurve_0_2;
          if ((Utility.Intersection((ICurve) Sketcher2D.firstSelectedEntity, (ICurve) Sketcher2D.secondSelectedEntity).Length > 1 ? 1 : (C1 == null || C2 == null ? 0 : (Utility.Intersection(C1, C2).Length > 1 ? 1 : 0))) != 0)
            Class5.smethod_193(icurve_0_2, ref icurve_1_2, out icurve_2_2, out icurve_3, icurve_4_2, out icurve_5, this);
          for (int index2 = 0; index2 < curveArray1.Length; ++index2)
            curveArray1[index2] = Class5.smethod_33(icurve_2_2, this);
          for (int index3 = 0; index3 < curveArray2.Length; ++index3)
            curveArray2[index3] = Class5.smethod_33(icurve_1_2, this);
          Curve.Chamfer(curveArray1[0], curveArray2[0], chamferLength, false, false, true, true, out gparam_0[0]);
          Curve.Chamfer(curveArray1[1], curveArray2[1], chamferLength, false, true, true, true, out gparam_0[1]);
          Curve.Chamfer(curveArray1[2], curveArray2[2], chamferLength, true, false, true, true, out gparam_0[2]);
          Curve.Chamfer(curveArray1[3], curveArray2[3], chamferLength, true, true, true, true, out gparam_0[3]);
          Curve.Chamfer(curveArray1[4], curveArray2[4], chamferLength, false, false, true, true, out gparam_0[4]);
          Curve.Chamfer(curveArray1[5], curveArray2[5], chamferLength, false, true, true, true, out gparam_0[5]);
          Curve.Chamfer(curveArray1[6], curveArray2[6], chamferLength, true, false, true, true, out gparam_0[6]);
          Curve.Chamfer(curveArray1[7], curveArray2[7], chamferLength, true, true, true, true, out gparam_0[7]);
          int index4 = this.method_12<Line>(gparam_0);
          if (index4 >= 0)
          {
            this.Entities.Remove(Sketcher2D.secondSelectedEntity);
            this.Entities.Remove(Sketcher2D.firstSelectedEntity);
            ICurve curve3 = Class5.smethod_169(this, curveArray1[index4], icurve_3, true);
            if (curve3 != null)
              curveArray1[index4] = curve3;
            ICurve curve4 = Class5.smethod_169(this, curveArray2[index4], icurve_5, true);
            if (curve4 != null)
              curveArray2[index4] = curve4;
            this.method_7(!Class5.smethod_137(Sketcher2D.firstSelectedEntity) ? (Entity) curveArray1[index4] : Sketcher2D.firstSelectedEntity, this.string_0);
            this.method_7(!Class5.smethod_137(Sketcher2D.secondSelectedEntity) ? (Entity) curveArray2[index4] : Sketcher2D.secondSelectedEntity, this.string_0);
            this.method_7((Entity) gparam_0[index4], this.string_0);
          }
          else
          {
            this.method_7(Sketcher2D.firstSelectedEntity, this.string_0);
            this.method_7(Sketcher2D.secondSelectedEntity, this.string_0);
          }
        }
      }
      clsInit.appEditor.Reset();
      this.Invalidate();
    }
  }

  private void method_3(ref double double_1)
  {
    if ((this.ActionMode != devDept.Eyeshot.actionType.None ? 0 : (Sketcher2D.Clicks.Count > 0 ? 1 : 0)) == 0)
      return;
    this.Draw((ICurve) new Line(Sketcher2D.Clicks[0].Pnt3D, this.mouseWorldLoc), new float?(2f), new Color?(Color.Blue));
    if (Sketcher2D.Clicks.Count == 2)
    {
      double radius = Sketcher2D.Clicks[0].Pnt3D.DistanceTo(Sketcher2D.Clicks[1].Pnt3D);
      if (radius > 0.001)
      {
        Plane arcPlane = Class5.smethod_13(Sketcher2D.Clicks[1].Pnt3D, this);
        Vector2D u = new Vector2D((Point2D) Sketcher2D.Clicks[0].Pnt3D, (Point2D) Sketcher2D.Clicks[1].Pnt3D);
        u.Normalize();
        Vector2D v = new Vector2D((Point2D) Sketcher2D.Clicks[0].Pnt3D, (Point2D) this.mouseWorldLoc);
        v.Normalize();
        double_1 = Vector2D.SignedAngleBetween(u, v);
        if (Math.Abs(double_1) > 0.001)
          this.Draw((ICurve) new Arc(arcPlane, arcPlane.Origin, radius, 0.0, double_1), new float?(2f), new Color?(Color.Blue));
      }
    }
    if (Sketcher2D.Clicks.Count != 3)
      return;
    double radius1 = Sketcher2D.Clicks[0].Pnt3D.DistanceTo(Sketcher2D.Clicks[1].Pnt3D);
    if (radius1 <= 0.001)
      return;
    Plane arcPlane1 = Class5.smethod_13(Sketcher2D.Clicks[1].Pnt3D, this);
    Vector2D u1 = new Vector2D((Point2D) Sketcher2D.Clicks[0].Pnt3D, (Point2D) Sketcher2D.Clicks[1].Pnt3D);
    u1.Normalize();
    Vector2D v1 = new Vector2D((Point2D) Sketcher2D.Clicks[0].Pnt3D, (Point2D) Sketcher2D.Clicks[2].Pnt3D);
    v1.Normalize();
    double_1 = Vector2D.SignedAngleBetween(u1, v1);
    if (Math.Abs(double_1) <= 0.001)
      return;
    this.Draw((ICurve) new Arc(arcPlane1, arcPlane1.Origin, radius1, 0.0, double_1), new float?(2f), new Color?(Color.Blue));
  }

  private void method_4()
  {
    SelectedItem underMouseCursor = this.GetItemUnderMouseCursor(this.mouseloc, true);
    this.entity_0 = (underMouseCursor == null ? 0 : (underMouseCursor.Item != null ? 1 : 0)) == 0 ? (Entity) null : (underMouseCursor.Item as Entity).Clone() as Entity;
    List<Entity> previewEntities = new List<Entity>();
    Utility.TrimPreview((IDesign) this, this.mouseloc, out previewEntities);
    this.list_0 = previewEntities.Select<Entity, Entity>((Func<Entity, Entity>) (entity_0 => entity_0.Clone() as Entity)).ToList<Entity>();
    foreach (Entity entity in this.list_0)
    {
      if (this.CurrentTransformation != (Transformation) null)
        entity.TransformBy(this.CurrentTransformation);
    }
    if ((this.entity_0 == null ? 0 : (this.CurrentTransformation != (Transformation) null ? 1 : 0)) == 0)
      return;
    this.entity_0.TransformBy(this.CurrentTransformation);
  }

  private void method_5()
  {
    this.RenderContext.EnableXOR(false);
    if (this.list_0.Count > 0)
    {
      this.Draw(this.entity_0 as ICurve, new float?(5f), new Color?(Color.BlueViolet));
      foreach (Entity entity in this.list_0)
        this.Draw(entity as ICurve, new float?(5f), new Color?(Color.DodgerBlue));
    }
    else if (this.entity_0 != null)
      this.Draw(this.entity_0 as ICurve, new float?(5f), new Color?(Color.DodgerBlue));
    this.RenderContext.EnableXOR(true);
  }

  public void DrawCursor()
  {
    double num = 10.0;
    this.Draw((ICurve) new Line(this.mouseScreenLoc.X, this.mouseScreenLoc.Y - num, this.mouseScreenLoc.X, this.mouseScreenLoc.Y + num), new float?(1.5f), screenCoords: true);
    this.Draw((ICurve) new Line(this.mouseScreenLoc.X - num, this.mouseScreenLoc.Y, this.mouseScreenLoc.X + num, this.mouseScreenLoc.Y), new float?(1.5f), screenCoords: true);
  }

  public void Draw(ICurve curve, float? lineSize = null, Color? color = null, bool screenCoords = false)
  {
    float? nullable1 = new float?();
    float? nullable2 = new float?();
    Color? nullable3 = new Color?();
    Color blue = Color.Blue;
    float float_0 = 1f;
    shaderType currentShader = this.RenderContext.CurrentShader;
    if (lineSize.HasValue)
    {
      float_0 = lineSize.Value;
      if (curve is devDept.Eyeshot.Entities.Point)
        nullable2 = new float?(this.RenderContext.SetPointSize(lineSize.Value));
      else
        nullable1 = new float?(this.RenderContext.SetLineSize(lineSize.Value));
    }
    if (color.HasValue)
    {
      nullable3 = new Color?(this.RenderContext.CurrentWireColor);
      blue = color.Value;
      this.RenderContext.SetColorWireframe(color.Value);
    }
    switch (curve)
    {
      case Line _:
        this.RenderContext.DrawLine(this.method_14(curve.StartPoint, screenCoords), this.method_14(curve.EndPoint, screenCoords));
        break;
      case LinearPath _:
        this.RenderContext.DrawLineStrip(this.method_15(((Entity) curve).Vertices, screenCoords));
        break;
      case devDept.Eyeshot.Entities.Point _:
        this.RenderContext.DrawPoints(new Point3D[1]
        {
          this.method_14(((devDept.Eyeshot.Entities.Point) curve).Position, screenCoords)
        });
        break;
      case CompositeCurve _:
        foreach (ICurve icurve_0 in ((CompositeCurve) curve).Explode())
          this.method_6(icurve_0, screenCoords, blue, float_0);
        break;
      default:
        this.method_6(curve, screenCoords, blue, float_0);
        break;
    }
    if (nullable2.HasValue)
    {
      double num1 = (double) this.RenderContext.SetPointSize(nullable2.Value);
    }
    if (nullable1.HasValue)
    {
      double num2 = (double) this.RenderContext.SetLineSize(nullable1.Value);
    }
    if (nullable3.HasValue)
      this.RenderContext.SetColorWireframe(nullable3.Value);
    this.RenderContext.SetShader(currentShader);
  }

  public void DrawArrow(
    Point3D position,
    Vector2D tangent,
    bool flip = false,
    int height = 4,
    int width = 10,
    int mWidth = 2)
  {
    this.RenderContext.SetColorWireframe(Color.Black);
    Mesh mesh = Class5.smethod_164((double) mWidth, (double) width, (double) height);
    mesh.Rotate(tangent.Angle + (flip ? Math.PI : 0.0), Vector3D.AxisZ);
    mesh.Translate(this.WorldToScreen(position).AsVector);
    this.RenderContext.DrawPlainTriangles((IList<IndexTriangle>) mesh.Triangles, (IList<Point3D>) mesh.Vertices);
  }

  public void DrawArrow(ICurve curve, double t, bool flip = false, int height = 4, int width = 10, int mWidth = 2)
  {
    bool flag1 = false;
    bool flag2 = false;
    if (curve is Entity && ((Entity) curve).EntityData != null && ((Entity) curve).EntityData is SewingEntityCustomData)
    {
      if (((SewingEntityCustomData) ((Entity) curve).EntityData).SortDir == entitySortDirection.Reverse)
        flag1 = true;
      if (((SewingEntityCustomData) ((Entity) curve).EntityData).DrawType != SewingDrawType.Jump & ((SewingEntityCustomData) ((Entity) curve).EntityData).DrawType != SewingDrawType.Stitched)
        flag2 = true;
      if (((SewingEntityCustomData) ((Entity) curve).EntityData).DrawType == SewingDrawType.Punteriz)
      {
        t = 1.0;
        flag2 = true;
      }
      if (((SewingEntityCustomData) ((Entity) curve).EntityData).DrawType == SewingDrawType.Extension)
      {
        t = 1.0;
        flag2 = true;
      }
    }
    Point3D point = curve.PointAt(t);
    Vector3D vector3D = curve.TangentAt(t);
    if (!(point != (Point3D) null & vector3D != (Vector3D) null))
      return;
    Vector2D asVector = ((Point2D) (this.WorldToScreen(point) - this.WorldToScreen(point - vector3D))).AsVector;
    if (flag1)
      ;
    asVector.Normalize();
    if (flag2)
      return;
    this.DrawArrow(curve.PointAt(t).AsVector.AsPoint, asVector, flip, height, width, mWidth);
  }

  public void DrawCircle(Circle C)
  {
    this.RenderContext.SetColorWireframe(C.Color);
    Mesh mesh = new devDept.Eyeshot.Entities.Region((ICurve) C).ExtrudeAsMesh(0.1, 0.01, Mesh.natureType.RichSmooth);
    mesh.Regen(0.02);
    List<Point3D> vertices = new List<Point3D>();
    vertices.AddRange((IEnumerable<Point3D>) this.method_15(mesh.Vertices, false));
    this.RenderContext.DrawPlainTriangles((IList<IndexTriangle>) mesh.Triangles, (IList<Point3D>) vertices);
  }

  public void DrawPoint(Point3D P, float size, Color color)
  {
    double num = (double) this.RenderContext.SetPointSize(size);
    this.RenderContext.SetColorWireframe(color);
    this.RenderContext.DrawPoints(new Point3D[1]
    {
      this.method_14(P, false)
    });
  }

  private void method_6(ICurve icurve_0, bool bool_2, Color color_0, float float_0 = 1f)
  {
    if (!(icurve_0 is Entity))
      return;
    Entity entity = (Entity) icurve_0;
    if (entity.Vertices == null)
      entity.Regen(0.01);
    double num1 = (double) this.RenderContext.SetLineSize(float_0);
    this.RenderContext.SetColorWireframe(color_0);
    long num2 = (long) this.RenderContext.SetState(depthStencilStateType.DepthTestOff);
    this.RenderContext.DrawLineStrip(this.method_15(entity.Vertices, bool_2));
  }

  internal void method_7(Entity entity_1, string string_1)
  {
    entity_1.ColorMethod = colorMethodType.byEntity;
    entity_1.Color = clsVar.varEditorSet.colorEntity;
    entity_1.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
    entity_1.LineWeightMethod = colorMethodType.byEntity;
    switch (entity_1)
    {
      case devDept.Eyeshot.Entities.Point _:
        entity_1.LineWeightMethod = colorMethodType.byEntity;
        entity_1.LineWeight += 3f;
        this.Entities.Add(entity_1);
        break;
      case Dimension _:
        Dimension dimension = (Dimension) entity_1;
        dimension.LayerName = string_1;
        dimension.WidthFactor = 0.9;
        dimension.LineWeightMethod = colorMethodType.byEntity;
        this.Entities.Add((Entity) dimension);
        break;
      case Leader _:
        entity_1.LayerName = string_1;
        entity_1.LineWeightMethod = colorMethodType.byEntity;
        this.Entities.Add(entity_1);
        break;
      case devDept.Eyeshot.Entities.Text _:
        devDept.Eyeshot.Entities.Text text = (devDept.Eyeshot.Entities.Text) entity_1;
        text.LayerName = string_1;
        text.WidthFactor = 0.9;
        text.LineWeightMethod = colorMethodType.byEntity;
        this.Entities.Add((Entity) text);
        break;
      default:
        this.Entities.Add(entity_1, string_1);
        break;
    }
    this.Entities.Regen();
    this.Invalidate();
  }

  private void method_8()
  {
    if ((!(Sketcher2D.firstSelectedEntity is ICurve) ? 0 : (Sketcher2D.secondSelectedEntity is ICurve ? 1 : 0)) == 0)
      return;
    ICurve firstSelectedEntity = Sketcher2D.firstSelectedEntity as ICurve;
    ICurve secondSelectedEntity = Sketcher2D.secondSelectedEntity as ICurve;
    this.ScreenToPlane(this.mouseloc, Plane.XY, out this.point3D_1);
    double num1 = 0.5;
    double t1;
    firstSelectedEntity.ClosestPointTo(secondSelectedEntity.StartPoint, out t1);
    double t2;
    firstSelectedEntity.ClosestPointTo(secondSelectedEntity.EndPoint, out t2);
    Point3D b1 = firstSelectedEntity.PointAt(t1);
    Point3D b2 = firstSelectedEntity.PointAt(t2);
    ICurve curve = (ICurve) null;
    ICurve C2 = (ICurve) null;
    switch (secondSelectedEntity)
    {
      case Arc _:
        Arc arc1 = secondSelectedEntity as Arc;
        curve = (ICurve) new Circle(arc1.Center, arc1.Radius);
        break;
      case Ellipse _:
        Ellipse ellipse1 = secondSelectedEntity as Ellipse;
        curve = (ICurve) new Ellipse(ellipse1.Center, ellipse1.RadiusX, ellipse1.RadiusY);
        break;
      case Line _:
        curve = Class5.smethod_175(this, secondSelectedEntity);
        break;
    }
    switch (firstSelectedEntity)
    {
      case Arc _:
        Arc arc2 = firstSelectedEntity as Arc;
        C2 = (ICurve) new Circle(arc2.Center, arc2.Radius);
        break;
      case Ellipse _:
        Ellipse ellipse2 = firstSelectedEntity as Ellipse;
        C2 = (ICurve) new Ellipse(ellipse2.Center, ellipse2.RadiusX, ellipse2.RadiusY);
        break;
      case Line _:
        C2 = Class5.smethod_175(this, firstSelectedEntity);
        break;
    }
    double num2;
    double num3;
    if ((curve == null || C2 == null ? 0 : (curve.IntersectWith(C2).Length > 1 ? 1 : 0)) != 0)
    {
      num2 = secondSelectedEntity.StartPoint.DistanceTo(this.point3D_1);
      num3 = secondSelectedEntity.EndPoint.DistanceTo(this.point3D_1);
    }
    else
    {
      num2 = secondSelectedEntity.StartPoint.DistanceTo(b1);
      num3 = secondSelectedEntity.EndPoint.DistanceTo(b2);
    }
    double num4 = Math.Abs(secondSelectedEntity.StartPoint.X - b1.X);
    double num5 = Math.Abs(secondSelectedEntity.StartPoint.Y - b1.Y);
    double num6 = Math.Abs(secondSelectedEntity.EndPoint.X - b2.X);
    double num7 = Math.Abs(secondSelectedEntity.EndPoint.Y - b2.Y);
    bool flag = false;
    bool? nullable = new bool?();
    if ((num2 >= num3 || num4 <= num1 ? 0 : (num5 > num1 ? 1 : 0)) != 0)
      nullable = new bool?(true);
    else if ((num6 <= num1 ? 0 : (num7 > num1 ? 1 : 0)) != 0)
      nullable = new bool?(false);
    else if ((num4 <= num1 ? 0 : (num5 > num1 ? 1 : 0)) != 0)
      nullable = new bool?(true);
    if (nullable.HasValue)
    {
      switch (secondSelectedEntity)
      {
        case Line _:
          flag = Class5.smethod_88(secondSelectedEntity, firstSelectedEntity, this, nullable.Value);
          break;
        case LinearPath _:
          flag = Class5.smethod_54(secondSelectedEntity, this, firstSelectedEntity, nullable.Value);
          break;
        case Arc _:
          flag = this.method_9(secondSelectedEntity, firstSelectedEntity, nullable.Value);
          break;
        case EllipticalArc _:
          flag = this.method_10(secondSelectedEntity, firstSelectedEntity, nullable.Value);
          break;
        case Curve _:
          flag = Class5.smethod_139(secondSelectedEntity, firstSelectedEntity, this, nullable.Value);
          break;
      }
    }
    if (!flag)
      return;
    this.Entities.Regen();
  }

  private bool method_9(ICurve icurve_0, ICurve icurve_1, bool bool_2)
  {
    Arc arc = icurve_0 as Arc;
    Circle C2 = new Circle(arc.Plane, arc.Center, arc.Radius);
    Point3D[] point3D_1 = Utility.Intersection(icurve_1, (ICurve) C2);
    if (point3D_1.Length == 0)
      point3D_1 = Utility.Intersection(Class5.smethod_175(this, icurve_1), (ICurve) C2);
    bool flag;
    if (point3D_1.Length != 0)
    {
      if (bool_2)
      {
        Point3D P1 = Class5.smethod_118(this, arc.StartPoint, point3D_1);
        Vector3D vector3D = new Vector3D(arc.Center, arc.EndPoint);
        vector3D.Normalize();
        Vector3D Y = Vector3D.Cross(Vector3D.AxisZ, vector3D);
        Y.Normalize();
        Plane arcPlane = new Plane(arc.Center, vector3D, Y);
        Vector2D u = new Vector2D((Point2D) arc.Center, (Point2D) arc.EndPoint);
        u.Normalize();
        Vector2D v = new Vector2D((Point2D) arc.Center, (Point2D) P1);
        v.Normalize();
        double endAngleInRadians = Vector2D.SignedAngleBetween(u, v);
        this.Entities.Remove(Sketcher2D.secondSelectedEntity);
        Sketcher2D.secondSelectedEntity = (Entity) new Arc(arcPlane, arcPlane.Origin, arc.Radius, 0.0, endAngleInRadians);
      }
      else
      {
        Point3D P1 = Class5.smethod_118(this, arc.EndPoint, point3D_1);
        Vector3D vector3D = new Vector3D(arc.Center, arc.StartPoint);
        vector3D.Normalize();
        Vector3D Y = Vector3D.Cross(Vector3D.AxisZ, vector3D);
        Y.Normalize();
        Plane arcPlane = new Plane(arc.Center, vector3D, Y);
        Vector2D u = new Vector2D((Point2D) arc.Center, (Point2D) arc.StartPoint);
        u.Normalize();
        Vector2D v = new Vector2D((Point2D) arc.Center, (Point2D) P1);
        v.Normalize();
        double endAngleInRadians = Vector2D.SignedAngleBetween(u, v);
        this.Entities.Remove(Sketcher2D.secondSelectedEntity);
        Sketcher2D.secondSelectedEntity = (Entity) new Arc(arcPlane, arcPlane.Origin, arc.Radius, 0.0, endAngleInRadians);
      }
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  private bool method_10(ICurve icurve_0, ICurve icurve_1, bool bool_2)
  {
    EllipticalArc ellipticalArc = icurve_0 as EllipticalArc;
    Ellipse C2 = new Ellipse(ellipticalArc.Plane, ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY);
    Point3D[] point3D_1 = Utility.Intersection(icurve_1, (ICurve) C2);
    if (point3D_1.Length == 0)
      point3D_1 = Utility.Intersection(Class5.smethod_175(this, icurve_1), (ICurve) C2);
    bool flag;
    if (point3D_1.Length != 0)
    {
      Plane plane = ellipticalArc.Plane;
      EllipticalArc entity_1;
      if (bool_2)
      {
        Point3D end = Class5.smethod_118(this, ellipticalArc.StartPoint, point3D_1);
        entity_1 = new EllipticalArc(plane, ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY, ellipticalArc.EndPoint, end, false);
        double t;
        entity_1.ClosestPointTo(ellipticalArc.StartPoint, out t);
        if (entity_1.PointAt(t).DistanceTo(ellipticalArc.StartPoint) > 0.1)
          entity_1 = new EllipticalArc(plane, ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY, ellipticalArc.EndPoint, end, true);
        this.method_7((Entity) entity_1, ((Entity) icurve_0).LayerName);
      }
      else
      {
        Point3D end = Class5.smethod_118(this, ellipticalArc.EndPoint, point3D_1);
        entity_1 = new EllipticalArc(plane, ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY, ellipticalArc.StartPoint, end, false);
        double t;
        entity_1.ClosestPointTo(ellipticalArc.EndPoint, out t);
        if (entity_1.PointAt(t).DistanceTo(ellipticalArc.EndPoint) > 0.1)
          entity_1 = new EllipticalArc(plane, ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY, ellipticalArc.StartPoint, end, true);
      }
      if (entity_1 != null)
      {
        this.Entities.Remove(Sketcher2D.secondSelectedEntity);
        Sketcher2D.secondSelectedEntity = (Entity) entity_1;
        flag = true;
        goto label_12;
      }
    }
    flag = false;
label_12:
    return flag;
  }

  internal bool method_11(ICurve icurve_0, ICurve icurve_1, bool bool_2)
  {
    ICurve curve1 = icurve_0.Clone() as ICurve;
    List<Point3D> point3DList = new List<Point3D>();
    for (int index = 0; (index >= 10 ? 0 : (point3DList == null ? 1 : (point3DList.Count == 0 ? 1 : 0))) != 0; ++index)
    {
      double t = bool_2 ? curve1.Domain.t0 - curve1.Domain.Length : curve1.Domain.t1 + curve1.Domain.Length;
      curve1.ExtendAt(t);
      point3DList = ((IEnumerable<Point3D>) curve1.IntersectWith(icurve_1)).ToList<Point3D>();
    }
    bool flag;
    if (point3DList.Count == 0)
    {
      flag = false;
    }
    else
    {
      ICurve curve2 = icurve_0.Clone() as ICurve;
      curve2.ExtendBy(point3DList[0], !bool_2);
      for (int index = 1; index < point3DList.Count; ++index)
      {
        Point3D pt = point3DList[index];
        ICurve curve3 = icurve_0.Clone() as ICurve;
        curve3.ExtendBy(pt, !bool_2);
        if (curve3.Length() < curve2.Length())
          curve2 = curve3;
      }
      this.Entities.Remove((Entity) icurve_0);
      this.Entities.Add((Entity) curve2);
      flag = true;
    }
    return flag;
  }

  private int method_12<T>(T[] gparam_0) where T : ICurve
  {
    double num1 = double.MaxValue;
    int num2 = -1;
    for (int index = 0; index < gparam_0.Length; ++index)
    {
      ICurve curve = (ICurve) gparam_0[index];
      if (curve != null)
      {
        Point3D b = curve.PointAt(curve.Domain.Mid);
        double num3 = Point3D.Distance(this.point3D_0, b) + Point3D.Distance(this.point3D_1, b);
        if (num3 < num1)
        {
          num1 = num3;
          num2 = index;
        }
      }
    }
    return num2;
  }

  private Entity method_13(Entity entity_1)
  {
    if ((!(entity_1 is Circle) ? 0 : (!(entity_1 is Arc) ? 1 : 0)) != 0)
    {
      Circle circle = entity_1 as Circle;
      this.Entities.Remove(entity_1);
      entity_1 = (Entity) new Arc(circle.Center, circle.Radius, 2.0 * Math.PI);
    }
    else if ((!(entity_1 is Ellipse) ? 0 : (!(entity_1 is EllipticalArc) ? 1 : 0)) != 0)
    {
      Ellipse ellipse = entity_1 as Ellipse;
      this.Entities.Remove(entity_1);
      entity_1 = (Entity) new EllipticalArc(ellipse.Center, ellipse.RadiusX, ellipse.RadiusY, 2.0 * Math.PI);
    }
    return entity_1;
  }

  public Entity GetEntityByPosition(System.Drawing.Point location)
  {
    try
    {
      SelectedItem underMouseCursor = this.GetItemUnderMouseCursor(location, true);
      return underMouseCursor != null ? underMouseCursor.Item as Entity : (Entity) null;
    }
    catch (Exception ex)
    {
      return (Entity) null;
    }
  }

  private Point3D method_14(Point3D point3D_2, bool bool_2)
  {
    return bool_2 ? point3D_2 : this.WorldToScreen(point3D_2);
  }

  private Point3D[] method_15(Point3D[] point3D_2, bool bool_2)
  {
    return bool_2 ? point3D_2 : this.WorldToScreen((IList<Point3D>) point3D_2);
  }

  private double method_16(Point3D point3D_2, Point3D point3D_3, bool bool_2)
  {
    Point3D point = point3D_2.Clone() as Point3D;
    if ((!bool_2 ? 0 : (this.CurrentTransformation != (Transformation) null ? 1 : 0)) != 0)
      point.TransformBy(this.CurrentTransformation);
    return this.WorldToScreen(point).DistanceTo(this.WorldToScreen(point3D_3));
  }

  public OsnapPoint Snaping()
  {
    try
    {
      if (this.CurrentSketch == null & clsVar.varEditorRuntimeSet.isSketchMode)
        return (OsnapPoint) null;
      devDept.Eyeshot.Entities.Point point = this.Entities.OfType<devDept.Eyeshot.Entities.Point>().Where<devDept.Eyeshot.Entities.Point>((Func<devDept.Eyeshot.Entities.Point, bool>) (point_3 => this.method_16(point_3.Position, this.mouseWorldLoc, true) <= (double) clsVar.varEditorSet.snapGridPixel)).OrderBy<devDept.Eyeshot.Entities.Point, double>((Func<devDept.Eyeshot.Entities.Point, double>) (point_3 => this.method_16(point_3.Position, this.mouseWorldLoc, true))).FirstOrDefault<devDept.Eyeshot.Entities.Point>();
      this.bool_0 = false;
      this.point_1 = (devDept.Eyeshot.Entities.Point) null;
      if (point != null)
      {
        this.point_1 = point;
        this.bool_0 = this.point_1 != null;
        if (!(clsVar.varEditorSet.OsnapOver & !clsVar.varEditorRuntimeSet.OsnapOverDisable))
          return (OsnapPoint) null;
        Point3D point3D = this.point_1.Position.Clone() as Point3D;
        if (this.CurrentTransformation != (Transformation) null)
          point3D.TransformBy(this.CurrentTransformation);
        return new OsnapPoint(point3D, osnapType.Over);
      }
      if (!this.bool_1)
        ;
      if (!this.ActiveViewport.Grid.Visible)
        return (OsnapPoint) null;
      double step = this.ActiveViewport.Grid.Step;
      Point3D point3D1 = new Point3D((double) (int) Math.Round(Sketcher2D.mousePlnLoc.X / step) * step, (double) (int) Math.Round(Sketcher2D.mousePlnLoc.Y / step) * step);
      if (this.CurrentSketch != null)
        this.bool_0 = this.method_16(this.CurrentSketch.DrawingPlane.PointAt((Point2D) point3D1), this.mouseWorldLoc, false) <= (double) clsVar.varEditorSet.snapGridPixel;
      return this.bool_0 & clsInit.appEditor.action != 0 && clsVar.varEditorSet.OsnapGrid & !clsVar.varEditorRuntimeSet.OsnapGridDisable ? new OsnapPoint(point3D1, osnapType.Grid) : (OsnapPoint) null;
    }
    catch (Exception ex)
    {
      return (OsnapPoint) null;
    }
  }

  private OsnapPoint method_17(OsnapPoint[] osnapPoint_2)
  {
    double num1 = double.MaxValue;
    int num2 = 0;
    int index = -1;
    foreach (Point3D point in osnapPoint_2)
    {
      double num3 = Point2D.Distance((Point2D) this.WorldToScreen(point), new Point2D((double) this.mouseloc.X, (double) (this.Size.Height - this.mouseloc.Y)));
      if (num3 < num1 & num3 <= (double) clsVar.varEditorSet.snapSymbolSize)
      {
        index = num2;
        num1 = num3;
      }
      ++num2;
    }
    OsnapPoint osnapPoint = (OsnapPoint) null;
    if (index >= 0)
      osnapPoint = (OsnapPoint) osnapPoint_2.GetValue(index);
    return osnapPoint;
  }

  private void method_18(OsnapPoint osnapPoint_2)
  {
    double num1 = (double) this.RenderContext.SetLineSize(2f);
    this.RenderContext.SetColorWireframe(Color.FromArgb(0, 0, (int) byte.MaxValue));
    long num2 = (long) this.RenderContext.SetState(depthStencilStateType.DepthTestOff);
    Point2D screen = (Point2D) this.WorldToScreen((Point3D) osnapPoint_2);
    switch (osnapPoint_2.Type)
    {
      case osnapType.Point:
        this.DrawQuad(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        break;
      case osnapType.Middle:
        this.DrawTriangle(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        break;
      case osnapType.Center:
        this.DrawCircle(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        break;
      case osnapType.Outer:
        this.DrawRhombus(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        break;
      case osnapType.Over:
        this.DrawCircle(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        this.DrawCross(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        break;
      case osnapType.Grid:
        this.DrawCross(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        this.DrawQuad(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        break;
    }
    double num3 = (double) this.RenderContext.SetLineSize(1f);
  }

  private Entity method_19(
    System.Drawing.Point point_3,
    IList<Entity> ilist_0,
    ref Transformation transformation_0)
  {
    int[] selectedIndices;
    this.GetCrossingEntities(new Rectangle(point_3.X - 5, point_3.Y - 5, 10, 10), ilist_0, false, out selectedIndices, accParentTransform: transformation_0);
    Entity entity;
    if ((selectedIndices == null ? 0 : (selectedIndices.Length != 0 ? 1 : 0)) != 0)
    {
      if (ilist_0[selectedIndices[0]] is BlockReference)
      {
        BlockReference blockReference = (BlockReference) ilist_0[selectedIndices[0]];
        transformation_0 *= blockReference.GetFullTransformation(this.Blocks);
        entity = this.method_19(point_3, (IList<Entity>) this.Blocks[blockReference.BlockName].Entities, ref transformation_0);
        goto label_12;
      }
      if (selectedIndices.Length == 1)
      {
        entity = ilist_0[selectedIndices[0]];
        goto label_12;
      }
      if (selectedIndices.Length > 1)
      {
        for (int index = 0; index <= selectedIndices.Length - 1; ++index)
        {
          if (ilist_0[selectedIndices[index]] is ICurve)
          {
            entity = ilist_0[selectedIndices[index]];
            goto label_12;
          }
        }
      }
    }
    entity = (Entity) null;
label_12:
    return entity;
  }

  public OsnapPoint[] GetSnapPoints(System.Drawing.Point mouseLocation)
  {
    int pickBoxSize = this.PickBoxSize;
    this.PickBoxSize = 10;
    Transformation transformation_0 = (Transformation) new Identity();
    Entity entity = this.method_19(mouseLocation, (IList<Entity>) this.Entities, ref transformation_0);
    this.PickBoxSize = pickBoxSize;
    OsnapPoint[] snapPoints = new OsnapPoint[0];
    if (entity != null && clsVar.varEditorSet.OsnapEntity & !clsVar.varEditorRuntimeSet.OsnapEntityDisable)
    {
      switch (entity)
      {
        case devDept.Eyeshot.Entities.Point _:
          if (!clsVar.varEditorRuntimeSet.OsnapPointDisable)
          {
            snapPoints = new OsnapPoint[1]
            {
              new OsnapPoint(entity.Vertices[0], osnapType.Point)
            };
            break;
          }
          break;
        case Line _:
          Line line = (Line) entity;
          snapPoints = new OsnapPoint[3]
          {
            new OsnapPoint(line.StartPoint, osnapType.Point),
            new OsnapPoint(line.EndPoint, osnapType.Point),
            new OsnapPoint(line.MidPoint, osnapType.Middle)
          };
          break;
        case LinearPath _:
          LinearPath linearPath = (LinearPath) entity;
          List<OsnapPoint> osnapPointList1 = new List<OsnapPoint>();
          foreach (Point3D vertex in linearPath.Vertices)
            osnapPointList1.Add(new OsnapPoint(vertex, osnapType.Point));
          snapPoints = osnapPointList1.ToArray();
          break;
        case CompositeCurve _:
          CompositeCurve compositeCurve = (CompositeCurve) entity;
          List<OsnapPoint> osnapPointList2 = new List<OsnapPoint>();
          foreach (ICurve curve in compositeCurve.CurveList)
            osnapPointList2.Add(new OsnapPoint(curve.EndPoint, osnapType.Point));
          osnapPointList2.Add(new OsnapPoint(compositeCurve.CurveList[0].StartPoint, osnapType.Point));
          snapPoints = osnapPointList2.ToArray();
          break;
        case Arc _:
          Arc arc = (Arc) entity;
          snapPoints = new OsnapPoint[4]
          {
            new OsnapPoint(arc.StartPoint, osnapType.Point),
            new OsnapPoint(arc.EndPoint, osnapType.Point),
            new OsnapPoint(arc.MidPoint, osnapType.Middle),
            new OsnapPoint(arc.Center, osnapType.Center)
          };
          break;
        case Circle _:
          Circle circle = (Circle) entity;
          Point3D point3D1 = new Point3D(circle.Center.X, circle.Center.Y + circle.Radius);
          Point3D point3D2 = new Point3D(circle.Center.X + circle.Radius, circle.Center.Y);
          Point3D point3D3 = new Point3D(circle.Center.X, circle.Center.Y - circle.Radius);
          Point3D point3D4 = new Point3D(circle.Center.X - circle.Radius, circle.Center.Y);
          snapPoints = new OsnapPoint[6]
          {
            new OsnapPoint(circle.EndPoint, osnapType.Point),
            new OsnapPoint(circle.Center, osnapType.Center),
            new OsnapPoint(point3D1, osnapType.Outer),
            new OsnapPoint(point3D2, osnapType.Outer),
            new OsnapPoint(point3D3, osnapType.Outer),
            new OsnapPoint(point3D4, osnapType.Outer)
          };
          break;
        case Curve _:
          Curve curve1 = (Curve) entity;
          snapPoints = new OsnapPoint[3]
          {
            new OsnapPoint(curve1.StartPoint, osnapType.Point),
            new OsnapPoint(curve1.EndPoint, osnapType.Point),
            new OsnapPoint(curve1.PointAt(0.5), osnapType.Middle)
          };
          break;
        case EllipticalArc _:
          EllipticalArc ellipticalArc = (EllipticalArc) entity;
          snapPoints = new OsnapPoint[3]
          {
            new OsnapPoint(ellipticalArc.StartPoint, osnapType.Point),
            new OsnapPoint(ellipticalArc.EndPoint, osnapType.Point),
            new OsnapPoint(ellipticalArc.Center, osnapType.Center)
          };
          break;
        case Ellipse _:
          Ellipse ellipse = (Ellipse) entity;
          snapPoints = new OsnapPoint[2]
          {
            new OsnapPoint(ellipse.EndPoint, osnapType.Point),
            new OsnapPoint(ellipse.Center, osnapType.Center)
          };
          break;
        case Mesh _:
          Mesh mesh = (Mesh) entity;
          snapPoints = new OsnapPoint[mesh.Vertices.Length];
          for (int index = 0; index < mesh.Vertices.Length; ++index)
          {
            Point3D vertex = mesh.Vertices[index];
            snapPoints[index] = new OsnapPoint(vertex, osnapType.Point);
          }
          break;
      }
    }
    if (transformation_0 != (Transformation) new Identity())
    {
      foreach (OsnapPoint osnapPoint in snapPoints)
      {
        Point3D point3D5 = transformation_0 * (Point3D) osnapPoint;
        osnapPoint.X = point3D5.X;
        osnapPoint.Y = point3D5.Y;
        osnapPoint.Z = point3D5.Z;
      }
    }
    return snapPoints;
  }

  public void DrawCross(System.Drawing.Point onScreen)
  {
    double x1 = (double) (onScreen.X + clsVar.varEditorSet.snapSymbolSize / 2);
    double y1 = (double) (onScreen.Y + clsVar.varEditorSet.snapSymbolSize / 2);
    double x2 = (double) (onScreen.X - clsVar.varEditorSet.snapSymbolSize / 2);
    double y2 = (double) (onScreen.Y - clsVar.varEditorSet.snapSymbolSize / 2);
    Point3D point3D1 = new Point3D(x2, y1);
    Point3D point3D2 = new Point3D(x1, y1);
    Point3D point3D3 = new Point3D(x1, y2);
    this.RenderContext.DrawLines(new Point3D[4]
    {
      new Point3D(x2, y2),
      point3D2,
      point3D1,
      point3D3
    });
  }

  public void DrawCircle(System.Drawing.Point onScreen)
  {
    double num = (double) (clsVar.varEditorSet.snapSymbolSize / 2);
    List<Point3D> point3DList = new List<Point3D>();
    for (int degrees = 0; degrees < 360; degrees += 10)
    {
      double rad = Utility.DegToRad((double) degrees);
      Point3D point3D = new Point3D((double) onScreen.X + num * Math.Cos(rad), (double) onScreen.Y + num * Math.Sin(rad));
      point3DList.Add(point3D);
    }
    this.RenderContext.DrawLineLoop(point3DList.ToArray());
  }

  public void DrawQuad(System.Drawing.Point onScreen)
  {
    double x1 = (double) (onScreen.X + clsVar.varEditorSet.snapSymbolSize / 2);
    double y1 = (double) (onScreen.Y + clsVar.varEditorSet.snapSymbolSize / 2);
    double x2 = (double) (onScreen.X - clsVar.varEditorSet.snapSymbolSize / 2);
    double y2 = (double) (onScreen.Y - clsVar.varEditorSet.snapSymbolSize / 2);
    Point3D point3D1 = new Point3D(x2, y1);
    Point3D point3D2 = new Point3D(x1, y1);
    Point3D point3D3 = new Point3D(x1, y2);
    this.RenderContext.DrawLineLoop(new Point3D[4]
    {
      new Point3D(x2, y2),
      point3D3,
      point3D2,
      point3D1
    });
  }

  public void DrawTriangle(System.Drawing.Point onScreen)
  {
    double x1 = (double) (onScreen.X + clsVar.varEditorSet.snapSymbolSize / 2);
    double y1 = (double) (onScreen.Y + clsVar.varEditorSet.snapSymbolSize / 2);
    double x2 = (double) (onScreen.X - clsVar.varEditorSet.snapSymbolSize / 2);
    double y2 = (double) (onScreen.Y - clsVar.varEditorSet.snapSymbolSize / 2);
    Point3D point3D1 = new Point3D((double) onScreen.X, y1);
    Point3D point3D2 = new Point3D(x1, y2);
    this.RenderContext.DrawLineLoop(new Point3D[3]
    {
      new Point3D(x2, y2),
      point3D2,
      point3D1
    });
  }

  public void DrawRhombus(System.Drawing.Point onScreen)
  {
    double x1 = (double) onScreen.X + (double) clsVar.varEditorSet.snapSymbolSize / 1.5;
    double y1 = (double) onScreen.Y + (double) clsVar.varEditorSet.snapSymbolSize / 1.5;
    double x2 = (double) onScreen.X - (double) clsVar.varEditorSet.snapSymbolSize / 1.5;
    double y2 = (double) onScreen.Y - (double) clsVar.varEditorSet.snapSymbolSize / 1.5;
    Point3D point3D1 = new Point3D((double) onScreen.X, y1);
    Point3D point3D2 = new Point3D((double) onScreen.X, y2);
    Point3D point3D3 = new Point3D(x1, (double) onScreen.Y);
    Point3D point3D4 = new Point3D(x2, (double) onScreen.Y);
    this.RenderContext.DrawLineLoop(new Point3D[4]
    {
      point3D2,
      point3D3,
      point3D1,
      point3D4
    });
  }
}
