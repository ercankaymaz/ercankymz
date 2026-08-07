// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillMachineSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillMachineSettings : buSerilization5
{
  public double HeadDistance;
  public double RoundCorner;
  public double ClosedPatternEndExtentLength;
  public double OpenPatternEndExtentLength;
  public quiltingSortType SortType;
  public quiltingDirectionType MiddleDirection;
  public double MiddleDirectionCompareAngle;
  public bool StartFromMiddle;
  public static List<string> Captions;
  public static byte f003EE6;
  public static List<string> LangDrillStatus;
  public static List<string> LangDrillMessage;
  public static List<string> LangDrillCaptions;
  public static List<string> LangDrillCommands;
  public static byte f003EEB;
  public List<List<DrillCalcItem>> lstTop;
  public List<List<DrillCalcItem>> lstBottom;
  public List<List<DrillCalcItem>> lstLeftRight;
  public List<List<DrillCalcItem>> lstLeft;
  public List<List<DrillCalcItem>> lstRight;
  public List<List<DrillCalcItem>> lstFront;
  public List<List<DrillCalcItem>> lstBack;
  public static byte f003EF3;
  public string Name;
  public List<buShape> Items;
  public List<DrillItemBase> baseItems;
  public List<DrillCalcItem> ItemCalc;

  public string JobItemName(FoamItem Item)
  {
    string str = buLangTranslate.preDef.Foam;
    if (((DrillCalcItem) Item).ItemName.Trim().Length > 0)
      str = ((DrillCalcItem) Item).ItemName.Trim();
    return $"{str} - {buLangTranslate.preDef.Width}(X) : {((SortResult) ((DrillCalcItem) Item).Material).Size.Width.ToString()} - {buLangTranslate.preDef.Height}(Y) : {((SortResult) ((DrillCalcItem) Item).Material).Size.Height.ToString()} - {buLangTranslate.preDef.Depth}(Z) : {((SortResult) ((DrillCalcItem) Item).Material).Size.Depth.ToString()}";
  }

  public string JobBlockName(FoamBlock Item)
  {
    string str = buLangTranslate.preDef.Block;
    if (((DrillCalcItem) Item).BlockName.Trim().Length > 0)
      str = ((DrillCalcItem) Item).BlockName.Trim();
    return $"{str} -  Z: {((DrillItemBase) Item).BottomZ.ToString("f1")} - {buLangTranslate.preDef.Width}(X) : {((DrillItemBase) Item).SizeObj.Width.ToString()} - {buLangTranslate.preDef.Height}(Y) : {((DrillItemBase) Item).SizeObj.Height.ToString()} - {buLangTranslate.preDef.Depth}(Z) : {((DrillItemBase) Item).SizeObj.Depth.ToString()}";
  }
}
