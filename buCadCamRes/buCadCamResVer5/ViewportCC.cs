// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.ViewportCC
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using ns8;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5;

public class ViewportCC : Design
{
  public Point3D pntUpperRight = new Point3D();
  public Point3D pntUpperLeft = new Point3D();
  public Point3D pntLowerLeft = new Point3D();
  public Point3D pntLowerRight = new Point3D();
  public double ZoomRatio = 1.0;
  public static System.Drawing.Point mouseLocation;
  private System.Drawing.Point point_0;
  private Segment2D segment2D_0;
  public static System.Drawing.Point mouseDownLocation;
  public static int UnderMouseEntityIndex = -1;
  public static object UnderMouseEdge = (object) null;
  public static object UnderMouseFace = (object) null;
  public static Point3D UnderMouseVertice = (Point3D) null;
  public static pickStateType currPickState;
  public static List<List<Point3D>> FreeDrawStrokeList = new List<List<Point3D>>();
  public static List<Point3D> FreeDrawStrokes = new List<Point3D>();
  public static int entityPickIndex = -1;
  public static Entity PickedLastEntity = (Entity) null;
  public static List<Entity> entitiesUnderMouse = new List<Entity>();
  public static List<Entity> entitiesSelectedUnderMouse = new List<Entity>();
  public static Brep.Face[] DynamicSelectedFace = (Brep.Face[]) null;
  public static Brep.Edge[] DynamicSelectedEdge = (Brep.Edge[]) null;
  public static Point3D[] DynamicSelectedVertex = (Point3D[]) null;
  public static Brep.Face[] DynamicSelectedInnerFace = (Brep.Face[]) null;
  public static int[] UnderMouseEntities = (int[]) null;
  public static string textDynamical = (string) null;
  public static bool buttonPressedForSelection = false;
  public static bool buttonPressedFreeDraw = false;
  public static bool ForbiddenAreaClicked = false;
  public static bool ForbiddenAreaClickedView = false;
  public static bool MiddleButtonPressed = false;
  public static bool MousePressed = false;

