// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Router3AXItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Flexo;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXItem : buSerilization5
{
  public bool XMove;
  public bool YMove;
  public bool ZMove;
  public bool ARotation;
  public bool BRotation;
  public bool CRotation;
  public string Tag;
  private Transformation \u0001;

  protected virtual void CopyDataFromObject(CustomData cd)
  {
    ((Router3AXTempVars) this).Tags = ((ClipperOffset) cd).get_Tags();
    ((Router3AXTempVars) this).SceneName = ((ClipperOffset) cd).get_SceneName();
    ((DrawOptions) this).EntityName = ((ClipperOffset) cd).get_EntityName();
    ((DrawOptions) this).ActionName = ((ClipperOffset) cd).get_ActionName();
    ((DrawOptions) this).CamID = ((buDiamakerCalc) cd).get_CamID();
    ((CamCreateSettings) this).CamSelected = ((buCutter) cd).get_CamSelected();
    ((CamCreateSettings) this).CamSelectable = ((buCutterCalc) cd).get_CamSelectable();
    ((DrawOptions) this).GroupIdIndex = ((buDiamakerCalc) cd).get_GroupIdIndex();
    ((MachineTableType) this).sortDirection = ((CutterIsoFileItems) cd).get_sortDirection();
    ((buDoor) this).infoAngle = ((CutterNotch) cd).get_infoAngle();
    ((DoorJob) this).infoDegree = ((buRollerBendCalc) cd).get_infoDegree();
    ((DoorJob) this).infoHeadRadius = ((ToolGrindingRuntimeSettings) cd).get_infoHeadRadius();
    ((buDoor) this).infoHeight = ((buToolGrindingCalc) cd).get_infoHeight();
    ((buDoor) this).infoLength = ((CutterProgramSettings) cd).get_infoLength();
    ((buDoor) this).infoRadius = ((ToolGrindingJob) cd).get_infoRadius();
    ((DoorJob) this).infoSide = ((ToolGrindingSettings) cd).get_infoSide();
    ((buDoor) this).infoString = ((CutterRuntimeSettings) cd).get_infoString();
    ((buDoor) this).infoData = ((CutterProgramSettings) cd).get_infoData();
    ((buDoor) this).infoWidth = ((ToolGrindingJob) cd).get_infoWidth();
    ((DoorJob) this).infoDepth = ((ToolGrindingJob) cd).get_infoDepth();
    ((DoorJob) this).infoDirection = ((CutterNotch) cd).get_infoDirection();
    ((CamCreateSettings) this).RefIndex = ((DiemakerGrindingShapeSettings) cd).get_RefIndex();
    ((MachineTableType) this).OrientationA = ((CutterIsoEntities) cd).get_OrientationA();
    ((MachineTableType) this).OrientationB = ((CutterIsoError) cd).get_OrientationB();
    ((MachineTableType) this).OrientationC = ((CutterIsoFileSettings) cd).get_OrientationC();
    ((DoorJob) this).CurveType = ((RollerJob) cd).get_CurveType();
    ((DoorJob) this).camFeedrate = ((buCutterCalc) cd).get_CamFeedrate();
    ((DrawOptions) this).OriginalEntityIndex = ((buDiamakerCalc) cd).get_OriginalEntityIndex();
    ((DoorJob) this).Sequence = ((RollerJob) cd).get_Sequence();
    ((MachineTableType) this).typeDefination = ((CutterRuntimeSettings) cd).get_typeDefination();
    ((DoorJob) this).tuftingMode = ((RollerJob) cd).get_tuftingMode();
    ((DoorJob) this).tuftingPileHeight = ((RollerBendMove) cd).get_tuftingPileHeight();
    ((DoorJob) this).tuftingStitchLength = ((RollerBendMove) cd).get_tuftingStitchLength();
    ((DoorSettings) this).DontUseForCalculation = ((buCutterCalc) cd).get_DontUseForCalculation();
    ((DoorSettings) this).ID = ((RollerBendRuntimeSettings) cd).get_ID();
    ((DoorSettings) this).Command = ((RollerBendSettings) cd).get_Command();
    ((DoorSettings) this).EntityIndex = ((buRouter3AX) cd).get_EntityIndex();
    ((DoorSettings) this).EntitySubIndex = ((buRouter3AX) cd).get_EntitySubIndex();
    ((DoorSettings) this).ItemID = ((buFlexoCalc) cd).get_ItemID();
    ((DoorSettings) this).EdgeID = ((buRouter3AX) cd).get_EdgeID();
    ((DoorRuntimeSettings) this).InsideIndex = ((buRouter3AX) cd).get_InsideIndex();
    if (!(((buRollerBendCalc) cd).get_infoBasePoint() != (Point3D) null))
      return;
    ((DoorJob) this).infoBasePoint = (Point3D) ((buRollerBendCalc) cd).get_infoBasePoint().Clone();
  }

  public static implicit operator CustomData(CustomDataSurrogate surrogate)
  {
    return surrogate == null ? (CustomData) null : surrogate.ConvertToObject();
  }

  public static implicit operator CustomDataSurrogate(CustomData source)
  {
    return source == null ? (CustomDataSurrogate) null : ((buRouter3AX) source).ConvertToSurrogate();
  }

  public abstract void m001A03();

  public Router3AXItem()
    : this()
  {
  }
}
