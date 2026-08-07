// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCountertopPocketPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopPocketPars : buSerilization5
{
  public bool isInside;
  public double ToolSocket;
  public double ToolThickness;
  public double ToolDiameter;

  public void ConcaveArcAngleACalculation(double ArcRadius, double SawDiameter, ref double CalcA)
  {
    try
    {
      double num1 = SawDiameter / 2.0;
      double num2 = Math.Asin(num1 / (ArcRadius + num1));
      CalcA = num2 * 180.0 / Math.PI;
      if (CalcA <= 45.0)
        return;
      CalcA = 45.0;
    }
    catch (Exception ex)
    {
    }
  }

  public void OffsetEntitiesByLevel(
    List<buEntity> tempEntities,
    List<DoubleString> StepValues,
    bool IsCircular,
    CamStepSequenceType StepType,
    ClockDirectionType CDRefEnt,
    marbleConvexConcaveCalculationPars Pars,
    ToolBase5 ToolSaw,
    MarbleItemSettings Settings,
    ref List<List<buEntity>> SawEntities)
  {
    try
    {
      for (int index1 = 0; index1 <= tempEntities.Count - 1; ++index1)
      {
        int clockDirection = (int) buCall.\u0001.GetClockDirection(((CustomDataSurrogate) tempEntities[index1]).Vertices);
        CamCuttingDirectionType cuttingDirectionType = ((marbleSlatPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).CuttingDirection;
        bool flag = ((marbleCollapsePars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).DontMoveSafeForForwardBackwardDirection;
        if (tempEntities[index1] is buCircle | tempEntities[index1] is buEllipse)
        {
          cuttingDirectionType = CamCuttingDirectionType.Forward;
          flag = false;
        }
        int num1 = 0;
        for (int index2 = 0; index2 <= StepValues.Count - 1; ++index2)
        {
          List<buEntity> refEntities = new List<buEntity>();
          buEntity copiedEntity = (buEntity) null;
          buDiametricDim.Copy(tempEntities[index1], ref copiedEntity);
          refEntities.Add(copiedEntity);
          buCall.\u0001.Move(0.0, 0.0, StepValues[index2].Value, ref refEntities);
          EntityCommands entityCommands;
          for (int index3 = 0; index3 <= refEntities.Count - 1; ++index3)
          {
            ((EntityDataSet) ((CustomData) refEntities[index3]).Info).Commands = new List<string>();
            ((EntityDataSet) ((CustomData) refEntities[index3]).Info).Options = new List<string>();
            if (index3 == 0)
              ((EntityDataSet) ((CustomData) refEntities[index3]).Info).Options.Add($"{buLangTranslate.preDef.Step} : {StepValues[index2].Value.ToString("f1")}");
            double num2;
            if (IsCircular)
            {
              if (index2 == 0)
              {
                string str1 = "";
                if (refEntities[index3] is buArc)
                {
                  string diameter = buLangTranslate.preDef.Diameter;
                  num2 = ((CustomDataSurrogate) refEntities[index3]).Radius * 2.0;
                  string str2 = num2.ToString("f1");
                  str1 = $" {diameter} : {str2}";
                }
                else if (refEntities[index3] is buCircle)
                {
                  string diameter = buLangTranslate.preDef.Diameter;
                  num2 = ((CustomDataSurrogate) refEntities[index3]).Radius * 2.0;
                  string str3 = num2.ToString("f1");
                  str1 = $" {diameter} : {str3}";
                }
                ((EntityDataSet) ((CustomData) refEntities[index3]).Info).Options.Add($"{buLangTranslate.preDef.Circular} {buLangTranslate.preDef.Moving}{str1}");
              }
              List<string> commands = ((EntityDataSet) ((CustomData) refEntities[index3]).Info).Commands;
              entityCommands = EntityCommands.CircularMove;
              string str = entityCommands.ToString();
              commands.Add(str);
            }
            else
            {
              if (index2 == 0)
              {
                List<string> options = ((EntityDataSet) ((CustomData) refEntities[index3]).Info).Options;
                string[] strArray = new string[7]
                {
                  buLangTranslate.preDef.Linear,
                  " ",
                  buLangTranslate.preDef.Moving,
                  " ",
                  buLangTranslate.preDef.Length,
                  " : ",
                  null
                };
                num2 = ((buUpperLine) refEntities[index3]).Length();
                strArray[6] = num2.ToString("f1");
                string str = string.Concat(strArray);
                options.Add(str);
              }
              List<string> commands = ((EntityDataSet) ((CustomData) refEntities[index3]).Info).Commands;
              entityCommands = EntityCommands.NoneCircularMove;
              string str4 = entityCommands.ToString();
              commands.Add(str4);
            }
            switch (StepType)
            {
              case CamStepSequenceType.FirstStep:
                ((EntityDataSet) ((CustomData) refEntities[index3]).Info).Options.Add($"{buLangTranslate.preDef.First} {buLangTranslate.preDef.Step}");
                List<string> commands1 = ((EntityDataSet) ((CustomData) refEntities[index3]).Info).Commands;
                entityCommands = EntityCommands.FirstStep;
                string str5 = entityCommands.ToString();
                commands1.Add(str5);
                break;
              case CamStepSequenceType.NormalStep:
                List<string> commands2 = ((EntityDataSet) ((CustomData) refEntities[index3]).Info).Commands;
                entityCommands = EntityCommands.NormalStep;
                string str6 = entityCommands.ToString();
                commands2.Add(str6);
                break;
              case CamStepSequenceType.LastStep:
                List<string> commands3 = ((EntityDataSet) ((CustomData) refEntities[index3]).Info).Commands;
                entityCommands = EntityCommands.LastStep;
                string str7 = entityCommands.ToString();
                commands3.Add(str7);
                break;
            }
            if (cuttingDirectionType == CamCuttingDirectionType.Forward)
            {
              List<string> commands4 = ((EntityDataSet) ((CustomData) refEntities[index3]).Info).Commands;
              entityCommands = EntityCommands.ForwardCut;
              string str8 = entityCommands.ToString();
              commands4.Add(str8);
            }
          }
          if (cuttingDirectionType == CamCuttingDirectionType.Forward)
          {
            ((marbleCountertopCornerPars) this).OffsetModifiedEntities(refEntities, CDRefEnt, Pars, ToolSaw, Settings, ref SawEntities);
          }
          else
          {
            List<List<buEntity>> SawEntities1 = new List<List<buEntity>>();
            ((marbleCountertopCornerPars) this).OffsetModifiedEntities(refEntities, CDRefEnt, Pars, ToolSaw, Settings, ref SawEntities1);
            for (int index4 = 0; index4 <= SawEntities1.Count - 1; ++index4)
            {
              if (num1 % 2 == 0)
              {
                for (int index5 = 0; index5 <= SawEntities1[index4].Count - 1; ++index5)
                {
                  List<string> commands5 = ((EntityDataSet) ((CustomData) SawEntities1[index4][index5]).Info).Commands;
                  entityCommands = EntityCommands.ForwardCut;
                  string str9 = entityCommands.ToString();
                  commands5.Add(str9);
                  if ((index2 >= StepValues.Count - 1 ? 0 : (flag & StepType != 0 ? 1 : 0)) != 0)
                  {
                    List<string> commands6 = ((EntityDataSet) ((CustomData) SawEntities1[index4][index5]).Info).Commands;
                    entityCommands = EntityCommands.DontMoveSafe;
                    string str10 = entityCommands.ToString();
                    commands6.Add(str10);
                  }
                }
                SawEntities.Add(SawEntities1[index4]);
              }
              else
              {
                for (int index6 = 0; index6 <= SawEntities1[index4].Count - 1; ++index6)
                {
                  buCall.\u0001.CamDirectionChange(ref ((CustomData) SawEntities1[index4][index6]).sortDirection);
                  if (((EntityDataSet) ((CustomData) SawEntities1[index4][index6]).Info).OffsetABC == null)
                    ((EntityDataSet) ((CustomData) SawEntities1[index4][index6]).Info).OffsetABC = (PointABC) new SortResult();
                  if (((ViewportSettings) ((EntityDataSet) ((CustomData) SawEntities1[index4][index6]).Info).OffsetABC).C == 0.0)
                    ((ViewportSettings) ((EntityDataSet) ((CustomData) SawEntities1[index4][index6]).Info).OffsetABC).C = 180.0;
                  else if (((ViewportSettings) ((EntityDataSet) ((CustomData) SawEntities1[index4][index6]).Info).OffsetABC).C == 180.0)
                    ((ViewportSettings) ((EntityDataSet) ((CustomData) SawEntities1[index4][index6]).Info).OffsetABC).C = 0.0;
                  if (SawEntities1[index4][index6] is buCircle | SawEntities1[index4][index6] is buEllipse)
                    ;
                  if (((EntityDataSet) ((CustomData) SawEntities1[index4][index6]).Info).Commands == null)
                    ((EntityDataSet) ((CustomData) SawEntities1[index4][index6]).Info).Commands = new List<string>();
                  List<string> commands7 = ((EntityDataSet) ((CustomData) SawEntities1[index4][index6]).Info).Commands;
                  entityCommands = EntityCommands.BackwardCut;
                  string str11 = entityCommands.ToString();
                  commands7.Add(str11);
                  if ((index2 >= StepValues.Count - 1 ? 0 : (flag & StepType != 0 ? 1 : 0)) != 0)
                  {
                    List<string> commands8 = ((EntityDataSet) ((CustomData) SawEntities1[index4][index6]).Info).Commands;
                    entityCommands = EntityCommands.DontMoveSafe;
                    string str12 = entityCommands.ToString();
                    commands8.Add(str12);
                  }
                }
                SawEntities.Add(SawEntities1[index4]);
              }
            }
          }
          refEntities.Clear();
          ++num1;
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void OffsetEntitiesByRegion(
    List<buEntity> tempEntities,
    List<DoubleString> StepValues,
    ClockDirectionType CDRefEnt,
    marbleConvexConcaveCalculationPars Pars,
    ToolBase5 ToolSaw,
    MarbleItemSettings Settings,
    ref List<List<buEntity>> SawEntities)
  {
    try
    {
      for (int index1 = 0; index1 <= StepValues.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= tempEntities.Count - 1; ++index2)
        {
          CamCuttingDirectionType cuttingDirectionType = ((marbleSlatPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).CuttingDirection;
          if (tempEntities[index2] is buCircle | tempEntities[index2] is buEllipse)
            cuttingDirectionType = CamCuttingDirectionType.Forward;
          int num1 = 0;
          List<buEntity> refEntities = new List<buEntity>();
          buEntity copiedEntity = (buEntity) null;
          buDiametricDim.Copy(tempEntities[index2], ref copiedEntity);
          refEntities.Add(copiedEntity);
          buCall.\u0001.Move(0.0, 0.0, StepValues[index1].Value, ref refEntities);
          if (cuttingDirectionType == CamCuttingDirectionType.Forward)
          {
            ((marbleCountertopCornerPars) this).OffsetModifiedEntities(refEntities, CDRefEnt, Pars, ToolSaw, Settings, ref SawEntities);
          }
          else
          {
            List<List<buEntity>> SawEntities1 = new List<List<buEntity>>();
            ((marbleCountertopCornerPars) this).OffsetModifiedEntities(refEntities, CDRefEnt, Pars, ToolSaw, Settings, ref SawEntities1);
            for (int index3 = 0; index3 <= SawEntities1.Count - 1; ++index3)
            {
              if (num1 % 2 == 0)
              {
                SawEntities.Add(SawEntities1[index3]);
              }
              else
              {
                for (int index4 = 0; index4 <= SawEntities1[index3].Count - 1; ++index4)
                {
                  buCall.\u0001.CamDirectionChange(ref ((CustomData) SawEntities1[index3][index4]).sortDirection);
                  if (((EntityDataSet) ((CustomData) SawEntities1[index3][index4]).Info).OffsetABC == null)
                    ((EntityDataSet) ((CustomData) SawEntities1[index3][index4]).Info).OffsetABC = (PointABC) new SortResult();
                  ((ViewportSettings) ((EntityDataSet) ((CustomData) SawEntities1[index3][index4]).Info).OffsetABC).C = 180.0;
                }
                SawEntities.Add(SawEntities1[index3]);
              }
            }
          }
          refEntities.Clear();
          int num2 = num1 + 1;
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void CutEntityConcaveCorner(
    ref List<buEntity> EL,
    ToolBase5 ToolSaw,
    marbleConvexConcaveCalculationPars Pars,
    ref List<buEntity> tempSawEntities,
    ref List<List<buEntity>> ConcaveEntities)
  {
    try
    {
      double num = ((marbleCountertopMainData) Pars).ConcaveLength;
      List<buEntity> buEntityList = new List<buEntity>();
      for (int index = 0; index <= EL.Count - 1; ++index)
      {
        if (EL[index].GetType() != typeof (buLine))
        {
          if (((CustomDataSurrogate) EL[index]).Orientation.A != 0.0)
            num = ((marbleDrillPars) this).DistanceCalcFromToolDiameterAndThickness(((ToolGeometry5) ToolSaw).Geometry.Diameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, ((CustomDataSurrogate) EL[index]).Orientation.A) + ((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).InnerCutSafeDistance;
          if (((buUpperLine) EL[index]).Length() < num)
          {
            buEntityList.Add(buAngularDim.Copy(EL[index]));
          }
          else
          {
            buEntity CalcEntity1 = (buEntity) null;
            buEntity CuttedEntity = (buEntity) null;
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(EL[index]), buCall.\u0001.EntityLength(EL[index]) - num, StartPointType.End, ref CalcEntity1, ref CuttedEntity);
            buEntityList.Add(CuttedEntity);
            CalcEntity1 = (buEntity) null;
            CuttedEntity = (buEntity) null;
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(EL[index]), buCall.\u0001.EntityLength(EL[index]) - num, StartPointType.Start, ref CalcEntity1, ref CuttedEntity);
            buEntityList.Add(CuttedEntity);
            buEntity CalcEntity2 = (buEntity) null;
            CuttedEntity = (buEntity) null;
            buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(EL[index]), buCall.\u0001.EntityLength(EL[index]) - num, StartPointType.StartAndEnd, ref CalcEntity2, ref CuttedEntity);
            tempSawEntities.Add(CalcEntity2);
          }
        }
        else
          buEntityList.Add(buAngularDim.Copy(EL[index]));
      }
      if (buEntityList.Count > 0)
        ;
    }
    catch (Exception ex)
    {
    }
  }
}
