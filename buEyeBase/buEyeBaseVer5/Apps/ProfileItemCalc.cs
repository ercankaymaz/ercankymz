// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileItemCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileItemCalc : buSerilization5
{
  public double UserData;
  public ToolBase5 Tool;
  public static List<string> Captions;
  public static byte f00421D;
  public buNestingSheetData MaterialData;
  public double Area;
  public double Cost;
  public int Used;
  public int Remain;
  public int ID;
  public string Aux;
  public string FileName;
  public bool Enable;
  public string Remarks;
  public string Referance;
  public double TrimWidth;
  public double TrimHeight;
  public nestMaterialType Type;
  public buEntitiesGroup EntitiesGroup;
  public static List<string> Captions;
  public static byte f00422E;
  public nestCorner CornerType;
  public nestDirection Direction;

  public static string NestedResultInfo(buNestedResult Result, buNestingProgramSettings Settings)
  {
    return !((ProfileClamperSettings) Settings).isCutter ? ProfileItemCalc.NestedResultInfoForCommon(Result, Settings) : GProfileOperationGroup.NestedResultInfoForCutter(Result, Settings);
  }

  public static string NestedSheetInfoForCommon(
    buNestedResult Result,
    int Index,
    buNestingProgramSettings Settings,
    int LineCount)
  {
    try
    {
      string str = "";
      if (LineCount <= 0)
      {
        str = $"{$"{$"{$"{$"{$"{str}{buLangTranslate.preDef.Width} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).MaterialWidth.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()}{Environment.NewLine}"}{buLangTranslate.preDef.Height} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).MaterialHeight.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()}{Environment.NewLine}"}{buLangTranslate.preDef.Efficiency} = %{((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[Index]).UsingPersentage.ToString("f2")}{Environment.NewLine}"}{buLangTranslate.preDef.Sheet} {buLangTranslate.preDef.Area} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).MaterialArea.ToString("f2")} {((ProfileClamperSettings) Settings).UnitArea.ToString()}\u00B2{Environment.NewLine}"}{buLangTranslate.preDef.Part} {buLangTranslate.preDef.Area} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).NestedArea.ToString("f2")} {((ProfileClamperSettings) Settings).UnitArea.ToString()}\u00B2{Environment.NewLine}"}{buLangTranslate.preDef.Count} = {((ProfileOperationDataNotch) ((ProfileOperationData) Result).NestedResultSheets[Index]).Parts.Count.ToString()}{Environment.NewLine}";
        if (((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult != null)
          str = $"{$"{$"{$"{str + Environment.NewLine}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Time} =  {buNumeric5.SecondToTimeFormat(((F_CutterOffsetEntities) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult).TotalTimeAsSec)} - "}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Time} =  {buNumeric5.SecondToTimeFormat(((F_NotchEdit) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult).OperationTimeAsSec)}{Environment.NewLine}"}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length} =  {((F_NotchEdit) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult).TotalLengthAsMeter.ToString("f2")} m - "}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Length} =  {((F_NotchEdit) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult).OperationLengthAsMeter.ToString("f2")} m ";
        if (((ProfileOperationDataNotch) ((ProfileOperationData) Result).NestedResultSheets[Index]).SheetMaxXPosition > 0.0)
          str = $"{str}Max {buLangTranslate.preDef.Length} = {((ProfileOperationDataNotch) ((ProfileOperationData) Result).NestedResultSheets[Index]).SheetMaxXPosition.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()}{Environment.NewLine}";
      }
      else if (LineCount == 1)
      {
        str = $"{$"{$"{$"{$"{$"{str}{buLangTranslate.preDef.Width} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).MaterialWidth.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()} - "}{buLangTranslate.preDef.Height} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).MaterialHeight.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()} - "}{buLangTranslate.preDef.Efficiency} = %{((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[Index]).UsingPersentage.ToString("f2")} - "}{buLangTranslate.preDef.Sheet} {buLangTranslate.preDef.Area} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).MaterialArea.ToString("f2")} {((ProfileClamperSettings) Settings).UnitArea.ToString()}\u00B2 - "}{buLangTranslate.preDef.Part} {buLangTranslate.preDef.Area} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).NestedArea.ToString("f2")} {((ProfileClamperSettings) Settings).UnitArea.ToString()}\u00B2 - "}{buLangTranslate.preDef.Count} = {((ProfileOperationDataNotch) ((ProfileOperationData) Result).NestedResultSheets[Index]).Parts.Count.ToString()}";
        if (((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult != null)
          str = $"{$"{$"{$"{str + Environment.NewLine}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Time} =  {buNumeric5.SecondToTimeFormat(((F_CutterOffsetEntities) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult).TotalTimeAsSec)} - "}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Time} =  {buNumeric5.SecondToTimeFormat(((F_NotchEdit) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult).OperationTimeAsSec)}{Environment.NewLine}"}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length} =  {((F_NotchEdit) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult).TotalLengthAsMeter.ToString("f2")} m - "}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Length} =  {((F_NotchEdit) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult).OperationLengthAsMeter.ToString("f2")} m ";
      }
      else if (LineCount == 2)
      {
        str = $"{$"{$"{$"{$"{$"{str}{buLangTranslate.preDef.Width} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).MaterialWidth.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()} - "}{buLangTranslate.preDef.Height} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).MaterialHeight.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()} - "}{buLangTranslate.preDef.Efficiency} = %{((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[Index]).UsingPersentage.ToString("f2")}{Environment.NewLine}"}{buLangTranslate.preDef.Sheet} {buLangTranslate.preDef.Area} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).MaterialArea.ToString("f2")} {((ProfileClamperSettings) Settings).UnitArea.ToString()}\u00B2 - "}{buLangTranslate.preDef.Part} {buLangTranslate.preDef.Area} = {((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).NestedArea.ToString("f2")} {((ProfileClamperSettings) Settings).UnitArea.ToString()}\u00B2 - "}{buLangTranslate.preDef.Count} = {((ProfileOperationDataNotch) ((ProfileOperationData) Result).NestedResultSheets[Index]).Parts.Count.ToString()}";
        if (((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult != null)
          str = $"{$"{$"{$"{str + Environment.NewLine}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Time} =  {buNumeric5.SecondToTimeFormat(((F_CutterOffsetEntities) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult).TotalTimeAsSec)} - "}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Time} =  {buNumeric5.SecondToTimeFormat(((F_NotchEdit) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult).OperationTimeAsSec)}{Environment.NewLine}"}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length} =  {((F_NotchEdit) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult).TotalLengthAsMeter.ToString("f2")} m - "}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Length} =  {((F_NotchEdit) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[Index]).GCodeResult).OperationLengthAsMeter.ToString("f2")} m ";
      }
      return str;
    }
    catch (Exception ex)
    {
      string str = "ID:00400011";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }

  public static string NestedResultInfoForCommon(
    buNestedResult Result,
    buNestingProgramSettings Settings)
  {
    try
    {
      string str1 = "";
      List<buNestedSheet> buNestedSheetList = new List<buNestedSheet>();
      for (int index1 = 0; index1 <= ((ProfileOperationData) Result).NestedResultSheets.Count - 1; ++index1)
      {
        if (buNestedSheetList.Count == 0)
        {
          buNestedSheet buNestedSheet = (buNestedSheet) new ProfileOperationData(((ProfileOperationData) Result).NestedResultSheets[index1]);
          ((ProfileOperationData) buNestedSheet).Count = 1;
          buNestedSheetList.Add(buNestedSheet);
        }
        else
        {
          bool flag = false;
          for (int index2 = 0; index2 <= buNestedSheetList.Count - 1; ++index2)
          {
            if (((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[index1]).MaterialWidth == ((ProfileOperationData) buNestedSheetList[index2]).MaterialWidth & ((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[index1]).MaterialHeight == ((ProfileOperationData) buNestedSheetList[index2]).MaterialHeight)
            {
              buNestedSheet buNestedSheet = buNestedSheetList[index2];
              ((ProfileOperationData) buNestedSheet).Count = ((ProfileOperationData) buNestedSheet).Count + 1;
              flag = true;
              index2 = buNestedSheetList.Count;
            }
          }
          if (!flag)
          {
            buNestedSheet buNestedSheet = (buNestedSheet) new ProfileOperationData(((ProfileOperationData) Result).NestedResultSheets[index1]);
            ((ProfileOperationData) buNestedSheet).Count = 1;
            buNestedSheetList.Add(buNestedSheet);
          }
        }
      }
      string str2 = $"{str1}{buLangTranslate.preDef.Job} = {((ProfileOperationData) Result).JobName}{Environment.NewLine}";
      if (((ProfileOperationData) Result).JobExplanation.Trim().Length > 0)
        str2 = $"{str2}{AppLanguage.CadCamDynamic[3]} = {((ProfileOperationData) Result).JobExplanation}{Environment.NewLine}";
      string str3 = $"{str2}{AppLanguage.CadCamDynamic[85]} = {((ProfileOperationData) Result).ExecutionTime.ToString("f1")} {AppLanguage.CadCamDynamic[102]}{Environment.NewLine}";
      if (((ProfileOperationData) Result).PastalWidth > 0.0)
        str3 = $"{str3}{buLangTranslate.preDef.Pastal} {AppLanguage.CadCamDynamic[15]} = {((ProfileOperationData) Result).PastalWidth.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()}{Environment.NewLine}";
      if (((ProfileOperationData) Result).PartGap > 0.0)
        str3 = $"{str3}{buLangTranslate.preDef.Part} {AppLanguage.CadCamDynamic[100]} = {((ProfileOperationData) Result).PartGap.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()}{Environment.NewLine}";
      if (((ProfileOperationData) Result).OrderedTotalPartCount > 0)
        str3 = $"{str3}{buLangTranslate.preDef.Part} {AppLanguage.CadCamDynamic[53]} = {((ProfileOperationData) Result).NestedTotalPartCount.ToString()} \\ {((ProfileOperationData) Result).OrderedTotalPartCount.ToString()}{Environment.NewLine}";
      if (((ProfileOperationData) Result).NestedSheetCount > 0)
        str3 = $"{str3}{buLangTranslate.preDef.Sheet} {buLangTranslate.preDef.Count} = {((ProfileOperationData) Result).NestedSheetCount.ToString()}{Environment.NewLine}";
      if (buNestedSheetList.Count > 0)
      {
        for (int index = 0; index <= buNestedSheetList.Count - 1; ++index)
        {
          string str4 = ((ProfileOperationDataCut) buNestedSheetList[index]).Name.Trim();
          if (str4.Length == 0)
            str4 = buLangTranslate.preDef.Sheet;
          str3 = $"{str3} - {((ProfileOperationData) buNestedSheetList[index]).Count.ToString()} \\ {((ProfileOperationData) Result).NestedSheetCount.ToString()} {str4} {buLangTranslate.preDef.Count} = {((ProfileOperationData) buNestedSheetList[index]).MaterialWidth.ToString("f1")} x {((ProfileOperationData) buNestedSheetList[index]).MaterialHeight.ToString("f1")}{Environment.NewLine}";
        }
      }
      if (((ProfileOperationData) Result).MaxXPosition > 0.0 & ((ProfileOperationData) Result).NestedResultSheets.Count == 1)
        str3 = $"{str3}Max {AppLanguage.CadCamDynamic[0]} = {((ProfileOperationData) Result).MaxXPosition.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()}{Environment.NewLine}";
      double num1 = 0.0;
      for (int index = 0; index <= ((ProfileOperationData) Result).NestedResultSheets.Count - 1; ++index)
      {
        if (((ProfileClamperSettings) Settings).CalculationShowFormat == nestCalculationShowFormat.MultiSheet)
          num1 += ((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[index]).UsingPersentage;
        else if (((ProfileClamperSettings) Settings).CalculationShowFormat == nestCalculationShowFormat.PastalAsSingleSheet)
          num1 += ((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[index]).UsingPersentageFromMaxX;
      }
      double num2 = num1 / (double) ((ProfileOperationData) Result).NestedResultSheets.Count;
      string str5 = $"{str3}{buLangTranslate.preDef.Efficiency} = %{num2.ToString("f2")}{Environment.NewLine}";
      if (((ProfileOperationData) Result).ExecutionDate.Year > 2000)
        str5 = $"{str5}{AppLanguage.CadCamDynamic[101]} = {((ProfileOperationData) Result).ExecutionDate.ToString("MM/dd/yyyy-HH:mm:ss")}{Environment.NewLine}";
      double Second1 = 0.0;
      double Second2 = 0.0;
      double num3 = 0.0;
      double num4 = 0.0;
      for (int index = 0; index <= ((ProfileOperationData) Result).NestedResultSheets.Count - 1; ++index)
      {
        if (((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[index]).GCodeResult != null)
        {
          Second1 += ((F_CutterOffsetEntities) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[index]).GCodeResult).TotalTimeAsSec;
          Second2 += ((F_NotchEdit) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[index]).GCodeResult).OperationTimeAsSec;
          num3 += ((F_NotchEdit) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[index]).GCodeResult).TotalLengthAsMeter;
          num4 += ((F_NotchEdit) ((ProfileOperationDataHole) ((ProfileOperationData) Result).NestedResultSheets[index]).GCodeResult).OperationLengthAsMeter;
        }
      }
      if (Second1 > 0.0)
        str5 = $"{$"{$"{$"{str5 + Environment.NewLine}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Time} =  {buNumeric5.SecondToTimeFormat(Second1)} - "}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Time} =  {buNumeric5.SecondToTimeFormat(Second2)}{Environment.NewLine}"}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length} =  {num3.ToString("f2")} m - "}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Length} =  {num4.ToString("f2")} m - ";
      buNestedSheetList.Clear();
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

  public static string NestedSheetInfoForCutter(
    buNestedResult Result,
    int Index,
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
      double num = 0.0;
      if (((ProfileClamperSettings) Settings).CalculationShowFormat == nestCalculationShowFormat.MultiSheet)
        num += ((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[Index]).UsingPersentage;
      else if (((ProfileClamperSettings) Settings).CalculationShowFormat == nestCalculationShowFormat.PastalAsSingleSheet)
        num += ((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[Index]).UsingPersentageFromMaxX;
      string str4 = $"{$"{str3}{buLangTranslate.preDef.Pastal} {buLangTranslate.preDef.Efficiency} = %{num.ToString("f2")}{Environment.NewLine}"}{buLangTranslate.preDef.Pastal} {buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length} = {(((ProfileOperationData) ((ProfileOperationData) Result).NestedResultSheets[Index]).TotalLength / 1000.0).ToString("f2")} m{Environment.NewLine}";
      if (((ProfileOperationData) Result).OrderedTotalPartCount > 0)
        str4 = $"{str4}{buLangTranslate.preDef.Part} {AppLanguage.CadCamDynamic[53]} = {((ProfileOperationData) Result).NestedTotalPartCount.ToString()} \\ {((ProfileOperationData) Result).OrderedTotalPartCount.ToString()}{Environment.NewLine}";
      string str5 = $"{str4}{buLangTranslate.preDef.Nesting} {AppLanguage.CadCamDynamic[85]} = {((ProfileOperationData) Result).ExecutionTime.ToString("f1")} {AppLanguage.CadCamDynamic[102]}{Environment.NewLine}";
      if (((ProfileOperationData) Result).PartGap > 0.0)
        str5 = $"{str5}{buLangTranslate.preDef.Part} {AppLanguage.CadCamDynamic[100]} = {((ProfileOperationData) Result).PartGap.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()}{Environment.NewLine}";
      if (((ProfileOperationDataNotch) ((ProfileOperationData) Result).NestedResultSheets[Index]).Parts.Count > 0)
        str5 = $"{str5}{buLangTranslate.preDef.Part} {buLangTranslate.preDef.Rotation} = {((ProfileOperationDataText) ((ProfileOperationDataNotch) ((ProfileOperationData) Result).NestedResultSheets[Index]).Parts[0]).Rotation.ToString()}{Environment.NewLine}";
      if (((ProfileOperationData) Result).MaxXPosition > 0.0 & ((ProfileOperationData) Result).NestedResultSheets.Count == 1)
        str5 = $"{str5}{buLangTranslate.preDef.Pastal} {AppLanguage.CadCamDynamic[0]} = {((ProfileOperationData) Result).MaxXPosition.ToString("f2")} {((ProfileClamperSettings) Settings).UnitLength.ToString()}{Environment.NewLine}";
      if (((ProfileOperationDataPolygon) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecutionTimeSec > 0.0)
      {
        TimeSpan timeSpan = TimeSpan.FromSeconds(((ProfileOperationDataPolygon) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecutionTimeSec);
        string str6 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
        str5 = $"{str5}{buLangTranslate.preDef.Approx} {buLangTranslate.preDef.Time} = {str6}{Environment.NewLine}";
        if (((ProfileOperationDataBarel) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution0TimeSec > 0.0)
        {
          timeSpan = TimeSpan.FromSeconds(((ProfileOperationDataBarel) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution0TimeSec);
          string str7 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
          str5 = $"{str5}{buLangTranslate.preDef.Approx} {buLangTranslate.preDef.Layer} 0 {buLangTranslate.preDef.Time} = {str7}{Environment.NewLine}";
        }
        if (((ProfileOperationDataBarel) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution1TimeSec > 0.0)
        {
          timeSpan = TimeSpan.FromSeconds(((ProfileOperationDataBarel) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution1TimeSec);
          string str8 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
          str5 = $"{str5}{buLangTranslate.preDef.Approx} {buLangTranslate.preDef.Layer} 1 {buLangTranslate.preDef.Time} = {str8}{Environment.NewLine}";
        }
        if (((ProfileOperationDataBarel) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution2TimeSec > 0.0)
        {
          timeSpan = TimeSpan.FromSeconds(((ProfileOperationDataBarel) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution2TimeSec);
          string str9 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
          str5 = $"{str5}{buLangTranslate.preDef.Approx} {buLangTranslate.preDef.Layer} 2 {buLangTranslate.preDef.Time} = {str9}{Environment.NewLine}";
        }
        if (((ProfileOperationDataSlot) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution3TimeSec > 0.0)
        {
          timeSpan = TimeSpan.FromSeconds(((ProfileOperationDataSlot) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution3TimeSec);
          string str10 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
          str5 = $"{str5}{buLangTranslate.preDef.Approx} {buLangTranslate.preDef.Layer} 3 {buLangTranslate.preDef.Time} = {str10}{Environment.NewLine}";
        }
        if (((ProfileOperationDataSlot) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution4TimeSec > 0.0)
        {
          timeSpan = TimeSpan.FromSeconds(((ProfileOperationDataSlot) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution4TimeSec);
          string str11 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
          str5 = $"{str5}{buLangTranslate.preDef.Approx} {buLangTranslate.preDef.Layer} 4 {buLangTranslate.preDef.Time} = {str11}{Environment.NewLine}";
        }
        if (((ProfileOperationDataSlot) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution5TimeSec > 0.0)
        {
          timeSpan = TimeSpan.FromSeconds(((ProfileOperationDataSlot) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution5TimeSec);
          string str12 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
          str5 = $"{str5}{buLangTranslate.preDef.Approx} {buLangTranslate.preDef.Layer} 5 {buLangTranslate.preDef.Time} = {str12}{Environment.NewLine}";
        }
        if (((ProfileOperationDataSlot) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution6TimeSec > 0.0)
        {
          timeSpan = TimeSpan.FromSeconds(((ProfileOperationDataSlot) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution6TimeSec);
          string str13 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
          str5 = $"{str5}{buLangTranslate.preDef.Approx} {buLangTranslate.preDef.Layer} 6 {buLangTranslate.preDef.Time} = {str13}{Environment.NewLine}";
        }
        if (((ProfileOperationDataSlot) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution7TimeSec > 0.0)
        {
          timeSpan = TimeSpan.FromSeconds(((ProfileOperationDataSlot) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution7TimeSec);
          string str14 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
          str5 = $"{str5}{buLangTranslate.preDef.Approx} {buLangTranslate.preDef.Layer} 7 {buLangTranslate.preDef.Time} = {str14}{Environment.NewLine}";
        }
        if (((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution8TimeSec > 0.0)
        {
          timeSpan = TimeSpan.FromSeconds(((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution8TimeSec);
          string str15 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
          str5 = $"{str5}{buLangTranslate.preDef.Approx} {buLangTranslate.preDef.Layer} 8 {buLangTranslate.preDef.Time} = {str15}{Environment.NewLine}";
        }
        if (((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution9TimeSec > 0.0)
        {
          timeSpan = TimeSpan.FromSeconds(((ProfileOperationDataCut) ((ProfileOperationData) Result).NestedResultSheets[Index]).ApproxExecution9TimeSec);
          string str16 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
          str5 = $"{str5}{buLangTranslate.preDef.Approx} {buLangTranslate.preDef.Layer} 9 {buLangTranslate.preDef.Time} = {str16}{Environment.NewLine}";
        }
      }
      return str5;
    }
    catch (Exception ex)
    {
      string str = "ID:00400011";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }
}
