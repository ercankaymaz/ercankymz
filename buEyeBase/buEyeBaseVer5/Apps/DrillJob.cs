// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillJob
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
public class DrillJob : buSerilization5
{
  public double LevelZ;
  public List<buEntity> entitiesInfill;
  public List<buEntity> entitiesOffsetedSlices;
  public bool ShowOperationButton;
  public int SliceCount;
  public double SliceStep;
  public bool InFill;
  public bool InFillConnect;
  public bool Simplify;
  public bool ZSpiralMove;
  public bool UseSpline;
  public double OffsetXY;
  public double NozzleDiameter;
  public double FeedSpeed;
  public double PlungeSpeed;
  public double TopHeight;
  public double FilletRadius;
  public double FilletLimitMaxAngle;
  public double FilletLimitMinAngle;
  public Printer3DSliceType SliceType;
  public Printer3DSpiralNextLEvelConnectionType SpiralConnection;
  public double SpiralConnectionDT;
  public bool SelectMode;
  public string layerSliceName;
  public string layerRegionName;
  public string layerOffsetSliceName;
  public string layerSimulationName;
  public string layerTessellationName;
  public string layerCamName;
  public string layerOnlineSimulationName;
  public string layerInFill;

  public static void Decode(List<string> Lines, ref List<PipeBendDiskBlocks> Items)
  {
    List<List<string>> CalcList = new List<List<string>>();
    buStatics.ListToSpecificList("<DiskBlocks>", "</DiskBlocks>", false, Lines, ref CalcList);
    if (Items == null)
      Items = new List<PipeBendDiskBlocks>();
    if (CalcList.Count <= 0)
      return;
    for (int index = 0; index <= CalcList.Count - 1; ++index)
    {
      object ObjPar = (object) (PipeBendDiskBlocks) new buDrillCalc();
      buSerilization5.StringToClass(ref ObjPar, CalcList[index][0]);
      if (ObjPar != null)
        Items.Add((PipeBendDiskBlocks) ObjPar);
    }
  }

  public static void Decode(List<string> Lines, ref PipeBendDiskBlocks Item)
  {
    List<string> CalcList = new List<string>();
    buStatics.ListToSpecificList("<DiskBlocks>", "</DiskBlocks>", false, Lines, ref CalcList);
    if (CalcList.Count <= 0)
      return;
    object ObjPar = (object) Item;
    buSerilization5.StringToClass(ref ObjPar, CalcList[0]);
  }

  public override string ToString()
  {
    return $"Pipe Diameter:{((SewingMain) this).BlockPipeDiameter.ToString("f1")} - DiskDiameter: {((SewingEntityCustomData) this).DiskDiameter.ToString("f1")}";
  }
}
