// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestedPart
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestedPart : buSerilization5
{
  public string ClamperVersion;
  public double MillingHolderOffset;
  public int SimulationIntervalMs;
  public static byte f0040FF;
  public Color colorPanel;
  public int transparencyPanel;
  public int transparencyOperation;
  public int simulationInterval;
  public DrillMachineView MachineView;
  public double ClamperSimX1ClampZDistance;
  public double ClamperSimX2ClampZDistance;
  public double SimTopMillingOffset;
  public double SimBottomMillinOffset;
  public bool AutoOpenLastPanel;
  public bool AutoOpenLastPanelAndDrill;
  public bool DeleteDrawingAfterChangeToJob;
  public double CornerArrowLength;
  public double CornerArrowDiameter;
  public double CornerArrowConeDiameter;
  public double CornerArrowConeLength;
  public int CodeLineDecimal;
  public Color CornerArrowXColor;

  public void EnableDisableOperation(bool Status, ref DrillJob Job, int Index)
  {
    if (!(Index >= 0 & Index <= ((DrillMachineSettings) Job).Items.Count - 1))
      return;
    ((buClipperBase) ((DrillMachineSettings) Job).Items[Index]).Enable = Status;
  }

  public void FindNextVerticalDrill(
    List<List<DrillCalcItem>> ItemList,
    DrillCalcItem refItem,
    int Index,
    double RepeatDistance,
    ref List<DrillCalcItem> foundItems,
    int MaxToolCount = -1)
  {
    int num1 = 1;
    foundItems.Clear();
    for (int index1 = Index; index1 <= ItemList.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ItemList[index1].Count - 1; ++index2)
      {
        double num2 = ((DrillRuntimeSettings) ItemList[index1][index2]).Center.X - ((DrillRuntimeSettings) refItem).Center.X;
        double num3 = num2 % RepeatDistance;
        if (((DrillRuntimeSettings) ItemList[index1][index2]).Enable & !((DrillRuntimeSettings) ItemList[index1][index2]).Calculated && num2 > 0.0 & buConversion5.EQ(num3, 0.0, 0.05) & buConversion5.EQ(((DrillRuntimeSettings) refItem).Center.Y, ((DrillRuntimeSettings) ItemList[index1][index2]).Center.Y, 0.05) && num1 < MaxToolCount | MaxToolCount == -1)
        {
          foundItems.Add((DrillCalcItem) new buProfileCalc(ItemList[index1][index2]));
          ++num1;
        }
      }
    }
  }

  public void FindVerticalSameDiameterTools(
    List<ToolBase5> Tools,
    double Diameter,
    planeBoxNames Plane,
    ref int recommentIndex)
  {
    recommentIndex = 0;
    List<int> intList = new List<int>();
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    for (int index = Tools.Count - 1; index >= 0; --index)
    {
      if (Plane == planeBoxNames.Bottom & ((ToolGeometry5) Tools[index]).Geometry.Diameter == Diameter && ((ToolData5) ((ToolGeometry5) Tools[index]).Geometry).ToolDirection.Z == 1.0)
      {
        intList.Add(((ToolCamData5) ((ToolGeometry5) Tools[index]).Data).No);
        if (((ToolCamData5) ((ToolGeometry5) Tools[index]).Data).No == 261)
          flag1 = true;
        if (((ToolCamData5) ((ToolGeometry5) Tools[index]).Data).No == 264)
          flag2 = true;
        if (((ToolCamData5) ((ToolGeometry5) Tools[index]).Data).No == 267)
          flag3 = true;
      }
    }
    if (!(Plane == planeBoxNames.Bottom & intList.Count > 0))
      return;
    bool flag4 = false;
    bool flag5 = false;
    if (flag1)
    {
      bool flag6 = true;
      for (int index = 0; index <= intList.Count - 1; ++index)
      {
        if (intList[index] == 262)
          flag4 = true;
        if (intList[index] == 263)
          flag5 = true;
      }
      if (flag6 & flag4 & flag5)
      {
        recommentIndex = 261;
        return;
      }
    }
    if (flag2)
    {
      bool flag7 = true;
      for (int index = 0; index <= intList.Count - 1; ++index)
      {
        if (intList[index] == 265)
          flag4 = true;
        if (intList[index] == 266)
          flag5 = true;
      }
      if (flag7 & flag4 & flag5)
      {
        recommentIndex = 264;
        return;
      }
    }
    if (!flag3)
      return;
    bool flag8 = true;
    for (int index = 0; index <= intList.Count - 1; ++index)
    {
      if (intList[index] == 268)
        flag4 = true;
      if (intList[index] == 269)
        flag5 = true;
    }
    if (!(flag8 & flag4 & flag5))
      return;
    recommentIndex = 267;
  }

  public bool isMultiZAvailable(List<DrillCalcItem> Items)
  {
    bool flag1 = false;
    bool flag2;
    if (Items.Count >= 2)
    {
      List<double> doubleList = new List<double>();
      doubleList.Add(((DrillRuntimeSettings) Items[0]).Center.Z);
      for (int index1 = 1; index1 <= Items.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= doubleList.Count - 1; ++index2)
        {
          if (!buConversion5.EQ(doubleList[index2], ((DrillRuntimeSettings) Items[index1]).Center.Z))
          {
            flag2 = true;
            goto label_10;
          }
        }
      }
    }
    flag2 = flag1;
