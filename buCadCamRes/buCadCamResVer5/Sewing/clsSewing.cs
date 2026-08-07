// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Sewing.clsSewing
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Editor;
using buClass;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Sewing;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Sewing;

public class clsSewing
{
  public static TreeView itemTreeView = (TreeView) null;
  public static SewingSettings varSewingSettings = new SewingSettings();
  public static SewingRuntimeSettings varSewingRunSettings = new SewingRuntimeSettings();
  public static SewingCompanies Company = SewingCompanies.Yesim;
  public static SewingModel Model = SewingModel.YesimModel1;
  public List<SewingMain> UndoList = new List<SewingMain>();
  public SewingMain SewingBase = new SewingMain();
  public System.Windows.Forms.Timer timSim = new System.Windows.Forms.Timer();
  public int simIndex = -1;
  public int selectedEntIndex = -1;
  public int selectedVertexIndex = -1;
  public bool SimPaused = false;
  public SewingSelectedPoint baseSelected = (SewingSelectedPoint) null;
  public List<SewingSelectedPoint> Selected = new List<SewingSelectedPoint>();
  public List<SewingJobItem> SewingTableList = new List<SewingJobItem>();
  public List<SewingCode> definedCodes = new List<SewingCode>();
  public F_SewingMove frmMove = (F_SewingMove) null;
  public F_SewingRotate frmRotate = (F_SewingRotate) null;
  public F_SewingSelectVertex frmSelectVertex = (F_SewingSelectVertex) null;
  public F_SewingFootHeight frmFootHeight = (F_SewingFootHeight) null;
  public F_SewingSpeed frmSpeed = (F_SewingSpeed) null;
  public F_SewingTable frmTable = (F_SewingTable) null;
  public string cmdTree = "";
  public bool CancelApplied = false;
  public Point3D pntCenter = new Point3D();
  public Point3D pntTarget = new Point3D();
  public Pnt9D pntCamCenter = new Pnt9D();
  public List<Point3D> pntList = new List<Point3D>();
  public List<Pnt9D> pntCam = new List<Pnt9D>();
  public int indx = 0;
  public System.Windows.Forms.Timer timm = (System.Windows.Forms.Timer) null;

  public event OkCommandWithThreeDataEventHandler SewingExternalCommand;

  public void Init()
  {
    this.timSim.Tick += new EventHandler(this.Sim_Tick);
    this.timSim.Interval = 20;
    this.OpenSewingFile();
    this.frmTable = new F_SewingTable();
  }

  public void InitSimulation()
  {
  }

  public void circle2()
  {
  }

