// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Editor.Drafting2D
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5;
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

public class Drafting2D : Design
{
  private Timer timer_0 = (Timer) null;
  private System.Drawing.Point point_0;
  public static Point3D boxMin = new Point3D();
  public static Point3D boxMid = new Point3D();
  public static Point3D boxMax = new Point3D();
  public Point3D current;
  public Point3D lastPoint;
  protected Point2D mousePlnLoc = new Point2D();
  public Plane plane = Plane.XY;
  public Plane drawingPlane;
  public static List<UClick> points = new List<UClick>();
  public double radius;
  public double radiusY;
  public double arcSpanAngle = 0.0;
  public bool editingMode;
  internal Point3D point3D_0 = (Point3D) null;
  public Point3D midPoint = (Point3D) null;
  public bool ObjectSnapEnabled;
  public static bool firstClick = true;
  public static bool selectionProcess = false;
  public static bool buttonPressedForSelection = false;
  public static bool _dragging = false;
  public string ActiveLayerName = "Default";
  public objectSnapType ActiveObjectSnap = objectSnapType.End;
  public bool currentlySnapping = false;
  public List<Drafting2D.SnapPoint> snapPoints = new List<Drafting2D.SnapPoint>();
  public static pickStateType currPickState;
  public static System.Drawing.Point mouseDownLocation;
  public int entityPickIndex = -1;
  public int selEntityIndex = -1;
  public static List<List<int>> selectedIndex = new List<List<int>>();
  public static Entity entitySelected = (Entity) null;
  public static List<Entity> entitiesSelected = new List<Entity>();
  public List<Entity> selEntities = new List<Entity>();
  public static SelectedItem entityMouseUnder = (SelectedItem) null;
  internal int[] int_0 = (int[]) null;
  public static Entity entToTrim;
  public static List<Entity> leftOvers = new List<Entity>();
  public Entity secondSelectedEntity = (Entity) null;
  public Entity firstSelectedEntity = (Entity) null;
  internal Point3D point3D_1;
  internal Point3D point3D_2;
  public static bool NoRectangleSelection = false;
  private ISelectableItem iselectableItem_0;

