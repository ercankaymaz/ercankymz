// Decompiled with JetBrains decompiler
// Type: buClass.Apps.TuftingSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class TuftingSettings : buSerilization
{
  public bool SaveImageFormatAfterGCodeCreat = true;
  public bool SavePropertiesFormatAfterGCodeCreat = true;
  public bool DevideGroupStartEnable = true;
  public double DevideGroupStartLength = 1.0;
  public bool DevideGroupEndEnable = true;
  public double DevideGroupEndLength = 1.0;
  public double CutModePileHeight = 0.0;
  public double LoopModePileHeight = 0.0;
  public tuftingFillOffsetType FillType = tuftingFillOffsetType.Straight;
  public double SpiralOutterOffset = 4.0;
  public double SpiralInnerOffset = 4.0;
  public double SpiralRowSpace = 5.0;
  public bool SpiralOutterEnable = false;
  public bool SpiralInnerEnable = false;
  public bool SpiralOutBorderConnect = true;
  public bool SpiralInBorderConenct = true;
  public ClockDirectionType SpiralFillDirection = ClockDirectionType.CW;
  public InOutDirection SpiralInOutDirection = InOutDirection.InsideToOutside;
  public double TraceOutterOffset = 4.0;
  public double TraceInnerOffset = 4.0;
  public double TraceRowSpace = 5.0;
  public bool TraceOutterEnable = false;
  public bool TraceInnerEnable = false;
  public bool TraceOutBorderConnect = true;
  public bool TraceInBorderConenct = true;
  public bool TraceRowLink = true;
  public bool TraceConnection = true;
  public bool TraceSplineConnection = false;
  public bool TraceConnectOneBefore = true;
  public ClockDirectionType TraceFillDirection = ClockDirectionType.CW;
  public InOutDirection TraceInOutDirection = InOutDirection.InsideToOutside;
  public double StraightOutterOffset = 4.0;
  public double StraightInnerOffset = 4.0;
  public double StraightRowSpace = 5.0;
  public double StraightDirection = 270.0;
  public double StraightAngle = 0.0;
  public int StraightOutBorderCount = 1;
  public int StraightInBorderCount = 1;
  public bool StraightOutBorderEnable = false;
  public bool StraightInBorderEnable = false;
  public bool StraightOutBorderConnect = true;
  public bool StraightInBorderConenct = true;
  public bool StraightRowLink = true;
  public tuftingBorderOffsetType StraightOutBorderType = tuftingBorderOffsetType.Contour;
  public tuftingBorderOffsetType StraightInBorderType = tuftingBorderOffsetType.Contour;
  public ClockDirectionType StraightOutBorderFillDirection = ClockDirectionType.CW;
  public ClockDirectionType StraightInBorderFillDirection = ClockDirectionType.CW;
  public double ContourOutterOffset = 4.0;
  public double ContourInnerOffset = 4.0;
  public int ContourOutBorderCount = 1;
  public int ContourInBorderCount = 1;
  public bool ContourOutBorderEnable = false;
  public bool ContourInBorderEnable = false;
  public bool ContourOutBorderConnect = true;
  public bool ContourInBorderConenct = true;
  public tuftingBorderOffsetType ContourOutBorderType = tuftingBorderOffsetType.Contour;
  public tuftingBorderOffsetType ContourInBorderType = tuftingBorderOffsetType.Contour;
  public ClockDirectionType ContourOutBorderFillDirection = ClockDirectionType.CW;
  public ClockDirectionType ContourInBorderFillDirection = ClockDirectionType.CW;
  public tuftingSelectionModeType SortType = tuftingSelectionModeType.Auto;
  public tuftingManuelModeType SortManuelMode = tuftingManuelModeType.ClickBlockPoints;
  public SortingNextGroupFindRulesType SortAutoNextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
  public SortingNextGroupFindRulesType SortManuelNextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
  public tuftingManuelModeLayerType SortLayerMode = tuftingManuelModeLayerType.SelectedLayer;
  public bool SortBoxBounding = false;
  public bool SortOutlineFirst = true;
  public double StartMarkerCircleDiameter = 3.0;
  public double EndMarkerSquareWidth = 3.0;
  public Color ShowSortedEntitiesColor = Color.WhiteSmoke;
  public double ShowSortedEntitiesThickness = 3.0;
  public int RandomPatternColorNumber = 3;
  public int RandomPatternColorLineNumber = 3;
  public double CutTolerance = 0.2;
  public double MinDistance = 2.0;
  public double MaxDistance = 50.0;
  public bool SharpCorner = true;
  public bool LinkAsSpline = false;
  public bool LockTuftEntitiesWhenCreated = true;
  public bool ShowClosedPathCalculationEntities = false;
  public double DefinationEntityThickness = 2.0;
  public static List<string> Captions = new List<string>();

  public TuftingSettings()
  {
  }

  public TuftingSettings(TuftingSettings data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }

  public override string ToString()
  {
    return $"DevideGroupStartEnable : {this.DevideGroupStartEnable.ToString()} ; DevideGroupStartLength: {this.DevideGroupStartLength.ToString()}";
  }
}
