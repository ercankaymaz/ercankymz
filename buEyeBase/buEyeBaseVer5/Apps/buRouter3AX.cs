// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buRouter3AX
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Flexo;
using devDept.Geometry;
using devDept.Serialization;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buRouter3AX
{
  public double cPos;
  public double xRot;
  public double yRot;
  public double zRot;

  [CompilerGenerated]
  [SpecialName]
  public int get_EntityIndex() => ((Router3AXTempVars) this).\u000E;

  [CompilerGenerated]
  [SpecialName]
  public void set_EntityIndex(int value) => ((Router3AXTempVars) this).\u000E = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_EntitySubIndex() => ((Router3AXTempVars) this).\u000F;

  [CompilerGenerated]
  [SpecialName]
  public void set_EntitySubIndex(int value) => ((Router3AXTempVars) this).\u000F = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_CamIndex() => ((Router3AXTempVars) this).\u0010;

  [CompilerGenerated]
  [SpecialName]
  public void set_CamIndex(int value) => ((Router3AXTempVars) this).\u0010 = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_EdgeID() => ((Router3AXTempVars) this).\u0011;

  [CompilerGenerated]
  [SpecialName]
  public void set_EdgeID(int value) => ((Router3AXTempVars) this).\u0011 = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_InsideIndex() => ((Router3AXTempVars) this).\u0012;

  [CompilerGenerated]
  [SpecialName]
  public void set_InsideIndex(int value) => ((Router3AXTempVars) this).\u0012 = value;

  public virtual string Dump()
  {
    StringBuilder stringBuilder1 = new StringBuilder();
    stringBuilder1.AppendLine("Tags = " + ((ClipperOffset) this).get_Tags());
    stringBuilder1.AppendLine("SceneName = " + ((ClipperOffset) this).get_SceneName());
    stringBuilder1.AppendLine("EntityName = " + ((ClipperOffset) this).get_EntityName());
    stringBuilder1.AppendLine("ActionName = " + ((ClipperOffset) this).get_ActionName());
    stringBuilder1.AppendLine("CamID = " + ((buDiamakerCalc) this).get_CamID().ToString());
    stringBuilder1.AppendLine("GroupIdIndex = " + ((buDiamakerCalc) this).get_GroupIdIndex().ToString());
    stringBuilder1.AppendLine("CamSelected = " + ((buCutter) this).get_CamSelected().ToString());
    stringBuilder1.AppendLine("sortDirection = " + ((CutterIsoFileItems) this).get_sortDirection().ToString());
    stringBuilder1.AppendLine("infoString = " + ((CutterRuntimeSettings) this).get_infoString());
    stringBuilder1.AppendLine("infoLength = " + ((CutterProgramSettings) this).get_infoLength().ToString());
    stringBuilder1.AppendLine("infoAngle = " + ((CutterNotch) this).get_infoAngle().ToString());
    stringBuilder1.AppendLine("infoHeight = " + ((buToolGrindingCalc) this).get_infoHeight().ToString());
    stringBuilder1.AppendLine("infoRadius = " + ((ToolGrindingJob) this).get_infoRadius().ToString());
    stringBuilder1.AppendLine("infoWidth = " + ((ToolGrindingJob) this).get_infoWidth().ToString());
    stringBuilder1.AppendLine("infoHeadRadius = " + ((ToolGrindingRuntimeSettings) this).get_infoHeadRadius().ToString());
    stringBuilder1.AppendLine("infoSide = " + ((ToolGrindingSettings) this).get_infoSide().ToString());
    stringBuilder1.AppendLine("infoDegree = " + ((buRollerBendCalc) this).get_infoDegree().ToString());
    stringBuilder1.AppendLine("infoBasePoint = " + ((buRollerBendCalc) this).get_infoBasePoint()?.ToString());
    StringBuilder stringBuilder2 = stringBuilder1;
    double num1 = ((CutterIsoFileSettings) this).get_OrientationC();
    string str1 = "OrientationC = " + num1.ToString();
    stringBuilder2.AppendLine(str1);
    stringBuilder1.AppendLine("CurveType = " + ((RollerJob) this).get_CurveType().ToString());
    StringBuilder stringBuilder3 = stringBuilder1;
    num1 = ((buCutterCalc) this).get_CamFeedrate();
    string str2 = "CamFeedrate = " + num1.ToString();
    stringBuilder3.AppendLine(str2);
    StringBuilder stringBuilder4 = stringBuilder1;
    int num2 = ((buDiamakerCalc) this).get_OriginalEntityIndex();
    string str3 = "OriginalEntityIndex = " + num2.ToString();
    stringBuilder4.AppendLine(str3);
    StringBuilder stringBuilder5 = stringBuilder1;
    bool flag = ((buCutterCalc) this).get_CamSelectable();
    string str4 = "CamSelectable = " + flag.ToString();
    stringBuilder5.AppendLine(str4);
    StringBuilder stringBuilder6 = stringBuilder1;
    num2 = ((RollerJob) this).get_Sequence();
    string str5 = "Sequence = " + num2.ToString();
    stringBuilder6.AppendLine(str5);
    stringBuilder1.AppendLine("typeDefination = " + ((CutterRuntimeSettings) this).get_typeDefination().ToString());
    stringBuilder1.AppendLine("infoData = " + ((CutterProgramSettings) this).get_infoData());
    StringBuilder stringBuilder7 = stringBuilder1;
    num1 = ((CutterNotch) this).get_infoDirection();
    string str6 = "infoDirection = " + num1.ToString();
    stringBuilder7.AppendLine(str6);
    StringBuilder stringBuilder8 = stringBuilder1;
    num2 = ((DiemakerGrindingShapeSettings) this).get_RefIndex();
    string str7 = "RefIndex = " + num2.ToString();
    stringBuilder8.AppendLine(str7);
    StringBuilder stringBuilder9 = stringBuilder1;
    num1 = ((ToolGrindingJob) this).get_infoDepth();
    string str8 = "infoDepth = " + num1.ToString();
    stringBuilder9.AppendLine(str8);
    stringBuilder1.AppendLine("tuftingMode = " + ((RollerJob) this).get_tuftingMode().ToString());
    StringBuilder stringBuilder10 = stringBuilder1;
    num1 = ((RollerBendMove) this).get_tuftingPileHeight();
    string str9 = "tuftingPileHeight = " + num1.ToString();
    stringBuilder10.AppendLine(str9);
    StringBuilder stringBuilder11 = stringBuilder1;
    num1 = ((RollerBendMove) this).get_tuftingStitchLength();
    string str10 = "tuftingStitchLength = " + num1.ToString();
    stringBuilder11.AppendLine(str10);
    StringBuilder stringBuilder12 = stringBuilder1;
    flag = ((buCutterCalc) this).get_DontUseForCalculation();
    string str11 = "DontUseForCalculation = " + flag.ToString();
    stringBuilder12.AppendLine(str11);
    StringBuilder stringBuilder13 = stringBuilder1;
    num1 = ((CutterIsoEntities) this).get_OrientationA();
    string str12 = "OrientationA = " + num1.ToString();
    stringBuilder13.AppendLine(str12);
    StringBuilder stringBuilder14 = stringBuilder1;
    num1 = ((CutterIsoError) this).get_OrientationB();
    string str13 = "OrientationB = " + num1.ToString();
    stringBuilder14.AppendLine(str13);
    stringBuilder1.AppendLine("ID = " + ((RollerBendRuntimeSettings) this).get_ID());
    stringBuilder1.AppendLine("Command = " + ((RollerBendSettings) this).get_Command());
    StringBuilder stringBuilder15 = stringBuilder1;
    num2 = this.get_EntityIndex();
    string str14 = "EntityIndex = " + num2.ToString();
    stringBuilder15.AppendLine(str14);
    StringBuilder stringBuilder16 = stringBuilder1;
    num2 = this.get_EntitySubIndex();
    string str15 = "EntitySubIndex = " + num2.ToString();
    stringBuilder16.AppendLine(str15);
    StringBuilder stringBuilder17 = stringBuilder1;
    num2 = this.get_CamIndex();
    string str16 = "CamIndex = " + num2.ToString();
    stringBuilder17.AppendLine(str16);
    StringBuilder stringBuilder18 = stringBuilder1;
    num2 = ((buFlexoCalc) this).get_ItemID();
    string str17 = "ItemID = " + num2.ToString();
    stringBuilder18.AppendLine(str17);
    StringBuilder stringBuilder19 = stringBuilder1;
    num2 = this.get_EdgeID();
    string str18 = "EdgeID = " + num2.ToString();
    stringBuilder19.AppendLine(str18);
    StringBuilder stringBuilder20 = stringBuilder1;
    num2 = this.get_InsideIndex();
    string str19 = "InsideIndex = " + num2.ToString();
    stringBuilder20.AppendLine(str19);
    return stringBuilder1.ToString();
  }

  public virtual CustomDataSurrogate ConvertToSurrogate()
  {
    return (CustomDataSurrogate) new buRouter3AX((CustomData) this);
  }

  public abstract void m0019FC();

  public buRouter3AX(CustomData obj)
  {
    ((DrawOptions) this).CamID = -1;
    ((DrawOptions) this).GroupIdIndex = -1;
    ((DrawOptions) this).OriginalEntityIndex = -1;
    ((CamCreateSettings) this).RefIndex = -1;
    ((CamCreateSettings) this).CamSelectable = true;
    ((DoorJob) this).tuftingMode = tuftingStitchModeType.None;
    ((DoorJob) this).tuftingPileHeight = 0.0;
    ((DoorJob) this).tuftingStitchLength = 0.0;
    ((DoorSettings) this).DontUseForCalculation = false;
    ((DoorSettings) this).ID = "";
    // ISSUE: explicit constructor call
    ((Surrogate<CustomData>) this).\u002Ector(obj);
  }

  protected virtual CustomData ConvertToObject()
  {
    CustomData customData = (CustomData) new ClipperOffset(((Router3AXTempVars) this).Tags, ((DrawOptions) this).EntityName, ((Router3AXTempVars) this).SceneName, ((DrawOptions) this).ActionName, ((DrawOptions) this).CamID, ((CamCreateSettings) this).CamSelected, ((DrawOptions) this).GroupIdIndex, ((MachineTableType) this).sortDirection, ((buDoor) this).infoAngle, ((DoorJob) this).infoBasePoint, ((DoorJob) this).infoDegree, ((DoorJob) this).infoHeadRadius, ((buDoor) this).infoHeight, ((buDoor) this).infoLength, ((buDoor) this).infoRadius, ((DoorJob) this).infoSide, ((buDoor) this).infoString, ((buDoor) this).infoWidth, ((MachineTableType) this).OrientationC, ((DoorJob) this).CurveType, ((DoorJob) this).camFeedrate, ((DrawOptions) this).OriginalEntityIndex, ((CamCreateSettings) this).CamSelectable, ((DoorJob) this).Sequence, ((MachineTableType) this).typeDefination, ((buDoor) this).infoData, ((DoorJob) this).infoDirection, ((CamCreateSettings) this).RefIndex, ((DoorJob) this).infoDepth, ((DoorJob) this).tuftingMode, ((DoorJob) this).tuftingPileHeight, ((DoorJob) this).tuftingStitchLength, ((DoorSettings) this).DontUseForCalculation, ((MachineTableType) this).OrientationA, ((MachineTableType) this).OrientationB, ((DoorSettings) this).ID, ((DoorSettings) this).Command, ((DoorSettings) this).EntityIndex, ((DoorSettings) this).EntitySubIndex, ((DoorSettings) this).ItemID, ((DoorSettings) this).EdgeID, ((DoorRuntimeSettings) this).InsideIndex);
    ((Surrogate<CustomData>) this).CopyDataToObject(customData);
    return customData;
  }

  protected virtual void CopyDataToObject(CustomData cd)
  {
    ((ClipperOffset) cd).set_Tags(((Router3AXTempVars) this).Tags);
    ((ClipperOffset) cd).set_SceneName(((Router3AXTempVars) this).SceneName);
    ((ClipperOffset) cd).set_EntityName(((DrawOptions) this).EntityName);
    ((\u001D.\u0001) cd).set_ActionName(((DrawOptions) this).ActionName);
    ((buDiamakerCalc) cd).set_CamID(((DrawOptions) this).CamID);
    ((buCutter) cd).set_CamSelected(((CamCreateSettings) this).CamSelected);
    ((buCutterCalc) cd).set_CamSelectable(((CamCreateSettings) this).CamSelectable);
    ((buDiamakerCalc) cd).set_GroupIdIndex(((DrawOptions) this).GroupIdIndex);
    ((CutterRuntimeSettings) cd).set_sortDirection(((MachineTableType) this).sortDirection);
    ((CutterNotch) cd).set_infoAngle(((buDoor) this).infoAngle);
    ((buRollerBendCalc) cd).set_infoDegree(((DoorJob) this).infoDegree);
    ((ToolGrindingRuntimeSettings) cd).set_infoHeadRadius(((DoorJob) this).infoHeadRadius);
    ((buToolGrindingCalc) cd).set_infoHeight(((buDoor) this).infoHeight);
    ((CutterProgramSettings) cd).set_infoLength(((buDoor) this).infoLength);
    ((ToolGrindingJob) cd).set_infoRadius(((buDoor) this).infoRadius);
    ((ToolGrindingSettings) cd).set_infoSide(((DoorJob) this).infoSide);
    ((CutterProgramSettings) cd).set_infoString(((buDoor) this).infoString);
    ((CutterProgramSettings) cd).set_infoData(((buDoor) this).infoData);
    ((ToolGrindingJob) cd).set_infoWidth(((buDoor) this).infoWidth);
    ((ToolGrindingJob) cd).set_infoDepth(((DoorJob) this).infoDepth);
    ((CutterNotch) cd).set_infoDirection(((DoorJob) this).infoDirection);
    ((DiemakerGrindingShapeSettings) cd).set_RefIndex(((CamCreateSettings) this).RefIndex);
    ((CutterIsoError) cd).set_OrientationA(((MachineTableType) this).OrientationA);
    ((CutterIsoFileSettings) cd).set_OrientationB(((MachineTableType) this).OrientationB);
    ((CutterIsoFileItems) cd).set_OrientationC(((MachineTableType) this).OrientationC);
    ((RollerJob) cd).set_CurveType(((DoorJob) this).CurveType);
    ((CutterIsoEntities) cd).set_CamFeedrate(((DoorJob) this).camFeedrate);
    ((buDiamakerCalc) cd).set_OriginalEntityIndex(((DrawOptions) this).OriginalEntityIndex);
    ((RollerJob) cd).set_Sequence(((DoorJob) this).Sequence);
    ((CutterRuntimeSettings) cd).set_typeDefination(((MachineTableType) this).typeDefination);
    ((RollerBendMove) cd).set_tuftingMode(((DoorJob) this).tuftingMode);
    ((RollerBendMove) cd).set_tuftingPileHeight(((DoorJob) this).tuftingPileHeight);
    ((RollerBendMove) cd).set_tuftingStitchLength(((DoorJob) this).tuftingStitchLength);
    ((buCutterCalc) cd).set_DontUseForCalculation(((DoorSettings) this).DontUseForCalculation);
    ((RollerBendRuntimeSettings) cd).set_ID(((DoorSettings) this).ID);
    ((RollerBendSettings) cd).set_Command(((DoorSettings) this).Command);
    ((buRouter3AX) cd).set_EntityIndex(((DoorSettings) this).EntityIndex);
    ((buRouter3AX) cd).set_EntitySubIndex(((DoorSettings) this).EntitySubIndex);
    ((buFlexoCalc) cd).set_ItemID(((DoorSettings) this).ItemID);
    ((buRouter3AX) cd).set_EdgeID(((DoorSettings) this).EdgeID);
    ((buRouter3AX) cd).set_InsideIndex(((DoorRuntimeSettings) this).InsideIndex);
    if (!(((DoorJob) this).infoBasePoint != (Point3D) null))
      return;
    ((RollerJob) cd).set_infoBasePoint((Point3D) ((DoorJob) this).infoBasePoint.Clone());
  }
}