  protected override void OnMouseDown(MouseEventArgs e)
  {
    try
    {
      ViewportCC.MousePressed = true;
      if (clsVar.threadCalculations == null || clsVar.threadCalculations.IsAlive)
        ;
      ViewportCC.MiddleButtonPressed = e.Button == MouseButtons.Middle;
      ViewportCC.ForbiddenAreaClicked = false;
      if (this.Viewports[0].ViewCubeIcon.Contains(e.Location) | this.Viewports[0].ToolBars[0].Contains(e.Location))
      {
        ViewportCC.ForbiddenAreaClicked = true;
        ViewportCC.ForbiddenAreaClickedView = true;
      }
      if (!ViewportCC.ForbiddenAreaClicked & !AppBool.MousePositionFromMotion)
        this.ScreenToPlane(ViewportCC.mouseLocation, ccVars.planeActive, out ccVars.pntActive);
      if (ccVars.pntActive == (Point3D) null)
        return;
      clsInit.appCommand.CoordinateCalculation(ccVars.pntActive);
      if (ccVars.ConstantCoordinateEnable.Z)
        ccVars.pntActive.Z = ccVars.ConstantCoordinate.Z;
      if (clsVar.varInterface.MinDistanceForEntity > 0.0 && ccVars.Action == actionTypeBU.drawPolyline)
      {
        for (int index = 0; index <= this.Entities.Count - 1; ++index)
        {
          if (this.Entities[index] is ICurve)
          {
            ICurve entity = this.Entities[index] as ICurve;
            double t = 0.0;
            entity.ClosestPointTo(ccVars.pntActive, out t);
            Point3D overPoint = new Point3D();
            if (clsInit.cVector5.GetPointOnEntity(ccVars.pntActive, (object) this.Entities[index], ref overPoint) & Point3D.Distance(overPoint, ccVars.pntActive) < clsVar.varInterface.MinDistanceForEntity)
            {
              double Angle = clsInit.cVector5.PointAngle(ccVars.pntActive, overPoint, ccVars.planeActive);
              clsInit.cVector5.LineWithLengthAndAngle(overPoint, clsVar.varInterface.MinDistanceForEntity, Angle, ref ccVars.pntActive);
            }
          }
        }
      }
      if (clsVar.UserMode.ProfileMode.Enable)
      {
        ViewportCC.UnderMouseEntities = this.GetAllEntitiesUnderMouseCursor(e.Location, false);
        if (ViewportCC.UnderMouseEntities != null & ViewportCC.UnderMouseEntities.Length != 0)
        {
          for (int index = 0; index <= ViewportCC.UnderMouseEntities.Length - 1; ++index)
          {
            Entity entity = this.Entities[ViewportCC.UnderMouseEntities[index]];
          }
          clsInit.appProfile.doSelectedEntities(ViewportCC.UnderMouseEntities);
        }
      }
      if (e.Button == MouseButtons.Left & (this.ActionMode == devDept.Eyeshot.actionType.None | this.ActionMode == devDept.Eyeshot.actionType.SelectVisibleByPickDynamic) & ccVars.selectionProcess & !ViewportCC.ForbiddenAreaClicked)
      {
        ViewportCC.buttonPressedForSelection = true;
        ViewportCC.mouseDownLocation = ViewportCC.mouseLocation = e.Location;
        ViewportCC.currPickState = pickStateType.Pick;
      }
      if (e.Button == MouseButtons.Left & ccVars.Action == actionTypeBU.drawFreeDraw)
      {
        ViewportCC.buttonPressedFreeDraw = true;
        if (clsVar.varInterface.FreeDrawVar.MouseMode == FreeDrawMouseModeType.DownDown & ViewportCC.FreeDrawStrokes.Count >= 2)
        {
          ViewportCC.FreeDrawStrokeList.Add(ViewportCC.FreeDrawStrokes);
          List<Point3D> point3DList = new List<Point3D>();
          ccVars.pntDrawDynamicLinesArr.Add(ViewportCC.FreeDrawStrokes);
          clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[93]);
          ViewportCC.FreeDrawStrokes = new List<Point3D>();
          ViewportCC.buttonPressedFreeDraw = false;
        }
        if (clsVar.varInterface.FreeDrawVar.MouseMode == FreeDrawMouseModeType.DownUp)
        {
          ViewportCC.FreeDrawStrokes.Clear();
          clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[94]);
        }
      }
      if (!ViewportCC.ForbiddenAreaClicked)
      {
        clsInit.appCommand.viewportMouseDown(ccVars.pntActive, (object) this, e);
        if (clsVar.UserMode.NestingMode.Enable)
        {
          ViewportCC.UnderMouseEntities = this.GetAllEntitiesUnderMouseCursor(e.Location, false);
          if (ViewportCC.UnderMouseEntities != null & ViewportCC.UnderMouseEntities.Length == 0 & ccVars.SelectionOP.Selections.Count > 0 & ViewportCC.currPickState == pickStateType.Pick & clsVar.varSelection.ClearSelectionWhenPressEmptySpace)
          {
            if (ccVars.Action == actionTypeBU.eventMove)
            {
              if (ccVars.stpDrawing == 2)
              {
                if (!ccVars.Moved)
                  clsInit.appCommand.Reset();
                else
                  ccVars.Moved = false;
              }
              if (ccVars.stpDrawing == 3 & !ccVars.MoveEntityPointPressed)
              {
                bool flag = false;
                if (clsVar.varDisplay.ShowSelectedEntitiesMovePoint)
                {
                  for (int index1 = 0; index1 <= ccVars.SelectionOP.Selections.Count - 1; ++index1)
                  {
                    for (int index2 = 0; index2 <= ccVars.SelectionOP.Selections[index1].AlingPoints.MovePoints.Count - 1; ++index2)
                    {
                      if (clsInit.cVector5.IsPointInsideWindow(ccVars.pntActive, ccVars.SelectionOP.Selections[index1].AlingPoints.MovePoints[index2], clsVar.varMouse.Osnap.CatchResolution * ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomRatio, ccVars.planeActive))
                        flag = true;
                    }
                  }
                }
                if (!flag)
                  clsInit.appCommand.Reset();
              }
            }
            else if (ccVars.Action == actionTypeBU.None & ccVars.stpDrawing == 0)
              clsInit.appCommand.Reset();
          }
        }
      }
      this.PaintBackBuffer();
      this.SwapBuffers();
      base.OnMouseDown(e);
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    try
    {
      if (clsVar.threadCalculations == null || clsVar.threadCalculations.IsAlive)
        ;
      ViewportCC.mouseLocation = e.Location;
      if (ViewportCC.mouseLocation == this.point_0)
        return;
      if (ViewportCC.buttonPressedForSelection & ccVars.selectionProcess)
      {
        int num = e.Location.X - ViewportCC.mouseDownLocation.X;
        if (num > 10)
        {
          if (!clsVar.varSelection.DontUseRectangleSelection)
            ViewportCC.currPickState = pickStateType.Enclosed;
        }
        else if (num < -10)
        {
          if (!clsVar.varSelection.DontUseRectangleSelection)
            ViewportCC.currPickState = pickStateType.Crossing;
        }
        else
          ViewportCC.currPickState = pickStateType.Pick;
        if (ccVars.selectionOnlyPick)
          ViewportCC.currPickState = pickStateType.Pick;
      }
      if (!AppBool.MousePositionFromMotion)
        this.ScreenToPlane(ViewportCC.mouseLocation, ccVars.planeActive, out ccVars.pntActive);
      if (clsVar.varInterface.MinDistanceForEntity > 0.0 && ccVars.Action == actionTypeBU.drawPolyline)
      {
        for (int index = 0; index <= this.Entities.Count - 1; ++index)
        {
          if (this.Entities[index] is ICurve)
          {
            ICurve entity = this.Entities[index] as ICurve;
            double t = 0.0;
            entity.ClosestPointTo(ccVars.pntActive, out t);
            Point3D overPoint = new Point3D();
            bool pointOnEntity = clsInit.cVector5.GetPointOnEntity(ccVars.pntActive, (object) this.Entities[index], ref overPoint);
            t = Point3D.Distance(overPoint, ccVars.pntActive);
            if (pointOnEntity & t < clsVar.varInterface.MinDistanceForEntity)
            {
              double Angle = clsInit.cVector5.PointAngle(ccVars.pntActive, overPoint, ccVars.planeActive);
              clsInit.cVector5.LineWithLengthAndAngle(overPoint, clsVar.varInterface.MinDistanceForEntity, Angle, ref ccVars.pntActive);
            }
          }
        }
      }
      if (ccVars.pntActive != (Point3D) null & !ViewportCC.MousePressed)
      {
        ccVars.HighLightPoints.Clear();
        ViewportCC.entitiesSelectedUnderMouse.Clear();
        ViewportCC.entitiesUnderMouse.Clear();
        int[] underMouseCursor = this.GetAllEntitiesUnderMouseCursor(e.Location);
        if (underMouseCursor != null)
        {
          if (underMouseCursor.Length == 0)
          {
            ViewportCC.UnderMouseEntityIndex = -1;
            ccVars.OsnapCatchPoint.UnderEntityIndex = -1;
            clsItem.timToolTip.Enabled = false;
            ccVars.Pages[ccVars.PageIndex].Form.lbl_tooltip.Visible = false;
          }
          else if (ccVars.Action == actionTypeBU.None & this.ActionMode == devDept.Eyeshot.actionType.None)
          {
            ViewportCC.UnderMouseEntityIndex = underMouseCursor[0];
            ccVars.OsnapCatchPoint.UnderEntityIndex = ViewportCC.UnderMouseEntityIndex;
            clsItem.timToolTip.Enabled = true;
          }
          List<Point3D> point3DList = new List<Point3D>();
          ccVars.numberOfUnderEntity = underMouseCursor.Length;
          ccVars.numberOfUnderSelectedEntity = 0;
          for (int index = 0; index <= underMouseCursor.Length - 1; ++index)
          {
            ViewportCC.UnderMouseEntityIndex = underMouseCursor[index];
            ccVars.OsnapCatchPoint.UnderEntityIndex = ViewportCC.UnderMouseEntityIndex;
            if (ViewportCC.UnderMouseEntityIndex >= 0 & ViewportCC.UnderMouseEntityIndex <= this.Entities.Count - 1)
            {
              ViewportCC.entitiesUnderMouse.Add(this.Entities[ViewportCC.UnderMouseEntityIndex]);
              if (this.Entities[ViewportCC.UnderMouseEntityIndex].Selected)
              {
                ViewportCC.entitiesSelectedUnderMouse.Add(this.Entities[ViewportCC.UnderMouseEntityIndex]);
                ++ccVars.numberOfUnderSelectedEntity;
              }
              if (clsInit.cVector5.isEntityDrawing(this.Entities[ViewportCC.UnderMouseEntityIndex]))
              {
                ((ICurve) this.Entities[ViewportCC.UnderMouseEntityIndex]).ClosestPointTo(ccVars.pntActive, out ccVars.OsnapCatchPoint.DistanceToPoint);
                ccVars.OsnapCatchPoint.EntityPoint = ((ICurve) this.Entities[ViewportCC.UnderMouseEntityIndex]).PointAt(ccVars.OsnapCatchPoint.DistanceToPoint);
                if (this.Entities[ViewportCC.UnderMouseEntityIndex].Vertices != null)
                {
                  HighLights highLights = new HighLights();
                  highLights.PointsList.AddRange((IEnumerable<Point3D>) ((IEnumerable<Point3D>) this.Entities[ViewportCC.UnderMouseEntityIndex].Vertices).ToArray<Point3D>());
                  ccVars.HighLightPoints.Add(highLights);
                }
                if (ccVars.Action == actionTypeBU.camContours && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode == devDept.Eyeshot.actionType.SelectVisibleByPickDynamic)
                {
                  ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
                  ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SelectionFilterMode = selectionFilterType.Edge;
                }
              }
              else if (!(this.Entities[ViewportCC.UnderMouseEntityIndex].GetType() == typeof (Mesh)) && !(this.Entities[ViewportCC.UnderMouseEntityIndex] is Surface) && this.Entities[ViewportCC.UnderMouseEntityIndex] is Brep && ccVars.Action == actionTypeBU.camContours)
              {
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.SelectVisibleByPickDynamic;
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SelectionFilterMode = selectionFilterType.Edge;
              }
            }
          }
          if (ViewportCC.entitiesSelectedUnderMouse.Count > 0)
            clsInit.cVector5.BoxSizeCalculate(ViewportCC.entitiesSelectedUnderMouse, ref ccVars.pntSelectedMin, ref ccVars.pntSelectedMid, ref ccVars.pntSelectedMax);
        }
        else
        {
          ccVars.OsnapCatchPoint.UnderEntityIndex = -1;
          ViewportCC.UnderMouseEntityIndex = -1;
          clsItem.timToolTip.Enabled = false;
          ccVars.Pages[ccVars.PageIndex].Form.lbl_tooltip.Visible = false;
        }
        clsInit.appCommand.CoordinateCalculation(ccVars.pntActive);
        if (ccVars.ConstantCoordinateEnable.Z)
          ccVars.pntActive.Z = ccVars.ConstantCoordinate.Z;
      }
      if (ccVars.pntActive != (Point3D) null)
        clsInit.appCommand.viewportMouseMove(ccVars.pntActive, (object) this, e);
      this.point_0 = ViewportCC.mouseLocation;
      bool flag = false;
      if ((ccVars.Action == actionTypeBU.drawMeasure | ccVars.Action == actionTypeBU.profileSelectPlaneThenOperation | ccVars.Action == actionTypeBU.profileSelectPlaneThenAdd) & !ViewportCC.MiddleButtonPressed && clsVar.varSelection.DynamicSelection != DynamicalSelectionType.Points)
        flag = true;
      if (!flag)
      {
        this.PaintBackBuffer();
        this.SwapBuffers();
      }
      base.OnMouseMove(e);
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    try
    {
      ViewportCC.MousePressed = false;
      if (clsVar.threadCalculations == null || clsVar.threadCalculations.IsAlive)
        ;
      ViewportCC.MiddleButtonPressed = false;
      ViewportCC.ForbiddenAreaClicked = false;
      if (this.Viewports[0].ViewCubeIcon.Contains(e.Location) | this.Viewports[0].ToolBars[0].Contains(e.Location))
        ViewportCC.ForbiddenAreaClicked = true;
      ViewportCC.PickedLastEntity = (Entity) null;
      if (!ViewportCC.ForbiddenAreaClicked)
      {
        if (ViewportCC.buttonPressedFreeDraw & ccVars.Action == actionTypeBU.drawFreeDraw && clsVar.varInterface.FreeDrawVar.MouseMode == FreeDrawMouseModeType.DownUp)
        {
          if (ViewportCC.FreeDrawStrokes.Count > 0)
          {
            clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[93]);
            ViewportCC.FreeDrawStrokeList.Add(ViewportCC.FreeDrawStrokes);
            ccVars.pntDrawDynamicLinesArr.Add(ViewportCC.FreeDrawStrokes);
            ViewportCC.FreeDrawStrokes = new List<Point3D>();
          }
          ViewportCC.buttonPressedFreeDraw = false;
        }
        if (ccVars.selectionProcess & e.Button == MouseButtons.Left & ViewportCC.buttonPressedForSelection)
        {
          List<int> intList1 = new List<int>();
          List<int> intList2 = new List<int>();
          if (ViewportCC.buttonPressedForSelection)
          {
            if (this.CurrentBlockReference != null)
            {
              EntityList entities = this.Blocks[this.CurrentBlockReference.BlockName].Entities;
            }
            else
            {
              List<Entity> entityList = new List<Entity>((IEnumerable<Entity>) this.Entities);
            }
            ViewportCC.buttonPressedForSelection = false;
            ViewportCC.entityPickIndex = -1;
            int num1 = ViewportCC.mouseLocation.X - ViewportCC.mouseDownLocation.X;
            int num2 = ViewportCC.mouseLocation.Y - ViewportCC.mouseDownLocation.Y;
            System.Drawing.Point mouseDownLocation = ViewportCC.mouseDownLocation;
            System.Drawing.Point mouseLocation = ViewportCC.mouseLocation;
            Class5.smethod_9(ref mouseLocation, ref mouseDownLocation);
            switch (ViewportCC.currPickState)
            {
              case pickStateType.Pick:
                ViewportCC.entityPickIndex = this.GetEntityUnderMouseCursor(ViewportCC.mouseLocation);
                if (ViewportCC.entityPickIndex >= 0)
                {
                  ViewportCC.PickedLastEntity = this.Entities[ViewportCC.entityPickIndex];
                  bool flag = false;
                  if (ccVars.Action == actionTypeBU.eventRotateVerHor)
                    flag = true;
                  if (!flag)
                  {
                    if (clsVar.varSelection.SmartSelection & !ccVars.disableSmartSelection & this.Entities[ViewportCC.entityPickIndex] is ICurve)
                    {
                      GetChainEntitiesSettings Settings = new GetChainEntitiesSettings(true, ViewportCC.entityPickIndex, clsVar.varSelection.UseSelectedEntityLayerForChainEntities);
                      clsInit.cVector5.GetChainEntities(ccVars.pntActive, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ToList<Entity>(), ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Blocks, Settings, ref ccVars.SelectionOP);
                      if (System.Windows.Forms.Control.ModifierKeys == Keys.Control)
                        clsInit.appCommand.ManageSelection(ViewportCC.entityPickIndex, System.Windows.Forms.Control.ModifierKeys, intList1, intList2);
                    }
                    else
                      clsInit.appCommand.ManageSelection(ViewportCC.entityPickIndex, System.Windows.Forms.Control.ModifierKeys, intList1, intList2);
                    clsInit.appCommand.SelectionAnalyzeAfterSelected(System.Windows.Forms.Control.ModifierKeys);
                    if (clsInit.appDrill != null)
                      clsInit.appDrill.GetPickEntity(ViewportCC.entityPickIndex);
                    if (clsInit.appMarble != null)
                    {
                      if (ViewportCC.entityPickIndex >= 0 & ViewportCC.entityPickIndex <= this.Entities.Count - 1 && (this.Entities[ViewportCC.entityPickIndex].EntityData == null ? 0 : (this.Entities[ViewportCC.entityPickIndex].EntityData is CustomData ? 1 : 0)) != 0)
                      {
                        if (((CustomData) this.Entities[ViewportCC.entityPickIndex].EntityData).infoBasePoint == (Point3D) null)
                          ((CustomData) this.Entities[ViewportCC.entityPickIndex].EntityData).infoBasePoint = new Point3D();
                        ((CustomData) this.Entities[ViewportCC.entityPickIndex].EntityData).infoBasePoint.X = ccVars.pntActive.X;
                        ((CustomData) this.Entities[ViewportCC.entityPickIndex].EntityData).infoBasePoint.Y = ccVars.pntActive.Y;
                        ((CustomData) this.Entities[ViewportCC.entityPickIndex].EntityData).infoBasePoint.Z = ccVars.pntActive.Z;
                      }
                      clsInit.appMarble.doGetSelectedItemFromPick(ViewportCC.entityPickIndex, ccVars.pntActive);
                      break;
                    }
                    break;
                  }
                  break;
                }
                break;
              case pickStateType.Enclosed:
                int[] selectedIndices1;
                if ((num1 == 0 ? 0 : (num2 != 0 ? 1 : 0)) != 0 && (this.GetEnclosedEntities(new Rectangle(mouseDownLocation, new Size(Math.Abs(num1), Math.Abs(num2))), false, out selectedIndices1) == null ? 0 : (selectedIndices1 != null ? 1 : 0)) != 0)
                {
                  for (int index = 0; index < selectedIndices1.Length; ++index)
                    clsInit.appCommand.ManageSelection(selectedIndices1[index], System.Windows.Forms.Control.ModifierKeys, intList1, intList2);
                  clsInit.appCommand.SelectionAnalyzeAfterSelected(System.Windows.Forms.Control.ModifierKeys);
                  break;
                }
                break;
              case pickStateType.Crossing:
                int[] selectedIndices2;
                if ((num1 == 0 ? 0 : (num2 != 0 ? 1 : 0)) != 0 && (this.GetCrossingEntities(new Rectangle(mouseDownLocation, new Size(Math.Abs(num1), Math.Abs(num2))), (IList<Entity>) this.Entities, false, out selectedIndices2) == null ? 0 : (selectedIndices2 != null ? 1 : 0)) != 0)
                {
                  for (int index = 0; index < selectedIndices2.Length; ++index)
                    clsInit.appCommand.ManageSelection(selectedIndices2[index], System.Windows.Forms.Control.ModifierKeys, intList1, intList2);
                  clsInit.appCommand.SelectionAnalyzeAfterSelected(System.Windows.Forms.Control.ModifierKeys);
                  break;
                }
                break;
            }
            this.Invalidate();
          }
          if (intList1.Count > 0)
            clsInit.appCommand.SelectedToSelectionAdd(intList1);
          if (intList2.Count > 0)
            clsInit.appCommand.SelectedToSelectionRemove(intList2);
        }
        clsInit.appCommand.viewportMouseUp(ccVars.pntActive, (object) this, e);
      }
      this.PaintBackBuffer();
      this.SwapBuffers();
      base.OnMouseUp(e);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error");
    }
  }

  protected override void OnDoubleClick(EventArgs e)
  {
    int[] underMouseCursor = this.GetAllEntitiesUnderMouseCursor(ViewportCC.mouseLocation);
    if (underMouseCursor == null || underMouseCursor.Length != 0)
      ;
    base.OnDoubleClick(e);
  }

  protected override void DrawOverlay(DrawSceneParams data)
  {
    try
    {
      if (clsVar.threadCalculations == null || clsVar.threadCalculations.IsAlive)
        ;
      if (ccVars.pntActive == (Point3D) null)
        return;
      this.ZoomRatio = Class5.smethod_52(this);
      ccVars.Pages[ccVars.PageIndex].Form.lbl_tooltip.Visible = false;
      for (int index = 0; index <= this.Entities.Count - 1; ++index)
      {
        Entity entity = this.Entities[index];
      }
      this.ScreenToPlane(new System.Drawing.Point(this.Width, 0), ccVars.planeActive, out this.pntUpperRight);
      this.ScreenToPlane(new System.Drawing.Point(0, 0), ccVars.planeActive, out this.pntUpperLeft);
      this.ScreenToPlane(new System.Drawing.Point(0, this.Height), ccVars.planeActive, out this.pntLowerLeft);
      this.ScreenToPlane(new System.Drawing.Point(this.Width, this.Height), ccVars.planeActive, out this.pntLowerRight);
      if (this.pntLowerLeft != (Point3D) null)
      {
        buVector5.ScreenInfo.pntMin.X = this.pntLowerLeft.X;
        buVector5.ScreenInfo.pntMin.Y = this.pntLowerLeft.Y;
        buVector5.ScreenInfo.pntMin.Z = this.pntLowerLeft.Z;
        buVector5.ScreenInfo.pntMax.X = this.pntUpperRight.X;
        buVector5.ScreenInfo.pntMax.Y = this.pntUpperRight.Y;
        buVector5.ScreenInfo.pntMax.Z = this.pntUpperRight.Z;
        buVector5.ScreenInfo.ScreenSize.dX = buVector5.ScreenInfo.pntMax.X - buVector5.ScreenInfo.pntMin.X;
        buVector5.ScreenInfo.ScreenSize.dY = buVector5.ScreenInfo.pntMax.Y - buVector5.ScreenInfo.pntMin.Y;
        buVector5.ScreenInfo.ScreenSize.dZ = buVector5.ScreenInfo.pntMax.Z - buVector5.ScreenInfo.pntMin.Z;
      }
      buVector5.ScreenInfo.pntCurrent.X = ccVars.pntActive.X;
      buVector5.ScreenInfo.pntCurrent.Y = ccVars.pntActive.Y;
      buVector5.ScreenInfo.pntCurrent.Z = ccVars.pntActive.Z;
      if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive) | buVector5.isPlaneYZorZY(ccVars.planeActive) && this.pntUpperRight != (Point3D) null & this.pntUpperLeft != (Point3D) null & this.pntLowerLeft != (Point3D) null & this.pntLowerRight != (Point3D) null)
        this.method_0();
      this.RenderContext.EnableXOR(false);
      long num1 = (long) this.RenderContext.SetState(depthStencilStateType.DepthTestOff);
      if (clsVar.varView.ShowOsnapPoints)
        this.method_2();
      if (clsVar.varView.ShowEntityPoints)
        this.method_3();
      if (this.segment2D_0 != null)
      {
        double num2 = (double) this.RenderContext.SetLineSize(4f);
        this.RenderContext.SetColorWireframe(Color.Red);
        this.RenderContext.DrawLine(this.segment2D_0.P0, this.segment2D_0.P1);
      }
      if (ccVars.pntDrawDynamicMarkers.Count > 0)
      {
        for (int index = 0; index <= ccVars.pntDrawDynamicMarkers.Count - 1; ++index)
          this.method_27(ccVars.pntDrawDynamicMarkers[index], clsVar.varView.displayMarker.Thickness, clsVar.varView.displayMarker.Color, 15.0);
      }
      this.method_21();
      this.method_28();
      if (ccVars.enableViewportDrawCurrentLine)
      {
        this.DrawCurrentLine(ccVars.pntBase, ccVars.pntActive);
        if (ccVars.RealDrawMode)
          this.method_16(ccVars.pntBase, ccVars.pntActive, clsVar.varInterface.FatWireframeDistance, clsVar.varDisplay.displayDynamicArrowLineDrawing.Color, clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
      }
      if (ccVars.Action == actionTypeBU.drawFreeDraw)
        this.method_20();
      if (ccVars.Action == actionTypeBU.marbleDrawCompositeCurve & ccVars.pntDynamicCompositeCurve.Count > 0)
        this.DrawDynamicPointCompositeCurve(ccVars.pntActive);
      this.method_17();
      this.DrawDynamicPointArr();
      this.DrawDynamicPointList();
      this.DrawDynamicPointLineArr();
      this.DrawDynamicPointLineArrColor();
      this.DrawDynamicMeasure();
      this.method_18();
      this.method_19();
      if (clsVar.varSelection.ShowAllBoxes)
        this.method_22();
      if (clsVar.varView.ShowDynamicText & ccVars.enableViewportTextForCommand)
        this.method_23(ccVars.pntActive, dynamicInfo.Command, dynamicInfo.Info);
      if (clsVar.varView.ShowDynamicBigCross & ccVars.enableViewportCross)
        this.method_26(ccVars.pntActive);
      if (clsVar.varView.ShowDynamicCross & ccVars.enableViewportCross)
      {
        this.method_27(ccVars.pntActive, clsVar.varView.displayDynamicCrossDisplay.Thickness, clsVar.varView.displayDynamicCrossDisplay.Color);
        if (ccVars.selectionProcess)
        {
          Point2D screen = (Point2D) this.WorldToScreen(ccVars.pntActive);
          this.method_5(new System.Drawing.Point((int) screen.X, (int) screen.Y), 8.0, clsVar.varView.displayDynamicCrossDisplay.Color, clsVar.varView.displayDynamicCrossDisplay.Thickness);
        }
      }
      this.method_1();
      if (ccVars.dynamicTextOnMouse.Length > 0)
        this.method_24(ViewportCC.mouseLocation.X, ViewportCC.mouseLocation.Y, ccVars.dynamicTextOnMouse);
      if (ccVars.DrawCircle.Count > 0)
      {
        for (int index = 0; index <= ccVars.DrawCircle.Count - 1; ++index)
        {
          Point2D screen = (Point2D) this.WorldToScreen(ccVars.DrawCircle[index].Center);
          this.method_10(new System.Drawing.Point((int) screen.X, (int) screen.Y), clsVar.varDisplay.DrawCircleSize, clsVar.varDisplay.displayCircle.Color, clsVar.varDisplay.displayCircle.Thickness);
        }
      }
      if (ccVars.DrawPointer)
        this.DrawPointer();
      if (ViewportCC.buttonPressedForSelection)
      {
        switch (ViewportCC.currPickState)
        {
          case pickStateType.Enclosed:
            this.method_4(ViewportCC.mouseDownLocation, ViewportCC.mouseLocation, clsVar.varSelection.colorSelectionRightToLeft, clsVar.varSelection.SelectionTransparancy, true, false);
            break;
          case pickStateType.Crossing:
            this.method_4(ViewportCC.mouseDownLocation, ViewportCC.mouseLocation, clsVar.varSelection.colorSelectionLeftToRight, clsVar.varSelection.SelectionTransparancy, true, true);
            break;
        }
      }
      if (ViewportCC.textDynamical != null)
        this.method_25(ccVars.pntActive, ViewportCC.textDynamical);
      this.RenderContext.EnableXOR(false);
      base.DrawOverlay(data);
    }
    catch (Exception ex)
    {
    }
  }

  public void GetDynamicSelectionEntityInfo(
    Entity refEntity,
    int Index,
    out Brep.Face[] SelectedFace,
    out Brep.Edge[] SelectedEdge,
    out Point3D[] SelectedVertice,
    out Brep.Face[] SelectedInnerFace)
  {
    SelectedFace = (Brep.Face[]) null;
    SelectedEdge = (Brep.Edge[]) null;
    SelectedVertice = (Point3D[]) null;
    SelectedInnerFace = (Brep.Face[]) null;
    for (int index1 = 0; index1 <= this.Blocks.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= this.Blocks[index1].Entities.Count - 1; ++index2)
      {
        if (!(this.Blocks[index1].Entities[index2].GetType() == typeof (Brep)) || ((Brep) this.Blocks[index1].Entities[index2]).GetSelectedFaces() != null)
          ;
      }
    }
    if (refEntity.GetType() == typeof (BlockReference))
    {
      for (int index3 = 0; index3 <= this.Blocks.Count - 1; ++index3)
      {
        if (((BlockReference) refEntity).BlockName == this.Blocks[index3].Name)
        {
          for (int index4 = 0; index4 <= this.Blocks[index3].Entities.Count - 1; ++index4)
            this.GetDynamicSelectionEntityInfo(this.Blocks[index3].Entities[index4], Index, out SelectedFace, out SelectedEdge, out SelectedVertice, out SelectedInnerFace);
        }
      }
    }
    if (!(refEntity.GetType() == typeof (Brep)))
      return;
    SelectedFace = ((Brep) refEntity).GetSelectedFaces();
    SelectedEdge = ((Brep) refEntity).GetSelectedEdges();
    SelectedVertice = ((Brep) refEntity).GetSelectedVertices();
    SelectedInnerFace = ((Brep) refEntity).GetSelectedInnerFaces();
    if (SelectedFace != null)
    {
      if (SelectedFace.Length == 0)
        return;
      if (SelectedFace[0].Parametric == null)
        ((Brep) refEntity).Rebuild(0.01);
      ViewportCC.UnderMouseFace = (object) SelectedFace[0];
      ViewportCC.UnderMouseEntityIndex = Index;
      clsItem.timToolTip.Enabled = true;
    }
    else if (SelectedEdge != null)
    {
      if (SelectedEdge.Length == 0)
        return;
      ViewportCC.UnderMouseEdge = (object) SelectedEdge[0];
      ViewportCC.UnderMouseEntityIndex = Index;
      clsItem.timToolTip.Enabled = true;
    }
    else if (SelectedVertice != null)
    {
      if (SelectedVertice.Length == 0)
        return;
      ViewportCC.UnderMouseVertice = SelectedVertice[0];
      ViewportCC.UnderMouseEntityIndex = Index;
      clsItem.timToolTip.Enabled = true;
    }
    else if (SelectedInnerFace != null)
    {
      if (SelectedInnerFace[0].Parametric == null)
        ((Brep) refEntity).Rebuild(0.01);
      ViewportCC.UnderMouseFace = (object) SelectedInnerFace[0];
      ViewportCC.UnderMouseEntityIndex = Index;
      clsItem.timToolTip.Enabled = true;
    }
    else
    {
      ViewportCC.UnderMouseFace = (object) null;
      ViewportCC.UnderMouseEdge = (object) null;
      ViewportCC.UnderMouseVertice = (Point3D) null;
    }
  }

  private void method_0()
  {
    try
    {
      int num1 = (int) this.RenderContext.SetState(blendStateType.Blend);
      bool flag = false;
      if (buCompare.EQ(this.ActiveViewport.Camera.Rotation.X, 0.5, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.Y, 0.5, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.Z, 0.5, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.W, 0.5, 0.01) | buCompare.EQ(this.ActiveViewport.Camera.Rotation.X, 0.0, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.Y, 0.0, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.Z, 0.707, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.W, 0.707, 0.01) | buCompare.EQ(this.ActiveViewport.Camera.Rotation.X, 0.0, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.Y, 0.0, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.Z, 0.0, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.W, 1.0, 0.01) | buCompare.EQ(this.ActiveViewport.Camera.Rotation.X, 0.0, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.Y, 0.0, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.Z, -0.707, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.W, 0.707, 0.01) | buCompare.EQ(this.ActiveViewport.Camera.Rotation.X, -0.5, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.Y, -0.5, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.Z, 0.5, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.W, 0.5, 0.01) | buCompare.EQ(this.ActiveViewport.Camera.Rotation.X, 0.0, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.Y, 0.0, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.Z, 1.0, 0.01) & buCompare.EQ(this.ActiveViewport.Camera.Rotation.W, 0.0, 0.01))
        flag = true;
      if (clsVar.varDisplay.LeftRuler.Enable & flag)
      {
        this.RenderContext.SetColorWireframe(Color.FromArgb((int) clsVar.varDisplay.LeftRuler.Transparancy, (int) clsVar.varDisplay.LeftRuler.RulerColor.R, (int) clsVar.varDisplay.LeftRuler.RulerColor.G, (int) clsVar.varDisplay.LeftRuler.RulerColor.B));
        int num2 = (int) this.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
        this.RenderContext.DrawQuad(new RectangleF(0.0f, 0.0f, (float) clsVar.varDisplay.LeftRuler.Width, (float) this.Height));
      }
      if (clsVar.varDisplay.RightRuler.Enable & flag)
      {
        this.RenderContext.SetColorWireframe(Color.FromArgb((int) clsVar.varDisplay.RightRuler.Transparancy, (int) clsVar.varDisplay.RightRuler.RulerColor.R, (int) clsVar.varDisplay.RightRuler.RulerColor.G, (int) clsVar.varDisplay.RightRuler.RulerColor.B));
        int num3 = (int) this.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
        this.RenderContext.DrawQuad(new RectangleF((float) this.Width - (float) clsVar.varDisplay.RightRuler.Width, 0.0f, (float) clsVar.varDisplay.RightRuler.Width, (float) this.Height));
      }
      if (clsVar.varDisplay.BottomRuler.Enable & flag)
      {
        this.RenderContext.SetColorWireframe(Color.FromArgb((int) clsVar.varDisplay.BottomRuler.Transparancy, (int) clsVar.varDisplay.BottomRuler.RulerColor.R, (int) clsVar.varDisplay.BottomRuler.RulerColor.G, (int) clsVar.varDisplay.BottomRuler.RulerColor.B));
        int num4 = (int) this.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
        this.RenderContext.DrawQuad(new RectangleF(0.0f, 0.0f, (float) this.Width, (float) clsVar.varDisplay.BottomRuler.Height));
      }
      if (clsVar.varDisplay.TopRuler.Enable & flag)
      {
        this.RenderContext.SetColorWireframe(Color.FromArgb((int) clsVar.varDisplay.TopRuler.Transparancy, (int) clsVar.varDisplay.TopRuler.RulerColor.R, (int) clsVar.varDisplay.TopRuler.RulerColor.G, (int) clsVar.varDisplay.TopRuler.RulerColor.B));
        int num5 = (int) this.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
        this.RenderContext.DrawQuad(new RectangleF(0.0f, (float) this.Height - (float) clsVar.varDisplay.TopRuler.Height, (float) this.Width, (float) clsVar.varDisplay.TopRuler.Height));
      }
      int num6 = (int) this.RenderContext.SetState(blendStateType.NoBlend);
      double Step = 0.0;
      double num7 = 0.0;
      double num8 = 0.0;
      int num9 = 0;
      string format = "{0:0.#}";
      Point3D point3D = new Point3D();
      if (clsVar.varDisplay.TopRuler.Enable & flag)
      {
        if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
        {
          buGeneral.RulerSteps(Math.Abs(this.pntUpperRight.X - this.pntUpperLeft.X) / (double) clsVar.varDisplay.TopRuler.TotalTickCount, ref Step);
          num7 = this.pntUpperLeft.X - this.pntUpperLeft.X % Step;
          num8 = this.pntUpperRight.X - this.pntUpperRight.X % Step;
        }
        if (buVector5.isPlaneYZorZY(ccVars.planeActive))
        {
          buGeneral.RulerSteps(Math.Abs(this.pntUpperRight.Y - this.pntUpperLeft.Y) / (double) clsVar.varDisplay.TopRuler.TotalTickCount, ref Step);
          num7 = this.pntUpperLeft.Y - this.pntUpperLeft.Y % Step;
          num8 = this.pntUpperRight.Y - this.pntUpperRight.Y % Step;
        }
        if (num7 > num8)
        {
          double num10 = num7;
          num7 = num8;
          num8 = num10;
        }
        for (double num11 = num7; num11 <= num8; num11 += Step)
        {
          double num12 = (double) this.RenderContext.SetLineSize((float) clsVar.varDisplay.TopRuler.SmallTickThickness);
          this.RenderContext.SetColorWireframe(clsVar.varDisplay.TopRuler.SmallTickColor);
          double num13 = clsVar.varDisplay.TopRuler.SmallTickLength;
          if (num9 % clsVar.varDisplay.TopRuler.BigTickCount == 0)
          {
            num13 = clsVar.varDisplay.TopRuler.BigTickLength;
            double num14 = (double) this.RenderContext.SetLineSize((float) clsVar.varDisplay.TopRuler.BigTickThickness);
            this.RenderContext.SetColorWireframe(clsVar.varDisplay.TopRuler.BigTickColor);
          }
          if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
            this.RenderContext.DrawLine(new Point2D(this.WorldToScreen(num11, 0.0, 0.0).X, (double) this.Height - num13), new Point2D(this.WorldToScreen(num11, 0.0, 0.0).X, (double) this.Height));
          if (buVector5.isPlaneYZorZY(ccVars.planeActive))
            this.RenderContext.DrawLine(new Point2D(this.WorldToScreen(0.0, num11, 0.0).X, (double) this.Height - num13), new Point2D(this.WorldToScreen(0.0, num11, 0.0).X, (double) this.Height));
          int num15 = 0;
          if (num11.ToString().Length > 3)
            num15 = (num11.ToString().Length - 3) * 10;
          Font textFont = new Font("Arial", 8f);
          if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
            this.DrawText((int) this.WorldToScreen(num11, 0.0, 0.0).X, this.Height - (int) clsVar.varDisplay.TopRuler.Height - num15, string.Format(format, (object) num11), textFont, clsVar.varDisplay.TopRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft, RotateFlipType.Rotate270FlipX);
          if (buVector5.isPlaneYZorZY(ccVars.planeActive))
            this.DrawText((int) this.WorldToScreen(0.0, num11, 0.0).X, this.Height - (int) clsVar.varDisplay.TopRuler.Height - num15, string.Format(format, (object) num11), textFont, clsVar.varDisplay.TopRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft, RotateFlipType.Rotate270FlipX);
          ++num9;
        }
        double num16 = (double) this.RenderContext.SetLineSize((float) clsVar.varDisplay.TopRuler.MoveCursorThickness);
        this.RenderContext.SetColorWireframe(clsVar.varDisplay.TopRuler.MoveCursorColor);
        if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
          this.RenderContext.DrawLine(new Point2D(this.WorldToScreen(ccVars.pntActive.X, 0.0, 0.0).X, (double) this.Height - clsVar.varDisplay.TopRuler.Height), new Point2D(this.WorldToScreen(ccVars.pntActive.X, 0.0, 0.0).X, (double) this.Height));
        if (buVector5.isPlaneYZorZY(ccVars.planeActive))
          this.RenderContext.DrawLine(new Point2D(this.WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).X, (double) this.Height - clsVar.varDisplay.TopRuler.Height), new Point2D(this.WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).X, (double) this.Height));
      }
      if (clsVar.varDisplay.BottomRuler.Enable & flag)
      {
        if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
        {
          buGeneral.RulerSteps(Math.Abs(this.pntUpperRight.X - this.pntUpperLeft.X) / (double) clsVar.varDisplay.BottomRuler.TotalTickCount, ref Step);
          num7 = this.pntUpperLeft.X - this.pntUpperLeft.X % Step;
          num8 = this.pntUpperRight.X - this.pntUpperRight.X % Step;
        }
        if (buVector5.isPlaneYZorZY(ccVars.planeActive))
        {
          buGeneral.RulerSteps(Math.Abs(this.pntUpperRight.Y - this.pntUpperLeft.Y) / (double) clsVar.varDisplay.BottomRuler.TotalTickCount, ref Step);
          num7 = this.pntUpperLeft.Y - this.pntUpperLeft.Y % Step;
          num8 = this.pntUpperRight.Y - this.pntUpperRight.Y % Step;
        }
        if (num7 > num8)
        {
          double num17 = num7;
          num7 = num8;
          num8 = num17;
        }
        for (double num18 = num7; num18 <= num8; num18 += Step)
        {
          double num19 = (double) this.RenderContext.SetLineSize((float) clsVar.varDisplay.BottomRuler.SmallTickThickness);
          this.RenderContext.SetColorWireframe(clsVar.varDisplay.BottomRuler.SmallTickColor);
          double y = clsVar.varDisplay.BottomRuler.SmallTickLength;
          if (num9 % clsVar.varDisplay.BottomRuler.BigTickCount == 0)
          {
            y = clsVar.varDisplay.BottomRuler.BigTickLength;
            double num20 = (double) this.RenderContext.SetLineSize((float) clsVar.varDisplay.BottomRuler.BigTickThickness);
            this.RenderContext.SetColorWireframe(clsVar.varDisplay.BottomRuler.BigTickColor);
          }
          if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
            this.RenderContext.DrawLine(new Point2D(this.WorldToScreen(num18, 0.0, 0.0).X, y), new Point2D(this.WorldToScreen(num18, 0.0, 0.0).X, 0.0));
          if (buVector5.isPlaneYZorZY(ccVars.planeActive))
            this.RenderContext.DrawLine(new Point2D(this.WorldToScreen(0.0, num18, 0.0).X, y), new Point2D(this.WorldToScreen(0.0, num18, 0.0).X, 0.0));
          Font textFont = new Font("Arial", 8f);
          if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
            this.DrawText((int) this.WorldToScreen(num18, 0.0, 0.0).X, 0, string.Format(format, (object) num18), textFont, clsVar.varDisplay.BottomRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft, RotateFlipType.Rotate270FlipX);
          if (buVector5.isPlaneYZorZY(ccVars.planeActive))
            this.DrawText((int) this.WorldToScreen(0.0, num18, 0.0).X, 0, string.Format(format, (object) num18), textFont, clsVar.varDisplay.BottomRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft, RotateFlipType.Rotate270FlipX);
          ++num9;
        }
        double num21 = (double) this.RenderContext.SetLineSize((float) clsVar.varDisplay.BottomRuler.MoveCursorThickness);
        this.RenderContext.SetColorWireframe(clsVar.varDisplay.BottomRuler.MoveCursorColor);
        if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
          this.RenderContext.DrawLine(new Point2D(this.WorldToScreen(ccVars.pntActive.X, 0.0, 0.0).X, clsVar.varDisplay.BottomRuler.Height), new Point2D(this.WorldToScreen(ccVars.pntActive.X, 0.0, 0.0).X, 0.0));
        if (buVector5.isPlaneYZorZY(ccVars.planeActive))
          this.RenderContext.DrawLine(new Point2D(this.WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).X, clsVar.varDisplay.BottomRuler.Height), new Point2D(this.WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).X, 0.0));
      }
      if (clsVar.varDisplay.LeftRuler.Enable & flag)
      {
        if (buVector5.isPlaneXYorYX(ccVars.planeActive))
        {
          buGeneral.RulerSteps(Math.Abs(this.pntUpperRight.Y - this.pntLowerLeft.Y) / (double) clsVar.varDisplay.LeftRuler.TotalTickCount, ref Step);
          num7 = this.pntLowerLeft.Y - this.pntLowerLeft.Y % Step;
          num8 = this.pntUpperRight.Y - this.pntUpperRight.Y % Step;
        }
        if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
        {
          buGeneral.RulerSteps(Math.Abs(this.pntUpperRight.Z - this.pntLowerLeft.Z) / (double) clsVar.varDisplay.LeftRuler.TotalTickCount, ref Step);
          num7 = this.pntLowerLeft.Z - this.pntLowerLeft.Z % Step;
          num8 = this.pntUpperRight.Z - this.pntUpperRight.Z % Step;
        }
        if (num7 > num8)
        {
          double num22 = num7;
          num7 = num8;
          num8 = num22;
        }
        for (double num23 = num7; num23 <= num8; num23 += Step)
        {
          double num24 = (double) this.RenderContext.SetLineSize((float) clsVar.varDisplay.LeftRuler.SmallTickThickness);
          this.RenderContext.SetColorWireframe(clsVar.varDisplay.LeftRuler.SmallTickColor);
          double x = clsVar.varDisplay.LeftRuler.SmallTickLength;
          if (num9 % clsVar.varDisplay.LeftRuler.BigTickCount == 0)
          {
            x = clsVar.varDisplay.LeftRuler.BigTickLength;
            double num25 = (double) this.RenderContext.SetLineSize((float) clsVar.varDisplay.LeftRuler.BigTickThickness);
            this.RenderContext.SetColorWireframe(clsVar.varDisplay.LeftRuler.BigTickColor);
          }
          if (buVector5.isPlaneXYorYX(ccVars.planeActive))
            this.RenderContext.DrawLine(new Point2D(x, this.WorldToScreen(0.0, num23, 0.0).Y), new Point2D(0.0, this.WorldToScreen(0.0, num23, 0.0).Y));
          if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
            this.RenderContext.DrawLine(new Point2D(x, this.WorldToScreen(0.0, 0.0, num23).Y), new Point2D(0.0, this.WorldToScreen(0.0, 0.0, num23).Y));
          Font textFont = new Font("Arial", 8f);
          if (buVector5.isPlaneXYorYX(ccVars.planeActive))
            this.DrawText(0, (int) this.WorldToScreen(0.0, num23, 0.0).Y, string.Format(format, (object) num23), textFont, clsVar.varDisplay.LeftRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft);
          if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
            this.DrawText(0, (int) this.WorldToScreen(0.0, 0.0, num23).Y, string.Format(format, (object) num23), textFont, clsVar.varDisplay.LeftRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft);
          ++num9;
        }
        double num26 = (double) this.RenderContext.SetLineSize((float) clsVar.varDisplay.LeftRuler.MoveCursorThickness);
        this.RenderContext.SetColorWireframe(clsVar.varDisplay.LeftRuler.MoveCursorColor);
        if (buVector5.isPlaneXYorYX(ccVars.planeActive))
          this.RenderContext.DrawLine(new Point2D(0.0, this.WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).Y), new Point2D(clsVar.varDisplay.LeftRuler.Width, this.WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).Y));
        if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
          this.RenderContext.DrawLine(new Point2D(0.0, this.WorldToScreen(0.0, 0.0, ccVars.pntActive.Z).Y), new Point2D(clsVar.varDisplay.LeftRuler.Width, this.WorldToScreen(0.0, 0.0, ccVars.pntActive.Z).Y));
      }
      if (!(clsVar.varDisplay.RightRuler.Enable & flag))
        return;
      if (buVector5.isPlaneXYorYX(ccVars.planeActive))
      {
        buGeneral.RulerSteps(Math.Abs(this.pntUpperRight.Y - this.pntLowerLeft.Y) / (double) clsVar.varDisplay.RightRuler.TotalTickCount, ref Step);
        num7 = this.pntLowerLeft.Y - this.pntLowerLeft.Y % Step;
        num8 = this.pntUpperRight.Y - this.pntUpperRight.Y % Step;
      }
      if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
      {
        buGeneral.RulerSteps(Math.Abs(this.pntUpperRight.Z - this.pntLowerLeft.Z) / (double) clsVar.varDisplay.RightRuler.TotalTickCount, ref Step);
        num7 = this.pntLowerLeft.Z - this.pntLowerLeft.Z % Step;
        num8 = this.pntUpperRight.Z - this.pntUpperRight.Z % Step;
      }
      if (num7 > num8)
      {
        double num27 = num7;
        num7 = num8;
        num8 = num27;
      }
      for (double num28 = num7; num28 <= num8; num28 += Step)
      {
        double num29 = (double) this.RenderContext.SetLineSize((float) clsVar.varDisplay.RightRuler.SmallTickThickness);
        this.RenderContext.SetColorWireframe(clsVar.varDisplay.RightRuler.SmallTickColor);
        double num30 = clsVar.varDisplay.RightRuler.SmallTickLength;
        if (num9 % clsVar.varDisplay.RightRuler.BigTickCount == 0)
        {
          num30 = clsVar.varDisplay.RightRuler.BigTickLength;
          double num31 = (double) this.RenderContext.SetLineSize((float) clsVar.varDisplay.RightRuler.BigTickThickness);
          this.RenderContext.SetColorWireframe(clsVar.varDisplay.RightRuler.BigTickColor);
        }
        if (buVector5.isPlaneXYorYX(ccVars.planeActive))
          this.RenderContext.DrawLine(new Point2D((double) this.Width - num30, this.WorldToScreen(0.0, num28, 0.0).Y), new Point2D((double) this.Width, this.WorldToScreen(0.0, num28, 0.0).Y));
        if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
          this.RenderContext.DrawLine(new Point2D((double) this.Width - num30, this.WorldToScreen(0.0, 0.0, num28).Y), new Point2D((double) this.Width, this.WorldToScreen(0.0, 0.0, num28).Y));
        int num32 = 0;
        if (num28.ToString().Length > 3)
          num32 = (num28.ToString().Length - 3) * 10;
        Font textFont = new Font("Arial", 8f);
        if (buVector5.isPlaneXYorYX(ccVars.planeActive))
          this.DrawText(this.Width - (int) clsVar.varDisplay.RightRuler.Width - num32, (int) this.WorldToScreen(0.0, num28, 0.0).Y, string.Format(format, (object) num28), textFont, clsVar.varDisplay.RightRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft);
        if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
          this.DrawText(this.Width - (int) clsVar.varDisplay.RightRuler.Width - num32, (int) this.WorldToScreen(0.0, 0.0, num28).Y, string.Format(format, (object) num28), textFont, clsVar.varDisplay.RightRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft);
        ++num9;
      }
      double num33 = (double) this.RenderContext.SetLineSize((float) clsVar.varDisplay.RightRuler.MoveCursorThickness);
      this.RenderContext.SetColorWireframe(clsVar.varDisplay.RightRuler.MoveCursorColor);
      if (buVector5.isPlaneXYorYX(ccVars.planeActive))
        this.RenderContext.DrawLine(new Point2D((double) this.Width, this.WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).Y), new Point2D((double) this.Width - clsVar.varDisplay.RightRuler.Width, this.WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).Y));
      if (!(buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive)))
        return;
      this.RenderContext.DrawLine(new Point2D((double) this.Width, this.WorldToScreen(0.0, 0.0, ccVars.pntActive.Z).Y), new Point2D((double) this.Width - clsVar.varDisplay.RightRuler.Width, this.WorldToScreen(0.0, 0.0, ccVars.pntActive.Z).Y));
    }
    catch (Exception ex)
    {
    }
  }

  private void method_1()
  {
    try
    {
      if (!ccVars.OsnapCatchPoint.Found)
      {
        if (ccVars.OsnapCatchPoint.OrthoFound)
        {
          Point2D screen = (Point2D) this.WorldToScreen(ccVars.OsnapCatchPoint.Point);
          this.method_12(new System.Drawing.Point((int) screen.X, (int) screen.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
        }
        if (ccVars.OsnapCatchPoint.OverFound)
        {
          Point2D screen = (Point2D) this.WorldToScreen(ccVars.OsnapCatchPoint.EntityPoint);
          this.method_9(new System.Drawing.Point((int) screen.X, (int) screen.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
        }
      }
      if (!ccVars.OsnapCatchPoint.Found)
        return;
      Point2D screen1 = (Point2D) this.WorldToScreen(ccVars.OsnapCatchPoint.Point);
      if (ccVars.OsnapCatchPoint.Type == osnapType.ControlPoint)
        this.method_5(new System.Drawing.Point((int) screen1.X, (int) screen1.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
      if (ccVars.OsnapCatchPoint.Type == osnapType.Point)
      {
        this.method_5(new System.Drawing.Point((int) screen1.X, (int) screen1.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
        if (ccVars.OsnapCatchPoint.Point == new Point3D())
        {
          double double_0 = 24.0;
          this.method_5(new System.Drawing.Point((int) screen1.X, (int) screen1.Y), double_0, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
        }
      }
      if (ccVars.OsnapCatchPoint.Type == osnapType.Middle)
        this.method_6(new System.Drawing.Point((int) screen1.X, (int) screen1.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
      if (ccVars.OsnapCatchPoint.Type == osnapType.Center)
        this.method_10(new System.Drawing.Point((int) screen1.X, (int) screen1.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
      if (ccVars.OsnapCatchPoint.Type == osnapType.Outer)
        this.method_14(new System.Drawing.Point((int) screen1.X, (int) screen1.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
      if (ccVars.OsnapCatchPoint.Type == osnapType.Intersection)
        this.method_8(new System.Drawing.Point((int) screen1.X, (int) screen1.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
      if (ccVars.OsnapCatchPoint.Type == osnapType.Over)
        this.method_8(new System.Drawing.Point((int) screen1.X, (int) screen1.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
      if (ccVars.OsnapCatchPoint.Type != osnapType.Alingment)
        return;
      this.method_11(new System.Drawing.Point((int) screen1.X, (int) screen1.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
      this.method_13(ccVars.OsnapCatchPoint.CatchBasePoints);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_2()
  {
    try
    {
      List<Point3D> pointList = new List<Point3D>();
      double num = (double) this.RenderContext.SetPointSize(clsVar.varView.displayOsnapPoints.Thickness);
      this.RenderContext.SetColorWireframe(clsVar.varView.displayOsnapPoints.Color);
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].OsnapPoints.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].OsnapPoints[index].Enable)
        {
          if (ccVars.Pages[ccVars.PageIndex].OsnapPoints[index].Type == osnapType.Point & clsVar.varMouse.Osnap.OsnapPoint)
          {
            Point3D point3D1 = new Point3D();
            Point3D point3D2 = buVector5.ToPoint3D((Point3D) ccVars.Pages[ccVars.PageIndex].OsnapPoints[index]);
            pointList.Add(point3D2);
          }
          else if (ccVars.Pages[ccVars.PageIndex].OsnapPoints[index].Type == osnapType.Middle & clsVar.varMouse.Osnap.OsnapMiddle)
          {
            Point3D point3D3 = new Point3D();
            Point3D point3D4 = buVector5.ToPoint3D((Point3D) ccVars.Pages[ccVars.PageIndex].OsnapPoints[index]);
            pointList.Add(point3D4);
          }
          else if (ccVars.Pages[ccVars.PageIndex].OsnapPoints[index].Type == osnapType.Center & clsVar.varMouse.Osnap.OsnapCenter)
          {
            Point3D point3D5 = new Point3D();
            Point3D point3D6 = buVector5.ToPoint3D((Point3D) ccVars.Pages[ccVars.PageIndex].OsnapPoints[index]);
            pointList.Add(point3D6);
          }
          else if (ccVars.Pages[ccVars.PageIndex].OsnapPoints[index].Type == osnapType.Outer & clsVar.varMouse.Osnap.OsnapOutside)
          {
            Point3D point3D7 = new Point3D();
            Point3D point3D8 = buVector5.ToPoint3D((Point3D) ccVars.Pages[ccVars.PageIndex].OsnapPoints[index]);
            pointList.Add(point3D8);
          }
          else if (ccVars.Pages[ccVars.PageIndex].OsnapPoints[index].Type == osnapType.Intersection & clsVar.varMouse.Osnap.OsnapIntersection)
          {
            Point3D point3D9 = new Point3D();
            Point3D point3D10 = buVector5.ToPoint3D((Point3D) ccVars.Pages[ccVars.PageIndex].OsnapPoints[index]);
            pointList.Add(point3D10);
          }
          else if (ccVars.Pages[ccVars.PageIndex].OsnapPoints[index].Type == osnapType.ControlPoint & clsVar.varMouse.Osnap.OsnapControlPoints)
          {
            Point3D point3D11 = new Point3D();
            Point3D point3D12 = buVector5.ToPoint3D((Point3D) ccVars.Pages[ccVars.PageIndex].OsnapPoints[index]);
            pointList.Add(point3D12);
          }
        }
      }
      if (pointList == null)
        return;
      this.RenderContext.DrawPoints(this.WorldToScreen((IList<Point3D>) pointList));
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_3()
  {
    try
    {
      List<Point3D> pointList = new List<Point3D>();
      double num = (double) this.RenderContext.SetPointSize(clsVar.varView.displayEntityPoints.Thickness);
      this.RenderContext.SetColorWireframe(clsVar.varView.displayEntityPoints.Color);
      for (int index1 = 0; index1 <= this.Entities.Count - 1; ++index1)
      {
        if (this.Entities[index1] is ICurve & this.Entities[index1].Visible)
        {
          for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index2)
          {
            if (ccVars.Pages[ccVars.PageIndex].Layers[index2].Name == this.Entities[index1].LayerName && ccVars.Pages[ccVars.PageIndex].Layers[index2].Enable)
            {
              if (this.Entities[index1].GetType() == typeof (LinearPath))
              {
                for (int index3 = 0; index3 <= this.Entities[index1].Vertices.Length - 1; ++index3)
                {
                  Point3D point3D1 = new Point3D();
                  Point3D point3D2 = buVector5.ToPoint3D(this.Entities[index1].Vertices[index3]);
                  pointList.Add(point3D2);
                }
              }
              else
              {
                Point3D point3D3 = new Point3D();
                Point3D point3D4 = buVector5.ToPoint3D(((ICurve) this.Entities[index1]).StartPoint);
                pointList.Add(point3D4);
                point3D3 = new Point3D();
                Point3D point3D5 = buVector5.ToPoint3D(((ICurve) this.Entities[index1]).EndPoint);
                pointList.Add(point3D5);
                if (this.Entities[index1] is CompositeCurve)
                {
                  for (int index4 = 0; index4 <= ((CompositeCurve) this.Entities[index1]).CurveList.Count - 1; ++index4)
                  {
                    Point3D point3D6 = buVector5.ToPoint3D(((CompositeCurve) this.Entities[index1]).CurveList[index4].StartPoint);
                    pointList.Add(point3D6);
                    point3D3 = new Point3D();
                    Point3D point3D7 = buVector5.ToPoint3D(((CompositeCurve) this.Entities[index1]).CurveList[index4].EndPoint);
                    pointList.Add(point3D7);
                  }
                }
              }
              index2 = ccVars.Pages[ccVars.PageIndex].Layers.Count;
            }
          }
        }
      }
      if (pointList == null)
        return;
      this.RenderContext.DrawPoints(this.WorldToScreen((IList<Point3D>) pointList));
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public bool FindClosestPointForOsnap(List<OsnapPoint> snapPoints, ref OsnapPoint foundPoint)
  {
    try
    {
      double num1 = double.MaxValue;
      int num2 = 0;
      int index1 = -1;
      foundPoint.Type = osnapType.None;
      if (clsVar.varMouse.Osnap.OsnapEntities)
      {
        using (IEnumerator<Entity> enumerator = this.Entities.GetEnumerator())
        {
label_12:
          Entity current;
          do
          {
            do
            {
              do
              {
                if (enumerator.MoveNext())
                {
                  current = enumerator.Current;
                  if (current is ICurve)
                    goto label_5;
                }
                else
                  goto label_20;
              }
              while (!(current is Brep) || !clsVar.varMouse.Osnap.OsnapBrep);
              goto label_8;
label_5:;
            }
            while (!this.Layers[current.LayerName].Visible);
            clsInit.cVector5.EntityICurveOsnapPoints(current, (Design) this, clsVar.varDisplay.OsnapSize, clsVar.varMouse.Osnap.OsnapOnlyStartEndPoint, ViewportCC.mouseLocation, ref foundPoint);
          }
          while (foundPoint.Type == osnapType.None);
          goto label_13;
label_8:
          Brep brep = current as Brep;
          int index2 = 0;
          while (true)
          {
            if (index2 <= brep.Edges.Length - 1)
            {
              Entity copiedEntity = (Entity) null;
              buEntity.Copy((Entity) brep.Edges[index2].Curve, ref copiedEntity);
              clsInit.cVector5.EntityICurveOsnapPoints(copiedEntity, (Design) this, clsVar.varDisplay.OsnapSize, clsVar.varMouse.Osnap.OsnapOnlyStartEndPoint, ViewportCC.mouseLocation, ref foundPoint);
              if (foundPoint.Type == osnapType.None)
                ++index2;
              else
                goto label_17;
            }
            else
              goto label_12;
          }
label_13:
          return true;
        }
label_17:
        return foundPoint.Type != osnapType.None;
      }
label_20:
      foreach (OsnapPoint snapPoint in snapPoints)
      {
        if ((Point3D) snapPoint != (Point3D) null)
        {
          double num3 = Point2D.Distance((Point2D) this.WorldToScreen((Point3D) snapPoint), new Point2D((double) ViewportCC.mouseLocation.X, (double) (this.Height - ViewportCC.mouseLocation.Y)));
          if (num3 < num1 & num3 <= clsVar.varDisplay.OsnapSize)
          {
            index1 = num2;
            num1 = num3;
          }
          ++num2;
        }
      }
      if (!(index1 >= 0 & index1 <= snapPoints.Count - 1))
        return false;
      foundPoint = snapPoints[index1];
      return true;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private void method_4(
    System.Drawing.Point point_1,
    System.Drawing.Point point_2,
    Color color_0,
    int int_0,
    bool bool_0,
    bool bool_1)
  {
    point_1.Y = this.Height - point_1.Y;
    point_2.Y = this.Height - point_2.Y;
    Class5.smethod_9(ref point_2, ref point_1);
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
    this.RenderContext.SetColorWireframe(Color.FromArgb(int_0, (int) color_0.R, (int) color_0.G, (int) color_0.B));
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

  private void method_5(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
  {
    try
    {
      double x1 = (double) point_1.X + double_0 / 2.0;
      double y1 = (double) point_1.Y + double_0 / 2.0;
      double x2 = (double) point_1.X - double_0 / 2.0;
      double y2 = (double) point_1.Y - double_0 / 2.0;
      Point3D point3D1 = new Point3D(x2, y1);
      Point3D point3D2 = new Point3D(x1, y1);
      Point3D point3D3 = new Point3D(x1, y2);
      Point3D point3D4 = new Point3D(x2, y2);
      double num = (double) this.RenderContext.SetLineSize(float_0);
      this.RenderContext.SetColorWireframe(color_0);
      this.RenderContext.DrawLineLoop(new Point3D[4]
      {
        point3D4,
        point3D3,
        point3D2,
        point3D1
      });
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_6(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
  {
    try
    {
      double x1 = (double) point_1.X + double_0 / 2.0;
      double y1 = (double) point_1.Y + double_0 / 2.0;
      double x2 = (double) point_1.X - double_0 / 2.0;
      double y2 = (double) point_1.Y - double_0 / 2.0;
      Point3D point3D1 = new Point3D((double) point_1.X, y1);
      Point3D point3D2 = new Point3D(x1, y2);
      Point3D point3D3 = new Point3D(x2, y2);
      double num = (double) this.RenderContext.SetLineSize(float_0);
      this.RenderContext.SetColorWireframe(color_0);
      this.RenderContext.DrawLineLoop(new Point3D[3]
      {
        point3D3,
        point3D2,
        point3D1
      });
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_7(Point3D point3D_0, double double_0, Color color_0, float float_0)
  {
    try
    {
      double x1 = this.WorldToScreen(point3D_0.X, point3D_0.Y, point3D_0.Z).X + double_0 / 2.0;
      double y1 = this.WorldToScreen(point3D_0.X, point3D_0.Y, point3D_0.Z).Y + double_0 / 2.0;
      double x2 = this.WorldToScreen(point3D_0.X, point3D_0.Y, point3D_0.Z).X - double_0 / 2.0;
      double y2 = this.WorldToScreen(point3D_0.X, point3D_0.Y, point3D_0.Z).Y - double_0 / 2.0;
      Point3D point3D1 = new Point3D(x2, y1);
      Point3D point3D2 = new Point3D(x1, y1);
      Point3D point3D3 = new Point3D(x1, y2);
      Point3D point3D4 = new Point3D(x2, y2);
      double num = (double) this.RenderContext.SetLineSize(float_0);
      this.RenderContext.SetColorWireframe(color_0);
      this.RenderContext.DrawLines(new Point3D[4]
      {
        point3D4,
        point3D2,
        point3D1,
        point3D3
      });
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_8(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
  {
    try
    {
      double x1 = (double) point_1.X + double_0 / 2.0;
      double y1 = (double) point_1.Y + double_0 / 2.0;
      double x2 = (double) point_1.X - double_0 / 2.0;
      double y2 = (double) point_1.Y - double_0 / 2.0;
      Point3D point3D1 = new Point3D(x2, y1);
      Point3D point3D2 = new Point3D(x1, y1);
      Point3D point3D3 = new Point3D(x1, y2);
      Point3D point3D4 = new Point3D(x2, y2);
      double num = (double) this.RenderContext.SetLineSize(float_0);
      this.RenderContext.SetColorWireframe(color_0);
      this.RenderContext.DrawLines(new Point3D[4]
      {
        point3D4,
        point3D2,
        point3D1,
        point3D3
      });
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_9(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
  {
    try
    {
      double x1 = (double) point_1.X + double_0 / 2.0;
      double y1 = (double) point_1.Y + double_0 / 2.0;
      double x2 = (double) point_1.X - double_0 / 2.0;
      double y2 = (double) point_1.Y - double_0 / 2.0;
      Point3D point3D1 = new Point3D(x2, (double) point_1.Y);
      Point3D point3D2 = new Point3D(x1, (double) point_1.Y);
      Point3D point3D3 = new Point3D((double) point_1.X, y1);
      Point3D point3D4 = new Point3D((double) point_1.X, y2);
      double num = (double) this.RenderContext.SetLineSize(float_0);
      this.RenderContext.SetColorWireframe(color_0);
      this.RenderContext.DrawLines(new Point3D[4]
      {
        point3D1,
        point3D2,
        point3D3,
        point3D4
      });
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_10(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
  {
    try
    {
      double num1 = double_0 / 2.0;
      List<Point3D> point3DList = new List<Point3D>();
      for (int degrees = 0; degrees < 360; degrees += 10)
      {
        double rad = Utility.DegToRad((double) degrees);
        Point3D point3D = new Point3D((double) point_1.X + num1 * Math.Cos(rad), (double) point_1.Y + num1 * Math.Sin(rad));
        point3DList.Add(point3D);
      }
      int num2 = (int) this.RenderContext.SetState(blendStateType.Blend);
      double num3 = (double) this.RenderContext.SetLineSize(float_0);
      this.RenderContext.SetColorWireframe(color_0);
      int num4 = (int) this.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
      this.RenderContext.DrawLineLoop(point3DList.ToArray());
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_11(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
  {
    try
    {
      double x = (double) point_1.X + double_0 * 1.0;
      double y = (double) point_1.Y + double_0 * 1.0;
      Point3D point3D1 = new Point3D((double) point_1.X, y);
      Point3D point3D2 = new Point3D(x, (double) point_1.Y);
      Point3D point3D3 = new Point3D((double) point_1.X, (double) point_1.Y);
      double num = (double) this.RenderContext.SetLineSize(float_0);
      this.RenderContext.SetColorWireframe(color_0);
      this.RenderContext.DrawLines(new Point3D[4]
      {
        point3D1,
        point3D3,
        point3D3,
        point3D2
      });
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_12(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
  {
    try
    {
      double x = (double) point_1.X - double_0 * 0.5;
      double y = (double) point_1.Y + double_0 * 1.0;
      Point3D point3D1 = new Point3D((double) point_1.X + double_0 * 0.5, (double) point_1.Y);
      Point3D point3D2 = new Point3D(x, (double) point_1.Y);
      Point3D point3D3 = new Point3D((double) point_1.X, (double) point_1.Y);
      Point3D point3D4 = new Point3D((double) point_1.X, y);
      double num = (double) this.RenderContext.SetLineSize(float_0);
      this.RenderContext.SetColorWireframe(color_0);
      this.RenderContext.DrawLines(new Point3D[4]
      {
        point3D1,
        point3D2,
        point3D3,
        point3D4
      });
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_13(List<Point3D> list_0)
  {
    try
    {
      if (list_0.Count <= 0)
        return;
      double num = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayHighLight.Thickness + 2f);
      this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayHighLight.Color);
      this.RenderContext.DrawLines(this.WorldToScreen((IList<Point3D>) list_0));
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_14(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
  {
    try
    {
      double x1 = (double) point_1.X + double_0 / 1.5;
      double y1 = (double) point_1.Y + double_0 / 1.5;
      double x2 = (double) point_1.X - double_0 / 1.5;
      double y2 = (double) point_1.Y - double_0 / 1.5;
      Point3D point3D1 = new Point3D((double) point_1.X, y1);
      Point3D point3D2 = new Point3D((double) point_1.X, y2);
      Point3D point3D3 = new Point3D(x1, (double) point_1.Y);
      Point3D point3D4 = new Point3D(x2, (double) point_1.Y);
      double num = (double) this.RenderContext.SetLineSize(float_0);
      this.RenderContext.SetColorWireframe(color_0);
      this.RenderContext.DrawLineLoop(new Point3D[4]
      {
        point3D2,
        point3D3,
        point3D1,
        point3D4
      });
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_15(
    Point3D point3D_0,
    Point3D point3D_1,
    double double_0,
    double double_1,
    double double_2)
  {
    geoTriangle geoTriangle1 = new geoTriangle();
    geoTriangle geoTriangle2 = new geoTriangle();
    double ArrowHeadLenght = double_0;
    List<Pnt3D> pnt3DList1 = new List<Pnt3D>();
    List<Pnt3D> pnt3DList2 = new List<Pnt3D>();
    List<Point3D> calcPoints = new List<Point3D>();
    clsInit.cVector5.DrawWireArrowHead(point3D_1, point3D_0, ArrowHeadLenght, double_2, true, ccVars.planeActive, ref calcPoints);
    int num1 = (int) this.RenderContext.SetState(blendStateType.Blend);
    double num2 = (double) this.RenderContext.SetLineSize(2f);
    this.RenderContext.SetColorWireframe(Color.Red);
    int num3 = (int) this.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
    Point3D[] vertices = new Point3D[calcPoints.Count];
    for (int index = 0; index <= calcPoints.Count - 1; ++index)
    {
      vertices[index] = new Point3D();
      vertices[index] = this.WorldToScreen(calcPoints[index].X, calcPoints[index].Y, calcPoints[index].Z);
    }
    this.RenderContext.DrawLineStrip(vertices);
    int num4 = (int) this.RenderContext.SetState(blendStateType.NoBlend);
  }

  private void method_16(
    Point3D point3D_0,
    Point3D point3D_1,
    double double_0,
    Color color_0,
    float float_0)
  {
    int num1 = (int) this.RenderContext.SetState(blendStateType.Blend);
    double num2 = (double) this.RenderContext.SetLineSize(float_0);
    this.RenderContext.SetColorWireframe(color_0);
    int num3 = (int) this.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
    if (ccVars.pntDrawDynamicArr != null && ccVars.pntDrawDynamicArr.Length != 0)
    {
      for (int index = 1; index <= ccVars.pntDrawDynamicArr.Length - 1; ++index)
      {
        Point3D point3D1 = buVector5.ToPoint3D(ccVars.pntDrawDynamicArr[index - 1]);
        Point3D point3D2 = buVector5.ToPoint3D(ccVars.pntDrawDynamicArr[index]);
        List<Point3D> calcPoints = new List<Point3D>();
        clsInit.cVector5.DrawLineAsRectangle(point3D1, point3D2, double_0, ccVars.planeActive, ref calcPoints);
        Point3D[] vertices1 = new Point3D[5]
        {
          this.WorldToScreen(calcPoints[0].X, calcPoints[0].Y, calcPoints[0].Z),
          this.WorldToScreen(calcPoints[1].X, calcPoints[1].Y, calcPoints[1].Z),
          this.WorldToScreen(calcPoints[2].X, calcPoints[2].Y, calcPoints[2].Z),
          this.WorldToScreen(calcPoints[3].X, calcPoints[3].Y, calcPoints[3].Z),
          this.WorldToScreen(calcPoints[4].X, calcPoints[4].Y, calcPoints[4].Z)
        };
        Point3D[] vertices2 = new Point3D[3];
        Point3D[] vertices3 = new Point3D[3];
        vertices2[0] = this.WorldToScreen(calcPoints[0].X, calcPoints[0].Y, calcPoints[0].Z);
        vertices2[1] = this.WorldToScreen(calcPoints[1].X, calcPoints[1].Y, calcPoints[1].Z);
        vertices2[2] = this.WorldToScreen(calcPoints[2].X, calcPoints[2].Y, calcPoints[2].Z);
        vertices3[0] = this.WorldToScreen(calcPoints[2].X, calcPoints[2].Y, calcPoints[2].Z);
        vertices3[1] = this.WorldToScreen(calcPoints[3].X, calcPoints[3].Y, calcPoints[3].Z);
        vertices3[2] = this.WorldToScreen(calcPoints[0].X, calcPoints[0].Y, calcPoints[0].Z);
        this.RenderContext.DrawTriangles(vertices2, new Vector3D(0.0, 0.0, 1.0));
        this.RenderContext.DrawTriangles(vertices3, new Vector3D(0.0, 0.0, 1.0));
        this.RenderContext.DrawLineStrip(vertices1);
      }
    }
    int num4 = (int) this.RenderContext.SetState(blendStateType.NoBlend);
  }

  public void DrawPointer()
  {
    Point2D screen = (Point2D) this.WorldToScreen(ccVars.pntActive);
    this.method_9(new System.Drawing.Point((int) screen.X, (int) screen.Y), clsVar.varDisplay.PointerSize, clsVar.varDisplay.displayPointer.Color, clsVar.varDisplay.displayPointer.Thickness);
  }

  private void method_17()
  {
    if (ccVars.pntMark.Count <= 0)
      return;
    for (int index = 0; index <= ccVars.pntMark.Count - 1; ++index)
    {
      Point2D screen = (Point2D) this.WorldToScreen((Point3D) ccVars.pntMark[index]);
      Color color_0 = Color.FromArgb((int) ccVars.pntMark[index].R, (int) ccVars.pntMark[index].G, (int) ccVars.pntMark[index].B);
      this.method_5(new System.Drawing.Point((int) screen.X, (int) screen.Y), 8.0, color_0, (float) clsVar.varView.DrawMarkThickness);
    }
  }

  private void method_18()
  {
    if (buVector5.AskMe.FoundEntities.Count > 0)
    {
      double num1 = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayAskMeEntities.Thickness);
      this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayAskMeEntities.Color);
      for (int index = 0; index <= buVector5.AskMe.FoundEntities.Count - 1; ++index)
      {
        if (buVector5.AskMe.FoundEntities[index].Vertices != null)
          this.RenderContext.DrawLines(this.WorldToScreen((IList<Point3D>) buVector5.AskMe.FoundEntities[index].Vertices));
      }
      if (buVector5.AskMe.SelectedIndex >= 0 & buVector5.AskMe.SelectedIndex <= buVector5.AskMe.FoundEntities.Count - 1)
      {
        double num2 = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayAskMeEntitiesSelected.Thickness);
        this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayAskMeEntitiesSelected.Color);
        if (buVector5.AskMe.FoundEntities[buVector5.AskMe.SelectedIndex].Vertices != null)
        {
          this.RenderContext.DrawLines(this.WorldToScreen((IList<Point3D>) buVector5.AskMe.FoundEntities[buVector5.AskMe.SelectedIndex].Vertices));
          if (buVector5.AskMe.FoundEntities[buVector5.AskMe.SelectedIndex] is ICurve)
          {
            Point3D OtherPoint = new Point3D();
            clsInit.cVector5.GetOtherPointOfEntity(buVector5.AskMe.CatchPoint, buVector5.AskMe.FoundEntities[buVector5.AskMe.SelectedIndex], ref OtherPoint);
            ICurve foundEntity = buVector5.AskMe.FoundEntities[buVector5.AskMe.SelectedIndex] as ICurve;
            this.method_15(buVector5.AskMe.CatchPoint, OtherPoint, 20.0, 10.0, 15.0);
          }
        }
      }
    }
    if (ccVars.SortedEntities.Count > 0)
    {
      double num3 = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedEntities.Thickness);
      this.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedEntities.Color);
      for (int index = 0; index <= ccVars.SortedEntities.Count - 1; ++index)
      {
        if (ccVars.SortedEntities[index].GetType() == typeof (buUpperLineEnt))
        {
          double num4 = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedUpperEntities.Thickness);
          this.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedUpperEntities.Color);
        }
        else
        {
          double num5 = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedEntities.Thickness);
          this.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedEntities.Color);
        }
        if (ccVars.SortedEntities[index].Vertices != null)
          this.RenderContext.DrawLines(this.WorldToScreen((IList<Point3D>) ccVars.SortedEntities[index].Vertices));
      }
    }
    if (buVector5.AskMe.SortedEntities.Count > 0)
    {
      double num = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedEntities.Thickness);
      this.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedEntities.Color);
      for (int index = 0; index <= buVector5.AskMe.SortedEntities.Count - 1; ++index)
      {
        if (buVector5.AskMe.SortedEntities[index].Vertices != null)
          this.RenderContext.DrawLines(this.WorldToScreen((IList<Point3D>) buVector5.AskMe.SortedEntities[index].Vertices));
      }
    }
    if (buVector5.AskMe.LastMarkPosition.Count <= 0)
      return;
    for (int index = buVector5.AskMe.LastMarkPosition.Count - 1; index <= buVector5.AskMe.LastMarkPosition.Count - 1; ++index)
      this.method_7(buVector5.AskMe.LastMarkPosition[index], clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displaySortedUpperEntities.Color, clsVar.varDisplay.displaySortedUpperEntities.Thickness);
  }

  private void method_19()
  {
    if (buVector5.AskMeBu.FoundEntities.Count > 0)
    {
      double num1 = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayAskMeEntities.Thickness);
      this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayAskMeEntities.Color);
      for (int index = 0; index <= buVector5.AskMeBu.FoundEntities.Count - 1; ++index)
      {
        if (buVector5.AskMeBu.FoundEntities[index].Vertices != null)
          this.RenderContext.DrawLines(this.WorldToScreen((IList<Point3D>) buVector5.AskMeBu.FoundEntities[index].Vertices));
      }
      if (buVector5.AskMeBu.SelectedIndex >= 0 & buVector5.AskMeBu.SelectedIndex <= buVector5.AskMeBu.FoundEntities.Count - 1)
      {
        double num2 = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayAskMeEntitiesSelected.Thickness);
        this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayAskMeEntitiesSelected.Color);
        if (buVector5.AskMeBu.FoundEntities[buVector5.AskMeBu.SelectedIndex].Vertices != null)
        {
          this.RenderContext.DrawLines(this.WorldToScreen((IList<Point3D>) buVector5.AskMeBu.FoundEntities[buVector5.AskMeBu.SelectedIndex].Vertices));
          Point3D OtherPoint = new Point3D();
          clsInit.cVector5.GetOtherPointOfEntity(buVector5.AskMeBu.CatchPoint, buVector5.AskMeBu.FoundEntities[buVector5.AskMeBu.SelectedIndex], ref OtherPoint);
          ICurve foundEntity = buVector5.AskMeBu.FoundEntities[buVector5.AskMeBu.SelectedIndex] as ICurve;
          this.method_15(buVector5.AskMeBu.CatchPoint, OtherPoint, 20.0, 10.0, 15.0);
        }
      }
    }
    if (ccVars.SortedEntities.Count > 0)
    {
      double num3 = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedEntities.Thickness);
      this.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedEntities.Color);
      for (int index = 0; index <= ccVars.SortedEntities.Count - 1; ++index)
      {
        if (ccVars.SortedEntities[index].GetType() == typeof (buUpperLineEnt))
        {
          double num4 = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedUpperEntities.Thickness);
          this.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedUpperEntities.Color);
        }
        else
        {
          double num5 = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedEntities.Thickness);
          this.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedEntities.Color);
        }
        if (ccVars.SortedEntities[index].Vertices != null)
          this.RenderContext.DrawLines(this.WorldToScreen((IList<Point3D>) ccVars.SortedEntities[index].Vertices));
      }
    }
    if (buVector5.AskMeBu.SortedEntities.Count > 0)
    {
      double num = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedEntities.Thickness);
      this.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedEntities.Color);
      for (int index = 0; index <= buVector5.AskMeBu.SortedEntities.Count - 1; ++index)
      {
        if (buVector5.AskMeBu.SortedEntities[index].Vertices != null)
          this.RenderContext.DrawLines(this.WorldToScreen((IList<Point3D>) buVector5.AskMeBu.SortedEntities[index].Vertices));
      }
    }
    if (buVector5.AskMeBu.LastMarkPosition.Count <= 0)
      return;
    for (int index = buVector5.AskMeBu.LastMarkPosition.Count - 1; index <= buVector5.AskMeBu.LastMarkPosition.Count - 1; ++index)
      this.method_7(buVector5.AskMeBu.LastMarkPosition[index], clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displaySortedUpperEntities.Color, clsVar.varDisplay.displaySortedUpperEntities.Thickness);
  }

  private void method_20()
  {
    double num = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
    this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
    for (int index = 0; index < ViewportCC.FreeDrawStrokes.Count - 1; ++index)
      this.RenderContext.DrawLine(this.WorldToScreen(ViewportCC.FreeDrawStrokes[index]), this.WorldToScreen(ViewportCC.FreeDrawStrokes[index + 1]));
    for (int index1 = 0; index1 <= ViewportCC.FreeDrawStrokeList.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 < ViewportCC.FreeDrawStrokeList[index1].Count - 1; ++index2)
        this.RenderContext.DrawLine(this.WorldToScreen(ViewportCC.FreeDrawStrokeList[index1][index2]), this.WorldToScreen(ViewportCC.FreeDrawStrokeList[index1][index2 + 1]));
    }
  }

  private void method_21()
  {
    try
    {
      if (ccVars.HighLightPoints.Count <= 0)
        return;
      for (int index1 = 0; index1 <= ccVars.HighLightPoints.Count - 1; ++index1)
      {
        double num1 = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayHighLight.Thickness + 2f);
        this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayHighLight.Color);
        Point3D[] array = ccVars.HighLightPoints[index1].PointsList.ToArray();
        if (ccVars.HighLightPoints[index1].TriangleIndexList.Count == 0)
        {
          this.RenderContext.DrawLineStrip(this.WorldToScreen((IList<Point3D>) array));
        }
        else
        {
          int num2 = (int) this.RenderContext.SetState(blendStateType.Blend);
          this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayHighLight.Color);
          Vector3D[] vector3DArray = new Vector3D[ccVars.HighLightPoints[index1].Normals.Count];
          Point3D[] pointList = new Point3D[ccVars.HighLightPoints[index1].TriangleIndexList.Count * 3];
          for (int index2 = 0; index2 <= ccVars.HighLightPoints[index1].TriangleIndexList.Count - 1; ++index2)
          {
            Point3D point3D1 = array[ccVars.HighLightPoints[index1].TriangleIndexList[index2].V1];
            Point3D point3D2 = array[ccVars.HighLightPoints[index1].TriangleIndexList[index2].V2];
            Point3D point3D3 = array[ccVars.HighLightPoints[index1].TriangleIndexList[index2].V3];
            pointList[index2 * 3] = new Point3D(point3D1.X, point3D1.Y, point3D1.Z);
            pointList[index2 * 3 + 1] = new Point3D(point3D2.X, point3D2.Y, point3D2.Z);
            pointList[index2 * 3 + 2] = new Point3D(point3D3.X, point3D3.Y, point3D3.Z);
          }
          for (int index3 = 0; index3 <= ccVars.HighLightPoints[index1].Normals.Count - 1; ++index3)
            vector3DArray[index3] = new Vector3D(ccVars.HighLightPoints[index1].Normals[index3].X, ccVars.HighLightPoints[index1].Normals[index3].Y, ccVars.HighLightPoints[index1].Normals[index3].Z);
          if (pointList.Length != 0)
            this.RenderContext.DrawTriangles(this.WorldToScreen((IList<Point3D>) pointList), Vector3D.AxisZ);
          int num3 = (int) this.RenderContext.SetState(blendStateType.NoBlend);
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public void DrawCurrentLine(Point3D pntPrevious, Point3D pntCurrent)
  {
    double num = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
    this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
    this.RenderContext.DrawLine(this.WorldToScreen(pntPrevious), this.WorldToScreen(pntCurrent));
    if (ccVars.enableViewPortCurrentLineArrow)
      ;
  }

  public void DrawDynamicPointCompositeCurve(Point3D pointLast)
  {
    Point4D point4D1 = (Point4D) null;
    if (ccVars.pntDynamicCompositeCurve.Count > 0)
      point4D1 = ccVars.pntDynamicCompositeCurve[ccVars.pntDynamicCompositeCurve.Count - 1];
    List<Point3D> pointList = new List<Point3D>();
    for (int index = 0; index <= ccVars.pntDynamicCompositeCurve.Count - 1; ++index)
    {
      Point4D EndPoint1 = ccVars.pntDynamicCompositeCurve[index];
      if (EndPoint1.W == 0.0)
        pointList.Add(new Point3D(EndPoint1.X, EndPoint1.Y, EndPoint1.Z));
      if (EndPoint1.W == 2.0)
      {
        Point4D EndPoint2 = ccVars.pntDynamicCompositeCurve[index - 2];
        Point4D StartPoint = ccVars.pntDynamicCompositeCurve[index - 1];
        List<Point3D> Vertices = new List<Point3D>();
        if (clsInit.cVector5.Length3D((Point3D) StartPoint, (Point3D) EndPoint2) > 0.5 & clsInit.cVector5.Length3D((Point3D) StartPoint, (Point3D) EndPoint1) > 0.5)
        {
          clsInit.cVector5.Arc3Point(new Point3D(EndPoint2.X, EndPoint2.Y, EndPoint2.Z), new Point3D(StartPoint.X, StartPoint.Y, StartPoint.Z), new Point3D(EndPoint1.X, EndPoint1.Y, EndPoint1.Z), ccVars.planeActive, new EntityResolution(0.5, 10, 20.0, EntityResolutionType.ByLnRadius, 25), ref Vertices);
          if (Vertices.Count >= 3)
          {
            Vertices.RemoveAt(0);
            pointList.AddRange((IEnumerable<Point3D>) Vertices);
          }
        }
      }
    }
    if (point4D1 != (Point4D) null)
    {
      if (point4D1.W == 0.0 | point4D1.W == 2.0)
        pointList.Add(new Point3D(pointLast.X, pointLast.Y, pointLast.Z));
      if (point4D1.W == 1.0)
      {
        Point4D StartPoint = ccVars.pntDynamicCompositeCurve[ccVars.pntDynamicCompositeCurve.Count - 2];
        List<Point3D> Vertices = new List<Point3D>();
        if (clsInit.cVector5.Length3D((Point3D) StartPoint, (Point3D) point4D1) > 0.5 & clsInit.cVector5.Length3D((Point3D) point4D1, pointLast) > 0.5)
        {
          clsInit.cVector5.Arc3Point(new Point3D(StartPoint.X, StartPoint.Y, StartPoint.Z), new Point3D(point4D1.X, point4D1.Y, point4D1.Z), pointLast, ccVars.planeActive, new EntityResolution(0.5, 10, 20.0, EntityResolutionType.ByLnRadius, 25), ref Vertices);
          if (Vertices.Count >= 3)
          {
            if (!buCompare5.EQ(Vertices[0], (Point3D) StartPoint))
              Vertices.Reverse();
            Vertices.RemoveAt(0);
            pointList.AddRange((IEnumerable<Point3D>) Vertices);
          }
        }
      }
    }
    double num = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
    this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
    this.RenderContext.DrawLineStrip(this.WorldToScreen((IList<Point3D>) pointList));
    if (ccVars.pntDynamicCompositeCurve.Count <= 0 || ccVars.pntDynamicCompositeCurve[ccVars.pntDynamicCompositeCurve.Count - 1].W != 1.0)
      return;
    Point4D point4D2 = ccVars.pntDynamicCompositeCurve[ccVars.pntDynamicCompositeCurve.Count - 1];
    this.method_7(new Point3D(point4D2.X, point4D2.Y, point4D2.Z), clsVar.varDisplay.OsnapSize, Color.Lime, 4f);
  }

  public void DrawDynamicPointArr()
  {
    if (ccVars.pntDrawDynamicArr == null || ccVars.pntDrawDynamicArr.Length == 0)
      return;
    double num = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
    this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
    this.RenderContext.DrawLineStrip(this.WorldToScreen((IList<Point3D>) ccVars.pntDrawDynamicArr));
  }

  public void DrawDynamicPointLineArr()
  {
    if (ccVars.pntDrawDynamicLinesArr == null)
      return;
    for (int index = 0; index <= ccVars.pntDrawDynamicLinesArr.Count - 1; ++index)
    {
      if (ccVars.pntDrawDynamicLinesArr[index].Count > 1)
      {
        double num = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
        this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
        this.RenderContext.DrawLineStrip(this.WorldToScreen((IList<Point3D>) ccVars.pntDrawDynamicLinesArr[index]));
      }
      else if (ccVars.pntDrawDynamicLinesArr[index].Count == 1)
      {
        double num = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness + 2f);
        this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
        this.RenderContext.DrawPoints(this.WorldToScreen((IList<Point3D>) ccVars.pntDrawDynamicLinesArr[index]));
      }
    }
  }

  public void DrawDynamicPointLineArrColor()
  {
    if (ccVars.pntDrawDynamicLinesArrColored == null)
      return;
    for (int index1 = 0; index1 <= ccVars.pntDrawDynamicLinesArrColored.Count - 1; ++index1)
    {
      for (int index2 = 1; index2 <= ccVars.pntDrawDynamicLinesArrColored[index1].Count - 1; ++index2)
      {
        double num = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
        this.RenderContext.SetColorWireframe(Color.FromArgb((int) ccVars.pntDrawDynamicLinesArrColored[index1][index2 - 1].R, (int) ccVars.pntDrawDynamicLinesArrColored[index1][index2 - 1].G, (int) ccVars.pntDrawDynamicLinesArrColored[index1][index2 - 1].B));
        this.RenderContext.DrawLine(this.WorldToScreen((Point3D) ccVars.pntDrawDynamicLinesArrColored[index1][index2 - 1]), this.WorldToScreen((Point3D) ccVars.pntDrawDynamicLinesArrColored[index1][index2]));
      }
    }
  }

  public void DrawDynamicMeasure()
  {
    if (ccVars.pntDrawDynamicMeasure == null)
      return;
    for (int index = 0; index <= ccVars.pntDrawDynamicMeasure.Count - 1; ++index)
    {
      if (ccVars.pntDrawDynamicMeasure[index].Points.Count > 0)
      {
        double num = (double) this.RenderContext.SetLineSize(ccVars.pntDrawDynamicMeasure[index].Size);
        this.RenderContext.SetColorWireframe(ccVars.pntDrawDynamicMeasure[index].Color);
        this.RenderContext.DrawLineStrip(this.WorldToScreen((IList<Point3D>) ccVars.pntDrawDynamicMeasure[index].Points));
        string text = ccVars.pntDrawDynamicMeasure[index].Text;
        if (!buCompare.EQ(ccVars.pntDrawDynamicMeasure[index].Length, 0.0, 0.001))
          text += ccVars.pntDrawDynamicMeasure[index].Length.ToString("f3");
        this.method_25(ccVars.pntDrawDynamicMeasure[index].PntText, text);
      }
    }
  }

  public void DrawDynamicPointList()
  {
    if (ccVars.pntDrawDynamicLines == null || ccVars.pntDrawDynamicLines.Count <= 0 || !(ccVars.pntDrawDynamicLines[0] != (Point3D) null))
      return;
    double num = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
    this.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
    this.RenderContext.DrawLineStrip(this.WorldToScreen((IList<Point3D>) ccVars.pntDrawDynamicLines));
  }

  private void method_22()
  {
    try
    {
      if (!(ccVars.SelectionOP.Selections.Count > 0 & clsVar.varDisplay.ShowSelectedEntitiesPoint))
        return;
      if (clsVar.varDisplay.ShowSelectedEntitiesMovePoint)
      {
        for (int index1 = 0; index1 <= ccVars.SelectionOP.Selections.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= ccVars.SelectionOP.Selections[index1].AlingPoints.MovePoints.Count - 1; ++index2)
          {
            Point2D screen = (Point2D) this.WorldToScreen(ccVars.SelectionOP.Selections[index1].AlingPoints.MovePoints[index2]);
            this.method_5(new System.Drawing.Point((int) screen.X, (int) screen.Y), clsVar.varSelection.SelectionBoxSize, clsVar.varSelection.displaySelectionBoxMove.Color, clsVar.varSelection.displaySelectionBoxMove.Thickness);
          }
        }
      }
      if (!clsVar.varDisplay.ShowSelectedEntitiesTipPoint)
        return;
      for (int index3 = 0; index3 <= ccVars.SelectionOP.Selections.Count - 1; ++index3)
      {
        for (int index4 = 0; index4 <= ccVars.SelectionOP.Selections[index3].AlingPoints.TipPoints.Count - 1; ++index4)
        {
          Point2D screen = (Point2D) this.WorldToScreen(ccVars.SelectionOP.Selections[index3].AlingPoints.TipPoints[index4]);
          this.method_5(new System.Drawing.Point((int) screen.X, (int) screen.Y), clsVar.varSelection.SelectionBoxSize, clsVar.varSelection.displaySelectionBox.Color, clsVar.varSelection.displaySelectionBox.Thickness);
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_23(Point3D point3D_0, string string_0, string string_1)
  {
    try
    {
      string str1 = string_0;
      string str2 = string_1;
      if (str2.Length > 0)
        str2 = Environment.NewLine + string_1;
      string str3 = "";
      if (clsVar.varView.ShowDynamicTextCommand)
        str3 = str1 + " - ";
      if (!clsVar.varView.ShowDynamicTextInfo)
        str2 = "";
      this.DrawText(ViewportCC.mouseLocation.X, this.Height - ViewportCC.mouseLocation.Y + 10, str3 + str2, new Font("Arial", (float) clsVar.varView.DynamicTextSize), clsVar.varView.colorDynamicText, ContentAlignment.BottomLeft);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_24(int int_0, int int_1, string string_0)
  {
    try
    {
      if (string_0.Length <= 0)
        return;
      this.DrawText(int_0, this.Height - int_1 + 10, string_0, new Font("Arial", (float) clsVar.varView.DynamicTextSize), clsVar.varView.colorDynamicText, ContentAlignment.MiddleCenter);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_25(Point3D point3D_0, string string_0)
  {
    try
    {
      if (string_0.Length <= 0)
        return;
      this.DrawText((int) this.WorldToScreen(point3D_0).X, (int) this.WorldToScreen(point3D_0).Y + 10, string_0, new Font("Arial", (float) clsVar.varView.DynamicTextSize), clsVar.varView.colorDynamicText, clsVar.varView.DynamicTextAlignment);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_26(Point3D point3D_0)
  {
    try
    {
      double num = (double) this.RenderContext.SetLineSize(clsVar.varView.displayDynamicBigCrossDisplay.Thickness);
      this.RenderContext.SetColorWireframe(clsVar.varView.displayDynamicBigCrossDisplay.Color);
      this.RenderContext.DrawLine(this.WorldToScreen(this.pntLowerLeft.X, point3D_0.Y, point3D_0.Z), this.WorldToScreen(this.pntLowerRight.X, point3D_0.Y, point3D_0.Z));
      this.RenderContext.DrawLine(this.WorldToScreen(point3D_0.X, this.pntLowerLeft.Y, point3D_0.Z), this.WorldToScreen(point3D_0.X, this.pntUpperLeft.Y, point3D_0.Z));
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_27(Point3D point3D_0, float float_0, Color color_0, double double_0 = 20.0)
  {
    try
    {
      double num = (double) this.RenderContext.SetLineSize(float_0);
      this.RenderContext.SetColorWireframe(color_0);
      Point3D screen = this.WorldToScreen(point3D_0);
      this.WorldToScreen(point3D_0.X - 1.0, point3D_0.Y, point3D_0.Z);
      Vector3D vector3D1 = new Vector3D(1.0, 0.0, 0.0);
      this.RenderContext.DrawLine((Point2D) (screen + vector3D1 * double_0), (Point2D) (screen - vector3D1 * double_0));
      this.WorldToScreen(point3D_0.X, point3D_0.Y, point3D_0.Z);
      Vector3D vector3D2 = new Vector3D(0.0, 1.0, 0.0);
      this.RenderContext.DrawLine(screen + vector3D2 * double_0, screen - vector3D2 * double_0);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  private void method_28()
  {
    double num = (double) this.RenderContext.SetLineSize(clsVar.varDisplay.displaySortArrow.Thickness);
    this.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortArrow.Color);
    if (ccVars.SortArrow.Count <= 0)
      return;
    for (int index = 0; index <= ccVars.SortArrow.Count - 1; ++index)
      this.method_15(buConversion5.Pnt3DToPoint3D(ccVars.SortArrow[index].PrePoint), buConversion5.Pnt3DToPoint3D(ccVars.SortArrow[index].Point), ccVars.SortArrow[index].Length, 10.0, ccVars.SortArrow[index].PointAngle);
  }
}