  public void circle()
  {
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    Circle circle = new Circle(Plane.XY, 80.0);
    this.pntTarget = new Point3D(0.0, -80.0);
    circle.Regen(0.01);
    circle.ColorMethod = colorMethodType.byEntity;
    List<Entity> refEntities = new List<Entity>();
    refEntities.Add((Entity) circle);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) circle);
    Joint joint = new Joint(new Point3D(), 2.0, (byte) 2);
    joint.ColorMethod = colorMethodType.byEntity;
    joint.Color = Color.Lime;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) joint);
    buCircle buCircle = new buCircle(new Point3D(0.0, -80.0), 3.0);
    ccVars.pntDrawDynamicLines = new List<Point3D>();
    ccVars.pntDrawDynamicLines.AddRange((IEnumerable<Point3D>) buCircle.Vertices);
    List<Entity> devideEntities = new List<Entity>();
    List<Point3D> point3DList = new List<Point3D>();
    EntityDevideData Settings = new EntityDevideData();
    Settings.LineLength = 3.0;
    Settings.ArcLength = 3.0;
    Settings.Line = true;
    this.pntList = new List<Point3D>();
    clsInit.cVector5.EntitiesDevideByLengthAsPolyline(refEntities, Settings, ref devideEntities);
    clsInit.cVector5.EntitiesToPointsWithCamDirection(devideEntities, 0.01, ref this.pntList);
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref this.pntList);
    List<Entity> BaseRefEntities = new List<Entity>();
    for (int index = 1; index <= this.pntList.Count - 1; ++index)
    {
      Line line = new Line(new Point3D(this.pntList[index - 1].X, this.pntList[index - 1].Y), this.pntList[index]);
      line.Visible = true;
      line.ColorMethod = colorMethodType.byEntity;
      line.LineWeight = 3f;
      line.LineWeightMethod = colorMethodType.byEntity;
      line.EntityData = (object) new CustomData();
      BaseRefEntities.Add((Entity) line);
    }
    List<Entity> SortedEntities = new List<Entity>();
    clsInit.cVector5.SortEntitiesByRefPoint(this.pntTarget, ref BaseRefEntities, new SortSettings(), ref SortedEntities);
    for (int index = 0; index <= SortedEntities.Count - 1; ++index)
    {
      if (((CustomData) SortedEntities[index].EntityData).sortDirection == entitySortDirection.Normal)
      {
        Line line = new Line(SortedEntities[index].Vertices[0], SortedEntities[index].Vertices[1]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
      else
      {
        Line line = new Line(SortedEntities[index].Vertices[1], SortedEntities[index].Vertices[0]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
    }
    this.pntCamCenter = new Pnt9D(this.pntCenter.X, this.pntCenter.Y, 0.0);
    this.pntCam.Clear();
    this.pntCam.Add(new Pnt9D(this.pntCenter.X, this.pntCenter.Y, 0.0));
    this.indx = 2;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void roundrect()
  {
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    CompositeCurve roundedRectangle = CompositeCurve.CreateRoundedRectangle(Plane.XY, 286.0, 142.0, 40.0, true);
    this.pntTarget = new Point3D(0.0, -71.0);
    roundedRectangle.Regen(0.01);
    roundedRectangle.ColorMethod = colorMethodType.byEntity;
    List<Entity> refEntities = new List<Entity>();
    for (int index = 0; index <= roundedRectangle.CurveList.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buEntity.Copy((Entity) roundedRectangle.CurveList[index], ref copiedEntity);
      refEntities.Add(copiedEntity);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) roundedRectangle);
    Joint joint = new Joint(new Point3D(), 2.0, (byte) 2);
    joint.ColorMethod = colorMethodType.byEntity;
    joint.Color = Color.Lime;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) joint);
    buCircle buCircle = new buCircle(new Point3D(0.0, -71.0), 3.0);
    ccVars.pntDrawDynamicLines = new List<Point3D>();
    ccVars.pntDrawDynamicLines.AddRange((IEnumerable<Point3D>) buCircle.Vertices);
    List<Entity> devideEntities = new List<Entity>();
    List<Point3D> point3DList = new List<Point3D>();
    EntityDevideData Settings = new EntityDevideData();
    Settings.LineLength = 3.0;
    Settings.ArcLength = 3.0;
    Settings.Line = true;
    this.pntList = new List<Point3D>();
    clsInit.cVector5.EntitiesDevideByLengthAsPolyline(refEntities, Settings, ref devideEntities);
    clsInit.cVector5.EntitiesToPointsWithCamDirection(devideEntities, 0.01, ref this.pntList);
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref this.pntList);
    List<Entity> BaseRefEntities = new List<Entity>();
    for (int index = 1; index <= this.pntList.Count - 1; ++index)
    {
      Line line = new Line(new Point3D(this.pntList[index - 1].X, this.pntList[index - 1].Y), this.pntList[index]);
      line.Visible = true;
      line.ColorMethod = colorMethodType.byEntity;
      line.LineWeight = 3f;
      line.LineWeightMethod = colorMethodType.byEntity;
      line.EntityData = (object) new CustomData();
      BaseRefEntities.Add((Entity) line);
    }
    List<Entity> SortedEntities = new List<Entity>();
    clsInit.cVector5.SortEntitiesByRefPoint(this.pntTarget, ref BaseRefEntities, new SortSettings(), ref SortedEntities);
    for (int index = 0; index <= SortedEntities.Count - 1; ++index)
    {
      if (((CustomData) SortedEntities[index].EntityData).sortDirection == entitySortDirection.Normal)
      {
        Line line = new Line(SortedEntities[index].Vertices[0], SortedEntities[index].Vertices[1]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
      else
      {
        Line line = new Line(SortedEntities[index].Vertices[1], SortedEntities[index].Vertices[0]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
    }
    this.indx = 2;
    this.pntCamCenter = new Pnt9D(this.pntCenter.X, this.pntCenter.Y, 0.0);
    this.pntCam.Clear();
    this.pntCam.Add(new Pnt9D(this.pntCenter.X, this.pntCenter.Y, 0.0));
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void slot()
  {
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    CompositeCurve slot = CompositeCurve.CreateSlot(Plane.XY, 100.0, 20.0, true);
    this.pntTarget = new Point3D(-70.0, 0.0);
    slot.Regen(0.01);
    slot.ColorMethod = colorMethodType.byEntity;
    List<Entity> refEntities = new List<Entity>();
    for (int index = 0; index <= slot.CurveList.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buEntity.Copy((Entity) slot.CurveList[index], ref copiedEntity);
      refEntities.Add(copiedEntity);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) slot);
    Joint joint = new Joint(new Point3D(), 2.0, (byte) 2);
    joint.ColorMethod = colorMethodType.byEntity;
    joint.Color = Color.Lime;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) joint);
    buCircle buCircle = new buCircle(new Point3D(-70.0, 0.0), 3.0);
    ccVars.pntDrawDynamicLines = new List<Point3D>();
    ccVars.pntDrawDynamicLines.AddRange((IEnumerable<Point3D>) buCircle.Vertices);
    List<Entity> devideEntities = new List<Entity>();
    List<Point3D> point3DList = new List<Point3D>();
    EntityDevideData Settings = new EntityDevideData();
    Settings.Line = true;
    this.pntList = new List<Point3D>();
    clsInit.cVector5.EntitiesDevideByLengthAsPolyline(refEntities, Settings, ref devideEntities);
    clsInit.cVector5.EntitiesToPointsWithCamDirection(devideEntities, 0.01, ref this.pntList);
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref this.pntList);
    List<Entity> BaseRefEntities = new List<Entity>();
    for (int index = 1; index <= this.pntList.Count - 1; ++index)
    {
      Line line = new Line(new Point3D(this.pntList[index - 1].X, this.pntList[index - 1].Y), this.pntList[index]);
      line.Visible = true;
      line.ColorMethod = colorMethodType.byEntity;
      line.LineWeight = 3f;
      line.LineWeightMethod = colorMethodType.byEntity;
      line.EntityData = (object) new CustomData();
      BaseRefEntities.Add((Entity) line);
    }
    List<Entity> SortedEntities = new List<Entity>();
    clsInit.cVector5.SortEntitiesByRefPoint(this.pntTarget, ref BaseRefEntities, new SortSettings(), ref SortedEntities);
    for (int index = 0; index <= SortedEntities.Count - 1; ++index)
    {
      if (((CustomData) SortedEntities[index].EntityData).sortDirection == entitySortDirection.Normal)
      {
        Line line = new Line(SortedEntities[index].Vertices[0], SortedEntities[index].Vertices[1]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
      else
      {
        Line line = new Line(SortedEntities[index].Vertices[1], SortedEntities[index].Vertices[0]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
    }
    this.pntCamCenter = new Pnt9D(this.pntCenter.X, this.pntCenter.Y, 0.0);
    this.pntCam.Clear();
    this.pntCam.Add(new Pnt9D(this.pntCenter.X, this.pntCenter.Y, 0.0));
    this.indx = 2;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void freedraw()
  {
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
    this.pntTarget = new Point3D();
    List<buEntity> buEntityList = new List<buEntity>();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      buEntity copiedEntity = (buEntity) null;
      buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity);
      buEntityList.Add(copiedEntity);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    Joint joint = new Joint(new Point3D(), 2.0, (byte) 2);
    joint.ColorMethod = colorMethodType.byEntity;
    joint.Color = Color.Lime;
    buCircle buCircle = new buCircle(new Point3D(this.pntTarget.X, this.pntTarget.Y), 4.0);
    ccVars.pntDrawDynamicLines = new List<Point3D>();
    ccVars.pntDrawDynamicLines.AddRange((IEnumerable<Point3D>) buCircle.Vertices);
    List<Entity> entityList = new List<Entity>();
    List<Point3D> point3DList = new List<Point3D>();
    EntityDevideData entityDevideData = new EntityDevideData()
    {
      Line = true,
      LineLength = 4.0,
      Arc = true,
      ArcLength = 4.0
    };
    this.pntList = new List<Point3D>();
    List<buEntity> BaseRefEntities = new List<buEntity>();
    for (int index1 = 0; index1 <= buEntityList.Count - 1; ++index1)
    {
      if (buEntityList[index1] is buLine)
      {
        this.pntList = new List<Point3D>();
        clsInit.cVector5.EntityDevide(buEntityList[index1], 4.0, ref this.pntList);
        for (int index2 = 1; index2 <= this.pntList.Count - 1; ++index2)
        {
          buLine buLine = new buLine(this.pntList[index2 - 1], this.pntList[index2]);
          BaseRefEntities.Add((buEntity) buLine);
        }
      }
      else
      {
        for (int index3 = 1; index3 <= buEntityList[index1].Vertices.Count - 1; ++index3)
        {
          buLine buLine = new buLine(buEntityList[index1].Vertices[index3 - 1], buEntityList[index1].Vertices[index3]);
          BaseRefEntities.Add((buEntity) buLine);
        }
      }
    }
    BaseRefEntities.Reverse();
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref this.pntList);
    List<buEntity> SortedEntities = new List<buEntity>();
    clsInit.cVector5.SortEntitiesByRefPoint(this.pntTarget, ref BaseRefEntities, new SortbuSettings()
    {
      Option = {
        NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup,
        IntersectionRules = SortingIntersectionRulesType.FromDrawing
      }
    }, ref SortedEntities);
    for (int index = 0; index <= SortedEntities.Count - 1; ++index)
    {
      if (SortedEntities[index].sortDirection == entitySortDirection.Normal)
      {
        Line line = new Line(SortedEntities[index].Vertices[0], SortedEntities[index].Vertices[1]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
      else
      {
        Line line = new Line(SortedEntities[index].Vertices[1], SortedEntities[index].Vertices[0]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
    }
    double dx = this.pntTarget.X - ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0].Vertices[0].X;
    double dy = this.pntTarget.Y - ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0].Vertices[0].Y;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Translate(dx, dy);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
    this.indx = 0;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void rotate()
  {
    if (this.indx > ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
      return;
    if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.indx] is Line)
    {
      Line entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.indx] as Line;
      double Degree = 180.0 - clsInit.cVector5.PointAngle(entity.EndPoint, entity.StartPoint);
      double dx = entity.StartPoint.X - entity.EndPoint.X;
      double dy = entity.StartPoint.Y - entity.EndPoint.Y;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Translate(dx, dy);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
      double radian = buConversion5.DegreeToRadian(Degree);
      this.pntCamCenter.X += dx;
      this.pntCamCenter.Y += dy;
      this.pntCamCenter.C += Degree;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Rotate(radian, Vector3D.AxisZ, this.pntTarget);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[1] is Joint)
    {
      Joint entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[1] as Joint;
      this.pntCam.Add(new Pnt9D(entity.Position.X, -entity.Position.Y, 0.0, 0.0, 0.0, this.pntCamCenter.C));
    }
    ++this.indx;
    Thread.Sleep(1);
    Application.DoEvents();
  }

  public void CreateCode()
  {
  }

  public void timtic(object sender, EventArgs e) => this.rotate();

  public void cmdNew()
  {
    this.UndoBuffer();
    this.SewingBase.MainEntityList.Clear();
    this.SewingBase = new SewingMain();
    clsInit.appSewing.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
    this.JobUpdate();
  }

  public void cmdConvertToSewingData(EntityList Entities)
  {
    this.SewingBase = new SewingMain();
    for (int index = 0; index <= Entities.Count - 1; ++index)
    {
      if (Entities[index].GetType() == typeof (Line))
      {
        buEntity buEntity = buEntity.Copy(Entities[index]);
        if (buEntity != null)
        {
          buEntity.Sewing = new SewingInfo();
          buEntity.Sewing.StitchLengt = clsSewing.varSewingSettings.defaultStitchLength;
          buEntity.Sewing.isStitchDrawing = true;
          this.SewingBase.MainEntityList.Add(buEntity);
        }
      }
      else if (Entities[index].GetType() == typeof (Arc))
      {
        buEntity buEntity = buEntity.Copy(Entities[index]);
        if (buEntity != null)
        {
          buEntity.Sewing = new SewingInfo();
          buEntity.Sewing.StitchLengt = clsSewing.varSewingSettings.defaultStitchLength;
          buEntity.Sewing.isStitchDrawing = true;
          this.SewingBase.MainEntityList.Add(buEntity);
        }
      }
    }
    this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
  }

  public void cmdChangeStitchLength(List<Entity> selectedEntities, bool ShowDialog = false)
  {
    try
    {
      SewingInfo sewingInfo = (SewingInfo) null;
      for (int index = 0; index <= selectedEntities.Count - 1; ++index)
      {
        if (selectedEntities[index].EntityData != null && selectedEntities[index].EntityData is SewingEntityCustomData)
        {
          SewingEntityCustomData entityData = selectedEntities[index].EntityData as SewingEntityCustomData;
          if (entityData.isStitch & entityData.indexEntity >= 0 & entityData.indexEntity <= this.SewingBase.MainEntityList.Count - 1)
          {
            sewingInfo = new SewingInfo(this.SewingBase.MainEntityList[entityData.indexEntity].Sewing);
            index = selectedEntities.Count;
          }
        }
      }
      if (sewingInfo == null)
        return;
      F_SewingStitchLen fSewingStitchLen = new F_SewingStitchLen();
      fSewingStitchLen.StitchLength = sewingInfo.StitchLengt;
      fSewingStitchLen.Properties.FormCloseMode = FormCloseModeType.Dispose;
      if (ShowDialog)
      {
        fSewingStitchLen.Init();
        int num = (int) fSewingStitchLen.ShowDialog();
      }
      // ISSUE: reference to a compiler-generated field
      if (this.okCommandWithThreeDataEventHandler_0 != null)
      {
        clsSewing.varSewingRunSettings.StitchLen = fSewingStitchLen.StitchLength;
        // ISSUE: reference to a compiler-generated field
        this.okCommandWithThreeDataEventHandler_0((object) "StitchLen", (object) null, (object) null);
        fSewingStitchLen.StitchLength = clsSewing.varSewingRunSettings.StitchLen;
      }
      if (!((fSewingStitchLen.Properties.Result == DialogResult.OK | !ShowDialog) & !this.CancelApplied))
        return;
      this.UndoBuffer();
      sewingInfo.StitchLengt = fSewingStitchLen.StitchLength;
      for (int index = 0; index <= selectedEntities.Count - 1; ++index)
      {
        if (selectedEntities[index].EntityData != null && selectedEntities[index].EntityData is SewingEntityCustomData)
        {
          SewingEntityCustomData entityData = selectedEntities[index].EntityData as SewingEntityCustomData;
          if (entityData.isStitch & entityData.indexEntity >= 0 & entityData.indexEntity <= this.SewingBase.MainEntityList.Count - 1 && sewingInfo.StitchLengt > 0.0)
            this.SewingBase.MainEntityList[entityData.indexEntity].Sewing.StitchLengt = sewingInfo.StitchLengt;
        }
      }
      this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
      this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdOffset()
  {
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandWithThreeDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithThreeDataEventHandler_0((object) "Offset", (object) null, (object) null);
      clsVar.varEditorRuntimeSet.OffsetValue = clsSewing.varSewingRunSettings.SewingOffset;
    }
    if (this.CancelApplied)
      return;
    SewingTempVars.DrawType = SewingDrawType.Stitched;
    clsInit.appEditor.action = actionTypeBU.eventOffset;
    if (Sketcher2D.entitiesSelected.Count == 0)
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Sewing);
      Sketcher2D.selectionProcess = true;
    }
    else
    {
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[33], buLangTranslate.preDef.Sewing);
      Sketcher2D.selectionProcess = false;
    }
  }

  public void cmdStitchToJump()
  {
    try
    {
      clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
      if (Sketcher2D.entitiesSelected.Count > 0)
        this.UndoBuffer();
      for (int index = 0; index <= Sketcher2D.entitiesSelected.Count - 1; ++index)
      {
        if (Sketcher2D.entitiesSelected[index].EntityData != null && Sketcher2D.entitiesSelected[index].EntityData is SewingEntityCustomData)
        {
          SewingEntityCustomData entityData = Sketcher2D.entitiesSelected[index].EntityData as SewingEntityCustomData;
          if (entityData.isStitch & entityData.indexEntity >= 0 & entityData.indexEntity <= this.SewingBase.MainEntityList.Count - 1 && this.SewingBase.MainEntityList[entityData.indexEntity].Sewing.isStitchDrawing)
            this.SewingBase.MainEntityList[entityData.indexEntity].Sewing.isStitchDrawing = false;
        }
      }
      this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
      this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
      this.JobUpdate();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdJumpToStitch()
  {
    try
    {
      clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
      if (Sketcher2D.entitiesSelected.Count > 0)
        this.UndoBuffer();
      for (int index = 0; index <= Sketcher2D.entitiesSelected.Count - 1; ++index)
      {
        if (Sketcher2D.entitiesSelected[index].EntityData != null && Sketcher2D.entitiesSelected[index].EntityData is SewingEntityCustomData)
        {
          SewingEntityCustomData entityData = Sketcher2D.entitiesSelected[index].EntityData as SewingEntityCustomData;
          if (!entityData.isStitch & entityData.indexEntity >= 0 & entityData.indexEntity <= this.SewingBase.MainEntityList.Count - 1 && !this.SewingBase.MainEntityList[entityData.indexEntity].Sewing.isStitchDrawing)
            this.SewingBase.MainEntityList[entityData.indexEntity].Sewing.isStitchDrawing = true;
        }
      }
      this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
      this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
      this.JobUpdate();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdSetProperties()
  {
    clsInit.appCommand.Reset(false);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
    ccVars.Action = actionTypeBU.sewingSetProperties;
    ccVars.stpDrawing = 1;
    ccVars.selectionProcess = false;
  }

  public void cmdShowPoints(bool Visible)
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name == clsSewing.varSewingSettings.layerNamePoint)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Visible = Visible;
    }
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name == clsSewing.varSewingSettings.layerNamePoint)
        ccVars.Pages[ccVars.PageIndex].Layers[index].Enable = Visible;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdShowDrawings(bool Visible)
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name == clsSewing.varSewingSettings.layerNameDrawing)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Visible = Visible;
    }
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name == clsSewing.varSewingSettings.layerNameDrawing)
        ccVars.Pages[ccVars.PageIndex].Layers[index].Enable = Visible;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdShowDrawingsDevided(bool Visible)
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name == clsSewing.varSewingSettings.layerNameDrawingDevided)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Visible = Visible;
    }
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name == clsSewing.varSewingSettings.layerNameDrawingDevided)
        ccVars.Pages[ccVars.PageIndex].Layers[index].Enable = Visible;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdShowDrawingPoints(bool Visible)
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name == clsSewing.varSewingSettings.layerNameDrawingPoints)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Visible = Visible;
    }
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name == clsSewing.varSewingSettings.layerNameDrawingPoints)
        ccVars.Pages[ccVars.PageIndex].Layers[index].Enable = Visible;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdShowOriginalDrawings(bool Visible)
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name == clsSewing.varSewingSettings.layerNameOriginal)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Visible = Visible;
    }
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name == clsSewing.varSewingSettings.layerNameOriginal)
        ccVars.Pages[ccVars.PageIndex].Layers[index].Enable = Visible;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdAddCodes()
  {
    clsInit.appEditor.action = actionTypeBU.sewingAddCode;
    Sketcher2D.selectionProcess = false;
    clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[7], buLangTranslate.preDef.Sewing);
  }

  public void cmdSimilationPrevius(int Step)
  {
    this.simIndex -= Step;
    this.simIndex -= Step;
    if (this.simIndex < 0)
      this.simIndex = 0;
    this.Sim_Tick((object) null, (EventArgs) null);
  }

  public void cmdSimilationNext(int Step)
  {
    if (Step > 1)
      this.simIndex += Step - 1;
    if (this.simIndex > this.SewingBase.SimilationPoint.SimMove.Count - 1)
      this.simIndex = this.SewingBase.SimilationPoint.SimMove.Count - 1;
    this.Sim_Tick((object) null, (EventArgs) null);
  }

  public void cmdSimilationPause()
  {
    this.timSim.Enabled = false;
    this.SimPaused = true;
  }

  public void cmdSimilationStop()
  {
    if (this.timSim.Enabled)
    {
      this.timSim.Enabled = false;
    }
    else
    {
      this.simIndex = -1;
      this.DeleteSimEntities();
      clsItem.frmEditor.viewport.Invalidate();
    }
  }

  public void cmdSimilationStart()
  {
    if (this.simIndex > 0 & !this.timSim.Enabled)
      this.timSim.Enabled = true;
    else if (this.SimPaused)
    {
      this.timSim.Enabled = true;
      this.SimPaused = false;
    }
    else
    {
      this.SewingTableList.Clear();
      this.CreateSewingTableList(clsSewing.Company, clsSewing.Model, ref this.SewingBase, ref this.SewingTableList);
      List<Point3D> point3DList = new List<Point3D>();
      for (int index1 = 0; index1 <= this.SewingTableList.Count - 1; ++index1)
      {
        if (point3DList.Count == 0)
        {
          point3DList.Add(new Point3D(this.SewingTableList[index1].PositionX, this.SewingTableList[index1].PositionY));
        }
        else
        {
          Point3D point3D1 = new Point3D(point3DList[point3DList.Count - 1].X, point3DList[point3DList.Count - 1].Y);
          Point3D point3D2 = new Point3D(this.SewingTableList[index1].PositionX, this.SewingTableList[index1].PositionY);
          if (Point3D.Distance(point3D1, point3D2) > 50.0)
          {
            List<Point3D> Vertices = new List<Point3D>();
            clsInit.cVector5.LineToLineer(point3D1, point3D2, 50.0, ref Vertices);
            for (int index2 = 1; index2 <= Vertices.Count - 1; ++index2)
              point3DList.Add(buVector5.ToPoint3D(Vertices[index2]));
          }
          else
            point3DList.Add(new Point3D(this.SewingTableList[index1].PositionX, this.SewingTableList[index1].PositionY));
        }
      }
      this.SewingBase.SimilationPoint = new SimulationTp();
      for (int index = 0; index <= point3DList.Count - 1; ++index)
      {
        Pnt6DSimMove pnt6DsimMove1 = new Pnt6DSimMove();
        Pnt6DSimMove pnt6DsimMove2 = new Pnt6DSimMove(point3DList[index]);
        if (index > 0)
        {
          double num = clsInit.cVector5.PointAngle(point3DList[index], point3DList[index - 1], Plane.XY);
          pnt6DsimMove2.C = num;
        }
        this.SewingBase.SimilationPoint.SimMove.Add(pnt6DsimMove2);
      }
      this.simIndex = 0;
      this.timSim.Interval = clsSewing.varSewingSettings.SimulationTick;
      this.timSim.Enabled = true;
    }
  }

  public void cmdShowTable(ref SewingMain sewingBase, ref List<SewingJobItem> sewingTableList)
  {
    if (sewingTableList.Count == 0)
      this.CreateSewingTableList(clsSewing.Company, clsSewing.Model, ref this.SewingBase, ref this.SewingTableList);
    if (this.frmTable == null)
      this.frmTable = new F_SewingTable();
    this.frmTable.SewingTableList.Clear();
    for (int index = 0; index <= sewingTableList.Count - 1; ++index)
      this.frmTable.SewingTableList.Add(new SewingJobItem(sewingTableList[index]));
    this.frmTable.Properties.FormCloseMode = FormCloseModeType.Invisible;
    this.frmTable.Init();
    int num = (int) this.frmTable.ShowDialog();
  }

  public EntityList DrawSewingData(SewingMain SewingData, EntityList EL)
  {
    EL.Clear();
    for (int index1 = 0; index1 <= SewingData.MainEntityList.Count - 1; ++index1)
    {
      Entity copiedEntity = (Entity) null;
      SewingInfo sewing = SewingData.MainEntityList[index1].Sewing;
      SewingDrawType drawType;
      if (sewing.isStitchDrawing)
      {
        buEntity.Copy(SewingData.MainEntityList[index1], ref copiedEntity);
        copiedEntity.ColorMethod = colorMethodType.byEntity;
        copiedEntity.Color = clsSewing.varSewingSettings.colorStitched;
        copiedEntity.LineWeight = (float) clsSewing.varSewingSettings.thicknessStitched;
        copiedEntity.LineWeightMethod = colorMethodType.byEntity;
        drawType = SewingDrawType.Stitched;
      }
      else
      {
        buEntity.Copy(SewingData.MainEntityList[index1], ref copiedEntity);
        copiedEntity.ColorMethod = colorMethodType.byEntity;
        copiedEntity.Color = clsSewing.varSewingSettings.colorJump;
        copiedEntity.LineWeight = (float) clsSewing.varSewingSettings.thicknessJump;
        copiedEntity.LineWeightMethod = colorMethodType.byEntity;
        drawType = SewingDrawType.Jump;
      }
      copiedEntity.EntityData = (object) new SewingEntityCustomData(index1, -1, sewing.isStitchDrawing, sewing.StitchLengt, drawType)
      {
        SortDir = SewingData.MainEntityList[index1].sortDirection
      };
      if (copiedEntity.LayerName != "Default")
        copiedEntity.LayerName = "Default";
      EL.Add(copiedEntity);
      int num1 = 0;
      int num2 = 0;
      if (sewing.StartStitchType != 0 & sewing.StartStitchCount > 0 & sewing.isStitchDrawing & sewing.Vertex.Count >= 2)
      {
        num1 = sewing.StartStitchCount;
        double Angle = clsInit.cVector5.PointAngle(sewing.Vertex[1].Point, sewing.Vertex[0].Point);
        double Length = (double) sewing.StartStitchCount * sewing.StitchLengt;
        Point3D EndPnt = new Point3D();
        clsInit.cVector5.LineWithLengthAndAngle(sewing.Vertex[0].Point, Length, Angle, ref EndPnt);
        Line line = new Line(sewing.Vertex[0].Point, EndPnt);
        line.ColorMethod = colorMethodType.byEntity;
        line.Color = clsSewing.varSewingSettings.colorLockStitch;
        line.LineWeight = (float) clsSewing.varSewingSettings.thicknessStitched + 2f;
        line.LineWeightMethod = colorMethodType.byEntity;
        SewingEntityCustomData entityCustomData = new SewingEntityCustomData(index1, -1, sewing.isStitchDrawing, sewing.StitchLengt, SewingDrawType.Extension);
        line.EntityData = (object) entityCustomData;
        EL.Add((Entity) line);
      }
      if (sewing.EndStitchType != 0 & sewing.EndStitchCount > 0 & sewing.isStitchDrawing & sewing.Vertex.Count >= 2)
        num2 = sewing.EndStitchCount;
      List<Point3D> points = new List<Point3D>();
      List<Point3D> point3DList = new List<Point3D>();
      SewingPunteriz data = (SewingPunteriz) null;
      for (int index2 = 0; index2 <= sewing.Vertex.Count - 1; ++index2)
      {
        SewingVertex sewingVertex = sewing.Vertex[index2];
        points.Add(new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY));
        devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY));
        point.ColorMethod = colorMethodType.byEntity;
        point.Color = clsSewing.varSewingSettings.colorVertex;
        point.LineWeight = (float) clsSewing.varSewingSettings.thicknessVertex + 4f;
        point.LineWeightMethod = colorMethodType.byEntity;
        if (num1 > 0 & index2 <= num1)
        {
          point.Color = clsSewing.varSewingSettings.colorLockStitch;
          point.LineWeight += 3f;
        }
        if (num2 > 0 & index2 >= sewing.Vertex.Count - num2 - 1)
        {
          point.Color = clsSewing.varSewingSettings.colorLockStitch;
          point.LineWeight += 3f;
        }
        SewingEntityCustomData entityCustomData1 = new SewingEntityCustomData(index1, index2, sewing.isStitchDrawing, sewing.StitchLengt, SewingDrawType.VertexPoint);
        if (sewing.Vertex[index2].Punterez != null)
        {
          data = new SewingPunteriz(sewing.Vertex[index2].Punterez);
          SewingPunteriz punterez = sewing.Vertex[index2].Punterez;
          bool flag = false;
          StartMiddleEndType startMiddleEndType;
          if (index2 == SewingData.MainEntityList[index1].Sewing.Vertex.Count - 1)
          {
            punterez.Angle = clsInit.cVector5.PointAngle(sewing.Vertex[index2 - 1].Point, sewing.Vertex[index2].Point);
            startMiddleEndType = StartMiddleEndType.End;
          }
          else if (index2 == 0)
          {
            punterez.Angle = clsInit.cVector5.PointAngle(sewing.Vertex[index2 + 1].Point, sewing.Vertex[index2].Point);
            startMiddleEndType = StartMiddleEndType.Start;
          }
          else
          {
            punterez.Angle = clsInit.cVector5.PointAngle(sewing.Vertex[index2 + 1].Point, sewing.Vertex[index2].Point);
            startMiddleEndType = StartMiddleEndType.Middle;
            flag = true;
          }
          entityCustomData1.Punteriz = new SewingPunteriz(punterez);
          List<Point3D> calcPoints = new List<Point3D>();
          this.doPunteriz(sewing.Vertex[index2].Point, punterez.Length, punterez.Width, punterez.Height, punterez.Angle, punterez.PunterizType, ref calcPoints);
          if (punterez.PunterizMethod == SewingPunterizMethod.StitchThenPunteriz & !flag)
          {
            if (startMiddleEndType == StartMiddleEndType.End | startMiddleEndType == StartMiddleEndType.Start)
            {
              List<Point3D> PointsDevided = new List<Point3D>();
              calcPoints.Reverse();
              calcPoints.Insert(0, buVector5.ToPoint3D(calcPoints[calcPoints.Count - 1]));
              clsInit.cVector5.DevidePointsByLength(calcPoints, sewing.StitchLengt, ref PointsDevided);
              LinearPath linearPath = new LinearPath((ICollection<Point3D>) PointsDevided);
              linearPath.ColorMethod = colorMethodType.byEntity;
              linearPath.Color = clsSewing.varSewingSettings.colorPunterez;
              linearPath.LineWeight = (float) clsSewing.varSewingSettings.thicknessStitched + 2f;
              linearPath.LineWeightMethod = colorMethodType.byEntity;
              SewingEntityCustomData entityCustomData2 = new SewingEntityCustomData(index1, index2, sewing.isStitchDrawing, sewing.StitchLengt, SewingDrawType.Punteriz);
              linearPath.EntityData = (object) entityCustomData2;
              EL.Add((Entity) linearPath);
            }
          }
          else
          {
            List<Point3D> PointsDevided = new List<Point3D>();
            clsInit.cVector5.DevidePointsByLength(calcPoints, sewing.StitchLengt, ref PointsDevided);
            LinearPath linearPath = new LinearPath((ICollection<Point3D>) PointsDevided);
            linearPath.ColorMethod = colorMethodType.byEntity;
            linearPath.Color = clsSewing.varSewingSettings.colorPunterez;
            linearPath.LineWeight = (float) clsSewing.varSewingSettings.thicknessStitched + 2f;
            linearPath.LineWeightMethod = colorMethodType.byEntity;
            SewingEntityCustomData entityCustomData3 = new SewingEntityCustomData(index1, index2, sewing.isStitchDrawing, sewing.StitchLengt, SewingDrawType.Punteriz);
            linearPath.EntityData = (object) entityCustomData3;
            EL.Add((Entity) linearPath);
          }
        }
        point.EntityData = (object) entityCustomData1;
        EL.Add((Entity) point);
        if (sewingVertex.Codes.Count > 0)
        {
          for (int index3 = 0; index3 <= sewingVertex.Codes.Count - 1; ++index3)
          {
            double z = (double) index3 * sewing.StitchLengt * 1.5;
            Joint joint = new Joint(new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY, z), sewing.StitchLengt * 0.5, (byte) 2);
            joint.Regen(0.1);
            joint.ColorMethod = colorMethodType.byEntity;
            joint.Color = clsSewing.varSewingSettings.colorVertexHasCode;
            joint.LineWeight = (float) clsSewing.varSewingSettings.thicknessVertex + 4f;
            joint.LineWeightMethod = colorMethodType.byEntity;
            EL.Add((Entity) joint);
          }
        }
      }
      if (point3DList.Count > 1)
      {
        int index4 = -1;
        int num3 = -1;
        double num4 = 9999999.0;
        double num5 = 9999999.0;
        for (int index5 = 0; index5 <= sewing.Vertex.Count - 1; ++index5)
        {
          double num6 = Point3D.Distance(sewing.Vertex[index5].Point, point3DList[0]);
          if (num6 < num4)
          {
            index4 = index5;
            num4 = num6;
          }
          double num7 = Point3D.Distance(sewing.Vertex[index5].Point, point3DList[point3DList.Count - 1]);
          if (num7 < num5)
          {
            num3 = index5;
            num5 = num7;
          }
        }
        if (index4 == -1)
        {
          double num8 = 9999999.0;
          for (int index6 = 0; index6 <= sewing.Vertex.Count - 1; ++index6)
          {
            double num9 = Point3D.Distance(sewing.Vertex[index6].Point, point3DList[0]);
            if (num9 < num8)
            {
              num8 = num9;
              index4 = index6;
            }
          }
        }
        if (num3 == -1)
        {
          double num10 = 9999999.0;
          for (int index7 = 0; index7 <= sewing.Vertex.Count - 1; ++index7)
          {
            double num11 = Point3D.Distance(sewing.Vertex[index7].Point, point3DList[point3DList.Count - 1]);
            if (num11 < num10)
            {
              num10 = num11;
              num3 = index7;
            }
          }
        }
        if (index4 >= 0 & num3 >= 0 & index4 != num3)
        {
          sewing.Vertex.RemoveRange(index4, num3 - index4 + 1);
          for (int index8 = 0; index8 <= point3DList.Count - 1; ++index8)
          {
            SewingVertex sewingVertex = new SewingVertex(point3DList[index8]);
            sewing.Vertex.Insert(index4 + index8, sewingVertex);
          }
          if (data != null)
            sewing.Vertex[index4].Punterez = new SewingPunteriz(data);
          points.Clear();
          points = new List<Point3D>();
          for (int index9 = 0; index9 <= sewing.Vertex.Count - 1; ++index9)
          {
            SewingVertex sewingVertex = sewing.Vertex[index9];
            points.Add(new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY));
          }
        }
      }
      if (sewing.isStitchDrawing)
      {
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
        linearPath.ColorMethod = colorMethodType.byEntity;
        linearPath.Color = clsSewing.varSewingSettings.colorStitched;
        linearPath.LineWeight = (float) clsSewing.varSewingSettings.thicknessStitched;
        linearPath.LineWeightMethod = colorMethodType.byEntity;
        linearPath.EntityData = (object) new SewingEntityCustomData(index1, -1, sewing.isStitchDrawing, sewing.StitchLengt, SewingDrawType.VertexPoint)
        {
          SortDir = SewingData.MainEntityList[index1].sortDirection
        };
        EL.Add((Entity) linearPath);
      }
      if (sewing.EndStitchType != 0 & sewing.EndStitchCount > 0 & sewing.isStitchDrawing & sewing.Vertex.Count >= 2)
      {
        double Angle = clsInit.cVector5.PointAngle(sewing.Vertex[sewing.Vertex.Count - 2].Point, sewing.Vertex[sewing.Vertex.Count - 1].Point);
        double Length = (double) sewing.EndStitchCount * sewing.StitchLengt;
        Point3D EndPnt = new Point3D();
        clsInit.cVector5.LineWithLengthAndAngle(sewing.Vertex[sewing.Vertex.Count - 1].Point, Length, Angle, ref EndPnt);
        Line line = new Line(sewing.Vertex[sewing.Vertex.Count - 1].Point, EndPnt);
        line.ColorMethod = colorMethodType.byEntity;
        line.Color = clsSewing.varSewingSettings.colorLockStitch;
        line.LineWeight = (float) clsSewing.varSewingSettings.thicknessStitched + 2f;
        line.LineWeightMethod = colorMethodType.byEntity;
        SewingEntityCustomData entityCustomData = new SewingEntityCustomData(index1, -1, sewing.isStitchDrawing, sewing.StitchLengt, SewingDrawType.Extension);
        line.EntityData = (object) entityCustomData;
        EL.Add((Entity) line);
      }
    }
    if (clsItem.frmEditor.viewport != null)
      clsItem.frmEditor.viewport.Invalidate();
    return EL;
  }

  public void DrawSewingTempEntities(List<Entity> tempEntities, ViewportRefType ViewType)
  {
    Design design = (Design) null;
    if (ViewType == ViewportRefType.Editor)
      design = (Design) clsItem.frmEditor.viewport;
    if (ViewType == ViewportRefType.Main)
      design = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
    design.TempEntities.Clear();
    for (int index = 0; index <= tempEntities.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buEntity.Copy(tempEntities[index], ref copiedEntity);
      design.TempEntities.Add(copiedEntity);
    }
    design.Invalidate();
  }

  public void AddLineJump(Point3D start, Point3D end)
  {
    this.UndoBuffer();
    buLine buLine = new buLine(start, end);
    buLine.Sewing = new SewingInfo();
    buLine.Sewing.isStitchDrawing = false;
    buLine.Sewing.Vertex.Add(new SewingVertex(start));
    buLine.Sewing.Vertex.Add(new SewingVertex(end));
    this.SewingBase.MainEntityList.Add((buEntity) buLine);
  }

  public void AddLineStitch(Point3D start, Point3D end)
  {
    this.UndoBuffer();
    buLine buLine = new buLine(start, end);
    buLine.Sewing = new SewingInfo();
    buLine.Sewing.StitchLengt = clsSewing.varSewingSettings.defaultStitchLength;
    buLine.Sewing.isStitchDrawing = true;
    buLine.Sewing.Vertex.Add(new SewingVertex(start));
    buLine.Sewing.Vertex.Add(new SewingVertex(end));
    this.SewingBase.MainEntityList.Add((buEntity) buLine);
    this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
  }

  public void AddArcStitch(Point3D start, Point3D middle, Point3D end, bool flip)
  {
    this.UndoBuffer();
    buArc buArc = new buArc(start, middle, end, flip);
    buArc.Sewing = new SewingInfo();
    buArc.Sewing.StitchLengt = clsSewing.varSewingSettings.defaultStitchLength;
    buArc.Sewing.isStitchDrawing = true;
    buArc.Sewing.Vertex.Add(new SewingVertex(start));
    buArc.Sewing.Vertex.Add(new SewingVertex(end));
    this.SewingBase.MainEntityList.Add((buEntity) buArc);
    this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
  }

  public void AddCircleStitch(Point3D start, Point3D middle, Point3D end)
  {
    this.UndoBuffer();
    buCircle buCircle = new buCircle(start, middle, end);
    buCircle.Sewing = new SewingInfo();
    buCircle.Sewing.StitchLengt = clsSewing.varSewingSettings.defaultStitchLength;
    buCircle.Sewing.isStitchDrawing = true;
    buCircle.Sewing.Vertex.Add(new SewingVertex(start));
    buCircle.Sewing.Vertex.Add(new SewingVertex(end));
    this.SewingBase.MainEntityList.Add((buEntity) buCircle);
    this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
  }

  public void LoadLanguage()
  {
    try
    {
      List<string> stringList = new List<string>();
      FileInfo fileInfo = clsVar.appModes_0.DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buSewing.lng") : new FileInfo(AppPath.Language + "\\buSewing.lng");
      if (fileInfo.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buSewingCalc.LangSewingStatus);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buSewingCalc.LangSewingMessage);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buSewingCalc.LangSewingCaptions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buSewingCalc.LangSewingCommands);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MainForm>", "</MainForm>", StringList), clsVar.varRuntime.Language, ref buSewingCalc.LangSewingMainForm);
        StringList.Clear();
      }
      else
      {
        buLog.addLog("Sewing Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Profile Language File Missing");
      }
      if (stringList.Count > 0)
        ;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenTeachFile(string FileName, ref SewingMain SewingData)
  {
    try
    {
      ArrayList RefList = new ArrayList();
      TextReader textReader = (TextReader) File.OpenText(FileName);
      string str;
      while ((str = textReader.ReadLine()) != null)
        RefList.Add((object) str);
      textReader.Close();
      List<List<string>> CalcList = new List<List<string>>();
      buString5.ListToSpecificList("<SewingJobItem>", "</SewingJobItem>", true, RefList, ref CalcList);
      SewingData.MainEntityList.Clear();
      this.OpenSewingJobFile(FileName, ref SewingData);
    }
    catch (Exception ex)
    {
    }
  }

  public void OpenSewingJobFile(string FileName, ref SewingMain SewingData)
  {
    try
    {
      if (!new FileInfo(FileName).Exists)
        return;
      List<string> StringList = new List<string>();
      buFile5.OpenFromFile(FileName, ref StringList);
      List<List<string>> CalcList = new List<List<string>>();
      buString5.ListToSpecificList("<buEntity>", "</buEntity>", false, StringList, ref CalcList);
      if (CalcList.Count > 0)
      {
        this.UndoList.Clear();
        SewingData.MainEntityList.Clear();
        SewingData.MainEntityList = new List<buEntity>();
      }
      for (int index = 0; index <= CalcList.Count - 1; ++index)
      {
        buEntity refEntity = (buEntity) null;
        buEntity.Decode(CalcList[index], ref refEntity);
        if (refEntity != null)
          SewingData.MainEntityList.Add(refEntity);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void SaveSewingFile()
  {
    try
    {
      string FileName = AppPath.Settings + "\\Sewing.prm";
      ArrayList StringList = new ArrayList();
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Sewing Settings");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "<varSewingSettings>");
      StringList.AddRange((ICollection) clsSewing.varSewingSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList.Add((object) "</varSewingSettings>");
      StringList.Add((object) "<varSewingRunSettings>");
      StringList.AddRange((ICollection) clsSewing.varSewingRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList.Add((object) "</varSewingRunSettings>");
      buFile.SaveToFile(StringList, FileName);
      buLog.addLog("EditSewingor Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenSewingFile()
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      FileInfo fileInfo = new FileInfo(AppPath.Settings + "\\Sewing.prm");
      if (fileInfo.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<varSewingSettings>", "</varSewingSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsSewing.varSewingSettings);
            buLog.addLog("varSewingSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<varSewingRunSettings>", "</varSewingRunSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsSewing.varSewingRunSettings);
            buLog.addLog("varSewingRunSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Sewing Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Editor Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("Door Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Door Settings File Missing");
      }
      buLog.addLog("Door Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void Sim_Tick(object sender, EventArgs e)
  {
    if (this.SewingBase.SimilationPoint.SimMove.Count > 0)
    {
      if (this.simIndex >= 0 & this.simIndex <= this.SewingBase.SimilationPoint.SimMove.Count - 1)
      {
        if (clsItem.frmEditor.viewport.Entities.Count > 0)
        {
          this.DeleteSimEntities();
          Pnt6DSimMove pnt6DsimMove = this.SewingBase.SimilationPoint.SimMove[this.simIndex];
          LinearPath outer = new LinearPath((ICollection<Point3D>) new List<Point3D>()
          {
            new Point3D(pnt6DsimMove.X, pnt6DsimMove.Y, 0.0),
            new Point3D(pnt6DsimMove.X + 20.0, pnt6DsimMove.Y + 5.0, 0.0),
            new Point3D(pnt6DsimMove.X + 20.0, pnt6DsimMove.Y - 5.0, 0.0),
            new Point3D(pnt6DsimMove.X, pnt6DsimMove.Y, 0.0)
          });
          if (clsSewing.varSewingSettings.SimulationRotate)
            outer.Rotate(buConversion5.DegreeToRadian(pnt6DsimMove.C + 180.0), Vector3D.AxisZ, new Point3D(pnt6DsimMove.X, pnt6DsimMove.Y, 0.0));
          Mesh mesh = new devDept.Eyeshot.Entities.Region((ICurve) outer, Plane.XY, true).ExtrudeAsMesh(1.0, 0.1, Mesh.natureType.RichSmooth);
          mesh.Color = Color.FromArgb(clsSewing.varSewingSettings.SimulationTransparency, clsSewing.varSewingSettings.colorSimulation);
          mesh.ColorMethod = colorMethodType.byEntity;
          CustomData customData = new CustomData();
          customData.typeDefination = entityTypeDefination.Tool;
          mesh.EntityData = (object) customData;
          outer.EntityData = (object) customData;
          if (clsSewing.varSewingSettings.SimulationSolid)
            clsItem.frmEditor.viewport.Entities.Add((Entity) mesh);
          else
            clsItem.frmEditor.viewport.Entities.Add((Entity) outer);
          this.simIndex += clsSewing.varSewingSettings.SimulationStep;
        }
      }
      else
      {
        this.simIndex = -1;
        this.timSim.Enabled = false;
        this.DeleteSimEntities();
      }
    }
    else
    {
      this.simIndex = -1;
      this.timSim.Enabled = false;
      this.DeleteSimEntities();
    }
    clsItem.frmEditor.viewport.Invalidate();
  }

  public void DeleteTempEntities()
  {
    if (clsItem.frmEditor == null)
      return;
    for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
    {
      Entity entity = clsItem.frmEditor.viewport.Entities[index];
      entity.Selected = false;
      if (entity.EntityData != null && entity.EntityData is CustomData && ((CustomData) entity.EntityData).typeDefination == entityTypeDefination.Temp)
        entity.Selected = true;
    }
    clsItem.frmEditor.viewport.Entities.DeleteSelected();
    clsItem.frmEditor.viewport.Invalidate();
  }

  public void DeleteSimEntities()
  {
    if (clsItem.frmEditor.viewport.Entities.Count <= 0)
      return;
    Entity entity = clsItem.frmEditor.viewport.Entities[clsItem.frmEditor.viewport.Entities.Count - 1];
    if (!(entity.EntityData != null & entity.EntityData is CustomData) || (entity.EntityData as CustomData).typeDefination != entityTypeDefination.Tool)
      return;
    clsItem.frmEditor.viewport.Entities.RemoveAt(clsItem.frmEditor.viewport.Entities.Count - 1);
  }

  public void CreateTempCircle(
    Point3D Center,
    double Radius,
    Color Clr,
    bool DrawCircle,
    ref Entity tempEntity)
  {
    ccVars.DrawCircle.Clear();
    if (!(Radius > 0.0 & Center != (Point3D) null))
      return;
    devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((ICurve) new Circle(Center, Radius));
    tempEntity = (Entity) region.ExtrudeAsMesh(1.0, 0.05, Mesh.natureType.RichSmooth);
    tempEntity.Color = Clr;
    tempEntity.ColorMethod = colorMethodType.byEntity;
    tempEntity.EntityData = (object) new CustomData()
    {
      typeDefination = entityTypeDefination.Temp
    };
    if (!DrawCircle)
      return;
    ccVars.DrawCircle.Add(new buCircle(Center, 10.0));
  }

  public void OpenSewingFile(string FileName)
  {
    if (!new FileInfo(FileName).Exists)
      return;
    List<string> StringList = new List<string>();
    buFile5.OpenFromFile(FileName, ref StringList);
    List<List<string>> CalcList = new List<List<string>>();
    buString5.ListToSpecificList("<buEntity>", "</buEntity>", false, StringList, ref CalcList);
    if (CalcList.Count > 0)
    {
      this.SewingBase.MainEntityList.Clear();
      this.SewingBase.MainEntityList = new List<buEntity>();
      if (ccVars.Pages.Count > 0)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    }
    for (int index = 0; index <= CalcList.Count - 1; ++index)
    {
      buEntity refEntity = (buEntity) null;
      buEntity.Decode(CalcList[index], ref refEntity);
      if (refEntity != null)
        this.SewingBase.MainEntityList.Add(refEntity);
    }
    List<Entity> entityList = new List<Entity>();
    if (ccVars.Pages.Count <= 0)
      return;
    this.doDrawMainEntities(this.SewingBase.MainEntityList, true);
  }

  public void OpenCamTable(string FileName, double Length)
  {
    List<string> StringList = new List<string>();
    buFile5.OpenFromFile(FileName, ref StringList);
    List<LengthAngle> lengthAngleList = new List<LengthAngle>();
    for (int index = 0; index <= StringList.Count - 1; ++index)
    {
      string[] strArray = StringList[index].Split(';');
      if (strArray != null & strArray.Length >= 2)
        lengthAngleList.Add(new LengthAngle()
        {
          Angle = double.Parse(strArray[0]) * 6.0,
          Length = double.Parse(strArray[1])
        });
    }
    if (lengthAngleList.Count <= 0)
      return;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    List<Point3D> points = new List<Point3D>();
    for (int index = 0; index <= lengthAngleList.Count - 1; ++index)
    {
      Point3D EndPnt = new Point3D();
      clsInit.cVector5.LineWithLengthAndAngle(new Point3D(), lengthAngleList[index].Length + Length, lengthAngleList[index].Angle, ref EndPnt);
      points.Add(EndPnt);
      ccVars.UndoDont = true;
      Line Ent = new Line(new Point3D(), EndPnt);
      Ent.Color = Color.Lime;
      Ent.ColorMethod = colorMethodType.byEntity;
      clsInit.appCommand.AddLine(Ent);
    }
    if (points.Count < 2)
      return;
    LinearPath Ent1 = new LinearPath((ICollection<Point3D>) points);
    Ent1.Color = Color.Red;
    Ent1.ColorMethod = colorMethodType.byEntity;
    clsInit.appCommand.AddPolyline(Ent1);
  }

  public bool isPointLayerVisible()
  {
    bool flag;
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name == clsSewing.varSewingSettings.layerNamePoint)
      {
        flag = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Visible;
        goto label_6;
      }
    }
    flag = true;
label_6:
    return flag;
  }

  public void MoveNeighboorOfVertex(
    ref List<buEntity> MainEntity,
    int EntityIndex,
    int VertexIndex,
    Point3D pntRef,
    double dX,
    double dY)
  {
    for (int index1 = 0; index1 <= MainEntity.Count - 1; ++index1)
    {
      if (index1 != EntityIndex)
      {
        if (buCompare5.EQ(pntRef, MainEntity[index1].StartPoint, 0.01))
        {
          MainEntity[index1].StartPoint.X += dX;
          MainEntity[index1].StartPoint.Y += dY;
          MainEntity[index1].Update(buEntityUpdateType.None);
        }
        if (buCompare5.EQ(pntRef, MainEntity[index1].EndPoint, 0.01))
        {
          MainEntity[index1].EndPoint.X += dX;
          MainEntity[index1].EndPoint.Y += dY;
          MainEntity[index1].Update(buEntityUpdateType.None);
        }
        for (int index2 = 0; index2 <= MainEntity[index1].Sewing.Vertex.Count - 1; ++index2)
        {
          Point3D point = MainEntity[index1].Sewing.Vertex[index2].Point;
          if (buCompare5.EQ(pntRef, point, 0.01))
          {
            MainEntity[index1].Sewing.Vertex[index2].Point.X += dX;
            MainEntity[index1].Sewing.Vertex[index2].Point.Y += dY;
          }
        }
      }
    }
  }

  public void MoveMainEntity(
    ref List<buEntity> MainEntity,
    int EntityIndex,
    int VertexIndex,
    Point3D pntRef,
    double dX,
    double dY)
  {
    for (int index = 0; index <= MainEntity.Count - 1; ++index)
    {
      if (index == EntityIndex)
      {
        double num1 = 0.0;
        double num2 = 0.0;
        if (MainEntity[index].Sewing.Vertex.Count > 0)
        {
          num1 = MainEntity[index].Sewing.Vertex[0].DeltaX;
          num2 = MainEntity[index].Sewing.Vertex[0].DeltaY;
        }
        Point3D point3D1 = new Point3D(MainEntity[index].StartPoint.X + num1, MainEntity[index].StartPoint.Y + num2);
        if (buCompare5.EQ(pntRef, point3D1, 0.01))
        {
          MainEntity[index].StartPoint.X += dX;
          MainEntity[index].StartPoint.Y += dY;
          MainEntity[index].Update(buEntityUpdateType.None);
        }
        if (MainEntity[index].Sewing.Vertex.Count > 0)
        {
          num1 = MainEntity[index].Sewing.Vertex[MainEntity[index].Sewing.Vertex.Count - 1].DeltaX;
          num2 = MainEntity[index].Sewing.Vertex[MainEntity[index].Sewing.Vertex.Count - 1].DeltaY;
        }
        Point3D point3D2 = new Point3D(MainEntity[index].EndPoint.X + num1, MainEntity[index].EndPoint.Y + num2);
        if (buCompare5.EQ(pntRef, point3D2, 0.01))
        {
          MainEntity[index].EndPoint.X += dX;
          MainEntity[index].EndPoint.Y += dY;
          MainEntity[index].Update(buEntityUpdateType.None);
        }
      }
    }
  }

  public void MoveCommand(object Axis, object MoveDis)
  {
    double X = 0.0;
    double Y = 0.0;
    double num = Convert.ToDouble(MoveDis.ToString());
    if (Axis.ToString() == "X")
      X = num;
    if (Axis.ToString() == "Y")
      Y = num;
    clsSewing.varSewingRunSettings.MoveDistance = num;
    if (clsInit.appEditor.action == actionTypeBU.sewingScale && this.Selected.Count > 0)
    {
      this.UndoBuffer();
      for (int index = 0; index <= this.Selected.Count - 1; ++index)
      {
        if (this.Selected[index].EntityIndex >= 0)
        {
          Point3D pntCatch = new Point3D();
          if (this.Selected[index].CatchPosition == StartMiddleEndType.Start)
          {
            pntCatch.X = this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint.X;
            pntCatch.Y = this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint.Y;
            if (Axis.ToString() == "AnglePlus")
            {
              double Degree = 180.0 + clsInit.cVector5.PointAngle(this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint, this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint);
              X = Math.Abs(num) * Math.Cos(buConversion5.DegreeToRadian(Degree));
              Y = Math.Abs(num) * Math.Sin(buConversion5.DegreeToRadian(Degree));
            }
            if (Axis.ToString() == "AngleMinus")
            {
              double Degree = clsInit.cVector5.PointAngle(this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint, this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint);
              X = Math.Abs(num) * Math.Cos(buConversion5.DegreeToRadian(Degree));
              Y = Math.Abs(num) * Math.Sin(buConversion5.DegreeToRadian(Degree));
            }
            this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint.X += X;
            this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint.Y += Y;
          }
          if (this.Selected[index].CatchPosition == StartMiddleEndType.End)
          {
            pntCatch.X = this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint.X;
            pntCatch.Y = this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint.Y;
            if (Axis.ToString() == "AnglePlus")
            {
              double Degree = 180.0 + clsInit.cVector5.PointAngle(this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint, this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint);
              X = Math.Abs(num) * Math.Cos(buConversion5.DegreeToRadian(Degree));
              Y = Math.Abs(num) * Math.Sin(buConversion5.DegreeToRadian(Degree));
            }
            if (Axis.ToString() == "AngleMinus")
            {
              double Degree = clsInit.cVector5.PointAngle(this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint, this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint);
              X = Math.Abs(num) * Math.Cos(buConversion5.DegreeToRadian(Degree));
              Y = Math.Abs(num) * Math.Sin(buConversion5.DegreeToRadian(Degree));
            }
            this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint.X += X;
            this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint.Y += Y;
          }
          if (this.SewingBase.MainEntityList[this.Selected[index].EntityIndex] is buLine)
            this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].Update(buEntityUpdateType.Line);
          if (this.SewingBase.MainEntityList[this.Selected[index].EntityIndex] is buArc)
            this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].Update(buEntityUpdateType.Arc3Point3D);
          this.MoveTouchEntities(this.Selected[index].EntityIndex, pntCatch, X, Y);
        }
      }
      this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
      this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
      this.SaveSewingFile();
    }
    if (clsInit.appEditor.action == actionTypeBU.sewingMove && this.Selected.Count > 0)
    {
      this.UndoBuffer();
      for (int index = 0; index <= this.Selected.Count - 1; ++index)
      {
        Point3D pntCatch1 = new Point3D();
        Point3D pntCatch2 = new Point3D();
        if (this.Selected[index].EntityIndex >= 0)
        {
          pntCatch1.X = this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint.X;
          pntCatch1.Y = this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint.Y;
          pntCatch2.X = this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint.X;
          pntCatch2.Y = this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint.Y;
          this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint.X += X;
          this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint.X += X;
          this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint.Y += Y;
          this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint.Y += Y;
          if (this.SewingBase.MainEntityList[this.Selected[index].EntityIndex] is buLine)
            this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].Update(buEntityUpdateType.Line);
          if (this.SewingBase.MainEntityList[this.Selected[index].EntityIndex] is buArc)
            this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].Update(buEntityUpdateType.Arc3Point3D);
          this.MoveTouchEntities(this.Selected[index].EntityIndex, pntCatch1, X, Y);
          this.MoveTouchEntities(this.Selected[index].EntityIndex, pntCatch2, X, Y);
        }
      }
      this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
      this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
      this.SaveSewingFile();
    }
    if (clsInit.appEditor.action != actionTypeBU.sewingMoveVertex)
      return;
    if (this.Selected.Count > 0)
    {
      this.UndoBuffer();
      bool flag1 = false;
      for (int index1 = 0; index1 <= this.Selected.Count - 1; ++index1)
      {
        Point3D pntCatch = new Point3D();
        bool flag2 = false;
        if (this.Selected[index1].EntityIndex >= 0 & this.Selected[index1].EntityIndex <= this.SewingBase.MainEntityList.Count - 1)
          flag2 = this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.isStitchDrawing;
        if (clsSewing.varSewingSettings.VertexMoveType == MoveVertexType.MoveCorner | !flag2)
        {
          if (this.Selected[index1].EntityIndex >= 0)
          {
            if (this.Selected[index1].CatchPosition == StartMiddleEndType.Start | this.Selected[index1].CatchPosition == StartMiddleEndType.End)
            {
              int index2 = 0;
              if (this.Selected[index1].CatchPosition == StartMiddleEndType.Start)
                index2 = 0;
              if (this.Selected[index1].CatchPosition == StartMiddleEndType.End)
                index2 = this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex.Count - 1;
              pntCatch.X = this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex[index2].Point.X + this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex[index2].DeltaX;
              pntCatch.Y = this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex[index2].Point.Y + this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex[index2].DeltaY;
              bool flag3 = false;
              flag1 = true;
              if (buCompare5.EQ(this.Selected[index1].refPoint, pntCatch))
              {
                this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex[index2].Point.X += X;
                this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex[index2].Point.Y += Y;
              }
              if (buCompare5.EQ(this.Selected[index1].refPoint, this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].StartPoint))
              {
                this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].StartPoint.X += X;
                this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].StartPoint.Y += Y;
                flag3 = true;
              }
              else if (buCompare5.EQ(this.Selected[index1].refPoint, this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].EndPoint))
              {
                this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].EndPoint.X += X;
                this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].EndPoint.Y += Y;
                flag3 = true;
              }
              if (flag3)
              {
                this.Selected[index1].refPoint.X += X;
                this.Selected[index1].refPoint.Y += Y;
                if (this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex] is buLine)
                  this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Update(buEntityUpdateType.Line);
                if (this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex] is buArc)
                  this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Update(buEntityUpdateType.Arc3Point3D);
              }
            }
            else if (this.Selected[index1].VertexIndex <= this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex.Count - 1)
            {
              pntCatch.X = this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex[this.Selected[index1].VertexIndex].Point.X + this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex[this.Selected[index1].VertexIndex].DeltaX;
              pntCatch.Y = this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex[this.Selected[index1].VertexIndex].Point.Y + this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex[this.Selected[index1].VertexIndex].DeltaY;
              this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex[this.Selected[index1].VertexIndex].DeltaX += X;
              this.Selected[index1].refPoint.X += X;
              this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Sewing.Vertex[this.Selected[index1].VertexIndex].DeltaY += Y;
              this.Selected[index1].refPoint.Y += Y;
            }
            this.MoveTouchEntities(this.Selected[index1].EntityIndex, pntCatch, X, Y);
          }
        }
        else if (this.Selected[index1].EntityIndex >= 0)
        {
          for (int index3 = 0; index3 <= this.SewingBase.MainEntityList.Count - 1; ++index3)
          {
            for (int index4 = 0; index4 <= this.SewingBase.MainEntityList[index3].Sewing.Vertex.Count - 1; ++index4)
            {
              Point3D point = this.SewingBase.MainEntityList[index3].Sewing.Vertex[index4].Point;
              if (buCompare5.EQ(point.X, this.Selected[index1].refPoint.X) & buCompare5.EQ(point.Y, this.Selected[index1].refPoint.Y))
              {
                point.X += X;
                point.Y += Y;
              }
            }
          }
          this.Selected[index1].refPoint.X += X;
          this.Selected[index1].refPoint.Y += Y;
        }
      }
      if (clsSewing.varSewingSettings.VertexMoveType == MoveVertexType.MoveCorner && flag1)
        this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
      this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
      Sketcher2D.selectedCircle.Clear();
      for (int index = 0; index <= this.Selected.Count - 1; ++index)
      {
        Circle circle = new Circle(Plane.XY, buVector5.ToPoint3D(this.Selected[index].refPoint), 0.8);
        circle.Color = Color.Cyan;
        Sketcher2D.selectedCircle.Add(circle);
      }
    }
    this.SaveSewingFile();
  }

  public void SelectVertexCommand(object Command, object Val, object ShowDialog)
  {
    if (Command.ToString() == "Ok")
    {
      if (this.frmSelectVertex != null)
        this.frmSelectVertex.Visible = false;
      if (clsInit.appEditor.action == actionTypeBU.sewingMoveVertex)
      {
        if (this.frmMove == null)
        {
          this.frmMove = new F_SewingMove();
          this.frmMove.MoveCommad += new OkCommandWithTwoDataEventHandler(this.MoveCommand);
          this.frmMove.CancelCommad += new CancelCommandEventHandler(this.MoveCancel);
        }
        if (clsSewing.varSewingRunSettings.MoveDistance <= 0.0)
          clsSewing.varSewingRunSettings.MoveDistance = 1.0;
        this.frmMove.MoveDis = clsSewing.varSewingRunSettings.MoveDistance;
        this.frmMove.Properties.FormCloseMode = FormCloseModeType.Invisible;
        this.frmMove.Properties.FormPosition = FormStartPosition.CenterScreen;
        this.frmMove.Properties.TopMost = true;
        this.frmMove.btn_anglePlus.Visible = false;
        this.frmMove.btn_angleMinus.Visible = false;
        this.frmMove.Init();
        this.frmMove.Show();
      }
      if (clsInit.appEditor.action == actionTypeBU.sewingFootHeight)
      {
        if (this.frmFootHeight == null)
          this.frmFootHeight = new F_SewingFootHeight();
        if (clsSewing.varSewingRunSettings.FootHeight < 0.0)
          clsSewing.varSewingRunSettings.FootHeight = 10.0;
        if (this.Selected.Count > 0)
        {
          clsSewing.varSewingRunSettings.FootHeight = this.SewingBase.MainEntityList[this.Selected[0].EntityIndex].Sewing.Vertex[this.Selected[0].VertexIndex].FootHeight;
          this.frmFootHeight.FootHeight = clsSewing.varSewingRunSettings.FootHeight;
          this.frmFootHeight.Properties.FormCloseMode = FormCloseModeType.Invisible;
          this.frmFootHeight.Properties.FormPosition = FormStartPosition.CenterScreen;
          this.frmFootHeight.Properties.TopMost = true;
          if ((bool) ShowDialog)
          {
            this.frmFootHeight.Init();
            int num = (int) this.frmFootHeight.ShowDialog();
          }
          // ISSUE: reference to a compiler-generated field
          if (this.okCommandWithThreeDataEventHandler_0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.okCommandWithThreeDataEventHandler_0((object) "FootHeight", (object) null, (object) null);
            this.frmFootHeight.FootHeight = clsSewing.varSewingRunSettings.FootHeight;
          }
          if ((this.frmFootHeight.Properties.Result == DialogResult.OK | !(bool) ShowDialog) & !this.CancelApplied)
          {
            for (int index = 0; index <= this.Selected.Count - 1; ++index)
              this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].Sewing.Vertex[this.Selected[index].VertexIndex].FootHeight = this.frmFootHeight.FootHeight;
            clsSewing.varSewingRunSettings.FootHeight = this.frmFootHeight.FootHeight;
          }
          clsInit.appEditor.Reset();
        }
        this.SaveSewingFile();
      }
      if (clsInit.appEditor.action == actionTypeBU.sewingSpeed)
      {
        if (this.frmSpeed == null)
          this.frmSpeed = new F_SewingSpeed();
        if (this.Selected.Count > 0)
        {
          if (this.SewingBase.MainEntityList[this.Selected[0].EntityIndex].Sewing.Vertex[this.Selected[0].VertexIndex].Speed > 0.0)
            clsSewing.varSewingRunSettings.SewingSpeed = this.SewingBase.MainEntityList[this.Selected[0].EntityIndex].Sewing.Vertex[this.Selected[0].VertexIndex].Speed;
          this.frmSpeed.Speed = clsSewing.varSewingRunSettings.SewingSpeed;
          this.frmSpeed.Properties.FormCloseMode = FormCloseModeType.Invisible;
          this.frmSpeed.Properties.FormPosition = FormStartPosition.CenterScreen;
          this.frmSpeed.Properties.TopMost = true;
          if ((bool) ShowDialog)
          {
            this.frmSpeed.Init();
            int num = (int) this.frmSpeed.ShowDialog();
          }
          // ISSUE: reference to a compiler-generated field
          if (this.okCommandWithThreeDataEventHandler_0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.okCommandWithThreeDataEventHandler_0((object) "SewingSpeed", (object) null, (object) null);
            this.frmSpeed.Speed = clsSewing.varSewingRunSettings.SewingSpeed;
          }
          if ((this.frmSpeed.Properties.Result == DialogResult.OK | !(bool) ShowDialog) & !this.CancelApplied)
          {
            for (int index = 0; index <= this.Selected.Count - 1; ++index)
              this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].Sewing.Vertex[this.Selected[index].VertexIndex].Speed = this.frmSpeed.Speed;
          }
          clsInit.appEditor.Reset();
        }
        this.SaveSewingFile();
      }
      this.CancelApplied = false;
    }
    else
    {
      if (!(this.baseSelected.EntityIndex >= 0 & this.baseSelected.EntityIndex <= this.SewingBase.MainEntityList.Count - 1) || this.SewingBase.MainEntityList[this.baseSelected.EntityIndex].Sewing == null)
        return;
      SewingInfo sewing = this.SewingBase.MainEntityList[this.baseSelected.EntityIndex].Sewing;
      if (this.Selected[this.Selected.Count - 1].VertexIndex >= 0 & this.Selected[this.Selected.Count - 1].VertexIndex <= sewing.Vertex.Count - 1)
      {
        if (Command.ToString() == "Minus")
        {
          if (this.Selected.Count == 1)
          {
            if (this.Selected[this.Selected.Count - 1].VertexIndex > 0)
            {
              SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint(this.Selected[this.Selected.Count - 1]);
              if (sewingSelectedPoint.VertexIndex > 0)
              {
                --sewingSelectedPoint.VertexIndex;
                sewingSelectedPoint.refPoint = new Point3D(sewing.Vertex[sewingSelectedPoint.VertexIndex].Point.X + sewing.Vertex[sewingSelectedPoint.VertexIndex].DeltaX, sewing.Vertex[sewingSelectedPoint.VertexIndex].Point.Y + sewing.Vertex[sewingSelectedPoint.VertexIndex].DeltaY);
                this.Selected.Add(sewingSelectedPoint);
              }
            }
          }
          else if (this.Selected.Count > 1)
          {
            if (this.Selected[this.Selected.Count - 1].VertexIndex < this.Selected[this.Selected.Count - 2].VertexIndex)
            {
              SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint(this.Selected[this.Selected.Count - 1]);
              if (sewingSelectedPoint.VertexIndex > 0)
              {
                --sewingSelectedPoint.VertexIndex;
                sewingSelectedPoint.refPoint = new Point3D(sewing.Vertex[sewingSelectedPoint.VertexIndex].Point.X + sewing.Vertex[sewingSelectedPoint.VertexIndex].DeltaX, sewing.Vertex[sewingSelectedPoint.VertexIndex].Point.Y + sewing.Vertex[sewingSelectedPoint.VertexIndex].DeltaY);
                this.Selected.Add(sewingSelectedPoint);
              }
            }
            else
              this.Selected.RemoveAt(this.Selected.Count - 1);
          }
        }
        if (Command.ToString() == "Plus")
        {
          if (this.Selected.Count == 1)
          {
            if (this.Selected[this.Selected.Count - 1].VertexIndex < sewing.Vertex.Count - 1)
            {
              SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint(this.Selected[this.Selected.Count - 1]);
              if (sewingSelectedPoint.VertexIndex < sewing.Vertex.Count - 1)
              {
                ++sewingSelectedPoint.VertexIndex;
                sewingSelectedPoint.refPoint = new Point3D(sewing.Vertex[sewingSelectedPoint.VertexIndex].Point.X + sewing.Vertex[sewingSelectedPoint.VertexIndex].DeltaX, sewing.Vertex[sewingSelectedPoint.VertexIndex].Point.Y + sewing.Vertex[sewingSelectedPoint.VertexIndex].DeltaY);
                this.Selected.Add(sewingSelectedPoint);
              }
            }
          }
          else if (this.Selected.Count > 1)
          {
            if (this.Selected[this.Selected.Count - 1].VertexIndex > this.Selected[this.Selected.Count - 2].VertexIndex)
            {
              SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint(this.Selected[this.Selected.Count - 1]);
              if (sewingSelectedPoint.VertexIndex < sewing.Vertex.Count - 1)
              {
                ++sewingSelectedPoint.VertexIndex;
                sewingSelectedPoint.refPoint = new Point3D(sewing.Vertex[sewingSelectedPoint.VertexIndex].Point.X + sewing.Vertex[sewingSelectedPoint.VertexIndex].DeltaX, sewing.Vertex[sewingSelectedPoint.VertexIndex].Point.Y + sewing.Vertex[sewingSelectedPoint.VertexIndex].DeltaY);
                this.Selected.Add(sewingSelectedPoint);
              }
            }
            else
              this.Selected.RemoveAt(this.Selected.Count - 1);
          }
        }
      }
      Sketcher2D.selectedCircle.Clear();
      for (int index = 0; index <= this.Selected.Count - 1; ++index)
      {
        Circle circle = new Circle(Plane.XY, buVector5.ToPoint3D(this.Selected[index].refPoint), 0.8);
        circle.Color = Color.Cyan;
        Sketcher2D.selectedCircle.Add(circle);
      }
      clsItem.frmEditor.viewport.Invalidate();
    }
  }

  public void MoveCancel() => clsInit.appEditor.Reset();

  public void RotateCommand(object Axis, object RotateDegree)
  {
    if (clsInit.appEditor.action != actionTypeBU.sewingRotate)
      return;
    Point3D point3D1 = new Point3D();
    Point3D point3D2 = new Point3D();
    Point3D Points = new Point3D();
    if (this.Selected.Count <= 0)
      return;
    int num = -1;
    StartEndType startEndType = StartEndType.Start;
    this.UndoBuffer();
    for (int index1 = 0; index1 <= this.Selected.Count - 1; ++index1)
    {
      if (this.Selected[index1].EntityIndex >= 0)
      {
        buEntity mainEntity = this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex];
        buEntity buEntity = (buEntity) null;
        if (this.Selected[index1].CatchPosition == StartMiddleEndType.Start)
        {
          point3D1 = new Point3D(this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].StartPoint.X, this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].StartPoint.Y);
          point3D2 = new Point3D(this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].EndPoint.X, this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].EndPoint.Y);
        }
        if (this.Selected[index1].CatchPosition == StartMiddleEndType.End)
        {
          point3D1 = new Point3D(this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].EndPoint.X, this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].EndPoint.Y);
          point3D2 = new Point3D(this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].StartPoint.X, this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].StartPoint.Y);
        }
        for (int index2 = 0; index2 <= this.SewingBase.MainEntityList.Count - 1; ++index2)
        {
          if (index2 != this.Selected[index1].EntityIndex)
          {
            if (buCompare5.EQ(point3D2, this.SewingBase.MainEntityList[index2].StartPoint))
            {
              num = index2;
              startEndType = StartEndType.Start;
              buEntity = this.SewingBase.MainEntityList[index2];
              Points = new Point3D(this.SewingBase.MainEntityList[index2].StartPoint.X, this.SewingBase.MainEntityList[index2].StartPoint.Y);
            }
            else if (buCompare5.EQ(point3D2, this.SewingBase.MainEntityList[index2].EndPoint))
            {
              num = index2;
              startEndType = StartEndType.End;
              buEntity = this.SewingBase.MainEntityList[index2];
              Points = new Point3D(this.SewingBase.MainEntityList[index2].EndPoint.X, this.SewingBase.MainEntityList[index2].EndPoint.Y);
            }
          }
        }
        clsInit.cVector5.Rotate(point3D1, (double) RotateDegree, Vector3D.AxisZ, ref mainEntity);
        clsInit.cVector5.Rotate(point3D1, (double) RotateDegree, Plane.XY, ref Points);
        if (num >= 0 & buEntity != null)
        {
          if (startEndType == StartEndType.Start)
            buEntity.StartPoint = Points;
          if (startEndType == StartEndType.End)
            buEntity.EndPoint = Points;
          if (buEntity is buLine)
            buEntity.Update(buEntityUpdateType.Line);
          if (buEntity is buArc)
            buEntity.Update(buEntityUpdateType.Arc3Point3D);
        }
        if (this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex] is buLine)
          this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Update(buEntityUpdateType.Line);
        if (this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex] is buArc)
          this.SewingBase.MainEntityList[this.Selected[index1].EntityIndex].Update(buEntityUpdateType.Arc3Point3D);
      }
    }
    clsSewing.varSewingRunSettings.RotateDegree = Math.Abs(Convert.ToDouble(RotateDegree.ToString()));
    this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
    this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
  }

  public void CreateSewingTableList(
    SewingCompanies Company,
    SewingModel Model,
    ref SewingMain SewingBase,
    ref List<SewingJobItem> SewingTableList)
  {
    if (Company == SewingCompanies.Yesim && Model == SewingModel.YesimModel1)
      this.CreateSewingTableListAsYesimModel1(ref SewingBase, ref SewingTableList);
    this.JobUpdate();
  }

  public void CreateSewingJobItem(
    ref SewingJobItem S,
    int i,
    int j,
    SewingInfo SewInfo,
    double StartX = 0.0,
    double StartY = 0.0,
    bool AddStartPosition = false)
  {
    S.StitchStep = SewInfo.StitchLengt;
    S.HeadSpeed = SewInfo.HeadSpeed;
    S.StitchedWay = SewInfo.isStitchDrawing;
    S.FootHeight = SewInfo.Vertex[j].FootHeight;
    if (SewInfo.Vertex[j].Speed > 0.0)
      S.HeadSpeed = SewInfo.Vertex[j].Speed;
    S.PositionX = SewInfo.Vertex[j].Point.X + SewInfo.Vertex[j].DeltaX;
    S.PositionY = SewInfo.Vertex[j].Point.Y + SewInfo.Vertex[j].DeltaY;
    if (i == 0 & j == 0 & AddStartPosition)
    {
      S.PositionX = StartX;
      S.PositionY = StartY;
    }
    S.Style = SewInfo.Style;
    if (SewInfo.Vertex[j].Codes.Count > 0)
      S.Code1 = (int) SewInfo.Vertex[j].Codes[0].Codes;
    if (SewInfo.Vertex[j].Codes.Count > 1)
      S.Code2 = (int) SewInfo.Vertex[j].Codes[1].Codes;
    if (SewInfo.Vertex[j].Codes.Count > 2)
      S.Code3 = (int) SewInfo.Vertex[j].Codes[2].Codes;
    if (SewInfo.Vertex[j].Codes.Count > 3)
      S.Code4 = (int) SewInfo.Vertex[j].Codes[3].Codes;
    if (SewInfo.Vertex[j].Codes.Count <= 4)
      return;
    S.Code5 = (int) SewInfo.Vertex[j].Codes[4].Codes;
  }

  public void MoveTouchEntities(int IndexNoApply, Point3D pntCatch, double X, double Y)
  {
    for (int index1 = 0; index1 <= this.SewingBase.MainEntityList.Count - 1; ++index1)
    {
      if (index1 != IndexNoApply)
      {
        bool flag = false;
        if (buCompare5.EQ(pntCatch, this.SewingBase.MainEntityList[index1].StartPoint))
        {
          this.SewingBase.MainEntityList[index1].StartPoint.X += X;
          this.SewingBase.MainEntityList[index1].StartPoint.Y += Y;
          flag = true;
        }
        else if (buCompare5.EQ(pntCatch, this.SewingBase.MainEntityList[index1].EndPoint))
        {
          this.SewingBase.MainEntityList[index1].EndPoint.X += X;
          this.SewingBase.MainEntityList[index1].EndPoint.Y += Y;
          flag = true;
        }
        for (int index2 = 0; index2 <= this.SewingBase.MainEntityList[index1].Sewing.Vertex.Count - 1; ++index2)
        {
          if (buCompare5.EQ(pntCatch, this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Point))
          {
            this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Point.X += X;
            this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Point.Y += Y;
            flag = true;
          }
        }
        if (flag)
        {
          if (this.SewingBase.MainEntityList[index1] is buLine)
            this.SewingBase.MainEntityList[index1].Update(buEntityUpdateType.Line);
          if (this.SewingBase.MainEntityList[index1] is buArc)
            this.SewingBase.MainEntityList[index1].Update(buEntityUpdateType.Arc3Point3D);
        }
      }
    }
  }

  public void UndoGetBack()
  {
    if (this.UndoList.Count <= 0)
      return;
    clsInit.appEditor.Reset();
    this.SewingBase = new SewingMain(this.UndoList[this.UndoList.Count - 1]);
    this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
    this.UndoList.RemoveAt(this.UndoList.Count - 1);
  }

  public void UndoBuffer()
  {
    if (this.UndoList.Count > 20)
      this.UndoList.RemoveAt(0);
    if (this.SewingBase.MainEntityList.Count <= 0)
      return;
    this.UndoList.Add(new SewingMain(this.SewingBase));
  }

  public void JobTree_AfterSelect(object sender, TreeViewEventArgs e)
  {
    TreeNodeSettings selectedNode = (TreeNodeSettings) ((TreeView) sender).SelectedNode;
    this.cmdTree = "";
    switch (selectedNode.Command)
    {
      case "entity":
        this.selectedEntIndex = selectedNode.ClassSubIndex;
        this.selectedVertexIndex = selectedNode.ClassSubSubIndex;
        this.cmdTree = selectedNode.Command;
        break;
      case "startlock":
        this.selectedEntIndex = selectedNode.ClassSubIndex;
        this.selectedVertexIndex = selectedNode.ClassSubSubIndex;
        this.cmdTree = selectedNode.Command;
        break;
      case "endlock":
        this.selectedEntIndex = selectedNode.ClassSubIndex;
        this.selectedVertexIndex = selectedNode.ClassSubSubIndex;
        this.cmdTree = selectedNode.Command;
        break;
      case "punterez":
        this.selectedEntIndex = selectedNode.ClassSubIndex;
        this.selectedVertexIndex = selectedNode.ClassSubSubIndex;
        this.cmdTree = selectedNode.Command;
        break;
      case "vertex":
        this.selectedEntIndex = selectedNode.ClassSubIndex;
        this.selectedVertexIndex = selectedNode.ClassSubSubIndex;
        this.cmdTree = selectedNode.Command;
        break;
      case "codes":
        this.selectedEntIndex = selectedNode.ClassSubIndex;
        this.selectedVertexIndex = selectedNode.ClassSubSubIndex;
        this.cmdTree = selectedNode.Command;
        break;
    }
    clsItem.frmEditor.viewport.Invalidate();
  }

  public void JobUpdate()
  {
    if (clsItem.frmEditor == null || clsSewing.itemTreeView == null)
      return;
    clsSewing.itemTreeView.Nodes.Clear();
    TreeNodeSettings treeNodeSettings1 = new TreeNodeSettings("sewing");
    treeNodeSettings1.ImageIndex = 0;
    treeNodeSettings1.SelectedImageIndex = 0;
    treeNodeSettings1.Tag = (object) "-1";
    treeNodeSettings1.ClassIndex = 0;
    treeNodeSettings1.ClassSubIndex = -1;
    treeNodeSettings1.ClassSubSubIndex = -1;
    treeNodeSettings1.Command = "sewing";
    treeNodeSettings1.Name = "sewing";
    treeNodeSettings1.Info = "sewing";
    treeNodeSettings1.Index = 0;
    treeNodeSettings1.Checked = false;
    for (int index1 = 0; index1 <= this.SewingBase.MainEntityList.Count - 1; ++index1)
    {
      TreeNodeSettings treeNodeSettings2 = new TreeNodeSettings("entity");
      treeNodeSettings2.Tag = (object) "-1";
      treeNodeSettings2.ClassIndex = 0;
      treeNodeSettings2.ClassSubIndex = index1;
      treeNodeSettings2.ClassSubSubIndex = -1;
      treeNodeSettings2.Command = "entity";
      treeNodeSettings2.Name = "entity" + index1.ToString();
      treeNodeSettings2.Info = "entity" + index1.ToString();
      treeNodeSettings2.Index = 0;
      treeNodeSettings2.Checked = false;
      TreeNodeSettings node1 = treeNodeSettings2;
      node1.ImageIndex = clsInit.cSewing.TreeJobImageIndex(this.SewingBase.MainEntityList[index1]);
      node1.SelectedImageIndex = clsInit.cSewing.TreeJobImageIndex(this.SewingBase.MainEntityList[index1]);
      node1.Text = clsInit.cSewing.TreeJobDefination(this.SewingBase.MainEntityList[index1]);
      if (this.SewingBase.MainEntityList[index1].Sewing.StartStitchCount > 0)
      {
        TreeNodeSettings treeNodeSettings3 = new TreeNodeSettings("startlock");
        treeNodeSettings3.Tag = (object) "-1";
        treeNodeSettings3.ClassIndex = 0;
        treeNodeSettings3.ClassSubIndex = index1;
        treeNodeSettings3.ClassSubSubIndex = -1;
        treeNodeSettings3.Command = "startlock";
        treeNodeSettings3.Name = "startlock" + index1.ToString();
        treeNodeSettings3.Info = "startlock" + index1.ToString();
        treeNodeSettings3.Index = 0;
        treeNodeSettings3.Checked = false;
        TreeNodeSettings node2 = treeNodeSettings3;
        node2.ImageIndex = 5;
        node2.SelectedImageIndex = 5;
        node2.Text = $"{buLangTranslate.preDef.Start} {buLangTranslate.preDef.Lock} {buLangTranslate.preDef.Stitch} : {this.SewingBase.MainEntityList[index1].Sewing.StartStitchCount.ToString()}";
        node1.Nodes.Add((TreeNode) node2);
      }
      if (this.SewingBase.MainEntityList[index1].Sewing.EndStitchCount > 0)
      {
        TreeNodeSettings treeNodeSettings4 = new TreeNodeSettings("endlock");
        treeNodeSettings4.Tag = (object) "-1";
        treeNodeSettings4.ClassIndex = 0;
        treeNodeSettings4.ClassSubIndex = index1;
        treeNodeSettings4.ClassSubSubIndex = -1;
        treeNodeSettings4.Command = "endlock";
        treeNodeSettings4.Name = "endlock" + index1.ToString();
        treeNodeSettings4.Info = "endlock" + index1.ToString();
        treeNodeSettings4.Index = 0;
        treeNodeSettings4.Checked = false;
        TreeNodeSettings node3 = treeNodeSettings4;
        node3.ImageIndex = 5;
        node3.SelectedImageIndex = 5;
        node3.Text = $"{buLangTranslate.preDef.End} {buLangTranslate.preDef.Lock} {buLangTranslate.preDef.Stitch} : {this.SewingBase.MainEntityList[index1].Sewing.StartStitchCount.ToString()}";
        node1.Nodes.Add((TreeNode) node3);
      }
      for (int index2 = 0; index2 <= this.SewingBase.MainEntityList[index1].Sewing.Vertex.Count - 1; ++index2)
      {
        if (this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Punterez != null)
        {
          SewingVertex sewingVertex = this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2];
          TreeNodeSettings treeNodeSettings5 = new TreeNodeSettings("punterez");
          treeNodeSettings5.Tag = (object) "-1";
          treeNodeSettings5.ClassIndex = 0;
          treeNodeSettings5.ClassSubIndex = index1;
          treeNodeSettings5.ClassSubSubIndex = index2;
          treeNodeSettings5.Command = "punterez";
          treeNodeSettings5.Name = "punterez" + index2.ToString();
          treeNodeSettings5.Info = "punterez" + index2.ToString();
          treeNodeSettings5.Index = 0;
          treeNodeSettings5.Checked = false;
          TreeNodeSettings node4 = treeNodeSettings5;
          node4.ImageIndex = 4;
          node4.SelectedImageIndex = 4;
          node4.Text = $"{buLangTranslate.preDef.Bartack} {buLangTranslate.preDef.Stitch}[ {index2.ToString()} ] : {buLangTranslate.preDef.Length}: {sewingVertex.Punterez.Length.ToString()} , {buLangTranslate.preDef.Width}: {sewingVertex.Punterez.Width.ToString()}";
          node1.Nodes.Add((TreeNode) node4);
        }
      }
      if (this.SewingBase.MainEntityList[index1].Sewing.Vertex.Count > 0)
      {
        TreeNodeSettings treeNodeSettings6 = new TreeNodeSettings("vertex");
        treeNodeSettings6.Tag = (object) "-1";
        treeNodeSettings6.ClassIndex = 0;
        treeNodeSettings6.ClassSubIndex = index1;
        treeNodeSettings6.Command = "vertex";
        treeNodeSettings6.Name = "vertex";
        treeNodeSettings6.Info = this.SewingBase.MainEntityList[index1].Sewing.Vertex.Count.ToString();
        treeNodeSettings6.Index = 0;
        treeNodeSettings6.Checked = false;
        TreeNodeSettings node5 = treeNodeSettings6;
        node5.ImageIndex = 4;
        node5.SelectedImageIndex = 4;
        node5.Text = $"{buLangTranslate.preDef.Vertex} : {this.SewingBase.MainEntityList[index1].Sewing.Vertex.Count.ToString()}";
        for (int index3 = 0; index3 <= this.SewingBase.MainEntityList[index1].Sewing.Vertex.Count - 1; ++index3)
        {
          SewingVertex sewingVertex = this.SewingBase.MainEntityList[index1].Sewing.Vertex[index3];
          TreeNodeSettings treeNodeSettings7 = new TreeNodeSettings("vertexnode");
          treeNodeSettings7.Tag = (object) "-1";
          treeNodeSettings7.ClassIndex = 0;
          treeNodeSettings7.ClassSubIndex = index1;
          treeNodeSettings7.ClassSubSubIndex = index3;
          treeNodeSettings7.Command = "vertexnode";
          treeNodeSettings7.Name = "vertexnode" + index3.ToString();
          treeNodeSettings7.Info = $"{sewingVertex.Point.X.ToString()};{sewingVertex.Point.Y.ToString()}";
          treeNodeSettings7.Index = 0;
          treeNodeSettings7.Checked = false;
          TreeNodeSettings node6 = treeNodeSettings7;
          node6.ImageIndex = 4;
          node6.SelectedImageIndex = 4;
          node6.Text = $"{buLangTranslate.preDef.Vertex} - X: {sewingVertex.Point.X.ToString("f2")}Y: {sewingVertex.Point.Y.ToString("f2")}";
          if (sewingVertex.Codes.Count > 0)
            node6.Text = $"{node6.Text} , {sewingVertex.Codes.Count.ToString()}";
          for (int index4 = 0; index4 <= sewingVertex.Codes.Count - 1; ++index4)
          {
            TreeNodeSettings treeNodeSettings8 = new TreeNodeSettings("codes");
            treeNodeSettings8.Tag = (object) "-1";
            treeNodeSettings8.ClassIndex = 0;
            treeNodeSettings8.ClassSubIndex = index1;
            treeNodeSettings8.ClassSubSubIndex = index3;
            treeNodeSettings8.ClassSubSubSubIndex = index4;
            treeNodeSettings8.Command = "codes";
            treeNodeSettings8.Name = "codes" + index3.ToString();
            treeNodeSettings8.Info = Convert.ToInt32((object) sewingVertex.Codes[index4].Codes).ToString();
            treeNodeSettings8.Index = 0;
            treeNodeSettings8.Checked = false;
            TreeNodeSettings node7 = treeNodeSettings8;
            node7.ImageIndex = 6;
            node7.SelectedImageIndex = 6;
            node7.Text = $"{buLangTranslate.preDef.Codes}: {sewingVertex.Codes[index4].Codes.ToString()}";
            node6.Nodes.Add((TreeNode) node7);
          }
          node5.Nodes.Add((TreeNode) node6);
        }
        node1.Nodes.Add((TreeNode) node5);
      }
      clsSewing.itemTreeView.Nodes.Add((TreeNode) node1);
    }
  }

  public void doAddEntities(List<Entity> refEntities)
  {
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      buEntity copiedEntity = (buEntity) null;
      buEntity.Copy(refEntities[index], ref copiedEntity);
      if (copiedEntity != null)
      {
        copiedEntity.Sewing = new SewingInfo();
        copiedEntity.Sewing.StitchLengt = clsSewing.varSewingSettings.defaultStitchLength;
        copiedEntity.Sewing.isStitchDrawing = true;
        this.SewingBase.MainEntityList.Add(copiedEntity);
      }
    }
    if (refEntities.Count <= 0)
      return;
    this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
    this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
  }

  public void doGetScreenEntititesFromMainEntities(
    List<buEntity> MainList,
    ref List<Entity> screenEntities)
  {
    screenEntities.Clear();
    screenEntities = new List<Entity>();
    for (int index1 = 0; index1 <= MainList.Count - 1; ++index1)
    {
      if (MainList[index1].Sewing.Vertex.Count == 0)
      {
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(MainList[index1], ref copiedEntity);
        if (copiedEntity != null)
        {
          copiedEntity.LayerName = "Drawing";
          copiedEntity.Color = Color.Green;
          screenEntities.Add(copiedEntity);
        }
      }
      else
      {
        for (int index2 = 0; index2 <= MainList[index1].Sewing.Vertex.Count - 1; ++index2)
        {
          CustomData customData = new CustomData();
          if (index2 > 0)
          {
            Line line = new Line(MainList[index1].Sewing.Vertex[index2 - 1].Point, MainList[index1].Sewing.Vertex[index2].Point);
            line.LineWeight = 1f;
            line.LayerName = "Drawing";
            line.Color = Color.Red;
            line.ColorMethod = colorMethodType.byEntity;
            line.EntityData = (object) new CustomData()
            {
              RefIndex = index1
            };
            screenEntities.Add((Entity) line);
          }
          devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(MainList[index1].Sewing.Vertex[index2].Point);
          point.LineWeight = 1f;
          point.Color = Color.Blue;
          point.ColorMethod = colorMethodType.byEntity;
          point.LayerName = "Point";
          point.EntityData = (object) new CustomData()
          {
            RefIndex = index1
          };
          screenEntities.Add((Entity) point);
        }
      }
    }
  }

  public bool doGetVertexIndex(
    Point3D Pnt,
    ref List<SewingPickType> PickList,
    ref Point3D pntCatch)
  {
    PickList.Clear();
    if (this.isPointLayerVisible())
    {
      for (int index1 = 0; index1 <= this.SewingBase.MainEntityList.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= this.SewingBase.MainEntityList[index1].Sewing.Vertex.Count - 1; ++index2)
        {
          Point3D Pnt1 = new Point3D(this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Point.X + this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].DeltaX, this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Point.Y + this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].DeltaY);
          if (buCompare5.EQ(Pnt, Pnt1, clsSewing.varSewingSettings.CatchResolution) & this.SewingBase.MainEntityList[index1].Sewing.isStitchDrawing)
          {
            PickList.Add(new SewingPickType()
            {
              EntityIndex = index1,
              VertexIndex = index2,
              PickType = SewingPickClickType.Vertex
            });
            pntCatch = buVector5.ToPoint3D(Pnt1);
          }
        }
      }
    }
    if (PickList.Count == 0)
    {
      for (int index = 0; index <= this.SewingBase.MainEntityList.Count - 1; ++index)
      {
        if (buCompare5.EQ(Pnt, this.SewingBase.MainEntityList[index].StartPoint, clsSewing.varSewingSettings.CatchResolution))
          PickList.Add(new SewingPickType()
          {
            EntityIndex = index,
            VertexIndex = -1,
            PickType = SewingPickClickType.Entity,
            EntitySelectType = SewingPickEntitySelectType.StartPoint
          });
        else if (buCompare5.EQ(Pnt, this.SewingBase.MainEntityList[index].EndPoint, clsSewing.varSewingSettings.CatchResolution))
          PickList.Add(new SewingPickType()
          {
            EntityIndex = index,
            VertexIndex = -1,
            PickType = SewingPickClickType.Entity,
            EntitySelectType = SewingPickEntitySelectType.EndPoint
          });
      }
    }
    return PickList.Count > 0;
  }

  public bool doGetVertexIndex(Point3D Pnt, ref List<SewingPickType> PickList)
  {
    Point3D pntCatch = new Point3D();
    return this.doGetVertexIndex(Pnt, ref PickList, ref pntCatch);
  }

  public void doCopyVertexPropertiesFromOld(
    ref List<buEntity> mainEntities,
    int EntityIndex,
    List<SewingVertex> OldVertex,
    bool CopyCodes = true)
  {
    if (!(OldVertex.Count > 0 & mainEntities[EntityIndex].Sewing.Vertex.Count > 0))
      return;
    if (CopyCodes)
      mainEntities[EntityIndex].Sewing.Vertex[0].Codes.Clear();
    mainEntities[EntityIndex].Sewing.Vertex[0].DeltaX = OldVertex[0].DeltaX;
    mainEntities[EntityIndex].Sewing.Vertex[0].DeltaY = OldVertex[0].DeltaY;
    if (CopyCodes)
    {
      for (int index = 0; index <= OldVertex[0].Codes.Count - 1; ++index)
        mainEntities[EntityIndex].Sewing.Vertex[0].Codes.Add(new SewingCode(OldVertex[0].Codes[index]));
    }
    mainEntities[EntityIndex].Sewing.Vertex[mainEntities[EntityIndex].Sewing.Vertex.Count - 1].Codes.Clear();
    mainEntities[EntityIndex].Sewing.Vertex[mainEntities[EntityIndex].Sewing.Vertex.Count - 1].DeltaX = OldVertex[OldVertex.Count - 1].DeltaX;
    mainEntities[EntityIndex].Sewing.Vertex[mainEntities[EntityIndex].Sewing.Vertex.Count - 1].DeltaY = OldVertex[OldVertex.Count - 1].DeltaY;
    for (int index = 0; index <= OldVertex[OldVertex.Count - 1].Codes.Count - 1; ++index)
      mainEntities[EntityIndex].Sewing.Vertex[mainEntities[EntityIndex].Sewing.Vertex.Count - 1].Codes.Add(new SewingCode(OldVertex[OldVertex.Count - 1].Codes[index]));
    for (int index1 = 1; index1 <= OldVertex.Count - 2; ++index1)
    {
      if (index1 <= mainEntities[EntityIndex].Sewing.Vertex.Count - 2)
      {
        if (CopyCodes)
          mainEntities[EntityIndex].Sewing.Vertex[index1].Codes.Clear();
        mainEntities[EntityIndex].Sewing.Vertex[index1].DeltaX = OldVertex[index1].DeltaX;
        mainEntities[EntityIndex].Sewing.Vertex[index1].DeltaY = OldVertex[index1].DeltaY;
        if (CopyCodes)
        {
          for (int index2 = 0; index2 <= OldVertex[index1].Codes.Count - 1; ++index2)
            mainEntities[EntityIndex].Sewing.Vertex[index1].Codes.Add(new SewingCode(OldVertex[index1].Codes[index2]));
        }
      }
    }
  }

  public void doSetProperties(Point3D Pnt)
  {
    for (int index1 = 0; index1 <= this.SewingBase.MainEntityList.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= this.SewingBase.MainEntityList[index1].Sewing.Vertex.Count - 1; ++index2)
      {
        Point3D point3D = new Point3D(this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Point.X + this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].DeltaX, this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Point.Y + this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].DeltaY);
        if (buCompare5.EQ(Pnt, point3D, clsSewing.varSewingSettings.CatchResolution))
        {
          F_SewingSetProperties sewingSetProperties = new F_SewingSetProperties();
          Array values = Enum.GetValues(typeof (SewingCodes));
          for (int index3 = 0; index3 <= values.Length - 1; ++index3)
            sewingSetProperties.AllCommands.Add(values.GetValue(index3).ToString());
          for (int index4 = 0; index4 <= this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Codes.Count - 1; ++index4)
            sewingSetProperties.ActualCommands.Add(this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Codes[index4].Codes.ToString());
          sewingSetProperties.Init();
          int num = (int) sewingSetProperties.ShowDialog();
          if (sewingSetProperties.Properties.Result == DialogResult.OK)
          {
            this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Codes.Clear();
            for (int index5 = 0; index5 <= sewingSetProperties.ActualCommands.Count - 1; ++index5)
            {
              if (sewingSetProperties.ActualCommands[index5].Trim().Length > 0)
                this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Codes.Add(new SewingCode()
                {
                  Codes = (SewingCodes) Enum.Parse(typeof (SewingCodes), sewingSetProperties.ActualCommands[index5].Trim())
                });
            }
          }
        }
      }
    }
  }

  public void doCreateSewingLayers(int indexPage)
  {
    if (!(ccVars.Pages.Count > 0 & indexPage >= 0 & indexPage <= ccVars.Pages.Count - 1))
      return;
    ccVars.Pages[indexPage].Layers.Clear();
    ccVars.Pages[indexPage].Layers.Add(new LayerBase5(clsSewing.varSewingSettings.layerNameDrawing)
    {
      LayerColor = clsSewing.varSewingSettings.colorDrawing,
      LayerThickness = (float) clsSewing.varSewingSettings.thicknessDrawing
    });
    ccVars.Pages[indexPage].Layers.Add(new LayerBase5(clsSewing.varSewingSettings.layerNamePoint)
    {
      LayerColor = clsSewing.varSewingSettings.colorPoints,
      LayerThickness = (float) clsSewing.varSewingSettings.thicknessPoints
    });
    ccVars.Pages[indexPage].Layers.Add(new LayerBase5(clsSewing.varSewingSettings.layerNameGeneral)
    {
      LayerColor = clsSewing.varSewingSettings.colorGeneral,
      LayerThickness = (float) clsSewing.varSewingSettings.thicknessGeneral
    });
    ccVars.Pages[indexPage].Layers.Add(new LayerBase5(clsSewing.varSewingSettings.layerNameOriginal)
    {
      LayerColor = clsSewing.varSewingSettings.colorOriginalDrawing,
      LayerThickness = (float) clsSewing.varSewingSettings.thicknessOriginalDrawing
    });
    ccVars.Pages[indexPage].Layers.Add(new LayerBase5(clsSewing.varSewingSettings.layerNameDrawingPoints)
    {
      LayerColor = clsSewing.varSewingSettings.colorDrawingPoints,
      LayerThickness = (float) clsSewing.varSewingSettings.thicknessDrawingPoints
    });
    ccVars.Pages[indexPage].Layers.Add(new LayerBase5(clsSewing.varSewingSettings.layerNameDrawingDevided)
    {
      LayerColor = clsSewing.varSewingSettings.colorDrawingDevided,
      LayerThickness = (float) clsSewing.varSewingSettings.thicknessDrawingDevided
    });
    ccVars.Pages[indexPage].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(ccVars.Pages[ccVars.PageIndex].Layers);
  }

  public void doSortMainEntitiesByRefPoint(
    Point3D refPoint,
    SortingNextGroupFindRulesType NextRules = SortingNextGroupFindRulesType.ClosestLength)
  {
    SortbuSettings Settings = new SortbuSettings();
    List<buEntity> SortedEntities = new List<buEntity>();
    Settings.Option.NextGroupRules = NextRules;
    clsInit.cVector5.SortEntitiesByRefPoint(refPoint, ref this.SewingBase.MainEntityList, Settings, ref SortedEntities);
    clsItem.frmEditor.SortingDone = false;
    if (SortedEntities.Count > 0)
    {
      this.SewingBase.MainEntityList.Clear();
      this.SewingBase.MainEntityList = new List<buEntity>();
      for (int index = 0; index <= SortedEntities.Count - 1; ++index)
      {
        if (SortedEntities[index].Sewing != null)
        {
          SewingInfo sewing = SortedEntities[index].Sewing;
          if (clsSewing.Company == SewingCompanies.Yesim && clsSewing.Model == SewingModel.YesimModel1)
            this.RemoveStitchEndCommand(ref sewing);
        }
        if (SortedEntities[index].GetType() == typeof (buUpperLine))
        {
          buLine buLine = new buLine(SortedEntities[index].StartPoint, SortedEntities[index].EndPoint);
          buLine.Sewing = new SewingInfo();
          buLine.Sewing.isStitchDrawing = false;
          buLine.Sewing.Vertex.Add(new SewingVertex(SortedEntities[index].StartPoint));
          buLine.Sewing.Vertex.Add(new SewingVertex(SortedEntities[index].EndPoint));
          this.SewingBase.MainEntityList.Add((buEntity) buLine);
        }
        else
          this.SewingBase.MainEntityList.Add(buEntity.Copy(SortedEntities[index]));
      }
      clsItem.frmEditor.SortingDone = true;
    }
    if (clsSewing.varSewingSettings.DevideEntitiesAfterSort | !this.SewingBase.isSorted)
      this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
    this.SewingBase.isSorted = true;
    clsInit.appEditor.Reset();
    clsInit.appEditor.action = actionTypeBU.None;
  }

  public void doDevideEntitiesByLength(ref List<buEntity> mainEntities, SewingDevideOptions Options)
  {
    int num1 = 0;
    int num2 = mainEntities.Count - 1;
    if (Options.StartIndex >= 0)
      num1 = Options.StartIndex;
    if (Options.EndIndex >= 0)
      num2 = Options.EndIndex;
    for (int index1 = num1; index1 <= num2; ++index1)
    {
      buEntity refEntity1 = mainEntities[index1];
      List<SewingVertex> Copied1 = new List<SewingVertex>();
      if (refEntity1.Sewing.Vertex.Count > 0)
        SewingVertex.Copy(refEntity1.Sewing.Vertex, ref Copied1);
      if (refEntity1.Sewing != null)
      {
        if (refEntity1.Sewing.isStitchDrawing)
        {
          if (refEntity1 is buLinearPath)
          {
            List<Point3D> Points = new List<Point3D>();
            for (int index2 = 1; index2 <= refEntity1.Vertices.Count - 1; ++index2)
            {
              List<Point3D> pntDevided = new List<Point3D>();
              double num3 = Point3D.Distance(refEntity1.Vertices[index2 - 1], refEntity1.Vertices[index2]);
              buEntity refEntity2 = (buEntity) new buLine(refEntity1.Vertices[index2 - 1], refEntity1.Vertices[index2]);
              double DevideLength = refEntity1.Sewing.StitchLengt;
              if (Copied1.Count > 1 & !Options.ProtectEntityStitchLen)
              {
                Entity copiedEntity = (Entity) null;
                buEntity.Copy(refEntity1, ref copiedEntity);
                Convert.ToInt32(num3 / refEntity1.Sewing.StitchLengt);
                DevideLength = ((ICurve) copiedEntity).Length() / (double) (Copied1.Count - 1);
              }
              clsInit.cVector5.EntityDevideByCamDir(refEntity2, DevideLength, ref pntDevided);
              Points.AddRange((IEnumerable<Point3D>) pntDevided);
            }
            List<SewingVertex> Copied2 = new List<SewingVertex>();
            SewingVertex.Copy(refEntity1.Sewing.Vertex, ref Copied2);
            refEntity1.Sewing.Vertex.Clear();
            refEntity1.Sewing.Vertex = new List<SewingVertex>();
            clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
            if (Points.Count > 0)
            {
              for (int index3 = 0; index3 <= Points.Count - 1; ++index3)
                refEntity1.Sewing.Vertex.Add(new SewingVertex(Points[index3]));
            }
            if (Copied2.Count <= Points.Count && Copied2.Count <= Points.Count && Copied2.Count > 0 & refEntity1.Sewing.Vertex.Count > 0)
            {
              if (Copied2.Count == 1)
              {
                refEntity1.Sewing.Vertex[0].DeltaX = Copied2[0].DeltaX;
                refEntity1.Sewing.Vertex[0].DeltaY = Copied2[0].DeltaY;
                for (int index4 = 0; index4 <= Copied2[0].Codes.Count - 1; ++index4)
                  refEntity1.Sewing.Vertex[0].Codes.Add(new SewingCode(Copied2[0].Codes[index4]));
              }
              else
              {
                refEntity1.Sewing.Vertex[0].DeltaX = Copied2[0].DeltaX;
                refEntity1.Sewing.Vertex[0].DeltaY = Copied2[0].DeltaY;
                for (int index5 = 0; index5 <= Copied2[0].Codes.Count - 1; ++index5)
                  refEntity1.Sewing.Vertex[0].Codes.Add(new SewingCode(Copied2[0].Codes[index5]));
                refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].DeltaX = Copied2[Copied2.Count - 1].DeltaX;
                refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].DeltaY = Copied2[Copied2.Count - 1].DeltaY;
                for (int index6 = 0; index6 <= Copied2[Copied2.Count - 1].Codes.Count - 1; ++index6)
                  refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].Codes.Add(new SewingCode(Copied2[Copied2.Count - 1].Codes[index6]));
              }
            }
          }
          else
          {
            List<Point3D> pntDevided = new List<Point3D>();
            double DevideLength = refEntity1.Sewing.StitchLengt;
            if (Copied1.Count > 1 & !Options.ProtectEntityStitchLen)
            {
              Entity copiedEntity = (Entity) null;
              buEntity.Copy(refEntity1, ref copiedEntity);
              int num4 = Convert.ToInt32(((ICurve) copiedEntity).Length() / refEntity1.Sewing.StitchLengt);
              if (num4 < 2)
                num4 = 2;
              DevideLength = ((ICurve) copiedEntity).Length() / (double) (num4 - 1);
            }
            clsInit.cVector5.EntityDevideByCamDir(refEntity1, DevideLength, ref pntDevided);
            List<SewingVertex> Copied3 = new List<SewingVertex>();
            SewingVertex.Copy(refEntity1.Sewing.Vertex, ref Copied3);
            refEntity1.Sewing.Vertex.Clear();
            refEntity1.Sewing.Vertex = new List<SewingVertex>();
            for (int index7 = 0; index7 <= pntDevided.Count - 1; ++index7)
            {
              if (Copied3.Count == 0)
                refEntity1.Sewing.Vertex.Add(new SewingVertex(pntDevided[index7]));
            }
            if (Copied3.Count > 0)
            {
              if (Copied3.Count > pntDevided.Count)
              {
                SewingVertex sewingVertex1 = new SewingVertex(pntDevided[0]);
                for (int index8 = 0; index8 <= pntDevided.Count - 1; ++index8)
                {
                  SewingVertex sewingVertex2 = new SewingVertex(pntDevided[index8]);
                  if (index8 < pntDevided.Count - 1)
                  {
                    if (Copied3[index8].Punterez != null)
                      sewingVertex2.Punterez = new SewingPunteriz(Copied3[index8].Punterez);
                    sewingVertex2.FootHeight = Copied3[index8].FootHeight;
                    sewingVertex2.Speed = Copied3[index8].Speed;
                    sewingVertex2.DeltaX = Copied3[index8].DeltaX;
                    sewingVertex2.DeltaY = Copied3[index8].DeltaY;
                    for (int index9 = 0; index9 <= Copied3[index8].Codes.Count - 1; ++index9)
                      sewingVertex2.Codes.Add(Copied3[index8].Codes[index9]);
                  }
                  else
                  {
                    if (Copied3[Copied3.Count - 1].Punterez != null)
                      sewingVertex2.Punterez = new SewingPunteriz(Copied3[Copied3.Count - 1].Punterez);
                    sewingVertex2.FootHeight = Copied3[Copied3.Count - 1].FootHeight;
                    sewingVertex2.Speed = Copied3[Copied3.Count - 1].Speed;
                    sewingVertex2.DeltaX = Copied3[Copied3.Count - 1].DeltaX;
                    sewingVertex2.DeltaY = Copied3[Copied3.Count - 1].DeltaY;
                    for (int index10 = 0; index10 <= Copied3[Copied3.Count - 1].Codes.Count - 1; ++index10)
                      sewingVertex2.Codes.Add(Copied3[Copied3.Count - 1].Codes[index10]);
                  }
                  refEntity1.Sewing.Vertex.Add(sewingVertex2);
                }
              }
              else if (Copied3.Count <= pntDevided.Count && Copied3.Count > 0)
              {
                SewingVertex sewingVertex3 = new SewingVertex(pntDevided[0]);
                sewingVertex3.FootHeight = Copied3[0].FootHeight;
                sewingVertex3.Speed = Copied3[0].Speed;
                sewingVertex3.DeltaX = Copied3[0].DeltaX;
                sewingVertex3.DeltaY = Copied3[0].DeltaY;
                for (int index11 = 0; index11 <= Copied3[0].Codes.Count - 1; ++index11)
                  sewingVertex3.Codes.Add(Copied3[0].Codes[index11]);
                if (Copied3[0].Punterez != null)
                  sewingVertex3.Punterez = new SewingPunteriz(Copied3[0].Punterez);
                refEntity1.Sewing.Vertex.Add(sewingVertex3);
                for (int index12 = 1; index12 <= pntDevided.Count - 2; ++index12)
                {
                  SewingVertex sewingVertex4 = new SewingVertex(pntDevided[index12]);
                  if (index12 < Copied3.Count - 1)
                  {
                    sewingVertex4.DeltaX = Copied3[index12].DeltaX;
                    sewingVertex4.DeltaY = Copied3[index12].DeltaY;
                    sewingVertex4.FootHeight = Copied3[index12].FootHeight;
                    sewingVertex4.Speed = Copied3[index12].Speed;
                    if (Copied3[index12].Punterez != null)
                      sewingVertex4.Punterez = new SewingPunteriz(Copied3[index12].Punterez);
                    if (index12 < Copied3.Count - 1)
                    {
                      for (int index13 = 0; index13 <= Copied3[index12].Codes.Count - 1; ++index13)
                        sewingVertex4.Codes.Add(Copied3[index12].Codes[index13]);
                    }
                  }
                  else if (Options.ApplyNewLenUpToEnd & refEntity1.Sewing.Vertex.Count > 0)
                  {
                    sewingVertex4.DeltaX = refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].DeltaX;
                    sewingVertex4.DeltaY = refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].DeltaY;
                    sewingVertex4.FootHeight = refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].FootHeight;
                    sewingVertex4.Speed = refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].Speed;
                    if (refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].Punterez != null)
                      sewingVertex4.Punterez = new SewingPunteriz(refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].Punterez);
                  }
                  refEntity1.Sewing.Vertex.Add(sewingVertex4);
                }
                SewingVertex sewingVertex5 = new SewingVertex(pntDevided[pntDevided.Count - 1]);
                sewingVertex5.DeltaX = Copied3[Copied3.Count - 1].DeltaX;
                sewingVertex5.DeltaY = Copied3[Copied3.Count - 1].DeltaY;
                sewingVertex5.FootHeight = Copied3[Copied3.Count - 1].FootHeight;
                sewingVertex5.Speed = Copied3[Copied3.Count - 1].Speed;
                if (Copied3.Count > 1)
                {
                  for (int index14 = 0; index14 <= Copied3[Copied3.Count - 1].Codes.Count - 1; ++index14)
                    sewingVertex5.Codes.Add(Copied3[Copied3.Count - 1].Codes[index14]);
                }
                if (Copied3[Copied3.Count - 1].Punterez != null)
                  sewingVertex5.Punterez = new SewingPunteriz(Copied3[Copied3.Count - 1].Punterez);
                refEntity1.Sewing.Vertex.Add(sewingVertex5);
              }
            }
          }
        }
        else
        {
          List<SewingVertex> sewingVertexList = new List<SewingVertex>();
          for (int index15 = 0; index15 <= refEntity1.Sewing.Vertex.Count - 1; ++index15)
            sewingVertexList.Add(new SewingVertex(refEntity1.Sewing.Vertex[index15]));
          refEntity1.Sewing.Vertex = new List<SewingVertex>();
          if (refEntity1.sortDirection == entitySortDirection.Normal)
          {
            refEntity1.Sewing.Vertex.Add(new SewingVertex(refEntity1.StartPoint));
            refEntity1.Sewing.Vertex.Add(new SewingVertex(refEntity1.EndPoint));
          }
          else
          {
            refEntity1.Sewing.Vertex.Add(new SewingVertex(refEntity1.EndPoint));
            refEntity1.Sewing.Vertex.Add(new SewingVertex(refEntity1.StartPoint));
          }
          for (int index16 = 0; index16 <= sewingVertexList.Count - 1; ++index16)
          {
            for (int index17 = 0; index17 <= refEntity1.Sewing.Vertex.Count - 1; ++index17)
            {
              if (buCompare5.EQ(sewingVertexList[index16].Point, refEntity1.Sewing.Vertex[index17].Point) && sewingVertexList[index16].Codes.Count > 0)
              {
                for (int index18 = 0; index18 <= sewingVertexList[index16].Codes.Count - 1; ++index18)
                  refEntity1.Sewing.Vertex[index17].Codes.Add(sewingVertexList[index16].Codes[index18]);
              }
            }
          }
        }
      }
    }
  }

  public void doDevideEntities(ref List<buEntity> mainEntities, SewingDevideOptions Options)
  {
    List<Entity> screenDrawEntities = new List<Entity>();
    List<Entity> screenPointEntities = new List<Entity>();
    this.doDevideEntities(ref mainEntities, Options, ref screenDrawEntities, ref screenPointEntities);
  }

  public void doDevideEntities(
    ref List<buEntity> mainEntities,
    SewingDevideOptions Options,
    ref List<Entity> screenDrawEntities,
    ref List<Entity> screenPointEntities)
  {
    screenDrawEntities.Clear();
    screenDrawEntities = new List<Entity>();
    screenPointEntities.Clear();
    screenPointEntities = new List<Entity>();
    int num1 = 0;
    int num2 = mainEntities.Count - 1;
    if (Options.StartIndex >= 0)
      num1 = Options.StartIndex;
    if (Options.EndIndex >= 0)
      num2 = Options.EndIndex;
    for (int index1 = num1; index1 <= num2; ++index1)
    {
      buEntity refEntity1 = mainEntities[index1];
      List<SewingVertex> Copied1 = new List<SewingVertex>();
      if (refEntity1.Sewing.Vertex.Count > 0)
        SewingVertex.Copy(refEntity1.Sewing.Vertex, ref Copied1);
      if (refEntity1.Sewing != null)
      {
        if (refEntity1.Sewing.isStitchDrawing)
        {
          if (refEntity1 is buLinearPath)
          {
            List<Point3D> Points = new List<Point3D>();
            for (int index2 = 1; index2 <= refEntity1.Vertices.Count - 1; ++index2)
            {
              List<Point3D> pntDevided = new List<Point3D>();
              double num3 = Point3D.Distance(refEntity1.Vertices[index2 - 1], refEntity1.Vertices[index2]);
              buEntity refEntity2 = (buEntity) new buLine(refEntity1.Vertices[index2 - 1], refEntity1.Vertices[index2]);
              double DevideLength = refEntity1.Sewing.StitchLengt;
              if (Copied1.Count > 1 & !Options.ProtectEntityStitchLen)
              {
                Entity copiedEntity = (Entity) null;
                buEntity.Copy(refEntity1, ref copiedEntity);
                Convert.ToInt32(num3 / refEntity1.Sewing.StitchLengt);
                DevideLength = ((ICurve) copiedEntity).Length() / (double) (Copied1.Count - 1);
              }
              clsInit.cVector5.EntityDevideByCamDir(refEntity2, DevideLength, ref pntDevided);
              Points.AddRange((IEnumerable<Point3D>) pntDevided);
            }
            List<SewingVertex> Copied2 = new List<SewingVertex>();
            SewingVertex.Copy(refEntity1.Sewing.Vertex, ref Copied2);
            refEntity1.Sewing.Vertex.Clear();
            refEntity1.Sewing.Vertex = new List<SewingVertex>();
            clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
            if (Points.Count > 0)
            {
              for (int index3 = 0; index3 <= Points.Count - 1; ++index3)
              {
                CustomData customData = new CustomData();
                if (index3 > 0)
                {
                  Line line = new Line(Points[index3 - 1], Points[index3]);
                  line.LineWeight = (float) Options.DrawigThickness;
                  line.Color = Options.DrawingColor;
                  line.ColorMethod = colorMethodType.byEntity;
                  if (Options.DrawingLayerName.Length > 0)
                    line.LayerName = Options.DrawingLayerName;
                  line.EntityData = (object) new CustomData()
                  {
                    RefIndex = index1
                  };
                  screenDrawEntities.Add((Entity) line);
                }
                devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(Points[index3]);
                point.LineWeight = (float) Options.PointThickness;
                point.Color = Options.PointColor;
                point.ColorMethod = colorMethodType.byEntity;
                if (Options.PointLayerName.Length > 0)
                  point.LayerName = Options.PointLayerName;
                point.EntityData = (object) new CustomData()
                {
                  RefIndex = index1
                };
                screenPointEntities.Add((Entity) point);
                refEntity1.Sewing.Vertex.Add(new SewingVertex(Points[index3]));
              }
            }
            if (Copied2.Count <= Points.Count && Copied2.Count <= Points.Count && Copied2.Count > 0 & refEntity1.Sewing.Vertex.Count > 0)
            {
              if (Copied2.Count == 1)
              {
                refEntity1.Sewing.Vertex[0].DeltaX = Copied2[0].DeltaX;
                refEntity1.Sewing.Vertex[0].DeltaY = Copied2[0].DeltaY;
                for (int index4 = 0; index4 <= Copied2[0].Codes.Count - 1; ++index4)
                  refEntity1.Sewing.Vertex[0].Codes.Add(new SewingCode(Copied2[0].Codes[index4]));
              }
              else
              {
                refEntity1.Sewing.Vertex[0].DeltaX = Copied2[0].DeltaX;
                refEntity1.Sewing.Vertex[0].DeltaY = Copied2[0].DeltaY;
                for (int index5 = 0; index5 <= Copied2[0].Codes.Count - 1; ++index5)
                  refEntity1.Sewing.Vertex[0].Codes.Add(new SewingCode(Copied2[0].Codes[index5]));
                refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].DeltaX = Copied2[Copied2.Count - 1].DeltaX;
                refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].DeltaY = Copied2[Copied2.Count - 1].DeltaY;
                for (int index6 = 0; index6 <= Copied2[Copied2.Count - 1].Codes.Count - 1; ++index6)
                  refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].Codes.Add(new SewingCode(Copied2[Copied2.Count - 1].Codes[index6]));
              }
            }
          }
          else
          {
            List<Point3D> pntDevided = new List<Point3D>();
            double DevideLength = refEntity1.Sewing.StitchLengt;
            if (Copied1.Count > 1 & !Options.ProtectEntityStitchLen)
            {
              Entity copiedEntity = (Entity) null;
              buEntity.Copy(refEntity1, ref copiedEntity);
              Convert.ToInt32(((ICurve) copiedEntity).Length() / refEntity1.Sewing.StitchLengt);
              DevideLength = ((ICurve) copiedEntity).Length() / (double) (Copied1.Count - 1);
            }
            clsInit.cVector5.EntityDevideByCamDir(refEntity1, DevideLength, ref pntDevided);
            List<SewingVertex> Copied3 = new List<SewingVertex>();
            SewingVertex.Copy(refEntity1.Sewing.Vertex, ref Copied3);
            refEntity1.Sewing.Vertex.Clear();
            refEntity1.Sewing.Vertex = new List<SewingVertex>();
            for (int index7 = 0; index7 <= pntDevided.Count - 1; ++index7)
            {
              CustomData customData = new CustomData();
              if (index7 > 0)
              {
                Line line = new Line(pntDevided[index7 - 1], pntDevided[index7]);
                line.LineWeight = (float) Options.DrawigThickness;
                line.Color = Options.DrawingColor;
                line.ColorMethod = colorMethodType.byEntity;
                if (Options.DrawingLayerName.Length > 0)
                  line.LayerName = Options.DrawingLayerName;
                line.EntityData = (object) new CustomData()
                {
                  RefIndex = index1
                };
                screenDrawEntities.Add((Entity) line);
              }
              devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(pntDevided[index7]);
              point.LineWeight = (float) Options.PointThickness;
              point.Color = Options.PointColor;
              point.ColorMethod = colorMethodType.byEntity;
              if (Options.PointLayerName.Length > 0)
                point.LayerName = Options.PointLayerName;
              point.EntityData = (object) new CustomData()
              {
                RefIndex = index1
              };
              screenPointEntities.Add((Entity) point);
              if (Copied3.Count == 0)
                refEntity1.Sewing.Vertex.Add(new SewingVertex(pntDevided[index7]));
            }
            if (Copied3.Count > 0)
            {
              if (Copied3.Count > pntDevided.Count)
              {
                SewingVertex sewingVertex1 = new SewingVertex(pntDevided[0]);
                for (int index8 = 0; index8 <= pntDevided.Count - 1; ++index8)
                {
                  SewingVertex sewingVertex2 = new SewingVertex(pntDevided[index8]);
                  if (index8 < pntDevided.Count - 1)
                  {
                    for (int index9 = 0; index9 <= Copied3[index8].Codes.Count - 1; ++index9)
                      sewingVertex2.Codes.Add(Copied3[index8].Codes[index9]);
                  }
                  else
                  {
                    for (int index10 = 0; index10 <= Copied3[Copied3.Count - 1].Codes.Count - 1; ++index10)
                      sewingVertex2.Codes.Add(Copied3[Copied3.Count - 1].Codes[index10]);
                  }
                  refEntity1.Sewing.Vertex.Add(sewingVertex2);
                }
              }
              else if (Copied3.Count <= pntDevided.Count && Copied3.Count > 0)
              {
                SewingVertex sewingVertex3 = new SewingVertex(pntDevided[0]);
                sewingVertex3.FootHeight = Copied3[0].FootHeight;
                sewingVertex3.Speed = Copied3[0].Speed;
                sewingVertex3.DeltaX = Copied3[0].DeltaX;
                sewingVertex3.DeltaY = Copied3[0].DeltaY;
                for (int index11 = 0; index11 <= Copied3[0].Codes.Count - 1; ++index11)
                  sewingVertex3.Codes.Add(Copied3[0].Codes[index11]);
                if (Copied3[0].Punterez != null)
                  sewingVertex3.Punterez = new SewingPunteriz(Copied3[0].Punterez);
                refEntity1.Sewing.Vertex.Add(sewingVertex3);
                for (int index12 = 1; index12 <= pntDevided.Count - 2; ++index12)
                {
                  SewingVertex sewingVertex4 = new SewingVertex(pntDevided[index12]);
                  if (index12 <= Copied3.Count - 1)
                  {
                    sewingVertex4.DeltaX = Copied3[index12].DeltaX;
                    sewingVertex4.DeltaY = Copied3[index12].DeltaY;
                    sewingVertex4.FootHeight = Copied3[index12].FootHeight;
                    sewingVertex4.Speed = Copied3[index12].Speed;
                    if (index12 < Copied3.Count - 1)
                    {
                      for (int index13 = 0; index13 <= Copied3[index12].Codes.Count - 1; ++index13)
                        sewingVertex4.Codes.Add(Copied3[index12].Codes[index13]);
                      if (Copied3[index12].Punterez != null)
                        sewingVertex4.Punterez = new SewingPunteriz(Copied3[index12].Punterez);
                    }
                  }
                  else if (Options.ApplyNewLenUpToEnd & refEntity1.Sewing.Vertex.Count > 0)
                  {
                    sewingVertex4.DeltaX = refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].DeltaX;
                    sewingVertex4.DeltaY = refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].DeltaY;
                    sewingVertex4.FootHeight = refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].FootHeight;
                    sewingVertex4.Speed = refEntity1.Sewing.Vertex[refEntity1.Sewing.Vertex.Count - 1].Speed;
                  }
                  refEntity1.Sewing.Vertex.Add(sewingVertex4);
                }
                SewingVertex sewingVertex5 = new SewingVertex(pntDevided[pntDevided.Count - 1]);
                sewingVertex5.DeltaX = Copied3[Copied3.Count - 1].DeltaX;
                sewingVertex5.DeltaY = Copied3[Copied3.Count - 1].DeltaY;
                sewingVertex5.FootHeight = Copied3[Copied3.Count - 1].FootHeight;
                sewingVertex5.Speed = Copied3[Copied3.Count - 1].Speed;
                if (Copied3.Count > 1)
                {
                  for (int index14 = 0; index14 <= Copied3[Copied3.Count - 1].Codes.Count - 1; ++index14)
                    sewingVertex5.Codes.Add(Copied3[Copied3.Count - 1].Codes[index14]);
                }
                if (Copied3[Copied3.Count - 1].Punterez != null)
                  sewingVertex5.Punterez = new SewingPunteriz(Copied3[Copied3.Count - 1].Punterez);
                refEntity1.Sewing.Vertex.Add(sewingVertex5);
              }
            }
          }
        }
        else
        {
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(refEntity1, ref copiedEntity);
          copiedEntity.LineWeight = (float) Options.DrawigThickness;
          copiedEntity.Color = Options.DrawingColor;
          copiedEntity.ColorMethod = colorMethodType.byEntity;
          if (Options.DrawingLayerName.Length > 0)
            copiedEntity.LayerName = Options.DrawingLayerName;
          copiedEntity.EntityData = (object) new CustomData()
          {
            RefIndex = index1
          };
          screenDrawEntities.Add(copiedEntity);
          for (int index15 = 0; index15 <= refEntity1.Vertices.Count - 1; ++index15)
          {
            devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(refEntity1.Vertices[index15]);
            point.LineWeight = (float) Options.PointThickness;
            point.Color = Options.PointColor;
            point.ColorMethod = colorMethodType.byEntity;
            if (Options.PointLayerName.Length > 0)
              point.LayerName = Options.PointLayerName;
            point.EntityData = (object) new CustomData()
            {
              RefIndex = index1
            };
            screenPointEntities.Add((Entity) point);
          }
        }
      }
    }
  }

  public void doDefinePunteriz(Point3D refPoint, bool ShowDialog = false)
  {
    bool flag = false;
    for (int index1 = 0; index1 <= this.SewingBase.MainEntityList.Count - 1; ++index1)
    {
      if (this.SewingBase.MainEntityList[index1].Sewing.isStitchDrawing)
      {
        for (int index2 = 0; index2 <= this.SewingBase.MainEntityList[index1].Sewing.Vertex.Count - 1; ++index2)
        {
          if (Point3D.Distance(this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Point, refPoint) < Sketcher2D.PixelVsMilimeter * 10.0 & !flag)
          {
            flag = true;
            F_SewingPunteriz fSewingPunteriz = new F_SewingPunteriz();
            fSewingPunteriz.PunterizHeight = clsSewing.varSewingRunSettings.PunterizHeigth;
            fSewingPunteriz.PunterizLength = clsSewing.varSewingRunSettings.PunterizLength;
            fSewingPunteriz.PunterizType = clsSewing.varSewingRunSettings.PunterizType;
            fSewingPunteriz.PunterizWidth = clsSewing.varSewingRunSettings.PunterizWidth;
            fSewingPunteriz.Properties.FormCloseMode = FormCloseModeType.Dispose;
            fSewingPunteriz.Properties.FormPosition = FormStartPosition.CenterScreen;
            if (ShowDialog)
            {
              fSewingPunteriz.Init();
              int num = (int) fSewingPunteriz.ShowDialog();
            }
            // ISSUE: reference to a compiler-generated field
            if (this.okCommandWithThreeDataEventHandler_0 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.okCommandWithThreeDataEventHandler_0((object) "Punterez", (object) null, (object) null);
              fSewingPunteriz.PunterizHeight = clsSewing.varSewingRunSettings.PunterizHeigth;
              fSewingPunteriz.PunterizLength = clsSewing.varSewingRunSettings.PunterizLength;
              fSewingPunteriz.PunterizType = clsSewing.varSewingRunSettings.PunterizType;
              fSewingPunteriz.PunterizWidth = clsSewing.varSewingRunSettings.PunterizWidth;
            }
            if ((fSewingPunteriz.Properties.Result == DialogResult.OK | !ShowDialog) & !this.CancelApplied)
            {
              this.UndoBuffer();
              clsSewing.varSewingRunSettings.PunterizHeigth = fSewingPunteriz.PunterizHeight;
              clsSewing.varSewingRunSettings.PunterizLength = fSewingPunteriz.PunterizLength;
              clsSewing.varSewingRunSettings.PunterizType = fSewingPunteriz.PunterizType;
              clsSewing.varSewingRunSettings.PunterizWidth = fSewingPunteriz.PunterizWidth;
              if (index2 == 0)
              {
                this.SewingBase.MainEntityList[index1].Sewing.StartStitchType = SewingAddStitchType.None;
                this.SewingBase.MainEntityList[index1].Sewing.StartStitchCount = 0;
              }
              if (index2 == this.SewingBase.MainEntityList[index1].Sewing.Vertex.Count - 1)
              {
                this.SewingBase.MainEntityList[index1].Sewing.EndStitchType = SewingAddStitchType.None;
                this.SewingBase.MainEntityList[index1].Sewing.EndStitchCount = 0;
              }
              this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Punterez = new SewingPunteriz();
              this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Punterez.Height = clsSewing.varSewingRunSettings.PunterizHeigth;
              this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Punterez.Width = clsSewing.varSewingRunSettings.PunterizWidth;
              this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Punterez.Length = clsSewing.varSewingRunSettings.PunterizLength;
              this.SewingBase.MainEntityList[index1].Sewing.Vertex[index2].Punterez.PunterizType = clsSewing.varSewingRunSettings.PunterizType;
              this.JobUpdate();
              this.CancelApplied = false;
            }
          }
        }
      }
    }
    clsInit.appEditor.action = actionTypeBU.None;
  }

  public void doDefineLockStitch(Point3D refPoint, bool ShowDialog = false)
  {
    for (int index1 = 0; index1 <= this.SewingBase.MainEntityList.Count - 1; ++index1)
    {
      SewingInfo sewing = this.SewingBase.MainEntityList[index1].Sewing;
      if (sewing.isStitchDrawing)
      {
        for (int index2 = 0; index2 <= sewing.Vertex.Count - 1; ++index2)
        {
          if (Point3D.Distance(sewing.Vertex[index2].Point, refPoint) < Sketcher2D.PixelVsMilimeter * 10.0)
          {
            F_SewingExtend fSewingExtend = new F_SewingExtend();
            if (index2 == 0)
            {
              fSewingExtend.StitchCount = sewing.StartStitchCount;
              fSewingExtend.ExtendType = sewing.StartStitchType;
              fSewingExtend.Properties.FormCloseMode = FormCloseModeType.Dispose;
              fSewingExtend.Properties.FormPosition = FormStartPosition.CenterScreen;
              if (fSewingExtend.StitchCount == 0)
                fSewingExtend.StitchCount = 5;
              if (fSewingExtend.ExtendType == SewingAddStitchType.None)
                fSewingExtend.ExtendType = SewingAddStitchType.TwoWay;
              if (ShowDialog)
              {
                fSewingExtend.Init();
                int num = (int) fSewingExtend.ShowDialog();
              }
              // ISSUE: reference to a compiler-generated field
              if (this.okCommandWithThreeDataEventHandler_0 != null)
              {
                // ISSUE: reference to a compiler-generated field
                this.okCommandWithThreeDataEventHandler_0((object) "LockStitch", (object) null, (object) null);
                fSewingExtend.StitchCount = clsSewing.varSewingRunSettings.LockStitcCount;
                fSewingExtend.ExtendType = clsSewing.varSewingRunSettings.LockStitchType;
              }
              if ((fSewingExtend.Properties.Result == DialogResult.OK | !ShowDialog) & !this.CancelApplied)
              {
                this.UndoBuffer();
                this.SewingBase.MainEntityList[index1].Sewing.StartStitchCount = fSewingExtend.StitchCount;
                this.SewingBase.MainEntityList[index1].Sewing.StartStitchType = fSewingExtend.ExtendType;
              }
            }
            if (index2 == sewing.Vertex.Count - 1)
            {
              fSewingExtend.StitchCount = sewing.EndStitchCount;
              fSewingExtend.ExtendType = sewing.EndStitchType;
              fSewingExtend.Properties.FormCloseMode = FormCloseModeType.Dispose;
              fSewingExtend.Properties.FormPosition = FormStartPosition.CenterScreen;
              if (fSewingExtend.StitchCount == 0)
                fSewingExtend.StitchCount = 5;
              if (fSewingExtend.ExtendType == SewingAddStitchType.None)
                fSewingExtend.ExtendType = SewingAddStitchType.TwoWay;
              if (ShowDialog)
              {
                fSewingExtend.Init();
                int num = (int) fSewingExtend.ShowDialog();
              }
              // ISSUE: reference to a compiler-generated field
              if (this.okCommandWithThreeDataEventHandler_0 != null)
              {
                // ISSUE: reference to a compiler-generated field
                this.okCommandWithThreeDataEventHandler_0((object) "LockStitch", (object) null, (object) null);
                fSewingExtend.StitchCount = clsSewing.varSewingRunSettings.LockStitcCount;
                fSewingExtend.ExtendType = clsSewing.varSewingRunSettings.LockStitchType;
              }
              if ((fSewingExtend.Properties.Result == DialogResult.OK | !ShowDialog) & !this.CancelApplied)
              {
                this.UndoBuffer();
                this.SewingBase.MainEntityList[index1].Sewing.EndStitchCount = fSewingExtend.StitchCount;
                this.SewingBase.MainEntityList[index1].Sewing.EndStitchType = fSewingExtend.ExtendType;
              }
            }
          }
        }
      }
    }
    clsInit.appEditor.action = actionTypeBU.None;
  }

  public void doDefineAddCodes(Point3D refPoint)
  {
    for (int index1 = 0; index1 <= this.SewingBase.MainEntityList.Count - 1; ++index1)
    {
      SewingInfo sewing = this.SewingBase.MainEntityList[index1].Sewing;
      if (sewing.isStitchDrawing)
      {
        for (int index2 = 0; index2 <= sewing.Vertex.Count - 1; ++index2)
        {
          if (Point2D.Distance((Point2D) sewing.Vertex[index2].Point, (Point2D) refPoint) < Sketcher2D.PixelVsMilimeter * 10.0)
          {
            F_SewingCodes fSewingCodes = new F_SewingCodes();
            for (int index3 = 0; index3 <= this.definedCodes.Count - 1; ++index3)
              fSewingCodes.CodesDefined.Add(new SewingCode(this.definedCodes[index3]));
            for (int index4 = 0; index4 <= sewing.Vertex[index2].Codes.Count - 1; ++index4)
              fSewingCodes.Codes.Add(new SewingCode(sewing.Vertex[index2].Codes[index4]));
            this.UndoBuffer();
            fSewingCodes.Properties.FormCloseMode = FormCloseModeType.Dispose;
            fSewingCodes.Properties.FormPosition = FormStartPosition.CenterScreen;
            fSewingCodes.Init();
            int num = (int) fSewingCodes.ShowDialog();
            if (fSewingCodes.Properties.Result == DialogResult.OK)
            {
              sewing.Vertex[index2].Codes.Clear();
              for (int index5 = 0; index5 <= fSewingCodes.Codes.Count - 1; ++index5)
                sewing.Vertex[index2].Codes.Add(new SewingCode(fSewingCodes.Codes[index5]));
              clsInit.appEditor.Reset();
              return;
            }
            clsInit.appEditor.Reset();
            return;
          }
        }
      }
    }
    for (int index6 = 0; index6 <= this.SewingBase.MainEntityList.Count - 1; ++index6)
    {
      SewingInfo sewing = this.SewingBase.MainEntityList[index6].Sewing;
      for (int index7 = 0; index7 <= sewing.Vertex.Count - 1; ++index7)
      {
        if (Point3D.Distance(sewing.Vertex[index7].Point, refPoint) < Sketcher2D.PixelVsMilimeter * 10.0)
        {
          F_SewingCodes fSewingCodes = new F_SewingCodes();
          for (int index8 = 0; index8 <= this.definedCodes.Count - 1; ++index8)
            fSewingCodes.CodesDefined.Add(new SewingCode(this.definedCodes[index8]));
          for (int index9 = 0; index9 <= sewing.Vertex[index7].Codes.Count - 1; ++index9)
            fSewingCodes.Codes.Add(new SewingCode(sewing.Vertex[index7].Codes[index9]));
          this.UndoBuffer();
          fSewingCodes.Properties.FormCloseMode = FormCloseModeType.Dispose;
          fSewingCodes.Properties.FormPosition = FormStartPosition.CenterScreen;
          fSewingCodes.Init();
          int num = (int) fSewingCodes.ShowDialog();
          if (fSewingCodes.Properties.Result == DialogResult.OK)
          {
            sewing.Vertex[index7].Codes.Clear();
            for (int index10 = 0; index10 <= fSewingCodes.Codes.Count - 1; ++index10)
              sewing.Vertex[index7].Codes.Add(new SewingCode(fSewingCodes.Codes[index10]));
            clsInit.appEditor.Reset();
            return;
          }
          clsInit.appEditor.Reset();
          return;
        }
      }
    }
    clsInit.appEditor.Reset();
  }

  public void doDefineScale(Point3D refPoint, bool ShowDialog = false)
  {
    this.Selected.Clear();
    Sketcher2D.selectedPoint.Clear();
    clsItem.frmEditor.viewport.TempEntities.Clear();
    for (int index1 = 0; index1 <= this.SewingBase.MainEntityList.Count - 1; ++index1)
    {
      SewingInfo sewing = this.SewingBase.MainEntityList[index1].Sewing;
      if (sewing.isStitchDrawing)
      {
        for (int index2 = 0; index2 <= sewing.Vertex.Count - 1; ++index2)
        {
          if (Point3D.Distance(sewing.Vertex[index2].Point, refPoint) < Sketcher2D.PixelVsMilimeter * 10.0 && index2 == 0 | index2 == sewing.Vertex.Count - 1)
          {
            SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint();
            if (index2 == 0)
              sewingSelectedPoint.CatchPosition = !buCompare5.EQ(sewing.Vertex[0].Point, this.SewingBase.MainEntityList[index1].StartPoint) ? (!buCompare5.EQ(sewing.Vertex[0].Point, this.SewingBase.MainEntityList[index1].EndPoint) ? StartMiddleEndType.Middle : StartMiddleEndType.End) : StartMiddleEndType.Start;
            if (index2 == sewing.Vertex.Count - 1)
              sewingSelectedPoint.CatchPosition = !buCompare5.EQ(sewing.Vertex[sewing.Vertex.Count - 1].Point, this.SewingBase.MainEntityList[index1].StartPoint) ? (!buCompare5.EQ(sewing.Vertex[sewing.Vertex.Count - 1].Point, this.SewingBase.MainEntityList[index1].EndPoint) ? StartMiddleEndType.Middle : StartMiddleEndType.End) : StartMiddleEndType.Start;
            sewingSelectedPoint.EntityIndex = index1;
            sewingSelectedPoint.VertexIndex = index2;
            sewingSelectedPoint.refPoint = buVector5.ToPoint3D(sewing.Vertex[index2].Point);
            this.Selected.Add(sewingSelectedPoint);
            Sketcher2D.selectedPoint.Add(buVector5.ToPoint3D(sewingSelectedPoint.refPoint));
          }
        }
      }
    }
    if (this.Selected.Count == 0)
    {
      for (int index = 0; index <= this.SewingBase.MainEntityList.Count - 1; ++index)
      {
        if (!this.SewingBase.MainEntityList[index].Sewing.isStitchDrawing)
        {
          double num1 = Point3D.Distance(this.SewingBase.MainEntityList[index].StartPoint, refPoint);
          double num2 = Point3D.Distance(this.SewingBase.MainEntityList[index].EndPoint, refPoint);
          if (num1 < Sketcher2D.PixelVsMilimeter * 10.0)
          {
            SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint();
            sewingSelectedPoint.CatchPosition = StartMiddleEndType.Start;
            sewingSelectedPoint.EntityIndex = index;
            sewingSelectedPoint.VertexIndex = -1;
            sewingSelectedPoint.refPoint = buVector5.ToPoint3D(this.SewingBase.MainEntityList[index].StartPoint);
            this.Selected.Add(sewingSelectedPoint);
            Sketcher2D.selectedPoint.Add(buVector5.ToPoint3D(sewingSelectedPoint.refPoint));
          }
          else if (num2 < Sketcher2D.PixelVsMilimeter * 10.0)
          {
            SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint();
            sewingSelectedPoint.CatchPosition = StartMiddleEndType.End;
            sewingSelectedPoint.EntityIndex = index;
            sewingSelectedPoint.VertexIndex = -1;
            sewingSelectedPoint.refPoint = buVector5.ToPoint3D(this.SewingBase.MainEntityList[index].EndPoint);
            this.Selected.Add(sewingSelectedPoint);
            Sketcher2D.selectedPoint.Add(buVector5.ToPoint3D(sewingSelectedPoint.refPoint));
          }
        }
      }
    }
    if (this.Selected.Count <= 0)
      return;
    if (this.frmMove == null)
    {
      this.frmMove = new F_SewingMove();
      this.frmMove.MoveCommad += new OkCommandWithTwoDataEventHandler(this.MoveCommand);
      this.frmMove.CancelCommad += new CancelCommandEventHandler(this.MoveCancel);
    }
    if (clsSewing.varSewingRunSettings.MoveDistance <= 0.0)
      clsSewing.varSewingRunSettings.MoveDistance = 1.0;
    this.frmMove.MoveDis = clsSewing.varSewingRunSettings.MoveDistance;
    this.frmMove.Properties.FormCloseMode = FormCloseModeType.Invisible;
    this.frmMove.Properties.FormPosition = FormStartPosition.CenterScreen;
    this.frmMove.Properties.TopMost = true;
    this.frmMove.btn_anglePlus.Visible = true;
    this.frmMove.btn_angleMinus.Visible = true;
    if (ShowDialog)
    {
      this.frmMove.Init();
      this.frmMove.Show();
    }
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandWithThreeDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.okCommandWithThreeDataEventHandler_0((object) "Scale", (object) null, (object) null);
  }

  public void doDefineRotate(Point3D refPoint, bool ShowDialog = false)
  {
    this.Selected.Clear();
    Sketcher2D.selectedPoint.Clear();
    clsItem.frmEditor.viewport.TempEntities.Clear();
    for (int index1 = 0; index1 <= this.SewingBase.MainEntityList.Count - 1; ++index1)
    {
      SewingInfo sewing = this.SewingBase.MainEntityList[index1].Sewing;
      if (sewing.isStitchDrawing)
      {
        for (int index2 = 0; index2 <= sewing.Vertex.Count - 1; ++index2)
        {
          if (Point3D.Distance(sewing.Vertex[index2].Point, refPoint) < Sketcher2D.PixelVsMilimeter * 10.0 && index2 == 0 | index2 == sewing.Vertex.Count - 1)
          {
            SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint();
            if (index2 == 0)
              sewingSelectedPoint.CatchPosition = !buCompare5.EQ(sewing.Vertex[0].Point, this.SewingBase.MainEntityList[index1].StartPoint) ? (!buCompare5.EQ(sewing.Vertex[0].Point, this.SewingBase.MainEntityList[index1].EndPoint) ? StartMiddleEndType.Middle : StartMiddleEndType.End) : StartMiddleEndType.Start;
            if (index2 == sewing.Vertex.Count - 1)
              sewingSelectedPoint.CatchPosition = !buCompare5.EQ(sewing.Vertex[sewing.Vertex.Count - 1].Point, this.SewingBase.MainEntityList[index1].StartPoint) ? (!buCompare5.EQ(sewing.Vertex[sewing.Vertex.Count - 1].Point, this.SewingBase.MainEntityList[index1].EndPoint) ? StartMiddleEndType.Middle : StartMiddleEndType.End) : StartMiddleEndType.Start;
            sewingSelectedPoint.EntityIndex = index1;
            sewingSelectedPoint.VertexIndex = index2;
            sewingSelectedPoint.refPoint = buVector5.ToPoint3D(sewing.Vertex[index2].Point);
            this.Selected.Add(sewingSelectedPoint);
            Sketcher2D.selectedPoint.Add(buVector5.ToPoint3D(sewingSelectedPoint.refPoint));
          }
        }
      }
    }
    if (this.Selected.Count <= 0)
      return;
    if (this.Selected.Count > 1)
    {
      DialogBoxList dialogBoxList = new DialogBoxList();
      for (int index = 0; index <= this.Selected.Count - 1; ++index)
      {
        Text text = new Text(Plane.XY, clsInit.cVector5.MiddlePointOfLine(this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].StartPoint, this.SewingBase.MainEntityList[this.Selected[index].EntityIndex].EndPoint), (index + 1).ToString(), 10.0);
        clsItem.frmEditor.viewport.Entities.Add((Entity) text);
        dialogBoxList.Items.Add((index + 1).ToString());
      }
      clsItem.frmEditor.viewport.Invalidate();
      dialogBoxList.Width = 200;
      dialogBoxList.Height = 150;
      dialogBoxList.Init();
      int num = (int) dialogBoxList.ShowDialog();
      int selectedIndex = dialogBoxList.SelectedIndex;
      if (selectedIndex == 0)
      {
        for (int index = this.Selected.Count - 1; index >= 1; --index)
          this.Selected.RemoveAt(index);
      }
      else if (selectedIndex == this.Selected.Count - 1)
      {
        for (int index = this.Selected.Count - 2; index >= 0; --index)
          this.Selected.RemoveAt(index);
      }
      else
      {
        for (int index = this.Selected.Count - 1; index >= selectedIndex + 1; --index)
          this.Selected.RemoveAt(index);
        for (int index = selectedIndex - 1; index >= 0; --index)
          this.Selected.RemoveAt(index);
      }
    }
    if (ShowDialog)
    {
      if (this.frmRotate == null)
      {
        this.frmRotate = new F_SewingRotate();
        this.frmRotate.RotateCommad += new OkCommandWithTwoDataEventHandler(this.RotateCommand);
        this.frmRotate.CancelCommad += new CancelCommandEventHandler(this.MoveCancel);
      }
      this.frmRotate.RotateDegree = clsSewing.varSewingRunSettings.RotateDegree;
      this.frmRotate.Properties.FormCloseMode = FormCloseModeType.Invisible;
      this.frmRotate.Properties.FormPosition = FormStartPosition.CenterScreen;
      this.frmRotate.Properties.TopMost = true;
      this.frmRotate.Init();
      this.frmRotate.Show();
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      if (this.okCommandWithThreeDataEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithThreeDataEventHandler_0((object) "Rotate", (object) null, (object) null);
      if (this.CancelApplied)
        return;
      this.RotateCommand((object) "Plus", (object) clsSewing.varSewingRunSettings.RotateDegree);
    }
  }

  public void doDefineMove()
  {
    this.Selected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    List<int> intList = new List<int>();
    if (Sketcher2D.entitiesSelected.Count > 0)
    {
      for (int index = 0; index <= Sketcher2D.entitiesSelected.Count - 1; ++index)
      {
        if (Sketcher2D.entitiesSelected[index].EntityData != null && Sketcher2D.entitiesSelected[index].EntityData is SewingEntityCustomData)
        {
          SewingEntityCustomData entityData = Sketcher2D.entitiesSelected[index].EntityData as SewingEntityCustomData;
          if (entityData.indexEntity >= 0 & entityData.indexEntity <= this.SewingBase.MainEntityList.Count - 1)
            this.Selected.Add(new SewingSelectedPoint()
            {
              EntityIndex = entityData.indexEntity
            });
        }
      }
    }
    if (this.Selected.Count <= 0)
      return;
    clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[4], buLangTranslate.preDef.Sewing);
    if (this.frmMove == null)
    {
      this.frmMove = new F_SewingMove();
      this.frmMove.MoveCommad += new OkCommandWithTwoDataEventHandler(this.MoveCommand);
      this.frmMove.CancelCommad += new CancelCommandEventHandler(this.MoveCancel);
    }
    if (clsSewing.varSewingRunSettings.MoveDistance <= 0.0)
      clsSewing.varSewingRunSettings.MoveDistance = 1.0;
    this.frmMove.MoveDis = clsSewing.varSewingRunSettings.MoveDistance;
    this.frmMove.Properties.FormCloseMode = FormCloseModeType.Invisible;
    this.frmMove.Properties.FormPosition = FormStartPosition.CenterScreen;
    this.frmMove.Properties.TopMost = true;
    this.frmMove.btn_anglePlus.Visible = false;
    this.frmMove.btn_angleMinus.Visible = false;
    this.frmMove.Init();
    this.frmMove.Show();
  }

  public void doDefineSelectVertex(Point3D refPoint, actionTypeBU action)
  {
    this.Selected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    List<int> intList = new List<int>();
    if (Sketcher2D.entitiesSelected.Count > 0)
    {
      for (int index = 0; index <= Sketcher2D.entitiesSelected.Count - 1; ++index)
      {
        if (Sketcher2D.entitiesSelected[index].EntityData != null && Sketcher2D.entitiesSelected[index].EntityData is SewingEntityCustomData)
        {
          SewingEntityCustomData entityData = Sketcher2D.entitiesSelected[index].EntityData as SewingEntityCustomData;
          if (entityData.indexEntity >= 0 & entityData.indexEntity <= this.SewingBase.MainEntityList.Count - 1 && entityData.indexVertex >= 0 & entityData.indexVertex <= this.SewingBase.MainEntityList[entityData.indexEntity].Sewing.Vertex.Count - 1)
          {
            SewingVertex sewingVertex = this.SewingBase.MainEntityList[entityData.indexEntity].Sewing.Vertex[entityData.indexVertex];
            this.baseSelected = new SewingSelectedPoint();
            this.baseSelected.EntityIndex = entityData.indexEntity;
            this.baseSelected.VertexIndex = entityData.indexVertex;
            this.baseSelected.refPoint = new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY);
            this.baseSelected.CatchPosition = entityData.indexVertex != 0 ? (entityData.indexVertex != this.SewingBase.MainEntityList[entityData.indexEntity].Sewing.Vertex.Count - 1 ? StartMiddleEndType.Middle : StartMiddleEndType.End) : StartMiddleEndType.Start;
            this.Selected.Add(this.baseSelected);
            index = Sketcher2D.entitiesSelected.Count;
          }
        }
      }
    }
    if (this.baseSelected == null)
      return;
    Sketcher2D.selectedCircle.Clear();
    for (int index = 0; index <= this.Selected.Count - 1; ++index)
    {
      Circle circle = new Circle(Plane.XY, buVector5.ToPoint3D(this.Selected[index].refPoint), 0.8);
      circle.Color = Color.Cyan;
      Sketcher2D.selectedCircle.Add(circle);
    }
    clsItem.frmEditor.viewport.Invalidate();
    clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[7], buLangTranslate.preDef.Sewing);
    if (this.frmSelectVertex == null)
    {
      this.frmSelectVertex = new F_SewingSelectVertex();
      this.frmSelectVertex.SelectCommad += new OkCommandWithThreeDataEventHandler(this.SelectVertexCommand);
      this.frmSelectVertex.CancelCommad += new CancelCommandEventHandler(this.MoveCancel);
    }
    this.frmSelectVertex.Properties.FormCloseMode = FormCloseModeType.Invisible;
    this.frmSelectVertex.Properties.FormPosition = FormStartPosition.CenterScreen;
    this.frmSelectVertex.Properties.TopMost = true;
    this.frmSelectVertex.ShowDialog = clsSewing.varSewingRunSettings.ShowDialog;
    this.frmSelectVertex.Init();
    this.frmSelectVertex.Show();
  }

  public void doChangeDirection(Point3D refPoint, actionTypeBU action)
  {
    this.Selected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    List<int> intList = new List<int>();
    if (Sketcher2D.entitiesSelected.Count > 0)
    {
      this.UndoBuffer();
      for (int index = 0; index <= Sketcher2D.entitiesSelected.Count - 1; ++index)
      {
        if (Sketcher2D.entitiesSelected[index].EntityData != null && Sketcher2D.entitiesSelected[index].EntityData is SewingEntityCustomData)
        {
          SewingEntityCustomData entityData = Sketcher2D.entitiesSelected[index].EntityData as SewingEntityCustomData;
          if (entityData.indexEntity >= 0 & entityData.indexEntity <= this.SewingBase.MainEntityList.Count - 1 && this.SewingBase.MainEntityList[entityData.indexEntity] is buLine)
          {
            Point3D point3D = buVector5.ToPoint3D(this.SewingBase.MainEntityList[entityData.indexEntity].StartPoint);
            this.SewingBase.MainEntityList[entityData.indexEntity].StartPoint = buVector5.ToPoint3D(this.SewingBase.MainEntityList[entityData.indexEntity].EndPoint);
            this.SewingBase.MainEntityList[entityData.indexEntity].EndPoint = point3D;
            this.SewingBase.MainEntityList[entityData.indexEntity].Update(buEntityUpdateType.Line);
            this.SewingBase.MainEntityList[entityData.indexEntity].Sewing.Vertex.Reverse();
          }
        }
      }
      this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
      this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
      this.JobUpdate();
    }
    clsInit.appEditor.Reset();
  }

  public void doDeleteAll()
  {
    if (buString5.MessageBoxQuestion(buSewingCalc.LangSewingMessage[1]) != DialogResult.Yes)
      return;
    this.UndoBuffer();
    this.SewingBase.MainEntityList.Clear();
    this.SewingBase.SimilationPoint.SimMove.Clear();
    this.SewingBase = new SewingMain();
    this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
    this.JobUpdate();
  }

  public void doDeleteVertex(Point3D refPoint)
  {
    this.Selected.Clear();
    Sketcher2D.selectedPoint.Clear();
    clsItem.frmEditor.viewport.TempEntities.Clear();
    int num = -1;
    Point3D point3D1 = (Point3D) null;
    Point3D point3D2 = (Point3D) null;
    this.UndoBuffer();
    for (int index1 = 0; index1 <= this.SewingBase.MainEntityList.Count - 1; ++index1)
    {
      SewingInfo sewing = this.SewingBase.MainEntityList[index1].Sewing;
      if (sewing.isStitchDrawing)
      {
        for (int index2 = 0; index2 <= sewing.Vertex.Count - 1; ++index2)
        {
          if (Point3D.Distance(sewing.Vertex[index2].Point, refPoint) < Sketcher2D.PixelVsMilimeter * 10.0 && index2 == 0 | index2 == sewing.Vertex.Count - 1)
          {
            point3D1 = new Point3D(sewing.Vertex[index2].Point.X + sewing.Vertex[index2].DeltaX, sewing.Vertex[index2].Point.Y + sewing.Vertex[index2].DeltaY);
            num = index1;
            if (index2 == 0)
            {
              if (buCompare5.EQ(sewing.Vertex[index2].Point, this.SewingBase.MainEntityList[index1].StartPoint))
              {
                point3D2 = new Point3D(sewing.Vertex[index2 + 1].Point.X + sewing.Vertex[index2 + 1].DeltaX, sewing.Vertex[index2 + 1].Point.Y + sewing.Vertex[index2 + 1].DeltaY);
                this.SewingBase.MainEntityList[index1].StartPoint = new Point3D(sewing.Vertex[index2 + 1].Point.X + sewing.Vertex[index2 + 1].DeltaX, sewing.Vertex[index2 + 1].Point.Y + sewing.Vertex[index2 + 1].DeltaY);
              }
              if (buCompare5.EQ(sewing.Vertex[index2].Point, this.SewingBase.MainEntityList[index1].EndPoint))
              {
                point3D2 = new Point3D(sewing.Vertex[index2 + 1].Point.X + sewing.Vertex[index2 + 1].DeltaX, sewing.Vertex[index2 + 1].Point.Y + sewing.Vertex[index2 + 1].DeltaY);
                this.SewingBase.MainEntityList[index1].EndPoint = buVector5.ToPoint3D(sewing.Vertex[index2 + 1].Point);
              }
            }
            if (index2 == sewing.Vertex.Count - 1)
            {
              if (buCompare5.EQ(sewing.Vertex[index2].Point, this.SewingBase.MainEntityList[index1].StartPoint))
              {
                point3D2 = new Point3D(sewing.Vertex[index2 - 1].Point.X + sewing.Vertex[index2 - 1].DeltaX, sewing.Vertex[index2 - 1].Point.Y + sewing.Vertex[index2 - 1].DeltaY);
                this.SewingBase.MainEntityList[index1].StartPoint = new Point3D(sewing.Vertex[index2 - 1].Point.X + sewing.Vertex[index2 - 1].DeltaX, sewing.Vertex[index2 - 1].Point.Y + sewing.Vertex[index2 - 1].DeltaY);
              }
              if (buCompare5.EQ(sewing.Vertex[index2].Point, this.SewingBase.MainEntityList[index1].EndPoint))
              {
                point3D2 = new Point3D(sewing.Vertex[index2 - 1].Point.X + sewing.Vertex[index2 - 1].DeltaX, sewing.Vertex[index2 - 1].Point.Y + sewing.Vertex[index2 - 1].DeltaY);
                this.SewingBase.MainEntityList[index1].EndPoint = new Point3D(sewing.Vertex[index2 - 1].Point.X + sewing.Vertex[index2 - 1].DeltaX, sewing.Vertex[index2 - 1].Point.Y + sewing.Vertex[index2 - 1].DeltaY);
              }
            }
            if (this.SewingBase.MainEntityList[index1] is buLine)
              this.SewingBase.MainEntityList[index1].Update(buEntityUpdateType.Line);
            if (this.SewingBase.MainEntityList[index1] is buArc)
              this.SewingBase.MainEntityList[index1].Update(buEntityUpdateType.Arc3Point3D);
          }
        }
        if (num >= 0 & point3D1 != (Point3D) null & point3D2 != (Point3D) null)
        {
          for (int index3 = 0; index3 <= this.SewingBase.MainEntityList.Count - 1; ++index3)
          {
            if (index3 != num)
            {
              if (buCompare5.EQ(point3D1, this.SewingBase.MainEntityList[index3].StartPoint))
              {
                this.SewingBase.MainEntityList[index3].StartPoint.X = point3D2.X;
                this.SewingBase.MainEntityList[index3].StartPoint.Y = point3D2.Y;
              }
              else if (buCompare5.EQ(point3D1, this.SewingBase.MainEntityList[index3].EndPoint))
              {
                this.SewingBase.MainEntityList[index3].EndPoint.X = point3D2.X;
                this.SewingBase.MainEntityList[index3].EndPoint.Y = point3D2.Y;
              }
            }
          }
        }
      }
    }
    if (num >= 0)
    {
      this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
      this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
    }
    else
    {
      if (this.UndoList.Count <= 0)
        return;
      this.UndoList.RemoveAt(this.UndoList.Count - 1);
    }
  }

  public void doDeleteByQuestion(Point3D refPoint)
  {
    int index1 = -1;
    for (int index2 = 0; index2 <= this.SewingBase.MainEntityList.Count - 1; ++index2)
    {
      SewingInfo sewing = this.SewingBase.MainEntityList[index2].Sewing;
      for (int index3 = 0; index3 <= sewing.Vertex.Count - 1; ++index3)
      {
        if (Point3D.Distance(sewing.Vertex[index3].Point, refPoint) < Sketcher2D.PixelVsMilimeter * 10.0)
        {
          index1 = index2;
          index3 = sewing.Vertex.Count;
          index2 = this.SewingBase.MainEntityList.Count;
        }
      }
    }
    if (index1 == -1)
    {
      Sketcher2D.entitiesSelected.Clear();
      clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
      if (Sketcher2D.entitiesSelected.Count > 0)
      {
        for (int index4 = 0; index4 <= Sketcher2D.entitiesSelected.Count - 1; ++index4)
        {
          if (Sketcher2D.entitiesSelected[index4].EntityData != null && Sketcher2D.entitiesSelected[index4].EntityData is SewingEntityCustomData)
          {
            SewingEntityCustomData entityData = Sketcher2D.entitiesSelected[index4].EntityData as SewingEntityCustomData;
            if (entityData.indexEntity >= 0 & entityData.indexEntity <= this.SewingBase.MainEntityList.Count - 1)
            {
              index1 = entityData.indexEntity;
              index4 = Sketcher2D.entitiesSelected.Count;
            }
          }
        }
      }
    }
    if (index1 < 0)
      return;
    this.UndoBuffer();
    if (buString5.MessageBoxQuestion(buSewingCalc.LangSewingMessage[0]) == DialogResult.Yes)
    {
      if (index1 > 0 & index1 < this.SewingBase.MainEntityList.Count - 1)
      {
        int index5 = -1;
        List<int> RefList = new List<int>();
        RefList.Add(index1);
        for (int index6 = index1 + 1; index6 <= this.SewingBase.MainEntityList.Count - 1; ++index6)
        {
          if (this.SewingBase.MainEntityList[index6].Sewing.isStitchDrawing)
          {
            index5 = index6;
            index6 = this.SewingBase.MainEntityList.Count;
          }
          else
            RefList.Add(index6);
        }
        if (index5 >= 0)
        {
          this.SewingBase.MainEntityList[index1 - 1].EndPoint = buVector5.ToPoint3D(this.SewingBase.MainEntityList[index5].StartPoint);
          if (this.SewingBase.MainEntityList[index1 - 1] is buLine)
            this.SewingBase.MainEntityList[index1 - 1].Update(buEntityUpdateType.Line);
          else if (this.SewingBase.MainEntityList[index1 - 1] is buArc)
            this.SewingBase.MainEntityList[index1 - 1].Update(buEntityUpdateType.Arc3Point3D);
        }
        clsInit.cVector5.SortList(SortDirectionType.Bigger, ref RefList);
        for (int index7 = 0; index7 <= RefList.Count - 1; ++index7)
          this.SewingBase.MainEntityList.RemoveAt(RefList[index7]);
      }
      else if (index1 == 0)
        this.SewingBase.MainEntityList.RemoveAt(index1);
      else if (index1 == this.SewingBase.MainEntityList.Count - 1)
        this.SewingBase.MainEntityList.RemoveAt(index1);
    }
    else
      this.SewingBase.MainEntityList.RemoveAt(index1);
    this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
    clsInit.appEditor.Reset();
  }

  public void doDelete()
  {
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    List<int> RefList = new List<int>();
    if (Sketcher2D.entitiesSelected.Count > 0)
    {
      for (int index1 = 0; index1 <= Sketcher2D.entitiesSelected.Count - 1; ++index1)
      {
        if (Sketcher2D.entitiesSelected[index1].EntityData != null & Sketcher2D.entitiesSelected[index1] is ICurve && Sketcher2D.entitiesSelected[index1].EntityData is SewingEntityCustomData & Sketcher2D.entitiesSelected[index1].GetType() != typeof (devDept.Eyeshot.Entities.Point))
        {
          SewingEntityCustomData entityData = Sketcher2D.entitiesSelected[index1].EntityData as SewingEntityCustomData;
          if (entityData.indexEntity >= 0 & entityData.indexEntity <= this.SewingBase.MainEntityList.Count - 1)
          {
            if (RefList.Count == 0)
            {
              RefList.Add(entityData.indexEntity);
            }
            else
            {
              bool flag = true;
              for (int index2 = 0; index2 <= RefList.Count - 1; ++index2)
              {
                if (RefList[index2] == entityData.indexEntity)
                  flag = false;
              }
              if (flag)
                RefList.Add(entityData.indexEntity);
            }
          }
        }
      }
    }
    if (RefList.Count > 0)
      this.UndoBuffer();
    clsInit.cVector5.SortList(SortDirectionType.Bigger, ref RefList);
    for (int index = 0; index <= RefList.Count - 1; ++index)
      this.SewingBase.MainEntityList.RemoveAt(RefList[index]);
    if (RefList.Count > 0)
      this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
    clsInit.appEditor.Reset();
  }

  public void doOffset(double Offset, LeftRightType Type)
  {
    Sketcher2D.entitiesSelected.Clear();
    clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
    double num1 = 2.0;
    if (Type == LeftRightType.Right)
      num1 = -2.0;
    clsVar.varEditorRuntimeSet.OffsetValue = Offset;
    for (int index = 0; index <= Sketcher2D.entitiesSelected.Count - 1; ++index)
    {
      Entity selEntity = (Entity) Sketcher2D.entitiesSelected[index].Clone();
      if (selEntity.Vertices == null)
        selEntity.Regen(0.01);
      ICurve curve = (ICurve) selEntity;
      double num2 = clsInit.cVector5.PointAngle(selEntity.Vertices[1], selEntity.Vertices[0]);
      Entity entityOffseted = (Entity) null;
      Point3D EndPnt = new Point3D();
      clsInit.cVector5.LineWithLengthAndAngle(selEntity.Vertices[0], curve.Length() / 2.0, num2 + num1, ref EndPnt);
      if (!clsInit.appEditor.Offset(selEntity, EndPnt, ref entityOffseted))
        break;
      if (entityOffseted != null)
      {
        entityOffseted.ColorMethod = colorMethodType.byEntity;
        entityOffseted.Color = clsVar.varEditorSet.colorEntity;
        entityOffseted.LineWeight = (float) clsVar.varEditorSet.thicknessEntity;
        entityOffseted.LineWeightMethod = colorMethodType.byEntity;
        clsInit.appSewing.doOffset(entityOffseted);
      }
    }
  }

  public void doOffset(Entity entityOffseted)
  {
    SewingInfo data = (SewingInfo) null;
    if (Sketcher2D.entitiesSelected.Count > 0 && Sketcher2D.entitiesSelected[0].EntityData != null && Sketcher2D.entitiesSelected[0].EntityData is SewingEntityCustomData)
    {
      SewingEntityCustomData entityData = Sketcher2D.entitiesSelected[0].EntityData as SewingEntityCustomData;
      if (entityData.indexEntity >= 0 & entityData.indexEntity <= this.SewingBase.MainEntityList.Count - 1)
        data = new SewingInfo(this.SewingBase.MainEntityList[entityData.indexEntity].Sewing);
    }
    if (entityOffseted == null)
      return;
    this.UndoBuffer();
    buEntity copiedEntity = (buEntity) null;
    buEntity.Copy(entityOffseted, ref copiedEntity);
    if (data != null)
    {
      data.Vertex.Clear();
      copiedEntity.Sewing = new SewingInfo(data);
    }
    else
    {
      copiedEntity.Sewing = new SewingInfo();
      copiedEntity.Sewing.StitchLengt = clsSewing.varSewingSettings.defaultStitchLength;
    }
    this.SewingBase.MainEntityList.Add(copiedEntity);
    this.doDevideEntitiesByLength(ref this.SewingBase.MainEntityList, new SewingDevideOptions());
    this.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
    clsInit.appEditor.Reset();
  }

  public void doPunteriz(
    Point3D refPoint,
    Point3D nextPoint,
    double Width,
    double Height,
    SewingPunterizType Type,
    ref List<Point3D> calcPoints)
  {
    calcPoints = new List<Point3D>();
    double Width1 = Point3D.Distance(refPoint, nextPoint);
    int int32 = Convert.ToInt32(Width1 / Width);
    double Angle = clsInit.cVector5.PointAngle(nextPoint, refPoint);
    this.doPunteriz(refPoint, Width1, Height, int32, Angle, Type, ref calcPoints);
  }

  public void doPunteriz(
    Point3D refPoint,
    double Length,
    double Width,
    double Height,
    double Angle,
    SewingPunterizType Type,
    ref List<Point3D> calcPoints)
  {
    calcPoints = new List<Point3D>();
    int int32 = Convert.ToInt32(Length / Width);
    this.doPunteriz(refPoint, Length, Height, int32, Angle, Type, ref calcPoints);
  }

  public void doPunteriz(
    Point3D refPoint,
    double Width,
    double Height,
    int Count,
    double Angle,
    SewingPunterizType Type,
    ref List<Point3D> calcPoints)
  {
    calcPoints.Clear();
    calcPoints = new List<Point3D>();
    switch (Type)
    {
      case SewingPunterizType.CenterLeft:
        double num1 = Width / Convert.ToDouble(Count * 4);
        calcPoints.Add(new Point3D());
        Point3D point3D1 = new Point3D();
        for (int index = 0; index < Count * 2 - 1; ++index)
        {
          if (index == 0)
          {
            Point3D point3D2 = new Point3D(num1 + (double) index * (num1 + num1 + num1 + num1), Height / 2.0);
            calcPoints.Add(point3D2);
            Point3D point3D3 = new Point3D(num1 + num1 + num1 + (double) index * (num1 + num1 + num1 + num1), -Height / 2.0);
            calcPoints.Add(point3D3);
          }
          else if ((double) index % 2.0 == 1.0)
          {
            Point3D point3D4 = new Point3D(num1 + num1 + calcPoints[calcPoints.Count - 1].X, Height / 2.0);
            calcPoints.Add(point3D4);
          }
          else
          {
            Point3D point3D5 = new Point3D(num1 + num1 + calcPoints[calcPoints.Count - 1].X, -Height / 2.0);
            calcPoints.Add(point3D5);
          }
        }
        Point3D point3D6 = new Point3D(Width, 0.0);
        calcPoints.Add(point3D6);
        break;
      case SewingPunterizType.CenterRigth:
        double num2 = Width / Convert.ToDouble(Count * 4);
        calcPoints.Add(new Point3D());
        Point3D point3D7 = new Point3D();
        for (int index = 0; index < Count * 2 - 1; ++index)
        {
          if (index == 0)
          {
            Point3D point3D8 = new Point3D(num2 + (double) index * (num2 + num2 + num2 + num2), -Height / 2.0);
            calcPoints.Add(point3D8);
            Point3D point3D9 = new Point3D(num2 + num2 + num2 + (double) index * (num2 + num2 + num2 + num2), Height / 2.0);
            calcPoints.Add(point3D9);
          }
          else if ((double) index % 2.0 == 1.0)
          {
            Point3D point3D10 = new Point3D(num2 + num2 + calcPoints[calcPoints.Count - 1].X, -Height / 2.0);
            calcPoints.Add(point3D10);
          }
          else
          {
            Point3D point3D11 = new Point3D(num2 + num2 + calcPoints[calcPoints.Count - 1].X, Height / 2.0);
            calcPoints.Add(point3D11);
          }
        }
        Point3D point3D12 = new Point3D(Width, 0.0);
        calcPoints.Add(point3D12);
        break;
      case SewingPunterizType.MinLeft:
        double num3 = Width / Convert.ToDouble(Count * 2);
        calcPoints.Add(new Point3D());
        for (int index = 0; index < Count; ++index)
        {
          Point3D point3D13 = new Point3D(num3 + (double) index * (num3 + num3), Height);
          calcPoints.Add(point3D13);
          Point3D point3D14 = new Point3D(num3 + num3 + (double) index * (num3 + num3), 0.0);
          calcPoints.Add(point3D14);
        }
        break;
      case SewingPunterizType.MinRigth:
        double num4 = Width / Convert.ToDouble(Count * 2);
        calcPoints.Add(new Point3D());
        for (int index = 0; index < Count; ++index)
        {
          Point3D point3D15 = new Point3D(num4 + (double) index * (num4 + num4), -Height);
          calcPoints.Add(point3D15);
          Point3D point3D16 = new Point3D(num4 + num4 + (double) index * (num4 + num4), 0.0);
          calcPoints.Add(point3D16);
        }
        break;
    }
    if (Angle > 0.0)
      clsInit.cVector5.Rotate(new Point3D(), Angle, Plane.XY, ref calcPoints);
    clsInit.cVector5.Move(new Point3D(), refPoint, ref calcPoints);
  }

  public bool doOffset(
    List<buEntity> refEntities,
    double Offset,
    SewingOffsetOptions Options,
    ref List<buEntity> offsetedEntities,
    ref List<Point3D> Points)
  {
    List<buEntity> SortedEntities = new List<buEntity>();
    SortbuSettings Settings = new SortbuSettings();
    SortbuResult Result = new SortbuResult();
    Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
    offsetedEntities.Clear();
    offsetedEntities = new List<buEntity>();
    bool flag1;
    if (refEntities.Count == 0)
    {
      flag1 = false;
    }
    else
    {
      List<Point3D> Points1 = new List<Point3D>();
      clsInit.cVector5.SortEntitiesByRefPoint(refEntities[0].Vertices[0], ref refEntities, Settings, ref SortedEntities, ref Result);
      clsInit.cVector5.EntitiesToPointsWithCamDirection(SortedEntities, 0.01, ref Points1);
      if (Points1.Count == 0)
      {
        flag1 = false;
      }
      else
      {
        double Offset1 = Offset;
        bool flag2;
        if (flag2 = clsInit.cVector5.IsClosed(Points1))
        {
          if (Options.ClosedType == CamClosedContourType.Inner)
          {
            double num = -Math.Abs(Offset);
          }
          Offset1 = Options.ClosedType != CamClosedContourType.Outter ? 0.0 : Math.Abs(Offset);
        }
        List<Point3D> OffsetedPoints = new List<Point3D>();
        CamOpenContourType2 OpenContourType = CamOpenContourType2.Left;
        if (Options.OpenType == CamOpenContourType.Right)
          OpenContourType = CamOpenContourType2.Right;
        else if (Options.OpenType == CamOpenContourType.Center)
          OpenContourType = CamOpenContourType2.Center;
        clsInit.cVector5.OffsetContour(Points1, Offset1, Options.CornerTyppe, OpenContourType, Plane.XY, 0.0, ref OffsetedPoints);
        if (!flag2 && OffsetedPoints.Count > 0 & Points1.Count > 0)
        {
          if (Options.MakeSameStartOffsetYLevel)
            OffsetedPoints[0].Y = Points1[0].Y;
          if (Options.MakeSameEndOffsetYLevel)
            OffsetedPoints[OffsetedPoints.Count - 1].Y = Points1[Points1.Count - 1].Y;
        }
        buLinearPath buLinearPath = new buLinearPath(OffsetedPoints);
        offsetedEntities.Add((buEntity) buLinearPath);
        Points = new List<Point3D>();
        clsInit.cVector5.EntitiesToPointsWithCamDirection(offsetedEntities, 0.005, ref Points);
        flag1 = true;
      }
    }
    return flag1;
  }

  public bool doOffset(
    List<Entity> refEntities,
    double Offset,
    SewingOffsetOptions Options,
    ref List<Entity> offsetedEntities,
    ref List<Point3D> Points)
  {
    List<Entity> SortedEntities = new List<Entity>();
    SortSettings Settings = new SortSettings();
    SortResult Result = new SortResult();
    Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
    offsetedEntities.Clear();
    offsetedEntities = new List<Entity>();
    bool flag1;
    if (refEntities.Count == 0)
    {
      flag1 = false;
    }
    else
    {
      List<Point3D> Points1 = new List<Point3D>();
      clsInit.cVector5.SortEntitiesByRefPoint(refEntities[0].Vertices[0], ref refEntities, Settings, ref SortedEntities, ref Result);
      clsInit.cVector5.EntitiesToPointsWithCamDirection(SortedEntities, 0.01, ref Points1);
      if (Points1.Count == 0)
      {
        flag1 = false;
      }
      else
      {
        double Offset1 = Offset;
        bool flag2;
        if (flag2 = clsInit.cVector5.IsClosed(Points1))
        {
          if (Options.ClosedType == CamClosedContourType.Inner)
          {
            double num = -Math.Abs(Offset);
          }
          Offset1 = Options.ClosedType != CamClosedContourType.Outter ? 0.0 : Math.Abs(Offset);
        }
        List<Point3D> OffsetedPoints = new List<Point3D>();
        CamOpenContourType2 OpenContourType = CamOpenContourType2.Left;
        if (Options.OpenType == CamOpenContourType.Right)
          OpenContourType = CamOpenContourType2.Right;
        else if (Options.OpenType == CamOpenContourType.Center)
          OpenContourType = CamOpenContourType2.Center;
        clsInit.cVector5.OffsetContour(Points1, Offset1, Options.CornerTyppe, OpenContourType, Plane.XY, 0.0, ref OffsetedPoints);
        if (!flag2 && OffsetedPoints.Count > 0 & Points1.Count > 0)
        {
          if (Options.MakeSameStartOffsetYLevel)
            OffsetedPoints[0].Y = Points1[0].Y;
          if (Options.MakeSameEndOffsetYLevel)
            OffsetedPoints[OffsetedPoints.Count - 1].Y = Points1[Points1.Count - 1].Y;
        }
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) OffsetedPoints);
        offsetedEntities.Add((Entity) linearPath);
        Points = new List<Point3D>();
        clsInit.cVector5.EntitiesToPointsWithCamDirection(offsetedEntities, 0.005, ref Points);
        flag1 = true;
      }
    }
    return flag1;
  }

  public bool doOffset(
    List<Point3D> refPoints,
    double Offset,
    SewingOffsetOptions Options,
    ref List<Point3D> offsetedPoints)
  {
    offsetedPoints.Clear();
    offsetedPoints = new List<Point3D>();
    bool flag1;
    if (refPoints.Count == 0)
    {
      flag1 = false;
    }
    else
    {
      double Offset1 = Offset;
      bool flag2;
      if (flag2 = clsInit.cVector5.IsClosed(refPoints))
      {
        if (Options.ClosedType == CamClosedContourType.Inner)
        {
          double num = -Math.Abs(Offset);
        }
        Offset1 = Options.ClosedType != CamClosedContourType.Outter ? 0.0 : Math.Abs(Offset);
      }
      List<Point3D> point3DList = new List<Point3D>();
      CamOpenContourType2 OpenContourType = CamOpenContourType2.Left;
      if (Options.OpenType == CamOpenContourType.Right)
        OpenContourType = CamOpenContourType2.Right;
      else if (Options.OpenType == CamOpenContourType.Center)
        OpenContourType = CamOpenContourType2.Center;
      clsInit.cVector5.OffsetContour(refPoints, Offset1, Options.CornerTyppe, OpenContourType, Plane.XY, 0.0, ref offsetedPoints);
      if (!flag2 && offsetedPoints.Count > 0 & refPoints.Count > 0)
      {
        if (Options.MakeSameStartOffsetYLevel)
          offsetedPoints[0].Y = refPoints[0].Y;
        if (Options.MakeSameEndOffsetYLevel)
          offsetedPoints[offsetedPoints.Count - 1].Y = refPoints[refPoints.Count - 1].Y;
      }
      flag1 = true;
    }
    return flag1;
  }

  public void doDrawMainEntities(List<buEntity> MainEntity)
  {
    this.doDrawMainEntities(MainEntity, false);
  }

  public void doDrawMainEntities(List<buEntity> MainEntity, bool AutoConnect)
  {
    if (ccVars.Pages.Count > 0)
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    Point3D start1 = new Point3D();
    for (int index1 = 0; index1 <= MainEntity.Count - 1; ++index1)
    {
      devDept.Eyeshot.Entities.Point point1 = new devDept.Eyeshot.Entities.Point(new Point3D(MainEntity[index1].StartPoint.X, MainEntity[index1].StartPoint.Y));
      point1.LayerName = clsSewing.varSewingSettings.layerNameDrawingPoints;
      point1.ColorMethod = colorMethodType.byLayer;
      point1.Color = clsSewing.varSewingSettings.colorDrawingPoints;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) point1);
      devDept.Eyeshot.Entities.Point point2 = new devDept.Eyeshot.Entities.Point(new Point3D(MainEntity[index1].EndPoint.X, MainEntity[index1].EndPoint.Y));
      point2.LayerName = clsSewing.varSewingSettings.layerNameDrawingPoints;
      point2.ColorMethod = colorMethodType.byLayer;
      point2.Color = clsSewing.varSewingSettings.colorDrawingPoints;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) point2);
      if (MainEntity[index1].Sewing.Vertex.Count == 0 | MainEntity[index1].Sewing.Vertex.Count == 1)
      {
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(MainEntity[index1], ref copiedEntity);
        copiedEntity.LayerName = clsSewing.varSewingSettings.layerNameDrawing;
        if (MainEntity[index1].Sewing.isStitchDrawing)
        {
          copiedEntity.ColorMethod = colorMethodType.byLayer;
        }
        else
        {
          copiedEntity.ColorMethod = colorMethodType.byEntity;
          copiedEntity.Color = clsSewing.varSewingSettings.colorNoStitch;
        }
        if (AutoConnect)
        {
          Point3D end = (Point3D) null;
          Point3D start2 = (Point3D) null;
          for (int index2 = index1 - 1; index2 >= 0; --index2)
          {
            if (MainEntity[index2].Sewing.Vertex.Count > 0)
            {
              int index3 = MainEntity[index2].Sewing.Vertex.Count - 1;
              start2 = new Point3D(MainEntity[index2].Sewing.Vertex[index3].Point.X + MainEntity[index2].Sewing.Vertex[index3].DeltaX, MainEntity[index2].Sewing.Vertex[index3].Point.Y + MainEntity[index2].Sewing.Vertex[index3].DeltaY);
              index2 = 0;
            }
          }
          int count;
          for (int index4 = index1 + 1; index4 <= MainEntity.Count - 1; index4 = count + 1)
          {
            if (MainEntity[index4].Sewing.Vertex.Count > 1)
            {
              end = new Point3D(MainEntity[index4].Sewing.Vertex[0].Point.X + MainEntity[index4].Sewing.Vertex[0].DeltaX, MainEntity[index4].Sewing.Vertex[0].Point.Y + MainEntity[index4].Sewing.Vertex[0].DeltaY);
              count = MainEntity.Count;
            }
            else
            {
              end = new Point3D(MainEntity[index4].Vertices[0].X, MainEntity[index4].Vertices[0].Y);
              count = MainEntity.Count;
            }
          }
          if (end != (Point3D) null & start2 != (Point3D) null)
          {
            Line line = new Line(start2, end);
            line.EntityData = (object) new CustomData();
            line.ColorMethod = colorMethodType.byEntity;
            line.Color = clsSewing.varSewingSettings.colorNoStitch;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
            start1 = new Point3D(end.X, end.Y);
          }
          if (end != (Point3D) null & start2 == (Point3D) null)
          {
            Line line = new Line(start1, end);
            line.EntityData = (object) new CustomData();
            line.ColorMethod = colorMethodType.byEntity;
            line.Color = clsSewing.varSewingSettings.colorNoStitch;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
            start1 = new Point3D(end.X, end.Y);
          }
          else if (MainEntity[index1].Sewing.Vertex.Count > 0 && !buCompare5.EQ(start1, MainEntity[index1].Sewing.Vertex[0].Point))
          {
            Line line = new Line(start1, MainEntity[index1].Sewing.Vertex[0].Point);
            line.EntityData = (object) new CustomData();
            line.ColorMethod = colorMethodType.byEntity;
            line.Color = clsSewing.varSewingSettings.colorNoStitch;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
            start1 = new Point3D(MainEntity[index1].Sewing.Vertex[0].Point.X, MainEntity[index1].Sewing.Vertex[0].Point.Y);
          }
        }
        else
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
      }
      else
      {
        List<Point3D> points = new List<Point3D>();
        if (MainEntity[index1].Sewing.Vertex[0].Punterez != null)
        {
          Point3D refPoint = new Point3D(MainEntity[index1].Sewing.Vertex[0].Point.X + MainEntity[index1].Sewing.Vertex[0].DeltaX, MainEntity[index1].Sewing.Vertex[0].Point.Y + MainEntity[index1].Sewing.Vertex[0].DeltaY);
          List<Point3D> calcPoints = new List<Point3D>();
          clsInit.appSewing.doPunteriz(refPoint, MainEntity[index1].Sewing.Vertex[0].Punterez.Length, MainEntity[index1].Sewing.Vertex[0].Punterez.Width, MainEntity[index1].Sewing.Vertex[0].Punterez.Height, MainEntity[index1].Sewing.Vertex[0].Punterez.Angle, MainEntity[index1].Sewing.Vertex[0].Punterez.PunterizType, ref calcPoints);
          calcPoints.Reverse();
          points.AddRange((IEnumerable<Point3D>) calcPoints);
        }
        if (MainEntity[index1].Sewing.Vertex[MainEntity[index1].Sewing.Vertex.Count - 1].Punterez != null)
        {
          Point3D refPoint = new Point3D(MainEntity[index1].Sewing.Vertex[MainEntity[index1].Sewing.Vertex.Count - 1].Point.X + MainEntity[index1].Sewing.Vertex[MainEntity[index1].Sewing.Vertex.Count - 1].DeltaX, MainEntity[index1].Sewing.Vertex[MainEntity[index1].Sewing.Vertex.Count - 1].Point.Y + MainEntity[index1].Sewing.Vertex[MainEntity[index1].Sewing.Vertex.Count - 1].DeltaY);
          List<Point3D> calcPoints = new List<Point3D>();
          SewingPunteriz punterez = MainEntity[index1].Sewing.Vertex[MainEntity[index1].Sewing.Vertex.Count - 1].Punterez;
          clsInit.appSewing.doPunteriz(refPoint, punterez.Length, punterez.Width, punterez.Height, punterez.Angle, punterez.PunterizType, ref calcPoints);
          calcPoints.Reverse();
          points.AddRange((IEnumerable<Point3D>) calcPoints);
        }
        for (int index5 = 0; index5 <= MainEntity[index1].Sewing.Vertex.Count - 1; ++index5)
        {
          points.Add(new Point3D(MainEntity[index1].Sewing.Vertex[index5].Point.X + MainEntity[index1].Sewing.Vertex[index5].DeltaX, MainEntity[index1].Sewing.Vertex[index5].Point.Y + MainEntity[index1].Sewing.Vertex[index5].DeltaY));
          devDept.Eyeshot.Entities.Point point3 = new devDept.Eyeshot.Entities.Point(new Point3D(MainEntity[index1].Sewing.Vertex[index5].Point.X + MainEntity[index1].Sewing.Vertex[index5].DeltaX, MainEntity[index1].Sewing.Vertex[index5].Point.Y + MainEntity[index1].Sewing.Vertex[index5].DeltaY));
          point3.LayerName = clsSewing.varSewingSettings.layerNamePoint;
          point3.ColorMethod = colorMethodType.byLayer;
          if (MainEntity[index1].Sewing.Vertex[index5].Codes.Count > 0)
          {
            point3.Color = clsSewing.varSewingSettings.colorVertexHasCode;
            point3.ColorMethod = colorMethodType.byEntity;
          }
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) point3);
        }
        start1 = new Point3D(MainEntity[index1].Sewing.Vertex[MainEntity[index1].Sewing.Vertex.Count - 1].Point.X + MainEntity[index1].Sewing.Vertex[MainEntity[index1].Sewing.Vertex.Count - 1].DeltaX, MainEntity[index1].Sewing.Vertex[MainEntity[index1].Sewing.Vertex.Count - 1].Point.Y + MainEntity[index1].Sewing.Vertex[MainEntity[index1].Sewing.Vertex.Count - 1].DeltaY);
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
        linearPath.LayerName = clsSewing.varSewingSettings.layerNameDrawingDevided;
        if (MainEntity[index1].Sewing.isStitchDrawing)
        {
          linearPath.ColorMethod = colorMethodType.byLayer;
        }
        else
        {
          linearPath.ColorMethod = colorMethodType.byEntity;
          linearPath.Color = clsSewing.varSewingSettings.colorNoStitch;
        }
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) linearPath);
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(MainEntity[index1], ref copiedEntity);
        copiedEntity.LayerName = clsSewing.varSewingSettings.layerNameDrawing;
        if (copiedEntity is Line)
        {
          ((Line) copiedEntity).StartPoint.X = MainEntity[index1].Sewing.Vertex[0].Point.X + MainEntity[index1].Sewing.Vertex[0].DeltaX;
          ((Line) copiedEntity).StartPoint.Y = MainEntity[index1].Sewing.Vertex[0].Point.Y + MainEntity[index1].Sewing.Vertex[0].DeltaY;
          ((Line) copiedEntity).EndPoint.X = MainEntity[index1].Sewing.Vertex[MainEntity[index1].Sewing.Vertex.Count - 1].Point.X + MainEntity[index1].Sewing.Vertex[0].DeltaX;
          ((Line) copiedEntity).EndPoint.Y = MainEntity[index1].Sewing.Vertex[MainEntity[index1].Sewing.Vertex.Count - 1].Point.Y + MainEntity[index1].Sewing.Vertex[0].DeltaY;
          copiedEntity.Regen(0.01);
        }
        if (MainEntity[index1].Sewing.isStitchDrawing)
        {
          copiedEntity.ColorMethod = colorMethodType.byLayer;
        }
        else
        {
          copiedEntity.ColorMethod = colorMethodType.byEntity;
          copiedEntity.Color = clsSewing.varSewingSettings.colorNoStitch;
        }
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void doMovePoint(
    double MoveValue,
    string MoveAxis,
    List<SewingPickType> PickList,
    ref List<buEntity> MainEntityList,
    bool AutoConnect = false)
  {
    bool flag = false;
    for (int index = 0; index <= PickList.Count - 1; ++index)
    {
      if (PickList[index].PickType == SewingPickClickType.Vertex)
      {
        if (MoveAxis == "X")
          this.SewingBase.MainEntityList[PickList[index].EntityIndex].Sewing.Vertex[PickList[index].VertexIndex].DeltaX += MoveValue;
        else
          this.SewingBase.MainEntityList[PickList[index].EntityIndex].Sewing.Vertex[PickList[index].VertexIndex].DeltaY += MoveValue;
      }
      if (PickList[index].PickType == SewingPickClickType.Entity)
      {
        flag = true;
        if (MoveAxis == "X")
        {
          if (PickList[index].EntitySelectType == SewingPickEntitySelectType.StartPoint)
            this.SewingBase.MainEntityList[PickList[index].EntityIndex].StartPoint.X += MoveValue;
          if (PickList[index].EntitySelectType == SewingPickEntitySelectType.EndPoint)
            this.SewingBase.MainEntityList[PickList[index].EntityIndex].EndPoint.X += MoveValue;
        }
        else
        {
          if (PickList[index].EntitySelectType == SewingPickEntitySelectType.StartPoint)
            this.SewingBase.MainEntityList[PickList[index].EntityIndex].StartPoint.Y += MoveValue;
          if (PickList[index].EntitySelectType == SewingPickEntitySelectType.EndPoint)
            this.SewingBase.MainEntityList[PickList[index].EntityIndex].EndPoint.Y += MoveValue;
        }
      }
    }
    if (flag)
      this.doDevideEntities(ref this.SewingBase.MainEntityList, new SewingDevideOptions()
      {
        DrawingLayerName = clsSewing.varSewingSettings.layerNameDrawing,
        PointLayerName = clsSewing.varSewingSettings.layerNamePoint
      });
    this.doDrawMainEntities(this.SewingBase.MainEntityList, AutoConnect);
  }

  public void doDeleteProperties()
  {
    if (this.cmdTree == "startlock" && this.selectedEntIndex >= 0 & this.selectedEntIndex <= this.SewingBase.MainEntityList.Count - 1 && this.SewingBase.MainEntityList[this.selectedEntIndex].Sewing != null)
    {
      this.SewingBase.MainEntityList[this.selectedEntIndex].Sewing.StartStitchCount = 0;
      this.SewingBase.MainEntityList[this.selectedEntIndex].Sewing.StartStitchType = SewingAddStitchType.None;
      this.UndoBuffer();
      clsInit.appSewing.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
      this.JobUpdate();
    }
    if (this.cmdTree == "endlock" && this.selectedEntIndex >= 0 & this.selectedEntIndex <= this.SewingBase.MainEntityList.Count - 1 && this.SewingBase.MainEntityList[this.selectedEntIndex].Sewing != null)
    {
      this.SewingBase.MainEntityList[this.selectedEntIndex].Sewing.EndStitchCount = 0;
      this.SewingBase.MainEntityList[this.selectedEntIndex].Sewing.EndStitchType = SewingAddStitchType.None;
      this.UndoBuffer();
      clsInit.appSewing.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
      this.JobUpdate();
    }
    if (this.cmdTree == "punterez" && this.selectedEntIndex >= 0 & this.selectedEntIndex <= this.SewingBase.MainEntityList.Count - 1 && this.SewingBase.MainEntityList[this.selectedEntIndex].Sewing != null && this.selectedVertexIndex >= 0 & this.selectedVertexIndex <= this.SewingBase.MainEntityList[this.selectedEntIndex].Sewing.Vertex.Count - 1)
    {
      this.SewingBase.MainEntityList[this.selectedEntIndex].Sewing.Vertex[this.selectedVertexIndex].Punterez = (SewingPunteriz) null;
      this.UndoBuffer();
      clsInit.appSewing.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
      this.JobUpdate();
    }
    if (!(this.cmdTree == "codes") || !(this.selectedEntIndex >= 0 & this.selectedEntIndex <= this.SewingBase.MainEntityList.Count - 1) || this.SewingBase.MainEntityList[this.selectedEntIndex].Sewing == null || !(this.selectedVertexIndex >= 0 & this.selectedVertexIndex <= this.SewingBase.MainEntityList[this.selectedEntIndex].Sewing.Vertex.Count - 1))
      return;
    this.SewingBase.MainEntityList[this.selectedEntIndex].Sewing.Vertex[this.selectedVertexIndex].Codes.Clear();
    this.UndoBuffer();
    clsInit.appSewing.DrawSewingData(this.SewingBase, clsItem.frmEditor.viewport.Entities);
    this.JobUpdate();
  }

  public void RemoveStitchEndCommand(ref SewingInfo Sewing)
  {
    for (int index1 = 0; index1 <= Sewing.Vertex.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= Sewing.Vertex[index1].Codes.Count - 1; ++index2)
      {
        if (Sewing.Vertex[index1].Codes[index2].Data1 == 16.0)
          Sewing.Vertex[index1].Codes[index2].Data1 = 0.0;
        if (Sewing.Vertex[index1].Codes[index2].Data2 == 16.0)
          Sewing.Vertex[index1].Codes[index2].Data2 = 0.0;
        if (Sewing.Vertex[index1].Codes[index2].Data3 == 16.0)
          Sewing.Vertex[index1].Codes[index2].Data3 = 0.0;
        if (Sewing.Vertex[index1].Codes[index2].Data4 == 16.0)
          Sewing.Vertex[index1].Codes[index2].Data4 = 0.0;
        if (Sewing.Vertex[index1].Codes[index2].Data5 == 16.0)
          Sewing.Vertex[index1].Codes[index2].Data5 = 0.0;
        if (Sewing.Vertex[index1].Codes[index2].Codes == SewingCodes.PnomaticSet4)
          Sewing.Vertex[index1].Codes[index2].Codes = SewingCodes.None;
      }
    }
  }

  public void CreateSewingTableListAsYesimModel1(
    ref SewingMain SewingBase,
    ref List<SewingJobItem> SewingTableList)
  {
    SewingTableList.Clear();
    for (int index1 = 0; index1 <= SewingBase.MainEntityList.Count - 1; ++index1)
    {
      SewingInfo sewing1 = SewingBase.MainEntityList[index1].Sewing;
      if (sewing1.Vertex.Count > 1 && sewing1.StartStitchCount > 0 & sewing1.isStitchDrawing)
      {
        if (sewing1.StartStitchType == SewingAddStitchType.OneWay)
        {
          for (int startStitchCount = sewing1.StartStitchCount; startStitchCount >= 1; --startStitchCount)
          {
            SewingJobItem S = new SewingJobItem();
            this.CreateSewingJobItem(ref S, index1, startStitchCount, sewing1);
            if (startStitchCount == sewing1.StartStitchCount)
              clsInit.cSewing.AddCodeSewingJobItem(ref S, 22);
            if (startStitchCount == 1)
              clsInit.cSewing.AddCodeSewingJobItem(ref S, 23);
            if (SewingTableList.Count == 0)
              SewingTableList.Add(S);
            else if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S.PositionY, 0.1))
              SewingTableList.Add(S);
          }
        }
        else
        {
          for (int j = 0; j <= sewing1.StartStitchCount - 1; ++j)
          {
            SewingJobItem S = new SewingJobItem();
            this.CreateSewingJobItem(ref S, index1, j, sewing1);
            if (j == 0)
              clsInit.cSewing.AddCodeSewingJobItem(ref S, 22);
            if (SewingTableList.Count == 0)
              SewingTableList.Add(S);
            else if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S.PositionY, 0.1))
              SewingTableList.Add(S);
          }
          for (int startStitchCount = sewing1.StartStitchCount; startStitchCount >= 1; --startStitchCount)
          {
            SewingJobItem S = new SewingJobItem();
            this.CreateSewingJobItem(ref S, index1, startStitchCount, sewing1);
            if (startStitchCount == 1)
              clsInit.cSewing.AddCodeSewingJobItem(ref S, 23);
            if (SewingTableList.Count == 0)
              SewingTableList.Add(S);
            else if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S.PositionY, 0.1))
              SewingTableList.Add(S);
          }
        }
      }
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      if (sewing1.Vertex.Count > 0 && sewing1.Vertex[sewing1.Vertex.Count - 1].Punterez != null)
        num2 = sewing1.Vertex[sewing1.Vertex.Count - 1].Punterez.Length;
      if (sewing1.Vertex.Count == 0 & index1 <= SewingBase.MainEntityList.Count - 2)
      {
        SewingInfo sewing2 = SewingBase.MainEntityList[index1 + 1].Sewing;
        SewingJobItem sewingJobItem = new SewingJobItem();
        if (sewing2.Vertex.Count > 0)
        {
          sewingJobItem.PositionX = sewing2.Vertex[0].Point.X + sewing2.Vertex[0].DeltaX;
          sewingJobItem.PositionY = sewing2.Vertex[0].Point.Y + sewing2.Vertex[0].DeltaY;
          SewingTableList.Add(sewingJobItem);
        }
      }
      int num4 = 0;
      if (index1 > 0 && SewingBase.MainEntityList[index1 - 1].Sewing != null && SewingBase.MainEntityList[index1 - 1].Sewing.isStitchDrawing & sewing1.isStitchDrawing && SewingBase.MainEntityList[index1 - 1].Sewing.Vertex.Count > 0)
      {
        Point3D point1 = SewingBase.MainEntityList[index1 - 1].Sewing.Vertex[SewingBase.MainEntityList[index1 - 1].Sewing.Vertex.Count - 1].Point;
        if ((sewing1.Vertex == null ? 0 : (sewing1.Vertex.Count > 0 ? 1 : 0)) != 0)
        {
          Point3D point2 = sewing1.Vertex[0].Point;
          if (buCompare5.EQ(point1, point2))
            num4 = 1;
        }
      }
      for (int index2 = num4; index2 <= sewing1.Vertex.Count - 1; ++index2)
      {
        SewingJobItem S = new SewingJobItem();
        if (index2 > 0)
          num3 = Point3D.Distance(sewing1.Vertex[index2].Point, sewing1.Vertex[0].Point);
        double num5 = Point3D.Distance(sewing1.Vertex[index2].Point, sewing1.Vertex[sewing1.Vertex.Count - 1].Point);
        if (sewing1.Vertex[index2].Punterez != null & index2 == 0 & sewing1.isStitchDrawing)
        {
          SewingVertex sewingVertex = sewing1.Vertex[index2];
          Point3D refPoint = new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY);
          List<Point3D> calcPoints = new List<Point3D>();
          List<Point3D> pntDevided = new List<Point3D>();
          List<Point3D> point3DList = new List<Point3D>();
          clsInit.appSewing.doPunteriz(refPoint, sewingVertex.Punterez.Length, sewingVertex.Punterez.Width, sewingVertex.Punterez.Height, sewingVertex.Punterez.Angle, sewingVertex.Punterez.PunterizType, ref calcPoints);
          buLine refEntity = new buLine(calcPoints[0], calcPoints[calcPoints.Count - 1]);
          clsInit.cVector5.EntityDevideByCamDir((buEntity) refEntity, sewing1.StitchLengt, ref pntDevided);
          point3DList.AddRange((IEnumerable<Point3D>) pntDevided);
          point3DList.Reverse();
          num1 = sewingVertex.Punterez.Length;
          for (int index3 = 0; index3 <= pntDevided.Count - 1; ++index3)
          {
            S = new SewingJobItem();
            S.StitchStep = sewing1.StitchLengt;
            S.HeadSpeed = sewing1.HeadSpeed;
            S.StitchedWay = sewing1.isStitchDrawing;
            S.FootHeight = sewing1.Vertex[index2].FootHeight;
            if (sewing1.Vertex[index2].Speed > 0.0)
              S.HeadSpeed = sewing1.Vertex[index2].Speed;
            S.PositionX = pntDevided[index3].X + sewing1.Vertex[index2].DeltaX;
            S.PositionY = pntDevided[index3].Y + sewing1.Vertex[index2].DeltaY;
            S.Style = sewing1.Style;
            if (index3 == 0)
            {
              clsInit.cSewing.GetVertexCodes(ref S, sewing1.Vertex[index2]);
              clsInit.cSewing.AddCodeSewingJobItem(ref S, 20);
            }
            SewingTableList.Add(S);
          }
          for (int index4 = 1; index4 <= point3DList.Count - 1; ++index4)
          {
            S = new SewingJobItem();
            S.StitchStep = sewing1.StitchLengt;
            S.HeadSpeed = sewing1.HeadSpeed;
            S.StitchedWay = sewing1.isStitchDrawing;
            S.FootHeight = sewing1.Vertex[index2].FootHeight;
            if (sewing1.Vertex[index2].Speed > 0.0)
              S.HeadSpeed = sewing1.Vertex[index2].Speed;
            S.PositionX = point3DList[index4].X + sewing1.Vertex[index2].DeltaX;
            S.PositionY = point3DList[index4].Y + sewing1.Vertex[index2].DeltaY;
            S.Style = sewing1.Style;
            SewingTableList.Add(S);
          }
          for (int index5 = 1; index5 <= calcPoints.Count - 1; ++index5)
          {
            S = new SewingJobItem();
            S.StitchStep = sewing1.StitchLengt;
            S.HeadSpeed = sewing1.HeadSpeed;
            S.StitchedWay = sewing1.isStitchDrawing;
            S.FootHeight = sewing1.Vertex[index2].FootHeight;
            if (sewing1.Vertex[index2].Speed > 0.0)
              S.HeadSpeed = sewing1.Vertex[index2].Speed;
            S.PositionX = calcPoints[index5].X + sewing1.Vertex[index2].DeltaX;
            S.PositionY = calcPoints[index5].Y + sewing1.Vertex[index2].DeltaY;
            S.Style = sewing1.Style;
            if (index5 == calcPoints.Count - 1)
              clsInit.cSewing.AddCodeSewingJobItem(ref S, 23);
            SewingTableList.Add(S);
          }
        }
        S = new SewingJobItem();
        this.CreateSewingJobItem(ref S, index1, index2, sewing1);
        if (index2 == 0 & sewing1.StartStitchCount > 0)
          clsInit.cSewing.ClearCodeSewingJobItem(ref S);
        if (index2 > 0 & index2 < sewing1.Vertex.Count - 1 && sewing1.Vertex[index2].Punterez != null & sewing1.isStitchDrawing)
        {
          SewingVertex sewingVertex = sewing1.Vertex[index2];
          Point3D refPoint = new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY);
          List<Point3D> calcPoints = new List<Point3D>();
          List<Point3D> pntDevided = new List<Point3D>();
          List<Point3D> point3DList = new List<Point3D>();
          clsInit.appSewing.doPunteriz(refPoint, sewingVertex.Punterez.Length, sewingVertex.Punterez.Width, sewingVertex.Punterez.Height, sewingVertex.Punterez.Angle, sewingVertex.Punterez.PunterizType, ref calcPoints);
          buLine refEntity = new buLine(calcPoints[0], calcPoints[calcPoints.Count - 1]);
          clsInit.cVector5.EntityDevideByCamDir((buEntity) refEntity, sewing1.StitchLengt, ref pntDevided);
          num1 = sewingVertex.Punterez.Length;
          int num6 = -1;
          int num7 = -1;
          double num8 = 9999999.0;
          double num9 = 9999999.0;
          for (int index6 = index2; index6 <= sewing1.Vertex.Count - 1; ++index6)
          {
            double num10 = Point3D.Distance(sewing1.Vertex[index6].Point, pntDevided[0]);
            if (num10 < num8)
            {
              num6 = index6;
              num8 = num10;
            }
            double num11 = Point3D.Distance(sewing1.Vertex[index6].Point, pntDevided[pntDevided.Count - 1]);
            if (num11 < num9)
            {
              num7 = index6;
              num9 = num11;
            }
          }
          if (num6 >= 0 & num7 >= 0 & num6 != num7)
          {
            for (int index7 = 0; index7 <= calcPoints.Count - 1; ++index7)
            {
              S = new SewingJobItem();
              S.StitchStep = sewing1.StitchLengt;
              S.HeadSpeed = sewing1.HeadSpeed;
              S.StitchedWay = sewing1.isStitchDrawing;
              S.FootHeight = sewing1.Vertex[index2].FootHeight;
              if (sewing1.Vertex[index2].Speed > 0.0)
                S.HeadSpeed = sewing1.Vertex[index2].Speed;
              S.PositionX = calcPoints[index7].X + sewing1.Vertex[index2].DeltaX;
              S.PositionY = calcPoints[index7].Y + sewing1.Vertex[index2].DeltaY;
              S.Style = sewing1.Style;
              if (index7 == 0)
              {
                clsInit.cSewing.GetVertexCodes(ref S, sewing1.Vertex[index2]);
                clsInit.cSewing.AddCodeSewingJobItem(ref S, 20);
              }
              if (index7 == calcPoints.Count - 1)
              {
                clsInit.cSewing.GetVertexCodes(ref S, sewing1.Vertex[index2]);
                clsInit.cSewing.AddCodeSewingJobItem(ref S, 23);
              }
              SewingTableList.Add(S);
            }
            index2 = num7;
          }
        }
        if (index2 == sewing1.Vertex.Count - 1 & sewing1.EndStitchCount > 0)
          clsInit.cSewing.ClearCodeSewingJobItem(ref S);
        if ((num1 == 0.0 | num1 > 0.0 & num3 > num1 + sewing1.StitchLengt) & (num2 == 0.0 | num2 > 0.0 & num5 > num2))
        {
          if (SewingTableList.Count == 0)
            SewingTableList.Add(S);
          else if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S.PositionY, 0.1))
            SewingTableList.Add(S);
        }
        if (sewing1.Vertex[index2].Punterez != null & index2 == sewing1.Vertex.Count - 1 & sewing1.isStitchDrawing)
        {
          SewingVertex sewingVertex = sewing1.Vertex[index2];
          Point3D refPoint = new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY);
          List<Point3D> calcPoints = new List<Point3D>();
          List<Point3D> pntDevided = new List<Point3D>();
          List<Point3D> point3DList = new List<Point3D>();
          clsInit.appSewing.doPunteriz(refPoint, sewingVertex.Punterez.Length, sewingVertex.Punterez.Width, sewingVertex.Punterez.Height, sewingVertex.Punterez.Angle, sewingVertex.Punterez.PunterizType, ref calcPoints);
          buLine refEntity = new buLine(calcPoints[0], calcPoints[calcPoints.Count - 1]);
          clsInit.cVector5.EntityDevideByCamDir((buEntity) refEntity, sewing1.StitchLengt, ref pntDevided);
          point3DList.AddRange((IEnumerable<Point3D>) pntDevided);
          point3DList.Reverse();
          num1 = sewingVertex.Punterez.Length;
          for (int index8 = 1; index8 <= point3DList.Count - 1; ++index8)
          {
            S = new SewingJobItem();
            S.StitchStep = sewing1.StitchLengt;
            S.HeadSpeed = sewing1.HeadSpeed;
            S.StitchedWay = sewing1.isStitchDrawing;
            S.FootHeight = sewing1.Vertex[index2].FootHeight;
            if (sewing1.Vertex[index2].Speed > 0.0)
              S.HeadSpeed = sewing1.Vertex[index2].Speed;
            S.PositionX = point3DList[index8].X + sewing1.Vertex[index2].DeltaX;
            S.PositionY = point3DList[index8].Y + sewing1.Vertex[index2].DeltaY;
            S.Style = sewing1.Style;
            SewingTableList.Add(S);
          }
          for (int index9 = 1; index9 <= pntDevided.Count - 1; ++index9)
          {
            S = new SewingJobItem();
            S.StitchStep = sewing1.StitchLengt;
            S.HeadSpeed = sewing1.HeadSpeed;
            S.StitchedWay = sewing1.isStitchDrawing;
            S.FootHeight = sewing1.Vertex[index2].FootHeight;
            if (sewing1.Vertex[index2].Speed > 0.0)
              S.HeadSpeed = sewing1.Vertex[index2].Speed;
            S.PositionX = pntDevided[index9].X + sewing1.Vertex[index2].DeltaX;
            S.PositionY = pntDevided[index9].Y + sewing1.Vertex[index2].DeltaY;
            S.Style = sewing1.Style;
            if (index9 == 1)
              clsInit.cSewing.AddCodeSewingJobItem(ref S, 20);
            SewingTableList.Add(S);
          }
          calcPoints.Reverse();
          for (int index10 = 1; index10 <= calcPoints.Count - 1; ++index10)
          {
            S = new SewingJobItem();
            S.StitchStep = sewing1.StitchLengt;
            S.HeadSpeed = sewing1.HeadSpeed;
            S.StitchedWay = sewing1.isStitchDrawing;
            S.PositionX = calcPoints[index10].X + sewing1.Vertex[index2].DeltaX;
            S.PositionY = calcPoints[index10].Y + sewing1.Vertex[index2].DeltaY;
            S.FootHeight = sewing1.Vertex[index2].FootHeight;
            if (sewing1.Vertex[index2].Speed > 0.0)
              S.HeadSpeed = sewing1.Vertex[index2].Speed;
            S.Style = sewing1.Style;
            if (index10 == calcPoints.Count - 1)
            {
              clsInit.cSewing.GetVertexCodes(ref S, sewing1.Vertex[index2]);
              clsInit.cSewing.AddCodeSewingJobItem(ref S, 23);
            }
            SewingTableList.Add(S);
          }
        }
      }
      if (sewing1.Vertex.Count > 1 & sewing1.isStitchDrawing)
      {
        if (sewing1.EndStitchType == SewingAddStitchType.OneWay)
        {
          if (sewing1.EndStitchCount > 0)
          {
            for (int j = sewing1.Vertex.Count - 2; j >= sewing1.Vertex.Count - sewing1.EndStitchCount - 2; --j)
            {
              SewingJobItem S = new SewingJobItem();
              this.CreateSewingJobItem(ref S, index1, j, sewing1);
              if (j == sewing1.Vertex.Count - 2)
                clsInit.cSewing.AddCodeSewingJobItem(ref S, 22);
              if (j == sewing1.Vertex.Count - sewing1.EndStitchCount - 2)
                clsInit.cSewing.AddCodeSewingJobItem(ref S, 23);
              if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S.PositionY, 0.1))
                SewingTableList.Add(S);
            }
          }
        }
        else if (sewing1.EndStitchCount > 0)
        {
          for (int j = sewing1.Vertex.Count - 2; j >= sewing1.Vertex.Count - sewing1.EndStitchCount - 2; --j)
          {
            SewingJobItem S = new SewingJobItem();
            this.CreateSewingJobItem(ref S, index1, j, sewing1);
            if (j == sewing1.Vertex.Count - sewing1.EndStitchCount - 2)
              clsInit.cSewing.AddCodeSewingJobItem(ref S, 22);
            if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S.PositionY, 0.1))
              SewingTableList.Add(S);
          }
          for (int j = sewing1.Vertex.Count - sewing1.EndStitchCount - 2; j <= sewing1.Vertex.Count - 1; ++j)
          {
            SewingJobItem S = new SewingJobItem();
            this.CreateSewingJobItem(ref S, index1, j, sewing1);
            if (j == sewing1.Vertex.Count - 1)
              clsInit.cSewing.AddCodeSewingJobItem(ref S, 23);
            if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S.PositionY, 0.1))
              SewingTableList.Add(S);
          }
        }
      }
    }
    if (SewingTableList.Count > 0)
    {
      int num = 0;
      for (int index = SewingTableList.Count - 1; index >= 0; --index)
      {
        if (num <= 0 || Point3D.Distance(new Point3D(SewingTableList[index + 1].PositionX, SewingTableList[index + 1].PositionY), new Point3D(SewingTableList[index].PositionX, SewingTableList[index].PositionY)) < 0.1)
          ;
        ++num;
      }
    }
    this.AnalyseTableListAsYesimModel1(ref SewingTableList);
  }

  public void AnalyseTableListAsYesimModel1(ref List<SewingJobItem> SewingTableList)
  {
    bool flag1 = false;
    int count = SewingTableList.Count;
    for (int index = 0; index <= count - 1; ++index)
    {
      SewingJobItem S1 = SewingTableList[index];
      SewingJobItem S2 = (SewingJobItem) null;
      if (index > 0)
        S2 = SewingTableList[index - 1];
      if (S1.StitchedWay & !flag1 && !clsInit.cSewing.isCodeAvailable(S1, 4) && clsInit.cSewing.FreeAvailableCodeSequence(S1) > 0)
        clsInit.cSewing.AddCodeSewingJobItem(ref S1, 4);
      if (!S1.StitchedWay & flag1 & S2 != null && !clsInit.cSewing.isCodeAvailable(S2, 5) && clsInit.cSewing.FreeAvailableCodeSequence(S2) > 0)
        clsInit.cSewing.AddCodeSewingJobItem(ref S2, 5);
      if (index < SewingTableList.Count - 1 && clsInit.cSewing.isCodeAvailable(S1, 16 /*0x10*/))
      {
        if (SewingTableList[index].Code0 == 16 /*0x10*/)
          SewingTableList[index].Code0 = 0;
        if (SewingTableList[index].Code1 == 16 /*0x10*/)
          SewingTableList[index].Code1 = 0;
        if (SewingTableList[index].Code2 == 16 /*0x10*/)
          SewingTableList[index].Code2 = 0;
        if (SewingTableList[index].Code3 == 16 /*0x10*/)
          SewingTableList[index].Code3 = 0;
        if (SewingTableList[index].Code4 == 16 /*0x10*/)
          SewingTableList[index].Code4 = 0;
        if (SewingTableList[index].Code5 == 16 /*0x10*/)
          SewingTableList[index].Code5 = 0;
      }
      if (index == SewingTableList.Count - 1)
      {
        if (!clsInit.cSewing.isCodeAvailable(S1, 5) && clsInit.cSewing.FreeAvailableCodeSequence(S1) > 0)
          clsInit.cSewing.AddCodeSewingJobItem(ref S1, 5);
        bool flag2;
        if (flag2 = clsInit.cSewing.isCodeAvailable(S1, 16 /*0x10*/))
        {
          if (SewingTableList[index].Code0 == 16 /*0x10*/)
            SewingTableList[index].Code0 = 0;
          if (SewingTableList[index].Code1 == 16 /*0x10*/)
            SewingTableList[index].Code1 = 0;
          if (SewingTableList[index].Code2 == 16 /*0x10*/)
            SewingTableList[index].Code2 = 0;
          if (SewingTableList[index].Code3 == 16 /*0x10*/)
            SewingTableList[index].Code3 = 0;
          if (SewingTableList[index].Code4 == 16 /*0x10*/)
            SewingTableList[index].Code4 = 0;
          if (SewingTableList[index].Code5 == 16 /*0x10*/)
            SewingTableList[index].Code5 = 0;
        }
        SewingTableList.Add(new SewingJobItem(SewingTableList[index])
        {
          Code0 = 0,
          Code1 = 16 /*0x10*/,
          Code2 = 0,
          Code3 = 0,
          Code4 = 0,
          Code5 = 0
        });
        if (!flag2)
          ;
      }
      int Index = -1;
      if (clsInit.cSewing.isCodeAvailable(S1, 5, ref Index) && S1.Code1 != 5)
      {
        if (Index == 2)
          buNumeric5.ExchangeTwoVaues(ref S1.Code1, ref S1.Code2);
        if (Index == 3)
          buNumeric5.ExchangeTwoVaues(ref S1.Code1, ref S1.Code3);
        if (Index == 4)
          buNumeric5.ExchangeTwoVaues(ref S1.Code1, ref S1.Code4);
        if (Index == 5)
          buNumeric5.ExchangeTwoVaues(ref S1.Code1, ref S1.Code5);
      }
      if (clsInit.cSewing.isCodeAvailable(S1, 4, ref Index) && S1.Code1 != 4)
      {
        if (Index == 2)
          buNumeric5.ExchangeTwoVaues(ref S1.Code1, ref S1.Code2);
        if (Index == 3)
          buNumeric5.ExchangeTwoVaues(ref S1.Code1, ref S1.Code3);
        if (Index == 4)
          buNumeric5.ExchangeTwoVaues(ref S1.Code1, ref S1.Code4);
        if (Index == 5)
          buNumeric5.ExchangeTwoVaues(ref S1.Code1, ref S1.Code5);
      }
      flag1 = SewingTableList[index].StitchedWay;
    }
    for (int index = SewingTableList.Count - 1; index >= 0; --index)
    {
      if (index < SewingTableList.Count - 1 & index > 0 && !SewingTableList[index].StitchedWay & SewingTableList[index - 1].StitchedWay)
      {
        SewingJobItem sewingJobItem1 = SewingTableList[index - 1];
        SewingJobItem sewingJobItem2 = SewingTableList[index];
        if (buCompare5.EQ(sewingJobItem2.PositionX, sewingJobItem1.PositionX) & buCompare5.EQ(sewingJobItem2.PositionY, sewingJobItem1.PositionY) & sewingJobItem2.Code1 != 16 /*0x10*/)
          SewingTableList.RemoveAt(index);
      }
    }
  }
}
