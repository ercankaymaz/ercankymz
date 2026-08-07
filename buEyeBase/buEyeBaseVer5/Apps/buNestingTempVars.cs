// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingTempVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingTempVars : buSerilization5
{
  public bool IgnoreUsedInfo;
  public bool SelectVerticalTools;
  public bool SelectHorizontalTools;

  public void isHorizontalDrillAvailabe(
    List<DrillCalcItem> Drills,
    DrillCalcItem refDrill,
    double RepeatDistance,
    int Index,
    ref int Count)
  {
    double MaxYDistance = 0.0;
    this.isHorizontalDrillAvailabe(Drills, refDrill, RepeatDistance, Index, ref Count, ref MaxYDistance);
  }

  public void isHorizontalDrillAvailabe(
    List<DrillCalcItem> Drills,
    DrillCalcItem refDrill,
    double RepeatDistance,
    int Index,
    ref int Count,
    ref double MaxYDistance)
  {
    Count = 0;
    double num1 = double.MinValue;
    for (int index = Index + 1; index <= Drills.Count - 1; ++index)
    {
      double num2 = ((DrillRuntimeSettings) Drills[index]).Center.Y - ((DrillRuntimeSettings) refDrill).Center.Y;
      double num3 = ((DrillRuntimeSettings) Drills[index]).Center.Z - ((DrillRuntimeSettings) refDrill).Center.Z;
      if (buConversion5.EQ(num2 % RepeatDistance, 0.0, 0.05) & buConversion5.EQ(num3, 0.0, 0.05) & ((DrillRuntimeSettings) refDrill).Diameter == ((DrillRuntimeSettings) Drills[index]).Diameter & ((DrillRuntimeSettings) refDrill).planeName == ((DrillRuntimeSettings) Drills[index]).planeName & ((DrillRuntimeSettings) refDrill).ID != ((DrillRuntimeSettings) Drills[index]).ID & ((DrillRuntimeSettings) refDrill).Depth == ((DrillRuntimeSettings) Drills[index]).Depth)
      {
        if (num2 > num1)
          num1 = num2;
        ++Count;
      }
    }
    MaxYDistance = num1;
    if (MaxYDistance != double.MinValue)
      return;
    MaxYDistance = 0.0;
  }
}
