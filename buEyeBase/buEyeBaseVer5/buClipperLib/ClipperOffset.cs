// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buClipperLib.ClipperOffset
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Flexo;
using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.buClipperLib;

public class ClipperOffset
{
  public Color OperationColor;
  public static List<ToolBase5> ToolList;
  public static byte f0038F3;
  public double Width;
  public double Height;
  public double Angle;
  public double Radius;
  public double Chamfer;
  public static byte f0038F9;
  public double Radius;
  public static byte f0038FB;
  public double RadiusX;
  public double RadiusY;
  public double Angle;
  public static byte f0038FF;
  public double Radius;

  public ClipperOffset()
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0001 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0003 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0004 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0002 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0003 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0004 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0005 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0002 = true;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0003 = false;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXDisplaySettings) this).\u0001 = entitySortDirection.Normal;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXDisplaySettings) this).\u0001 = entityTypeDefination.None;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXRuntimeSettings) this).\u0007 = 1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXRuntimeSettings) this).\u0001 = tuftingStitchModeType.None;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0012 = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0013 = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0007 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0008 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u000E = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u000F = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0010 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0011 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0012 = -1;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public ClipperOffset(entityTypeDefination type)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0001 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0003 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0004 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0002 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0003 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0004 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0005 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0002 = true;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0003 = false;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXDisplaySettings) this).\u0001 = entitySortDirection.Normal;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXDisplaySettings) this).\u0001 = entityTypeDefination.None;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXRuntimeSettings) this).\u0007 = 1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXRuntimeSettings) this).\u0001 = tuftingStitchModeType.None;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0012 = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0013 = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0007 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0008 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u000E = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u000F = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0010 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0011 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0012 = -1;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((CutterRuntimeSettings) this).set_typeDefination(type);
  }

  public ClipperOffset(
    string tags,
    string entityname,
    string scenename,
    string actionname,
    int camid,
    bool camselected,
    int groupindex,
    entitySortDirection sortdir,
    double infoangle,
    Point3D infobasepnt,
    int infodegree,
    double infoheadrad,
    double infoheight,
    double infolength,
    double inforadius,
    int infoside,
    string infostring,
    double infowidth,
    double orientationc,
    entitySplineType curvetype,
    double camfeedrate,
    int originalentityindex,
    bool camselectable,
    int sequence,
    entityTypeDefination typedefination,
    string infodata,
    double infodirection,
    int refindex,
    double infodepth,
    tuftingStitchModeType tuftingmode,
    double tuftingpileheight,
    double tuftingstitchlen,
    bool dontuseforcalculation,
    double orientationa,
    double orientationb,
    string id,
    string command,
    int entityindex,
    int entitysubindex,
    int itemid,
    int edgeid,
    int insideindex)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0001 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0003 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0004 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0002 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0003 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0004 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0005 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0002 = true;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0003 = false;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXDisplaySettings) this).\u0001 = entitySortDirection.Normal;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXDisplaySettings) this).\u0001 = entityTypeDefination.None;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXRuntimeSettings) this).\u0007 = 1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXRuntimeSettings) this).\u0001 = tuftingStitchModeType.None;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0012 = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0013 = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0007 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0008 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u000E = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u000F = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0010 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0011 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0012 = -1;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.set_Tags(tags);
    this.set_EntityName(entityname);
    this.set_SceneName(scenename);
    ((\u001D.\u0001) this).set_ActionName(actionname);
    ((buDiamakerCalc) this).set_CamID(camid);
    ((buCutter) this).set_CamSelected(camselected);
    ((buCutterCalc) this).set_CamSelectable(camselectable);
    ((buDiamakerCalc) this).set_GroupIdIndex(groupindex);
    ((CutterRuntimeSettings) this).set_sortDirection(((CutterIsoFileItems) this).get_sortDirection());
    ((CutterNotch) this).set_infoAngle(infoangle);
    if (((buRollerBendCalc) this).get_infoBasePoint() != (Point3D) null)
      ((RollerJob) this).set_infoBasePoint(new Point3D(((buRollerBendCalc) this).get_infoBasePoint().X, ((buRollerBendCalc) this).get_infoBasePoint().Y, ((buRollerBendCalc) this).get_infoBasePoint().Z));
    ((buRollerBendCalc) this).set_infoDegree(infodegree);
    ((ToolGrindingRuntimeSettings) this).set_infoHeadRadius(infoheadrad);
    ((buToolGrindingCalc) this).set_infoHeight(infoheight);
    ((CutterProgramSettings) this).set_infoLength(infolength);
    ((ToolGrindingJob) this).set_infoRadius(inforadius);
    ((ToolGrindingSettings) this).set_infoSide(infoside);
    ((CutterProgramSettings) this).set_infoString(infostring);
    ((ToolGrindingJob) this).set_infoWidth(infowidth);
    ((ToolGrindingJob) this).set_infoDepth(infodepth);
    ((CutterProgramSettings) this).set_infoData(infodata);
    ((CutterNotch) this).set_infoDirection(infodirection);
    ((DiemakerGrindingShapeSettings) this).set_RefIndex(refindex);
    ((CutterIsoError) this).set_OrientationA(orientationa);
    ((CutterIsoFileSettings) this).set_OrientationB(orientationb);
    ((CutterIsoFileItems) this).set_OrientationC(orientationc);
    ((RollerJob) this).set_CurveType(curvetype);
    ((CutterIsoEntities) this).set_CamFeedrate(camfeedrate);
    ((buDiamakerCalc) this).set_OriginalEntityIndex(originalentityindex);
    ((RollerJob) this).set_Sequence(sequence);
    ((CutterRuntimeSettings) this).set_typeDefination(typedefination);
    ((RollerBendMove) this).set_tuftingMode(tuftingmode);
    ((RollerBendMove) this).set_tuftingPileHeight(tuftingpileheight);
    ((RollerBendMove) this).set_tuftingStitchLength(tuftingstitchlen);
    ((buCutterCalc) this).set_DontUseForCalculation(dontuseforcalculation);
    ((RollerBendRuntimeSettings) this).set_ID(id);
    ((RollerBendSettings) this).set_Command(command);
    ((buRouter3AX) this).set_EntityIndex(entityindex);
    ((buRouter3AX) this).set_EntitySubIndex(entitysubindex);
    ((buFlexoCalc) this).set_ItemID(itemid);
    ((buRouter3AX) this).set_EdgeID(edgeid);
    ((buRouter3AX) this).set_InsideIndex(insideindex);
  }

  public ClipperOffset(CustomData Data)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0001 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0003 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0004 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0002 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0003 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0004 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0005 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0002 = true;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXSettings) this).\u0003 = false;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXDisplaySettings) this).\u0001 = entitySortDirection.Normal;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXDisplaySettings) this).\u0001 = entityTypeDefination.None;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXRuntimeSettings) this).\u0007 = 1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXRuntimeSettings) this).\u0001 = tuftingStitchModeType.None;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0012 = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0013 = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0007 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0008 = "";
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u000E = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u000F = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0010 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0011 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXTempVars) this).\u0012 = -1;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    if (Data == null)
      Data = (CustomData) new ClipperOffset();
    this.set_Tags(((ClipperOffset) Data).get_Tags());
    this.set_EntityName(((ClipperOffset) Data).get_EntityName());
    this.set_SceneName(((ClipperOffset) Data).get_SceneName());
    ((\u001D.\u0001) this).set_ActionName(((ClipperOffset) Data).get_ActionName());
    ((buDiamakerCalc) this).set_CamID(((buDiamakerCalc) Data).get_CamID());
    ((buCutter) this).set_CamSelected(((buCutter) Data).get_CamSelected());
    ((buCutterCalc) this).set_CamSelectable(((buCutterCalc) Data).get_CamSelectable());
    ((buDiamakerCalc) this).set_GroupIdIndex(((buDiamakerCalc) Data).get_GroupIdIndex());
    ((CutterRuntimeSettings) this).set_sortDirection(((CutterIsoFileItems) Data).get_sortDirection());
    ((CutterNotch) this).set_infoAngle(((CutterNotch) Data).get_infoAngle());
    if (((buRollerBendCalc) Data).get_infoBasePoint() != (Point3D) null)
      ((RollerJob) this).set_infoBasePoint(new Point3D(((buRollerBendCalc) Data).get_infoBasePoint().X, ((buRollerBendCalc) Data).get_infoBasePoint().Y, ((buRollerBendCalc) Data).get_infoBasePoint().Z));
    ((CutterIsoError) this).set_OrientationA(((CutterIsoEntities) Data).get_OrientationA());
    ((CutterIsoFileSettings) this).set_OrientationB(((CutterIsoError) Data).get_OrientationB());
    ((CutterIsoFileItems) this).set_OrientationC(((CutterIsoFileSettings) Data).get_OrientationC());
    ((buRollerBendCalc) this).set_infoDegree(((buRollerBendCalc) Data).get_infoDegree());
    ((ToolGrindingRuntimeSettings) this).set_infoHeadRadius(((ToolGrindingRuntimeSettings) Data).get_infoHeadRadius());
    ((buToolGrindingCalc) this).set_infoHeight(((buToolGrindingCalc) Data).get_infoHeight());
    ((CutterProgramSettings) this).set_infoLength(((CutterProgramSettings) Data).get_infoLength());
    ((ToolGrindingJob) this).set_infoRadius(((ToolGrindingJob) Data).get_infoRadius());
    ((ToolGrindingSettings) this).set_infoSide(((ToolGrindingSettings) Data).get_infoSide());
    ((CutterProgramSettings) this).set_infoString(((CutterRuntimeSettings) Data).get_infoString());
    ((CutterProgramSettings) this).set_infoData(((CutterProgramSettings) Data).get_infoData());
    ((ToolGrindingJob) this).set_infoWidth(((ToolGrindingJob) Data).get_infoWidth());
    ((CutterNotch) this).set_infoDirection(((CutterNotch) Data).get_infoDirection());
    ((ToolGrindingJob) this).set_infoWidth(((ToolGrindingJob) Data).get_infoWidth());
    ((DiemakerGrindingShapeSettings) this).set_RefIndex(((DiemakerGrindingShapeSettings) Data).get_RefIndex());
    ((RollerJob) this).set_CurveType(((RollerJob) Data).get_CurveType());
    ((CutterIsoEntities) this).set_CamFeedrate(((buCutterCalc) Data).get_CamFeedrate());
    ((CutterRuntimeSettings) this).set_typeDefination(((CutterRuntimeSettings) Data).get_typeDefination());
    ((buDiamakerCalc) this).set_OriginalEntityIndex(((buDiamakerCalc) Data).get_OriginalEntityIndex());
    ((RollerJob) this).set_Sequence(((RollerJob) Data).get_Sequence());
    ((RollerBendMove) this).set_tuftingStitchLength(((RollerBendMove) Data).get_tuftingStitchLength());
    ((RollerBendMove) this).set_tuftingPileHeight(((RollerBendMove) Data).get_tuftingPileHeight());
    ((RollerBendMove) this).set_tuftingMode(((RollerJob) Data).get_tuftingMode());
    ((buCutterCalc) this).set_DontUseForCalculation(((buCutterCalc) Data).get_DontUseForCalculation());
    ((RollerBendRuntimeSettings) this).set_ID(((RollerBendRuntimeSettings) Data).get_ID());
    ((RollerBendSettings) this).set_Command(((RollerBendSettings) Data).get_Command());
    ((buRouter3AX) this).set_EntityIndex(((buRouter3AX) Data).get_EntityIndex());
    ((buRouter3AX) this).set_EntitySubIndex(((buRouter3AX) Data).get_EntitySubIndex());
    ((buFlexoCalc) this).set_ItemID(((buFlexoCalc) Data).get_ItemID());
    ((buRouter3AX) this).set_EdgeID(((buRouter3AX) Data).get_EdgeID());
    ((buRouter3AX) this).set_InsideIndex(((buRouter3AX) Data).get_InsideIndex());
  }

  [CompilerGenerated]
  [SpecialName]
  public string get_Tags() => ((Router3AXCamPlane) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_Tags(string value) => ((Router3AXCamPlane) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public string get_SceneName() => ((Router3AXCamPlane) this).\u0002;

  [CompilerGenerated]
  [SpecialName]
  public void set_SceneName(string value) => ((Router3AXCamPlane) this).\u0002 = value;

  [CompilerGenerated]
  [SpecialName]
  public string get_EntityName() => ((Router3AXSettings) this).\u0003;

  [CompilerGenerated]
  [SpecialName]
  public void set_EntityName(string value) => ((Router3AXSettings) this).\u0003 = value;

  [CompilerGenerated]
  [SpecialName]
  public string get_ActionName() => ((Router3AXSettings) this).\u0004;

  public double ArcTolerance
  {
    [CompilerGenerated, SpecialName] get => ((PipeBendTempVars) this).\u0007;
    [CompilerGenerated, SpecialName] set => ((PipeBendTempVars) this).\u0007 = value;
  }

  public double MiterLimit
  {
    [CompilerGenerated, SpecialName] get => ((PipeBendTempVars) this).\u0008;
    [CompilerGenerated, SpecialName] set => ((PipeBendTempVars) this).\u0008 = value;
  }
}
