// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCamSawFeedAnalysisPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCamSawFeedAnalysisPars : buSerilization5
{
  public double CountertopLHeight;
  public double CountertopLTopLegWidth;
  public double CountertopLBottomLegHeight;
  public double CountertopTrapezTopWidth;
  public double CountertopTrapezBottomWidth;

  public void CreateEdgesFromEntities(
    List<buEntity> Entities,
    MarbleJob Job,
    MarbleItem Item,
    MarbleItemCam CamItem,
    bool Outside,
    double Thickness,
    double ToolDiameter,
    int indexInside,
    ref List<marbleEdgeItem> Edges)
  {
    if (Edges == null)
      Edges = new List<marbleEdgeItem>();
    if (Job != null)
      ((marbleCountertopTapPars) this).GetEdgeID(Job, ref MarbleCountertopSettings.EdgeIndex);
    else
      ++MarbleCountertopSettings.EdgeIndex;
    ClockDirectionType clock = buCall.\u0001.EntitiesClockDirection(Entities);
    for (int index = 0; index <= Entities.Count - 1; ++index)
    {
      string name = "";
      if (((EntityDataSet) ((CustomData) Entities[index]).Info).Data != null)
        name = ((EntityDataSet) ((CustomData) Entities[index]).Info).Data;
      if (name.Trim().Length == 0)
        name = buLangTranslate.preDef.Edge;
      marbleEdgeItem marbleEdgeItem = (marbleEdgeItem) null;
      if (Outside)
      {
        marbleEdgeItem = (marbleEdgeItem) new \u0007.\u0001(name, 0.0, clock, Thickness, false, ((marbleMaterialPars) MarbleEntitiesSettings.varCountertopSettings).SocketDefaultWidth, ((marbleMaterialPars) MarbleEntitiesSettings.varCountertopSettings).SocketDefaultHeight);
      }
      else
      {
        double num1 = buCall.\u0001.EntityLength(Entities[index]);
        double num2 = ((marbleDrillPars) buCall.\u0001).DistanceCalcFromToolDiameterAndThickness(ToolDiameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, 0.0) + ((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).InnerCutSafeDistance;
        if (ToolDiameter == 0.0)
          num2 = 0.0;
        if (num1 > num2)
        {
          marbleEdgeItem = (marbleEdgeItem) new \u0007.\u0001(name, 0.0, clock, Thickness, true, ((marbleMaterialPars) MarbleEntitiesSettings.varCountertopSettings).SocketDefaultWidth, ((marbleMaterialPars) MarbleEntitiesSettings.varCountertopSettings).SocketDefaultHeight);
          ((MarbleSliceType) marbleEdgeItem).OutsideInside = OutsideInsideType.Inside;
          ((MarbleMillingToolType) marbleEdgeItem).IndexEntitySub = -1;
        }
      }
      if (marbleEdgeItem != null)
      {
        ((MarbleCornerCleanToolType) marbleEdgeItem).IndexEntity = index;
        ((MarbleMillingToolType) marbleEdgeItem).IndexInside = indexInside;
        buDiametricDim.Copy(Entities[index], ref ((MarbleSliceType) marbleEdgeItem).refEntity);
        ((AnalyseEntitiesSetting) ((CustomData) ((MarbleSliceType) marbleEdgeItem).refEntity).Info).EntityIndex = index;
        ((AnalyseEntitiesSetting) ((CustomData) ((MarbleSliceType) marbleEdgeItem).refEntity).Info).InsideIndex = indexInside;
        ((EntityDataSet) ((CustomData) ((MarbleSliceType) marbleEdgeItem).refEntity).Info).ItemID = ((MarbleProgramSettings) Item).ID;
        ((EntityDataSet) ((CustomData) ((MarbleSliceType) marbleEdgeItem).refEntity).Info).CamID = ((MarbleMachineSettings) CamItem).CamID;
        ((EntityDataSet) ((CustomData) ((MarbleSliceType) marbleEdgeItem).refEntity).Info).EdgeID = MarbleCountertopSettings.EdgeIndex;
        this.CreateEdgeEntity(((MarbleSliceType) marbleEdgeItem).refEntity, new Point3D(), Outside, ((MarbleProgramSettings) Item).ID, ((MarbleMachineSettings) CamItem).CamID, ((MarbleToolType) marbleEdgeItem).EdgeID, index, -1, indexInside, ref ((MarbleSliceType) marbleEdgeItem).drawEntity);
        ((marbleCountertopTapPars) this).GetEdgeID(Job, ref ((MarbleToolType) marbleEdgeItem).EdgeID);
        ((MarbleMillingToolType) marbleEdgeItem).CamID = ((MarbleMachineSettings) CamItem).CamID;
        ((MarbleToolType) marbleEdgeItem).ItemID = ((MarbleProgramSettings) Item).ID;
        Edges.Add(marbleEdgeItem);
        ++MarbleCountertopSettings.EdgeIndex;
      }
    }
  }

  public void CreateEdgesFromEntity(
    buEntity Ent,
    int EntityIndex,
    ClockDirectionType CD,
    MarbleJob Job,
    MarbleItem Item,
    MarbleItemCam CamItem,
    bool Outside,
    double Thickness,
    double ToolDiameter,
    int indexInside,
    ref marbleEdgeItem EdgeItem)
  {
    string name = "";
    if (((EntityDataSet) ((CustomData) Ent).Info).Data != null)
      name = ((EntityDataSet) ((CustomData) Ent).Info).Data;
    if (name.Trim().Length == 0)
      name = buLangTranslate.preDef.Edge;
    EdgeItem = (marbleEdgeItem) null;
    if (Outside)
    {
      EdgeItem = (marbleEdgeItem) new \u0007.\u0001(name, 0.0, CD, Thickness, false, ((marbleMaterialPars) MarbleEntitiesSettings.varCountertopSettings).SocketDefaultWidth, ((marbleMaterialPars) MarbleEntitiesSettings.varCountertopSettings).SocketDefaultHeight);
    }
    else
    {
      double num1 = buCall.\u0001.EntityLength(Ent);
      double num2 = ((marbleDrillPars) buCall.\u0001).DistanceCalcFromToolDiameterAndThickness(ToolDiameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, 0.0) + ((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).InnerCutSafeDistance;
      if (ToolDiameter == 0.0)
        num2 = 0.0;
      if (num1 > num2)
      {
        EdgeItem = (marbleEdgeItem) new \u0007.\u0001(name, 0.0, CD, Thickness, true, ((marbleMaterialPars) MarbleEntitiesSettings.varCountertopSettings).SocketDefaultWidth, ((marbleMaterialPars) MarbleEntitiesSettings.varCountertopSettings).SocketDefaultHeight);
        ((MarbleSliceType) EdgeItem).OutsideInside = OutsideInsideType.Inside;
        ((MarbleMillingToolType) EdgeItem).IndexEntitySub = -1;
      }
    }
    if (EdgeItem == null)
      return;
    if (((CustomData) Ent).Marble != null)
      ((MarbleCornerCleanToolType) EdgeItem).Angle = ((EntityInfo) ((CustomData) Ent).Marble).Angle;
    ((MarbleCornerCleanToolType) EdgeItem).IndexEntity = EntityIndex;
    ((MarbleMillingToolType) EdgeItem).IndexInside = indexInside;
    if (Job != null)
    {
      ((marbleCountertopTapPars) this).GetEdgeID(Job, ref ((MarbleToolType) EdgeItem).EdgeID);
    }
    else
    {
      ((MarbleToolType) EdgeItem).EdgeID = MarbleCountertopSettings.EdgeIndex;
      ++MarbleCountertopSettings.EdgeIndex;
    }
    buDiametricDim.Copy(Ent, ref ((MarbleSliceType) EdgeItem).refEntity);
    ((AnalyseEntitiesSetting) ((CustomData) ((MarbleSliceType) EdgeItem).refEntity).Info).EntityIndex = EntityIndex;
    ((AnalyseEntitiesSetting) ((CustomData) ((MarbleSliceType) EdgeItem).refEntity).Info).InsideIndex = indexInside;
    ((EntityDataSet) ((CustomData) ((MarbleSliceType) EdgeItem).refEntity).Info).ItemID = ((MarbleProgramSettings) Item).ID;
    ((EntityDataSet) ((CustomData) ((MarbleSliceType) EdgeItem).refEntity).Info).CamID = ((MarbleMachineSettings) CamItem).CamID;
    ((EntityDataSet) ((CustomData) ((MarbleSliceType) EdgeItem).refEntity).Info).EdgeID = ((MarbleToolType) EdgeItem).EdgeID;
    this.CreateEdgeEntity(((MarbleSliceType) EdgeItem).refEntity, new Point3D(), Outside, ((MarbleProgramSettings) Item).ID, ((MarbleMachineSettings) CamItem).CamID, ((MarbleToolType) EdgeItem).EdgeID, EntityIndex, -1, indexInside, ref ((MarbleSliceType) EdgeItem).drawEntity);
    ((MarbleMillingToolType) EdgeItem).CamID = ((MarbleMachineSettings) CamItem).CamID;
    ((MarbleToolType) EdgeItem).ItemID = ((MarbleProgramSettings) Item).ID;
  }

  public void CreateEdgeEntities(
    List<buEntity> refEntities,
    Point3D refPoint,
    bool Outside,
    int indexInside,
    int indexCam,
    ref MarbleItem Item)
  {
    if (refEntities.Count > 0)
    {
      int num = 0;
      while (num <= refEntities.Count - 1)
        ++num;
    }
    if (refEntities.Count <= 0)
      return;
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities == null)
      ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities = new List<buEntity>();
    for (int index1 = 0; index1 <= refEntities.Count - 1; ++index1)
    {
      buEntity copiedEntity = (buEntity) null;
      buDiametricDim.Copy(refEntities[index1], ref copiedEntity);
      if (refPoint != (Point3D) null)
        ((buLinearDim) copiedEntity).Translate(refPoint.X, refPoint.Y, 0.0);
      switch (copiedEntity)
      {
        case buCompositeCurve _:
          for (int index2 = 0; index2 <= ((CustomDataSurrogate) copiedEntity).CurveList.Count - 1; ++index2)
          {
            ((CustomData) ((CustomDataSurrogate) copiedEntity).CurveList[index2]).Marble = (MarbleInfo) new Line2D();
            buEntity curve = ((CustomDataSurrogate) copiedEntity).CurveList[index2];
            List<Point3D> OffsetedPoints = new List<Point3D>();
            buCall.\u0001.OffsetOpenContour(((CustomDataSurrogate) curve).Vertices, 3.0, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints);
            buMesh buMesh = (buMesh) new buShapeFreeLines(new Region((ICurve) new LinearPath((ICollection<Point3D>) OffsetedPoints)).ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth));
            ((CustomData) buMesh).Marble = (MarbleInfo) new Line2D();
            ((AnalyseEntitiesSetting) ((CustomData) buMesh).Info).EntitySubIndex = indexInside;
            ((AnalyseEntitiesSetting) ((CustomData) buMesh).Info).EntityIndex = index1;
            ((AnalyseEntitiesResult) ((CustomData) buMesh).Info).CamIndex = indexCam;
            ((EntityDataSet) ((CustomData) buMesh).Info).Tags = "Edge";
            if (Outside)
              ((EntityDataSet) ((CustomData) buMesh).Info).Data = nameof (Outside);
            else
              ((EntityDataSet) ((CustomData) buMesh).Info).Data = "Inside";
            ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities.Add((buEntity) buMesh);
          }
          break;
        case buCircle _:
          buMesh buMesh1 = (buMesh) new buShapeFreeLines(new Region((IList<ICurve>) new List<ICurve>()
          {
            (ICurve) new Circle(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) copiedEntity).Center), ((CustomDataSurrogate) copiedEntity).Radius + 3.0),
            (ICurve) new Circle(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) copiedEntity).Center), ((CustomDataSurrogate) copiedEntity).Radius - 3.0)
          }).ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth));
          ((CustomData) buMesh1).Marble = (MarbleInfo) new Line2D();
          ((AnalyseEntitiesSetting) ((CustomData) buMesh1).Info).EntitySubIndex = indexInside;
          ((AnalyseEntitiesSetting) ((CustomData) buMesh1).Info).EntityIndex = index1;
          ((AnalyseEntitiesResult) ((CustomData) buMesh1).Info).CamIndex = indexCam;
          ((EntityDataSet) ((CustomData) buMesh1).Info).Tags = "Edge";
          if (Outside)
            ((EntityDataSet) ((CustomData) buMesh1).Info).Data = nameof (Outside);
          else
            ((EntityDataSet) ((CustomData) buMesh1).Info).Data = "Inside";
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities.Add((buEntity) buMesh1);
          break;
        case buEllipse _:
          buMesh buMesh2 = (buMesh) new buShapeFreeLines(new Region((IList<ICurve>) new List<ICurve>()
          {
            (ICurve) new Ellipse(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) copiedEntity).Center), ((CustomDataSurrogate) copiedEntity).RadiusX + 3.0, ((CustomDataSurrogate) copiedEntity).RadiusY + 3.0),
            (ICurve) new Ellipse(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) copiedEntity).Center), ((CustomDataSurrogate) copiedEntity).RadiusX - 3.0, ((CustomDataSurrogate) copiedEntity).RadiusY - 3.0)
          }).ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth));
          ((CustomData) buMesh2).Marble = (MarbleInfo) new Line2D();
          ((AnalyseEntitiesSetting) ((CustomData) buMesh2).Info).EntitySubIndex = indexInside;
          ((AnalyseEntitiesSetting) ((CustomData) buMesh2).Info).EntityIndex = index1;
          ((AnalyseEntitiesResult) ((CustomData) buMesh2).Info).CamIndex = indexCam;
          ((EntityDataSet) ((CustomData) buMesh2).Info).Tags = "Edge";
          if (Outside)
            ((EntityDataSet) ((CustomData) buMesh2).Info).Data = nameof (Outside);
          else
            ((EntityDataSet) ((CustomData) buMesh2).Info).Data = "Inside";
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities.Add((buEntity) buMesh2);
          break;
        default:
          ((CustomData) copiedEntity).Marble = (MarbleInfo) new Line2D();
          if (copiedEntity is buLinearPath)
          {
            for (int index3 = 1; index3 <= ((CustomDataSurrogate) copiedEntity).Vertices.Count - 1; ++index3)
            {
              List<Point3D> RefPoints = new List<Point3D>();
              RefPoints.Add(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) copiedEntity).Vertices[index3 - 1]));
              RefPoints.Add(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) copiedEntity).Vertices[index3]));
              List<Point3D> OffsetedPoints = new List<Point3D>();
              buCall.\u0001.OffsetOpenContour(RefPoints, 3.0, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints);
              buMesh buMesh3 = (buMesh) new buShapeFreeLines(new Region((ICurve) new LinearPath((ICollection<Point3D>) OffsetedPoints)).ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth));
              ((CustomData) buMesh3).Marble = (MarbleInfo) new Line2D();
              ((AnalyseEntitiesSetting) ((CustomData) buMesh3).Info).EntitySubIndex = indexInside;
              ((AnalyseEntitiesSetting) ((CustomData) buMesh3).Info).EntityIndex = index1;
              ((AnalyseEntitiesResult) ((CustomData) buMesh3).Info).CamIndex = indexCam;
              ((EntityDataSet) ((CustomData) buMesh3).Info).Tags = "Edge";
              if (Outside)
                ((EntityDataSet) ((CustomData) buMesh3).Info).Data = nameof (Outside);
              else
                ((EntityDataSet) ((CustomData) buMesh3).Info).Data = "Inside";
              ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities.Add((buEntity) buMesh3);
            }
            break;
          }
          buEntity buEntity = copiedEntity;
          List<Point3D> OffsetedPoints1 = new List<Point3D>();
          buCall.\u0001.OffsetOpenContour(((CustomDataSurrogate) buEntity).Vertices, 3.0, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints1);
          buMesh buMesh4 = (buMesh) new buShapeFreeLines(new Region((ICurve) new LinearPath((ICollection<Point3D>) OffsetedPoints1)).ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth));
          ((CustomData) buMesh4).Marble = (MarbleInfo) new Line2D();
          ((AnalyseEntitiesSetting) ((CustomData) buMesh4).Info).EntitySubIndex = indexInside;
          ((AnalyseEntitiesSetting) ((CustomData) buMesh4).Info).EntityIndex = index1;
          ((AnalyseEntitiesResult) ((CustomData) buMesh4).Info).CamIndex = indexCam;
          ((EntityDataSet) ((CustomData) buMesh4).Info).Tags = "Edge";
          if (Outside)
            ((EntityDataSet) ((CustomData) buMesh4).Info).Data = nameof (Outside);
          else
            ((EntityDataSet) ((CustomData) buMesh4).Info).Data = "Inside";
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities.Add((buEntity) buMesh4);
          break;
      }
    }
  }

  public void CreateEdgeEntity(
    buEntity refEntity,
    Point3D refPoint,
    bool Outside,
    int ItemID,
    int CamID,
    int EdgeID,
    int indexEntity,
    int indexEntitySub,
    int indexInside,
    ref buEntity entEdge)
  {
    buEntity copiedEntity = (buEntity) null;
    buDiametricDim.Copy(refEntity, ref copiedEntity);
    if (refPoint != (Point3D) null)
      ((buLinearDim) copiedEntity).Translate(refPoint.X, refPoint.Y, 0.0);
    switch (copiedEntity)
    {
      case buCompositeCurve _:
        for (int index = 0; index <= ((CustomDataSurrogate) copiedEntity).CurveList.Count - 1; ++index)
        {
          ((CustomData) ((CustomDataSurrogate) copiedEntity).CurveList[index]).Marble = (MarbleInfo) new Line2D();
          buEntity curve = ((CustomDataSurrogate) copiedEntity).CurveList[index];
          List<Point3D> OffsetedPoints = new List<Point3D>();
          buCall.\u0001.OffsetOpenContour(((CustomDataSurrogate) curve).Vertices, 3.0, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints);
          Mesh another = new Region((ICurve) new LinearPath((ICollection<Point3D>) OffsetedPoints)).ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
          entEdge = (buEntity) new buShapeFreeLines(another);
          ((CustomData) entEdge).Marble = (MarbleInfo) new Line2D();
          ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).InsideIndex = indexInside;
          ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).EntityIndex = indexEntity;
          ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).EntitySubIndex = indexEntitySub;
          ((EntityDataSet) ((CustomData) entEdge).Info).CamID = CamID;
          ((EntityDataSet) ((CustomData) entEdge).Info).EdgeID = EdgeID;
          ((EntityDataSet) ((CustomData) entEdge).Info).ItemID = ItemID;
          ((EntityDataSet) ((CustomData) entEdge).Info).Tags = "Edge";
          if (Outside)
            ((EntityDataSet) ((CustomData) entEdge).Info).Data = nameof (Outside);
          else
            ((EntityDataSet) ((CustomData) entEdge).Info).Data = "Inside";
        }
        break;
      case buCircle _:
        Mesh another1 = new Region((IList<ICurve>) new List<ICurve>()
        {
          (ICurve) new Circle(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) copiedEntity).Center), ((CustomDataSurrogate) copiedEntity).Radius + 3.0),
          (ICurve) new Circle(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) copiedEntity).Center), ((CustomDataSurrogate) copiedEntity).Radius - 3.0)
        }).ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
        entEdge = (buEntity) new buShapeFreeLines(another1);
        ((CustomData) entEdge).Marble = (MarbleInfo) new Line2D();
        ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).InsideIndex = indexInside;
        ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).EntityIndex = indexEntity;
        ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).EntitySubIndex = indexEntitySub;
        ((EntityDataSet) ((CustomData) entEdge).Info).CamID = CamID;
        ((EntityDataSet) ((CustomData) entEdge).Info).EdgeID = EdgeID;
        ((EntityDataSet) ((CustomData) entEdge).Info).ItemID = ItemID;
        ((EntityDataSet) ((CustomData) entEdge).Info).Tags = "Edge";
        if (Outside)
        {
          ((EntityDataSet) ((CustomData) entEdge).Info).Data = nameof (Outside);
          break;
        }
        ((EntityDataSet) ((CustomData) entEdge).Info).Data = "Inside";
        break;
      case buEllipse _:
        Mesh another2 = new Region((IList<ICurve>) new List<ICurve>()
        {
          (ICurve) new Ellipse(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) copiedEntity).Center), ((CustomDataSurrogate) copiedEntity).RadiusX + 3.0, ((CustomDataSurrogate) copiedEntity).RadiusY + 3.0),
          (ICurve) new Ellipse(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) copiedEntity).Center), ((CustomDataSurrogate) copiedEntity).RadiusX - 3.0, ((CustomDataSurrogate) copiedEntity).RadiusY - 3.0)
        }).ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
        entEdge = (buEntity) new buShapeFreeLines(another2);
        ((CustomData) entEdge).Marble = (MarbleInfo) new Line2D();
        ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).InsideIndex = indexInside;
        ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).EntityIndex = indexEntity;
        ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).EntitySubIndex = indexEntitySub;
        ((EntityDataSet) ((CustomData) entEdge).Info).CamID = CamID;
        ((EntityDataSet) ((CustomData) entEdge).Info).EdgeID = EdgeID;
        ((EntityDataSet) ((CustomData) entEdge).Info).ItemID = ItemID;
        ((EntityDataSet) ((CustomData) entEdge).Info).Tags = "Edge";
        if (Outside)
        {
          ((EntityDataSet) ((CustomData) entEdge).Info).Data = nameof (Outside);
          break;
        }
        ((EntityDataSet) ((CustomData) entEdge).Info).Data = "Inside";
        break;
      default:
        ((CustomData) copiedEntity).Marble = (MarbleInfo) new Line2D();
        if (copiedEntity is buLinearPath)
        {
          for (int index = 1; index <= ((CustomDataSurrogate) copiedEntity).Vertices.Count - 1; ++index)
          {
            List<Point3D> RefPoints = new List<Point3D>();
            RefPoints.Add(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) copiedEntity).Vertices[index - 1]));
            RefPoints.Add(F_NotchEdit.ToPoint3D(((CustomDataSurrogate) copiedEntity).Vertices[index]));
            List<Point3D> OffsetedPoints = new List<Point3D>();
            buCall.\u0001.OffsetOpenContour(RefPoints, 3.0, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints);
            Mesh another3 = new Region((ICurve) new LinearPath((ICollection<Point3D>) OffsetedPoints)).ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
            entEdge = (buEntity) new buShapeFreeLines(another3);
            ((CustomData) entEdge).Marble = (MarbleInfo) new Line2D();
            ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).InsideIndex = indexInside;
            ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).EntityIndex = indexEntity;
            ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).EntitySubIndex = indexEntitySub;
            ((EntityDataSet) ((CustomData) entEdge).Info).CamID = CamID;
            ((EntityDataSet) ((CustomData) entEdge).Info).EdgeID = EdgeID;
            ((EntityDataSet) ((CustomData) entEdge).Info).ItemID = ItemID;
            ((EntityDataSet) ((CustomData) entEdge).Info).Tags = "Edge";
            if (Outside)
              ((EntityDataSet) ((CustomData) entEdge).Info).Data = nameof (Outside);
            else
              ((EntityDataSet) ((CustomData) entEdge).Info).Data = "Inside";
          }
          break;
        }
        buEntity buEntity = copiedEntity;
        List<Point3D> OffsetedPoints1 = new List<Point3D>();
        buCall.\u0001.OffsetOpenContour(((CustomDataSurrogate) buEntity).Vertices, 3.0, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints1);
        Mesh another4 = new Region((ICurve) new LinearPath((ICollection<Point3D>) OffsetedPoints1)).ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
        entEdge = (buEntity) new buShapeFreeLines(another4);
        ((CustomData) entEdge).Marble = (MarbleInfo) new Line2D();
        ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).InsideIndex = indexInside;
        ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).EntityIndex = indexEntity;
        ((AnalyseEntitiesSetting) ((CustomData) entEdge).Info).EntitySubIndex = indexEntitySub;
        ((EntityDataSet) ((CustomData) entEdge).Info).CamID = CamID;
        ((EntityDataSet) ((CustomData) entEdge).Info).EdgeID = EdgeID;
        ((EntityDataSet) ((CustomData) entEdge).Info).ItemID = ItemID;
        ((EntityDataSet) ((CustomData) entEdge).Info).Tags = "Edge";
        if (Outside)
        {
          ((EntityDataSet) ((CustomData) entEdge).Info).Data = nameof (Outside);
          break;
        }
        ((EntityDataSet) ((CustomData) entEdge).Info).Data = "Inside";
        break;
    }
  }

  public void EdgePropertiesFromWireEntities(
    List<List<buEntity>> WireEntities,
    ref List<marbleEdgeItem> Edges)
  {
    for (int index1 = 0; index1 <= Edges.Count - 1; ++index1)
    {
      bool flag = false;
      if (WireEntities != null)
      {
        for (int index2 = 0; index2 <= WireEntities.Count - 1; ++index2)
        {
          for (int index3 = 0; index3 <= WireEntities[index2].Count - 1; ++index3)
          {
            if (((MarbleCornerCleanToolType) Edges[index1]).IndexEntity == ((AnalyseEntitiesSetting) ((CustomData) WireEntities[index2][index3]).Info).EntityIndex & ((MarbleMillingToolType) Edges[index1]).IndexEntitySub == ((AnalyseEntitiesSetting) ((CustomData) WireEntities[index2][index3]).Info).EntitySubIndex)
            {
              flag = true;
              Point3D pntStart = new Point3D();
              Point3D pntEnd = new Point3D();
              buCall.\u0001.GetEntityStartEndPointByCamDirection(WireEntities[index2][index3], ref pntStart, ref pntEnd);
              ((MarbleCornerCleanToolType) Edges[index1]).DirectionAngle = buCall.\u0001.PointAngle(pntEnd, pntStart);
              ((MarbleCornerCleanToolType) Edges[index1]).Length = buCall.\u0001.Length3D(pntEnd, pntStart);
              ((MarbleToolType) Edges[index1]).Sequence = index2 + 1;
              ((MarbleItemType) Edges[index1]).Enable = ((DirectionArrowSetting) ((CustomData) WireEntities[index2][index3]).Info).Enable;
              index3 = WireEntities[index2].Count;
            }
          }
          if (flag)
            index2 = WireEntities.Count;
        }
      }
    }
  }

  public void GetEdgeIndexFromEdgeID(List<marbleEdgeItem> EdgeList, int EdgeID, ref int EdgeIndex)
  {
    EdgeIndex = -1;
    for (int index = 0; index <= EdgeList.Count - 1; ++index)
    {
      if (((MarbleToolType) EdgeList[index]).EdgeID == EdgeID)
      {
        EdgeIndex = index;
        break;
      }
    }
  }
}
