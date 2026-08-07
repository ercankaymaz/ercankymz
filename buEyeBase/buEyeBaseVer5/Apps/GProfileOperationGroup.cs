// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.GProfileOperationGroup
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
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class GProfileOperationGroup
{
  public nestAlgorithm Algorithm;
  public double RectangleMarginLeft;

  public static string NestedResultInfoForCutter(
    buNestedResult Result,
    buNestingProgramSettings Settings)
  {
    try
    {
      string str1 = "";
      if (((ProfileOperationData) Result).ExecutionDate.Year > 2000)
        str1 = $"{str1}{AppLanguage.CadCamDynamic[101]} = {((ProfileOperationData) Result).ExecutionDate.ToString("MM/dd/yyyy-HH:mm:ss")}{Environment.NewLine}";
      string str2 = $"{str1}{buLangTranslate.preDef.Pastal} {AppLanguage.CadCamDynamic[40]} = {((ProfileOperationData) Result).JobName}{Environment.NewLine}";
      if (((ProfileOperationData) Result).JobExplanation.Trim().Length > 0)
        str2 = $"{str2}{buLangTranslate.preDef.Pastal} {AppLanguage.CadCamDynamic[3]} = {((ProfileOperationData) Result).JobExplanation}{Environment.NewLine}";
      string str3 = $"{str2}{buLangTranslate.preDef.Pastal} {AppLanguage.CadCamDynamic[15]} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[0]).MaterialHeight.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()}{Environment.NewLine}";
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      for (int index = 0; index <= ((ProfileOperationData) Result).NestedResultSheets.Count - 1; ++index)
      {
        if (((ProfileClamperSettings) Settings).CalculationShowFormat == nestCalculationShowFormat.MultiSheet)
          num1 += ((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[index]).UsingPersentage;
        else if (((ProfileClamperSettings) Settings).CalculationShowFormat == nestCalculationShowFormat.PastalAsSingleSheet)
          num1 += ((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[index]).UsingPersentageFromMaxX;
        num2 += ((ProfileOperationDataPolygon) ((ProfileOperationData) Result).NestedResultSheets[index]).ApproxExecutionTimeSec;
        num3 += ((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[index]).TotalLength;
      }
      double num4 = num1 / (double) ((ProfileOperationData) Result).NestedResultSheets.Count;
      string str4 = $"{$"{str3}{buLangTranslate.preDef.Pastal} {buLangTranslate.preDef.Efficiency} = %{num4.ToString("f2")}{Environment.NewLine}"}{buLangTranslate.preDef.Cutting} {buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length} = {(num3 / 1000.0).ToString("f2")} m{Environment.NewLine}";
      if (((ProfileOperationData) Result).OrderedTotalPartCount > 0)
        str4 = $"{str4}{buLangTranslate.preDef.Part} {AppLanguage.CadCamDynamic[53]} = {((ProfileOperationData) Result).NestedTotalPartCount.ToString()} \\ {((ProfileOperationData) Result).OrderedTotalPartCount.ToString()}{Environment.NewLine}";
      string str5 = $"{str4}{AppLanguage.CadCamDynamic[85]} = {((ProfileOperationData) Result).ExecutionTime.ToString("f1")} {AppLanguage.CadCamDynamic[102]}{Environment.NewLine}";
      if (((ProfileOperationData) Result).PartGap > 0.0)
        str5 = $"{str5}{buLangTranslate.preDef.Part} {AppLanguage.CadCamDynamic[100]} = {((ProfileOperationData) Result).PartGap.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()}{Environment.NewLine}";
      if ((((ProfileOperationData) Result).NestedResultSheets.Count <= 0 ? 0 : (((ProfileOperationDataNotch) ((ProfileOperationData) Result).NestedResultSheets[0]).Parts.Count > 0 ? 1 : 0)) != 0)
        str5 = $"{str5}{buLangTranslate.preDef.Part} {buLangTranslate.preDef.Rotation} = {((ProfileOperationDataText) ((ProfileOperationDataNotch) ((ProfileOperationData) Result).NestedResultSheets[0]).Parts[0]).Rotation.ToString()}{Environment.NewLine}";
      if (((ProfileOperationData) Result).MaxXPosition > 0.0 & ((ProfileOperationData) Result).NestedResultSheets.Count == 1)
        str5 = $"{str5}{buLangTranslate.preDef.Pastal} {AppLanguage.CadCamDynamic[0]} = {((ProfileOperationData) Result).MaxXPosition.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()}{Environment.NewLine}";
      if (num2 > 0.0)
      {
        TimeSpan timeSpan = TimeSpan.FromSeconds(num2);
        string str6 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
        str5 = $"{str5}{buLangTranslate.preDef.Approx} {buLangTranslate.preDef.Time} = {str6}{Environment.NewLine}";
      }
      return str5;
    }
    catch (Exception ex)
    {
      string str = "ID:00400012";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }

  public void SortNestingMaterialFromSmallToBig(
    bool FromLowerToBigger,
    ref List<buNestingSheet> Mateials)
  {
    try
    {
      for (int index1 = 0; index1 <= Mateials.Count - 1; ++index1)
      {
        for (int index2 = index1; index2 <= Mateials.Count - 1; ++index2)
        {
          if (FromLowerToBigger)
          {
            if (((ProfileItemCalc) Mateials[index1]).Area > ((ProfileItemCalc) Mateials[index2]).Area)
            {
              buNestingSheet data = (buNestingSheet) new ProfileOperation(Mateials[index2]);
              Mateials[index2] = (buNestingSheet) new ProfileOperation(Mateials[index1]);
              Mateials[index1] = (buNestingSheet) new ProfileOperation(data);
            }
          }
          else if (((ProfileItemCalc) Mateials[index1]).Area < ((ProfileItemCalc) Mateials[index2]).Area)
          {
            buNestingSheet data = (buNestingSheet) new ProfileOperation(Mateials[index2]);
            Mateials[index2] = (buNestingSheet) new ProfileOperation(Mateials[index1]);
            Mateials[index1] = (buNestingSheet) new ProfileOperation(data);
          }
        }
      }
    }
    catch (Exception ex)
    {
      string str = "FromLowerToBigger : " + FromLowerToBigger.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CreatePointAndSolidFromEntityGroup(ref buEntitiesGroup entGroup, bool View3D = true)
  {
    if (((\u0084.\u0001) entGroup.Outside).Entities.Count <= 0)
      return;
    ((\u0084.\u0001) entGroup.Outside).Points = new List<Point3D>();
    buCall.\u0001.EntitiesToPointsWithCamDirection(((\u0084.\u0001) entGroup.Outside).Entities, ref ((\u0084.\u0001) entGroup.Outside).Points);
    ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref ((\u0084.\u0001) entGroup.Outside).Points);
    if ((entGroup.Inside == null ? 0 : (entGroup.Inside.Count > 0 ? 1 : 0)) != 0)
    {
      for (int index = 0; index <= entGroup.Inside.Count - 1; ++index)
      {
        ((\u0084.\u0001) entGroup.Inside[index]).Points = new List<Point3D>();
        buCall.\u0001.EntitiesToPointsWithCamDirection(((\u0084.\u0001) entGroup.Inside[index]).Entities, ref ((\u0084.\u0001) entGroup.Inside[index]).Points);
        ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref ((\u0084.\u0001) entGroup.Inside[index]).Points);
      }
    }
    if ((entGroup.OpenEntities == null ? 0 : (entGroup.OpenEntities.Count > 0 ? 1 : 0)) != 0)
    {
      for (int index = 0; index <= entGroup.OpenEntities.Count - 1; ++index)
      {
        ((\u0084.\u0001) entGroup.OpenEntities[index]).Points = new List<Point3D>();
        buCall.\u0001.EntitiesToPointsWithCamDirection(((\u0084.\u0001) entGroup.OpenEntities[index]).Entities, ref ((\u0084.\u0001) entGroup.OpenEntities[index]).Points);
        ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref ((\u0084.\u0001) entGroup.OpenEntities[index]).Points);
      }
    }
    if (!View3D)
      return;
    Entity entSurface = (Entity) null;
    buCall.\u0001.surfaceFromOutterInner(entGroup, 0.2, ref entSurface);
    if (entSurface == null)
      return;
    ((DimensionGroup) entGroup).Solid = (buEntityList) new buArcCam();
    buEntity copiedEntity = (buEntity) null;
    buAngularDim.Copy(entSurface, ref copiedEntity);
    if (copiedEntity == null)
      return;
    ((\u0084.\u0001) ((DimensionGroup) entGroup).Solid).Entities.Add(copiedEntity);
  }
}
