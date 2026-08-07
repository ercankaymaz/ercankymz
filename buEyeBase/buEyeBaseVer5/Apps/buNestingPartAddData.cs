// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingPartAddData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingPartAddData : buSerilization5
{
  public double Y1GroupToolHorizontalXOffset;
  public double Y1GroupToolHorizontalYOffset;
  public double Y1GroupToolHorizontalZOffset;
  public double Y1GroupToolMillingZOffset;
  public double Y1GroupToolSawZOffset;
  public double Y1GroupXOffset;
  public double Y1GroupYOffset;
  public double Y1GroupZOffset;
  public double Y1MinLimit;
  public double Y1ToolBlockWidth;
  public double Y2GroupToolVerticalXOffset;
  public double Y2GroupToolVerticalYOffset;
  public double Y2GroupToolVerticalZOffset;
  public double Y2GroupToolHorizontalXOffset;
  public double Y2GroupToolHorizontalYOffset;
  public double Y2GroupToolHorizontalZOffset;
  public double Y2GroupToolSawZOffset;
  public double Y2GroupXOffset;
  public double Y2GroupYOffset;
  public double Y2GroupZOffset;
  public double Y2MaxLimit;
  public double Y2ToolBlockWidth;
  public double Y3GroupToolVerticalXOffset;
  public double Y3GroupToolVerticalYOffset;
  public double Y3GroupToolVerticalZOffset;

  public buNestingPartAddData()
  {
  }

  static buNestingPartAddData()
  {
    DrillCNCSettings.LangQuiltingStatus = new List<string>();
    DrillCNCSettings.LangQuiltingMessage = new List<string>();
    DrillCNCSettings.LangQuiltingCaptions = new List<string>();
    DrillCNCSettings.LangQuiltingCommand = new List<string>();
  }

  public buNestingPartAddData()
  {
    ((DrillCNCSettings) this).QuiltSortSettings = (SortSettings) new ShapeRuntimeData();
    ((DrillCNCSettings) this).Heads = quiltingHeadType.Both;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
