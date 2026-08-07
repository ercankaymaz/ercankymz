// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buMesh
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buControls.Controls;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buMesh : buEntity
{
  internal buLabel \u0002;
  public buButton btnl_sidetiltstrategy;
  public buCheckBox chk_undercut;

  public static CustomData EntityToCustomData(buEntity refEntity)
  {
    CustomData CD = (CustomData) null;
    buMesh.EntityToCustomData(refEntity, ref CD);
    return CD;
  }

  public static void EntityToCustomData(buEntity refEntity, ref CustomData CD)
  {
    CD = (CustomData) new ClipperOffset();
    ((buDiamakerCalc) CD).set_OriginalEntityIndex(((AnalyseEntitiesSetting) ((CustomData) refEntity).Info).OriginalEntityIndex);
    ((DiemakerGrindingShapeSettings) CD).set_RefIndex(((AnalyseEntitiesSetting) ((CustomData) refEntity).Info).RefIndex);
    ((RollerJob) CD).set_Sequence(((AnalyseEntitiesSetting) ((CustomData) refEntity).Info).Sequence);
    ((buCutterCalc) CD).set_DontUseForCalculation(((DirectionArrowSetting) ((CustomData) refEntity).Info).DontUseForCalculation);
    ((buCutter) CD).set_CamSelected(((AnalyseEntitiesResult) ((CustomData) refEntity).Info).CamSelected);
    ((buCutterCalc) CD).set_CamSelectable(((AnalyseEntitiesResultError) ((CustomData) refEntity).Info).CamSelectable);
    ((buDiamakerCalc) CD).set_CamID(((EntityDataSet) ((CustomData) refEntity).Info).CamID);
    ((ClipperOffset) CD).set_Tags(((EntityDataSet) ((CustomData) refEntity).Info).Tags);
    ((CutterIsoError) CD).set_OrientationA(((CustomDataSurrogate) refEntity).Orientation.A);
    ((CutterIsoFileSettings) CD).set_OrientationB(((CustomDataSurrogate) refEntity).Orientation.B);
    ((CutterIsoFileItems) CD).set_OrientationC(((CustomDataSurrogate) refEntity).Orientation.C);
    ((CutterRuntimeSettings) CD).set_sortDirection(((CustomData) refEntity).sortDirection);
    ((CutterRuntimeSettings) CD).set_typeDefination(((CustomDataSurrogate) refEntity).typeDefination);
    ((CutterRuntimeSettings) CD).set_sortDirection(((CustomData) refEntity).sortDirection);
    if (((CustomData) refEntity).Shape == null)
      return;
    ((CutterNotch) CD).set_infoAngle(((SewingPunteriz) ((CustomData) refEntity).Shape).Angle);
    if (((MarbleInfo) ((CustomData) refEntity).Shape).BasePoint != (Point3D) null)
      ((RollerJob) CD).set_infoBasePoint(new Point3D(((MarbleInfo) ((CustomData) refEntity).Shape).BasePoint.X, ((MarbleInfo) ((CustomData) refEntity).Shape).BasePoint.Y, ((MarbleInfo) ((CustomData) refEntity).Shape).BasePoint.Z));
    ((CutterProgramSettings) CD).set_infoData(((SewingPunteriz) ((CustomData) refEntity).Shape).Data);
    ((buRollerBendCalc) CD).set_infoDegree(((MarbleInfo) ((CustomData) refEntity).Shape).Degree);
    ((ToolGrindingJob) CD).set_infoDepth(((MarbleInfo) ((CustomData) refEntity).Shape).Depth);
    ((CutterNotch) CD).set_infoDirection(((SewingPunteriz) ((CustomData) refEntity).Shape).Direction);
    ((ToolGrindingRuntimeSettings) CD).set_infoHeadRadius(((MarbleInfo) ((CustomData) refEntity).Shape).HeadRadius);
    ((buToolGrindingCalc) CD).set_infoHeight(((SewingPunteriz) ((CustomData) refEntity).Shape).Height);
    ((CutterProgramSettings) CD).set_infoLength(((SewingPunteriz) ((CustomData) refEntity).Shape).Length);
    ((ToolGrindingJob) CD).set_infoRadius(((SewingPunteriz) ((CustomData) refEntity).Shape).Radius);
    ((ToolGrindingSettings) CD).set_infoSide(((MarbleInfo) ((CustomData) refEntity).Shape).Side);
    ((CutterProgramSettings) CD).set_infoString(((SewingPunteriz) ((CustomData) refEntity).Shape).String);
    ((ToolGrindingJob) CD).set_infoWidth(((MarbleInfo) ((CustomData) refEntity).Shape).Width);
    ((RollerJob) CD).set_CurveType(((MarbleInfo) ((CustomData) refEntity).Shape).CurveType);
  }

  public static void CustomDataToEntity(CustomData CD, ref buEntity refEntity)
  {
    ((CustomData) refEntity).Shape = (EntityShapeInfo) new SewingCode();
    ((CustomData) refEntity).Info = (EntityInfo) new CharLibrary5();
    ((AnalyseEntitiesSetting) ((CustomData) refEntity).Info).OriginalEntityIndex = ((buDiamakerCalc) CD).get_OriginalEntityIndex();
    ((AnalyseEntitiesSetting) ((CustomData) refEntity).Info).RefIndex = ((DiemakerGrindingShapeSettings) CD).get_RefIndex();
    ((AnalyseEntitiesSetting) ((CustomData) refEntity).Info).Sequence = ((RollerJob) CD).get_Sequence();
    ((DirectionArrowSetting) ((CustomData) refEntity).Info).DontUseForCalculation = ((buCutterCalc) CD).get_DontUseForCalculation();
    ((AnalyseEntitiesResult) ((CustomData) refEntity).Info).CamSelected = ((buCutter) CD).get_CamSelected();
    ((AnalyseEntitiesResultError) ((CustomData) refEntity).Info).CamSelectable = ((buCutterCalc) CD).get_CamSelectable();
    ((EntityDataSet) ((CustomData) refEntity).Info).CamID = ((buDiamakerCalc) CD).get_CamID();
    ((EntityDataSet) ((CustomData) refEntity).Info).Tags = ((ClipperOffset) CD).get_Tags();
    ((CustomDataSurrogate) refEntity).Orientation.A = ((CutterIsoEntities) CD).get_OrientationA();
    ((CustomDataSurrogate) refEntity).Orientation.B = ((CutterIsoError) CD).get_OrientationB();
    ((CustomDataSurrogate) refEntity).Orientation.C = ((CutterIsoFileSettings) CD).get_OrientationC();
    ((CustomData) refEntity).sortDirection = ((CutterIsoFileItems) CD).get_sortDirection();
    ((SewingPunteriz) ((CustomData) refEntity).Shape).Angle = ((CutterNotch) CD).get_infoAngle();
    if (((buRollerBendCalc) CD).get_infoBasePoint() != (Point3D) null)
      ((MarbleInfo) ((CustomData) refEntity).Shape).BasePoint = new Point3D(((buRollerBendCalc) CD).get_infoBasePoint().X, ((buRollerBendCalc) CD).get_infoBasePoint().Y, ((buRollerBendCalc) CD).get_infoBasePoint().Z);
    ((SewingPunteriz) ((CustomData) refEntity).Shape).Data = ((CutterProgramSettings) CD).get_infoData();
    ((MarbleInfo) ((CustomData) refEntity).Shape).Degree = ((buRollerBendCalc) CD).get_infoDegree();
    ((MarbleInfo) ((CustomData) refEntity).Shape).Depth = ((ToolGrindingJob) CD).get_infoDepth();
    ((SewingPunteriz) ((CustomData) refEntity).Shape).Direction = ((CutterNotch) CD).get_infoDirection();
    ((MarbleInfo) ((CustomData) refEntity).Shape).HeadRadius = ((ToolGrindingRuntimeSettings) CD).get_infoHeadRadius();
    ((SewingPunteriz) ((CustomData) refEntity).Shape).Height = ((buToolGrindingCalc) CD).get_infoHeight();
    ((SewingPunteriz) ((CustomData) refEntity).Shape).Length = ((CutterProgramSettings) CD).get_infoLength();
    ((SewingPunteriz) ((CustomData) refEntity).Shape).Radius = ((ToolGrindingJob) CD).get_infoRadius();
    ((MarbleInfo) ((CustomData) refEntity).Shape).Side = ((ToolGrindingSettings) CD).get_infoSide();
    ((SewingPunteriz) ((CustomData) refEntity).Shape).String = ((CutterRuntimeSettings) CD).get_infoString();
    ((MarbleInfo) ((CustomData) refEntity).Shape).Width = ((ToolGrindingJob) CD).get_infoWidth();
    ((MarbleInfo) ((CustomData) refEntity).Shape).CurveType = ((RollerJob) CD).get_CurveType();
  }

  public static void ZPointToZero(ref List<buEntity> refEntities)
  {
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      buEntity refEntity = refEntities[index];
      buMesh.ZPointToZero(ref refEntity);
    }
  }

  public static void ZPointToZero(ref buEntity refEntity)
  {
    if (refEntity == null)
      return;
    ((CustomData) refEntity).StartPoint.Z = 0.0;
    ((CustomData) refEntity).MiddlePoint.Z = 0.0;
    ((CustomData) refEntity).EndPoint.Z = 0.0;
    if (!(refEntity.GetType() == typeof (buPoint)) && !(refEntity.GetType() == typeof (buLine)) && !(refEntity.GetType() == typeof (buUpperLine)))
    {
      if (refEntity.GetType() == typeof (buArc))
        ((CustomDataSurrogate) refEntity).Center.Z = 0.0;
      else if (refEntity.GetType() == typeof (buCircle))
        ((CustomDataSurrogate) refEntity).Center.Z = 0.0;
      else if (refEntity.GetType() == typeof (buEllipse))
        ((CustomDataSurrogate) refEntity).Center.Z = 0.0;
      else if (!(refEntity.GetType() == typeof (buLinearPath)))
      {
        if (refEntity.GetType() == typeof (buCurve))
        {
          if (((CustomDataSurrogate) refEntity).isRational)
          {
            for (int index = 0; index <= ((CustomDataSurrogate) refEntity).ControlPoints.Count - 1; ++index)
              ((CustomDataSurrogate) refEntity).ControlPoints[index].Z = 0.0;
          }
          else
          {
            for (int index = 0; index <= ((CustomDataSurrogate) refEntity).ControlPoints.Count - 1; ++index)
              ((CustomDataSurrogate) refEntity).ControlPoints[index].Z = 0.0;
          }
        }
        else if (refEntity.GetType() == typeof (buCompositeCurve))
        {
          for (int index = 0; index <= ((CustomDataSurrogate) refEntity).CurveList.Count - 1; ++index)
          {
            buEntity curve = ((CustomDataSurrogate) refEntity).CurveList[index];
            buMesh.ZPointToZero(ref curve);
          }
        }
        else if (refEntity.GetType() == typeof (buRegion))
        {
          for (int index = 0; index <= ((CustomDataSurrogate) refEntity).CurveList.Count - 1; ++index)
          {
            buEntity curve = ((CustomDataSurrogate) refEntity).CurveList[index];
            buMesh.ZPointToZero(ref curve);
          }
        }
        else if (refEntity.GetType() == typeof (buLinearDim))
        {
          ((PolyNode) refEntity).ExtLine1.Z = 0.0;
          ((PolyNode) refEntity).ExtLine2.Z = 0.0;
          ((PolyNode) refEntity).InsertionPoint.Z = 0.0;
          ((PolyNode) refEntity).DimLinePosition.Z = 0.0;
        }
        else if (refEntity.GetType() == typeof (buAngularDim))
        {
          ((\u000E.\u0001) refEntity).ExtLine1.Z = 0.0;
          ((IntPoint) refEntity).ExtLine2.Z = 0.0;
          ((IntPoint) refEntity).InsertionPoint.Z = 0.0;
          ((IntPoint) refEntity).DimLinePosition.Z = 0.0;
          ((IntRect) refEntity).QuadrantPoint.Z = 0.0;
          ((IntRect) refEntity).Origin.Z = 0.0;
        }
        else if (refEntity.GetType() == typeof (buDiametricDim))
        {
          ((ClipType) refEntity).InsertionPoint.Z = 0.0;
          ((ClipType) refEntity).DimLinePosition.Z = 0.0;
          ((ClipType) refEntity).Origin.Z = 0.0;
        }
        else if (refEntity.GetType() == typeof (buRadialDim))
        {
          ((EndType) refEntity).InsertionPoint.Z = 0.0;
          ((EndType) refEntity).DimLinePosition.Z = 0.0;
          ((EndType) refEntity).Origin.Z = 0.0;
        }
        else if (refEntity.GetType() == typeof (buOrdinateDim))
        {
          ((PolyFillType) refEntity).InsertionPoint.Z = 0.0;
          ((PolyFillType) refEntity).DimLinePosition.Z = 0.0;
          ((PolyFillType) refEntity).DefiningPoint.Z = 0.0;
        }
        else if (refEntity.GetType() == typeof (buText))
          ((\u0084.\u0001) refEntity).InsertionPoint.Z = 0.0;
      }
    }
    for (int index = 0; index <= ((CustomDataSurrogate) refEntity).Vertices.Count - 1; ++index)
      ((CustomDataSurrogate) refEntity).Vertices[index].Z = 0.0;
    ((CustomData) refEntity).BoxMax.Z = 0.0;
    ((CustomData) refEntity).BoxMin.Z = 0.0;
  }
}
