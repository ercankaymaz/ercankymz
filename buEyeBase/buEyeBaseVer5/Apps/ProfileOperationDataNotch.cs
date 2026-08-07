// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationDataNotch
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataNotch : buSerilization5
{
  public string SalesNo;
  public string Other;
  public string Aux;
  public double UserData;
  public string WarningText;
  public double SheetMaxXPosition;
  public double SheetMaxYPosition;
  public nestMaterialType Type;
  public buEntitiesGroup EntitiesGroup;
  public List<List<buEntity>> UselessEntities;
  public List<buNestedPart> Parts;

  public static string OperationItemStringV2(GProfileOperation Op)
  {
    string str;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Circle)
      str = $"{buLangTranslate.preDef.Cirlce} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Rectangle)
      str = $"{buLangTranslate.preDef.Rectangle} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.RoundRectangle)
      str = $"{buLangTranslate.preDef.RectangleRound} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Slot)
      str = $"{buLangTranslate.preDef.Slot} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Cut)
      str = $"{buLangTranslate.preDef.Cut} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Barrel)
      str = $"{buLangTranslate.preDef.KeyHole} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Ellipse)
      str = $"{buLangTranslate.preDef.Ellipse} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Hole)
      str = $"{buLangTranslate.preDef.Hole} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Notch)
      str = $"{buLangTranslate.preDef.Notch} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.FreeDraw)
      str = $"{buLangTranslate.preDef.FreeDraw} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Text)
      str = $"{buLangTranslate.preDef.Text} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.WireText)
      str = $"{buLangTranslate.preDef.Text} - {buLangTranslate.preDef.Wireframe} {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Op).OperationData).OperationType == ProfileOperationTypes.Polygon)
      str = $"{buLangTranslate.preDef.Polygon} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    else
      str = $"{buLangTranslate.preDef.Other} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()} - [ X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) Op).OperationData).Position.X.ToString()}]";
    return $"{str} - {((ProfileMirror) ((ProfileRuntimeSettings) Op).OperationData).selectedPlaneName.ToString()}";
  }

  public static string PlaneToString(planeNames refPlane)
  {
    string str;
    switch (refPlane)
    {
      case planeNames.Top:
        str = buLangTranslate.preDef.Top;
        break;
      case planeNames.Bottom:
        str = buLangTranslate.preDef.Bottom;
        break;
      case planeNames.Left:
        str = buLangTranslate.preDef.Left;
        break;
      case planeNames.Right:
        str = buLangTranslate.preDef.Right;
        break;
      case planeNames.Front:
        str = buLangTranslate.preDef.Front;
        break;
      case planeNames.Back:
        str = buLangTranslate.preDef.Back;
        break;
      default:
        str = buLangTranslate.preDef.Free;
        break;
    }
    return str;
  }

  public int GetOperationImageIndex(ProfileOperation OP)
  {
    int operationImageIndex = Convert.ToInt32((object) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType);
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.WireText)
      operationImageIndex = 32 /*0x20*/;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Tapping)
      operationImageIndex = 42;
    if (!((ProfileRuntimeSettings) OP).Enable)
      operationImageIndex = 26;
    if (((ProfileRuntimeSettings) OP).Error)
      ;
    return operationImageIndex;
  }

  public void SetWaterOnAdnOffToCam(ref List<camTp> Cams, string WaterOn, string WaterOff)
  {
    bool flag = false;
    for (int index1 = 0; index1 <= Cams.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= Cams[index1].CamPoints.Count - 1; ++index2)
      {
        for (int index3 = 0; index3 <= Cams[index1].CamPoints[index2].Points.Count - 1; ++index3)
        {
          TpPnt9D point = Cams[index1].CamPoints[index2].Points[index3];
          TpPnt9D tpPnt9D1 = (TpPnt9D) null;
          TpPnt9D tpPnt9D2 = (TpPnt9D) null;
          if (index3 < Cams[index1].CamPoints[index2].Points.Count - 1)
            tpPnt9D1 = Cams[index1].CamPoints[index2].Points[index3 + 1];
          if (index3 > 0)
            tpPnt9D2 = Cams[index1].CamPoints[index2].Points[index3 - 1];
          if (flag & tpPnt9D2 != null && point.Type == 0 & tpPnt9D2.Type > 0)
          {
            point.AfterCodes.Add((object) WaterOff);
            flag = false;
          }
          if (!flag & tpPnt9D1 != null && point.Type == 0 & tpPnt9D1.Type > 0)
          {
            point.AfterCodes.Add((object) WaterOn);
            flag = true;
          }
        }
      }
    }
  }

  public void SetWaterOnAdnOffToCam(
    ref List<camTp> Cams,
    List<string> WaterOn,
    List<string> WaterOff)
  {
    bool flag = false;
    for (int index1 = 0; index1 <= Cams.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= Cams[index1].CamPoints.Count - 1; ++index2)
      {
        for (int index3 = 0; index3 <= Cams[index1].CamPoints[index2].Points.Count - 1; ++index3)
        {
          TpPnt9D point = Cams[index1].CamPoints[index2].Points[index3];
          TpPnt9D tpPnt9D1 = (TpPnt9D) null;
          TpPnt9D tpPnt9D2 = (TpPnt9D) null;
          if (index3 < Cams[index1].CamPoints[index2].Points.Count - 1)
            tpPnt9D1 = Cams[index1].CamPoints[index2].Points[index3 + 1];
          if (index3 > 0)
            tpPnt9D2 = Cams[index1].CamPoints[index2].Points[index3 - 1];
          if (flag & tpPnt9D2 != null && point.Type == 0 & tpPnt9D2.Type > 0)
          {
            point.AfterCodes.AddRange((ICollection) WaterOff);
            flag = false;
          }
          if (!flag & tpPnt9D1 != null && point.Type == 0 & tpPnt9D1.Type > 0)
          {
            point.AfterCodes.AddRange((ICollection) WaterOn);
            flag = true;
          }
        }
      }
    }
  }

  public void InsertProfileInfoToGCode(
    ProfileItem Item,
    int IndestIndex,
    ref PostProcessor tempPost,
    string CommentStartChar,
    string CommentEndChar,
    string EqualChar = " = ")
  {
    string callMethod = nameof (InsertProfileInfoToGCode);
    try
    {
      string str = buLangTranslate.preDef.Left;
      if (((ProfileSettings) Item).XReferanceLocation == LeftRightType.Right)
        str = buLangTranslate.preDef.Right;
      tempPost.StartLines.Insert(IndestIndex, (object) $"{CommentStartChar}{str} {buLangTranslate.preDef.Profile} {CommentEndChar}");
      tempPost.StartLines.Insert(IndestIndex + 1, (object) $"{CommentStartChar}{buLangTranslate.preDef.Length}{EqualChar}{((ProfileSettings) Item).Length.ToString("f2")} {CommentEndChar}");
      tempPost.StartLines.Insert(IndestIndex + 2, (object) $"{CommentStartChar}{buLangTranslate.preDef.Width}{EqualChar}{((ProfileSettings) Item).Width.ToString("f2")} {CommentEndChar}");
      tempPost.StartLines.Insert(IndestIndex + 3, (object) $"{CommentStartChar}{buLangTranslate.preDef.Height}{EqualChar}{((ProfileSettings) Item).Height.ToString("f2")} {CommentEndChar}");
    }
    catch (Exception ex)
    {
      buException.throwException(ex, ProfileSettings.sClass, callMethod, false, "");
    }
  }
}