  public Drafting2D()
  {
    if (this.IsDesignMode())
      return;
    this.LoadDocument((DesignDocument) new SketcherDesignDocument());
    this.WaitCursorMode = waitCursorType.Never;
    this.Clear();
    this.timer_0 = new Timer();
    this.timer_0.Interval = 100;
    this.timer_0.Tick += new EventHandler(this.Tick_Add);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    try
    {
      this.point_0 = e.Location;
      if ((this.current == (Point3D) null || this.ActionMode != devDept.Eyeshot.actionType.None ? 1 : (this.ToolBar.Contains(this.point_0) ? 1 : 0)) != 0)
      {
        base.OnMouseMove(e);
      }
      else
      {
        if (this.CurrentSketch != null)
          this.mousePlnLoc = this.CurrentSketch.DrawingPlane.Project(this.current);
        if (clsItem.frmEditorV2 != null)
        {
          clsItem.frmEditorV2.lbl_x.Text = "X: " + this.current.X.ToString("f2");
          clsItem.frmEditorV2.lbl_y.Text = "Y: " + this.current.Y.ToString("f2");
        }
        this.int_0 = (int[]) null;
        Drafting2D.entityMouseUnder = this.GetItemUnderMouseCursor(this.point_0, true);
        this.int_0 = this.GetAllEntitiesUnderMouseCursor(this.point_0);
        int underMouseCursor = this.GetLabelUnderMouseCursor(e.Location);
        if (Drafting2D.entityMouseUnder != null)
          ;
        if (Drafting2D.entityMouseUnder == null & underMouseCursor >= 0 && this.ActiveViewport.Labels[underMouseCursor] is StackedLabel)
          this.CurrentSketch.DisplayConstraintEntities((this.ActiveViewport.Labels[underMouseCursor] as StackedLabel).Constraint);
        if (Drafting2D.buttonPressedForSelection & Drafting2D.selectionProcess)
        {
          int num = e.Location.X - Drafting2D.mouseDownLocation.X;
          if (num > 10)
          {
            if (!clsVar.varSelection.DontUseRectangleSelection)
              Drafting2D.currPickState = pickStateType.Enclosed;
          }
          else if (num < -10)
          {
            if (!clsVar.varSelection.DontUseRectangleSelection)
              Drafting2D.currPickState = pickStateType.Crossing;
          }
          else
            Drafting2D.currPickState = pickStateType.Pick;
          if (ccVars.selectionOnlyPick | Drafting2D.NoRectangleSelection)
            Drafting2D.currPickState = pickStateType.Pick;
        }
        if (clsInit.appEditor2.action == actionTypeBU.eventTrim)
          this.method_14();
        this.PaintBackBuffer();
        this.SwapBuffers();
        base.OnMouseMove(e);
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok: " + ex.Message, "MouseMove");
    }
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    try
    {
      System.Drawing.Point location = e.Location;
      Drafting2D.mouseDownLocation = e.Location;
      if (this.ToolBar.Contains(location))
      {
        base.OnMouseDown(e);
      }
      else
      {
        Entity entity = (Entity) null;
        this.iselectableItem_0 = (ISelectableItem) this.GetEntityByPosition(e.Location);
        if (this.iselectableItem_0 is Entity)
        {
          entity = (Entity) this.iselectableItem_0;
          if (clsVar.varEditorRuntimeSet.isSketchMode)
          {
            Drafting2D._dragging = true;
            if (!entity.Selected)
            {
              this.CurrentSketch.DragStart(this.mousePlnLoc, entity);
              entity.Selected = true;
            }
            else
            {
              this.ActionMode = devDept.Eyeshot.actionType.None;
              this.CurrentSketch.DragStart(this.mousePlnLoc, this.Entities.Where<Entity>((Func<Entity, bool>) (entity_0 => entity_0.Selected)).ToArray<Entity>());
            }
          }
        }
        this.ScreenToPlane(location, this.plane, out this.current);
        this.PointToOsnap();
        if (e.Button == MouseButtons.Left & Drafting2D.selectionProcess & Drafting2D.selectionProcess & !Drafting2D._dragging)
        {
          Drafting2D.buttonPressedForSelection = true;
          Drafting2D.mouseDownLocation = e.Location;
          Drafting2D.currPickState = pickStateType.Pick;
        }
        this.selEntityIndex = this.GetEntityUnderMouseCursor(location);
        if ((!(this.ActionMode == devDept.Eyeshot.actionType.None & clsInit.appEditor2.action != 0) ? 0 : (e.Button == MouseButtons.Left ? 1 : 0)) != 0 && !Drafting2D.selectionProcess)
        {
          Drafting2D.points.Add(new UClick(new Point2D(this.current.X, this.current.Y), this.current, entity));
          if (clsInit.appEditor2.action == actionTypeBU.drawLine)
          {
            clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineNextPoint, buLangTranslate.preDef.Line);
            if (!clsVar.varEditorRuntimeSet.isSketchMode)
            {
              if (Drafting2D.points.Count >= 2)
                clsInit.appEditor2.AddLine(Drafting2D.points[Drafting2D.points.Count - 2], Drafting2D.points[Drafting2D.points.Count - 1]);
            }
            else if (Drafting2D.points.Count == 2)
              Drafting2D.points[Drafting2D.points.Count - 1].Entity = (Entity) clsInit.appEditor2.AddLine(Drafting2D.points[Drafting2D.points.Count - 2], Drafting2D.points[Drafting2D.points.Count - 1]);
            else if (Drafting2D.points.Count > 2)
            {
              Drafting2D.points[Drafting2D.points.Count - 1].Entity = (Entity) clsInit.appEditor2.ExtendLine((Line) Drafting2D.points[Drafting2D.points.Count - 2].Entity, Drafting2D.points[Drafting2D.points.Count - 1]);
              if (buCompare5.EQ(Drafting2D.points[0].Position, Drafting2D.points[Drafting2D.points.Count - 1].Position))
              {
                this.ClearAllPreviousCommandData();
                clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
              }
            }
          }
          else if (clsInit.appEditor2.action == actionTypeBU.drawPolyline)
          {
            clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineNextPoint, buLangTranslate.preDef.Polyline);
            if (Drafting2D.points.Count >= 2 && buCompare5.EQ((Point2D) Drafting2D.points[0].Pnt3D, Drafting2D.points[Drafting2D.points.Count - 1].Position))
              clsInit.appEditor2.AddPolyLine(Drafting2D.points);
          }
          else if ((clsInit.appEditor2.action != actionTypeBU.drawPoint ? 0 : (Drafting2D.points.Count == 1 ? 1 : 0)) != 0)
            clsInit.appEditor2.AddPoint(Drafting2D.points[0]);
          else if (clsInit.appEditor2.action == actionTypeBU.drawCircle)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOutsidePoint, buLangTranslate.preDef.Cirlce);
            if (Drafting2D.points.Count == 2)
              clsInit.appEditor2.AddCircle(Drafting2D.points[0], Drafting2D.points[1]);
          }
          else if (clsInit.appEditor2.action == actionTypeBU.drawCircle3Point)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineSecondPoint, buLangTranslate.preDef.Cirlce);
            if (Drafting2D.points.Count == 2)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineThirdPoint, buLangTranslate.preDef.Cirlce);
            if (Drafting2D.points.Count == 3 && Point2D.Distance((Point2D) Drafting2D.points[0].Pnt3D, Drafting2D.points[1].Position) > 0.0 & Point2D.Distance((Point2D) Drafting2D.points[0].Pnt3D, Drafting2D.points[2].Position) > 0.0 & Point2D.Distance(Drafting2D.points[1].Position, Drafting2D.points[2].Position) > 0.0)
              clsInit.appEditor2.AddCircle(Drafting2D.points[0], Drafting2D.points[1], Drafting2D.points[2]);
          }
          else if (clsInit.appEditor2.action == actionTypeBU.drawArc)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineNextPoint, buLangTranslate.preDef.Arc);
            if (Drafting2D.points.Count == 2)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineLastPoint, buLangTranslate.preDef.Arc);
            if (Drafting2D.points.Count == 3)
            {
              this.drawingPlane = Class5.smethod_209(this, Drafting2D.points[1].Pnt3D);
              Vector2D u = new Vector2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) Drafting2D.points[1].Pnt3D);
              u.Normalize();
              Vector2D v = new Vector2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) this.current);
              v.Normalize();
              this.arcSpanAngle = Vector2D.SignedAngleBetween(u, v);
              clsInit.appEditor2.AddArc(this.drawingPlane, this.drawingPlane.Origin, this.radius, 0.0, this.arcSpanAngle);
            }
          }
          else if (clsInit.appEditor2.action == actionTypeBU.drawArc3Point)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineThirdPoint, buLangTranslate.preDef.Arc);
            if (Drafting2D.points.Count == 2)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineSecondPoint, buLangTranslate.preDef.Arc);
            if (Drafting2D.points.Count == 3 && Point2D.Distance((Point2D) Drafting2D.points[0].Pnt3D, Drafting2D.points[1].Position) > 0.0 & Point2D.Distance((Point2D) Drafting2D.points[0].Pnt3D, Drafting2D.points[2].Position) > 0.0 & Point2D.Distance(Drafting2D.points[1].Position, Drafting2D.points[2].Position) > 0.0 && clsInit.appEditor2.EvaluateArc((Point2D) Drafting2D.points[0].Pnt3D, Drafting2D.points[2].Position, Drafting2D.points[1].Position, out bool _))
              clsInit.appEditor2.AddArc(Drafting2D.points[0], Drafting2D.points[2], Drafting2D.points[1]);
          }
          else if (clsInit.appEditor2.action == actionTypeBU.drawEllipse)
          {
            if (clsVar.varEditorRuntimeSet.isSketchMode)
            {
              if (Drafting2D.points.Count == 1)
                clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOutsidePoint, buLangTranslate.preDef.Ellipse);
              if (Drafting2D.points.Count == 2)
                clsInit.appEditor2.AddEllipse(Drafting2D.points[0], Drafting2D.points[1]);
            }
            else
            {
              if (Drafting2D.points.Count == 1)
                clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineSecondPoint, buLangTranslate.preDef.Ellipse);
              if (Drafting2D.points.Count == 2)
                clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOutsidePoint, buLangTranslate.preDef.Ellipse);
              if (Drafting2D.points.Count == 3)
              {
                Ellipse Ent = new Ellipse(this.drawingPlane, this.drawingPlane.Origin, this.radius, this.radiusY);
                clsInit.appEditor2.AddEllipse(Ent);
              }
            }
          }
          else if (clsInit.appEditor2.action == actionTypeBU.drawRectangle)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineSecondPoint, buLangTranslate.preDef.Rectangle);
            if (Drafting2D.points.Count == 2)
              clsInit.appEditor2.AddRectangle(Drafting2D.points[0], Drafting2D.points[1]);
          }
          else if (clsInit.appEditor2.action == actionTypeBU.drawPolygon)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOutsidePoint, buLangTranslate.preDef.Polygon);
            if (Drafting2D.points.Count == 2)
              clsInit.appEditor2.AddPolygon(Drafting2D.points[0], Drafting2D.points[1]);
          }
          else if (clsInit.appEditor2.action == actionTypeBU.drawSlot)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineSecondPoint, buLangTranslate.preDef.Slot);
            if (Drafting2D.points.Count == 2)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOutsidePoint, buLangTranslate.preDef.Slot);
            if (Drafting2D.points.Count == 3)
              clsInit.appEditor2.AddSlot(Drafting2D.points[0], Drafting2D.points[1], Drafting2D.points[2]);
          }
          else if ((clsInit.appEditor2.action != actionTypeBU.drawCurve ? 0 : (Drafting2D.points.Count >= 3 ? 1 : 0)) != 0)
          {
            clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineNextPoint, buLangTranslate.preDef.Curve);
            if (buCompare5.EQ(Drafting2D.points[0].Pnt3D, Drafting2D.points.Last<UClick>().Pnt3D))
              clsInit.appEditor2.AddCurve(Drafting2D.points);
          }
          if (this.lastPoint == (Point3D) null)
            this.lastPoint = new Point3D();
          this.lastPoint.X = this.current.X;
          this.lastPoint.Y = this.current.Y;
          if (clsInit.appEditor2.action == actionTypeBU.eventMove)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineMovePoint, buLangTranslate.preDef.Move);
            if (Drafting2D.points.Count == 2)
              this.EventMove();
          }
          if (clsInit.appEditor2.action == actionTypeBU.eventCopy)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineCopyPoint, buLangTranslate.preDef.Copy);
            if (Drafting2D.points.Count == 2)
              this.EventCopy();
          }
          if (clsInit.appEditor2.action == actionTypeBU.eventRotate)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Rotate);
            if (Drafting2D.points.Count == 2)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineRotatePoint, buLangTranslate.preDef.Rotate);
            if (Drafting2D.points.Count == 3)
              this.EventRotate();
          }
          if (clsInit.appEditor2.action == actionTypeBU.eventMirror)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineMirrorPoint, buLangTranslate.preDef.Mirror);
            if (Drafting2D.points.Count == 2)
              this.EventMirror();
          }
          if (clsInit.appEditor2.action == actionTypeBU.eventScale)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Scale);
            if (Drafting2D.points.Count == 2)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineScalePoint, buLangTranslate.preDef.Scale);
            if (Drafting2D.points.Count == 3)
              this.EventScale();
          }
          if ((clsInit.appEditor2.action != actionTypeBU.eventOffset ? 0 : (Drafting2D.points.Count == 1 ? 1 : 0)) != 0)
            this.EventOffset();
          if (clsInit.appEditor2.action == actionTypeBU.eventLineerArray)
          {
            if (Drafting2D.points.Count == 1)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineNextPoint, buLangTranslate.preDef.Array);
            if (Drafting2D.points.Count == 2)
              this.EventLinearArray();
          }
          this.HandleLibraryAction(entity);
        }
        if ((this.ActionMode != devDept.Eyeshot.actionType.None ? 0 : (e.Button == MouseButtons.Right ? 1 : 0)) != 0)
        {
          if (clsInit.appEditor2.action == actionTypeBU.drawPolyline)
          {
            if (Drafting2D.points.Count >= 2)
              clsInit.appEditor2.AddPolyLine(Drafting2D.points);
          }
          else if (clsInit.appEditor2.action == actionTypeBU.drawCurve)
          {
            if (Drafting2D.points.Count >= 2)
              clsInit.appEditor2.AddCurve(Drafting2D.points);
          }
          else if (clsInit.appEditor2.action == actionTypeBU.drawLine)
            this.ClearAllPreviousCommandData();
          if (clsInit.appEditor2.action == actionTypeBU.eventDelete)
            this.EventDelete();
          if (clsInit.appEditor2.action == actionTypeBU.eventMove | clsInit.appEditor2.action == actionTypeBU.eventCopy | clsInit.appEditor2.action == actionTypeBU.eventMirror | clsInit.appEditor2.action == actionTypeBU.eventRotate | clsInit.appEditor2.action == actionTypeBU.eventOffset | clsInit.appEditor2.action == actionTypeBU.eventScale | clsInit.appEditor2.action == actionTypeBU.eventLineerArray | clsInit.appEditor2.action == actionTypeBU.eventExplode)
          {
            if (clsInit.appEditor2.action == actionTypeBU.eventMove)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Move);
            if (clsInit.appEditor2.action == actionTypeBU.eventCopy)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Copy);
            if (clsInit.appEditor2.action == actionTypeBU.eventMirror)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Mirror);
            if (clsInit.appEditor2.action == actionTypeBU.eventMove | clsInit.appEditor2.action == actionTypeBU.eventCopy | clsInit.appEditor2.action == actionTypeBU.eventMirror)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Move);
            if (clsInit.appEditor2.action == actionTypeBU.eventRotate)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineCenterPoint, buLangTranslate.preDef.Move);
            if (clsInit.appEditor2.action == actionTypeBU.eventOffset)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOffsetPoint, buLangTranslate.preDef.Offset);
            if (clsInit.appEditor2.action == actionTypeBU.eventScale)
              clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Scale);
            if (clsInit.appEditor2.action == actionTypeBU.eventExplode)
              clsInit.appEditor2.StatusUpdate("Apply explode options", "Explode");
            this.EventCopyToSelected();
          }
        }
        base.OnMouseDown(e);
      }
    }
    catch (Exception ex)
    {
      this.ReportDraftingError(ex, "MouseDown");
    }
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    int[] selectedIndices = (int[]) null;
    this.entityPickIndex = -1;
    if (Drafting2D.selectionProcess & e.Button == MouseButtons.Left & Drafting2D.buttonPressedForSelection)
    {
      List<int> intList1 = new List<int>();
      List<int> intList2 = new List<int>();
      if (Drafting2D.buttonPressedForSelection)
      {
        if (this.CurrentBlockReference != null)
        {
          EntityList entities = this.Blocks[this.CurrentBlockReference.BlockName].Entities;
        }
        else
        {
          List<Entity> entityList = new List<Entity>((IEnumerable<Entity>) this.Entities);
        }
        Drafting2D.buttonPressedForSelection = false;
        System.Drawing.Point location1 = e.Location;
        int num1 = location1.X - Drafting2D.mouseDownLocation.X;
        location1 = e.Location;
        int num2 = location1.Y - Drafting2D.mouseDownLocation.Y;
        System.Drawing.Point mouseDownLocation = Drafting2D.mouseDownLocation;
        System.Drawing.Point location2 = e.Location;
        Class5.smethod_158(ref location2, ref mouseDownLocation);
        switch (Drafting2D.currPickState)
        {
          case pickStateType.Pick:
            this.entityPickIndex = this.GetEntityUnderMouseCursor(e.Location);
            this.GetAllEntitiesUnderMouseCursor(e.Location);
            if (this.entityPickIndex >= 0 && this.Entities[this.entityPickIndex].Selectable)
            {
              if (!this.Entities[this.entityPickIndex].Selected)
              {
                this.Entities[this.entityPickIndex].Selected = true;
                break;
              }
              this.Entities[this.entityPickIndex].Selected = false;
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
        if (e.Button != MouseButtons.Left || selectedIndices == null || selectedIndices.Length == 0)
          ;
        this.Invalidate();
      }
    }
    if ((!(this.ActionMode == devDept.Eyeshot.actionType.None & clsInit.appEditor2.action != 0) ? 0 : (e.Button == MouseButtons.Left ? 1 : 0)) != 0)
    {
      if (!Drafting2D.selectionProcess)
      {
        if ((clsInit.appEditor2.action != actionTypeBU.eventBreak ? 0 : (Drafting2D.points.Count == 1 ? 1 : 0)) != 0)
          this.EventBreak();
        if ((clsInit.appEditor2.action != actionTypeBU.eventTrim ? 0 : (Drafting2D.points.Count == 1 ? 1 : 0)) != 0)
          this.EventTrim();
        if (clsInit.appEditor2.action == actionTypeBU.eventExtend)
          this.EventExtend();
      }
      else
      {
        if (clsInit.appEditor2.action == actionTypeBU.eventFillet)
        {
          if (this.firstSelectedEntity == null)
          {
            if (this.selEntityIndex == -1)
              return;
            this.firstSelectedEntity = this.Entities[this.selEntityIndex];
            this.selEntityIndex = -1;
            this.ScreenToPlane(this.point_0, Plane.XY, out this.point3D_1);
            clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectSecondEntity, buLangTranslate.preDef.Fillet);
            return;
          }
          if (this.secondSelectedEntity == null && this.selEntityIndex != -1)
          {
            this.secondSelectedEntity = this.Entities[this.selEntityIndex];
            this.selEntityIndex = -1;
            this.ScreenToPlane(this.point_0, Plane.XY, out this.point3D_2);
            this.EventFillet();
          }
        }
        if (clsInit.appEditor2.action == actionTypeBU.eventChamfer)
        {
          if (this.firstSelectedEntity == null)
          {
            if (this.selEntityIndex == -1)
              return;
            this.firstSelectedEntity = this.Entities[this.selEntityIndex];
            this.selEntityIndex = -1;
            this.ScreenToPlane(this.point_0, Plane.XY, out this.point3D_1);
            clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectSecondEntity, buLangTranslate.preDef.Chamfer);
            return;
          }
          if (this.secondSelectedEntity == null && this.selEntityIndex != -1)
          {
            this.secondSelectedEntity = this.Entities[this.selEntityIndex];
            this.selEntityIndex = -1;
            this.ScreenToPlane(this.point_0, Plane.XY, out this.point3D_2);
            this.EventChamfer();
          }
        }
      }
    }
    if (Drafting2D._dragging)
    {
      this.CurrentSketch.DragEnd();
      Drafting2D._dragging = false;
    }
    if (e.Button == MouseButtons.Left && clsInit.appEditor2.action == actionTypeBU.None && clsItem.frmEditorV2 != null)
    {
      bool hasSelection = false;
      for (int index = 0; index < this.Entities.Count; ++index)
      {
        if (!this.Entities[index].Selected)
          continue;
        hasSelection = true;
        break;
      }
      clsItem.frmEditorV2.grp_eventmovecmd.Visible = hasSelection;
      if (hasSelection)
        clsItem.frmEditorV2.grp_eventmovecmd.BringToFront();
    }
    base.OnMouseUp(e);
  }

  protected override void DrawOverlay(DrawSceneParams data)
  {
    this.ScreenToPlane(this.point_0, this.plane, out this.current);
    this.PointToOsnap();
    if (Drafting2D.buttonPressedForSelection)
    {
      switch (Drafting2D.currPickState)
      {
        case pickStateType.Enclosed:
          this.method_0(Drafting2D.mouseDownLocation, this.point_0, clsVar.varSelection.colorSelectionRightToLeft, clsVar.varSelection.SelectionTransparancy, true, false);
          break;
        case pickStateType.Crossing:
          this.method_0(Drafting2D.mouseDownLocation, this.point_0, clsVar.varSelection.colorSelectionLeftToRight, clsVar.varSelection.SelectionTransparancy, true, true);
          break;
      }
    }
    if (clsInit.appEditor2.action == actionTypeBU.drawLine)
      this.method_1();
    else if (clsInit.appEditor2.action == actionTypeBU.drawPolyline)
      this.method_1();
    else if ((clsInit.appEditor2.action != actionTypeBU.drawCircle ? 0 : (Drafting2D.points.Count > 0 ? 1 : 0)) != 0)
    {
      if ((this.ActionMode != devDept.Eyeshot.actionType.None ? 0 : (!this.ToolBar.Contains(this.point_0) ? 1 : 0)) != 0)
        Class5.smethod_66(this);
    }
    else if ((clsInit.appEditor2.action != actionTypeBU.drawCircle3Point ? 0 : (Drafting2D.points.Count > 0 ? 1 : 0)) != 0)
    {
      if ((this.ActionMode != devDept.Eyeshot.actionType.None ? 0 : (!this.ToolBar.Contains(this.point_0) ? 1 : 0)) != 0)
      {
        if (Drafting2D.points.Count == 1)
          this.method_1();
        if (Drafting2D.points.Count == 2)
          Class5.smethod_190(this);
      }
    }
    else if ((clsInit.appEditor2.action != actionTypeBU.drawArc ? 0 : (Drafting2D.points.Count > 0 ? 1 : 0)) != 0)
    {
      if ((this.ActionMode != devDept.Eyeshot.actionType.None ? 0 : (!this.ToolBar.Contains(this.point_0) ? 1 : 0)) != 0)
        this.method_3();
    }
    else if ((clsInit.appEditor2.action != actionTypeBU.drawArc3Point ? 0 : (Drafting2D.points.Count > 0 ? 1 : 0)) != 0)
    {
      if ((this.ActionMode != devDept.Eyeshot.actionType.None ? 0 : (!this.ToolBar.Contains(this.point_0) ? 1 : 0)) != 0)
      {
        if (Drafting2D.points.Count == 1)
          this.method_1();
        if (Drafting2D.points.Count == 2)
          Class5.smethod_45(this);
      }
    }
    else if ((clsInit.appEditor2.action != actionTypeBU.drawEllipse ? 0 : (Drafting2D.points.Count > 0 ? 1 : 0)) != 0)
      this.method_4();
    else if (clsInit.appEditor2.action == actionTypeBU.drawCurve)
      this.method_9();
    else if (clsInit.appEditor2.action == actionTypeBU.drawRectangle)
    {
      if (Drafting2D.points.Count > 0)
      {
        ICurve icurve_0_1 = (ICurve) new Line(Plane.XY, Drafting2D.points[0].Pnt3D.X, Drafting2D.points[0].Pnt3D.Y, this.current.X, Drafting2D.points[0].Pnt3D.Y);
        Class5.smethod_183(clsVar.varEditorSet.colorDynamic, this, icurve_0_1);
        ICurve icurve_0_2 = (ICurve) new Line(Plane.XY, this.current.X, Drafting2D.points[0].Pnt3D.Y, this.current.X, this.current.Y);
        Class5.smethod_183(clsVar.varEditorSet.colorDynamic, this, icurve_0_2);
        ICurve icurve_0_3 = (ICurve) new Line(Plane.XY, this.current.X, this.current.Y, Drafting2D.points[0].Pnt3D.X, this.current.Y);
        Class5.smethod_183(clsVar.varEditorSet.colorDynamic, this, icurve_0_3);
        ICurve icurve_0_4 = (ICurve) new Line(Plane.XY, Drafting2D.points[0].Pnt3D.X, this.current.Y, Drafting2D.points[0].Pnt3D.X, Drafting2D.points[0].Pnt3D.Y);
        Class5.smethod_183(clsVar.varEditorSet.colorDynamic, this, icurve_0_4);
      }
    }
    else if (clsInit.appEditor2.action == actionTypeBU.drawPolygon)
      this.method_5();
    else if (clsInit.appEditor2.action == actionTypeBU.drawSlot)
    {
      if (Drafting2D.points.Count == 1)
        this.method_1();
      if (Drafting2D.points.Count == 2)
        this.method_6();
    }
    if (clsInit.appEditor2.action == actionTypeBU.eventMove && this.selEntities.Count > 0)
      this.method_11();
    if (clsInit.appEditor2.action == actionTypeBU.eventCopy && this.selEntities.Count > 0)
      this.method_11();
    if (clsInit.appEditor2.action == actionTypeBU.eventRotate && this.selEntities.Count > 0)
      this.EventRotateEntity();
    if (clsInit.appEditor2.action == actionTypeBU.eventMirror && this.selEntities.Count > 0)
      this.method_12();
    if (clsInit.appEditor2.action == actionTypeBU.eventScale && this.selEntities.Count > 0)
      this.method_13();
    if (clsInit.appEditor2.action == actionTypeBU.eventOffset && this.selEntities.Count > 0)
      this.EventOffsetEntity();
    if (clsInit.appEditor2.action == actionTypeBU.eventBreak && (Drafting2D.entityMouseUnder == null ? 0 : (Drafting2D.entityMouseUnder.Item != null ? 1 : 0)) != 0)
      Class5.smethod_196(this);
    if (clsInit.appEditor2.action == actionTypeBU.eventTrim)
      this.method_7();
    if (clsInit.appEditor2.action == actionTypeBU.eventExtend && (Drafting2D.entityMouseUnder == null ? 0 : (Drafting2D.entityMouseUnder.Item != null ? 1 : 0)) != 0)
      Class5.smethod_63(this);
    if ((Drafting2D.entityMouseUnder == null ? 0 : (Drafting2D.entityMouseUnder.Item is ICurve ? 1 : 0)) != 0)
      this.method_8((ICurve) Drafting2D.entityMouseUnder.Item, Color.Red);
    base.DrawOverlay(data);
  }

  public void MouseDownDrawings(Entity ent, MouseEventArgs mea)
  {
  }

  public void MouseDownEvents(int[] indx, MouseEventArgs mea)
  {
  }

  private void method_0(
    System.Drawing.Point point_1,
    System.Drawing.Point point_2,
    Color color_0,
    int int_1,
    bool bool_0,
    bool bool_1)
  {
    point_1.Y = this.Height - point_1.Y;
    point_2.Y = this.Height - point_2.Y;
    Class5.smethod_158(ref point_2, ref point_1);
    int[] viewFrame = this.Viewports[0].GetViewFrame();
    int num1 = viewFrame[0];
    int num2 = viewFrame[1] + viewFrame[3];
    int num3 = num1 + viewFrame[2];
    int num4 = viewFrame[1];
    if (point_2.X > num3 - 1)
      point_2.X = num3 - 1;
    if (point_2.Y > num2 - 1)
      point_2.Y = num2 - 1;
    if (point_1.X < num1 + 1)
      point_1.X = num1 + 1;
    if (point_1.Y < num4 + 1)
      point_1.Y = num4 + 1;
    int num5 = (int) this.RenderContext.SetState(blendStateType.Blend);
    this.RenderContext.SetColorWireframe(Color.FromArgb(int_1, (int) color_0.R, (int) color_0.G, (int) color_0.B));
    int num6 = (int) this.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
    int num7 = point_2.X - point_1.X;
    int num8 = point_2.Y - point_1.Y;
    this.RenderContext.DrawQuad(new RectangleF((float) (point_1.X + 1), (float) (point_1.Y + 1), (float) (num7 - 1), (float) (num8 - 1)));
    int num9 = (int) this.RenderContext.SetState(blendStateType.NoBlend);
    if (!bool_0)
      return;
    this.RenderContext.SetColorWireframe(Color.FromArgb((int) byte.MaxValue, (int) color_0.R, (int) color_0.G, (int) color_0.B));
    if (bool_1)
    {
      this.RenderContext.SetLineStipple(1, (ushort) 3855, this.Viewports[0].Camera);
      this.RenderContext.EnableLineStipple(true);
    }
    int x1 = point_1.X;
    int x2 = point_2.X;
    if (this.RenderContext.IsDirect3D)
    {
      ++x1;
      ++x2;
    }
    this.RenderContext.DrawLines(new List<Point3D>((IEnumerable<Point3D>) new Point3D[8]
    {
      new Point3D((double) x1, (double) point_1.Y),
      new Point3D((double) point_2.X, (double) point_1.Y),
      new Point3D((double) x2, (double) point_1.Y),
      new Point3D((double) x2, (double) point_2.Y),
      new Point3D((double) x2, (double) point_2.Y),
      new Point3D((double) x1, (double) point_2.Y),
      new Point3D((double) x1, (double) point_2.Y),
      new Point3D((double) x1, (double) point_1.Y)
    }).ToArray());
    if (!bool_1)
      return;
    this.RenderContext.EnableLineStipple(false);
  }

  private void method_1()
  {
    if (Drafting2D.points.Count == 0)
      return;
    Point2D[] vertices = this.method_16((IList<Point3D>) clsInit.appEditor2.ClicksToPoints(Drafting2D.points));
    double num = (double) this.RenderContext.SetLineSize((float) clsVar.varEditorSet.DrawThickness + 1f);
    this.RenderContext.DrawLineStrip(vertices);
    if ((this.ActionMode != devDept.Eyeshot.actionType.None || this.ToolBar.Contains(this.point_0) ? 0 : (Drafting2D.points.Count > 0 ? 1 : 0)) == 0)
      return;
    this.RenderContext.DrawLine(vertices[vertices.Length - 1], (Point2D) this.WorldToScreen(this.current));
  }

  private void method_2(List<Point3D> list_0)
  {
    if (Drafting2D.points.Count == 0)
      return;
    Point2D[] vertices = this.method_16((IList<Point3D>) list_0);
    double num = (double) this.RenderContext.SetLineSize((float) clsVar.varEditorSet.DrawThickness + 1f);
    this.RenderContext.DrawLineStrip(vertices);
  }

  private void method_3()
  {
    Point2D[] vertices = this.method_16((IList<Point3D>) clsInit.appEditor2.ClicksToPoints(Drafting2D.points));
    double num = (double) this.RenderContext.SetLineSize((float) clsVar.varEditorSet.DrawThickness + 1f);
    this.RenderContext.DrawLineStrip(vertices);
    if ((this.ActionMode != devDept.Eyeshot.actionType.None || this.ToolBar.Contains(this.point_0) ? 0 : (Drafting2D.points.Count > 0 ? 1 : 0)) == 0)
      return;
    this.RenderContext.DrawLine(this.WorldToScreen(Drafting2D.points[0].Pnt3D), this.WorldToScreen(this.current));
    if (Drafting2D.points.Count != 2)
      return;
    this.radius = Drafting2D.points[0].Pnt3D.DistanceTo(Drafting2D.points[1].Pnt3D);
    if (this.radius <= 0.001)
      return;
    this.drawingPlane = Class5.smethod_209(this, Drafting2D.points[1].Pnt3D);
    Vector2D u = new Vector2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) Drafting2D.points[1].Pnt3D);
    u.Normalize();
    Vector2D v = new Vector2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) this.current);
    v.Normalize();
    this.arcSpanAngle = Vector2D.SignedAngleBetween(u, v);
    if (Math.Abs(this.arcSpanAngle) <= 0.001)
      return;
    Arc icurve_0 = new Arc(this.drawingPlane, this.drawingPlane.Origin, this.radius, 0.0, this.arcSpanAngle);
    Class5.smethod_183(clsVar.varEditorSet.colorDynamic, this, (ICurve) icurve_0);
  }

  private void method_4()
  {
    if ((clsInit.appEditor2.action != actionTypeBU.drawEllipseArc ? 0 : (Drafting2D.points.Count > 2 ? 1 : 0)) != 0)
      return;
    double num = (double) this.RenderContext.SetLineSize((float) clsVar.varEditorSet.DrawThickness + 1f);
    if (Drafting2D.points.Count == 1)
      this.RenderContext.DrawLine(this.WorldToScreen(Drafting2D.points[0].Pnt3D), this.WorldToScreen(this.current));
    if (Drafting2D.points.Count < 2)
      return;
    this.midPoint = Point3D.MidPoint(Drafting2D.points[0].Pnt3D, Drafting2D.points[1].Pnt3D);
    this.radius = this.midPoint.DistanceTo(Drafting2D.points[1].Pnt3D);
    this.radiusY = this.current.DistanceTo(new Segment2D((Point2D) Drafting2D.points[0].Pnt3D, (Point2D) Drafting2D.points[1].Pnt3D));
    if ((this.radius <= 0.001 ? 0 : (this.radiusY > 0.001 ? 1 : 0)) == 0)
      return;
    Point3D midPoint = this.midPoint;
    this.drawingPlane = Class5.smethod_11(Drafting2D.points[1].Pnt3D, midPoint, this);
    this.method_10(this.midPoint);
    Ellipse icurve_0 = new Ellipse(this.drawingPlane, this.drawingPlane.Origin, this.radius, this.radiusY);
    Class5.smethod_183(clsVar.varEditorSet.colorDynamic, this, (ICurve) icurve_0);
  }

  private void method_5()
  {
    if (Drafting2D.points.Count == 0)
      return;
    double num = (double) this.RenderContext.SetLineSize((float) clsVar.varEditorSet.DrawThickness + 1f);
    if (Drafting2D.points.Count == 1)
      this.RenderContext.DrawLine(this.WorldToScreen(Drafting2D.points[0].Pnt3D), this.WorldToScreen(this.current));
    List<Pnt3D> Vertices = new List<Pnt3D>();
    clsInit.cVector.PolygonCenter(new Pnt3D(Drafting2D.points[0].Pnt3D.X, Drafting2D.points[0].Pnt3D.Y), new Pnt3D(this.current.X, this.current.Y), clsVar.varEditorRuntimeSet.PolygonSide, new WorkPlane(planeType.XY, 1), ref Vertices);
    List<Point3D> CopiedPnt = new List<Point3D>();
    buConversion5.Pnt3DToPoint3D(Vertices, ref CopiedPnt);
    if (CopiedPnt.Count < 2)
      return;
    this.drawingPlane = Plane.XY;
    this.method_10(Drafting2D.points[0].Pnt3D);
    this.method_2(CopiedPnt);
  }

  private void method_6()
  {
    if (Drafting2D.points.Count <= 1)
      return;
    double num = (double) this.RenderContext.SetLineSize((float) clsVar.varEditorSet.DrawThickness + 1f);
    this.RenderContext.DrawLine(this.WorldToScreen(Drafting2D.points[0].Pnt3D), this.WorldToScreen(Drafting2D.points[1].Pnt3D));
    List<Point3D> point3DList = new List<Point3D>();
    Entity icurve_0 = clsInit.cVector5.Slot3Point(Drafting2D.points[0].Pnt3D, Drafting2D.points[1].Pnt3D, this.current, Plane.XY);
    Class5.smethod_183(clsVar.varEditorSet.colorDynamic, this, (ICurve) icurve_0);
  }

  private void method_7()
  {
    this.RenderContext.EnableXOR(false);
    if (Drafting2D.leftOvers.Count > 0)
    {
      ICurve entToTrim = Drafting2D.entToTrim as ICurve;
      Class5.smethod_183(clsVar.varEditorSet.colorFirstPart, this, entToTrim);
      foreach (Entity leftOver in Drafting2D.leftOvers)
        Class5.smethod_183(clsVar.varEditorSet.colorSecondPart, this, leftOver as ICurve);
    }
    else if (Drafting2D.entToTrim != null)
    {
      ICurve entToTrim = Drafting2D.entToTrim as ICurve;
      Class5.smethod_183(clsVar.varEditorSet.colorSecondPart, this, entToTrim);
    }
    this.RenderContext.EnableXOR(true);
  }

  internal void method_8(ICurve icurve_0, Color color_0)
  {
    Point3D[] vertices = new Point3D[101];
    for (int index = 0; index <= 100; ++index)
      vertices[index] = this.WorldToScreen(icurve_0.PointAt(icurve_0.Domain.ParameterAt((double) index / 100.0)));
    double num = (double) this.RenderContext.SetLineSize((float) clsVar.varEditorSet.DrawThickness + 1f);
    this.RenderContext.SetColorWireframe(color_0);
    this.RenderContext.DrawLineStrip(vertices);
  }

  private void method_9()
  {
    List<Point3D> point3DList = new List<Point3D>((IEnumerable<Point3D>) clsInit.appEditor2.ClicksToPoints(Drafting2D.points));
    point3DList.Add(this.method_17(this.point_0, this.plane, (IList<Point3D>) clsInit.appEditor2.ClicksToPoints(Drafting2D.points), 0));
    double num = (double) this.RenderContext.SetLineSize((float) clsVar.varEditorSet.DrawThickness + 1f);
    if (Drafting2D.points.Count > 1)
    {
      Curve icurve_0 = Curve.CubicSplineInterpolation<Point3D>((IList<Point3D>) point3DList);
      Class5.smethod_183(clsVar.varEditorSet.colorDynamic, this, (ICurve) icurve_0);
    }
    else
      this.RenderContext.DrawLineStrip(this.method_16((IList<Point3D>) point3DList));
  }

  internal void method_10(Point3D point3D_3, double double_0 = 20.0)
  {
    if ((clsInit.appEditor2.action == actionTypeBU.drawDimAlinged || clsInit.appEditor2.action == actionTypeBU.drawDimAngular || clsInit.appEditor2.action == actionTypeBU.drawDimLeader || clsInit.appEditor2.action == actionTypeBU.drawDimDiameter || clsInit.appEditor2.action == actionTypeBU.drawDimLinear || clsInit.appEditor2.action == actionTypeBU.drawDimHorizontalOrdinate || clsInit.appEditor2.action == actionTypeBU.drawDimVerticalOrdinate ? 1 : (clsInit.appEditor2.action == actionTypeBU.drawDimRadial ? 1 : 0)) != 0)
      return;
    if (this.IsPolygonClosed())
      point3D_3 = Drafting2D.points[0].Pnt3D;
    double num1 = (double) this.RenderContext.SetLineSize((float) clsVar.varEditorSet.DrawThickness + 1f);
    Point3D screen = this.WorldToScreen(point3D_3);
    Vector2D vector2D1 = Vector2D.Subtract((Point2D) this.WorldToScreen(point3D_3.X - 1.0, point3D_3.Y, 0.0), (Point2D) screen);
    vector2D1.Normalize();
    this.RenderContext.DrawLine((Point2D) screen + vector2D1 * double_0, (Point2D) screen - vector2D1 * double_0);
    Vector2D vector2D2 = Vector2D.Subtract((Point2D) this.WorldToScreen(point3D_3.X, point3D_3.Y - 1.0, 0.0), (Point2D) screen);
    vector2D2.Normalize();
    this.RenderContext.DrawLine((Point2D) screen + vector2D2 * double_0, (Point2D) screen - vector2D2 * double_0);
    double num2 = (double) this.RenderContext.SetLineSize(1f);
  }

  private void HandleLibraryAction(Entity entity)
  {
    actionTypeBU action = clsInit.appEditor2.action;
    bool libraryAction = action == actionTypeBU.libraryVertical || action == actionTypeBU.libraryHorizontal ||
                         action == actionTypeBU.libraryLength || action == actionTypeBU.libraryRadius ||
                         action == actionTypeBU.libraryFixPoint || action == actionTypeBU.libraryAngle ||
                         action == actionTypeBU.libraryFillet || action == actionTypeBU.libraryChamfer ||
                         action == actionTypeBU.libraryEqualLength || action == actionTypeBU.libraryEqualRadius ||
                         action == actionTypeBU.libraryLineLine || action == actionTypeBU.libraryLinePoint ||
                         action == actionTypeBU.libraryPointPoint || action == actionTypeBU.libraryCollinear ||
                         action == actionTypeBU.libraryParalel || action == actionTypeBU.libraryPerpendiculat ||
                         action == actionTypeBU.libraryTangent || action == actionTypeBU.libraryDeleteEntity;
    if (!libraryAction)
      return;
    Drafting2D.points.Clear();
    if (this.CurrentSketch == null)
    {
      clsInit.appEditor2.StatusUpdate("A sketch must be active", "Constraint");
      this.ClearAllPreviousCommandData();
      return;
    }
    Point2D dimensionPoint = new Point2D(this.current.X, this.current.Y);
    if (action == actionTypeBU.libraryVertical && entity is Line)
      clsInit.appEditor2.CreateConstraintVertical((Line) entity);
    else if (action == actionTypeBU.libraryHorizontal && entity is Line)
      clsInit.appEditor2.CreateConstraintHorizontal((Line) entity);
    else if (action == actionTypeBU.libraryLength && entity is Line)
      clsInit.appEditor2.CreateConstraintLength((Line) entity, dimensionPoint);
    else if (action == actionTypeBU.libraryRadius && entity is Circle)
      clsInit.appEditor2.CreateConstraintDiameter((Circle) entity);
    else if (action == actionTypeBU.libraryFixPoint && entity != null)
      clsInit.appEditor2.CreateConstraintFixPoint(entity, this.current);
    else if (action == actionTypeBU.libraryDeleteEntity && entity != null)
      clsInit.appEditor2.cmdDeleteEntity(entity);
    else if (action == actionTypeBU.libraryAngle)
    {
      if (entity is Arc)
        clsInit.appEditor2.CreateConstraintAngle((Arc) entity, dimensionPoint);
      else if (entity is Line)
      {
        this.AddLibrarySelection(entity);
        if (Drafting2D.entitiesSelected.Count == 2)
        {
          clsInit.appEditor2.CreateConstraintAngle((Line) Drafting2D.entitiesSelected[0], (Line) Drafting2D.entitiesSelected[1], dimensionPoint);
          this.CompleteLibraryPairSelection(action);
        }
      }
    }
    else if (action == actionTypeBU.libraryFillet || action == actionTypeBU.libraryChamfer)
    {
      if (entity is ICurve)
      {
        this.AddLibrarySelection(entity);
        if (Drafting2D.entitiesSelected.Count == 2)
        {
          clsInit.appEditor2.FilletChamferCalculation(action == actionTypeBU.libraryFillet);
          this.CompleteLibraryPairSelection(action);
        }
      }
    }
    else if (action == actionTypeBU.libraryEqualLength && entity is ICurve)
    {
      this.AddLibrarySelection(entity);
      if (Drafting2D.entitiesSelected.Count == 2)
      {
        clsInit.appEditor2.CreateConstraintEqualLength(Drafting2D.entitiesSelected[0], Drafting2D.entitiesSelected[1], false);
        this.CompleteLibraryPairSelection(action);
      }
    }
    else if (action == actionTypeBU.libraryEqualRadius && (entity is Circle || entity is Arc))
    {
      this.AddLibrarySelection(entity);
      if (Drafting2D.entitiesSelected.Count == 2)
      {
        clsInit.appEditor2.CreateConstraintEqualLength(Drafting2D.entitiesSelected[0], Drafting2D.entitiesSelected[1], true);
        this.CompleteLibraryPairSelection(action);
      }
    }
    else if ((action == actionTypeBU.libraryCollinear || action == actionTypeBU.libraryParalel || action == actionTypeBU.libraryPerpendiculat) && entity is Line)
    {
      this.AddLibrarySelection(entity);
      if (Drafting2D.entitiesSelected.Count == 2)
      {
        Line first = (Line) Drafting2D.entitiesSelected[0];
        Line second = (Line) Drafting2D.entitiesSelected[1];
        if (action == actionTypeBU.libraryCollinear)
          clsInit.appEditor2.CreateConstraintCollinear(first, second);
        else if (action == actionTypeBU.libraryParalel)
          clsInit.appEditor2.CreateConstraintParallel(first, second);
        else
          clsInit.appEditor2.CreateConstraintPerpendicular(first, second);
        this.CompleteLibraryPairSelection(action);
      }
    }
    else if (action == actionTypeBU.libraryTangent && entity is ICurve)
    {
      this.AddLibrarySelection(entity);
      if (Drafting2D.entitiesSelected.Count == 2)
      {
        clsInit.appEditor2.CreateConstraintTangent(Drafting2D.entitiesSelected[0], Drafting2D.entitiesSelected[1]);
        this.CompleteLibraryPairSelection(action);
      }
    }
    else if (action == actionTypeBU.libraryLineLine && entity is Line)
    {
      this.AddLibrarySelection(entity);
      if (Drafting2D.entitiesSelected.Count == 2)
      {
        clsInit.appEditor2.CreateConstraintLineLineDistance((Line) Drafting2D.entitiesSelected[0], (Line) Drafting2D.entitiesSelected[1], dimensionPoint);
        this.CompleteLibraryPairSelection(action);
      }
    }
    else if (action == actionTypeBU.libraryLinePoint && (entity is Line || entity is devDept.Eyeshot.Entities.Point))
    {
      this.AddLibrarySelection(entity);
      if (Drafting2D.entitiesSelected.Count == 2)
      {
        Line line = Drafting2D.entitiesSelected[0] as Line ?? Drafting2D.entitiesSelected[1] as Line;
        devDept.Eyeshot.Entities.Point point = Drafting2D.entitiesSelected[0] as devDept.Eyeshot.Entities.Point ?? Drafting2D.entitiesSelected[1] as devDept.Eyeshot.Entities.Point;
        if (line != null && point != null)
        {
          clsInit.appEditor2.CreateConstraintLinePointDistance(point, line, dimensionPoint);
          this.CompleteLibraryPairSelection(action);
        }
      }
    }
    else if (action == actionTypeBU.libraryPointPoint)
    {
      bool joinMode = clsItem.frmEditorV2.LibraryPointJoinMode;
      bool joinEndpointsMode = clsItem.frmEditorV2.LibraryJoinEndpointsMode;
      if (joinEndpointsMode && (entity is ICurve || entity is devDept.Eyeshot.Entities.Point))
        this.AddLibrarySelection(entity);
      else if ((!joinMode && entity is devDept.Eyeshot.Entities.Point) || (joinMode && entity != null))
        this.AddLibrarySelection(entity);
      if (Drafting2D.entitiesSelected.Count == 2)
      {
        if (joinEndpointsMode)
        {
          clsInit.appEditor2.CreateConstraintJoinEntities(Drafting2D.entitiesSelected[0], Drafting2D.entitiesSelected[1]);
          this.CompleteLibraryPairSelection(action);
        }
        else if (joinMode)
        {
          devDept.Eyeshot.Entities.Point point = Drafting2D.entitiesSelected[0] as devDept.Eyeshot.Entities.Point ?? Drafting2D.entitiesSelected[1] as devDept.Eyeshot.Entities.Point;
          Entity target = Drafting2D.entitiesSelected[0] == point ? Drafting2D.entitiesSelected[1] : Drafting2D.entitiesSelected[0];
          if (point != null && target != null)
          {
            clsInit.appEditor2.CreateConstraintPointOn(point, target);
            this.CompleteLibraryPairSelection(action);
          }
        }
        else
        {
          clsInit.appEditor2.CreateConstraintPointPointAlignedDistance((devDept.Eyeshot.Entities.Point) Drafting2D.entitiesSelected[0], (devDept.Eyeshot.Entities.Point) Drafting2D.entitiesSelected[1], dimensionPoint);
          this.CompleteLibraryPairSelection(action);
        }
      }
    }
  }

  private void AddLibrarySelection(Entity entity)
  {
    if (entity == null || Drafting2D.entitiesSelected.Contains(entity))
      return;
    entity.Selected = true;
    Drafting2D.entitiesSelected.Add(entity);
  }

  private void CompleteLibraryPairSelection(actionTypeBU action)
  {
    for (int index = 0; index < Drafting2D.entitiesSelected.Count; ++index)
      Drafting2D.entitiesSelected[index].Selected = false;
    Drafting2D.entitiesSelected.Clear();
    clsInit.appEditor2.action = action;
    Drafting2D.selectionProcess = false;
    clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, "Constraint");
    this.Invalidate();
  }

  public void EventCopyToSelected()
  {
    Drafting2D.selectionProcess = false;
    clsItem.frmEditorV2.viewport.selEntities.Clear();
    for (int index = clsItem.frmEditorV2.viewport.Entities.Count - 1; index > -1; --index)
    {
      Entity entity = clsItem.frmEditorV2.viewport.Entities[index];
      int num;
      if (entity.Selected)
      {
        switch (entity)
        {
          case ICurve _:
          case BlockReference _:
          case devDept.Eyeshot.Entities.Text _:
            num = 1;
            break;
          default:
            num = entity is Leader ? 1 : 0;
            break;
        }
      }
      else
        num = 0;
      if (num != 0)
        clsItem.frmEditorV2.viewport.selEntities.Add(entity);
    }
    foreach (Entity selEntity in clsItem.frmEditorV2.viewport.selEntities)
      selEntity.Selected = true;
  }

  public void EventMove()
  {
    try
    {
      if (Drafting2D.points.Count != 2 || this.selEntities.Count <= 0)
        return;
      clsInit.appEditor2.UndoBuffer();
      foreach (Entity selEntity in this.selEntities)
        selEntity.Translate(new Vector3D(Drafting2D.points[0].Pnt3D, Drafting2D.points[1].Pnt3D));
      this.Entities.Regen();
      this.ClearAllPreviousCommandData();
    }
    catch (Exception ex)
    {
      this.ReportDraftingError(ex, nameof (EventMove));
    }
  }

  public void EventCopy()
  {
    try
    {
      if (Drafting2D.points.Count != 2 || this.selEntities.Count <= 0)
        return;
      clsInit.appEditor2.UndoBuffer();
      foreach (Entity selEntity in this.selEntities)
      {
        Vector3D v = new Vector3D(Drafting2D.points[0].Pnt3D, Drafting2D.points[1].Pnt3D);
        Entity entity_0 = (Entity) selEntity.Clone();
        entity_0.Translate(v);
        this.method_18(entity_0, this.ActiveLayerName, false, false);
      }
      this.Entities.Regen();
      this.ClearAllPreviousCommandData();
    }
    catch (Exception ex)
    {
      this.ReportDraftingError(ex, nameof (EventCopy));
    }
  }

  public void EventLinearArray()
  {
    try
    {
      if (Drafting2D.points.Count != 2 || this.selEntities.Count == 0)
        return;
      int columns = Math.Max(1, Math.Min(100, clsVar.varInterface.ArrayLineerVar.ColomnsCountX));
      int rows = Math.Max(1, Math.Min(100, clsVar.varInterface.ArrayLineerVar.RowsCountY));
      int levels = Math.Max(1, Math.Min(10, clsVar.varInterface.ArrayLineerVar.LevelCountZ));
      if ((long) columns * rows * levels > 10000L)
        throw new InvalidOperationException("Array entity count is greater than the safe editor limit.");
      Vector3D mouseStep = new Vector3D(Drafting2D.points[0].Pnt3D, Drafting2D.points[1].Pnt3D);
      clsInit.appEditor2.UndoBuffer();
      List<Entity> sources = new List<Entity>(this.selEntities);
      for (int level = 0; level < levels; ++level)
      {
        for (int row = 0; row < rows; ++row)
        {
          for (int column = 0; column < columns; ++column)
          {
            if (level == 0 && row == 0 && column == 0)
              continue;
            Vector3D move = new Vector3D();
            if (clsVar.varInterface.ArrayLineerVar.MoveByMouse)
            {
              move.X = mouseStep.X * column;
              move.Y = mouseStep.Y * row;
              move.Z = mouseStep.Z * level;
            }
            else
            {
              move.X = clsVar.varInterface.ArrayLineerVar.ColomnsDistanceX * column;
              move.Y = clsVar.varInterface.ArrayLineerVar.RowDistanceY * row;
              move.Z = clsVar.varInterface.ArrayLineerVar.LevelDistanceZ * level;
            }
            for (int sourceIndex = 0; sourceIndex < sources.Count; ++sourceIndex)
            {
              Entity copy = sources[sourceIndex].Clone() as Entity;
              if (copy == null)
                continue;
              copy.Translate(move);
              copy.Selected = false;
              this.Entities.Add(copy);
            }
          }
        }
      }
      this.Entities.Regen();
      this.Entities.UpdateBoundingBox();
      this.ClearAllPreviousCommandData();
      this.Invalidate();
      clsInit.appEditor2.JobUpdate();
    }
    catch (Exception ex)
    {
      clsInit.appEditor2.StatusUpdate(ex.Message, "Array");
      buLog.addLog("", "Not Ok: " + ex.Message, nameof (EventLinearArray));
      this.ClearAllPreviousCommandData();
    }
  }

  public void EventExplode()
  {
    try
    {
      if (this.selEntities.Count == 0)
        this.EventCopyToSelected();
      if (this.selEntities.Count == 0)
        return;
      clsVar.varEditorRuntimeSet.ExplodeArcToPolyline = clsItem.frmEditorV2.chk_explodearctopolyline.Check;
      clsVar.varEditorRuntimeSet.ExplodeCircleToArc = clsItem.frmEditorV2.chk_explodecircletoarc.Check;
      clsVar.varEditorRuntimeSet.ExplodeCircleToPolyline = clsItem.frmEditorV2.chk_explodecircletopolyline.Check;
      clsVar.varEditorRuntimeSet.ExplodeCompositeCurveToEntities = clsItem.frmEditorV2.chk_explodeCompositetoEntity.Check;
      clsVar.varEditorRuntimeSet.ExplodeCurveToPolyline = clsItem.frmEditorV2.chk_explodecurvetopolyline.Check;
      clsVar.varEditorRuntimeSet.ExplodeEllipseToPolyline = clsItem.frmEditorV2.chk_explodeellipsetopolyline.Check;
      clsVar.varEditorRuntimeSet.ExplodePolylineToLine = clsItem.frmEditorV2.chk_explodepolylinetoLine.Check;
      clsInit.appEditor2.UndoBuffer();
      List<Entity> sources = new List<Entity>(this.selEntities);
      for (int sourceIndex = 0; sourceIndex < sources.Count; ++sourceIndex)
      {
        Entity source = sources[sourceIndex];
        List<Entity> parts = this.ExplodeEditorEntity(source);
        this.ClearEntityGroup(source);
        if (parts.Count == 0)
        {
          source.Selected = false;
          continue;
        }
        for (int partIndex = 0; partIndex < parts.Count; ++partIndex)
          this.AddExplodedEditorEntity(source, parts[partIndex]);
        this.Entities.Remove(source);
      }
      this.Entities.Regen();
      this.Entities.UpdateBoundingBox();
      this.ClearAllPreviousCommandData();
      this.Invalidate();
      clsInit.appEditor2.JobUpdate();
    }
    catch (Exception ex)
    {
      clsInit.appEditor2.StatusUpdate(ex.Message, "Explode");
      buLog.addLog("", "Not Ok: " + ex.Message, nameof (EventExplode));
    }
  }

  private List<Entity> ExplodeEditorEntity(Entity source)
  {
    List<Entity> parts = new List<Entity>();
    if (source is Circle && !(source is Arc))
    {
      Circle circle = (Circle) source;
      if (clsVar.varEditorRuntimeSet.ExplodeCircleToPolyline)
        parts.Add(this.CreatePolylineFromEntity(source));
      else if (clsVar.varEditorRuntimeSet.ExplodeCircleToArc)
      {
        for (int quadrant = 0; quadrant < 4; ++quadrant)
          parts.Add((Entity) new Arc(circle.Plane, circle.Center, circle.Radius, quadrant * Math.PI / 2.0, (quadrant + 1) * Math.PI / 2.0));
      }
    }
    else if (source is Arc && clsVar.varEditorRuntimeSet.ExplodeArcToPolyline)
      parts.Add(this.CreatePolylineFromEntity(source));
    else if ((source is Ellipse || source is EllipticalArc) && clsVar.varEditorRuntimeSet.ExplodeEllipseToPolyline)
      parts.Add(this.CreatePolylineFromEntity(source));
    else if (source is Curve && clsVar.varEditorRuntimeSet.ExplodeCurveToPolyline)
      parts.Add(this.CreatePolylineFromEntity(source));
    else if (source is LinearPath && clsVar.varEditorRuntimeSet.ExplodePolylineToLine)
    {
      Point3D[] vertices = source.Vertices;
      for (int index = 1; index < vertices.Length; ++index)
        parts.Add((Entity) new Line(vertices[index - 1], vertices[index]));
    }
    else if (source is CompositeCurve && clsVar.varEditorRuntimeSet.ExplodeCompositeCurveToEntities)
      parts.AddRange(((CompositeCurve) source).Explode());
    else if (source is BlockReference && clsVar.varEditorRuntimeSet.ExplodeCompositeCurveToEntities)
      parts.AddRange(((BlockReference) source).Explode(this.Blocks));
    parts.RemoveAll((Entity entity) => entity == null);
    return parts;
  }

  private LinearPath CreatePolylineFromEntity(Entity source)
  {
    source.Regen(0.01);
    List<Point3D> vertices = new List<Point3D>((IEnumerable<Point3D>) source.Vertices);
    return vertices.Count < 2 ? null : new LinearPath((ICollection<Point3D>) vertices);
  }

  private void AddExplodedEditorEntity(Entity source, Entity part)
  {
    if (part == null)
      return;
    part.LayerName = source.LayerName;
    part.ColorMethod = source.ColorMethod;
    part.Color = source.Color;
    part.LineWeightMethod = source.LineWeightMethod;
    part.LineWeight = source.LineWeight;
    part.GroupIndex = -1;
    if (source.EntityData is CustomData)
    {
      CustomData data = new CustomData((CustomData) source.EntityData);
      data.GroupIdIndex = -1;
      part.EntityData = (object) data;
    }
    part.Selected = false;
    this.Entities.Add(part);
  }

  private void ClearEntityGroup(Entity entity)
  {
    if (entity == null)
      return;
    entity.GroupIndex = -1;
    if (entity.EntityData is CustomData)
      ((CustomData) entity.EntityData).GroupIdIndex = -1;
  }

  public void EventRotate()
  {
    if (Drafting2D.points.Count != 3 || this.selEntities.Count <= 0)
      return;
    clsInit.appEditor2.UndoBuffer();
    foreach (Entity selEntity in this.selEntities)
    {
      selEntity.Rotate(this.arcSpanAngle, Vector3D.AxisZ, Drafting2D.points[0].Pnt3D);
      if (selEntity is devDept.Eyeshot.Entities.Text)
        selEntity.Regen(new RegenParams(0.0, (IWorkspace) this));
    }
    this.Entities.Regen();
    this.ClearAllPreviousCommandData();
  }

  public void EventMirror()
  {
    if (Drafting2D.points.Count != 2 || this.selEntities.Count <= 0)
      return;
    clsInit.appEditor2.UndoBuffer();
    if ((Drafting2D.points[1].Pnt3D.X < Drafting2D.points[0].Pnt3D.X ? 1 : (Drafting2D.points[1].Pnt3D.Y < Drafting2D.points[0].Pnt3D.Y ? 1 : 0)) != 0)
    {
      Point3D pnt3D1 = Drafting2D.points[0].Pnt3D;
      Point3D pnt3D2 = Drafting2D.points[1].Pnt3D;
      Utility.Swap<Point3D>(ref pnt3D1, ref pnt3D2);
      Drafting2D.points[0].Pnt3D = pnt3D1;
      Drafting2D.points[1].Pnt3D = pnt3D2;
    }
    Vector3D X = new Vector3D(Drafting2D.points[0].Pnt3D, Drafting2D.points[1].Pnt3D);
    Plane pln = new Plane(Drafting2D.points[0].Pnt3D, X, Vector3D.AxisZ);
    foreach (Entity selEntity in this.selEntities)
    {
      Entity entity_0 = (Entity) selEntity.Clone();
      Transformation reflection = Transformation.CreateReflection(pln);
      entity_0.TransformBy(reflection);
      this.method_18(entity_0, this.ActiveLayerName, false, false);
    }
    this.Entities.Regen();
    this.ClearAllPreviousCommandData();
  }

  public void EventScale(bool Override = false, double ScaleRatio = 1.0)
  {
    try
    {
      if (Override)
      {
        if (ScaleRatio > 0.0)
        {
          clsInit.appEditor2.UndoBuffer();
          foreach (Entity selEntity in this.selEntities)
          {
            if (Drafting2D.points.Count > 0)
              selEntity.Scale(Drafting2D.points[0].Pnt3D, ScaleRatio);
            else
              selEntity.Scale(Drafting2D.boxMid, ScaleRatio);
          }
          this.Entities.Regen();
        }
        this.ClearAllPreviousCommandData();
      }
      else
      {
        if (Drafting2D.points.Count != 3 || this.selEntities.Count <= 0)
          return;
        double referenceDistance = Drafting2D.points[0].Pnt3D.DistanceTo(Drafting2D.points[1].Pnt3D);
        if (referenceDistance <= 1E-09)
        {
          this.ClearAllPreviousCommandData();
          return;
        }
        double factor = Drafting2D.points[0].Pnt3D.DistanceTo(Drafting2D.points[2].Pnt3D) / referenceDistance;
        if (factor > 0.0)
        {
          clsInit.appEditor2.UndoBuffer();
          foreach (Entity selEntity in this.selEntities)
            selEntity.Scale(Drafting2D.points[0].Pnt3D, factor);
          this.Entities.Regen();
        }
        this.ClearAllPreviousCommandData();
      }
    }
    catch (Exception ex)
    {
      this.ReportDraftingError(ex, nameof (EventScale));
    }
  }

  public void EventOffset()
  {
    if (Drafting2D.points.Count != 1 || this.selEntities.Count <= 0)
      return;
    clsVar.varEditorSet.OffsetByMouse = clsItem.frmEditorV2.chk_offsetbymouse.Check;
    clsVar.varEditorRuntimeSet.OffsetValue = clsItem.frmEditorV2.spn_offset.Value;
    clsInit.appEditor2.UndoBuffer();
    foreach (Entity selEntity in this.selEntities)
    {
      ICurve curve = selEntity as ICurve;
      if (curve == null)
        continue;
      if (clsVar.varEditorSet.OffsetByMouse)
      {
        double t;
        if (!curve.Project(Drafting2D.points[0].Pnt3D, out t))
          continue;
        double amount = curve.PointAt(t).DistanceTo(Drafting2D.points[0].Pnt3D);
        ICurve[] positiveOffsets = curve.Offset(amount, Vector3D.AxisZ, true);
        if (positiveOffsets == null || positiveOffsets.Length == 0 || positiveOffsets[0] == null)
          continue;
        ICurve offsetCurve = positiveOffsets[0];
        if (!offsetCurve.Project(Drafting2D.points[0].Pnt3D, out t))
          continue;
        if (offsetCurve.PointAt(t).DistanceTo(Drafting2D.points[0].Pnt3D) > 0.001)
        {
          ICurve[] negativeOffsets = curve.Offset(-amount, Vector3D.AxisZ, true);
          if (negativeOffsets == null || negativeOffsets.Length == 0 || negativeOffsets[0] == null)
            continue;
          offsetCurve = negativeOffsets[0];
        }
        this.method_18((Entity) offsetCurve, this.ActiveLayerName, false, false);
      }
      else
      {
        double offsetValue = clsVar.varEditorRuntimeSet.OffsetValue;
        ICurve[] positiveOffsets = curve.Offset(offsetValue, Vector3D.AxisZ, true);
        ICurve[] negativeOffsets = curve.Offset(-offsetValue, Vector3D.AxisZ, true);
        ICurve positive = positiveOffsets != null && positiveOffsets.Length > 0 ? positiveOffsets[0] : null;
        ICurve negative = negativeOffsets != null && negativeOffsets.Length > 0 ? negativeOffsets[0] : null;
        if (positive == null && negative == null)
          continue;
        double positiveDistance = double.MaxValue;
        double negativeDistance = double.MaxValue;
        double t;
        if (positive != null && positive.Project(this.current, out t))
          positiveDistance = positive.PointAt(t).DistanceTo(this.current);
        if (negative != null && negative.Project(this.current, out t))
          negativeDistance = negative.PointAt(t).DistanceTo(this.current);
        ICurve offsetCurve = positiveDistance <= negativeDistance ? positive : negative;
        if (offsetCurve != null)
          this.method_18((Entity) offsetCurve, this.ActiveLayerName, false, false);
      }
    }
    this.Entities.Regen();
    this.ClearAllPreviousCommandData();
  }

  public void EventDelete()
  {
    try
    {
      clsInit.appEditor2.UndoBuffer();
      this.Entities.DeleteSelected();
      this.Invalidate();
      clsInit.appEditor2.Reset();
      this.ClearAllPreviousCommandData();
    }
    catch (Exception ex)
    {
      this.ReportDraftingError(ex, nameof (EventDelete));
    }
  }

  public void EventBreak()
  {
    try
    {
      if ((!(Drafting2D.points.Count == 1 & this.int_0 != null) ? 0 : (this.int_0.Length != 0 ? 1 : 0)) == 0 || (Drafting2D.entityMouseUnder == null ? 0 : (Drafting2D.entityMouseUnder.Item != null ? 1 : 0)) == 0)
        return;
      clsInit.appEditor2.UndoBuffer();
      Entity entityFirst = (Entity) null;
      Entity entitySecond = (Entity) null;
      this.Break((Entity) Drafting2D.entityMouseUnder.Item, this.current, ref entityFirst, ref entitySecond);
      if (!(entityFirst != null & entitySecond != null))
        return;
      if (this.int_0[0] >= 0 & this.int_0[0] <= this.Entities.Count - 1)
        this.Entities.RemoveAt(this.int_0[0]);
      this.method_18(entityFirst, this.ActiveLayerName, true, true);
      this.method_18(entitySecond, this.ActiveLayerName, true, true);
    }
    catch (Exception ex)
    {
      this.ReportDraftingError(ex, nameof (EventBreak));
    }
  }

  public void EventTrim()
  {
    try
    {
      if ((!(Drafting2D.points.Count == 1 & this.int_0 != null) ? 0 : (this.int_0.Length != 0 ? 1 : 0)) == 0)
        return;
      int index = this.int_0[0];
      if (index == -1)
        return;
      Entity entity = this.Entities[index];
      if (entity == null)
        return;
      clsInit.appEditor2.UndoBuffer();
      List<Entity> leftOverEntities;
      if (Utility.Trim((IDesign) this, Drafting2D.mouseDownLocation, out leftOverEntities))
        this.Entities.AddRange((IEnumerable<Entity>) leftOverEntities);
      else
        this.Entities.Remove(entity);
      this.Entities.RegenAllCurved();
      Drafting2D.points.Clear();
      this.timer_0.Interval = 100;
      this.timer_0.Enabled = true;
    }
    catch (Exception ex)
    {
      this.ReportDraftingError(ex, nameof (EventTrim));
    }
  }

  public void Break(
    Entity selEntity,
    Point3D refPoint,
    ref Entity entityFirst,
    ref Entity entitySecond)
  {
    ICurve curve = selEntity as ICurve;
    ICurve lower = (ICurve) null;
    ICurve upper = (ICurve) null;
    double t;
    if (curve.Project(refPoint, out t))
      curve.SplitAt(t, out lower, out upper);
    if (!(lower != null & upper != null))
      return;
    entityFirst = (Entity) lower;
    entitySecond = (Entity) upper;
  }

  public void EventExtend()
  {
    try
    {
      if ((!(Drafting2D.points.Count == 1 & this.int_0 != null) ? 0 : (this.int_0.Length != 0 ? 1 : 0)) == 0)
        return;
      if ((Drafting2D.entityMouseUnder == null ? 0 : (Drafting2D.entityMouseUnder.Item != null ? 1 : 0)) != 0)
      {
        Entity entityExtended = (Entity) null;
        clsVar.varEditorRuntimeSet.ExtendLength = clsItem.frmEditorV2.spn_extndlen.Value;
        clsInit.appCommand.Extend(clsItem.frmEditorV2.viewport.Entities, this.int_0[0], this.current, clsVar.varEditorRuntimeSet.ExtendLength, ref entityExtended);
        if (entityExtended != null)
        {
          clsInit.appEditor2.UndoBuffer();
          if (this.int_0[0] >= 0 & this.int_0[0] <= this.Entities.Count - 1)
            this.Entities.RemoveAt(this.int_0[0]);
          this.method_18(entityExtended, this.ActiveLayerName, true, true);
        }
      }
      this.ClearAllPreviousCommandData();
    }
    catch (Exception ex)
    {
      this.ReportDraftingError(ex, nameof (EventExtend));
    }
  }

  private void ReportDraftingError(Exception ex, string command)
  {
    string message = ex == null ? "Unknown editor error" : ex.Message;
    if (clsInit.appEditor2 != null)
      clsInit.appEditor2.StatusUpdate(message, command);
    buLog.addLog("", "Not Ok: " + message, command);
  }

  public void EventFillet()
  {
    if (this.firstSelectedEntity == null)
    {
      if (this.selEntityIndex != -1)
      {
        this.firstSelectedEntity = this.Entities[this.selEntityIndex];
        this.selEntityIndex = -1;
        this.ScreenToPlane(this.point_0, Plane.XY, out this.point3D_1);
        return;
      }
    }
    else if (this.secondSelectedEntity == null)
      ;
    if (this.secondSelectedEntity == null && this.selEntityIndex != -1)
      this.secondSelectedEntity = this.Entities[this.selEntityIndex];
    if ((!(this.firstSelectedEntity is ICurve) ? 0 : (this.secondSelectedEntity is ICurve ? 1 : 0)) == 0)
      return;
    if ((!(this.firstSelectedEntity is Line) ? 0 : (this.secondSelectedEntity is Line ? 1 : 0)) != 0 && Vector3D.AreParallel((this.firstSelectedEntity as Line).StartTangent, (this.secondSelectedEntity as Line).StartTangent))
    {
      this.ClearAllPreviousCommandData();
    }
    else
    {
      try
      {
        if (this.firstSelectedEntity.Equals((object) this.secondSelectedEntity))
        {
          this.ClearAllPreviousCommandData();
          return;
        }
        this.ScreenToPlane(this.point_0, Plane.XY, out this.point3D_2);
        clsVar.varEditorRuntimeSet.FilletRadius = clsItem.frmEditorV2.spn_filletrad.Value;
        this.firstSelectedEntity = this.method_19(this.firstSelectedEntity);
        this.secondSelectedEntity = this.method_19(this.secondSelectedEntity);
        ICurve icurve_1_1 = (ICurve) this.firstSelectedEntity.Clone();
        ICurve icurve_4_1 = (ICurve) this.secondSelectedEntity.Clone();
        ICurve icurve_3 = (ICurve) null;
        ICurve icurve_5 = (ICurve) null;
        ICurve C1 = (ICurve) null;
        ICurve C2 = (ICurve) null;
        if (this.firstSelectedEntity is Arc)
        {
          Arc firstSelectedEntity = this.firstSelectedEntity as Arc;
          C1 = (ICurve) new Circle(firstSelectedEntity.Center, firstSelectedEntity.Radius);
        }
        else if (this.firstSelectedEntity is Line)
          C1 = Class5.smethod_56((ICurve) this.firstSelectedEntity, this);
        else if (this.firstSelectedEntity is EllipticalArc)
        {
          EllipticalArc firstSelectedEntity = this.firstSelectedEntity as EllipticalArc;
          C1 = (ICurve) new Ellipse(firstSelectedEntity.Center, firstSelectedEntity.RadiusX, firstSelectedEntity.RadiusY);
        }
        if (this.secondSelectedEntity is Arc)
        {
          Arc secondSelectedEntity = this.secondSelectedEntity as Arc;
          C2 = (ICurve) new Circle(secondSelectedEntity.Center, secondSelectedEntity.Radius);
        }
        else if (this.secondSelectedEntity is Line)
          C2 = Class5.smethod_56((ICurve) this.secondSelectedEntity, this);
        else if (this.secondSelectedEntity is EllipticalArc)
        {
          EllipticalArc secondSelectedEntity = this.secondSelectedEntity as EllipticalArc;
          C2 = (ICurve) new Ellipse(secondSelectedEntity.Center, secondSelectedEntity.RadiusX, secondSelectedEntity.RadiusY);
        }
        ICurve icurve_0_1 = icurve_1_1;
        ICurve icurve_2_1 = icurve_4_1;
        if ((Utility.Intersection((ICurve) this.firstSelectedEntity, (ICurve) this.secondSelectedEntity).Length > 1 ? 1 : (C1 == null || C2 == null ? 0 : (Utility.Intersection(C1, C2).Length > 1 ? 1 : 0))) != 0)
          Class5.smethod_153(ref icurve_0_1, icurve_1_1, out icurve_2_1, out icurve_3, icurve_4_1, out icurve_5, this);
        ICurve[] curveArray1 = new ICurve[8]
        {
          Class5.smethod_0(icurve_0_1, this),
          Class5.smethod_0(icurve_0_1, this),
          Class5.smethod_0(icurve_0_1, this),
          Class5.smethod_0(icurve_0_1, this),
          null,
          null,
          null,
          null
        };
        ICurve[] curveArray2 = new ICurve[8]
        {
          Class5.smethod_0(icurve_2_1, this),
          Class5.smethod_0(icurve_2_1, this),
          Class5.smethod_0(icurve_2_1, this),
          Class5.smethod_0(icurve_2_1, this),
          null,
          null,
          null,
          null
        };
        Arc[] gparam_0 = new Arc[8];
        ICurve firstSelectedEntity1 = this.firstSelectedEntity as ICurve;
        ICurve secondSelectedEntity1 = this.secondSelectedEntity as ICurve;
        double num1 = Point3D.Distance(this.point3D_1, firstSelectedEntity1.StartPoint);
        double num2 = Point3D.Distance(this.point3D_1, firstSelectedEntity1.EndPoint);
        if ((num2 >= num1 ? 0 : (firstSelectedEntity1 is Arc ? 1 : (firstSelectedEntity1 is EllipticalArc ? 1 : 0))) != 0)
          firstSelectedEntity1.Reverse();
        double num3 = Point3D.Distance(this.point3D_2, secondSelectedEntity1.StartPoint);
        double num4 = Point3D.Distance(this.point3D_2, secondSelectedEntity1.EndPoint);
        if ((num4 >= num3 ? 0 : (secondSelectedEntity1 is Arc ? 1 : (secondSelectedEntity1 is EllipticalArc ? 1 : 0))) != 0)
          secondSelectedEntity1.Reverse();
        for (int index = 4; index < curveArray1.Length; ++index)
          curveArray1[index] = Class5.smethod_0(icurve_0_1, this);
        for (int index = 4; index < curveArray2.Length; ++index)
          curveArray2[index] = Class5.smethod_0(icurve_2_1, this);
        Curve.Fillet(curveArray1[0], curveArray2[0], clsVar.varEditorRuntimeSet.FilletRadius, false, false, true, true, out gparam_0[0]);
        Curve.Fillet(curveArray1[1], curveArray2[1], clsVar.varEditorRuntimeSet.FilletRadius, false, true, true, true, out gparam_0[1]);
        Curve.Fillet(curveArray1[2], curveArray2[2], clsVar.varEditorRuntimeSet.FilletRadius, true, false, true, true, out gparam_0[2]);
        Curve.Fillet(curveArray1[3], curveArray2[3], clsVar.varEditorRuntimeSet.FilletRadius, true, true, true, true, out gparam_0[3]);
        Curve.Fillet(curveArray1[4], curveArray2[4], clsVar.varEditorRuntimeSet.FilletRadius, false, false, true, true, out gparam_0[4]);
        Curve.Fillet(curveArray1[5], curveArray2[5], clsVar.varEditorRuntimeSet.FilletRadius, false, true, true, true, out gparam_0[5]);
        Curve.Fillet(curveArray1[6], curveArray2[6], clsVar.varEditorRuntimeSet.FilletRadius, true, false, true, true, out gparam_0[6]);
        Curve.Fillet(curveArray1[7], curveArray2[7], clsVar.varEditorRuntimeSet.FilletRadius, true, true, true, true, out gparam_0[7]);
        int index1 = this.method_20<Arc>(gparam_0);
        if (index1 >= 0)
        {
          clsInit.appEditor2.UndoBuffer();
          this.Entities.Remove(this.firstSelectedEntity);
          this.Entities.Remove(this.secondSelectedEntity);
          ICurve icurve_0_2 = curveArray1[index1];
          ICurve icurve_0_3 = curveArray2[index1];
          bool bool_0_1 = icurve_0_2 is EllipticalArc && (icurve_0_2 as EllipticalArc).Center.X > this.point3D_1.X;
          ICurve curve1 = Class5.smethod_148(this, icurve_0_2, icurve_3, bool_0_1);
          if (curve1 != null)
            curveArray1[index1] = curve1;
          bool bool_0_2 = icurve_0_3 is EllipticalArc && (icurve_0_3 as EllipticalArc).Center.X > this.point3D_2.X;
          ICurve curve2 = Class5.smethod_148(this, icurve_0_3, icurve_5, bool_0_2);
          if (curve2 != null)
            curveArray2[index1] = curve2;
          this.method_18(!Class5.smethod_162(this.firstSelectedEntity) ? (Entity) curveArray1[index1] : this.firstSelectedEntity, this.ActiveLayerName, true, true);
          this.method_18(!Class5.smethod_162(this.secondSelectedEntity) ? (Entity) curveArray2[index1] : this.secondSelectedEntity, this.ActiveLayerName, true, true);
          this.method_18((Entity) gparam_0[index1], this.ActiveLayerName, true, true);
        }
        else if ((firstSelectedEntity1.StartPoint.Equals(secondSelectedEntity1.StartPoint) || firstSelectedEntity1.StartPoint.Equals(secondSelectedEntity1.EndPoint) || secondSelectedEntity1.StartPoint.Equals(firstSelectedEntity1.EndPoint) ? 0 : (!secondSelectedEntity1.EndPoint.Equals(firstSelectedEntity1.EndPoint) ? 1 : 0)) != 0)
        {
          if ((this.secondSelectedEntity is Arc || this.secondSelectedEntity is EllipticalArc ? (this.firstSelectedEntity is Line ? 1 : 0) : 0) != 0)
          {
            if (!Class5.smethod_162(this.secondSelectedEntity))
              this.method_21();
            Utility.Swap<Entity>(ref this.firstSelectedEntity, ref this.secondSelectedEntity);
            this.method_21();
            Utility.Swap<Entity>(ref this.firstSelectedEntity, ref this.secondSelectedEntity);
          }
          else
          {
            Utility.Swap<Entity>(ref this.firstSelectedEntity, ref this.secondSelectedEntity);
            this.method_21();
            Utility.Swap<Entity>(ref this.firstSelectedEntity, ref this.secondSelectedEntity);
            this.method_21();
            if ((num2 >= num1 ? 0 : (firstSelectedEntity1 is Arc ? 1 : (secondSelectedEntity1 is Arc ? 1 : 0))) != 0)
              firstSelectedEntity1.Reverse();
            if ((num4 >= num3 ? 0 : (firstSelectedEntity1 is Arc ? 1 : (secondSelectedEntity1 is Arc ? 1 : 0))) != 0)
              secondSelectedEntity1.Reverse();
          }
          if (clsVar.varEditorRuntimeSet.FilletRadius > 0.0)
          {
            clsInit.appEditor2.UndoBuffer();
            ICurve icurve_1_2 = (ICurve) this.firstSelectedEntity.Clone();
            ICurve icurve_4_2 = (ICurve) this.secondSelectedEntity.Clone();
            ICurve icurve_0_4 = icurve_1_2;
            ICurve icurve_2_2 = icurve_4_2;
            if ((Utility.Intersection((ICurve) this.firstSelectedEntity, (ICurve) this.secondSelectedEntity).Length > 1 ? 1 : (C1 == null || C2 == null ? 0 : (Utility.Intersection(C1, C2).Length > 1 ? 1 : 0))) != 0)
              Class5.smethod_153(ref icurve_0_4, icurve_1_2, out icurve_2_2, out icurve_3, icurve_4_2, out icurve_5, this);
            for (int index2 = 0; index2 < curveArray1.Length; ++index2)
              curveArray1[index2] = Class5.smethod_0(icurve_0_4, this);
            for (int index3 = 0; index3 < curveArray2.Length; ++index3)
              curveArray2[index3] = Class5.smethod_0(icurve_2_2, this);
            Curve.Fillet(curveArray1[0], curveArray2[0], clsVar.varEditorRuntimeSet.FilletRadius, false, false, true, true, out gparam_0[0]);
            Curve.Fillet(curveArray1[1], curveArray2[1], clsVar.varEditorRuntimeSet.FilletRadius, false, true, true, true, out gparam_0[1]);
            Curve.Fillet(curveArray1[2], curveArray2[2], clsVar.varEditorRuntimeSet.FilletRadius, true, false, true, true, out gparam_0[2]);
            Curve.Fillet(curveArray1[3], curveArray2[3], clsVar.varEditorRuntimeSet.FilletRadius, true, true, true, true, out gparam_0[3]);
            Curve.Fillet(curveArray1[4], curveArray2[4], clsVar.varEditorRuntimeSet.FilletRadius, false, false, true, true, out gparam_0[4]);
            Curve.Fillet(curveArray1[5], curveArray2[5], clsVar.varEditorRuntimeSet.FilletRadius, false, true, true, true, out gparam_0[5]);
            Curve.Fillet(curveArray1[6], curveArray2[6], clsVar.varEditorRuntimeSet.FilletRadius, true, false, true, true, out gparam_0[6]);
            Curve.Fillet(curveArray1[7], curveArray2[7], clsVar.varEditorRuntimeSet.FilletRadius, true, true, true, true, out gparam_0[7]);
            int index4 = this.method_20<Arc>(gparam_0);
            if (index4 >= 0)
            {
              this.Entities.Remove(this.secondSelectedEntity);
              this.Entities.Remove(this.firstSelectedEntity);
              ICurve curve3 = Class5.smethod_148(this, curveArray1[index4], icurve_3, true);
              if (curve3 != null)
                curveArray1[index4] = curve3;
              ICurve curve4 = Class5.smethod_148(this, curveArray2[index4], icurve_5, true);
              if (curve4 != null)
                curveArray2[index4] = curve4;
              this.method_18(!Class5.smethod_162(this.firstSelectedEntity) ? (Entity) curveArray1[index4] : this.firstSelectedEntity, this.ActiveLayerName, true, true);
              this.method_18(!Class5.smethod_162(this.secondSelectedEntity) ? (Entity) curveArray2[index4] : this.secondSelectedEntity, this.ActiveLayerName, true, true);
              this.method_18((Entity) gparam_0[index4], this.ActiveLayerName, true, true);
            }
            else
            {
              this.method_18(this.firstSelectedEntity, this.ActiveLayerName, true, true);
              this.method_18(this.secondSelectedEntity, this.ActiveLayerName, true, true);
            }
          }
        }
      }
      catch
      {
      }
      this.ClearAllPreviousCommandData();
    }
  }

  public void EventChamfer()
  {
    if (this.firstSelectedEntity == null)
    {
      if (this.selEntityIndex != -1)
      {
        this.firstSelectedEntity = this.Entities[this.selEntityIndex];
        this.selEntityIndex = -1;
        this.ScreenToPlane(this.point_0, Plane.XY, out this.point3D_1);
        return;
      }
    }
    else if (this.secondSelectedEntity == null)
      ;
    if (this.secondSelectedEntity == null && this.selEntityIndex != -1)
      this.secondSelectedEntity = this.Entities[this.selEntityIndex];
    if ((!(this.firstSelectedEntity is ICurve) ? 0 : (this.secondSelectedEntity is ICurve ? 1 : 0)) == 0)
      return;
    if (this.firstSelectedEntity.Equals((object) this.secondSelectedEntity))
    {
      this.ClearAllPreviousCommandData();
    }
    else
    {
      clsVar.varEditorRuntimeSet.ChamferLength = clsItem.frmEditorV2.spn_chamgerlen.Value;
      this.firstSelectedEntity = this.method_19(this.firstSelectedEntity);
      this.secondSelectedEntity = this.method_19(this.secondSelectedEntity);
      this.ScreenToPlane(this.point_0, Plane.XY, out this.point3D_2);
      double chamferLength = clsVar.varEditorRuntimeSet.ChamferLength;
      ICurve icurve_1_1 = (ICurve) this.firstSelectedEntity.Clone();
      ICurve icurve_4_1 = (ICurve) this.secondSelectedEntity.Clone();
      ICurve icurve_3 = (ICurve) null;
      ICurve icurve_5 = (ICurve) null;
      ICurve C1 = (ICurve) null;
      ICurve C2 = (ICurve) null;
      if (this.firstSelectedEntity is Arc)
      {
        Arc firstSelectedEntity = this.firstSelectedEntity as Arc;
        C1 = (ICurve) new Circle(firstSelectedEntity.Center, firstSelectedEntity.Radius);
      }
      else if (this.firstSelectedEntity is Line)
        C1 = Class5.smethod_56((ICurve) this.firstSelectedEntity, this);
      else if (this.firstSelectedEntity is EllipticalArc)
      {
        EllipticalArc firstSelectedEntity = (EllipticalArc) this.firstSelectedEntity;
        C1 = (ICurve) new Ellipse(firstSelectedEntity.Center, firstSelectedEntity.RadiusX, firstSelectedEntity.RadiusY);
      }
      if (this.secondSelectedEntity is Arc)
      {
        Arc secondSelectedEntity = this.secondSelectedEntity as Arc;
        C2 = (ICurve) new Circle(secondSelectedEntity.Center, secondSelectedEntity.Radius);
      }
      else if (this.secondSelectedEntity is Line)
        C2 = Class5.smethod_56((ICurve) this.secondSelectedEntity, this);
      else if (this.secondSelectedEntity is EllipticalArc)
      {
        EllipticalArc secondSelectedEntity = this.secondSelectedEntity as EllipticalArc;
        C2 = (ICurve) new Ellipse(secondSelectedEntity.Center, secondSelectedEntity.RadiusX, secondSelectedEntity.RadiusY);
      }
      ICurve icurve_0_1 = icurve_1_1;
      ICurve icurve_2_1 = icurve_4_1;
      if ((Utility.Intersection((ICurve) this.firstSelectedEntity, (ICurve) this.secondSelectedEntity).Length > 1 ? 1 : (C1 == null || C2 == null ? 0 : (Utility.Intersection(C1, C2).Length > 1 ? 1 : 0))) != 0)
        Class5.smethod_153(ref icurve_0_1, icurve_1_1, out icurve_2_1, out icurve_3, icurve_4_1, out icurve_5, this);
      ICurve[] curveArray1 = new ICurve[8]
      {
        Class5.smethod_0(icurve_0_1, this),
        Class5.smethod_0(icurve_0_1, this),
        Class5.smethod_0(icurve_0_1, this),
        Class5.smethod_0(icurve_0_1, this),
        null,
        null,
        null,
        null
      };
      ICurve[] curveArray2 = new ICurve[8]
      {
        Class5.smethod_0(icurve_2_1, this),
        Class5.smethod_0(icurve_2_1, this),
        Class5.smethod_0(icurve_2_1, this),
        Class5.smethod_0(icurve_2_1, this),
        null,
        null,
        null,
        null
      };
      Line[] gparam_0 = new Line[8];
      ICurve firstSelectedEntity1 = this.firstSelectedEntity as ICurve;
      ICurve secondSelectedEntity1 = this.secondSelectedEntity as ICurve;
      double num1 = Point3D.Distance(this.point3D_1, firstSelectedEntity1.StartPoint);
      double num2 = Point3D.Distance(this.point3D_1, firstSelectedEntity1.EndPoint);
      if ((num2 >= num1 ? 0 : (firstSelectedEntity1 is Arc ? 1 : (firstSelectedEntity1 is EllipticalArc ? 1 : 0))) != 0)
        firstSelectedEntity1.Reverse();
      double num3 = Point3D.Distance(this.point3D_2, secondSelectedEntity1.StartPoint);
      double num4 = Point3D.Distance(this.point3D_2, secondSelectedEntity1.EndPoint);
      if ((num4 >= num3 ? 0 : (secondSelectedEntity1 is Arc ? 1 : (secondSelectedEntity1 is EllipticalArc ? 1 : 0))) != 0)
        secondSelectedEntity1.Reverse();
      for (int index = 4; index < curveArray1.Length; ++index)
        curveArray1[index] = Class5.smethod_0(icurve_0_1, this);
      for (int index = 4; index < curveArray2.Length; ++index)
        curveArray2[index] = Class5.smethod_0(icurve_2_1, this);
      Curve.Chamfer(curveArray1[0], curveArray2[0], chamferLength, false, false, true, true, out gparam_0[0]);
      Curve.Chamfer(curveArray1[1], curveArray2[1], chamferLength, false, true, true, true, out gparam_0[1]);
      Curve.Chamfer(curveArray1[2], curveArray2[2], chamferLength, true, false, true, true, out gparam_0[2]);
      Curve.Chamfer(curveArray1[3], curveArray2[3], chamferLength, true, true, true, true, out gparam_0[3]);
      Curve.Chamfer(curveArray1[4], curveArray2[4], chamferLength, false, false, true, true, out gparam_0[4]);
      Curve.Chamfer(curveArray1[5], curveArray2[5], chamferLength, false, true, true, true, out gparam_0[5]);
      Curve.Chamfer(curveArray1[6], curveArray2[6], chamferLength, true, false, true, true, out gparam_0[6]);
      Curve.Chamfer(curveArray1[7], curveArray2[7], chamferLength, true, true, true, true, out gparam_0[7]);
      int index1 = this.method_20<Line>(gparam_0);
      if (index1 >= 0)
      {
        clsInit.appEditor2.UndoBuffer();
        this.Entities.Remove(this.firstSelectedEntity);
        this.Entities.Remove(this.secondSelectedEntity);
        bool bool_0_1 = curveArray1[index1] is EllipticalArc && ((Ellipse) curveArray1[index1]).Center.X > this.point3D_1.X;
        ICurve curve1 = Class5.smethod_148(this, curveArray1[index1], icurve_3, bool_0_1);
        if (curve1 != null)
          curveArray1[index1] = curve1;
        bool bool_0_2 = curveArray2[index1] is EllipticalArc && ((Ellipse) curveArray2[index1]).Center.X > this.point3D_2.X;
        ICurve curve2 = Class5.smethod_148(this, curveArray2[index1], icurve_5, bool_0_2);
        if (curve2 != null)
          curveArray2[index1] = curve2;
        this.method_18(!Class5.smethod_162(this.firstSelectedEntity) ? (Entity) curveArray1[index1] : this.firstSelectedEntity, this.ActiveLayerName, true, true);
        this.method_18(!Class5.smethod_162(this.secondSelectedEntity) ? (Entity) curveArray2[index1] : this.secondSelectedEntity, this.ActiveLayerName, true, true);
        this.method_18((Entity) gparam_0[index1], this.ActiveLayerName, true, true);
      }
      else if ((firstSelectedEntity1.StartPoint.Equals(secondSelectedEntity1.StartPoint) || firstSelectedEntity1.StartPoint.Equals(secondSelectedEntity1.EndPoint) || secondSelectedEntity1.StartPoint.Equals(firstSelectedEntity1.EndPoint) ? 0 : (!secondSelectedEntity1.EndPoint.Equals(firstSelectedEntity1.EndPoint) ? 1 : 0)) != 0)
      {
        if ((this.secondSelectedEntity is Arc || this.secondSelectedEntity is EllipticalArc ? (this.firstSelectedEntity is Line ? 1 : 0) : 0) != 0)
        {
          if (!Class5.smethod_162(this.secondSelectedEntity))
            this.method_21();
          Utility.Swap<Entity>(ref this.firstSelectedEntity, ref this.secondSelectedEntity);
          this.method_21();
          Utility.Swap<Entity>(ref this.firstSelectedEntity, ref this.secondSelectedEntity);
        }
        else
        {
          Utility.Swap<Entity>(ref this.firstSelectedEntity, ref this.secondSelectedEntity);
          this.method_21();
          Utility.Swap<Entity>(ref this.firstSelectedEntity, ref this.secondSelectedEntity);
          this.method_21();
          if ((num2 >= num1 ? 0 : (firstSelectedEntity1 is Arc ? 1 : (secondSelectedEntity1 is Arc ? 1 : 0))) != 0)
            firstSelectedEntity1.Reverse();
          if ((num4 >= num3 ? 0 : (firstSelectedEntity1 is Arc ? 1 : (secondSelectedEntity1 is Arc ? 1 : 0))) != 0)
            secondSelectedEntity1.Reverse();
        }
        if (chamferLength > 0.0)
        {
          clsInit.appEditor2.UndoBuffer();
          ICurve icurve_1_2 = (ICurve) this.firstSelectedEntity.Clone();
          ICurve icurve_4_2 = (ICurve) this.secondSelectedEntity.Clone();
          ICurve icurve_0_2 = icurve_1_2;
          ICurve icurve_2_2 = icurve_4_2;
          if ((Utility.Intersection((ICurve) this.firstSelectedEntity, (ICurve) this.secondSelectedEntity).Length > 1 ? 1 : (C1 == null || C2 == null ? 0 : (Utility.Intersection(C1, C2).Length > 1 ? 1 : 0))) != 0)
            Class5.smethod_153(ref icurve_0_2, icurve_1_2, out icurve_2_2, out icurve_3, icurve_4_2, out icurve_5, this);
          for (int index2 = 0; index2 < curveArray1.Length; ++index2)
            curveArray1[index2] = Class5.smethod_0(icurve_0_2, this);
          for (int index3 = 0; index3 < curveArray2.Length; ++index3)
            curveArray2[index3] = Class5.smethod_0(icurve_2_2, this);
          Curve.Chamfer(curveArray1[0], curveArray2[0], chamferLength, false, false, true, true, out gparam_0[0]);
          Curve.Chamfer(curveArray1[1], curveArray2[1], chamferLength, false, true, true, true, out gparam_0[1]);
          Curve.Chamfer(curveArray1[2], curveArray2[2], chamferLength, true, false, true, true, out gparam_0[2]);
          Curve.Chamfer(curveArray1[3], curveArray2[3], chamferLength, true, true, true, true, out gparam_0[3]);
          Curve.Chamfer(curveArray1[4], curveArray2[4], chamferLength, false, false, true, true, out gparam_0[4]);
          Curve.Chamfer(curveArray1[5], curveArray2[5], chamferLength, false, true, true, true, out gparam_0[5]);
          Curve.Chamfer(curveArray1[6], curveArray2[6], chamferLength, true, false, true, true, out gparam_0[6]);
          Curve.Chamfer(curveArray1[7], curveArray2[7], chamferLength, true, true, true, true, out gparam_0[7]);
          int index4 = this.method_20<Line>(gparam_0);
          if (index4 >= 0)
          {
            this.Entities.Remove(this.secondSelectedEntity);
            this.Entities.Remove(this.firstSelectedEntity);
            ICurve curve3 = Class5.smethod_148(this, curveArray1[index4], icurve_3, true);
            if (curve3 != null)
              curveArray1[index4] = curve3;
            ICurve curve4 = Class5.smethod_148(this, curveArray2[index4], icurve_5, true);
            if (curve4 != null)
              curveArray2[index4] = curve4;
            this.method_18(!Class5.smethod_162(this.firstSelectedEntity) ? (Entity) curveArray1[index4] : this.firstSelectedEntity, this.ActiveLayerName, true, true);
            this.method_18(!Class5.smethod_162(this.secondSelectedEntity) ? (Entity) curveArray2[index4] : this.secondSelectedEntity, this.ActiveLayerName, true, true);
            this.method_18((Entity) gparam_0[index4], this.ActiveLayerName, true, true);
          }
          else
          {
            this.method_18(this.firstSelectedEntity, this.ActiveLayerName, true, true);
            this.method_18(this.secondSelectedEntity, this.ActiveLayerName, true, true);
          }
        }
      }
      this.ClearAllPreviousCommandData();
    }
  }

  public void EventRotateEntity()
  {
    this.method_3();
    if (Drafting2D.points.Count == 0 || Drafting2D.points.Count == 1 || Drafting2D.points.Count != 2)
      return;
    foreach (Entity selEntity in this.selEntities)
    {
      Entity entity_0 = (Entity) selEntity.Clone();
      entity_0.Rotate(this.arcSpanAngle, Vector3D.AxisZ, Drafting2D.points[0].Pnt3D);
      if (entity_0 is devDept.Eyeshot.Entities.Text)
        entity_0.Regen(new RegenParams(0.0, (IWorkspace) this));
      this.method_15(entity_0, clsVar.varEditorSet.colorEvent);
    }
  }

  private void method_11()
  {
    if (Drafting2D.points.Count == 0 || Drafting2D.points.Count != 1)
      return;
    foreach (Entity selEntity in this.selEntities)
    {
      Entity entity_0 = (Entity) selEntity.Clone();
      Vector3D v = new Vector3D(Drafting2D.points[0].Pnt3D, this.current);
      entity_0.Translate(v);
      if (entity_0 is devDept.Eyeshot.Entities.Text)
        entity_0.Regen(new RegenParams(0.0, (IWorkspace) this));
      this.method_15(entity_0, clsVar.varEditorSet.colorEvent);
    }
  }

  private void method_12()
  {
    if (Drafting2D.points.Count < 1)
    {
      this.method_1();
    }
    else
    {
      this.method_1();
      Point3D point3D1 = new Point3D(Drafting2D.points[0].Pnt3D.X, Drafting2D.points[0].Pnt3D.Y, Drafting2D.points[0].Pnt3D.Z);
      Point3D point3D2 = new Point3D(this.current.X, this.current.Y, this.current.Z);
      if ((point3D2.X < point3D1.X ? 1 : (point3D2.Y < point3D1.Y ? 1 : 0)) != 0)
      {
        Point3D first = point3D1;
        Point3D second = point3D2;
        Utility.Swap<Point3D>(ref first, ref second);
        point3D1 = first;
        point3D2 = second;
      }
      if (Point3D.Distance(point3D1, point3D2) <= 0.0)
        return;
      Vector3D X = new Vector3D(point3D1, point3D2);
      Plane pln = new Plane(point3D1, X, Vector3D.AxisZ);
      foreach (Entity selEntity in this.selEntities)
      {
        Entity entity_0 = (Entity) selEntity.Clone();
        Transformation reflection = Transformation.CreateReflection(pln);
        entity_0.TransformBy(reflection);
        this.method_15(entity_0, clsVar.varEditorSet.colorEvent);
      }
    }
  }

  private void method_13()
  {
    List<Point3D> source = new List<Point3D>();
    foreach (Point3D point in clsInit.appEditor2.ClicksToPoints(Drafting2D.points))
      source.Add(this.WorldToScreen(point));
    this.RenderContext.DrawLineStrip(source.ToArray());
    if ((this.ActionMode != devDept.Eyeshot.actionType.None ? 0 : (source.Count<Point3D>() > 0 ? 1 : 0)) != 0)
      this.RenderContext.DrawLineStrip(new Point3D[2]
      {
        this.WorldToScreen(clsInit.appEditor2.ClicksToPoints(Drafting2D.points).First<Point3D>()),
        this.WorldToScreen(this.current)
      });
    if (Drafting2D.points.Count != 2)
      return;
    double referenceDistance = Drafting2D.points[0].Pnt3D.DistanceTo(Drafting2D.points[1].Pnt3D);
    if (referenceDistance <= 1E-09)
      return;
    double num = Drafting2D.points[0].Pnt3D.DistanceTo(this.current) / referenceDistance;
    if (num <= 0.0)
      return;
    foreach (Entity selEntity in this.selEntities)
    {
      Entity entity_0 = (Entity) selEntity.Clone();
      entity_0.Scale(Drafting2D.points[0].Pnt3D, num == 0.0 ? 1.0 : num);
      if (entity_0 is devDept.Eyeshot.Entities.Text)
        entity_0.Regen(new RegenParams(0.0, (IWorkspace) this));
      this.method_15(entity_0, clsVar.varEditorSet.colorEvent);
    }
  }

  public void EventOffsetEntity()
  {
    if (Drafting2D.points.Count != 0)
      return;
    clsVar.varEditorSet.OffsetByMouse = clsItem.frmEditorV2.chk_offsetbymouse.Check;
    clsVar.varEditorRuntimeSet.OffsetValue = clsItem.frmEditorV2.spn_offset.Value;
    foreach (Entity selEntity in this.selEntities)
    {
      Entity entity = (Entity) selEntity.Clone();
      ICurve curve = entity as ICurve;
      if (curve == null)
        continue;
      if (clsVar.varEditorSet.OffsetByMouse)
      {
        double t;
        if (!curve.Project(this.current, out t))
          continue;
        double amount = curve.PointAt(t).DistanceTo(this.current);
        ICurve[] positiveOffsets = curve.Offset(amount, Vector3D.AxisZ, true);
        if (positiveOffsets == null || positiveOffsets.Length == 0 || positiveOffsets[0] == null)
          continue;
        ICurve offsetCurve = positiveOffsets[0];
        if (!offsetCurve.Project(this.current, out t))
          continue;
        if (offsetCurve.PointAt(t).DistanceTo(this.current) > 0.001)
        {
          ICurve[] negativeOffsets = curve.Offset(-amount, Vector3D.AxisZ, true);
          if (negativeOffsets == null || negativeOffsets.Length == 0 || negativeOffsets[0] == null)
            continue;
          offsetCurve = negativeOffsets[0];
        }
        this.method_15((Entity) offsetCurve, clsVar.varEditorSet.colorEvent);
      }
      else
      {
        double offsetValue = clsVar.varEditorRuntimeSet.OffsetValue;
        ICurve[] positiveOffsets = curve.Offset(offsetValue, Vector3D.AxisZ, true);
        ICurve[] negativeOffsets = curve.Offset(-offsetValue, Vector3D.AxisZ, true);
        ICurve positive = positiveOffsets != null && positiveOffsets.Length > 0 ? positiveOffsets[0] : null;
        ICurve negative = negativeOffsets != null && negativeOffsets.Length > 0 ? negativeOffsets[0] : null;
        if (positive == null && negative == null)
          continue;
        double positiveDistance = double.MaxValue;
        double negativeDistance = double.MaxValue;
        double t;
        if (positive != null && positive.Project(this.current, out t))
          positiveDistance = positive.PointAt(t).DistanceTo(this.current);
        if (negative != null && negative.Project(this.current, out t))
          negativeDistance = negative.PointAt(t).DistanceTo(this.current);
        ICurve offsetCurve = positiveDistance <= negativeDistance ? positive : negative;
        if (offsetCurve != null)
          this.method_15((Entity) offsetCurve, clsVar.varEditorSet.colorEvent);
      }
    }
  }

  private void method_14()
  {
    Drafting2D.entToTrim = (Entity) null;
    Drafting2D.leftOvers.Clear();
    if (Drafting2D.points.Count != 0 || (Drafting2D.entityMouseUnder == null ? 0 : (Drafting2D.entityMouseUnder.Item != null ? 1 : 0)) == 0)
      return;
    Drafting2D.entToTrim = (Drafting2D.entityMouseUnder == null ? 0 : (Drafting2D.entityMouseUnder.Item != null ? 1 : 0)) == 0 ? (Entity) null : (Drafting2D.entityMouseUnder.Item as Entity).Clone() as Entity;
    List<Entity> previewEntities = new List<Entity>();
    Utility.TrimPreview((IDesign) this, this.point_0, out previewEntities);
    Drafting2D.leftOvers = previewEntities.Select<Entity, Entity>((Func<Entity, Entity>) (entity_0 => entity_0.Clone() as Entity)).ToList<Entity>();
    foreach (Entity leftOver in Drafting2D.leftOvers)
    {
      if (this.CurrentTransformation != (Transformation) null)
        leftOver.TransformBy(this.CurrentTransformation);
    }
    if ((Drafting2D.entToTrim == null ? 0 : (this.CurrentTransformation != (Transformation) null ? 1 : 0)) == 0)
      return;
    Drafting2D.entToTrim.TransformBy(this.CurrentTransformation);
  }

  internal void method_15(Entity entity_0, Color color_0)
  {
    switch (entity_0)
    {
      case ICurve _:
        Class5.smethod_183(color_0, this, entity_0 as ICurve);
        break;
      case LinearDim _:
        LinearDim linearDim = (LinearDim) entity_0;
        Class5.smethod_183(color_0, this, (ICurve) new Line(linearDim.Vertices[6], linearDim.Vertices[7]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(linearDim.Vertices[7], linearDim.Vertices[8]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(linearDim.Vertices[8], linearDim.Vertices[9]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(linearDim.Vertices[9], linearDim.Vertices[6]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(linearDim.Vertices[0], linearDim.Vertices[1]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(linearDim.Vertices[2], linearDim.Vertices[3]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(linearDim.Vertices[4], linearDim.Vertices[5]));
        break;
      case RadialDim _:
        RadialDim radialDim = (RadialDim) entity_0;
        Class5.smethod_183(color_0, this, (ICurve) new Line(radialDim.Vertices[6], radialDim.Vertices[7]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(radialDim.Vertices[7], radialDim.Vertices[8]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(radialDim.Vertices[8], radialDim.Vertices[9]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(radialDim.Vertices[9], radialDim.Vertices[6]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(radialDim.Vertices[0], radialDim.Vertices[5]));
        break;
      case AngularDim _:
        AngularDim angularDim = (AngularDim) entity_0;
        Class5.smethod_183(color_0, this, (ICurve) new Line(angularDim.Vertices[4], angularDim.Vertices[5]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(angularDim.Vertices[5], angularDim.Vertices[6]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(angularDim.Vertices[6], angularDim.Vertices[7]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(angularDim.Vertices[7], angularDim.Vertices[4]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(angularDim.Vertices[0], angularDim.Vertices[1]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(angularDim.Vertices[2], angularDim.Vertices[3]));
        Class5.smethod_183(color_0, this, (ICurve) angularDim.UnderlyingArc);
        break;
      case OrdinateDim _:
        OrdinateDim ordinateDim = (OrdinateDim) entity_0;
        Class5.smethod_183(color_0, this, (ICurve) new Line(ordinateDim.Vertices[4], ordinateDim.Vertices[5]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(ordinateDim.Vertices[5], ordinateDim.Vertices[6]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(ordinateDim.Vertices[6], ordinateDim.Vertices[7]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(ordinateDim.Vertices[7], ordinateDim.Vertices[4]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(ordinateDim.Vertices[0], ordinateDim.Vertices[1]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(ordinateDim.Vertices[1], ordinateDim.Vertices[2]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(ordinateDim.Vertices[2], ordinateDim.Vertices[3]));
        break;
      case devDept.Eyeshot.Entities.Text _:
        devDept.Eyeshot.Entities.Text text = (devDept.Eyeshot.Entities.Text) entity_0;
        Class5.smethod_183(color_0, this, (ICurve) new Line(text.Vertices[0], text.Vertices[1]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(text.Vertices[1], text.Vertices[2]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(text.Vertices[2], text.Vertices[3]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(text.Vertices[3], text.Vertices[0]));
        break;
      case BlockReference _:
        foreach (Entity entity in ((BlockReference) entity_0).Explode(this.Blocks))
        {
          if (entity is ICurve icurve_0)
            Class5.smethod_183(color_0, this, icurve_0);
        }
        break;
      case Leader _:
        Leader leader = (Leader) entity_0;
        Class5.smethod_183(color_0, this, (ICurve) new Line(leader.Vertices[0], leader.Vertices[1]));
        Class5.smethod_183(color_0, this, (ICurve) new Line(leader.Vertices[1], leader.Vertices[2]));
        break;
    }
  }

  public Entity GetEntityByPosition(System.Drawing.Point location)
  {
    SelectedItem underMouseCursor = this.GetItemUnderMouseCursor(location, true);
    return underMouseCursor == null ? (Entity) null : underMouseCursor.Item as Entity;
  }

  private Point2D[] method_16(IList<Point3D> ilist_0)
  {
    Point2D[] point2DArray = new Point2D[ilist_0.Count];
    for (int index = 0; index < ilist_0.Count; ++index)
      point2DArray[index] = (Point2D) this.WorldToScreen(ilist_0[index]);
    return point2DArray;
  }

  public bool IsPolygonClosed()
  {
    return (Drafting2D.points.Count <= 0 || clsInit.appEditor2.action != actionTypeBU.drawLine && clsInit.appEditor2.action != actionTypeBU.drawPolyline && clsInit.appEditor2.action != actionTypeBU.drawCurve ? 0 : (Drafting2D.points[0].Pnt3D.DistanceTo(this.current) < (double) clsVar.varEditorSet.EntityMagnetRange ? 1 : 0)) != 0;
  }

  private Point3D method_17(System.Drawing.Point point_1, Plane plane_0, IList<Point3D> ilist_0, int int_1)
  {
    Point3D point3D;
    if (ilist_0.Count > 0)
    {
      Point3D point = ilist_0[int_1];
      Point3D screen = this.WorldToScreen(point);
      if (Point2D.Distance(new Point2D((double) point_1.X, (double) (this.Size.Height - point_1.Y)), (Point2D) screen) < 10.0)
      {
        point3D = (Point3D) point.Clone();
        goto label_4;
      }
    }
    Point3D intPoint;
    this.ScreenToPlane(point_1, plane_0, out intPoint);
    point3D = intPoint;
label_4:
    return point3D;
  }

  internal void method_18(Entity entity_0, string string_0, bool bool_0, bool bool_1)
  {
    if (entity_0 == null)
      return;
    switch (entity_0)
    {
      case devDept.Eyeshot.Entities.Point _:
        entity_0.ColorMethod = colorMethodType.byEntity;
        entity_0.Color = clsVar.varEditorSet.colorDraw;
        entity_0.LineWeightMethod = colorMethodType.byEntity;
        entity_0.LineWeight = 3f;
        this.Entities.Add(entity_0);
        break;
      case Dimension _:
        Dimension dimension = (Dimension) entity_0;
        dimension.ColorMethod = colorMethodType.byEntity;
        dimension.Color = clsVar.varEditorSet.colorDraw;
        dimension.LayerName = string_0;
        dimension.WidthFactor = 0.9;
        dimension.LineWeightMethod = colorMethodType.byEntity;
        this.Entities.Add((Entity) dimension);
        break;
      case Leader _:
        entity_0.LayerName = string_0;
        entity_0.LineWeightMethod = colorMethodType.byEntity;
        this.Entities.Add(entity_0);
        break;
      case devDept.Eyeshot.Entities.Text _:
        devDept.Eyeshot.Entities.Text text = (devDept.Eyeshot.Entities.Text) entity_0;
        text.LayerName = string_0;
        text.WidthFactor = 0.9;
        text.LineWeightMethod = colorMethodType.byEntity;
        this.Entities.Add((Entity) text);
        break;
      default:
        entity_0.ColorMethod = colorMethodType.byEntity;
        entity_0.Color = clsVar.varEditorSet.colorDraw;
        entity_0.LineWeightMethod = colorMethodType.byEntity;
        entity_0.LineWeight = (float) clsVar.varEditorSet.DrawThickness;
        this.Entities.Add(entity_0, string_0);
        break;
    }
    if (bool_1)
    {
      this.Entities.Regen();
      this.Entities.UpdateBoundingBox();
      this.Invalidate();
    }
    if (clsInit.appEditor2 != null)
      clsInit.appEditor2.JobUpdate();
    if (!bool_0)
      return;
    this.ClearAllPreviousCommandData();
  }

  private Entity method_19(Entity entity_0)
  {
    if ((!(entity_0 is Circle) ? 0 : (!(entity_0 is Arc) ? 1 : 0)) != 0)
    {
      Circle circle = entity_0 as Circle;
      this.Entities.Remove(entity_0);
      entity_0 = (Entity) new Arc(circle.Center, circle.Radius, 2.0 * Math.PI);
    }
    else if ((!(entity_0 is Ellipse) ? 0 : (!(entity_0 is EllipticalArc) ? 1 : 0)) != 0)
    {
      Ellipse ellipse = entity_0 as Ellipse;
      this.Entities.Remove(entity_0);
      entity_0 = (Entity) new EllipticalArc(ellipse.Center, ellipse.RadiusX, ellipse.RadiusY, 2.0 * Math.PI);
    }
    return entity_0;
  }

  private int method_20<T>(T[] gparam_0) where T : ICurve
  {
    double num1 = double.MaxValue;
    int num2 = -1;
    for (int index = 0; index < gparam_0.Length; ++index)
    {
      ICurve curve = (ICurve) gparam_0[index];
      if (curve != null)
      {
        Point3D b = curve.PointAt(curve.Domain.Mid);
        double num3 = Point3D.Distance(this.point3D_1, b) + Point3D.Distance(this.point3D_2, b);
        if (num3 < num1)
        {
          num1 = num3;
          num2 = index;
        }
      }
    }
    return num2;
  }

  private void method_21()
  {
    if ((!(this.firstSelectedEntity is ICurve) ? 0 : (this.secondSelectedEntity is ICurve ? 1 : 0)) == 0)
      return;
    ICurve firstSelectedEntity = this.firstSelectedEntity as ICurve;
    ICurve secondSelectedEntity = this.secondSelectedEntity as ICurve;
    this.ScreenToPlane(this.point_0, Plane.XY, out this.point3D_2);
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
        curve = Class5.smethod_56(secondSelectedEntity, this);
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
        C2 = Class5.smethod_56(firstSelectedEntity, this);
        break;
    }
    double num1;
    double num2;
    if ((curve == null || C2 == null ? 0 : (curve.IntersectWith(C2).Length > 1 ? 1 : 0)) != 0)
    {
      num1 = secondSelectedEntity.StartPoint.DistanceTo(this.point3D_2);
      num2 = secondSelectedEntity.EndPoint.DistanceTo(this.point3D_2);
    }
    else
    {
      num1 = secondSelectedEntity.StartPoint.DistanceTo(b1);
      num2 = secondSelectedEntity.EndPoint.DistanceTo(b2);
    }
    bool flag = false;
    bool bool_0 = num1 < num2;
    switch (secondSelectedEntity)
    {
      case Line _:
        flag = Class5.smethod_194(secondSelectedEntity, bool_0, firstSelectedEntity, this);
        break;
      case LinearPath _:
        flag = Class5.smethod_75(bool_0, this, firstSelectedEntity, secondSelectedEntity);
        break;
      case Arc _:
        flag = Class5.smethod_115(bool_0, secondSelectedEntity, firstSelectedEntity, this);
        break;
      case EllipticalArc _:
        flag = Class5.smethod_171(firstSelectedEntity, secondSelectedEntity, bool_0, this);
        break;
      case Curve _:
        flag = Class5.smethod_214(secondSelectedEntity, firstSelectedEntity, bool_0, this);
        break;
    }
    if (!flag)
      return;
    this.Entities.Regen();
  }

  internal bool method_22(ICurve icurve_0, ICurve icurve_1, bool bool_0)
  {
    ICurve curve1 = icurve_0.Clone() as ICurve;
    List<Point3D> point3DList = new List<Point3D>();
    for (int index = 0; (index >= 100 ? 0 : (point3DList.Count == 0 ? 1 : 0)) != 0; ++index)
    {
      double num = curve1.Domain.Length / 10.0;
      double t = bool_0 ? curve1.Domain.t0 - num : curve1.Domain.t1 + num;
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
      curve2.ExtendBy(point3DList[0], !bool_0);
      this.Entities.Remove((Entity) icurve_0);
      this.Entities.Add((Entity) curve2);
      flag = true;
    }
    return flag;
  }

  public void ClearAllPreviousCommandData()
  {
    clsItem.frmEditorV2.grp_eventmovecmd.Visible = false;
    clsItem.frmEditorV2.grp_events.Visible = false;
    clsInit.appEditor2.StatusUpdate("", "");
    Drafting2D.selectionProcess = true;
    clsInit.appEditor2.action = actionTypeBU.None;
    Drafting2D.NoRectangleSelection = false;
    this.lastPoint = (Point3D) null;
    Drafting2D.points.Clear();
    this.selEntities.Clear();
    this.selEntityIndex = -1;
    this.point3D_0 = (Point3D) null;
    Drafting2D.firstClick = true;
    this.firstSelectedEntity = (Entity) null;
    this.secondSelectedEntity = (Entity) null;
    Drafting2D.entToTrim = (Entity) null;
    Drafting2D.leftOvers = new List<Entity>();
    this.ActionMode = devDept.Eyeshot.actionType.None;
    this.Entities.ClearSelection();
    this.ObjectManipulator.Cancel();
  }

  public void Tick_Add(object sender, EventArgs e)
  {
    actionTypeBU action = clsInit.appEditor2.action;
    this.ClearAllPreviousCommandData();
    this.timer_0.Enabled = false;
    this.Invalidate();
    if (action != actionTypeBU.eventTrim)
      return;
    clsInit.appEditor2.cmdEventsTrim();
  }

  public void PointToOsnap()
  {
    this.currentlySnapping = false;
    if (clsVar.varEditorSet.OsnapEntity)
    {
      this.point3D_0 = (Point3D) null;
      this.snapPoints = this.GetSnapPoints(this.point_0);
      if ((this.snapPoints == null ? 0 : (this.snapPoints.Count > 0 ? 1 : 0)) != 0)
      {
        Drafting2D.SnapPoint snapPoint = this.method_23(this.snapPoints);
        if ((Point3D) snapPoint != (Point3D) null)
        {
          this.current = (Point3D) snapPoint;
          this.currentlySnapping = true;
        }
      }
      if ((Drafting2D.points == null ? 0 : (Drafting2D.points.Count >= 2 ? 1 : 0)) != 0 && buCompare5.EQ(Drafting2D.points[0].Pnt3D, this.current, 2.0))
      {
        Drafting2D.SnapPoint snapPoint_0 = new Drafting2D.SnapPoint(Drafting2D.points[0].Pnt3D, objectSnapType.End);
        this.current = (Point3D) snapPoint_0;
        this.currentlySnapping = true;
        this.method_24(snapPoint_0);
      }
    }
    if (this.currentlySnapping)
      return;
    if (clsVar.varEditorSet.Ortho & this.lastPoint != (Point3D) null & clsInit.appEditor2.action != 0)
    {
      int OrthoDir = 0;
      if (!(this.lastPoint != (Point3D) null))
        return;
      clsInit.cVector5.OrthoFunction(this.current, this.lastPoint, Plane.XY, ref this.current, ref OrthoDir);
    }
    else
    {
      if (!(!this.currentlySnapping & clsVar.varEditorSet.OsnapGrid))
        return;
      Class5.smethod_5(this.current, ref this.current, clsInit.appEditor2);
    }
  }

  private Drafting2D.SnapPoint method_23(List<Drafting2D.SnapPoint> list_0)
  {
    double num1 = double.MaxValue;
    int num2 = 0;
    int index = -1;
    foreach (Point3D point in list_0)
    {
      double num3 = Point2D.Distance((Point2D) this.WorldToScreen(point), new Point2D((double) this.point_0.X, (double) (this.Size.Height - this.point_0.Y)));
      if (num3 < num1 & num3 <= (double) clsVar.varEditorSet.snapSymbolSize)
      {
        index = num2;
        num1 = num3;
      }
      ++num2;
    }
    Drafting2D.SnapPoint snapPoint_0 = (Drafting2D.SnapPoint) null;
    if (index >= 0)
    {
      snapPoint_0 = list_0[index];
      this.method_24(snapPoint_0);
    }
    return snapPoint_0;
  }

  private void method_24(Drafting2D.SnapPoint snapPoint_0)
  {
    double num1 = (double) this.RenderContext.SetLineSize(2f);
    this.RenderContext.SetColorWireframe(Color.FromArgb(0, 0, (int) byte.MaxValue));
    long num2 = (long) this.RenderContext.SetState(depthStencilStateType.DepthTestOff);
    Point2D screen = (Point2D) this.WorldToScreen((Point3D) snapPoint_0);
    this.point3D_0 = (Point3D) snapPoint_0;
    switch (snapPoint_0.Type)
    {
      case objectSnapType.Point:
        this.DrawCircle(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        this.DrawCross(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        break;
      case objectSnapType.End:
        this.DrawQuad(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        break;
      case objectSnapType.Mid:
        this.method_26(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        break;
      case objectSnapType.Center:
        this.DrawCircle(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        break;
      case objectSnapType.Quad:
        double num3 = (double) this.RenderContext.SetLineSize(3f);
        this.method_27(new System.Drawing.Point((int) screen.X, (int) screen.Y));
        break;
    }
    double num4 = (double) this.RenderContext.SetLineSize(1f);
  }

  private Entity method_25(
    System.Drawing.Point point_1,
    IList<Entity> ilist_0,
    ref Transformation transformation_0)
  {
    int[] selectedIndices;
    this.GetCrossingEntities(new Rectangle(point_1.X - 5, point_1.Y - 5, 10, 10), ilist_0, true, out selectedIndices, accParentTransform: transformation_0);
    Entity entity;
    if ((selectedIndices == null ? 0 : (selectedIndices.Length != 0 ? 1 : 0)) != 0)
    {
      if (ilist_0[selectedIndices[0]] is BlockReference)
      {
        BlockReference blockReference = (BlockReference) ilist_0[selectedIndices[0]];
        transformation_0 *= blockReference.GetFullTransformation(this.Blocks);
        entity = this.method_25(point_1, (IList<Entity>) this.Blocks[blockReference.BlockName].Entities, ref transformation_0);
      }
      else
        entity = ilist_0[selectedIndices[0]];
    }
    else
      entity = (Entity) null;
    return entity;
  }

  public List<Drafting2D.SnapPoint> GetSnapPoints(System.Drawing.Point mouseLocation)
  {
    int pickBoxSize = this.PickBoxSize;
    this.PickBoxSize = 10;
    Transformation identity = Transformation.CreateIdentity();
    Entity entity1 = this.method_25(mouseLocation, (IList<Entity>) this.Entities, ref identity);
    this.PickBoxSize = pickBoxSize;
    List<Drafting2D.SnapPoint> snapPoints = new List<Drafting2D.SnapPoint>();
    switch (entity1)
    {
      case devDept.Eyeshot.Entities.Point _:
        devDept.Eyeshot.Entities.Point point = (devDept.Eyeshot.Entities.Point) entity1;
        if (this.ActiveObjectSnap == objectSnapType.Point)
        {
          Point3D vertex = point.Vertices[0];
          snapPoints.Add(new Drafting2D.SnapPoint(vertex, objectSnapType.Point));
          break;
        }
        break;
      case Line _:
        Line line = (Line) entity1;
        snapPoints.Add(new Drafting2D.SnapPoint(line.StartPoint, objectSnapType.End));
        snapPoints.Add(new Drafting2D.SnapPoint(line.EndPoint, objectSnapType.End));
        snapPoints.Add(new Drafting2D.SnapPoint(line.MidPoint, objectSnapType.Mid));
        break;
      case LinearPath _:
        LinearPath linearPath = (LinearPath) entity1;
        List<Drafting2D.SnapPoint> snapPointList1 = new List<Drafting2D.SnapPoint>();
        if (this.ActiveObjectSnap == objectSnapType.End)
        {
          foreach (Point3D vertex in linearPath.Vertices)
            snapPointList1.Add(new Drafting2D.SnapPoint(vertex, objectSnapType.End));
          snapPoints.AddRange((IEnumerable<Drafting2D.SnapPoint>) snapPointList1.ToArray());
          break;
        }
        break;
      case CompositeCurve _:
        CompositeCurve compositeCurve = (CompositeCurve) entity1;
        List<Drafting2D.SnapPoint> snapPointList2 = new List<Drafting2D.SnapPoint>();
        if (this.ActiveObjectSnap == objectSnapType.End)
        {
          foreach (ICurve curve in compositeCurve.CurveList)
            snapPointList2.Add(new Drafting2D.SnapPoint(curve.EndPoint, objectSnapType.End));
          snapPointList2.Add(new Drafting2D.SnapPoint(compositeCurve.CurveList[0].StartPoint, objectSnapType.End));
          snapPoints.AddRange((IEnumerable<Drafting2D.SnapPoint>) snapPointList2.ToArray());
          break;
        }
        break;
      case Arc _:
        Arc arc = (Arc) entity1;
        snapPoints.Add(new Drafting2D.SnapPoint(arc.StartPoint, objectSnapType.End));
        snapPoints.Add(new Drafting2D.SnapPoint(arc.EndPoint, objectSnapType.End));
        snapPoints.Add(new Drafting2D.SnapPoint(arc.MidPoint, objectSnapType.Mid));
        snapPoints.Add(new Drafting2D.SnapPoint(arc.Center, objectSnapType.Center));
        break;
      case Circle _:
        Circle circle1 = (Circle) entity1;
        Point3D point3D1 = new Point3D(circle1.Center.X, circle1.Center.Y + circle1.Radius);
        Point3D point3D2 = new Point3D(circle1.Center.X + circle1.Radius, circle1.Center.Y);
        Point3D point3D3 = new Point3D(circle1.Center.X, circle1.Center.Y - circle1.Radius);
        Point3D point3D4 = new Point3D(circle1.Center.X - circle1.Radius, circle1.Center.Y);
        snapPoints.Add(new Drafting2D.SnapPoint(circle1.EndPoint, objectSnapType.End));
        snapPoints.Add(new Drafting2D.SnapPoint(circle1.Center, objectSnapType.Center));
        snapPoints.Add(new Drafting2D.SnapPoint(point3D1, objectSnapType.Quad));
        snapPoints.Add(new Drafting2D.SnapPoint(point3D2, objectSnapType.Quad));
        snapPoints.Add(new Drafting2D.SnapPoint(point3D3, objectSnapType.Quad));
        snapPoints.Add(new Drafting2D.SnapPoint(point3D4, objectSnapType.Quad));
        break;
      case Curve _:
        Curve curve1 = (Curve) entity1;
        snapPoints.Add(new Drafting2D.SnapPoint(curve1.StartPoint, objectSnapType.End));
        snapPoints.Add(new Drafting2D.SnapPoint(curve1.EndPoint, objectSnapType.End));
        snapPoints.Add(new Drafting2D.SnapPoint(curve1.PointAt(0.5), objectSnapType.Mid));
        break;
      case EllipticalArc _:
        EllipticalArc ellipticalArc = (EllipticalArc) entity1;
        snapPoints.Add(new Drafting2D.SnapPoint(ellipticalArc.StartPoint, objectSnapType.Point));
        snapPoints.Add(new Drafting2D.SnapPoint(ellipticalArc.EndPoint, objectSnapType.Point));
        snapPoints.Add(new Drafting2D.SnapPoint(ellipticalArc.Center, objectSnapType.Center));
        break;
      case Ellipse _:
        Ellipse ellipse1 = (Ellipse) entity1;
        snapPoints.Add(new Drafting2D.SnapPoint(ellipse1.EndPoint, objectSnapType.Point));
        snapPoints.Add(new Drafting2D.SnapPoint(ellipse1.Center, objectSnapType.Center));
        snapPoints.Add(new Drafting2D.SnapPoint(ellipse1.PointAt(ellipse1.Domain.Mid), objectSnapType.Mid));
        break;
      case Mesh _:
        Mesh mesh = (Mesh) entity1;
        if (this.ActiveObjectSnap == objectSnapType.End)
        {
          for (int index = 0; index < mesh.Vertices.Length; ++index)
          {
            Point3D vertex = mesh.Vertices[index];
            snapPoints.Add(new Drafting2D.SnapPoint(vertex, objectSnapType.End));
          }
          break;
        }
        break;
    }
    foreach (Entity entity2 in (EyeshotCollection<Entity>) this.Entities)
    {
      if (entity2 is Circle)
      {
        Circle circle2 = entity2 as Circle;
        snapPoints.Add(new Drafting2D.SnapPoint(circle2.Center, objectSnapType.Center));
      }
      if (entity2 is Ellipse)
      {
        Ellipse ellipse2 = entity2 as Ellipse;
        snapPoints.Add(new Drafting2D.SnapPoint(ellipse2.Center, objectSnapType.Center));
      }
    }
    snapPoints.Add(new Drafting2D.SnapPoint(new Point3D(), objectSnapType.End));
    if (identity != Transformation.CreateIdentity())
    {
      foreach (Drafting2D.SnapPoint snapPoint in snapPoints)
      {
        Point3D point3D5 = identity * (Point3D) snapPoint;
        snapPoint.X = point3D5.X;
        snapPoint.Y = point3D5.Y;
        snapPoint.Z = point3D5.Z;
      }
    }
    return snapPoints;
  }

  public void DrawCross(System.Drawing.Point onScreen)
  {
    double x1 = (double) (onScreen.X + 6);
    double y1 = (double) (onScreen.Y + 6);
    double x2 = (double) (onScreen.X - 6);
    double y2 = (double) (onScreen.Y - 6);
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
    double num = 6.0;
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
    double x1 = (double) (onScreen.X + 6);
    double y1 = (double) (onScreen.Y + 6);
    double x2 = (double) (onScreen.X - 6);
    double y2 = (double) (onScreen.Y - 6);
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

  private void method_26(System.Drawing.Point point_1)
  {
    double x1 = (double) (point_1.X + 6);
    double y1 = (double) (point_1.Y + 6);
    double x2 = (double) (point_1.X - 6);
    double y2 = (double) (point_1.Y - 6);
    Point3D point3D1 = new Point3D((double) point_1.X, y1);
    Point3D point3D2 = new Point3D(x1, y2);
    this.RenderContext.DrawLineLoop(new Point3D[3]
    {
      new Point3D(x2, y2),
      point3D2,
      point3D1
    });
  }

  private void method_27(System.Drawing.Point point_1)
  {
    double x1 = (double) point_1.X + 8.0;
    double y1 = (double) point_1.Y + 8.0;
    double x2 = (double) point_1.X - 8.0;
    double y2 = (double) point_1.Y - 8.0;
    Point3D point3D1 = new Point3D((double) point_1.X, y1);
    Point3D point3D2 = new Point3D((double) point_1.X, y2);
    Point3D point3D3 = new Point3D(x1, (double) point_1.Y);
    Point3D point3D4 = new Point3D(x2, (double) point_1.Y);
    this.RenderContext.DrawLineLoop(new Point3D[4]
    {
      point3D2,
      point3D3,
      point3D1,
      point3D4
    });
  }

  public class SnapPoint : Point3D
  {
    public objectSnapType Type;

    public SnapPoint() => this.Type = objectSnapType.None;

    public SnapPoint(Point3D point3D, objectSnapType objectSnapType)
      : base(point3D.X, point3D.Y, point3D.Z)
    {
      this.Type = objectSnapType;
    }

    public override string ToString() => $"{base.ToString()} | {this.Type.ToString()}";
  }
}
