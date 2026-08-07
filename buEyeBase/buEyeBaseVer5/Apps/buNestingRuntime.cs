// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingRuntime
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingRuntime : buSerilization5
{
  public string pathSaveCode;
  public string pathOpenCode;
  public string pathTool;
  public string pathEngraving;
  public string path3DJob;
  public Point3D engravingPoint;
  public bool engravingRough;
  public bool engravingFinish;
  public bool shapeStepEnable;
  public double shapeStepValue;
  public string CabinetpathImport;
  public string CabinetpathExport;
  public string CabinetpathDeleted;
  public string CabinetReferanceKey;
  public bool CabinetSubFolder;
  public bool CabinetShowInfo;
  public bool CabinetMirrorIfSlotClamperSide;
  public bool CabinetMirrorIfNoClamperSideAvailable;
  public string CabinetAutoFileExtension;
  public int CabinetAutoCycleTickMs;
  public int CabinetAutoCycleTickDelayMs;
  public bool CabinetAutoCycleDeleteAndMove;
  public bool ToolExpertMode;
  public string RecentSaveFile1;
  public string RecentSaveFile2;
  public string RecentSaveFile3;
  public string RecentSaveFile4;
  public string RecentSaveFile5;
  public string RecentSaveFile6;
  public string RecentOpenFile1;
  public string RecentOpenFile2;
  public string RecentOpenFile3;
  public string RecentOpenFile4;
  public string RecentOpenFile5;
  public string RecentOpenFile6;
  public static byte f00418D;
  public bool simRelease;
  public DrillMove activeMove;
  public int acliveLine;
  public string layerPanel;
  public string layerOperation;
  public string layerGeneral;
  public string layerSelected;
  public string layerCam;
  public static byte f004196;
  public double Y1Y2ZoneSelectionLimit;
  public planeBoxNames Plane;
  public bool SetAsUsed;

  public bool isDrillSameForSameLine(DrillCalcItem refItem, DrillCalcItem checkİtem)
  {
    return buConversion5.EQ(((DrillRuntimeSettings) refItem).Diameter, ((DrillRuntimeSettings) checkİtem).Diameter) && buConversion5.EQ(((DrillRuntimeSettings) refItem).Depth, ((DrillRuntimeSettings) checkİtem).Depth) && ((DrillRuntimeSettings) refItem).planeName == ((DrillRuntimeSettings) checkİtem).planeName;
  }

  public void isHorizontalDrillAvailabe(
    List<DrillItem> Drills,
    DrillItem refDrill,
    double RepeatDistance,
    int Index,
    ref int Count)
  {
    Count = 0;
    for (int index = Index + 1; index <= Drills.Count - 1; ++index)
    {
      if (buConversion5.EQ((((DrillRuntimeSettings) Drills[index]).Center.Y - ((DrillRuntimeSettings) refDrill).Center.Y) % RepeatDistance, 0.0, 0.05))
        ++Count;
    }
  }

  public void isVerticalDrillAvailable(DrillItem refDrill, List<DrillItem> Drills, ref int Count)
  {
    Count = 0;
    for (int index = 0; index <= Drills.Count - 1; ++index)
    {
      if (!((DrillRuntimeSettings) Drills[index]).Calculated && buConversion5.EQ(((DrillRuntimeSettings) Drills[index]).Center.Y, ((DrillRuntimeSettings) refDrill).Center.Y, 0.05))
        ++Count;
    }
  }
}
