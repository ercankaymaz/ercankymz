// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestedResult
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestedResult : buSerilization5
{
  public double Tool64XZeroOffset;
  public double Tool65XZeroOffset;
  public double Tool66XZeroOffset;
  public double Tool67XZeroOffset;
  public double Tool68XZeroOffset;
  public double Tool69XZeroOffset;
  public double Tool70XZeroOffset;
  public double Tool71XZeroOffset;
  public double Tool72XZeroOffset;
  public double Tool73XZeroOffset;
  public double Tool74XZeroOffset;
  public double Tool75XZeroOffset;
  public double Tool76XZeroOffset;
  public double Tool77XZeroOffset;
  public double Tool78XZeroOffset;
  public double Tool79XZeroOffset;
  public double Tool80XZeroOffset;
  public double Tool85XZeroOffset;
  public double Tool270XZeroOffset;
  public double Tool61YZeroOffset;
  public double Tool62YZeroOffset;
  public double Tool63YZeroOffset;
  public double Tool64YZeroOffset;
  public double Tool65YZeroOffset;

  public buNestedResult()
  {
    if (!buVector5.\u0001("buDrillCalc"))
      throw new RegisterException("buDrillCalc");
  }

  public void ToolToStringList(List<ToolBase5> ToolList, ref List<string> SL)
  {
    SL = new List<string>();
    for (int index = 0; index <= ToolList.Count - 1; ++index)
    {
      if (ToolList[index] != null)
      {
        string str = $"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"Tool = No: {((ToolCamData5) ((ToolGeometry5) ToolList[index]).Data).No.ToString("000")} ; "}BodyDia: {$"{((ToolGeometry5) ToolList[index]).Geometry.DiameterBody.ToString("f3"),10}"} ; "}BodyLen: {$"{((ToolGeometry5) ToolList[index]).Geometry.Length.ToString("f3"),10}"} ; "}CutDia: {$"{((ToolGeometry5) ToolList[index]).Geometry.Diameter.ToString("f3"),10}"} ; "}CutLen: {$"{((ToolGeometry5) ToolList[index]).Geometry.CutLength.ToString("f3"),10}"} ; "}Dir: {buNumeric5.ToolDirectionToString(((ToolData5) ((ToolGeometry5) ToolList[index]).Geometry).ToolDirection)} ; "}Purpose: {$"{Convert.ToInt32((object) ((ToolGeometry5) ToolList[index]).Purpose).ToString(),3}"} ; "}Type: {$"{Convert.ToInt32((object) ((ToolData5) ((ToolGeometry5) ToolList[index]).Geometry).GeometryType).ToString(),3}"} ; "}GrpIndex: {$"{((ToolCamData5) ((ToolGeometry5) ToolList[index]).Data).GroupIndex.ToString(),3}"} ; "}GrpItemIndex: {$"{((ToolLimits5) ((ToolGeometry5) ToolList[index]).Data).GroupItemIndex.ToString(),3}"} ; "}XOffset: {$"{((MoveEventFormVars) ((ToolGeometry5) ToolList[index]).Positions).Offset.X.ToString("f3"),12}"} ; "}YOffset: {$"{((MoveEventFormVars) ((ToolGeometry5) ToolList[index]).Positions).Offset.Y.ToString("f3"),12}"} ; "}ZOffset: {$"{((MoveEventFormVars) ((ToolGeometry5) ToolList[index]).Positions).Offset.Z.ToString("f3"),12}"} ; "}XPosition: {$"{((MoveEventFormVars) ((ToolGeometry5) ToolList[index]).Positions).Position.X.ToString("f3"),12}"} ; "}YPosition: {$"{((MoveEventFormVars) ((ToolGeometry5) ToolList[index]).Positions).Position.Y.ToString("f3"),12}"} ; "}ZPosition: {$"{((MoveEventFormVars) ((ToolGeometry5) ToolList[index]).Positions).Position.Z.ToString("f3"),12}"} ; "}Location: {$"{Convert.ToInt32((object) ((ScaleEventFormVars) ((ToolGeometry5) ToolList[index]).Positions).Location).ToString(),4}"} ; "}XOffsetCommon: {$"{((MoveEventFormVars) ((ToolGeometry5) ToolList[index]).Positions).CommonOffset.X.ToString("f3"),12}"} ; "}YOffsetCommon: {$"{((MoveEventFormVars) ((ToolGeometry5) ToolList[index]).Positions).CommonOffset.Y.ToString("f3"),12}"} ; "}ZOffsetCommon: {$"{((MoveEventFormVars) ((ToolGeometry5) ToolList[index]).Positions).CommonOffset.Z.ToString("f3"),12}"} ; "}MinLimitY: {$"{((LayerBase5) ((ToolGeometry5) ToolList[index]).Limits).AxesMinLimits.Y.ToString("f3"),12}"} ; "}MaxLimitY: {$"{((LayerBase5) ((ToolGeometry5) ToolList[index]).Limits).AxesMaxLimits.Y.ToString("f3"),12}"} ; "}SPlunge: {$"{((ToolPositions5) ((ToolGeometry5) ToolList[index]).CamData).PlungeSpeed.ToString("f3"),12}"} ; "}SWait: {$"{((LayerBase5) ((ToolGeometry5) ToolList[index]).CamData).WaitTime.ToString("f3"),12}"}";
        SL.Add(str);
      }
    }
  }

  public void StringListToTool(List<string> SL, ref List<ToolBase5> ToolList)
  {
    if (SL.Count <= 0)
      return;
    for (int index1 = 0; index1 <= SL.Count - 1; ++index1)
    {
      int num = -1;
      if (SL[index1].Length > 2 && SL[index1].Substring(0, 1) != "|")
      {
        string[] strArray1 = SL[index1].Split('=');
        if (strArray1 != null && strArray1.Length >= 2)
        {
          string[] strArray2 = strArray1[1].Split(';');
          if (strArray2 != null & strArray2.Length >= 10)
          {
            ToolBase5 toolBase5 = (ToolBase5) new ToolGeometry5();
            for (int index2 = 0; index2 <= strArray2.Length - 1; ++index2)
            {
              string[] strArray3 = strArray2[index2].Split(':');
              if (index2 == 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    num = int.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  num = int.Parse(strArray3[1]);
                if (num >= 0)
                  ((ToolCamData5) ((ToolGeometry5) toolBase5).Data).No = num;
              }
              if (index2 == 1 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((ToolGeometry5) toolBase5).Geometry.DiameterBody = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((ToolGeometry5) toolBase5).Geometry.DiameterBody = double.Parse(strArray3[1]);
              }
              if (index2 == 2 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((ToolGeometry5) toolBase5).Geometry.Length = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((ToolGeometry5) toolBase5).Geometry.Length = double.Parse(strArray3[1]);
              }
              if (index2 == 3 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((ToolGeometry5) toolBase5).Geometry.Diameter = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((ToolGeometry5) toolBase5).Geometry.Diameter = double.Parse(strArray3[1]);
              }
              if (index2 == 4 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                  {
                    ((ToolGeometry5) toolBase5).Geometry.CutLength = double.Parse(strArray3[0]);
                    ((ToolDisplay5) ((ToolGeometry5) toolBase5).Geometry).Thickness = ((ToolGeometry5) toolBase5).Geometry.CutLength;
                  }
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                {
                  ((ToolGeometry5) toolBase5).Geometry.CutLength = double.Parse(strArray3[1]);
                  ((ToolDisplay5) ((ToolGeometry5) toolBase5).Geometry).Thickness = ((ToolGeometry5) toolBase5).Geometry.CutLength;
                }
              }
              if (index2 == 5 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (strArray3[0].ToLower().Trim() == "+x")
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).ToolDirection = new Vec3D(1.0, 0.0, 0.0);
                  if (strArray3[0].ToLower().Trim() == "+y")
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).ToolDirection = new Vec3D(0.0, 1.0, 0.0);
                  if (strArray3[0].ToLower().Trim() == "+z")
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).ToolDirection = new Vec3D(0.0, 0.0, 1.0);
                  if (strArray3[0].ToLower().Trim() == "-x")
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).ToolDirection = new Vec3D(-1.0, 0.0, 0.0);
                  if (strArray3[0].ToLower().Trim() == "-y")
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).ToolDirection = new Vec3D(0.0, -1.0, 0.0);
                  if (strArray3[0].ToLower().Trim() == "-z")
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).ToolDirection = new Vec3D(0.0, 0.0, -1.0);
                }
                else if (strArray3.Length == 2)
                {
                  if (strArray3[1].ToLower().Trim() == "+x")
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).ToolDirection = new Vec3D(1.0, 0.0, 0.0);
                  if (strArray3[1].ToLower().Trim() == "+y")
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).ToolDirection = new Vec3D(0.0, 1.0, 0.0);
                  if (strArray3[1].ToLower().Trim() == "+z")
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).ToolDirection = new Vec3D(0.0, 0.0, 1.0);
                  if (strArray3[1].ToLower().Trim() == "-x")
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).ToolDirection = new Vec3D(-1.0, 0.0, 0.0);
                  if (strArray3[1].ToLower().Trim() == "-y")
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).ToolDirection = new Vec3D(0.0, -1.0, 0.0);
                  if (strArray3[1].ToLower().Trim() == "-z")
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).ToolDirection = new Vec3D(0.0, 0.0, -1.0);
                }
              }
              if (index2 == 6 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((ToolGeometry5) toolBase5).Purpose = (ToolPurpose) int.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((ToolGeometry5) toolBase5).Purpose = (ToolPurpose) int.Parse(strArray3[1]);
              }
              if (index2 == 7 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).GeometryType = (ToolType) int.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((ToolData5) ((ToolGeometry5) toolBase5).Geometry).GeometryType = (ToolType) int.Parse(strArray3[1]);
                if (((ToolData5) ((ToolGeometry5) toolBase5).Geometry).GeometryType == ToolType.Slot)
                {
                  ((ToolGeometry5) toolBase5).Geometry.ShoulderLength = ((ToolGeometry5) toolBase5).Geometry.Length - ((ToolGeometry5) toolBase5).Geometry.CutLength;
                  ((ToolGeometry5) toolBase5).Geometry.ShoulderDiameter = ((ToolGeometry5) toolBase5).Geometry.DiameterBody;
                }
              }
              if (index2 == 8 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((ToolCamData5) ((ToolGeometry5) toolBase5).Data).GroupIndex = int.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((ToolCamData5) ((ToolGeometry5) toolBase5).Data).GroupIndex = int.Parse(strArray3[1]);
              }
              if (index2 == 9 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((ToolLimits5) ((ToolGeometry5) toolBase5).Data).GroupItemIndex = int.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((ToolLimits5) ((ToolGeometry5) toolBase5).Data).GroupItemIndex = int.Parse(strArray3[1]);
              }
              if (index2 == 10 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).Offset.X = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).Offset.X = double.Parse(strArray3[1]);
              }
              if (index2 == 11 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).Offset.Y = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).Offset.Y = double.Parse(strArray3[1]);
              }
              if (index2 == 12 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).Offset.Z = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).Offset.Z = double.Parse(strArray3[1]);
              }
              if (index2 == 13 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).Position.X = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).Position.X = double.Parse(strArray3[1]);
              }
              if (index2 == 14 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).Position.Y = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).Position.Y = double.Parse(strArray3[1]);
              }
              if (index2 == 15 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).Position.Z = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).Position.Z = double.Parse(strArray3[1]);
              }
              if (index2 == 16 /*0x10*/ && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((ScaleEventFormVars) ((ToolGeometry5) toolBase5).Positions).Location = (ToolLocationType) int.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((ScaleEventFormVars) ((ToolGeometry5) toolBase5).Positions).Location = (ToolLocationType) int.Parse(strArray3[1]);
              }
              if (index2 == 17 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).CommonOffset.X = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).CommonOffset.X = double.Parse(strArray3[1]);
              }
              if (index2 == 18 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).CommonOffset.Y = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).CommonOffset.Y = double.Parse(strArray3[1]);
              }
              if (index2 == 19 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).CommonOffset.Z = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((MoveEventFormVars) ((ToolGeometry5) toolBase5).Positions).CommonOffset.Z = double.Parse(strArray3[1]);
              }
              if (index2 == 20 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((LayerBase5) ((ToolGeometry5) toolBase5).Limits).AxesMinLimits.Y = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((LayerBase5) ((ToolGeometry5) toolBase5).Limits).AxesMinLimits.Y = double.Parse(strArray3[1]);
              }
              if (index2 == 21 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((LayerBase5) ((ToolGeometry5) toolBase5).Limits).AxesMaxLimits.Y = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((LayerBase5) ((ToolGeometry5) toolBase5).Limits).AxesMaxLimits.Y = double.Parse(strArray3[1]);
              }
              if (index2 == 22 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((ToolPositions5) ((ToolGeometry5) toolBase5).CamData).PlungeSpeed = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((ToolPositions5) ((ToolGeometry5) toolBase5).CamData).PlungeSpeed = double.Parse(strArray3[1]);
              }
              if (index2 == 23 && num >= 0)
              {
                if (strArray3.Length == 1)
                {
                  if (buFile5.IsNumeric(strArray3[0]))
                    ((LayerBase5) ((ToolGeometry5) toolBase5).CamData).WaitTime = double.Parse(strArray3[0]);
                }
                else if (strArray3.Length == 2 && buFile5.IsNumeric(strArray3[1]))
                  ((LayerBase5) ((ToolGeometry5) toolBase5).CamData).WaitTime = double.Parse(strArray3[1]);
              }
            }
            ToolList.Add(toolBase5);
          }
        }
      }
    }
  }

  public void FindOperationToolFromString(
    List<ToolGroup5> Tools,
    ToolBase5 toolActive,
    string sTool,
    ref buShape S)
  {
    if (sTool.Trim().Length > 0)
    {
      buCall.\u0001.FindToolWithToolName(Tools, sTool.Trim(), ref ((buClipper.\u0001) S).Tool);
    }
    else
    {
      if ((Tools.Count <= 0 ? 0 : (((ToolGeometry5) Tools[0]).Tools.Count > 0 ? 1 : 0)) != 0)
        ((buClipper.\u0001) S).Tool = (ToolBase5) new ToolGeometry5(((ToolGeometry5) Tools[0]).Tools[0]);
      ((buClipper.\u0001) S).InfoMessages = new List<string>();
      ((buClipper.\u0001) S).InfoMessages.Add(buLangTranslate.preSentences.OperationToolIsNotInToolList);
    }
    if (((buClipper.\u0001) S).Tool != null)
      return;
    ((buClipper.\u0001) S).Tool = (ToolBase5) new ToolGeometry5(toolActive);
    ((buClipper.\u0001) S).InfoMessages = new List<string>();
    ((buClipper.\u0001) S).InfoMessages.Add(buLangTranslate.preSentences.OperationToolIsNotInToolList);
  }

  public bool isSingleClamperAvailable(
    DrillJob Job,
    DrillCNCSettings Settings,
    ref double X1Pos,
    ref double X2Pos)
  {
    List<double> doubleList1 = new List<double>();
    List<double> doubleList2 = new List<double>();
    for (int index = 0; index <= ((DrillMachineSettings) Job).ItemCalc.Count - 1; ++index)
    {
      if (((DrillRuntimeSettings) ((DrillMachineSettings) Job).ItemCalc[index]).planeName == planeBoxNames.Front | ((DrillRuntimeSettings) ((DrillMachineSettings) Job).ItemCalc[index]).planeName == planeBoxNames.Back)
      {
        if (Math.Abs(((DrillRuntimeSettings) ((DrillMachineSettings) Job).ItemCalc[index]).Center.Y) < ((TuftingSequenceItem) Settings).ClamperCatchWidth + ((buNestingSheetAddData) Settings).HorizontalToolHolderWidth / 2.0)
          doubleList1.Add(((DrillRuntimeSettings) ((DrillMachineSettings) Job).ItemCalc[index]).Center.X);
        else
          doubleList2.Add(((DrillRuntimeSettings) ((DrillMachineSettings) Job).ItemCalc[index]).Center.X);
      }
      else if (Math.Abs(((DrillRuntimeSettings) ((DrillMachineSettings) Job).ItemCalc[index]).Center.Y) < ((TuftingSequenceItem) Settings).ClamperCatchWidth)
        doubleList1.Add(((DrillRuntimeSettings) ((DrillMachineSettings) Job).ItemCalc[index]).Center.X);
      else
        doubleList2.Add(((DrillRuntimeSettings) ((DrillMachineSettings) Job).ItemCalc[index]).Center.X);
    }
    bool flag;
    if (doubleList1.Count >= 2)
    {
      for (int index = 1; index <= doubleList1.Count - 1; ++index)
      {
        if (doubleList1[index] - doubleList1[index - 1] > ((buNestingCalc) Settings).ClamperLength + ((buNestingCalc) Settings).ClamperBetweenMinDistance)
        {
          X2Pos = -Math.Abs(doubleList1[index - 1] + (doubleList1[index] - doubleList1[index - 1]) / 2.0);
          X1Pos = -(((SortResult) ((DrillSettings) Job).Material).Size.Width + ((buNestingCalc) Settings).ClamperLength + 3.0 * ((buNestingCalc) Settings).ClamperLength);
          flag = true;
          goto label_25;
        }
      }
      double num1 = Math.Abs(doubleList1[0]);
      if (num1 > ((buNestingCalc) Settings).ClamperLength + ((buNestingCalc) Settings).ClamperBetweenMinDistance)
      {
        X2Pos = -num1 / 2.0;
        X1Pos = -(((SortResult) ((DrillSettings) Job).Material).Size.Width + ((buNestingCalc) Settings).ClamperLength + 3.0 * ((buNestingCalc) Settings).ClamperLength);
        flag = true;
        goto label_25;
      }
      double num2 = ((SortResult) ((DrillSettings) Job).Material).Size.Width + ((buNestingCalc) Settings).ClamperLength * 0.3;
      if (num2 - Math.Abs(doubleList1[doubleList1.Count - 1]) > ((buNestingCalc) Settings).ClamperLength + ((buNestingCalc) Settings).ClamperBetweenMinDistance)
      {
        X2Pos = -Math.Abs(doubleList1[doubleList1.Count - 1] + (num2 - doubleList1[doubleList1.Count - 1]) / 2.0);
        X1Pos = -(((SortResult) ((DrillSettings) Job).Material).Size.Width + ((buNestingCalc) Settings).ClamperLength + 3.0 * ((buNestingCalc) Settings).ClamperLength);
        flag = true;
        goto label_25;
      }
    }
    if (doubleList1.Count == 1 && ((SortResult) ((DrillSettings) Job).Material).Size.Width < ((buNestingCalc) Settings).ClamperLength && doubleList1[0] == 0.0)
    {
      X2Pos = -((buNestingCalc) Settings).ClamperLength / 2.0;
      X1Pos = -(((SortResult) ((DrillSettings) Job).Material).Size.Width + ((buNestingCalc) Settings).ClamperLength + 3.0 * ((buNestingCalc) Settings).ClamperLength);
      flag = true;
    }
    else if (doubleList1.Count == 0 & doubleList2.Count > 0)
    {
      X2Pos = -((SortResult) ((DrillSettings) Job).Material).Size.Width / 2.0;
      X1Pos = -(((SortResult) ((DrillSettings) Job).Material).Size.Width + ((buNestingCalc) Settings).ClamperLength + 3.0 * ((buNestingCalc) Settings).ClamperLength);
      flag = true;
    }
    else
      flag = false;
label_25:
    return flag;
  }

  public bool SingleMustClamper(
    DrillJob Job,
    DrillCNCSettings Settings,
    ref double X1Pos,
    ref double X2Pos)
  {
    double num = -((SortResult) ((DrillSettings) Job).Material).Size.Width / 2.0;
    bool flag1 = false;
    bool flag2 = false;
    for (int index = 0; index <= ((DrillMachineSettings) Job).Items.Count - 1; ++index)
    {
      if (((buClipperBase) ((DrillMachineSettings) Job).Items[index]).planeName == planeBoxNames.Right)
        flag1 = true;
      if (((buClipperBase) ((DrillMachineSettings) Job).Items[index]).planeName == planeBoxNames.Left)
        flag2 = true;
    }
    if (!flag2)
      num = -((buNestingCalc) Settings).ClamperLength / 2.0;
    else if (!flag1)
      num = -((SortResult) ((DrillSettings) Job).Material).Size.Width + ((buNestingCalc) Settings).ClamperLength / 2.0;
    X2Pos = num;
    X1Pos = -(((SortResult) ((DrillSettings) Job).Material).Size.Width + ((buNestingCalc) Settings).ClamperLength + 3.0 * ((buNestingCalc) Settings).ClamperLength);
    return true;
  }

  public void ChangeCornerOpposite(ref CornerLocation Corner)
  {
    if (Corner == CornerLocation.RightBottom)
      Corner = CornerLocation.LeftBottom;
    else if (Corner == CornerLocation.RightTop)
      Corner = CornerLocation.LeftTop;
    else if (Corner == CornerLocation.RightCenter)
      Corner = CornerLocation.LeftCenter;
    else if (Corner == CornerLocation.LeftBottom)
      Corner = CornerLocation.RightBottom;
    else if (Corner == CornerLocation.LeftTop)
    {
      Corner = CornerLocation.RightTop;
    }
    else
    {
      if (Corner != CornerLocation.LeftCenter)
        return;
      Corner = CornerLocation.RightCenter;
    }
  }
}
