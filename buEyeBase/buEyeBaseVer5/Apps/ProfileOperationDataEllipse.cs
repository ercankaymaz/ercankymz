// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationDataEllipse
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataEllipse : buSerilization5
{
  public bool DontUse;
  public bool CalculationError;
  public double PartsTotalWidth;
  public double PartsTotalHeight;
  public string ItemNo;

  public abstract void m001D2D();

  public ProfileOperationDataEllipse()
  {
    if (!buVector5.\u0001("buProfile"))
      throw new RegisterException("buProfile");
  }

  public static string ProfileToString(ProfileItem Profile)
  {
    string str1 = "";
    if (((ProfileSettings) Profile).ItemName.Trim().Length > 0)
      str1 = ((ProfileSettings) Profile).ItemName.Trim();
    string str2;
    if (str1.Length > 0)
      str2 = $"{str1}- {buLangTranslate.preChar.Length}: {((ProfileSettings) Profile).Length.ToString()}";
    else
      str2 = $"{buLangTranslate.preChar.Length}: {((ProfileSettings) Profile).Length.ToString()}";
    string str3 = $"{str2} - {buLangTranslate.preChar.Width}: {(((ProfileSettings) Profile).ProfileMaxPoint.Y - ((ProfileSettings) Profile).ProfileMinPoint.Y).ToString("f1")} - {buLangTranslate.preChar.Height}: {((ProfileSettings) Profile).ProfileMaxPoint.Z.ToString("f1")}";
    return ((ProfileSettings) Profile).XReferanceLocation != LeftRightType.Left ? $"{str3} - {buLangTranslate.preDef.Right}" : $"{str3} - {buLangTranslate.preDef.Left}";
  }

  public static string OperationItemString(ProfileOperation Op, string charPriority = "P")
  {
    string str1 = "";
    string str2 = "";
    if (((ProfileRuntimeSettings) Op).Priority != 0)
      str2 = $" - {charPriority}: {((ProfileRuntimeSettings) Op).Priority.ToString()}";
    string str3 = $" | {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} , X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString("f1")} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Circle)
      str1 = $"{AppLanguage.CadCamDynamic[51]}{str2}{str3} - Dia: {AppLanguage.CadCamDynamic[57]}{((CreateProfileFromDataOptions) ((OperationInsideClampers) ((ProfileRuntimeSettings) Op).OperationData).CircleData).CircleDiameter.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Rectangle)
      str1 = $"{AppLanguage.CadCamDynamic[62]}{str2}{str3} - W: {((CreateProfileFromDataOptions) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleData).RectangleWidth.ToString("f1")} , H: {((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleData).RectangleHeight.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.RoundRectangle)
      str1 = $"{AppLanguage.CadCamDynamic[63 /*0x3F*/]}{str2}{str3} - W: {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleRoundData).RoundRectangleWidth.ToString("f1")} , H: {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleRoundData).RoundRectangleHeight.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Slot)
      str1 = $"{AppLanguage.CadCamDynamic[59]}{str2}{str3} - Dia: {((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).SlotData).SlotDiameter.ToString("f1")} , W: {((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).SlotData).SlotWidth.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Cut)
      str1 = $"{AppLanguage.CadCamDynamic[123]}{str2}{str3} - W: {((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).CutData).CutWidth.ToString("f1")} , H: {((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).CutData).CutHeigth.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Barrel)
      str1 = $"{AppLanguage.CadCamDynamic[60]}{str2}{str3} - Dia:{((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).BarelData).BarrelDiameter.ToString("f1")} , L: {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).BarelData).BarrelLength.ToString("f1")} , W: {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).BarelData).BarrelWidth.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Ellipse)
      str1 = $"{AppLanguage.CadCamDynamic[54]}{str2}{str3} - Dx:{((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).EllipseData).EllipseWidth.ToString("f1")} , Dy: {((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).EllipseData).EllipseHeight.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Hole)
      str1 = $"{AppLanguage.CadCamDynamic[124]}{str2}{str3} - Dia:{((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).HoleData).HoleDiameter.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Tapping)
      str1 = $"{buLangTranslate.preDef.Tapping}{str2}{str3} - Dia:{((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).HoleData).HoleDiameter.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Notch)
      str1 = $"{AppLanguage.CadCamDynamic[125]}{str2}{str3} - D:{((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).NotchData).NotchDepth.ToString("f1")} , H:{((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).NotchData).NotchHeight.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.FreeDraw)
      str1 = $"{AppLanguage.CadCamDynamic[77]}{str2}{str3} - W:{((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).FreeDrawData).FreeDrawWidth.ToString("f1")} , H:{((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).FreeDrawData).FreeDrawHeight.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Text)
      str1 = $"{buLangTranslate.preDef.Text}{str2}{str3} - T:{((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextString.ToString()}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.WireText)
      str1 = $"{buLangTranslate.preDef.Text}  {buLangTranslate.preDef.Wireframe}{str2}{str3} - T:{((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextString.ToString()}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Polygon)
      str1 = $"{buLangTranslate.preDef.Polygon}{str2}{str3} - Side:{((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).PolygonData).PolygonSide.ToString()} , Dia:{((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).PolygonData).PolygonDiameter.ToString("f1")}";
    return str1;
  }

  public static string OperationItemDetailedString(ProfileOperation Op)
  {
    string str1 = "";
    string str2 = $" | X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString("f1")} , Y: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.Y.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Circle)
      str1 = $"{AppLanguage.CadCamDynamic[51]}{str2} - {AppLanguage.CadCamDynamic[57]}= {((CreateProfileFromDataOptions) ((OperationInsideClampers) ((ProfileRuntimeSettings) Op).OperationData).CircleData).CircleDiameter.ToString("f1")} - {AppLanguage.CadCamDynamic[113]}= {((CreateProfileFromDataOptions) ((OperationInsideClampers) ((ProfileRuntimeSettings) Op).OperationData).CircleData).CircleThickness.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Rectangle)
    {
      str1 = $"{AppLanguage.CadCamDynamic[62]}{str2} - {AppLanguage.CadCamDynamic[15]}= {((CreateProfileFromDataOptions) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleData).RectangleWidth.ToString("f1")} - {AppLanguage.CadCamDynamic[16 /*0x10*/]}= {((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleData).RectangleHeight.ToString("f1")} - {AppLanguage.CadCamDynamic[113]}= {((profileSortSequenceAtSamePosition) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleData).RectangleThickness.ToString("f1")}";
      if (((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleData).RectangleAngle != 0.0)
        str1 = $"{str1} - {AppLanguage.CadCamDynamic[2]}= {((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleData).RectangleAngle.ToString("f1")}";
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.RoundRectangle)
    {
      str1 = $"{AppLanguage.CadCamDynamic[63 /*0x3F*/]}{str2} - {AppLanguage.CadCamDynamic[15]}= {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleRoundData).RoundRectangleWidth.ToString("f1")} - {AppLanguage.CadCamDynamic[16 /*0x10*/]}= {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleRoundData).RoundRectangleHeight.ToString("f1")} - {AppLanguage.CadCamDynamic[19]}= {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleRoundData).RoundRectangleRadius.ToString("f1")} - {AppLanguage.CadCamDynamic[113]}= {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleRoundData).RoundRectangleThickness.ToString("f1")}";
      if (((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleData).RectangleAngle != 0.0)
        str1 = $"{str1} - {AppLanguage.CadCamDynamic[2]}= {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).RectangleRoundData).RoundRectangleAngle.ToString("f1")}";
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Slot)
    {
      str1 = $"{AppLanguage.CadCamDynamic[59]}{str2} - {AppLanguage.CadCamDynamic[15]}= {((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).SlotData).SlotWidth.ToString("f1")} - {AppLanguage.CadCamDynamic[57]}= {((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).SlotData).SlotDiameter.ToString("f1")} - {AppLanguage.CadCamDynamic[113]}= {((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).SlotData).SlotThickness.ToString("f1")}";
      if (((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).SlotData).SlotAngle != 0.0)
        str1 = $"{str1} - {AppLanguage.CadCamDynamic[2]}= {((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).SlotData).SlotAngle.ToString("f1")}";
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Cut)
    {
      str1 = $"{AppLanguage.CadCamDynamic[123]}{str2} - {AppLanguage.CadCamDynamic[15]}= {((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).CutData).CutWidth.ToString("f1")} - {AppLanguage.CadCamDynamic[16 /*0x10*/]}= {((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).CutData).CutHeigth.ToString("f1")} - {AppLanguage.CadCamDynamic[113]}= {((PanelWaitAssembly) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).CutData).CutThickness.ToString("f1")}";
      if (((PanelWaitAssembly) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).CutData).CutAngle != 0.0)
        str1 = $"{str1} - {AppLanguage.CadCamDynamic[2]}= {((PanelWaitAssembly) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).CutData).CutAngle.ToString("f1")}";
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Barrel)
    {
      str1 = $"{AppLanguage.CadCamDynamic[60]}{str2} - {AppLanguage.CadCamDynamic[57]}= {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).BarelData).BarrelDiameter.ToString("f1")} - {AppLanguage.CadCamDynamic[0]}= {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).BarelData).BarrelLength.ToString("f1")} - {AppLanguage.CadCamDynamic[15]}= {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).BarelData).BarrelWidth.ToString("f1")} - {AppLanguage.CadCamDynamic[113]}= {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).BarelData).BarrelThickness.ToString("f1")}";
      if (((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).BarelData).BarrelAngle != 0.0)
        str1 = $"{str1} - {AppLanguage.CadCamDynamic[2]}= {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).BarelData).BarrelAngle.ToString("f1")}";
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Ellipse)
    {
      str1 = $"{AppLanguage.CadCamDynamic[54]}{str2} - {AppLanguage.CadCamDynamic[15]}= {((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).EllipseData).EllipseWidth.ToString("f1")} - {AppLanguage.CadCamDynamic[16 /*0x10*/]}= {((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).EllipseData).EllipseHeight.ToString("f1")} - {AppLanguage.CadCamDynamic[113]}= {((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).EllipseData).EllipseThickness.ToString("f1")}";
      if (((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).EllipseData).EllipseAngle != 0.0)
        str1 = $"{str1} - {AppLanguage.CadCamDynamic[2]}= {((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).EllipseData).EllipseAngle.ToString("f1")}";
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Hole)
      str1 = $"{AppLanguage.CadCamDynamic[124]}{str2} - {AppLanguage.CadCamDynamic[57]}= {((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).HoleData).HoleDiameter.ToString("f1")} - {AppLanguage.CadCamDynamic[113]}= {((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).HoleData).HoleThickness.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Tapping)
      str1 = $"{buLangTranslate.preDef.Tapping}{str2} - {AppLanguage.CadCamDynamic[57]}= {((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).HoleData).HoleDiameter.ToString("f1")} - {AppLanguage.CadCamDynamic[113]}= {((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).HoleData).HoleThickness.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Notch)
      str1 = $"{$"{AppLanguage.CadCamDynamic[125]} - {AppLanguage.CadCamDynamic[84]}= {((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).NotchData).NotchLocation.ToString()} - {AppLanguage.CadCamDynamic[(int) sbyte.MaxValue]}= {((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) Op).OperationData).CamParNotch).Notch).CutDirection.ToString()} - {((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) Op).OperationData).CamParNotch).Notch).NotchCutDirection.ToString()} - {((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) Op).OperationData).CamParNotch).Notch).NotchCutType.ToString()}"} - {AppLanguage.CadCamDynamic[15]}= {((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).NotchData).NotchWidth.ToString("f1")} - {AppLanguage.CadCamDynamic[16 /*0x10*/]}= {((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).NotchData).NotchHeight.ToString("f1")} - {AppLanguage.CadCamDynamic[113]}= {((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Op).OperationData).NotchData).NotchDepth.ToString("f1")}";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.FreeDraw)
    {
      str1 = $"{AppLanguage.CadCamDynamic[77]}{str2} - {AppLanguage.CadCamDynamic[15]}= {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).FreeDrawData).FreeDrawWidth.ToString("f1")} - {AppLanguage.CadCamDynamic[16 /*0x10*/]}= {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).FreeDrawData).FreeDrawHeight.ToString("f1")} - {AppLanguage.CadCamDynamic[50]}= {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).FreeDrawData).FreeDrawScaleCenter.ToString()} - {AppLanguage.CadCamDynamic[113]}= {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).FreeDrawData).FreeDrawThickness.ToString("f1")}";
      if (((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).FreeDrawData).FreeDrawAngle != 0.0)
        str1 = $"{str1} - {AppLanguage.CadCamDynamic[2]}= {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).FreeDrawData).FreeDrawAngle.ToString("f1")}";
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Text)
    {
      str1 = $"{buLangTranslate.preDef.Text}{str2} - {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextString.ToString()} - {AppLanguage.CadCamDynamic[15]}= {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextWidth.ToString("f1")} - {AppLanguage.CadCamDynamic[16 /*0x10*/]}= {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextHeight.ToString("f1")} - {AppLanguage.CadCamDynamic[50]}= {((PanelCutSettings) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextScaleCenter.ToString()} - {AppLanguage.CadCamDynamic[126]}= {((PanelCutSettings) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextAlignment.ToString()} - {AppLanguage.CadCamDynamic[113]}= {((PanelCutSettings) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextThickness.ToString("f1")}";
      if (((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextAngle != 0.0)
        str1 = $"{str1} - {AppLanguage.CadCamDynamic[2]}= {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextAngle.ToString("f1")}";
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.WireText)
    {
      str1 = $"{buLangTranslate.preDef.Text} {buLangTranslate.preDef.Wireframe}{str2} - {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextString.ToString()} - {AppLanguage.CadCamDynamic[15]}= {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextWidth.ToString("f1")} - {AppLanguage.CadCamDynamic[16 /*0x10*/]}= {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextHeight.ToString("f1")} - {AppLanguage.CadCamDynamic[50]}= {((PanelCutSettings) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextScaleCenter.ToString()} - {AppLanguage.CadCamDynamic[126]}= {((PanelCutSettings) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextAlignment.ToString()} - {AppLanguage.CadCamDynamic[113]}= {((PanelCutSettings) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextThickness.ToString("f1")}";
      if (((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextAngle != 0.0)
        str1 = $"{str1} - {AppLanguage.CadCamDynamic[2]}= {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).TextData).TextAngle.ToString("f1")}";
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Polygon)
    {
      str1 = $"{AppLanguage.CadCamDynamic[70]}{str2} - {AppLanguage.CadCamDynamic[71]}= {((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).PolygonData).PolygonSide.ToString()} - {AppLanguage.CadCamDynamic[57]}= {((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).PolygonData).PolygonDiameter.ToString("f1")} - {AppLanguage.CadCamDynamic[113]}= {((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).PolygonData).PolygonThickness.ToString("f1")}";
      if (((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).PolygonData).PolygonThickness != 0.0)
        str1 = $"{str1} - {AppLanguage.CadCamDynamic[2]}= {((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) Op).OperationData).PolygonData).PolygonThickness.ToString("f1")}";
    }
    return str1;
  }

  public static string OperationItemString(GProfileOperation Op, string strOperation, int Index)
  {
    string str = strOperation;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Circle)
      str = $"{MarbleJob.strCircle} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Rectangle)
      str = $"{MarbleJob.strRectangle} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.RoundRectangle)
      str = $"{MarbleItem.strRoundRect} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Slot)
      str = $"{MarbleItem.strSlot} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Cut)
      str = $"{MarbleItem.strCut} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Barrel)
      str = $"{MarbleJob.strKeyHole} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Ellipse)
      str = $"{MarbleJob.strEllipse} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Hole)
      str = $"{MarbleJob.strHole} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Notch)
      str = $"{MarbleItem.strNotch} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.FreeDraw)
      str = $"{MarbleItem.strFreeDraw} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Text)
      str = $"{MarbleItem.strText} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.WireText)
      str = $"{MarbleItem.strText} {buLangTranslate.preDef.Wireframe} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Polygon)
      str = $"{MarbleItem.strPoylgon} {(Index + 1).ToString()}: [{((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    return str;
  }
}
