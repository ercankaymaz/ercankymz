// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestedResultSentEventArg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buNestedResultSentEventArg
{
  public int StartToolIndex;
  public int MaxVerticalToolCount;
  public bool UpdateRuntime;
  public bool Finished;
  public bool ErrorAvailable;

  static buNestedResultSentEventArg()
  {
    DrillMachineSettings.LangDrillStatus = new List<string>();
    DrillMachineSettings.LangDrillMessage = new List<string>();
    DrillMachineSettings.LangDrillCaptions = new List<string>();
    DrillMachineSettings.LangDrillCommands = new List<string>();
  }

  public buNestedResultSentEventArg()
  {
    ((DrillMachineSettings) this).lstTop = new List<List<DrillCalcItem>>();
    ((DrillMachineSettings) this).lstBottom = new List<List<DrillCalcItem>>();
    ((DrillMachineSettings) this).lstLeftRight = new List<List<DrillCalcItem>>();
    ((DrillMachineSettings) this).lstLeft = new List<List<DrillCalcItem>>();
    ((DrillMachineSettings) this).lstRight = new List<List<DrillCalcItem>>();
    ((DrillMachineSettings) this).lstFront = new List<List<DrillCalcItem>>();
    ((DrillMachineSettings) this).lstBack = new List<List<DrillCalcItem>>();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