label_10:
    return flag2;
  }

  public void SplitDrillsByYDistanceThenSortZDir(
    List<DrillCalcItem> Items,
    SortDirection SortDir,
    ref List<List<DrillCalcItem>> SplitedItems)
  {
    List<DrillCalcItem> drillCalcItemList1 = new List<DrillCalcItem>();
    SplitedItems = new List<List<DrillCalcItem>>();
    if (Items.Count <= 0)
      return;
    drillCalcItemList1.Add((DrillCalcItem) new buProfileCalc(Items[0]));
    for (int index = 1; index <= Items.Count - 1; ++index)
    {
      if (buConversion5.EQ(((DrillRuntimeSettings) drillCalcItemList1[drillCalcItemList1.Count - 1]).Center.Y, ((DrillRuntimeSettings) Items[index]).Center.Y))
      {
        drillCalcItemList1.Add((DrillCalcItem) new buProfileCalc(Items[index]));
      }
      else
      {
        SplitedItems.Add(drillCalcItemList1);
        drillCalcItemList1 = new List<DrillCalcItem>();
        drillCalcItemList1.Add((DrillCalcItem) new buProfileCalc(Items[index]));
      }
    }
    if (drillCalcItemList1.Count > 0)
      SplitedItems.Add(drillCalcItemList1);
    for (int index = 0; index <= SplitedItems.Count - 1; ++index)
    {
      List<DrillCalcItem> drillCalcItemList2 = new List<DrillCalcItem>();
      List<DrillCalcItem> drillCalcItemList3 = this.SortByZDistance(SplitedItems[index], (DrillCalcItem) new buProfileCalc(), SortDir);
      SplitedItems[index] = drillCalcItemList3;
    }
  }

  public List<DrillCalcItem> SortByZDistance(
    List<DrillCalcItem> lst,
    DrillCalcItem refPoint,
    SortDirection Direction)
  {
    List<DrillCalcItem> drillCalcItemList = new List<DrillCalcItem>();
    if (lst.Count > 0)
    {
      drillCalcItemList.Add(lst[((buNestingResultSettings) this).NearestZPoint((DrillCalcItem) new buProfileCalc(refPoint), lst)]);
      lst.Remove(drillCalcItemList[0]);
      int num = 0;
      for (int index = 0; index < lst.Count + num; ++index)
      {
        drillCalcItemList.Add(lst[((buNestingResultSettings) this).NearestZPoint(drillCalcItemList[drillCalcItemList.Count - 1], lst)]);
        lst.Remove(drillCalcItemList[drillCalcItemList.Count - 1]);
        ++num;
      }
      if (Direction == SortDirection.LowerToBigger)
        drillCalcItemList.Reverse();
    }
    return drillCalcItemList;
  }
}
