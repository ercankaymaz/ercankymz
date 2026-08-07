// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCountertopCornerPars
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
public class marbleCountertopCornerPars : buSerilization5
{
  public double Offset;
  public double OrientationA;
  public double MaterialThickness;
  public double TargetZ;
  public CamClosedContourType ClosedOffsetType;
  public CamOpenContourType OpenOffsetType;

  public void CutEntityConcaveCorner(
    int i,
    int j,
    bool isConcave,
    ref buEntity EPre,
    ref buEntity ECur,
    ref buEntity ENext,
    ref List<List<buEntity>> ELL,
    ToolBase5 ToolSaw,
    ref marbleConvexConcaveCalculationPars Pars,
    ref List<buEntity> tempConcave,
    ref List<buEntity> tempSawEntities,
    ref List<List<buEntity>> ConcaveEntities,
    ref List<List<buEntity>> ConvexEntities)
  {
    buEntity CalcEntity1 = (buEntity) null;
    buEntity CalcEntity2 = (buEntity) null;
    buEntity CuttedEntity1 = (buEntity) null;
    buEntity CuttedEntity2 = (buEntity) null;
    double num1 = ((buUpperLine) ECur).Length();
    double num2 = 0.0;
    double num3 = ((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).InnerCutSafeDistance;
    if (!isConcave)
      num3 = ((marbleCollapsePars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).OutterCutSafeDistance;
    if ((ECur == null ? 0 : (ECur is buEllipse | ECur is buCircle ? 1 : 0)) != 0)
    {
      if (isConcave)
      {
        tempConcave.Add(buAngularDim.Copy(ECur));
        ConcaveEntities.Add(tempConcave);
      }
      else
      {
        tempConcave.Add(buAngularDim.Copy(ECur));
        ConvexEntities.Add(tempConcave);
      }
      tempConcave = new List<buEntity>();
    }
    else
    {
      if (ENext != null)
        num2 = ((buUpperLine) ENext).Length();
      if (j == 0)
      {
        double num4 = ((marbleCountertopMainData) Pars).ConcaveLength;
        if (!isConcave)
          num4 = ((marbleCountertopMainData) Pars).ConvexLength;
        if (((CustomDataSurrogate) ECur).Orientation.A != 0.0)
          num4 = ((marbleDrillPars) this).DistanceCalcFromToolDiameterAndThickness(((ToolGeometry5) ToolSaw).Geometry.Diameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, ((CustomDataSurrogate) ECur).Orientation.A) + num3;
        bool flag1 = false;
        bool flag2 = false;
        double num5 = ((buUpperLine) ECur).Length();
        if (ECur.GetType() != typeof (buLine))
        {
          flag2 = true;
          if (((marbleCountertopMainData) Pars).isInside)
            flag1 = true;
        }
        else if (num5 < ((marbleCountertopMainData) Pars).MinLength)
          flag1 = true;
        if (flag1 | flag2)
        {
          if (EPre != null)
          {
            if (((buUpperLine) EPre).Length() > ((marbleCountertopMainData) Pars).MinLength)
              buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(EPre), buCall.\u0001.EntityLength(EPre) - num4, StartPointType.End, ref CalcEntity1, ref CuttedEntity2);
            if (CuttedEntity2 != null)
              tempConcave.Add(CuttedEntity2);
            tempConcave.Add(buAngularDim.Copy(ECur));
            ((marbleCountertopMainData) Pars).FirstCornerCalculated = true;
          }
        }
        else
        {
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(ECur), buCall.\u0001.EntityLength(ECur) - num4, StartPointType.End, ref CalcEntity1, ref CuttedEntity2);
          tempConcave.Add(CuttedEntity2);
          tempSawEntities.Add(CalcEntity1);
          if (((CustomData) CalcEntity1).Marble != null)
            ((EntityInfo) ((CustomData) CalcEntity1).Marble).Trimmed = true;
        }
      }
      else
      {
        bool flag3 = false;
        if (num1 > ((marbleCountertopMainData) Pars).MinLength | ((EntityInfo) ((CustomData) ECur).Marble).Trimmed)
        {
          flag3 = true;
          if (((marbleCountertopMainData) Pars).isInside & ECur.GetType() != typeof (buLine))
            flag3 = false;
        }
        if (flag3)
        {
          double num6 = ((marbleCountertopMainData) Pars).ConcaveLength;
          if (!isConcave)
            num6 = ((marbleCountertopMainData) Pars).ConvexLength;
          if (((CustomDataSurrogate) tempSawEntities[tempSawEntities.Count - 1]).Orientation.A != 0.0)
            num6 = ((marbleDrillPars) this).DistanceCalcFromToolDiameterAndThickness(((ToolGeometry5) ToolSaw).Geometry.Diameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, ((CustomDataSurrogate) tempSawEntities[tempSawEntities.Count - 1]).Orientation.A) + num3;
          bool flag4 = false;
          if (((buUpperLine) tempSawEntities[tempSawEntities.Count - 1]).Length() < num6)
            flag4 = true;
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(tempSawEntities[tempSawEntities.Count - 1]), buCall.\u0001.EntityLength(ECur) - num6, StartPointType.End, ref CalcEntity1, ref CuttedEntity2);
          if (CuttedEntity2 != null && j < ELL[i].Count - 1 | j == ELL[i].Count - 1 & !((marbleCountertopMainData) Pars).FirstCornerCalculated && (CalcEntity1 == null ? 0 : (((CustomData) CalcEntity1).Marble != null ? 1 : 0)) != 0 && ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide == StartEndBothNoneType.None | ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide == StartEndBothNoneType.Start)
            tempConcave.Add(CuttedEntity2);
          if (CalcEntity1 != null)
          {
            if (((CustomData) CalcEntity1).Marble != null)
            {
              if (((CustomData) ECur).sortDirection == entitySortDirection.Normal)
              {
                if (((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide == StartEndBothNoneType.Start | ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide == StartEndBothNoneType.Both)
                  ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide = StartEndBothNoneType.Both;
                else
                  ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide = StartEndBothNoneType.End;
              }
              else if (((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide == StartEndBothNoneType.End | ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide == StartEndBothNoneType.Both)
                ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide = StartEndBothNoneType.Both;
              else
                ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide = StartEndBothNoneType.Start;
              ((EntityInfo) ((CustomData) CalcEntity1).Marble).Trimmed = true;
            }
            if (!flag4)
              tempSawEntities[tempSawEntities.Count - 1] = CalcEntity1;
            else
              tempSawEntities.RemoveAt(tempSawEntities.Count - 1);
          }
        }
      }
      bool flag5 = false;
      if (((num2 > ((marbleCountertopMainData) Pars).MinLength ? 1 : 0) | (ENext == null ? 0 : (((EntityInfo) ((CustomData) ENext).Marble).Trimmed ? 1 : 0))) != 0)
      {
        flag5 = true;
        if ((!((marbleCountertopMainData) Pars).isInside || ENext == null ? 0 : (ENext.GetType() != typeof (buLine) ? 1 : 0)) != 0)
          flag5 = false;
      }
      if (flag5)
      {
        double num7 = ((marbleCountertopMainData) Pars).ConcaveLength;
        if (!isConcave)
          num7 = ((marbleCountertopMainData) Pars).ConvexLength;
        if ((ENext == null ? 0 : (((CustomDataSurrogate) ENext).Orientation.A != 0.0 ? 1 : 0)) != 0)
          num7 = ((marbleDrillPars) this).DistanceCalcFromToolDiameterAndThickness(((ToolGeometry5) ToolSaw).Geometry.Diameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, ((CustomDataSurrogate) tempSawEntities[tempSawEntities.Count - 1]).Orientation.A) + num3;
        bool flag6 = false;
        if ((ENext == null ? 0 : (((buUpperLine) ENext).Length() < num7 ? 1 : 0)) != 0)
          flag6 = true;
        else if ((ENext == null ? 0 : (ENext.GetType() != typeof (buLine) ? 1 : 0)) != 0 && (((CustomData) ENext).Marble == null ? 0 : (((EntityInfo) ((CustomData) ENext).Marble).isInside ? 1 : 0)) != 0)
          flag6 = true;
        if (!flag6 && ENext != null && j < ELL[i].Count - 1 | j == ELL[i].Count - 1 & !((marbleCountertopMainData) Pars).FirstCornerCalculated)
        {
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(ENext), buCall.\u0001.EntityLength(ENext) - num7, StartPointType.Start, ref CalcEntity2, ref CuttedEntity1);
          tempConcave.Add(CuttedEntity1);
        }
        if ((CalcEntity2 == null ? 0 : (((CustomData) CalcEntity2).Marble != null ? 1 : 0)) != 0)
        {
          if (((CustomData) ENext).sortDirection == entitySortDirection.Normal)
          {
            if (((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide == StartEndBothNoneType.End | ((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide == StartEndBothNoneType.Both)
              ((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide = StartEndBothNoneType.Both;
            else
              ((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide = StartEndBothNoneType.Start;
          }
          else if (((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide == StartEndBothNoneType.Start | ((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide == StartEndBothNoneType.Both)
            ((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide = StartEndBothNoneType.Both;
          else
            ((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide = StartEndBothNoneType.End;
          ((EntityInfo) ((CustomData) CalcEntity2).Marble).Trimmed = true;
        }
        if (j < ELL[i].Count - 1)
        {
          if (CalcEntity2 != null & !flag6)
          {
            switch (CalcEntity2)
            {
              case buLine _:
                tempSawEntities.Add(CalcEntity2);
                break;
              case buArc _:
                if ((((CustomData) CalcEntity2).Marble == null ? 0 : (!((EntityInfo) ((CustomData) CalcEntity2).Marble).isInside ? 1 : 0)) != 0)
                {
                  tempSawEntities.Add(CalcEntity2);
                  break;
                }
                break;
            }
          }
        }
        else if (CalcEntity2 != null)
        {
          if (!flag6)
            tempSawEntities[0] = CalcEntity2;
          else
            tempSawEntities.RemoveAt(0);
        }
        ECur = CalcEntity2;
        if (tempConcave.Count <= 1)
          return;
        ClockDirectionType clockDirection = buCall.\u0001.GetClockDirection(tempConcave);
        if (isConcave)
        {
          if (clockDirection != ((marbleSlatPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).ConcaveDirection)
            buCall.\u0001.ChangeEntitiesDirection(ref tempConcave);
        }
        else if (clockDirection != ((marbleSlatPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).ConvexDirection)
          buCall.\u0001.ChangeEntitiesDirection(ref tempConcave);
        if (isConcave)
          ConcaveEntities.Add(tempConcave);
        else
          ConvexEntities.Add(tempConcave);
        tempConcave = new List<buEntity>();
      }
      else
      {
        if (ENext == null)
          return;
        tempConcave.Add(buAngularDim.Copy(ENext));
        ECur = ENext;
      }
    }
  }

  public void CutEntityConcaveCorner(
    int i,
    int j,
    bool isConcave,
    ref buEntity ECur,
    ref buEntity ENext,
    ref List<List<buEntity>> ELL,
    ToolBase5 ToolSaw,
    marbleConvexConcaveCalculationPars Pars,
    ref List<buEntity> tempConcave,
    ref List<buEntity> tempSawEntities,
    ref List<List<buEntity>> ConcaveEntities)
  {
    buEntity CalcEntity1 = (buEntity) null;
    buEntity CalcEntity2 = (buEntity) null;
    buEntity CuttedEntity1 = (buEntity) null;
    buEntity CuttedEntity2 = (buEntity) null;
    double num1 = ((buUpperLine) ECur).Length();
    double num2 = 0.0;
    double num3 = ((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).InnerCutSafeDistance;
    if (!isConcave)
      num3 = ((marbleCollapsePars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).OutterCutSafeDistance;
    if ((ECur == null ? 0 : (ECur is buEllipse | ECur is buCircle ? 1 : 0)) != 0)
    {
      tempConcave.Add(buAngularDim.Copy(ECur));
      ConcaveEntities.Add(tempConcave);
      tempConcave = new List<buEntity>();
    }
    else
    {
      if (ENext != null)
        num2 = ((buUpperLine) ENext).Length();
      if (j == 0)
      {
        double num4 = ((marbleCountertopMainData) Pars).ConcaveLength;
        if (!isConcave)
          num4 = ((marbleCountertopMainData) Pars).ConvexLength;
        if (((CustomDataSurrogate) ECur).Orientation.A != 0.0)
          num4 = ((marbleDrillPars) this).DistanceCalcFromToolDiameterAndThickness(((ToolGeometry5) ToolSaw).Geometry.Diameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, ((CustomDataSurrogate) ECur).Orientation.A) + num3;
        bool flag = false;
        if (((buUpperLine) ECur).Length() < num4)
          flag = true;
        buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(ECur), buCall.\u0001.EntityLength(ECur) - num4, StartPointType.End, ref CalcEntity1, ref CuttedEntity2);
        if (CuttedEntity2 != null)
        {
          if (!isConcave)
            tempConcave.Add(CuttedEntity2);
          else
            tempConcave.Add(CuttedEntity2);
        }
        if (CalcEntity1 != null && ((CustomData) CalcEntity1).Marble != null)
          ((EntityInfo) ((CustomData) CalcEntity1).Marble).Trimmed = true;
        if (!flag)
        {
          if (!isConcave)
            tempSawEntities.Add(CalcEntity1);
          else if (CalcEntity1 is buLine)
            tempSawEntities.Add(CalcEntity1);
        }
      }
      else
      {
        bool flag1 = false;
        if (num1 > ((marbleCountertopMainData) Pars).MinLength | ((EntityInfo) ((CustomData) ECur).Marble).Trimmed)
        {
          flag1 = true;
          if (((marbleCountertopMainData) Pars).isInside & ECur.GetType() != typeof (buLine))
            flag1 = false;
        }
        if (flag1)
        {
          double num5 = ((marbleCountertopMainData) Pars).ConcaveLength;
          if (!isConcave)
            num5 = ((marbleCountertopMainData) Pars).ConvexLength;
          if (((CustomDataSurrogate) tempSawEntities[tempSawEntities.Count - 1]).Orientation.A != 0.0)
            num5 = ((marbleDrillPars) this).DistanceCalcFromToolDiameterAndThickness(((ToolGeometry5) ToolSaw).Geometry.Diameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, ((CustomDataSurrogate) tempSawEntities[tempSawEntities.Count - 1]).Orientation.A) + num3;
          bool flag2 = false;
          if (((buUpperLine) tempSawEntities[tempSawEntities.Count - 1]).Length() < num5)
            flag2 = true;
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(tempSawEntities[tempSawEntities.Count - 1]), buCall.\u0001.EntityLength(ECur) - num5, StartPointType.End, ref CalcEntity1, ref CuttedEntity2);
          if (CuttedEntity2 != null)
          {
            if (!isConcave)
              tempConcave.Add(CuttedEntity2);
            else if (CuttedEntity2 is buLine)
              tempConcave.Add(CuttedEntity2);
          }
          if (CalcEntity1 != null)
          {
            if (((CustomData) CalcEntity1).Marble != null)
              ((EntityInfo) ((CustomData) CalcEntity1).Marble).Trimmed = true;
            if (!flag2)
              tempSawEntities[tempSawEntities.Count - 1] = CalcEntity1;
            else
              tempSawEntities.RemoveAt(tempSawEntities.Count - 1);
          }
        }
      }
      bool flag3 = false;
      if (num2 > ((marbleCountertopMainData) Pars).MinLength | ((EntityInfo) ((CustomData) ENext).Marble).Trimmed)
      {
        flag3 = true;
        if (((marbleCountertopMainData) Pars).isInside & ENext.GetType() != typeof (buLine))
          flag3 = false;
      }
      if (flag3)
      {
        double num6 = ((marbleCountertopMainData) Pars).ConcaveLength;
        if (!isConcave)
          num6 = ((marbleCountertopMainData) Pars).ConvexLength;
        if (((CustomDataSurrogate) ENext).Orientation.A != 0.0)
          num6 = ((marbleDrillPars) this).DistanceCalcFromToolDiameterAndThickness(((ToolGeometry5) ToolSaw).Geometry.Diameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, ((CustomDataSurrogate) tempSawEntities[tempSawEntities.Count - 1]).Orientation.A) + num3;
        bool flag4 = false;
        if (((buUpperLine) ENext).Length() < num6)
          flag4 = true;
        buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(ENext), buCall.\u0001.EntityLength(ENext) - num6, StartPointType.Start, ref CalcEntity2, ref CuttedEntity1);
        if (CuttedEntity1 != null)
        {
          if (!isConcave)
            tempConcave.Add(CuttedEntity1);
          else if (CuttedEntity1 is buLine)
            tempConcave.Add(CuttedEntity1);
        }
        if ((CalcEntity2 == null ? 0 : (((CustomData) CalcEntity2).Marble != null ? 1 : 0)) != 0)
          ((EntityInfo) ((CustomData) CalcEntity2).Marble).Trimmed = true;
        if (j < ELL[i].Count - 1)
        {
          if (CalcEntity2 != null & !flag4)
          {
            if (!isConcave)
              tempSawEntities.Add(buAngularDim.Copy(CalcEntity2));
            else if (CalcEntity2 is buLine)
              tempSawEntities.Add(CalcEntity2);
          }
        }
        else if (CalcEntity2 != null)
        {
          if (!flag4)
            tempSawEntities[0] = CalcEntity2;
          else
            tempSawEntities.RemoveAt(0);
        }
        else
          tempSawEntities.RemoveAt(0);
        ECur = CalcEntity2;
        if (tempConcave.Count <= 0)
          return;
        ClockDirectionType clockDirection = buCall.\u0001.GetClockDirection(tempConcave);
        if (isConcave)
        {
          if (clockDirection != ((marbleSlatPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).ConcaveDirection)
            buCall.\u0001.ChangeEntitiesDirection(ref tempConcave);
        }
        else if (clockDirection != ((marbleSlatPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).ConvexDirection)
          buCall.\u0001.ChangeEntitiesDirection(ref tempConcave);
        ConcaveEntities.Add(tempConcave);
        tempConcave = new List<buEntity>();
      }
      else
      {
        tempConcave.Add(buAngularDim.Copy(ENext));
        ECur = ENext;
      }
    }
  }

  public void CutEntityConcaveCorner11(
    int i,
    int j,
    bool isConcave,
    ref buEntity EPre,
    ref buEntity ECur,
    ref buEntity ENext,
    ref List<List<buEntity>> ELL,
    ToolBase5 ToolSaw,
    ref marbleConvexConcaveCalculationPars Pars,
    ref List<buEntity> tempConcave,
    ref List<buEntity> tempSawEntities,
    ref List<List<buEntity>> ConcaveEntities)
  {
    buEntity CalcEntity1 = (buEntity) null;
    buEntity CalcEntity2 = (buEntity) null;
    buEntity CuttedEntity1 = (buEntity) null;
    buEntity CuttedEntity2 = (buEntity) null;
    double num1 = ((buUpperLine) ECur).Length();
    double num2 = 0.0;
    double num3 = ((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).InnerCutSafeDistance;
    if (!isConcave)
      num3 = ((marbleCollapsePars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).OutterCutSafeDistance;
    if ((ECur == null ? 0 : (ECur is buEllipse | ECur is buCircle ? 1 : 0)) != 0)
    {
      tempConcave.Add(buAngularDim.Copy(ECur));
      ConcaveEntities.Add(tempConcave);
      tempConcave = new List<buEntity>();
    }
    else
    {
      if (ENext != null)
        num2 = ((buUpperLine) ENext).Length();
      if (j == 0)
      {
        double num4 = ((marbleCountertopMainData) Pars).ConcaveLength;
        if (!isConcave)
          num4 = ((marbleCountertopMainData) Pars).ConvexLength;
        if (((CustomDataSurrogate) ECur).Orientation.A != 0.0)
          num4 = ((marbleDrillPars) this).DistanceCalcFromToolDiameterAndThickness(((ToolGeometry5) ToolSaw).Geometry.Diameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, ((CustomDataSurrogate) ECur).Orientation.A) + num3;
        bool flag1 = false;
        bool flag2 = false;
        double num5 = ((buUpperLine) ECur).Length();
        if (ECur.GetType() != typeof (buLine))
        {
          flag2 = true;
          if (((marbleCountertopMainData) Pars).isInside)
            flag1 = true;
        }
        else if (num5 < ((marbleCountertopMainData) Pars).MinLength)
          flag1 = true;
        if (flag1 | flag2)
        {
          if (EPre != null)
          {
            if (((buUpperLine) EPre).Length() > ((marbleCountertopMainData) Pars).MinLength)
              buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(EPre), buCall.\u0001.EntityLength(EPre) - num4, StartPointType.End, ref CalcEntity1, ref CuttedEntity2);
            if (CuttedEntity2 != null)
              tempConcave.Add(CuttedEntity2);
            tempConcave.Add(buAngularDim.Copy(ECur));
            ((marbleCountertopMainData) Pars).FirstCornerCalculated = true;
          }
        }
        else
        {
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(ECur), buCall.\u0001.EntityLength(ECur) - num4, StartPointType.End, ref CalcEntity1, ref CuttedEntity2);
          tempConcave.Add(CuttedEntity2);
          tempSawEntities.Add(CalcEntity1);
          if (((CustomData) CalcEntity1).Marble != null)
            ((EntityInfo) ((CustomData) CalcEntity1).Marble).Trimmed = true;
        }
      }
      else
      {
        bool flag3 = false;
        if (num1 > ((marbleCountertopMainData) Pars).MinLength | ((EntityInfo) ((CustomData) ECur).Marble).Trimmed)
        {
          flag3 = true;
          if (((marbleCountertopMainData) Pars).isInside & ECur.GetType() != typeof (buLine))
            flag3 = false;
        }
        if (flag3)
        {
          double num6 = ((marbleCountertopMainData) Pars).ConcaveLength;
          if (!isConcave)
            num6 = ((marbleCountertopMainData) Pars).ConvexLength;
          if (((CustomDataSurrogate) tempSawEntities[tempSawEntities.Count - 1]).Orientation.A != 0.0)
            num6 = ((marbleDrillPars) this).DistanceCalcFromToolDiameterAndThickness(((ToolGeometry5) ToolSaw).Geometry.Diameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, ((CustomDataSurrogate) tempSawEntities[tempSawEntities.Count - 1]).Orientation.A) + num3;
          bool flag4 = false;
          if (((buUpperLine) tempSawEntities[tempSawEntities.Count - 1]).Length() < num6)
            flag4 = true;
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(tempSawEntities[tempSawEntities.Count - 1]), buCall.\u0001.EntityLength(ECur) - num6, StartPointType.End, ref CalcEntity1, ref CuttedEntity2);
          if (CuttedEntity2 != null && j < ELL[i].Count - 1 | j == ELL[i].Count - 1 & !((marbleCountertopMainData) Pars).FirstCornerCalculated && (CalcEntity1 == null ? 0 : (((CustomData) CalcEntity1).Marble != null ? 1 : 0)) != 0 && ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide == StartEndBothNoneType.None | ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide == StartEndBothNoneType.Start)
          {
            if (!isConcave)
              tempConcave.Add(CuttedEntity2);
            else if (CuttedEntity2 is buLine)
              tempConcave.Add(CuttedEntity2);
            else if (CuttedEntity2 is buArc)
              tempConcave.Add(CuttedEntity2);
          }
          if (CalcEntity1 != null)
          {
            if (((CustomData) CalcEntity1).Marble != null)
            {
              if (((CustomData) ECur).sortDirection == entitySortDirection.Normal)
              {
                if (((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide == StartEndBothNoneType.Start | ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide == StartEndBothNoneType.Both)
                  ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide = StartEndBothNoneType.Both;
                else
                  ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide = StartEndBothNoneType.End;
              }
              else if (((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide == StartEndBothNoneType.End | ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide == StartEndBothNoneType.Both)
                ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide = StartEndBothNoneType.Both;
              else
                ((EntityInfo) ((CustomData) CalcEntity1).Marble).TrimSide = StartEndBothNoneType.Start;
              ((EntityInfo) ((CustomData) CalcEntity1).Marble).Trimmed = true;
            }
            if (!flag4)
              tempSawEntities[tempSawEntities.Count - 1] = CalcEntity1;
            else
              tempSawEntities.RemoveAt(tempSawEntities.Count - 1);
          }
        }
      }
      bool flag5 = false;
      if (((num2 > ((marbleCountertopMainData) Pars).MinLength ? 1 : 0) | (ENext == null ? 0 : (((EntityInfo) ((CustomData) ENext).Marble).Trimmed ? 1 : 0))) != 0)
      {
        flag5 = true;
        if ((!((marbleCountertopMainData) Pars).isInside || ENext == null ? 0 : (ENext.GetType() != typeof (buLine) ? 1 : 0)) != 0)
          flag5 = false;
      }
      if (flag5)
      {
        double num7 = ((marbleCountertopMainData) Pars).ConcaveLength;
        if (!isConcave)
          num7 = ((marbleCountertopMainData) Pars).ConvexLength;
        if ((ENext == null ? 0 : (((CustomDataSurrogate) ENext).Orientation.A != 0.0 ? 1 : 0)) != 0)
          num7 = ((marbleDrillPars) this).DistanceCalcFromToolDiameterAndThickness(((ToolGeometry5) ToolSaw).Geometry.Diameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, ((CustomDataSurrogate) tempSawEntities[tempSawEntities.Count - 1]).Orientation.A) + num3;
        bool flag6 = false;
        if ((ENext == null ? 0 : (((buUpperLine) ENext).Length() < num7 ? 1 : 0)) != 0)
          flag6 = true;
        else if ((ENext == null ? 0 : (ENext.GetType() != typeof (buLine) ? 1 : 0)) != 0 && (((CustomData) ENext).Marble == null ? 0 : (((EntityInfo) ((CustomData) ENext).Marble).isInside ? 1 : 0)) != 0)
          flag6 = true;
        if (!flag6 && ENext != null && j < ELL[i].Count - 1 | j == ELL[i].Count - 1 & !((marbleCountertopMainData) Pars).FirstCornerCalculated)
        {
          buCall.\u0001.EntityUpdateByLength(buAngularDim.Copy(ENext), buCall.\u0001.EntityLength(ENext) - num7, StartPointType.Start, ref CalcEntity2, ref CuttedEntity1);
          tempConcave.Add(CuttedEntity1);
        }
        if ((CalcEntity2 == null ? 0 : (((CustomData) CalcEntity2).Marble != null ? 1 : 0)) != 0)
        {
          if (((CustomData) ENext).sortDirection == entitySortDirection.Normal)
          {
            if (((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide == StartEndBothNoneType.End | ((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide == StartEndBothNoneType.Both)
              ((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide = StartEndBothNoneType.Both;
            else
              ((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide = StartEndBothNoneType.Start;
          }
          else if (((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide == StartEndBothNoneType.Start | ((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide == StartEndBothNoneType.Both)
            ((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide = StartEndBothNoneType.Both;
          else
            ((EntityInfo) ((CustomData) CalcEntity2).Marble).TrimSide = StartEndBothNoneType.End;
          ((EntityInfo) ((CustomData) CalcEntity2).Marble).Trimmed = true;
        }
        if (j < ELL[i].Count - 1)
        {
          if (CalcEntity2 != null & !flag6)
          {
            if (!isConcave)
            {
              tempSawEntities.Add(buAngularDim.Copy(CalcEntity2));
            }
            else
            {
              switch (CalcEntity2)
              {
                case buLine _:
                  tempSawEntities.Add(CalcEntity2);
                  break;
                case buArc _:
                  if ((((CustomData) CalcEntity2).Marble == null ? 0 : (!((EntityInfo) ((CustomData) CalcEntity2).Marble).isInside ? 1 : 0)) != 0)
                  {
                    tempSawEntities.Add(CalcEntity2);
                    break;
                  }
                  break;
              }
            }
          }
        }
        else if (CalcEntity2 != null)
        {
          if (!flag6)
            tempSawEntities[0] = CalcEntity2;
          else
            tempSawEntities.RemoveAt(0);
        }
        ECur = CalcEntity2;
        if (tempConcave.Count <= 1)
          return;
        ClockDirectionType clockDirection = buCall.\u0001.GetClockDirection(tempConcave);
        if (isConcave)
        {
          if (clockDirection != ((marbleSlatPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).ConcaveDirection)
            buCall.\u0001.ChangeEntitiesDirection(ref tempConcave);
        }
        else if (clockDirection != ((marbleSlatPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).ConvexDirection)
          buCall.\u0001.ChangeEntitiesDirection(ref tempConcave);
        ConcaveEntities.Add(tempConcave);
        tempConcave = new List<buEntity>();
      }
      else
      {
        if (ENext == null)
          return;
        tempConcave.Add(buAngularDim.Copy(ENext));
        ECur = ENext;
      }
    }
  }

  public void OffsetModifiedEntities(
    List<buEntity> tempSawEntities,
    ClockDirectionType CDRefEnt,
    marbleConvexConcaveCalculationPars Pars,
    ToolBase5 ToolSaw,
    MarbleItemSettings Settings,
    ref List<List<buEntity>> SawEntities)
  {
    // ISSUE: unable to decompile the method.
  }
}
