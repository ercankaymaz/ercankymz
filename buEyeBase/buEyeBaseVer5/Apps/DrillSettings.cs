// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillSettings : buSerilization5
{
  public List<DrillItem> ItemShape;
  public List<DrillMove> Moves;
  public List<DrillMove> SimulationMoves;
  public List<string> Codes;
  public List<camTp> Cams;
  public List<DrillItem> NoCalculatedItems;
  public List<string> ErrorCodes;
  public MaterialBase5 Material;
  public int TotalCount;
  public int Used;
  public double FirstClamperX;
  public double SecondClamperX;
  public double TotalSec;
  public bool isError;
  public bool isLesSafe;
  public bool isSingleClamper;
  public bool isSorted;
  public bool isClamperSideDrillOpAvailable;
  public bool isClamperSideMillingOpAvailable;
  public bool isClamperSideSlotOpAvailable;
  public bool MakeContour;

  public string JobPatternName(FoamPattern Item)
  {
    string str1 = buLangTranslate.preDef.Pattern;
    if (((DrillItemBase) Item).PatternName.Trim().Length > 0)
      str1 = ((DrillItemBase) Item).PatternName.Trim();
    string str2 = "";
    string str3 = "";
    string str4 = $"{buLangTranslate.preDef.Height}: {((DrillItem) Item).Height.ToString()}";
    string str5 = "";
    string str6 = $"Z {buLangTranslate.preDef.Position}: {((DrillItemBase) Item).BoxMinItem.Z.ToString()}";
    if (((DrillItem) Item).planeName == FoamPlaneType.XZ)
    {
      str2 = $"X {buLangTranslate.preDef.Sequence}: {((DrillItem) Item).HorizontalIndex.ToString()}";
      str5 = $"X {buLangTranslate.preDef.Position}: {((DrillItemBase) Item).BoxMinItem.X.ToString()}";
      str3 = $"{buLangTranslate.preDef.Width}: {((DrillItem) Item).Width.ToString()}";
    }
    if (((DrillItem) Item).planeName == FoamPlaneType.YZ)
    {
      str2 = $"Y {buLangTranslate.preDef.Sequence}: {((DrillItem) Item).HorizontalIndex.ToString()}";
      str5 = $"Y {buLangTranslate.preDef.Position}: {((DrillItemBase) Item).BoxMinItem.Y.ToString()}";
      str3 = $"{buLangTranslate.preDef.Width}: {((DrillItem) Item).Width.ToString()}";
    }
    return $"{str1} - {str2} - Z: {((DrillItem) Item).VerticalIndex.ToString()} - {str3}{str4}{str5}{str6}";
  }

  public int JobPatternImageIndex(FoamPattern OP)
  {
    return ((DrillItem) OP).Type != FoamType.VForm ? (((DrillItem) OP).Type != FoamType.SForm ? (((DrillItem) OP).Type != FoamType.FromDrawing ? (((DrillItem) OP).Type != FoamType.SlicesHorizontal ? (((DrillItem) OP).Type != FoamType.SingleLine ? -1 : 8) : 7) : 6) : 5) : 4;
  }
}
